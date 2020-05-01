using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UniversalTestingService.Models;

namespace UniversalTestingClient
{
    public class ControlActions
    {
        private ControlActions control;

        /// <summary>
        /// Объект HttpClient
        /// </summary>
        protected HttpClient Client { get; set; }
        /// <summary>
        /// Объект аутенфикации пользователя
        /// </summary>
        protected UserAuthentication Authentication { get; set; }
        /// <summary>
        /// Путь к сервису UniversalTestingService
        /// </summary>
        protected string ServicePath { get; set; }
        /// <summary>
        /// Значение ошибки сервиса UniversalTestingService
        /// </summary>
        protected string ServiceError { get; set; }

        /// <summary>
        /// Конструктор объекта управления действиями
        /// </summary>
        public ControlActions()
        {
            Authentication = new UserAuthentication();
            Client = new HttpClient();
            InitializationComponent();
        }

        /// <summary>
        /// Конструктор объекта управления действиями
        /// </summary>
        /// <param name="control">Объект управления действиями</param>
        public ControlActions(ControlActions control)
        {
            Authentication = control.Authentication;
            Client = control.Client;
            InitializationComponent();
        }

        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        private void InitializationComponent()
        {
            ServicePath = ConfigurationManager.ConnectionStrings["UniversalTestingService"].ConnectionString;
            ServiceError = "Ошибка связи с сервисом UniversalTestingService";
        }

        /// <summary>
        /// Проверка результата
        /// </summary>
        /// <param name="result">Объект ответного сообщения</param>
        /// <returns>Результат проверки</returns>
        protected bool CheckResult(HttpResponseMessage result)
        {
            bool check = false;
            switch (result.StatusCode)
            {
                case HttpStatusCode.OK:
                    check = true;
                    break;

                case HttpStatusCode.BadRequest:
                    List<string> listError = ReadBadRequestResult(result);
                    foreach (string errorBadRequest in listError)
                    {
                        OutputInfoForm(errorBadRequest);
                    }
                    break;

                case HttpStatusCode.Unauthorized:
                    string errorUnauthorized = "Пользователь не аутенфицирован";
                    OutputInfoForm(errorUnauthorized);
                    break;

                case HttpStatusCode.Forbidden:
                    string errorForbidden = "Пользователь не имеет доступа к ресурсу";
                    OutputInfoForm(errorForbidden);
                    break;

                default:
                    string error = "Ошибка работы сервиса UniversalTestingService";
                    OutputInfoForm(error);
                    break;
            }
            return check;
        }

        /// <summary>
        /// Чтение результата ответа BadRequest
        /// </summary>
        /// <param name="result">Объект ответного сообщения</param>
        /// <returns>Список сообщений о ошибках</returns>
        protected List<string> ReadBadRequestResult(HttpResponseMessage result)
        {
            List<string> listError = new List<string>();
            string resultJson = result.Content.ReadAsStringAsync().Result;
            BadRequestError errors = JsonSerializer.Deserialize<BadRequestError>(resultJson);
            foreach (var error in errors.ModelState)
            {
                foreach (string errorMessage in error.Value)
                {
                    listError.Add(errorMessage);
                }
            }
            return listError;
        }

        /// <summary>
        /// Формирование строкового контекста
        /// </summary>
        /// <typeparam name="T">Тип формирования</typeparam>
        /// <param name="value">Объект формирования</param>
        /// <returns></returns>
        protected StringContent FormingStringContent<T>(T value)
        {
            string Json = JsonSerializer.Serialize<T>(value);
            StringContent Content = new StringContent(Json, Encoding.UTF8, "application/json");
            return Content;
        }

        /// <summary>
        /// Возвращение int по объекту LevelDifficultyEnum
        /// </summary>
        /// <param name="levelDifficulty">Объект LevelDifficultyEnum</param>
        /// <returns>Значение int</returns>
        public int GetIntByLevelDifficulty(LevelDifficultyEnum levelDifficulty)
        {
            int i;
            switch (levelDifficulty)
            {
                case LevelDifficultyEnum.Easy:
                    i = 0;
                    break;
                case LevelDifficultyEnum.Medium:
                    i = 1; ;
                    break;
                default:
                    i = 2;
                    break;
            }
            return i;
        }

        /// <summary>
        /// Создание и вывод формы информации
        /// </summary>
        /// <param name="info">Текст ошибки</param>
        public void OutputInfoForm(string info)
        {
            InfoForm form = new InfoForm(info);
            form.ShowDialog();
        }
    }
}
