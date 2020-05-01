using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversalTestingService.Additional
{
    /// <summary>
    /// Атрибут проверки перечисления
    /// </summary>
    public class EnumConformityAttribute : ValidationAttribute
    {
        /// <summary>
        /// Конструктор объекта атрибута проверки перечисления
        /// </summary>
        public EnumConformityAttribute()
        {
            ErrorMessage = "Значение не соответствует перечислению.";
        }

        /// <summary>
        /// Проверка объекта на принадлежность к перечислению
        /// </summary>
        /// <param name="value">Объект проверки</param>
        /// <returns>Результат проверки</returns>
        public override bool IsValid(object value)
        {
            bool valid = false;
            if (value != null && Enum.IsDefined(value.GetType(), value))
            {
                valid = true;
            }
            return valid;
        }
    }
}