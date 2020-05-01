using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversalTestingService.Services;

namespace UniversalTestingClient
{
    /// <summary>
    /// Форма аутенфикации пользователя
    /// </summary>
    public partial class UserAuthenticationForm : Form
    {
        /// <summary>
        /// Обект контекста приложения
        /// </summary>
        private ApplicationContextUT Context { get; }
        /// <summary>
        /// Объект управления действиями
        /// </summary>
        private ControlActionsAuthenticationUser Control { get; }
        /// <summary>
        /// Показывает обрабатывается ли событие кнопками формы
        /// </summary>
        private bool EventButtons { get; set; }

        /// <summary>
        /// Конструктор объекта формы аутенфикации пользователя
        /// </summary>
        public UserAuthenticationForm(ApplicationContextUT context)
        {
            InitializeComponent();
            Context = context;
            Context.AddForm();
            Control = new ControlActionsAuthenticationUser(this);
            EventButtons = false;

            this.FormClosed += (sender, e) => Context.RemoveForm();
            btnRegistration.Click += BtnRegistration_Click;
            btnEntrance.Click += BtnEntrance_Click;
        }

        /// <summary>
        /// Регистрация пользователя и вход в систему при нажатии btnRegistration
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Вспомогательный объект</param>
        private async void BtnRegistration_Click(object sender, EventArgs e)
        {
            if (EventButtons)
            {
                return;
            }
            EventButtons = true;
            if (await Control.RegistrationUser())
            {
                await Entrance();
            }
            EventButtons = false;
        }

        /// <summary>
        /// Вход в систему при нажатии btnEntrance
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Вспомогательный объект</param>
        private async void BtnEntrance_Click(object sender, EventArgs e)
        {
            if (EventButtons)
            {
                return;
            }
            EventButtons = true;
            await Entrance();
            EventButtons = false;
        }

        /// <summary>
        /// Вход в систему
        /// </summary>
        private async Task Entrance()
        {
            string RoleUser = await Control.GetRoleUser();
            if (RoleUser == UserService.AdminRole)
            {
                AdminForm adminForm = new AdminForm(Control, Context);
                adminForm.Show();
                this.Close();
            }
            else if (RoleUser == UserService.UserRole)
            {
                UserForm userForm = new UserForm(Control, Context);
                userForm.Show();
                this.Close();
            }
        }
    }
}
