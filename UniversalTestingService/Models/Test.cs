using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversalTestingService.Models
{
    /// <summary>
    /// Класс теста
    /// </summary>
    public class Test
    {
        /// <summary>
        /// Номер теста
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string UserLogin { get; set; }
        /// <summary>
        /// Предмет
        /// </summary>
        public SubjectEnum Subject { get; set; }
        /// <summary>
        /// Количество легких вопросов
        /// </summary>
        public int EasyCount { get; set; }
        /// <summary>
        /// Количество вопросов средней сложности
        /// </summary>
        public int MediumCount { get; set; }
        /// <summary>
        /// Количество сложных вопросов
        /// </summary>
        public int HardCount { get; set; }
        /// <summary>
        /// Максимальное число балов за тест
        /// </summary>
        public int MaxResult { get; set; }
        /// <summary>
        /// Результат
        /// </summary>
        public int? Result { get; set; }
        /// <summary>
        /// Список вопросов-ответов
        /// </summary>
        public List<Answer> Answers { get; set; }
    }
}