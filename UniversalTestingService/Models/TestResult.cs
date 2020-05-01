using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversalTestingService.Models
{
    /// <summary>
    /// Класс результата теста
    /// </summary>
    public class TestResult
    {
        /// <summary>
        /// Результат теста
        /// </summary>
        public int? Result { get; set; }
        /// <summary>
        /// Максимальный результат теста
        /// </summary>
        public int MaxResult { get; set; }
    }
}