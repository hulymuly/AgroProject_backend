using System.ComponentModel.DataAnnotations;
using AgroProject.Models;

namespace AgroProject.Helpers.Validation
{
    public class SampleValidator
    {
        public static List<string> ValidateSample(RegistraciaObrazcov sample)
        {
            var errors = new List<string>();

            // Проверка обязательных полей
            if (string.IsNullOrEmpty(sample.Kulture))
                errors.Add("Поле 'Культура' обязательно.");

            if (string.IsNullOrEmpty(sample.Sort))
                errors.Add("Поле 'Сорт' обязательно.");

            if (sample.Zakazchik <= 0)
                errors.Add("Неверное значение 'Заказчик'.");

            if (string.IsNullOrEmpty(sample.VidAnaliza))
                errors.Add("Поле 'Вид анализа' обязательно.");

            if (sample.DataPostupObraz == null)
                errors.Add("Поле 'Дата поступления образца' обязательно.");

            // Проверка на положительные значения для массы
            if (!string.IsNullOrEmpty(sample.MassaObrazca) && !decimal.TryParse(sample.MassaObrazca, out var massaObrazca))
                errors.Add("Масса образца должна быть числом.");

            if (!string.IsNullOrEmpty(sample.MassaObrazca) && massaObrazca <= 0)
                errors.Add("Масса образца должна быть положительным числом.");

            return errors;
        }
    }
}
