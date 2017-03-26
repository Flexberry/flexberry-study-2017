<%@ Page AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ICSSoft.STORMNET.Web.Default" Language="C#" MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="desktop-page">
        <div class="desktop">
            <a href="/forms/SotrudnikKafedry/SotrudnikKafedryL.aspx">
                <div>
                    <img src="/shared/img/MessageTypes.png" />
                </div>
                <span>Сотрудники кафедры</span>
            </a>
            <a href="/forms/Gruppa/GruppaL.aspx">
                <div>
                    <img src="/shared/img/Clients.png" />
                </div>
                <span>Группы</span>
            </a>
            <a href="/forms/Prepodavatel/PrepodavatelL.aspx">
                <div>
                    <img src="/shared/img/Subscriptios.png" />
                </div>
                <span>Преподаватели</span>
            </a>
            <a href="/forms/Disciplina/DisciplinaL.aspx">
                <div>
                    <img src="/shared/img/Messages.png" />
                </div>
                <span>Дисциплины</span>
            </a>
            <a href="/forms/Predmet/PredmetL.aspx">
                <div>
                    <img src="/shared/img/EventLog.png" />
                </div>
                <span>Предметы</span>
            </a>
            <a href="/forms/Semestr/SemestrL.aspx">
                <div>
                    <img src="/shared/img/HealthMonitor.png" />
                </div>
                <span>Семестры</span>
            </a>
            <a href="/forms/Fakultet/FakultetL.aspx">
                <div>
                    <img src="/shared/img/StatisticsMonitor.png" />
                </div>
                <span>Факультеты</span>
            </a>
            <a href="/forms/ExecuteQuery.aspx">
                <div>
                    <img src="/shared/img/GraphicScheme.png" />
                </div>
                <span>Отчёты</span>
            </a>
        </div>
    </div>
</asp:Content>
