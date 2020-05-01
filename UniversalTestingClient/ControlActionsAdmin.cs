using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UniversalTestingService.Models;
using UniversalTestingService.Services;

namespace UniversalTestingClient
{
    /// <summary>
    /// Класс управления действиями администратора
    /// </summary>
    public class ControlActionsAdmin : ControlActions
    {
        /// <summary>
        /// Объект формы администратора
        /// </summary>
        private AdminForm Form { get; }

        /// <summary>
        /// Конструктор объекта управления действиями администратора
        /// </summary>
        /// <param name="control">Объекта управления действиями</param>
        /// <param name="form">Объект формы администратора</param>
        public ControlActionsAdmin(ControlActions control, AdminForm form)
            : base(control)
        {
            Form = form;
        }

        /// <summary>
        /// Возвращение всех пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        public async Task<List<User>> GetAllUsers()
        {
            List<User> listUsers = null;
            try
            {
                string uri = $"{ServicePath}/api/Users";
                HttpResponseMessage result = await Client.GetAsync(uri);
                if (CheckResult(result))
                {
                    string listUsersJson = await result.Content.ReadAsStringAsync();
                    listUsers = JsonSerializer.Deserialize<List<User>>(listUsersJson);
                }
            }
            catch
            {
                OutputInfoForm(ServiceError);
            }
            return listUsers;
        }

        /// <summary>
        /// Редактирование пользователя
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <returns>Результат редактирования</returns>
        public async Task<bool> EditUser(object sender)
        {
            bool edit = false;
            bool adminEnabled;
            bool actingEnabled;
            int index = Form.dgvUsers.CurrentCell.RowIndex;
            string login = Form.dgvUsers.Rows[index].Cells["Login"].Value.ToString();
            if (sender == Form.btnChangeRole)
            {
                adminEnabled = Form.dgvUsers.Rows[index].Cells["Role"].Value.ToString() == UserService.AdminRole ?
                    false : true;
                actingEnabled = (bool)Form.dgvUsers.Rows[index].Cells["Acting"].Value ? true : false;
            }
            else
            {
                adminEnabled = Form.dgvUsers.Rows[index].Cells["Role"].Value.ToString() == UserService.AdminRole ?
                    true : false;
                actingEnabled = (bool)Form.dgvUsers.Rows[index].Cells["Acting"].Value ? false : true;
            }
            try
            {
                string uri = $"{ServicePath}/api/Users/{login}/{adminEnabled}/{actingEnabled}";
                HttpResponseMessage result = await Client.PutAsync(uri, null);
                if (CheckResult(result))
                {
                    edit = true;
                }
            }
            catch
            {
                OutputInfoForm(ServiceError);
            }
            return edit;
        }

        /// <summary>
        /// Возвращение пользователя
        /// </summary>
        /// <returns>Пользователь</returns>
        public async Task<User> GetUser()
        {
            User user = null;
            string login = Form.tbxLogin.Text;
            try
            {
                if (!String.IsNullOrWhiteSpace(login))
                {
                    string uri = $"{ServicePath}/api/Users/{login}";
                    HttpResponseMessage result = await Client.GetAsync(uri);
                    if (CheckResult(result))
                    {
                        string userJson = await result.Content.ReadAsStringAsync();
                        user = JsonSerializer.Deserialize<User>(userJson);
                    }
                }
            }
            catch
            {
                OutputInfoForm(ServiceError);
            }
            return user;
        }


        /// <summary>
        /// Добавление вопроса
        /// </summary>
        /// <returns>Номер добавленого вопроса</returns>
        public async Task<int?> AddQuestion()
        {
            int? id = null;
            Question question = FormingQuestion();

            StringContent questionContent = FormingStringContent<Question>(question);
            try
            {
                string uri = $"{ServicePath}/api/Questions";
                HttpResponseMessage result = await Client.PostAsync(uri, questionContent);
                if (CheckResult(result))
                {
                    string idJson = await result.Content.ReadAsStringAsync();
                    id = JsonSerializer.Deserialize<int>(idJson);
                }
            }
            catch
            {
                OutputInfoForm(ServiceError);
            }
            return id;
        }

        /// <summary>
        /// Возвращение вопроса
        /// </summary>
        /// <returns>Вопрос</returns>
        public async Task<Question> GetQuestion()
        {
            Question question = null;
            int numberQuestion = (int)Form.nudQuestionNumber.Value;
            try
            {
                string uri = $"{ServicePath}/api/Questions/{numberQuestion}";
                HttpResponseMessage result = await Client.GetAsync(uri);
                if (CheckResult(result))
                {
                    string questionJson = await result.Content.ReadAsStringAsync();
                    question = JsonSerializer.Deserialize<Question>(questionJson);
                }
            }
            catch
            {
                OutputInfoForm(ServiceError);
            }
            return question;
        }

        /// <summary>
        /// Возвращение вопросов по фильтру
        /// </summary>
        /// <returns>Список вопросов</returns>
        public async Task<List<Question>> GetQuestionsByFilter()
        {
            List<Question> listQuestions = null;
            FilterQuestions filter = FormingFilterQuestions();
            try
            {
                string uri = $"{ServicePath}/api/Questions/GetQuestionsByFilter?acting={filter.Acting}&" +
                    $"levelDifficulty={filter.LevelDifficulty}&subject={filter.Subject}";
                HttpResponseMessage result = await Client.GetAsync(uri);
                if (CheckResult(result))
                {
                    string listQuestionsJson = await result.Content.ReadAsStringAsync();
                    listQuestions = JsonSerializer.Deserialize<List<Question>>(listQuestionsJson);
                }
            }
            catch
            {
                OutputInfoForm(ServiceError);
            }
            return listQuestions;
        }

        /// <summary>
        /// Возвращение всех вопросов
        /// </summary>
        /// <returns>Список вопросов</returns>
        public async Task<List<Question>> GetAllQuestions()
        {
            List<Question> listQuestions = null;
            try
            {
                string uri = $"{ServicePath}/api/Questions";
                HttpResponseMessage result = await Client.GetAsync(uri);
                if (CheckResult(result))
                {
                    string listQuestionsJson = await result.Content.ReadAsStringAsync();
                    listQuestions = JsonSerializer.Deserialize<List<Question>>(listQuestionsJson);
                }
            }
            catch
            {
                OutputInfoForm(ServiceError);
            }
            return listQuestions;
        }

        /// <summary>
        /// Редактирование вопроса
        /// </summary>
        /// <returns>Результат редактирования</returns>
        public async Task<bool?> EditQuestion()
        {
            bool? edit = null;
            Question question = FormingQuestion();

            StringContent questionContent = FormingStringContent<Question>(question);
            try
            {
                string uri = $"{ServicePath}/api/Questions/{question.Id}";
                HttpResponseMessage result = await Client.PutAsync(uri, questionContent);
                if (CheckResult(result))
                {
                    string editJson = await result.Content.ReadAsStringAsync();
                    edit = JsonSerializer.Deserialize<bool?>(editJson);
                    Form.QuestionStack = question;
                }
            }
            catch
            {
                OutputInfoForm(ServiceError);
            }
            return edit;
        }

        /// <summary>
        /// Редактирование активности вопроса
        /// </summary>
        /// <returns>Результат редактирования</returns>
        public async Task<bool> EditActingQuestion(bool acting)
        {
            bool edit = false;
            int numberQuestion = (int)Form.nudQuestionNumber.Value;
            try
            {
                string uri = $"{ServicePath}/api/Questions/{numberQuestion}/{acting}";
                HttpResponseMessage result = await Client.PutAsync(uri, null);
                if (CheckResult(result))
                {
                    edit = true;
                }
            }
            catch
            {
                OutputInfoForm(ServiceError);
            }
            return edit;
        }

        /// <summary>
        /// Формирование объекта фильтра вопросов
        /// </summary>
        /// <returns>Объект фильтра вопросов</returns>
        private FilterQuestions FormingFilterQuestions()
        {
            FilterQuestions filter = new FilterQuestions();
            if (Form.cbxFilterActing.Checked)
            {
                filter.Acting = Form.cbxActing.Checked;
            }
            if (Form.cbxFilterLevelDifficulty.Checked)
            {
                filter.LevelDifficulty = GetLevelDifficulty();
            }
            if (Form.cbxFilterSubject.Checked)
            {
                filter.Subject = (SubjectEnum)Form.cmbSubject.SelectedIndex;
            }
            return filter;
        }

        /// <summary>
        /// Формирование объекта вопроса
        /// </summary>
        /// <returns>Объект вопроса</returns>
        public Question FormingQuestion()
        {
            Question question = new Question();
            if (Form.tbxNumberQuestion.Text != String.Empty)
                question.Id = Int32.Parse(Form.tbxNumberQuestion.Text);
            question.Text = Form.rtbxTextQuestion.Text;
            question.OptionResponse1 = Form.rtbxOption1.Text;
            question.OptionResponse2 = Form.rtbxOption2.Text;
            question.OptionResponse3 = Form.rtbxOption3.Text;
            question.OptionResponse4 = Form.rtbxOption4.Text;
            question.Response = (int)Form.nudResponse.Value;
            question.Subject = (SubjectEnum)Form.cmbSubject.SelectedIndex;
            question.Acting = Form.cbxActing.Checked;
            question.LevelDifficulty = GetLevelDifficulty();
            return question;
        }

        /// <summary>
        /// Возвращение объекта перечисления LevelDifficultyEnum
        /// </summary>
        /// <returns>Объект перечисления LevelDifficultyEnum</returns>
        private LevelDifficultyEnum GetLevelDifficulty()
        {
            LevelDifficultyEnum levelDifficulty;
            switch (Form.cmbLevelDifficulty.SelectedIndex)
            {
                case 0:
                    levelDifficulty = LevelDifficultyEnum.Easy;
                    break;
                case 1:
                    levelDifficulty = LevelDifficultyEnum.Medium;
                    break;
                default:
                    levelDifficulty = LevelDifficultyEnum.Hard;
                    break;
            }
            return levelDifficulty;
        }
    }
}
