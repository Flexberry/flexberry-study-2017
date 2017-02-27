using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Objects
{
    /// <summary>
    /// Класс для работы с информацией о днях
    /// </summary>
    public class ExceptionDay
    {
        /// <summary>
        /// Конструктор для создания дня
        /// </summary>
        /// <param name="DateStart">Начало предела повторения</param>
        /// <param name="DateFinish">Окончание предела повторения</param>
        /// <param name="IterationCount">Переодичность</param>
        /// <param name="IterationTipe">Тип повторения(ежедневно, еженедельно, ежемесячно, ежегодно)</param>
        /// <param name="IsWorkDay">Есть рабочие часы - true, нет - false</param>
        /// <param name="Description">Описание дня исключения</param>
        public ExceptionDay(
            DateTime DateStart,
            DateTime DateFinish,
            int IterationCount,
            IterationTipe IterationTipe,
            bool IsWorkDay,
            string Description,
            List<WorkTimeSpan> workTimeSpanCollection)
        {
            this.Id = Guid.NewGuid();
            this.dateStart = DateStart;
            this.dateFinish = DateFinish;
            this.iterationCount = IterationCount;
            this.iterationTipe = IterationTipe;
            this.IsWorkDay = IsWorkDay;
            this.description = Description;
            this.workTimeSpanCollection = workTimeSpanCollection;
        }
        public Guid Id { get; set; }
        public List<WorkTimeSpan> workTimeSpanCollection { get; set; }  //Список для хранения временных промежутков 
        public DateTime dateStart { get; set; }
        public DateTime dateFinish { get; set; }
        public IterationTipe iterationTipe { get; set; }
        public int iterationCount { get; set; }
        public string description { get; set; }
        
        
        /// <summary>
        /// Возвращает общую длительность временных промежутков за один день
        /// </summary>
        public TimeSpan WorkTime 
        { 
            get
            {
                if(workTimeSpanCollection != null)
                {
                    TimeSpan workTime = new TimeSpan(0, 0, 0);
                    foreach (WorkTimeSpan item in workTimeSpanCollection)
                        workTime += item.TotalTime;
                    return workTime;
                }
                else
                {
                    return new TimeSpan(0, 0, 0);
                }
            }
        }
        /// <summary>
        /// Установить или задать тип дня true - рабочий день, false - день исключение
        /// </summary>
        public bool IsWorkDay;
        /// <summary>
        /// Возвращает дату начала дня
        /// </summary>
        /// <returns></returns>
        public DateTime GetDate()
        {
            return this.dateStart;
        }

        /// <summary>
        /// Добавить временной промежуток
        /// </summary>
        /// <param name="item"></param>
        public void AddWorkTimeSpan(WorkTimeSpan item)
        {
            workTimeSpanCollection.Add(item);
        }

        /// <summary>
        /// Возвращает список временных промежутков
        /// </summary>
        /// <returns></returns>
        public List<WorkTimeSpan> GetWorkTimeSpans()
        {
            return workTimeSpanCollection;
        }
    }
}
