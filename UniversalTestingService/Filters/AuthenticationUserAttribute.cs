using System;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using System.Security.Principal;
using UniversalTestingService.Models;
using System.Linq;
using UniversalTestingService.Services;

namespace UniversalTestingService.Filters
{
    /// <summary>
    /// Фильтр аутенфикации пользователей
    /// </summary>
    class AuthenticationUserAttribute : Attribute, IAuthenticationFilter
    {
        /// <summary>
        /// Объект контекста базы данных
        /// </summary>
        private UniversalTestingContext Context;

        /// <summary>
        /// Конструктор объекта фильтра аутенфикации пользователей
        /// </summary>
        public AuthenticationUserAttribute()
        {
            Context = new UniversalTestingContext();
        }

        /// <summary>
        /// Метод аутенфикации
        /// </summary>
        /// <param name="context">Объект HttpAuthenticationContext</param>
        /// <param name="cancellationToken">Объект отменяющего токена</param>
        /// <returns>Результат задачи</returns>
        public Task AuthenticateAsync(HttpAuthenticationContext context,
                                    CancellationToken cancellationToken)
        {
            context.Principal = null;
            bool successAuthenticate = false;
            AuthenticationHeaderValue authentication = context.Request.Headers.Authorization;
            try
            {
                if (authentication != null && authentication.Scheme == "Basic")
                {
                    string[] loginPassword = ConvertAuthenticationHeader(authentication);
                    if (CheckLoginPassword(loginPassword))
                    {
                        string login = loginPassword[0];
                        string password = loginPassword[1];
                        string role = Context.Users.FirstOrDefault(n => n.Login == login && n.Password == password && n.Acting == true).Role;
                        if (role != null)
                        {
                            string[] roles = new string[] { role };
                            context.Principal = new GenericPrincipal(new GenericIdentity(loginPassword[0]), roles);
                            successAuthenticate = true;
                        }
                    }
                }
                if (!successAuthenticate)
                {
                    context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[] {
                    new AuthenticationHeaderValue("Basic") }, context.Request);
                }
            }
            catch
            {
                context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[] {
                    new AuthenticationHeaderValue("Basic") }, context.Request);
            }
            return Task.FromResult<object>(null);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context,
                                    CancellationToken cancellationToken)
        {
            return Task.FromResult<object>(null);
        }
        public bool AllowMultiple
        {
            get { return false; }
        }

        /// <summary>
        /// Конвертирование объекта AuthenticationHeaderValue в строковой массив
        /// </summary>
        /// <param name="authentication">Объект конвертирования AuthenticationHeaderValue</param>
        /// <returns>Строковой массив</returns>
        private string[] ConvertAuthenticationHeader(AuthenticationHeaderValue authentication)
        {
            byte[] authenticationBytes = Convert.FromBase64String(authentication.Parameter);
            string authenticationString = Encoding.ASCII.GetString(authenticationBytes);
            string[] authenticationArray = authenticationString.Split(':');
            return authenticationArray;
        }

        /// <summary>
        /// Проверка строкового массива на соответствие
        /// </summary>
        /// <param name="loginPassword">Строковой массив</param>
        /// <returns>Результат проверки</returns>
        private bool CheckLoginPassword(string[] loginPassword)
        {
            bool check = false;
            if (loginPassword.Count() == 2 && UserService.CheckLogin(loginPassword[0]) && 
                UserService.CheckPassword(loginPassword[1]))
            {
                check = true;
            }
            return check;
        }
    }
}