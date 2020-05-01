using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversalTestingService.Models
{
    /// <summary>
    /// Класс аутенфикации пользователя
    /// </summary>
    public class UserAuthentication
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Key]
        [Required(ErrorMessage = "Не указан логин пользователя.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Недопустимая длина логина пользователя.")]
        [RegularExpression(@"^[^:]*", ErrorMessage = "В логине пользователя знак ':' не допустим.")]
        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required(ErrorMessage ="Не указан пароль пользователя.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Недопустимая длина пароля пользователя.")]
        [RegularExpression(@"^[^:]*", ErrorMessage = "В пароле пользователя знак ':' не допустим.")]
        public string Password { get; set; }
    }
}