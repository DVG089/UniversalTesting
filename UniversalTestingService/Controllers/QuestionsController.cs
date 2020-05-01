using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Контроллер вопросов
    /// </summary>
    [AuthenticationUser]
    [AuthorizationUser(UserService.AdminRole)]
    public class QuestionsController : ApiController
    {
        /// <summary>
        /// Объект контекста базы данных
        /// </summary>
        private UniversalTestingContext Context;
        /// <summary>
        /// Объект сервиса вопроса
        /// </summary>
        private QuestionService Service;

        /// <summary>
        /// Конструирует объект контроллера вопросов
        /// </summary>
        public QuestionsController()
        {
            Context = new UniversalTestingContext();
            Service = new QuestionService(Context);
        }

        /// <summary>
        /// Возвращение списка всех вопросов
        /// </summary>
        /// <returns>Список вопросов</returns>
        public List<Question> GetAllQuestions()
        {
            return Service.GetAllQuestions();
        }

        /// <summary>
        /// Возвращение вопроса
        /// </summary>
        /// <param name="id">Номер вопроса</param>
        /// <returns>Вопрос</returns>
        public Question GetQuestion(int id)
        {
            return Service.GetQuestion(id);
        }

        /// <summary>
        /// Возвращение списка вопросов по фильтру
        /// </summary>
        /// <param name="filter">Объект фильтра</param>
        /// <returns>Список вопросов</returns>
        [Route("api/Questions/GetQuestionsByFilter")]
        public List<Question> GetQuestionsByFilter([FromUri]FilterQuestions filter)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException();
            }
            return Service.GetQuestionsByFilter(filter);
        }

        /// <summary>
        /// Создание вопроса
        /// </summary>
        /// <param name="question">Объект вопроса</param>
        /// <returns>Номер созданого вопроса</returns>
        [HttpPost]
        public int CreateQuestion([FromBody]Question question)
        {
            if (question == null)
            {
                ModelState.AddModelError("user", "Не заданы данные вопроса.");
                throw new BadRequestException();
            }
            if (!ModelState.IsValid)
            {
                throw new BadRequestException();
            }

            int id = Service.CreateQuestion(question);
            return id;
        }

        /// <summary>
        /// Редактирование вопроса при отсутствии ссылок на него
        /// </summary>
        /// <param name="id">Номер вопроса</param>
        /// <param name="question">Объект вопроса</param>
        /// <returns>Результат редактирования</returns>
        [HttpPut]
        public bool EditQuestion(int id, [FromBody]Question question)
        {
            if (!Service.ConstainsQuestion(id))
            {
                ModelState.AddModelError("id", $"Вопрос с номером {id} не найден");
                throw new BadRequestException();
            }
            return Service.EditQuestion(id, question);
        }

        /// <summary>
        /// Редактирование активности вопроса
        /// </summary>
        /// <param name="id">Номер вопроса</param>
        /// <param name="acting">Активность вопроса</param>
        /// <returns>Объект IHttpActionResult</returns>
        [HttpPut]
        [Route("api/Questions/{id:min(1)}/{acting:bool}")]
        public IHttpActionResult EditQuestion(int id, bool acting)
        {
            Question question = Service.GetQuestion(id);
            if (question == null)
            {
                ModelState.AddModelError("question.Id", $"Вопрос с номером {id} не найден");
                throw new BadRequestException();
            }
            Service.EditActingQuestion(question, acting);
            return Ok();
        }
    }
}
