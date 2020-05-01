using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversalTestingService.Models;
using UniversalTestingService.Services;

namespace UniversalTestingClient
{
    /// <summary>
    /// Форма администратора
    /// </summary>
    public partial class AdminForm : Form
    {
        /// <summary>
        /// Обект контекста приложения
        /// </summary>
        private ApplicationContextUT Context { get; }
        /// <summary>
        /// Объект управления действиями
        /// </summary>
        private ControlActionsAdmin Control { get; }
        /// <summary>
        /// Список вопросов
        /// </summary>
        private List<Question> ListQuestions { get; set; }
        /// <summary>
        /// Стек вопроса
        /// </summary>
        public Question QuestionStack { get; set; }
        /// <summary>
        /// Показывает обрабатывается ли событие кнопками пользователей
        /// </summary>
        private bool EventButtonsUsers { get; set; }
        /// <summary>
        /// Показывает обрабатывается ли событие кнопками вопросов
        /// </summary>
        private bool EventButtonsQuestions { get; set; }

        /// <summary>
        /// Конструктор объекта формы администратора
        /// </summary>
        /// <param name="control">Объект управления действиями</param>
        public AdminForm(ControlActions control, ApplicationContextUT context)
        {
            InitializeComponent();
            Context = context;
            Context.AddForm();
            Control = new ControlActionsAdmin(control, this);
            ListQuestions = null;
            EventButtonsUsers = false;
            EventButtonsQuestions = false;
            cmbLevelDifficulty.SelectedIndex = 0;
            cmbSubject.SelectedIndex = 0;


            this.FormClosed += (sender, e) => Context.RemoveForm();

            btnAddQuestion.Click += AddQuestion;
            rbAddQuestion.CheckedChanged += RbAddQuestion_CheckedChanged;
            rbEditQuestion.CheckedChanged += RbEditQuestion_CheckedChanged;
            rbQuestionByNumber.CheckedChanged += RbQuestionByNumber_CheckedChanged;
            rbQuestionsByFilter.CheckedChanged += RbQuestionsByFilter_CheckedChanged;
            btnOutputQuestions.Click += (sender, e) => OutputQuestions();
            nudListNumberQuestion.ValueChanged += (sender, e) => OutputListQuestion();
            btnEditQuestion.Click += EditQuestion;

            rbLogin.CheckedChanged += (sender, e) => ChangeEnabledTBLogin();
            btnOutputUsers.Click += (sender, e) => OutputUsers();
            btnChangeRole.Click += ChangeRole;
            btnChangeActing.Click += ChangeActing;

            btnUserMode.Click += SwitchingUserMode;
        }

        /// <summary>
        /// Вывод пользователей
        /// </summary>
        private async void OutputUsers()
        {
            if (EventButtonsUsers)
            {
                return;
            }
            EventButtonsUsers = true;
            dgvUsers.DataSource = null;
            List<User> listUsers = null;
            if (rbAllUsers.Checked)
            {
                listUsers = await Control.GetAllUsers();
            }
            else if (rbLogin.Checked)
            {
                User user = await Control.GetUser();
                if (user != null)
                {
                    listUsers = new List<User>() { user };
                }
            }
            if (listUsers != null)
            {
                dgvUsers.DataSource = listUsers;
                EditTableUsers();
            }
            EventButtonsUsers = false;
        }

        /// <summary>
        /// Изменение роли пользователя
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Вспомогательный объект</param>
        private async void ChangeRole(object sender, EventArgs e)
        {
            if (EventButtonsUsers)
            {
                return;
            }
            EventButtonsUsers = true;
            int index = dgvUsers.CurrentCell.RowIndex;
            if (dgvUsers.DataSource != null && await Control.EditUser(sender))
            {
                dgvUsers.Rows[index].Cells["Role"].Value = dgvUsers.Rows[index].Cells["Role"].Value.ToString() == UserService.AdminRole ? 
                    UserService.UserRole : UserService.AdminRole;
            }
            EventButtonsUsers = false;
        }

        /// <summary>
        /// Изменение активности пользователя
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Вспомогательный объект</param>
        private async void ChangeActing(object sender, EventArgs e)
        {
            if (EventButtonsUsers)
            {
                return;
            }
            EventButtonsUsers = true;
            int index = dgvUsers.CurrentCell.RowIndex;
            if (dgvUsers.DataSource != null && await Control.EditUser(sender))
            {
                dgvUsers.Rows[index].Cells["Acting"].Value = (bool)dgvUsers.Rows[index].Cells["Acting"].Value ?
                    false : true;
            }
            EventButtonsUsers = false;
        }

        /// <summary>
        /// Добавление вопроса
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Вспомогательный объект</param>
        private async void AddQuestion(object sender, EventArgs e)
        {
            if (EventButtonsQuestions)
            {
                return;
            }
            EventButtonsQuestions = true;
            int? id = await Control.AddQuestion();
            if (id != null)
            {
                string info = $"Вопрос добавлен под номером {id}.";
                Control.OutputInfoForm(info);
                ClearQuestionTextBoxs();
            }
            EventButtonsQuestions = false;
        }

        /// <summary>
        /// Вывод вопросов
        /// </summary>
        private async void OutputQuestions()
        {
            if (EventButtonsQuestions)
            {
                return;
            }
            EventButtonsQuestions = true;
            ClearQuestionTextBoxs();
            ListQuestions = null;
            if (rbAllQuestions.Checked)
            {
                ListQuestions = await Control.GetAllQuestions();
            }
            else if (rbQuestionByNumber.Checked)
            {
                Question question = await Control.GetQuestion();
                if (question != null)
                {
                    ListQuestions = new List<Question>() { question };
                }
            }
            else if (rbQuestionsByFilter.Checked)
            {
                ListQuestions = await Control.GetQuestionsByFilter();
            }
            EditPQuestionList();
            EventButtonsQuestions = false;
        }

        /// <summary>
        /// Редактирование вопроса
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Вспомогательный объект</param>
        private async void EditQuestion(object sender, EventArgs e)
        {
            if (EventButtonsQuestions)
            {
                return;
            }
            EventButtonsQuestions = true;
            string info;
            int index = (int)nudListNumberQuestion.Value - 1;
            bool? editCheck = await Control.EditQuestion();
            if (editCheck == true)
            {
                ListQuestions[index] = QuestionStack;
                info = $"Вопрос успешно изменен.";
                Control.OutputInfoForm(info);
            }
            else if (editCheck == false)
            {
                info = "Вопрос нельзя отредактировать из-за ссылающихся на него элементов.";
                if (await Control.EditActingQuestion(false))
                {
                    info = $"{info} Вопрос изменен на неактивный.";
                    ListQuestions[index].Acting = false;
                    int? id = await Control.AddQuestion();
                    if (id != null)
                    {
                        info = $"{info} Вопрос добавлен под номером {id}.";
                    }
                }
                Control.OutputInfoForm(info);
            }
            EventButtonsQuestions = false;
        }

        /// <summary>
        /// Редактирование панели pQuestionList
        /// </summary>
        private void EditPQuestionList()
        {
            nudListNumberQuestion.Value = 1;
            if (ListQuestions != null && ListQuestions.Count > 0)
            {
                pQuestionList.Enabled = true;
                nudListNumberQuestion.Maximum = ListQuestions.Count;
                lblListNumberQuestion.Text = $"из {ListQuestions.Count}";
                OutputListQuestion();
            }
            else
            {
                pQuestionList.Enabled = false;
                nudListNumberQuestion.Maximum = 1;
                lblListNumberQuestion.Text = $"из 0";
            }
        }

        /// <summary>
        /// Очистка полей текстбоксов вопроса
        /// </summary>
        private void ClearQuestionTextBoxs()
        {
            rtbxTextQuestion.Text = String.Empty;
            rtbxOption1.Text = String.Empty;
            rtbxOption2.Text = String.Empty;
            rtbxOption3.Text = String.Empty;
            rtbxOption4.Text = String.Empty;
            tbxNumberQuestion.Text = String.Empty;
        }

        /// <summary>
        /// Редактирование таблицы пользователей
        /// </summary>
        private void EditTableUsers()
        {
            dgvUsers.Columns["Password"].Visible = false;
            dgvUsers.Columns["Login"].HeaderText = "Логин";
            dgvUsers.Columns["Acting"].HeaderText = "Активность";
            dgvUsers.Columns["Role"].HeaderText = "Роль";
            dgvUsers.Columns["Login"].DisplayIndex = 0;
            dgvUsers.Columns["Role"].DisplayIndex = 1;
            dgvUsers.Columns["Acting"].DisplayIndex = 2;
            dgvUsers.Columns["Acting"].Width = 80;
            foreach (DataGridViewColumn column in dgvUsers.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        /// <summary>
        /// Изменение свойства включения tbLogin
        /// </summary>
        private void ChangeEnabledTBLogin()
        {
            if (rbLogin.Checked)
            {
                tbxLogin.Enabled = true;
            }
            else
            {
                tbxLogin.Text = String.Empty;
                tbxLogin.Enabled = false;
            }
        }

        /// <summary>
        /// Изменение внешнего вида при включении/выключении rbEditQuestion
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Вспомогательный объект</param>
        private void RbEditQuestion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEditQuestion.Checked)
            {
                pSearchQuestion.Enabled = true;
                if (ListQuestions != null && ListQuestions.Count > 0)
                {
                    pQuestionList.Enabled = true;
                    OutputListQuestion();
                }
            }
            else
            {
                pSearchQuestion.Enabled = false;
                pQuestionList.Enabled = false;
            }
        }

        /// <summary>
        /// Вывод вопроса из списка вопросов
        /// </summary>
        private void OutputListQuestion()
        {
            int index = (int)nudListNumberQuestion.Value - 1;
            tbxNumberQuestion.Text = ListQuestions[index].Id.ToString();
            rtbxTextQuestion.Text = ListQuestions[index].Text;
            rtbxOption1.Text = ListQuestions[index].OptionResponse1;
            rtbxOption2.Text = ListQuestions[index].OptionResponse2;
            rtbxOption3.Text = ListQuestions[index].OptionResponse3;
            rtbxOption4.Text = ListQuestions[index].OptionResponse4;
            nudResponse.Value = (decimal)ListQuestions[index].Response;
            cmbSubject.SelectedIndex = (int)ListQuestions[index].Subject;
            cbxActing.Checked = ListQuestions[index].Acting;
            cmbLevelDifficulty.SelectedIndex = Control.GetIntByLevelDifficulty(ListQuestions[index].LevelDifficulty);
        }       

        /// <summary>
        /// Изменение внешнего вида при включении/выключении rbAddQuestion
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Вспомогательный объект</param>
        private void RbAddQuestion_CheckedChanged(object sender, EventArgs e)
        {
            ClearQuestionTextBoxs();
            if (rbAddQuestion.Checked)
            {
                cbxActing.Checked = true;
                cbxActing.Enabled = false;
                btnAddQuestion.Enabled = true;
            }
            else
            {
                btnAddQuestion.Enabled = false;
                cbxActing.Enabled = true;
            }
        }

        /// <summary>
        /// Изменение внешнего вида при включении/выключении rbQuestionByNumber
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Вспомогательный объект</param>
        private void RbQuestionByNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (rbQuestionByNumber.Checked)
            {
                nudQuestionNumber.Enabled = true;
            }
            else
            {
                nudQuestionNumber.Enabled = false;
            }
        }

        /// <summary>
        /// Изменение внешнего вида при включении/выключении rbQuestionsByFilter
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Вспомогательный объект</param>
        private void RbQuestionsByFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (rbQuestionsByFilter.Checked)
            {
                pFilter.Enabled = true;
            }
            else
            {
                pFilter.Enabled = false;
            }
        }

        /// <summary>
        /// Переключение на режим пользователя
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Вспомогательный объект</param>
        private void SwitchingUserMode(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm(Control, Context);
            userForm.btnAdminMode.Visible = true;
            userForm.Show();
            this.Close();
        }
    }
}
