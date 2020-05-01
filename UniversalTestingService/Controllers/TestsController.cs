using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UniversalTestingService.Additional;
using UniversalTestingService.Filters;
using UniversalTestingService.Models;
using UniversalTestingService.Services;

namespace UniversalTestingService.Controllers
{
    /// <summary>
    /// Контроллер тестов
    /// </summary>
    [AuthenticationUser]
    public class TestsController : ApiController
    {
        /// <summary>
        /// Объект контекста базы данных
        /// </summary>
        private UniversalTestingContext Context;
        /// <summary>
        /// Объект сервиса теста
        /// </summary>
        private TestService Service;

        /// <summary>
        /// Конструирует объект контроллера тестов
        /// </summary>
        public TestsController()
        {
            Context = new UniversalTestingContext();
            Service = new TestService(Context);
        }

        /// <summary>
        /// Возвращение списка всех тестов
        /// </summary>
        /// <returns>Список тестов</returns>
        [AuthorizationUser(UserService.AdminRole)]
        public List<Test> GetAllQuestions()
        {
            return Service.GetAllTests();
        }

        /// <summary>
        /// Возвращение теста
        /// </summary>
        /// <param name="id">Номер теста</param>
        /// <returns>Тест</returns>
        [AuthorizationUser(UserService.AdminRole)]
        public Test GetTest(int id)
        {
            return Service.GetTest(id);
        }

        /// <summary>
        /// Возвращение списка вопросов-ответов
        /// </summary>
        /// <param name="id">Номер теста</param>
        /// <returns>Список вопросов-ответов</returns>
        [Route("api/Tests/GetAnswersTest/{id:min(1)}")]
        public List<Answer> GetAnswersTest(int id)
        {
            Test test = Service.GetUserTest(id, ActionContext.RequestContext.Principal);
            if (test == null)
            {
                ModelState.AddModelError("id", $"Тест с номером {id} не найден у пользователя.");
                throw new BadRequestException();
            }
            return Service.GetAnswersTest(test);
        }

        /// <summary>
        /// Возвращение результата теста вызывающего пользователя
        /// </summary>
        /// <param name="id">Номер теста</param>
        /// <returns>Результат теста</returns>
        [Route("api/Tests/GetResultTest/{id:min(1)}")]
        public TestResult GetResultTest(int id)
        {
            Test test = Service.GetUserTest(id, ActionContext.RequestContext.Principal);
            if (test == null)
            {
                ModelState.AddModelError("id", $"Тест с номером {id} не найден у пользователя.");
                throw new BadRequestException();
            }
            return new TestResult() { Result = test.Result, MaxResult = test.MaxResult };
        }

        /// <summary>
        /// Создание теста
        /// </summary>
        /// <param name="subject">Предмет</param>
        /// <param name="easyCount">Количество легких вопросов</param>
        /// <param name="mediumCount">Количество вопросов средней сложности</param>
        /// <param name="hardCount">Количество сложных вопросов</param>
        /// <returns>Номер созданого теста</returns>
        [HttpPost]
        [Route("api/Tests/{subject}/{easyCount:min(1)}/{mediumCount:min(0)}/{hardCount:min(0)}")]
        public int CreateTest(SubjectEnum subject, int easyCount, int mediumCount, int hardCount)
        {
            if (!Enum.IsDefined(typeof(SubjectEnum), subject))
            {
                ModelState.AddModelError("subject", "Данный предмет не найден.");
                throw new BadRequestException();
            }
            return Service.CreateTest(ActionContext.RequestContext.Principal, subject, easyCount, mediumCount, hardCount);
        }

        /// <summary>
        /// Расчет результата для не рассчитанного теста вызывающего пользователя
        /// </summary>
        /// <param name="id">Номер теста</param>
        /// <param name="answers">Список ответов пользователя</param>
        /// <returns>Объект IHttpActionResult</returns>
        [HttpPut]
        public IHttpActionResult CalculationResultTest(int id, [FromBody]List<Answer> answers)
        {
            for (int i = 0; i < answers.Count; i++)
            {
                ModelState.Remove($"answers[{i}].Question.Response");
            }
            if (ModelState.Count > 1)
            {
                throw new BadRequestException();
            }

            Test test = Service.GetUserTest(id, ActionContext.RequestContext.Principal);
            if (test == null)
            {
                ModelState.AddModelError("id", $"Тест с номером {id} не найден у пользователя.");
                throw new BadRequestException();
            }
            if (test.Result == null)
            {
                Service.CalculationResultTest(test, answers);
            }

            return Ok();
        }
    }
}
