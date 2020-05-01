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
    /// <summary>
    /// Класс управления действиями по аутенфикации пользователя
    /// </summary>
    public class ControlActionsAuthenticationUser : ControlActions
    {
        /// <summary>
        /// Объект формы аутенфикации пользователя
        /// </summary>
        private UserAuthenticationForm FormAuthentication { get; }

        /// <summary>
        /// Конструктор объекта управления действиями по аутенфикации пользователя
        /// </summary>
        /// <param name="form">Объект формы аутенфикации пользователя</param>
        public ControlActionsAuthenticationUser(UserAuthenticationForm form)
            : base()
        {
            FormAuthentication = form;
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <returns>Результат регистрации пользователя</returns>
        public async Task<bool> RegistrationUser()
        {
            bool registration = false;
            Client.DefaultRequestHeaders.Authorization = null;
            SetUserAuthentication();

            StringContent authenticationContent = FormingStringContent<UserAuthentication>(Authentication);
            try
            {
                string uri = $"{ServicePath}/api/Users";
                HttpResponseMessage result = await Client.PostAsync(uri, authenticationContent);
                if (CheckResult(result))
                {
                    registration = true;
                    SetAuthenticationHeader();
                }
            }
            catch
            {
                OutputInfoForm(ServiceError);
            }
            return registration;
        }

        /// <summary>
        /// Возвращение роли пользователя
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetRoleUser()
        {
            string role = null;
            SetUserAuthentication();
            SetAuthenticationHeader();

            try
            {
                string uri = $"{ServicePath}/api/Users/role";
                HttpResponseMessage result = await Client.GetAsync(uri);
                if (CheckResult(result))
                {
                    string roleJson = await result.Content.ReadAsStringAsync();
                    role = JsonSerializer.Deserialize<string>(roleJson);
                }
            }
            catch
            {
                OutputInfoForm(ServiceError);
            }
            return role;
        }

        /// <summary>
        /// Задание значений объекта UserAuthentication
        /// </summary>
        private void SetUserAuthentication()
        {
            Authentication.Login = FormAuthentication.tbLogin.Text;
            Authentication.Password = FormAuthentication.tbPassword.Text;
        }

        /// <summary>
        /// Задание значения заголовка аутенфикации
        /// </summary>
        private void SetAuthenticationHeader()
        {
            string loginPassword = $"{Authentication.Login}:{Authentication.Password}";
            byte[] buffer = Encoding.ASCII.GetBytes(loginPassword);
            string authenticationHeader = Convert.ToBase64String(buffer);
            Client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", authenticationHeader);
        }
    }
}
