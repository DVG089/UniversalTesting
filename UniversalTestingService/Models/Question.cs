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
    /// Класс вопроса
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Номер вопроса
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Текст вопроса
        /// </summary>
        [Required(ErrorMessage = "Не указан текст вопроса.")]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Недопустимая длина текста вопроса.")]
        public string Text { get; set; }
        /// <summary>
        /// Первый вариант ответа
        /// </summary>
        [Required(ErrorMessage = "Не указан первый вариант ответа.")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Недопустимая длина варианта ответа.")]
        public string OptionResponse1 { get; set; }
        /// <summary>
        /// Второй вариант ответа
        /// </summary>
        [Required(ErrorMessage = "Не указан второй вариант ответа.")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Недопустимая длина варианта ответа.")]
        public string OptionResponse2 { get; set; }
        /// <summary>
        /// Третий вариант ответа
        /// </summary>
        [Required(ErrorMessage = "Не указан третий вариант ответа.")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Недопустимая длина варианта ответа.")]
        public string OptionResponse3 { get; set; }
        /// <summary>
        /// Четвертый вариант ответа
        /// </summary>
        [Required(ErrorMessage = "Не указан четвертый вариант ответа.")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Недопустимая длина варианта ответа.")]
        public string OptionResponse4 { get; set; }
        /// <summary>
        /// Правильный ответ
        /// </summary>
        [Required(ErrorMessage = "Не указан правильный ответ.")]
        [Range(1, 4, ErrorMessage = "Ответ не находится в допустимом диапазоне.")]
        public int? Response { get; set; }
        /// <summary>
        /// Уровень сложности
        /// </summary>
        [EnumConformity(ErrorMessage = "Значение не соответствует перечислению LevelDifficultyEnum.")]
        public LevelDifficultyEnum LevelDifficulty { get; set; }
        /// <summary>
        /// Предмет
        /// </summary>
        [EnumConformity(ErrorMessage = "Значение не соответствует перечислению SubjectEnum.")]
        public SubjectEnum Subject { get; set; }
        /// <summary>
        /// Активность вопроса
        /// </summary>
        public bool Acting { get; set; }
    }

    /// <summary>
    /// Перечисление уровней сложности
    /// </summary>
    public enum LevelDifficultyEnum
    {
        /// <summary>
        /// Легкий уровень
        /// </summary>
        Easy = 1,
        /// <summary>
        /// Средний уровень
        /// </summary>
        Medium,
        /// <summary>
        /// Сложный уровень
        /// </summary>
        Hard = 4
    }

    /// <summary>
    /// Перечисление предметов
    /// </summary>
    public enum SubjectEnum
    {
        /// <summary>
        /// Физика
        /// </summary>
        Physics,
        /// <summary>
        /// Математика
        /// </summary>
        Mathematics,
        /// <summary>
        /// Информатика
        /// </summary>
        Informatics,
        /// <summary>
        /// Русский язык
        /// </summary>
        RussianLanguage
    }
}