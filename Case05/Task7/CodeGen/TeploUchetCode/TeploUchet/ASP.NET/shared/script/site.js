//кнопка поиска объекта по коду
function findBtnClickAlert() {
    var url = "/forms/Rajon/RajonL.aspx";
    var host = window.location.host;
    var targetUrl = host + url;
    document.location.href = "Find.aspx";
}
//сортировка участков в объекте
function sortBubble(col, sum) {
    for (var i = sum - 1; i >= 0; i--) {
        for (var j = 0; j < i; j++) {
            console.log("j=" + j + " col[j]=" + $("a", col[j]).attr("Name"));
            if ($("a", col[j]).attr("Name") > $("a", col[j + 1]).attr("Name")) {
                var t = col[j];
                col[j] = col[j + 1];
                col[j + 1] = t;
            };
        };
    };
    return col;
}

//сортировка объекта и участков
//element - объект
function buildScheme(element) {
    col = $('.plan > .sector');
    sum = $('.plan > .sector').length;
    console.log("element в buildScheme " + $(element).attr("class") );
    console.log("секоторов в плане  " + sum);
    console.log("первый элемент плана  " + $("a", col[0]).attr("Name"));
    console.log("первый элемент объекта = " + $(".sector:first a", $(element)).attr("Name"));
    for (var i = 0; i <= sum; i++) {
        if ( $(".sector:first a", $(element)).attr("Name") > $("a", col[i]).attr("Name") ) {
            $(element).insertAfter(col[i]);
        };
    };
}

//показывать форму ввода при клике на участок сети
function showField(e) {
    var sectorClicked = $(this)
    console.log("click on  - " + $(this).attr("class"));
    console.log("parent click on  - " + $(this).parent().attr("class"));
    if ($('.fieldset', $(this).parent()).attr("class").indexOf("hidden") !== -1) {
        $(".fieldset", $(this).parent()).removeClass("hidden");
        $("#ContentPlaceHolder1_MainPanel").css(min - height, $("#ContentPlaceHolder1_MainPanel").css(min-heigh) + $(".fieldset:first").css(height) );
    }
    else {
        $(".fieldset", $(this).parent()).addClass("hidden");
    }
}
//выбор типа прокладки из списка и применение класса на участок
function selectValue(e, sect) {
    console.log("changed this = " + e + " in sector " + sect);
    $("." + sect).removeClass("overground");
    $("." + sect).removeClass("underground");
    $("." + sect).removeClass("basement");
    $("." + sect).addClass(e);
}
//вставка поля теплоизоляция
function inputIsulation(e, sect) {
    console.log("input text = " + e + " in sector " + sect);
    $(".sector-insulation", $("." + sect)).text(e);
}
//перетаскивание блоков
$(document).ready(function () {
    //перетаскиваем блок
    $('.draggable').draggable({
        axis: "x", //по оси х
        containment: $('.plan'),   // перемещать только по плану           

        start: function () {
            var addsector = $(this);
            addsector.css("z-index", "20");
            $('.object').droppable({
                tolerance: "pointer",

                drop: function () {
                    console.log("Start Add Sector in Object+++++++++++");
                    $(this).append(addsector); // добавляем сектор в объект

                    var col = $('.sector', $(this)); //все элементы сектор в объекте
                    col.each(function (index, element) {
                        console.log("col: " + $("a", element).attr("Name"));
                    });
                    var sum = $('.sector', $(this)).length; // кол-во элементов сектор в  объекте
                    console.log("object sum= " + sum);

                    //сортируем элементы по аттрибуту Name сектора
                    console.log("Start Sort in object");
                    sortBubble(col, sum);
                    console.log("End sort");

                    //удаляем старые элементы сеторa
                    $('.sector', $(this)).detach();
                    // добавляем отсортированные элементы
                    console.log("Start Add sectors in object");
                    for (var j = 0; j < sum; j++) {
                        $(this).append(col[j]);
                        console.log("j=" + j + " col[j]=" + $("a", col[j]).attr("Name"));
                    };
                    console.log("End to add sectors");
                    console.log("End to Add in Object-----------");

                    buildScheme($(this));
                },

                // при перемещении из объекта
                out: function () {
                    console.log("Start Add Sector in plan+++++++++++");
                    $('.plan').append(addsector); // добавляем сектор в схему

                    var col = $('.plan > .sector'); //получаем все элементы сектор
                    col.each(function (index, element) {
                        console.log("col: " + $("a", element).attr("Name"));
                    });
                    var sum = $('.plan > .sector').length; // кол-во элементов сектор в  объекте
                    console.log("plan sum= " + sum);
                    //сортируем элементы по аттрибуту Name сектора
                    console.log("Start Sort in Plan");
                    sortBubble(col, sum);
                    console.log("End sort");
                    //удаляем старые элементы сеторa
                    $('.plan > .sector').detach();
                    // добавляем отсортированные элементы
                    console.log("Start Add sectors in object");
                    for (var j = 0; j < sum; j++) {
                        $('.plan').append(col[j]);
                        console.log("j=" + j + " col[j]=" + $("a", col[j]).attr("Name"));
                    };
                    console.log("End to add sectors");
                    console.log("End Add in plan-----------");

                    buildScheme($(this));
                }
            });
        },
        stop: function () {
            //свойства для отображения после перемещения            
            $(this).css("left", "auto");
            $(this).css("z-index", "auto");
        }
    });
});
$(document).ready(function () {
    //вызов формы кликом по сектору
    // $('.sector h4').bind("click", showField);
    // $('.sector p').bind("click", showField);
    $('.sector .clickable').bind("click", showField);
    $()
    //исчезает форма после клика
    $('input[type="button"]').bind("click", function () {
        var prnt = $(this).parent(); //fieldset
        prnt.addClass("hidden");
        SaveBtn_Click($(this));
    });
});