
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniversalTestingService.Models
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class UniversalTestingContext : DbContext
    {
        /// <summary>
        /// Объект контекста базы данных
        /// </summary>
        public UniversalTestingContext()
            : base("UniversalTestingMsSQLServer")
        { 
        }

        /// <summary>
        /// Таблица Users
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Таблица Questions
        /// </summary>
        public DbSet<Question> Questions { get; set; }
        /// <summary>
        /// Таблица Answers
        /// </summary>
        public DbSet<Answer> Answers { get; set; }
        /// <summary>
        /// Таблица Tests
        /// </summary>
        public DbSet<Test> Tests { get; set; }
    }
}