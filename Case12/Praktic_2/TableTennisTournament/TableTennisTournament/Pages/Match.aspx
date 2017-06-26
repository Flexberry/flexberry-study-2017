<%@ Page Title="Match" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Match.aspx.cs" Inherits="TableTennisTournament.Pages.Match" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel-info">

        <div class="Players">
            <label>
                Player A          
               <select id="Player_List_A" class="Players" oninput="checkPlayers()">
               </select>

                <script type="text/javascript">
                    fillDDL("Player_List_A");
                </script>
            </label>

            <label>
                Player B
                 <select id="Player_List_B" class="Players" oninput="checkPlayers()">
                 </select>

                <script type="text/javascript">
                    fillDDL("Player_List_B");
                </script>

            </label>
            <script>
                function checkPlayers() {
                    var result = true;
                    var PlayerA = $("#Player_List_A")[0];
                    var PlayerB = $("#Player_List_B")[0];
                    if (PlayerA.selectedIndex === PlayerB.selectedIndex) {

                        alert("Validation player Error!");
                    }
                }

            </script>
        </div>


        <div class="calendar">
            <script>
                //document.ready(function() {
                var currentDate = new Date();
                //var date = new Date(currentDate.year, currentDate.month, currentDate.day, currentDate.hour + 1, 0, 0);
                document.getElementById("#matchTime").value = currentDate.toISOString();
                //})
                alert(currentDate.year + '-' + currentDate.month + '-' + currentDate.day + 'T' + currentDate.hour + 1 + ':' + 00);
            </script>
            <label for="matchTime">
                Игра начинается:
                      <input id="matchTime" class="Players" type="datetime-local" min="7:00" max="21:00" onchange="alert(this.value);" required step="300" />

                <%--<script type="text/javascript" src="js/jquery-1.11.1.min.js"></script>--%>
                <!-- 1. Подключить библиотеку jQuery -->
                <script type="text/javascript" src="Scripts/jquery-1.11.1.min.js"></script>
                <!-- 2. Подключить скрипт moment-with-locales.min.js для работы с датами -->
                <script type="text/javascript" src="Scripts/moment-with-locales.min.js"></script>
                <!-- 3. Подключить скрипт платформы Twitter Bootstrap 3 -->
                <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
                <!-- 4. Подключить скрипт виджета "Bootstrap datetimepicker" -->
                <script type="text/javascript" src="../Scripts/bootstrap-datetimepicker.min.js"></script>
                <!-- 5. Подключить CSS платформы Twitter Bootstrap 3 -->
                <link rel="stylesheet" href="../Content/bootstrap.min.css" />
                <!-- 6. Подключить CSS виджета "Bootstrap datetimepicker" -->
                <link rel="stylesheet" href="../Content/bootstrap-datetimepicker.min.css" />
                <div class="form-group">
                    <!-- Элемент HTML с id равным datetimepicker1 -->
                    <div class="input-group date" id="datetimepicker1">
                        <input type="text" class="form-control Players" required />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>

                <!-- Инициализация виджета "Bootstrap datetimepicker" -->
                <script type="text/javascript">
                    $(function () {
                        //Идентификатор элемента HTML (например: #datetimepicker1), для которого необходимо инициализировать виджет "Bootstrap datetimepicker"
                        $('#datetimepicker1').datetimepicker({
                            language: 'ru',
                            minuteStepping: 5
                        });
                    });
                </script>
            </label>

            <%--            <asp:DropDownList ID="Day" runat="server"></asp:DropDownList>/
            <asp:DropDownList ID="Month" runat="server" OnSelectedIndexChanged="Month_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>/
            <asp:DropDownList ID="Year" runat="server"></asp:DropDownList>
                value="2017-03-25T15:00"
            <asp:DropDownList ID="Hour" runat="server"></asp:DropDownList>:
            <asp:DropDownList ID="Minutes" runat="server"></asp:DropDownList>--%>
        </div>

        <div class="GameInfo">
            <div>
                <label for="maxScore">
                    Играем до:
                    <select id="maxScore">
                        <option value="0">11</option>
                        <option value="1">21</option>
                    </select>
                </label>

            </div>
            <div>
                <label for="WinnerRounds">
                    Кол-во партий до ПОБЕДЫ:
                    <input id="WinnerRounds" max="20" min="1" value="3" type="range" onchange="writeScalevalue()"list="WinnerRoundsScale" />
                    <span id="rangeValue">3</span>
                    <%--onchange="document.getElementById('rangeValue').innerHTML = this.value;"--%>
                    <script type="text/javascript">
                        function writeScalevalue() {
                            var scaleVal = $('#WinnerRounds')[0].value;
                            $('#rangeValue')[0].innerHTML = scaleVal;
                        }

                    </script>
                    <datalist id="WinnerRoundsScale">
                        <option value="1" label="1">
                        <option value="5" label="5">
                        <option value="10" label="10">
                        <option value="15" label="15">
                        <option value="20" label="20">
                    </datalist>

                </label>

            </div>
            <div>
                <label for="GameFactorTB">
                    Коэффицент:
                    <input id="GameFactor" type="number" required min="1" value="16" required />
                </label>
            </div>
        </div>
        <div>
            <input id="MatchCreate" type="button" value="Create" onclick="createMatch()" />
        </div>
    </div>

    <div id="RoundsInfo">
        <label for="divPlayerA">
            Игрок 1
            <div id="divPlayerA"></div>
        </label>

        <label for="divPlayerB">
            Игрок 2
             <div id="divPlayerB"></div>
        </label>
    </div>
    <div id = "MatchList">
        <table class="table">
            <thead>
                <tr>
                    <th>Игрок 1</th>
                    <th>Игрок 2</th>
                    <th>Дата</th>
                    <th>Результаты</th>
                   </tr>
            </thead>
            <tbody id="match-list-res">
            </tbody>
        </table>
    </div>

</asp:Content>


