using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using UniversalTestingService.Models;

namespace UniversalTestingService.Services
{
    /// <summary>
    /// Класс сервиса пользователя
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// Объект контекста базы данных
        /// </summary>
        private UniversalTestingContext Context;
        /// <summary>
        /// Роль администратора
        /// </summary>
        public const string AdminRole = "admin";
        /// <summary>
        /// Роль пользователя
        /// </summary>
        public const string UserRole = "user";

        /// <summary>
        /// Конструктор объекта сервиса пользователя
        /// </summary>
        /// <param name="context">Объект контекста базы данных</param>
        public UserService(UniversalTestingContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Возвращение списка всех пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        public List<User> GetAllUsers()
        {
            List<User> listUsers = Context.Users.ToList();
            foreach (User user in listUsers)
            {
                user.Password = null;
            }
            return listUsers;
        }

        /// <summary>
        /// Возвращение пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>Пользователь</returns>
        public User GetUser(string login)
        {
            User user = null;
            if (CheckLogin(login))
            {
                user = Context.Users.FirstOrDefault(n => n.Login == login);
            }
            return user;
        }

        /// <summary>
        /// Возвращение роли пользователя
        /// </summary>
        /// <param name="principal">Объект аутенфицированого пользователя</param>
        /// <returns>Роль пользователя</returns>
        public string GetRoleUser(IPrincipal principal)
        {
            string role = UserService.UserRole;
            if (principal.IsInRole(UserService.AdminRole))
            {
                role = UserService.AdminRole;
            }
            return role;
        }

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="userAuth">Объект аутенфикации пользователя</param>
        public void CreateUser(UserAuthentication userAuth)
        {
            User user = new User();
            user.Login = userAuth.Login;
            user.Password = userAuth.Password;
            user.Role = Context.Users.Any(n => n.Role == AdminRole) ? UserRole : AdminRole;
            user.Acting = true;

            Context.Users.Add(user);
            Context.SaveChanges();
        }

        /// <summary>
        /// Проверка наличия пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Результат проверки</returns>
        public bool ConstainsUser(UserAuthentication user)
        {
            return Context.Users.Any(n => n.Login == user.Login);
        }

        /// <summary>
        /// Редактирование пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="adminEnabled">Включение роли администратора</param>
        /// <param name="actingEnabled">Включение активности</param>
        public void EditUser(User user, bool adminEnabled, bool actingEnabled)
        {
            user.Role = adminEnabled ? AdminRole : UserRole;
            user.Acting = actingEnabled;
            Context.Entry(user).State = EntityState.Modified;
            Context.SaveChanges();
        }

        /// <summary>
        /// Проверка логина
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>Результат проверки</returns>
        public static bool CheckLogin(string login)
        {
            int minLength = 1;
            int maxLength = 20;
            string regular = @"^[^:]*";
            bool check = false;
            if (!String.IsNullOrWhiteSpace(login) && login.Length >= minLength &&
                login.Length <= maxLength && Regex.IsMatch(login, regular))
            {
                check = true;
            }
            return check;
        }

        /// <summary>
        /// Проверка пароля
        /// </summary>
        /// <param name="password">Пароль</param>
        /// <returns>Результат проверки</returns>
        public static bool CheckPassword(string password)
        {
            int minLength = 1;
            int maxLength = 20;
            string regular = @"^[^:]*";
            bool check = false;
            if (!String.IsNullOrWhiteSpace(password) && password.Length >= minLength &&
                password.Length <= maxLength && Regex.IsMatch(password, regular))
            {
                check = true;
            }
            return check;
        }
    }
}