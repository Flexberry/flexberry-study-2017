<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Web.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div > 
        <div class="post-header">
            <h1 class="post-title-main">Вариант 05 - «Электронный учет объектов теплопотребления»</h1>
        </div>
        <div class="post-content">   
            <h2 id="section" class="clickable-header top-level-header">Задание<a class="anchorjs-link " href="#section" aria-label="Anchor link for: section" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h2><i class="icon-arrow-up back-to-top"> </i>
            <p>В рамках выполнения практической части курса вами будет разработан сквозной пример: приложение «Электронный учет объектов теплопотребления» (модуль ИС для тепловых инспекторов).</p>
            <p>Первая часть практического задания будет посвящена освоению базовых технологий, таких как C#, базы данных, клиентские технологии и т.п., вторая часть будет включать изучение возможностей платформы Flexberry для эффективного создания приложений.</p>
            <h2 id="section-1" class="clickable-header top-level-header">Общее описание предметной области<a class="anchorjs-link " href="#section-1" aria-label="Anchor link for: section 1" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h2><i class="icon-arrow-up back-to-top"> </i>
            <p>Требуется создать отдельный модуль приложения для тепловых инспекторов. Данный модуль должен покрывать потребность в учете объектов теплопотребления и их участков сети. Известно, что объекты теплопотребления находятся в зданиях, которые в свою очередь прикреплены к какому-нибудь сетевому району. Каждый объект теплопотребления оформлен на какого-либо потребителя, а также может иметь наружные или внутренние участки сети. Информация об объектах и их участках фиксируется в приложении.</p>
            <p>Технические требования:</p>
            <ul>
              <li>Приложение реализуется в виде ASP.NET WebForms-приложения.</li>
              <li>Данные хранятся в БД MSSQL Server.</li>
            </ul>
            <h2 id="c-net-aspnet" class="clickable-header top-level-header">Практическое задание №1 - Серверная разработка (C#, .NET, ASP.NET)<a class="anchorjs-link " href="#c-net-aspnet" aria-label="Anchor link for: c net aspnet" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h2><i class="icon-arrow-up back-to-top"> </i>
            <p>Для реализации потребуется:</p>
            <ul>
              <li>Microsoft Visual Studio 2015</li>
              <li>Git for Windows</li>
            </ul>
            <h3 id="section-2" class="clickable-header">Задание. Часть 1.<a class="anchorjs-link " href="#section-2" aria-label="Anchor link for: section 2" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h3>
            <p>Требуется реализовать 2 алгоритма генерации уникального цифро-буквенного кода для QR-кода объекта теплопотребления, исходя из следующих входных данных:</p>
            <ul>
              <li>наименование объекта,</li>
              <li>дата регистрации (валидная дата),</li>
              <li>лицевой счет потребителя (только целые числа).</li>
            </ul>
            <p>Алгоритмы формирования данного кода нужно придумать самостоятельно. Тип алгоритма должен содержаться в этом самом коде. Длина цифро-буквенного кода не должна превышать 18 символов. Код должен быть построен таким образом, что по нему должна быть реализована потенциальная возможность вычислить конкретный объект теплопотребления (из известного списка), не храня соответствия между объектом и кодом. Примеры цифро-буквенного кода: <code class="highlighter-rouge">2017-01-01-ШШШШПВ</code>; <code class="highlighter-rouge">А665Б44В121212</code>. К алгоритму следует в комментарии приложить описание выбранного варианта работы алгоритма, т.к. допустимы различные варианты формирования данного цифро-буквенного кода.</p>
            <p>Реализацию следует сделать в виде .net-библиотеки и подготовить модульные тесты для неё, продемонстрировать процент покрытия кода модульными тестами (чем больше, тем лучше).</p>
            <h3 id="section-3" class="clickable-header">Задание. Часть 2.<a class="anchorjs-link " href="#section-3" aria-label="Anchor link for: section 3" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h3>

            <p>Реализовать простое ASP.NET WebForms-приложение (на данном этапе без БД), которое содержит компоненты (ascx-контролы), реализующиие:</p>

            <ol>
              <li>Логику ввода поискового запроса цифро-буквенного кода и использование библиотеки из предыдущего пункта для выдачи информации о найденном объекте теплопотребления (поле для ввода значения, кнопка, блок с отображением результатов).</li>
              <li>Логику получения цифро-буквенного кода для указанной информации о наименовании объекта, его даты регистрации, лицевого счета потребителя (поля для ввода значений, кнопка, блок с отображением результатов).</li>
            </ol>

            <h3 id="section-4" class="clickable-header">Предоставление результатов выполнения работы на проверку<a class="anchorjs-link " href="#section-4" aria-label="Anchor link for: section 4" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h3>

            <p>Реализованное решение (Visual Studio Solution) полностью разместить в репозитории на GitHub (решение должно компилироваться и запускаться). Ссылку на репозиторий предоставить преподавателям курса.</p>

            <h2 id="html-css-js-jquery" class="clickable-header top-level-header">Практическое задание №2 - Клиентская разработка (HTML, CSS, JS, jQuery)<a class="anchorjs-link " href="#html-css-js-jquery" aria-label="Anchor link for: html css js jquery" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h2><i class="icon-arrow-up back-to-top"> </i>

            <p>Для реализации потребуется:</p>

            <ul>
              <li>Редактор кода для клиентской разработки: Visual Studio Code, Atom, Sublime Text и т.п.</li>
              <li>Git for Windows</li>
            </ul>

            <h3 id="section-5" class="clickable-header">Задание<a class="anchorjs-link " href="#section-5" aria-label="Anchor link for: section 5" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h3>

            <h3 id="section-6" class="clickable-header">Предоставление результатов<a class="anchorjs-link " href="#section-6" aria-label="Anchor link for: section 6" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h3>

            <p>Реализованный проект разместить в репозитории на GitHub в виде встроенных страниц <a href="https://pages.github.com/">GitHub Pages</a>, позволяющих просматривать готовый результат. Ссылку на репозиторий и опубликованный таким образом проект предоставить преподавателям курса.</p>

            <h2 id="section-7" class="clickable-header top-level-header">Практическое задание №3 - Базы данных<a class="anchorjs-link " href="#section-7" aria-label="Anchor link for: section 7" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h2><i class="icon-arrow-up back-to-top"> </i>

            <p>Для реализации потребуется:</p>

            <ul>
              <li>Microsoft SQL Server</li>
              <li>Microsoft SQL Server Management Studio</li>
              <li>Git for Windows</li>
            </ul>

            <h3 id="section-8" class="clickable-header">Задание<a class="anchorjs-link " href="#section-8" aria-label="Anchor link for: section 8" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h3>

            <h3 id="section-9" class="clickable-header">Предоставление результатов<a class="anchorjs-link " href="#section-9" aria-label="Anchor link for: section 9" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h3>

            <p>Реализованные скрипты закоммитить в GitHub-репозиторий. Ссылку на репозиторий предоставить преподавателям курса.</p>

            <h2 id="section-10" class="clickable-header top-level-header">Практическое задание №4 - Проектирование ИС<a class="anchorjs-link " href="#section-10" aria-label="Anchor link for: section 10" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h2><i class="icon-arrow-up back-to-top"> </i>

            <p>Для реализации потребуется:</p>

            <ul>
              <li>Flexberry Designer</li>
            </ul>

            <h3 id="section-11" class="clickable-header">Задание<a class="anchorjs-link " href="#section-11" aria-label="Anchor link for: section 11" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h3>

            <p>Нарисовать UML-диаграммы для обозначенной предметной области. Состав диаграмм определяется самим слушателем курсов, но должен обеспечивать полноценное описание предметной области.</p>

            <h3 id="section-12" class="clickable-header">Предоставление результатов<a class="anchorjs-link " href="#section-12" aria-label="Anchor link for: section 12" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h3>

            <p>Результатом работы является выгруженная в формате CRP стадия из Flexberry Designer. Стадию (файл с расширением *.CRP) следует закоммитить в репозиторий на GitHub, ссылку предоставить преподавателям курса.</p>

            <h2 id="section-13" class="clickable-header top-level-header">Практическое задание №5 - Объектный дизайн и генерация приложений<a class="anchorjs-link " href="#section-13" aria-label="Anchor link for: section 13" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h2><i class="icon-arrow-up back-to-top"> </i>

            <p>Для реализации потребуется:</p>

            <ul>
              <li>Flexberry Designer</li>
              <li>Microsoft Visual Studio 2015</li>
              <li>Microsoft SQL Server</li>
              <li>Git for Windows</li>
            </ul>

            <h3 id="section-14" class="clickable-header">Задание<a class="anchorjs-link " href="#section-14" aria-label="Anchor link for: section 14" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h3>

            <p>Выполнить объектный дизайн и генерацию ASP.NET-приложения для описанной предметной области. В качестве основы использовать реализованные ранее UML-модели. Генерация приложения и БД должна быть выполнена средствами Flexberry Designer приложение должно соответствовать требованиям и быть полностью работоспособным. Представления должны быть качественно настроены, подписи к классам и атрибутам на формах должны быть адекватными. Перечень форм и атрибутивный состав должны соответствовать предметной области и покрывать все требуемые бизнес-функции.</p>

            <h3 id="section-15" class="clickable-header">Предоставление результатов<a class="anchorjs-link " href="#section-15" aria-label="Anchor link for: section 15" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h3>

            <p>Сгенерированное приложение и скрипты создания БД следует выложить в репозиторий на GitHub. Предоставить преподавателям ссылку на репозиторий.</p>

            <h2 id="section-16" class="clickable-header top-level-header">Практическое задание №6 - Разработка бизнес-логики приложений<a class="anchorjs-link " href="#section-16" aria-label="Anchor link for: section 16" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h2><i class="icon-arrow-up back-to-top"> </i>

            <p>Для реализации потребуется:</p>

            <ul>
              <li>Flexberry Designer</li>
              <li>Microsoft Visual Studio 2015</li>
              <li>Microsoft SQL Server</li>
              <li>Git for Windows</li>
            </ul>

            <h3 id="section-17" class="clickable-header">Задание<a class="anchorjs-link " href="#section-17" aria-label="Anchor link for: section 17" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h3>

            <p>В сгенерированном при помощи Flexberry Designer приложении требуется реализовать следующую бизнес-логику.</p>

            <ol>
              <li></li>
              <li></li>
            </ol>

            <h3 id="section-18" class="clickable-header">Предоставление результатов<a class="anchorjs-link " href="#section-18" aria-label="Anchor link for: section 18" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h3>

            <p>Доработанная бизнес-логика должна быть включена в разрабатываемое приложение и закоммичена в соответствующий репозиторий. Ссылка на репозиторий предоставляется для проверки преподавателям курса.</p>

            <h2 id="ui--" class="clickable-header top-level-header">Практическое задание №7 - Разработка UI-логики приложения<a class="anchorjs-link " href="#ui--" aria-label="Anchor link for: ui  " data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h2><i class="icon-arrow-up back-to-top"> </i>

            <p>Для реализации потребуется:</p>

            <ul>
              <li>Microsoft Visual Studio 2015</li>
              <li>Microsoft SQL Server</li>
              <li>Редактор кода для клиентской разработки: Visual Studio Code, Atom, Sublime Text и т.п.</li>
              <li>Git for Windows</li>
            </ul>

            <h3 id="section-19" class="clickable-header">Задание<a class="anchorjs-link " href="#section-19" aria-label="Anchor link for: section 19" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h3>

            <h3 id="section-20" class="clickable-header">Предоставление результатов<a class="anchorjs-link " href="#section-20" aria-label="Anchor link for: section 20" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h3>

            <p>Доработанная UI-логика должна быть включена в разрабатываемое приложение и закоммичена в соответствующий репозиторий. Ссылка на репозиторий предоставляется для проверки преподавателям курса.</p>

            <h2 id="flexberry" class="clickable-header top-level-header">Практическое задание №8 - Функциональные подсистемы Flexberry<a class="anchorjs-link " href="#flexberry" aria-label="Anchor link for: flexberry" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h2><i class="icon-arrow-up back-to-top"> </i>

            <p>Для реализации потребуется:</p>

            <ul>
              <li>Flexberry Designer</li>
              <li>Microsoft Visual Studio 2015</li>
              <li>Microsoft SQL Server</li>
              <li>Git for Windows</li>
            </ul>

            <h3 id="section-21" class="clickable-header">Задание<a class="anchorjs-link " href="#section-21" aria-label="Anchor link for: section 21" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h3>

            <p>Для реализованного приложения настроить подсистему полномочий. Пользователи должны заводиться администратором приложения. Авторизация на основе форм. Создать иерархию ролей, добавить операции на просмотр данных и выдать права только определённым пользователям. Настроить несколько ролей и назначить эти роли пользователям.</p>

            <p>Настроить подсистему аудита. В разрабатываемом приложении все изменения объектов данных должно фиксироваться в подсистеме аудита. В навигационное меню следует добавить формы аудита, которые должны показываться только администраторам.</p>

            <h3 id="section-22" class="clickable-header">Предоставление результатов<a class="anchorjs-link " href="#section-22" aria-label="Anchor link for: section 22" data-anchorjs-icon="" style="font-family: anchorjs-icons; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; line-height: 1; padding-left: 0.375em;"></a></h3>

            <p>Доработанное приложение должно быть закоммичено в соответствующий репозиторий. Дополнительно в репозиторий должны быть добавлены SQL-скрипты, которые нужно выполнить для функционирования приложения с подсистемой полномочий и аудита. Ссылка на репозиторий предоставляется для проверки преподавателям курса.</p>
        </div>
    </div>
</asp:Content>
