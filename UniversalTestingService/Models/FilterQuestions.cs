using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversalTestingService.Additional;

namespace UniversalTestingService.Models
{
    /// <summary>
    /// Класс фильтра вопросов
    /// </summary>
    public class FilterQuestions
    {
        /// <summary>
        /// Уровень сложности
        /// </summary>
        [EnumConformityOrNull(ErrorMessage = "Значение не соответствует перечислению LevelDifficultyEnum.")]
        public LevelDifficultyEnum? LevelDifficulty { get; set; }
        /// <summary>
        /// Предмет
        /// </summary>
        [EnumConformityOrNull(ErrorMessage = "Значение не соответствует перечислению SubjectEnum.")]
        public SubjectEnum? Subject { get; set; }
        /// <summary>
        /// Активность вопроса
        /// </summary>
        public bool? Acting { get; set; }
    }
}