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

namespace UniversalTestingClient
{
    /// <summary>
    /// Форма пользователя
    /// </summary>
    public partial class UserForm : Form
    {
        /// <summary>
        /// Обект контекста приложения
        /// </summary>
        private ApplicationContextUT Context { get; }
        /// <summary>
        /// Объект управления действиями
        /// </summary>
        private ControlActionsUser Control { get; }
        /// <summary>
        /// Список вопросов-ответов
        /// </summary>
        public List<Answer> ListAnswers { get; set; }
        /// <summary>
        /// Показывает обрабатывается ли событие кнопками
        /// </summary>
        private bool EventButtons { get; set; }

        /// <summary>
        /// Конструктор объекта формы пользователя
        /// </summary>
        public UserForm(ControlActions control, ApplicationContextUT context)
        {
            InitializeComponent();
            Context = context;
            Context.AddForm();
            Control = new ControlActionsUser(control, this);
            EventButtons = false;
            cmbSubject.SelectedIndex = 0;

            this.FormClosed += (sender, e) => Context.RemoveForm();

            btnOutputTest.Click += OutputTest;
            btnTestComplete.Click += TestComplete;
            btnAdminMode.Click += SwitchingAdminMode;
            nudListNumberQuestion.ValueChanged += (sender, e) => OutputListAnswer();
            rbtAnswer1.CheckedChanged += CheckedChangedAnswer;
            rbtAnswer2.CheckedChanged += CheckedChangedAnswer;
            rbtAnswer3.CheckedChanged += CheckedChangedAnswer;
            rbtAnswer4.CheckedChanged += CheckedChangedAnswer;
        }

        /// <summary>
        /// Получение теста
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Вспомогательный объект</param>
        private async void OutputTest(object sender, EventArgs e)
        {
            if (EventButtons)
            {
                return;
            }
            EventButtons = true;
            string info;
            Control.TestId = await Control.CreateTest();
            if (Control.TestId != null)
            {
                info = $"Тест создан под номером {Control.TestId}.";
                Control.OutputInfoForm(info);

                ListAnswers = await Control.GetAnswersTest();
                if (ListAnswers != null)
                {
                    if (ListAnswers.Count == 0)
                    {
                        info = "Тест не содержит вопросов.";
                        Control.OutputInfoForm(info);
                    }
                    else
                    {
                        EditPAnswerList();
                        pGetTest.Enabled = false;
                    }
                }
            }
            EventButtons = false;
        }

        /// <summary>
        /// Завершение теста
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Вспомогательный объект</param>
        private async void TestComplete(object sender, EventArgs e)
        {
            if (EventButtons)
            {
                return;
            }
            EventButtons = true;
            if (await Control.CalculationResultTest())
            {
                TestResult result = await Control.GetResultTest();
                if (result != null)
                {
                    string info = $"Тест завершен. Вы набрали {result.Result} балов из {result.MaxResult}.";
                    Control.OutputInfoForm(info);
                    pGetTest.Enabled = true;
                    pAnswerList.Enabled = false;
                }
            }
            EventButtons = false;
        }

        /// <summary>
        /// Редактирование панели PAnswerList
        /// </summary>
        private void EditPAnswerList()
        {
            pAnswerList.Enabled = true;
            nudListNumberQuestion.Value = 1;
            nudListNumberQuestion.Maximum = ListAnswers.Count;
            lblListNumberQuestion.Text = $"из {ListAnswers.Count}";
            OutputListAnswer();
        }

        /// <summary>
        /// Вывод вопроса из списка вопросов-ответов
        /// </summary>
        private void OutputListAnswer()
        {
            int index = (int)nudListNumberQuestion.Value - 1;
            tbxNumberQuestion.Text = ListAnswers[index].Question.Id.ToString();
            rtbxTextQuestion.Text = ListAnswers[index].Question.Text;
            rtbxOption1.Text = ListAnswers[index].Question.OptionResponse1;
            rtbxOption2.Text = ListAnswers[index].Question.OptionResponse2;
            rtbxOption3.Text = ListAnswers[index].Question.OptionResponse3;
            rtbxOption4.Text = ListAnswers[index].Question.OptionResponse4;
            cmbLevelDifficulty.SelectedIndex = Control.GetIntByLevelDifficulty(ListAnswers[index].Question.LevelDifficulty);
            OutputCheckedAnswer(index);
        }

        /// <summary>
        /// Вывод активного ответа
        /// </summary>
        private void OutputCheckedAnswer(int index)
        {
            switch (ListAnswers[index].AnswerBody)
            {
                case 1:
                    rbtAnswer1.Checked = true;
                    break;
                case 2:
                    rbtAnswer2.Checked = true;
                    break;
                case 3:
                    rbtAnswer3.Checked = true;
                    break;
                case 4:
                    rbtAnswer4.Checked = true;
                    break;
                default:
                    rbtAnswer1.Checked = false;
                    rbtAnswer2.Checked = false;
                    rbtAnswer3.Checked = false;
                    rbtAnswer4.Checked = false;
                    break;
            }
        }

        /// <summary>
        /// Изменение выбора ответа
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Вспомогательный объект</param>
        private void CheckedChangedAnswer(object sender, EventArgs e)
        {
            int index = (int)nudListNumberQuestion.Value - 1;
            if (sender == rbtAnswer1 && rbtAnswer1.Checked)
            {
                ListAnswers[index].AnswerBody = 1;
            }
            else if (sender == rbtAnswer2 && rbtAnswer2.Checked)
            {
                ListAnswers[index].AnswerBody = 2;
            }
            else if (sender == rbtAnswer3 && rbtAnswer3.Checked)
            {
                ListAnswers[index].AnswerBody = 3;
            }
            else if (sender == rbtAnswer4 && rbtAnswer4.Checked)
            {
                ListAnswers[index].AnswerBody = 4;
            }
        }

        /// <summary>
        /// Переключение на режим администратора
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Вспомогательный объект</param>
        private void SwitchingAdminMode(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm(Control, Context);
            adminForm.Show();
            this.Close();
        }
    }
}
