using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalTestingClient
{
    /// <summary>
    /// Класс ошибок ответа BadRequest
    /// </summary>
    class BadRequestError
    {
        /// <summary>
        /// Общее сообщение о ошибке
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Словарь ошибок
        /// </summary>
        public Dictionary<string, List<string>> ModelState { get; set; }
    }
}
