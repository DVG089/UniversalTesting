using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UniversalTestingService.Filters;
using UniversalTestingService.Additional;
using UniversalTestingService.Models;
using UniversalTestingService.Services;

namespace UniversalTestingService.Controllers
{
    /// <summary>
    /// Контроллер пользователей
    /// </summary>
    public class UsersController : ApiController
    {
        /// <summary>
        /// Объект контекста базы данных
        /// </summary>
        private UniversalTestingContext Context;
        /// <summary>
        /// Объект сервиса пользователя
        /// </summary>
        private UserService Service;

        /// <summary>
        /// Конструирует объект контроллера пользователей
        /// </summary>
        public UsersController()
        {
            Context = new UniversalTestingContext();
            Service = new UserService(Context);
        }

        /// <summary>
        /// Возвращение списка всех пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        [AuthenticationUser]
        [AuthorizationUser(UserService.AdminRole)]
        public List<User> GetAllUsers()
        {
            return Service.GetAllUsers();
        }

        /// <summary>
        /// Возвращение пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>Пользователь</returns>
        [AuthenticationUser]
        [AuthorizationUser(UserService.AdminRole)]
        [Route("api/Users/{login}")]
        public User GetUser(string login)
        {
            return Service.GetUser(login);
        }

        /// <summary>
        /// Возвращение роли авторизованого пользователя
        /// </summary>
        /// <returns>Роль пользователя</returns>
        [Route("api/Users/role")]
        [AuthenticationUser]
        public string GetRoleUser()
        {
            return Service.GetRoleUser(ActionContext.RequestContext.Principal);
        }

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="user">Объект аутенфикации пользователя</param>
        /// <returns>Объект IHttpActionResult</returns>
        [HttpPost]
        public IHttpActionResult CreateUser([FromBody]UserAuthentication user)
        {

            if (user == null)
            {
                ModelState.AddModelError("user", "Не заданы данные пользователя.");
                throw new BadRequestException();
            }
            if (!ModelState.IsValid)
            {
                throw new BadRequestException();
            }
            if (Service.ConstainsUser(user))
            {
                ModelState.AddModelError("user.Login", "Пользователь с данным логином уже существует");
                throw new BadRequestException();
            }

            Service.CreateUser(user);
            return Ok();
        }

        /// <summary>
        /// Редактирование пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="adminEnabled">Включение роли администратора</param>
        /// <param name="actingEnabled">Включение активности</param>
        /// <returns>Объект IHttpActionResult</returns>
        [HttpPut]
        [AuthenticationUser]
        [AuthorizationUser(UserService.AdminRole)]
        [Route("api/Users/{login}/{adminEnabled:bool}/{actingEnabled:bool}")]
        public IHttpActionResult EditUser(string login, bool adminEnabled, bool actingEnabled)
        {
            User user = Service.GetUser(login);
            if (user == null)
            {
                ModelState.AddModelError("user.Login", "Данный пользователь не найден.");
                throw new BadRequestException();
            }
            Service.EditUser(user, adminEnabled, actingEnabled);
            return Ok();
        }

        /// <summary>
        /// Освобождение неуправляемых ресурсов
        /// </summary>
        /// <param name="disposing">Параметр включения</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
