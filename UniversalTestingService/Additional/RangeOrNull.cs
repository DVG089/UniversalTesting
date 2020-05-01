using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversalTestingService.Additional
{
    /// <summary>
    /// Задает ограничения числового диапазона для значения поля данных, разрешая null
    /// </summary>
    public class RangeOrNullAttribute : RangeAttribute
    {
        /// <summary>
        /// Конструктор объектаRangeOrNullAttribute
        /// </summary>
        /// <param name="minimum">Минимальное значение</param>
        /// <param name="maximum">Максимальное значение</param>
        public RangeOrNullAttribute(int minimum, int maximum) : base(minimum, maximum)
        {
        }

        /// <summary>
        /// Проверка объекта на принадлежность к числовому диапазону или отсутствии значения
        /// </summary>
        /// <param name="value">Объект проверки</param>
        /// <returns>Результат проверки</returns>
        public override bool IsValid(object value)
        {
            bool valid;
            if (value == null)
            {
                valid = true;
            }
            else
            {
                valid = base.IsValid(value);
            }
            return valid;
        }
    }
}