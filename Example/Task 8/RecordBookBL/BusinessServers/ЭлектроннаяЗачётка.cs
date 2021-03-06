﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewPlatform.RecordBookBL
{
    using System;
    using System.Xml;
    
    
    // *** Start programmer edit section *** (Using statements)
    using System.Collections;
    using System.Linq;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.LINQProvider;
    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Электронная зачётка.
    /// </summary>
    // *** Start programmer edit section *** (ЭлектроннаяЗачётка CustomAttributes)

    // *** End programmer edit section *** (ЭлектроннаяЗачётка CustomAttributes)
    [ICSSoft.STORMNET.AccessType(ICSSoft.STORMNET.AccessType.none)]
    public class ЭлектроннаяЗачётка : ICSSoft.STORMNET.Business.BusinessServer
    {
        
        // *** Start programmer edit section *** (ЭлектроннаяЗачётка CustomMembers)
        private bool MarkExist(IEnumerable marksCollection, NewPlatform.RecordBookBL.Оценка оценка, bool searchAmongDetails)
        {
            var marksCollectionForQuery = marksCollection.Cast<NewPlatform.RecordBookBL.Оценка>();
            var count = searchAmongDetails ? 1 : 0;
            var названиеДисциплины = оценка.Предмет.Дисциплина.Название;
            var фиоСтудента = оценка.Студент.ФИО;
            var названиеСеместра = оценка.Предмет.Семестр.Название;

            return marksCollectionForQuery.Count(m =>
                        m.Предмет.Дисциплина.Название == названиеДисциплины &&
                        m.Студент.ФИО == фиоСтудента &&
                        m.Предмет.Семестр.Название == названиеСеместра) > count;
        }
        // *** End programmer edit section *** (ЭлектроннаяЗачётка CustomMembers)

        
        // *** Start programmer edit section *** (OnUpdateОценка CustomAttributes)

        // *** End programmer edit section *** (OnUpdateОценка CustomAttributes)
        public virtual ICSSoft.STORMNET.DataObject[] OnUpdateОценка(NewPlatform.RecordBookBL.Оценка UpdatedObject)
        {
            // *** Start programmer edit section *** (OnUpdateОценка)
            var monthOfExam = UpdatedObject.Дата.Month;
            if (monthOfExam != 1 && monthOfExam != 6)
            {
                throw new Exception("Экзамены и зачеты могут быть сданы только в январе или в июне!");
            }

            if (UpdatedObject.GetStatus() == ObjectStatus.Created)
            {
                var markQuery = ((SQLDataService) DataService).Query<Оценка>(Оценка.Views.ОценкаE);
                var markExist = MarkExist(markQuery, UpdatedObject, false) || MarkExist(UpdatedObject.Предмет.Оценка, UpdatedObject, true);

                if (markExist)
                {
                    throw new Exception($"У студента '{UpdatedObject.Студент.ФИО}' уже выставлена оценка по предмету '{UpdatedObject.Предмет.Дисциплина.Название}' в семестре '{UpdatedObject.Предмет.Семестр.Название}'");
                }

                if (UpdatedObject.Значение == ЗначениеОценки.НетОценки)
                {
                    UpdatedObject.Состояние = СостояниеОценки.ОценкаНеВыставлена;
                }
                else
                {
                    UpdatedObject.Состояние = СостояниеОценки.ОценкаВыставлена;
                }
            }
            else if (UpdatedObject.GetStatus() == ObjectStatus.Altered)
            {
                if (UpdatedObject.Состояние == СостояниеОценки.ОценкаНеВыставлена && UpdatedObject.Значение != ЗначениеОценки.НетОценки)
                {
                    UpdatedObject.Состояние = СостояниеОценки.ОценкаВыставлена;
                }
                else if (UpdatedObject.Состояние == СостояниеОценки.ОценкаВыставлена && UpdatedObject.Значение != ((Оценка)UpdatedObject.GetDataCopy()).Значение)
                {
                    UpdatedObject.Состояние = СостояниеОценки.ОценкаИсправлена;
                }
            }

            return new ICSSoft.STORMNET.DataObject[0];
            // *** End programmer edit section *** (OnUpdateОценка)
        }
        
        // *** Start programmer edit section *** (OnUpdateСтудент CustomAttributes)

        // *** End programmer edit section *** (OnUpdateСтудент CustomAttributes)
        public virtual ICSSoft.STORMNET.DataObject[] OnUpdateСтудент(NewPlatform.RecordBookBL.Студент UpdatedObject)
        {
            // *** Start programmer edit section *** (OnUpdateСтудент)
            UpdatedObject.НомерЗачетки = CodeGenerator.GetCodeForRecordBook(UpdatedObject);

            return new ICSSoft.STORMNET.DataObject[0];
            // *** End programmer edit section *** (OnUpdateСтудент)
        }
        
        // *** Start programmer edit section *** (OnUpdateЛичность CustomAttributes)

        // *** End programmer edit section *** (OnUpdateЛичность CustomAttributes)
        public virtual ICSSoft.STORMNET.DataObject[] OnUpdateЛичность(NewPlatform.RecordBookBL.Личность UpdatedObject)
        {
            // *** Start programmer edit section *** (OnUpdateЛичность)
            return new ICSSoft.STORMNET.DataObject[0];
            // *** End programmer edit section *** (OnUpdateЛичность)
        }
        
        // *** Start programmer edit section *** (OnUpdateСеместр CustomAttributes)

        // *** End programmer edit section *** (OnUpdateСеместр CustomAttributes)
        public virtual ICSSoft.STORMNET.DataObject[] OnUpdateСеместр(NewPlatform.RecordBookBL.Семестр UpdatedObject)
        {
            // *** Start programmer edit section *** (OnUpdateСеместр)
            return new ICSSoft.STORMNET.DataObject[0];
            // *** End programmer edit section *** (OnUpdateСеместр)
        }
    }
}
