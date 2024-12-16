using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AgroProject.Data;
using Microsoft.EntityFrameworkCore;

public class NotificationService : IHostedService, IDisposable
{
    private readonly IServiceScopeFactory _scopeFactory;
    private Timer _timer;

    public NotificationService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        // Запускаем проверку каждые 6 часов
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(6));
        return Task.CompletedTask;
    }

    private void DoWork(object state)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Проверяем истекающие сроки годности
            var soonExpiring = context.ReaktivPrixods
                .Where(p => p.DataIzgotovlenia.HasValue &&
                            p.DataIzgotovlenia.Value.AddYears(1).ToDateTime(TimeOnly.MinValue) <= DateTime.Now.AddDays(30))
                .ToList();

            foreach (var reagent in soonExpiring)
            {
                var message = $"Реагент {reagent.Reaktiv} истекает {reagent.DataIzgotovlenia.Value.AddYears(1):dd.MM.yyyy}";
                AddNotification(context, message);
            }

            // Проверяем минимальные остатки
            var lowStock = context.Reaktivis
                .Where(r => r.Quantity < r.MinQuantity)
                .ToList();

            foreach (var reagent in lowStock)
            {
                var message = $"Остаток реагента {reagent.Name} ниже минимума ({reagent.Quantity}/{reagent.MinQuantity}).";
                AddNotification(context, message);
            }
        }
    }

    private void AddNotification(AppDbContext context, string message)
    {
        // Создаем новую запись для таблицы уведомлений
        context.Notifications.Add(new Notification
        {
            Message = message,
            CreatedAt = DateTime.Now, // Время создания уведомления
            IsRead = false // Уведомление по умолчанию не прочитано
        });

        // Сохраняем изменения в базе данных
        context.SaveChanges();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}