using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using UniversalTestingService.Models;

namespace UniversalTestingService.Services
{
    /// <summary>
    /// Класс сервиса теста
    /// </summary>
    public class TestService
    {
        /// <summary>
        /// Объект контекста базы данных
        /// </summary>
        private UniversalTestingContext Context;

        /// <summary>
        /// Конструктор объекта сервиса вопроса
        /// </summary>
        /// <param name="context">Объект контекста базы данных</param>
        public TestService(UniversalTestingContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Возвращение списка всех тестов
        /// </summary>
        /// <returns>Список тестов</returns>
        public List<Test> GetAllTests()
        {
            List<Test> listTests = Context.Tests.Include("Answers").ToList();
            foreach (Test test in listTests)
            {
                foreach (Answer answer in test.Answers)
                {
                    Context.Entry(answer).Reference("Question").Load();
                }
            }
            return listTests;
        }

        /// <summary>
        /// Возвращение теста
        /// </summary>
        /// <param name="id">Номер теста</param>
        /// <returns>Тест</returns>
        public Test GetTest(int id)
        {
            Test test = Context.Tests.FirstOrDefault(n => n.Id == id);
            Context.Entry(test).Collection("Answers").Load();
            foreach (Answer answer in test.Answers)
            {
                Context.Entry(answer).Reference("Question").Load();
            }
            return test;
        }

        /// <summary>
        /// Создание теста
        /// </summary>
        /// <param name="principal">Объект аутенфицированого пользователя</param>
        /// <param name="subject">Предмет</param>
        /// <param name="easyCount">Количество легких вопросов</param>
        /// <param name="mediumCount">Количество вопросов средней сложности</param>
        /// <param name="hardCount">Количество сложных вопросов</param>
        /// <returns>Номер созданого теста</returns>
        public int CreateTest(IPrincipal principal, SubjectEnum subject, int easyCount, int mediumCount, int hardCount)
        {
            Test test = new Test();
            List<int> idQuestions;
            Context.Tests.Add(test);
            Context.SaveChanges();

            test.UserLogin = principal.Identity.Name;
            test.Subject = subject;
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        idQuestions = GetQuestions(subject, LevelDifficultyEnum.Easy, easyCount);
                        test.EasyCount = idQuestions.Count;
                        break;
                    case 1:
                        idQuestions = GetQuestions(subject, LevelDifficultyEnum.Medium, mediumCount);
                        test.MediumCount = idQuestions.Count;
                        break;
                    default:
                        idQuestions = GetQuestions(subject, LevelDifficultyEnum.Hard, hardCount);
                        test.HardCount = idQuestions.Count;
                        break;
                }
                foreach (int idQuestion in idQuestions)
                {
                    Answer answer = new Answer();
                    answer.QuestionId = idQuestion;
                    answer.TestId = test.Id;
                    Context.Answers.Add(answer);
                }
            }
            CalculateMaxResult(test);
            Context.SaveChanges();

            return test.Id;
        }

        /// <summary>
        /// Возвращение списка вопросов-ответов
        /// </summary>
        /// <param name="test">Тест</param>
        /// <returns>Список вопросов-ответов</returns>
        public List<Answer> GetAnswersTest(Test test)
        {
            Context.Entry(test).Collection("Answers").Load();
            foreach (Answer answer in test.Answers)
            {
                Context.Entry(answer).Reference("Question").Load();
                answer.Question.Response = null;
            }
            return test.Answers;
        }

        /// <summary>
        /// Возвращение списка случайных номеров вопросов
        /// </summary>
        /// <param name="subject">Предмет</param>
        /// <param name="levelDifficulty">Уровень сложности</param>
        /// <param name="count">Количество вопросов</param>
        /// <returns></returns>
        private List<int> GetQuestions(SubjectEnum subject, LevelDifficultyEnum levelDifficulty, int count)
        {
            List<int> IdQuestions = Context.Questions.Where(n => n.Subject == subject && n.LevelDifficulty == levelDifficulty && n.Acting == true).
                Select(n => n.Id).OrderBy(n => Guid.NewGuid()).Take(count).ToList();
            return IdQuestions;
        }

        /// <summary>
        /// Расчет результата для не рассчитанного теста вызывающего пользователя
        /// </summary>
        /// <param name="test">Тест</param>
        /// <param name="answers">Список ответов пользователя</param>
        public void CalculationResultTest(Test test, List<Answer> answers)
        {
            int result = 0;
            Context.Entry(test).Collection("Answers").Load();
            foreach (Answer answer in test.Answers)
            {
                foreach (Answer answerUser in answers)
                {
                    if (answer.Id == answerUser.Id)
                    {
                        answer.AnswerBody = answerUser.AnswerBody;
                        Context.Entry(answer).Reference("Question").Load();
                        if (answer.Question.Response == answer.AnswerBody)
                        {
                            result = result + (int)answer.Question.LevelDifficulty;
                        }
                        break;
                    }
                }
            }
            test.Result = result;
            Context.SaveChanges();
        }

        /// <summary>
        /// Возвращение теста вызывающего пользователя
        /// </summary>
        /// <param name="id">Номер теста</param>
        /// <param name="principal">Объект аутенфицированого пользователя</param>
        /// <returns>Тест</returns>
        public Test GetUserTest(int id, IPrincipal principal)
        {
            return Context.Tests.FirstOrDefault(n => n.Id == id && n.UserLogin == principal.Identity.Name);
        }

        /// <summary>
        /// Расчет и установка максимального результата теста
        /// </summary>
        /// <param name="test">Тест</param>
        private void CalculateMaxResult(Test test)
        {
            test.MaxResult = (int)LevelDifficultyEnum.Easy * test.EasyCount + (int)LevelDifficultyEnum.Medium * test.MediumCount
                + (int)LevelDifficultyEnum.Hard * test.HardCount;
        }
    }
}