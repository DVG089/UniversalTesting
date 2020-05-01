using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UniversalTestingService.Models;

namespace UniversalTestingClient
{
    /// <summary>
    /// Класс управления действиями пользователя
    /// </summary>
    public class ControlActionsUser : ControlActions
    {
        /// <summary>
        /// Объект формы пользователя
        /// </summary>
        private UserForm Form { get; }
        /// <summary>
        /// Номер теста
        /// </summary>
        public int? TestId { get; set; }
        /// <summary>
        /// Количество легких вопросов
        /// </summary>
        private int EasyCount { get; set; }
        /// <summary>
        /// Количество вопросов средней сложности
        /// </summary>
        private int MediumCount { get; set; }
        /// <summary>
        /// Количество сложных вопросов
        /// </summary>
        private int HardCount { get; set; }

        /// <summary>
        /// Конструктор объекта управления действиями пользователя
        /// </summary>
        /// <param name="control">Объекта управления действиями</param>
        /// <param name="form">Объект формы пользователя</param>
        public ControlActionsUser(ControlActions control, UserForm form)
            : base(control)
        {
            Form = form;
            EasyCount = 10;
            MediumCount = 10;
            HardCount = 10;
        }

        /// <summary>
        /// Создание теста
        /// </summary>
        /// <returns>Номер созданого теста</returns>
        public async Task<int?> CreateTest()
        {
            int? id = null;
            SubjectEnum subject = (SubjectEnum)Form.cmbSubject.SelectedIndex;

            try
            {
                string uri = $"{ServicePath}/api/Tests/{subject}/{EasyCount}/{MediumCount}/{HardCount}";
                HttpResponseMessage result = await Client.PostAsync(uri, null);
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
        /// Получение вопросов-ответов теста
        /// </summary>
        /// <returns>Список вопросов-ответов</returns>
        public async Task<List<Answer>> GetAnswersTest()
        {
            List<Answer> listAnswers = null;
            try
            {
                string uri = $"{ServicePath}/api/Tests/GetAnswersTest/{TestId}";
                HttpResponseMessage result = await Client.GetAsync(uri);
                if (CheckResult(result))
                {
                    string listAnswersJson = await result.Content.ReadAsStringAsync();
                    listAnswers = JsonSerializer.Deserialize<List<Answer>>(listAnswersJson);
                }
            }
            catch
            {
                OutputInfoForm(ServiceError);
            }
            return listAnswers;
        }

        /// <summary>
        /// Расчет результата теста
        /// </summary>
        /// <returns>Успешность расчета</returns>
        public async Task<bool> CalculationResultTest()
        {
            bool calculation = false;

            StringContent answersContent = FormingStringContent<List<Answer>>(Form.ListAnswers);
            try
            {
                string uri = $"{ServicePath}/api/Tests/{TestId}";
                HttpResponseMessage result = await Client.PutAsync(uri, answersContent);
                if (CheckResult(result))
                {
                    calculation = true;
                }
            }
            catch
            {
                OutputInfoForm(ServiceError);
            }
            return calculation;
        }

        /// <summary>
        /// Возвращение результата теста
        /// </summary>
        /// <returns>Результат теста</returns>
        public async Task<TestResult> GetResultTest()
        {
            TestResult testResult = null;
            try
            {
                string uri = $"{ServicePath}/api/Tests/GetResultTest/{TestId}";
                HttpResponseMessage result = await Client.GetAsync(uri);
                if (CheckResult(result))
                {
                    string testResultJson = await result.Content.ReadAsStringAsync();
                    testResult = JsonSerializer.Deserialize<TestResult>(testResultJson);
                }
            }
            catch
            {
                OutputInfoForm(ServiceError);
            }
            return testResult;
        }
    }
}