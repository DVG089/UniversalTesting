using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using UniversalTestingService.Models;

namespace UniversalTestingService.Services
{
    /// <summary>
    /// Класс сервиса вопроса
    /// </summary>
    public class QuestionService
    {
        /// <summary>
        /// Объект контекста базы данных
        /// </summary>
        private UniversalTestingContext Context;

        /// <summary>
        /// Конструктор объекта сервиса вопроса
        /// </summary>
        /// <param name="context">Объект контекста базы данных</param>
        public QuestionService(UniversalTestingContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Возвращение списка всех вопросов
        /// </summary>
        /// <returns>Список вопросов</returns>
        public List<Question> GetAllQuestions()
        {
            return Context.Questions.ToList();
        }

        /// <summary>
        /// Возвращение вопроса
        /// </summary>
        /// <param name="id">Номер вопроса</param>
        /// <returns>Вопрос</returns>
        public Question GetQuestion(int id)
        {
            return Context.Questions.FirstOrDefault(n => n.Id == id);
        }

        /// <summary>
        /// Возвращение списка вопросов по фильтру
        /// </summary>
        /// <param name="filter">Объект фильтра вопросов</param>
        /// <returns>Список вопросов</returns>
        public List<Question> GetQuestionsByFilter(FilterQuestions filter)
        {
            List<Question> listQuestions = null;
            IQueryable<Question> questions = Context.Questions;
            if (filter.Acting != null)
            {
                questions = questions.Where(n => n.Acting == filter.Acting);
            }
            if (filter.LevelDifficulty != null)
            {
                questions = questions.Where(n => n.LevelDifficulty == filter.LevelDifficulty);
            }
            if (filter.Subject != null)
            {
                questions = questions.Where(n => n.Subject == filter.Subject);
            }
            listQuestions = questions.ToList();
            return listQuestions;
        }

        /// <summary>
        /// Создание вопроса
        /// </summary>
        /// <param name="question">Объект вопроса</param>
        public int CreateQuestion(Question question)
        {
            int id;
            Context.Questions.Add(question);
            Context.SaveChanges();
            id = question.Id;
            return id;
        }

        /// <summary>
        /// Проверка наличия вопроса
        /// </summary>
        /// <param name="id">Номер вопроса</param>
        /// <returns>Результат проверки</returns>
        public bool ConstainsQuestion(int id)
        {
            return Context.Questions.Any(n => n.Id == id);
        }

        /// <summary>
        /// Редактирование вопроса
        /// </summary>
        /// <param name="id">Номер вопроса</param>
        /// <param name="question">Вопрос</param>
        /// <returns>Результат редактирования</returns>
        public bool EditQuestion(int id, Question question)
        {
            bool result;
            question.Id = id;
            if (!Context.Answers.Any(n => n.QuestionId == question.Id))
            {
                Context.Entry(question).State = EntityState.Modified;
                Context.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Редактирование активности вопроса 
        /// </summary>
        /// <param name="question">Вопрос</param>
        /// <param name="acting">Активность вопроса</param>
        public void EditActingQuestion(Question question, bool acting)
        {
            question.Acting = acting;
            Context.Entry(question).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}