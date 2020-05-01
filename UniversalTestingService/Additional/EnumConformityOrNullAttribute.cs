using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversalTestingService.Additional
{
    /// <summary>
    /// Атрибут проверки перечисления или отсутствия значения
    /// </summary>
    public class EnumConformityOrNullAttribute : ValidationAttribute
    {
        /// <summary>
        /// Конструктор объекта атрибута проверки перечисления или отсутствия значения
        /// </summary>
        public EnumConformityOrNullAttribute()
        {
            ErrorMessage = "Значение не соответствует перечислению.";
        }

        /// <summary>
        /// Проверка объекта на принадлежность к перечислению или отсутствии значения
        /// </summary>
        /// <param name="value">Объект проверки</param>
        /// <returns>Результат проверки</returns>
        public override bool IsValid(object value)
        {
            bool valid = false;
            if (value == null || Enum.IsDefined(value.GetType(), value))
            {
                valid = true;
            }
            return valid;
        }
    }
}