using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalTestingClient
{
    /// <summary>
    /// Контекст приложения
    /// </summary>
    public class ApplicationContextUT : ApplicationContext
    {
        /// <summary>
        /// Количество активных форм
        /// </summary>
        private int FormCount { get; set; }

        /// <summary>
        /// Конструктор объекта контекста приложения
        /// </summary>
        public ApplicationContextUT()
        {
            FormCount = 0;
            UserAuthenticationForm Form = new UserAuthenticationForm(this);
            Form.Show();
        }

        /// <summary>
        /// Добавление формы
        /// </summary>
        public void AddForm()
        {
            FormCount++;
        }

        /// <summary>
        /// Удаление формы и проверка закрытия приложения
        /// </summary>
        public void RemoveForm()
        {
            FormCount--;
            if (FormCount == 0)
            {
                ExitThread();
            }
        }
    }
}
