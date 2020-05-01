using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace UniversalTestingService.Filters
{
    /// <summary>
    /// Фильтр авторизации пользователей
    /// </summary>
    public class AuthorizationUserAttribute : Attribute, IAuthorizationFilter
    {
        /// <summary>
        /// Проверяемая роль пользователя
        /// </summary>
        private string Role;

        /// <summary>
        /// Конструктор объекта авторизации пользователей
        /// </summary>
        /// <param name="role">Проверяемая роль пользователя</param>
        public AuthorizationUserAttribute(string role)
        {
            Role = role;
        }
        /// <summary>
        /// Метод авторизации
        /// </summary>
        /// <param name="actionContext">Объект HttpActionContext</param>
        /// <param name="cancellationToken">Объект отменяющего токена</param>
        /// <param name="continuation">Выполняемый метод</param>
        /// <returns>Результат задачи</returns>
        public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext,
                        CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            IPrincipal principal = actionContext.RequestContext.Principal;
            if (principal == null || !principal.IsInRole(Role))
            {
                return Task.FromResult<HttpResponseMessage>(
                       actionContext.Request.CreateResponse(HttpStatusCode.Forbidden));
            }
            else
            {
                return continuation();
            }
        }
        public bool AllowMultiple
        {
            get { return false; }
        }
    }
}