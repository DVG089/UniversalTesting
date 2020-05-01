using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using UniversalTestingService.Additional;

namespace UniversalTestingService.Models
{
    /// <summary>
    /// Класс ответа
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// Номер ответа
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Содержание ответа
        /// </summary>
        [RangeOrNull(1, 4, ErrorMessage = "Ответ не находится в допустимом диапазоне.")]
        public int? AnswerBody { get; set; }
        /// <summary>
        /// Номер вопроса
        /// </summary>
        public int QuestionId { get; set; }
        /// <summary>
        /// Вопрос
        /// </summary>
        public Question Question { get; set; }
        /// <summary>
        /// Номер теста
        /// </summary>
        public int TestId { get; set; }
    }
}