<%@ Page Title="Учебный план (клиентский вариант, задание № 2)" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentsClient.aspx.cs" Inherits="AcademicPerformance.StudentsClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Учебный план магистра</h3>


    <head>
    <meta charset="utf-8">
    <title>jQuery UI</title>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="//ajax.aspnetcdn.com/ajax/jquery.ui/1.10.3/jquery-ui.min.js"></script>
    <link rel="stylesheet" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.10.3/themes/sunny/jquery-ui.css">
    <style type="text/css">
        .sortable { display: inline-block;border-radius: 5px;
            width: 20%;  background-color: khaki; color:black;
            float: left; margin: 2px; text-align: center; border: thin solid black;
            padding: 2px;}
        .semester { display: inline-block; color:black;border-radius: 10px;
            width: 100%; background-color: lightgrey; font-size: large;
            float: left; margin: 6px; text-align: center; border: medium solid black;
            padding: 3px;}
        .semester_name {border-radius: 0 10px;
            width: 15%; background-color: lightgreen; font-size: large;
            float: left; margin: 6px; text-align: center; border: thin solid black;
            padding: 10px;}
        .module_name {border-radius: 2px;
            width: 100%; background-color: lightblue; font-size: large;
            float: left; margin: 1px; text-align: center; border: thin solid black;
            padding: 1px;}
        .module_description {border-radius: 2px;
            width: 100%; background-color: navajowhite; font-size:14px;
            float: left; margin: 1px; text-align: center; border: thin solid black;
            padding: 1px;}
    </style>
    <script type="text/javascript">
$(function() {
	
    $('#sortContainer1').sortable();
    $('#sortContainer2').sortable();
    $('#sortContainer3').sortable();
    $('#sortContainer4').sortable();

     $('<div id=buttonDiv><button>Получить порядок</button></div>').appendTo('body');

     $('button').button().click(function () {
         var priority_sem_1 = $('#sortContainer1').sortable("toArray");
         var priority_sem_2 = $('#sortContainer2').sortable("toArray");
         var priority_sem_3 = $('#sortContainer3').sortable("toArray");
         var priority_sem_4 = $('#sortContainer4').sortable("toArray");
             for (var i = 1; i <= priority_sem_1.length; i++) {
                 console.log("Приоритеты в 1 семестре: " + i + " ID: " + priority_sem_1[i-1]);
             }
             for (var i = 1; i <= priority_sem_2.length; i++) {
                 console.log("Приоритеты в 2 семестре: " + i + " ID: " + priority_sem_2[i-1]);
             }
             for (var i = 1; i <= priority_sem_3.length; i++) {
                 console.log("Приоритеты в 3 семестре: " + i + " ID: " + priority_sem_3[i-1]);
             }
             for (var i = 1; i <= priority_sem_4.length; i++) {
                 console.log("Приоритеты в 4 семестре: " + i + " ID: " + priority_sem_4[i-1]);
             }
     })//sortable ui-state-error
});
    </script> 
</head>
<body>
<div id="semester1" class="semester">
    <div id="name1" class="semester_name">1 семестр<br />Дата начала - Дата конца</div>
    <div id="sortContainer1">
        <div id="item1_1" class="sortable">
            <div id="name_1_1" class="module_name">Образовательный блок 1</div><br />
            <div id="description_1_1" class="module_description">Описание кратко содержимого модуля и т.д. и т.п. *текст для объема, а тут подлиннее текст - ve ry roy eryf eoryfoery oyer*</div><br />
        </div>
        <div id="item2_1" class="sortable">
            <div id="name_2_1" class="module_name">Образовательный блок 2</div><br />
            <div id="description_2_1" class="module_description">Описание кратко содержимого модуля и т.д. и т.п. *текст для объема*</div><br />
        </div>
        <div id="item3_1" class="sortable">
            <div id="name_3_1" class="module_name">Образовательный блок 3</div><br />
            <div id="description_3_1" class="module_description">Описание кратко содержимого модуля и т.д. и т.п. *текст для объема*</div><br />
        </div>
    </div><br>
    </div>
    <div id="semester2" class="semester">
    <div id="name2" class="semester_name">2 семестр<br />Дата начала - Дата конца</div>
    <div id="sortContainer2">
        <div id="item1_2" class="sortable">
            <div id="name_1_2" class="module_name">Образовательный блок 1</div><br />
            <div id="description_1_2" class="module_description">Описание кратко содержимого модуля и т.д. и т.п. *текст для объема*</div><br />
        </div>
        <div id="item2_2" class="sortable">
            <div id="name_2_2" class="module_name">Образовательный блок 2</div><br />
            <div id="description_2_2" class="module_description">Описание кратко содержимого модуля и т.д. и т.п. *текст для объема*</div><br />
        </div>
        <div id="item3_2" class="sortable">
            <div id="name_3_2" class="module_name">Образовательный блок 3</div><br />
            <div id="description_3_2" class="module_description">Описание кратко содержимого модуля и т.д. и т.п. *текст для объема*</div><br />
        </div>
    </div><br>
    </div>
    <div id="semester3" class="semester">
    <div id="name3" class="semester_name">3 семестр<br />Дата начала - Дата конца</div>
    <div id="sortContainer3">
        <div id="item1_3" class="sortable">
            <div id="name_1_3" class="module_name">Образовательный блок 1</div><br />
            <div id="description_1_3" class="module_description">Описание кратко содержимого модуля и т.д. и т.п. *текст для объема*</div><br />
        </div>
        <div id="item2_3" class="sortable">
            <div id="name_2_3" class="module_name">Образовательный блок 2</div><br />
            <div id="description_2_3" class="module_description">Описание кратко содержимого модуля и т.д. и т.п. *текст для объема*</div><br />
        </div>
        <div id="item3_3" class="sortable">
            <div id="name_3_3" class="module_name">Образовательный блок 3</div><br />
            <div id="description_3_3" class="module_description">Описание кратко содержимого модуля и т.д. и т.п. *текст для объема*</div><br />
        </div>
    </div><br>
    </div>
    <div id="semester4" class="semester">
    <div id="name4" class="semester_name">4 семестр<br />Дата начала - Дата конца</div>
    <div id="sortContainer4">
        <div id="item1_4" class="sortable">
            <div id="name_1_4" class="module_name">Образовательный блок 1</div><br />
            <div id="description_1_4" class="module_description">Описание кратко содержимого модуля и т.д. и т.п. *текст для объема*</div><br />
        </div>
        <div id="item2_4" class="sortable">
            <div id="name_2_4" class="module_name">Образовательный блок 2</div><br />
            <div id="description_2_4" class="module_description">Описание кратко содержимого модуля и т.д. и т.п. *текст для объема*</div><br />
        </div>
        <div id="item3_4" class="sortable">
            <div id="name_3_4" class="module_name">Образовательный блок 3</div><br />
            <div id="description_3_4" class="module_description">Описание кратко содержимого модуля и т.д. и т.п. *текст для объема*</div><br />
        </div>
        <div id="item4_4" class="sortable">
            <div id="name_4_4" class="module_name">Образовательный блок 4</div><br />
            <div id="description_4_4" class="module_description">Описание кратко содержимого модуля и т.д. и т.п. *текст для объема*</div><br />
        </div>
    </div>
       
    </div> <br />
</body>



 

    <script type="text/javascript">
       

        $(function () {
            $('.main-form').submit(function (event) {
                event.preventDefault();
            });
           
        });
    </script>
</asp:Content>
