using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversalTestingService.Models
{
    /// <summary>
    /// Класс пользователя
    /// </summary>
    public class User: UserAuthentication
    {
        /// <summary>
        /// Роль пользователя
        /// </summary>
        [Required(ErrorMessage = "Не указана роль пользователя.")]
        public string Role { get; set; }
        /// <summary>
        /// Активность пользователя
        /// </summary>
        public bool Acting { get; set; }
        /// <summary>
        /// Список тестов
        /// </summary>
        public List<Test> Tests { get; set; }
    }
}