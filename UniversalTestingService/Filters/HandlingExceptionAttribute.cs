using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using UniversalTestingService.Additional;

namespace UniversalTestingService.Filters
{
    /// <summary>
    /// Фильтр обработки исключения BadRequestException
    /// </summary>
    public class HandlingExceptionAttribute : Attribute, IExceptionFilter
    {
        /// <summary>
        /// Журнал сообщений Nlog
        /// </summary>
        private static Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Метод обработки исключения
        /// </summary>
        /// <param name="actionExecutedContext">Объект HttpActionExecutedContext</param>
        /// <param name="cancellationToken">Отменяющий токен</param>
        /// <returns>Результат задачи</returns>
        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext,
            CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception != null)
            {
                if (actionExecutedContext.Exception is BadRequestException)
                {
                    actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(
                HttpStatusCode.BadRequest, actionExecutedContext.ActionContext.ModelState);
                }
                else
                {
                    Log.Error(actionExecutedContext.Exception.ToString);
                }               
            }
            return Task.FromResult<object>(null);
        }
        public bool AllowMultiple
        {
            get { return true; }
        }
    }
}