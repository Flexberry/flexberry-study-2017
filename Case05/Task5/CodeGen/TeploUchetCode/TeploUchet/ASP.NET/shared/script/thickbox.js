/*
* Внимание! Это модифицированный thickbox. Изменены методы 
* tb_Ready() и tb_init(), чтобы он работал по клику на td (атрибут abbr)
* Thickbox 3.1 - One Box To Rule Them All.
* By Cody Lindley (http://www.codylindley.com)
* Copyright (c) 2007 cody lindley
* Licensed under the MIT License: http://www.opensource.org/licenses/mit-license.php
*/

/*!!!!!!!!!!!!!!!!! edit below this line at your own risk !!!!!!!!!!!!!!!!!!!!!!!*/
//on page load call tb_init
$(document).ready(function () {
    tb_Ready();
});

// Хаберев: Добавил данную переменную, чтобы можно было отловить событие закрытия окна из других скриптов
/**
 * Deffered object to catch close event in other scripts.
 *
 * @type {jQuery.Deferred}
 */
//var tb_CloseActionDeferred;

function tb_Ready() {
    tb_init('a.thickbox, area.thickbox, input.thickbox, td.thickbox'); //pass where to apply thickbox
}

//add thickbox to href & area elements that have a class of .thickbox
function tb_init(domChunk) {
    // KULIKOV: Добавил unbind, чтобы не вешать один и тот же обработчик много раз
    $(domChunk).unbind("click").click(function () {
        var t = this.rel || this.title || this.name || null;
        var a = this.href || this.alt || this.abbr;
        var g = false;
        tb_show(t, a, g);
        this.blur();
        return false;
    });
}

function tb_show(caption, url, imageGroup) { //function called when the user clicks on a thickbox link

    //tb_CloseActionDeferred = $.Deferred();
    try {
        if (typeof document.body.style.maxHeight === "undefined") { //if IE 6
            $("body", "html").css({ height: "100%", width: "100%" });
            // KLIMOV: чтобы предотвратить мерцание скролл-бара в эксплорере (он исчезал при появлении окошка)
            //$("html").css("overflow","hidden");
            if (document.getElementById("TB_HideSelect") === null) { //iframe to hide select elements in ie6
                $("body").append("<iframe id='TB_HideSelect'></iframe><div id='TB_overlay'></div><div id='TB_window'></div>");
                $("#TB_overlay").click(tb_remove);
            }
        } else { //all others
            if (document.getElementById("TB_overlay") === null) {
                $("body").append("<div id='TB_overlay'></div><div id='TB_window'></div>");
                $("#TB_overlay").click(tb_remove);
            }
        }

        if (tb_detectMacXFF()) {
            $("#TB_overlay").addClass("TB_overlayMacFFBGHack"); //use png overlay so hide flash
        } else {
            $("#TB_overlay").addClass("TB_overlayBG"); //use background and opacity
        }

        if (caption === null) {
            caption = "";
        }

        $("body").append('<div id="TB_load"><div id="TB_loadAnimation"></div></div>'); //add loader to the page
        $('#TB_load').show(); //show loader

        // Балуев: изменено для поддержки веб-сервисов (в конце url должно быть имя файла)
        var urlString = /\.jpg$|\.jpeg$|\.png$|\.gif$|\.bmp$/;
        var baseURL;
        if (!(url.toLowerCase().match(urlString)) && url.indexOf("?") !== -1) { //ff there is a query string involved
            baseURL = url.substr(0, url.indexOf("?"));
        } else {
            baseURL = url;
        }

        var urlType = baseURL.toLowerCase().match(urlString);

        if (urlType == '.jpg' || urlType == '.jpeg' || urlType == '.png' || urlType == '.gif' || urlType == '.bmp') { //code to show images

            TB_PrevCaption = "";
            TB_PrevURL = "";
            TB_PrevHTML = "";
            TB_NextCaption = "";
            TB_NextURL = "";
            TB_NextHTML = "";
            TB_imageCount = "";
            TB_FoundURL = false;
            if (imageGroup) {
                TB_TempArray = $("a[@rel=" + imageGroup + "]").get();
                for (TB_Counter = 0; ((TB_Counter < TB_TempArray.length) && (TB_NextHTML === "")) ; TB_Counter++) {
                    var urlTypeTemp = TB_TempArray[TB_Counter].href.toLowerCase().match(urlString);
                    if (!(TB_TempArray[TB_Counter].href == url)) {
                        if (TB_FoundURL) {
                            TB_NextCaption = TB_TempArray[TB_Counter].title;
                            TB_NextURL = TB_TempArray[TB_Counter].href;
                            TB_NextHTML = "<span id='TB_next'>&nbsp;&nbsp;<a href='#'>Next &gt;</a></span>";
                        } else {
                            TB_PrevCaption = TB_TempArray[TB_Counter].title;
                            TB_PrevURL = TB_TempArray[TB_Counter].href;
                            TB_PrevHTML = "<span id='TB_prev'>&nbsp;&nbsp;<a href='#'>&lt; Prev</a></span>";
                        }
                    } else {
                        TB_FoundURL = true;
                        TB_imageCount = "Image " + (TB_Counter + 1) + " of " + (TB_TempArray.length);
                    }
                }
            }

            imgPreloader = new Image();
            imgPreloader.onload = function () {
                imgPreloader.onload = null;

                // Resizing large images - orginal by Christian Montoya edited by me.
                var pagesize = tb_getPageSize();
                var x = pagesize[0] - 150;
                var y = pagesize[1] - 150;
                var imageWidth = imgPreloader.width;
                var imageHeight = imgPreloader.height;
                if (imageWidth > x) {
                    imageHeight = imageHeight * (x / imageWidth);
                    imageWidth = x;
                    if (imageHeight > y) {
                        imageWidth = imageWidth * (y / imageHeight);
                        imageHeight = y;
                    }
                } else if (imageHeight > y) {
                    imageWidth = imageWidth * (y / imageHeight);
                    imageHeight = y;
                    if (imageWidth > x) {
                        imageHeight = imageHeight * (x / imageWidth);
                        imageWidth = x;
                    }
                }
                // End Resizing

                TB_WIDTH = imageWidth + 30;
                TB_HEIGHT = imageHeight + 60;
                $("#TB_window").append("<a href='' id='TB_ImageOff' title='Close'><img id='TB_Image' src='" + url + "' width='" + imageWidth + "' height='" + imageHeight + "' alt='" + caption + "'/></a>" + "<div id='TB_caption'>" + caption + "<div id='TB_secondLine'>" + TB_imageCount + TB_PrevHTML + TB_NextHTML + "</div></div><div id='TB_closeWindow'><span id='TB_closeWindowButton' title='Закрыть или [Esc]'>закрыть</span></div>");

                $("#TB_closeWindowButton").click(tb_remove);

                if (!(TB_PrevHTML === "")) {

                    function goPrev() {
                        if ($(document).unbind("click", goPrev)) {
                            $(document).unbind("click", goPrev);
                        }
                        $("#TB_window").remove();
                        $("body").append("<div id='TB_window'></div>");
                        tb_show(TB_PrevCaption, TB_PrevURL, imageGroup);
                        return false;
                    }

                    $("#TB_prev").click(goPrev);
                }

                if (!(TB_NextHTML === "")) {

                    function goNext() {
                        $("#TB_window").remove();
                        $("body").append("<div id='TB_window'></div>");
                        tb_show(TB_NextCaption, TB_NextURL, imageGroup);
                        return false;
                    }

                    $("#TB_next").click(goNext);

                }

                document.onkeydown = function (e) {
                    if (e == null) { // ie
                        keycode = event.keyCode;
                    } else { // mozilla
                        keycode = e.which;
                    }
                    if (keycode == 27) { // close
                        tb_remove();
                    } else if (keycode == 190) { // display previous image
                        if (!(TB_NextHTML == "")) {
                            document.onkeydown = "";
                            goNext();
                        }
                    } else if (keycode == 188) { // display next image
                        if (!(TB_PrevHTML == "")) {
                            document.onkeydown = "";
                            goPrev();
                        }
                    }
                };

                tb_position();
                $("#TB_load").remove();
                $("#TB_ImageOff").click(tb_remove);
                $("#TB_window").css({ display: "block" }); //for safari using css instead of show
            };

            imgPreloader.src = url;
        } else { //code to show html

            var queryString = url.replace(/^[^\?]+\??/, '');
            var params = tb_parseQuery(queryString);

            TB_WIDTH = (params['width'] * 1) + 30 || 630; //defaults to 630 if no paramaters were added to URL
            TB_HEIGHT = (params['height'] * 1) + 40 || 440; //defaults to 440 if no paramaters were added to URL

            // Если окно очень маленькое
            if ($(window).width() < TB_WIDTH) {
                TB_WIDTH = $(window).width() - 40;
            }

            if ($(window).height() < TB_HEIGHT) {
                TB_HEIGHT = $(window).height() - 40;
            }

            // Если thickbox открыт еще в thickbox - работает для iframe (лукапы)
            if (self != top) {
                var iframeLength = parent.document.getElementsByTagName("IFRAME").length;
                TB_HEIGHT = TB_HEIGHT - 60 * iframeLength;
                TB_WIDTH = TB_WIDTH - 40 * iframeLength;
            }

            ajaxContentW = TB_WIDTH - 30;
            ajaxContentH = TB_HEIGHT - 45;

            if (url.indexOf('TB_iframe') != -1) { // either iframe or ajax window		
                urlNoQuery = url.split('TB_');
                $("#TB_iframeContent").remove();
                if (params['modal'] != "true") { //iframe no modal
                    $("#TB_window").append("<div id='TB_title'><div id='TB_ajaxWindowTitle'>" + caption + "</div><div id='TB_closeAjaxWindow'><span id='TB_closeWindowButton' title='Закрыть или [Esc]'>закрыть</span></div></div><iframe frameborder='0' hspace='0' src='" + urlNoQuery[0] + "' id='TB_iframeContent' name='TB_iframeContent" + Math.round(Math.random() * 1000) + "' onload='tb_showIframe()' style='width:" + (ajaxContentW + 29) + "px;height:" + (ajaxContentH + 17) + "px;' > </iframe>");
                } else { //iframe modal
                    $("#TB_overlay").unbind();
                    $("#TB_window").append("<iframe frameborder='0' hspace='0' src='" + urlNoQuery[0] + "' id='TB_iframeContent' name='TB_iframeContent" + Math.round(Math.random() * 1000) + "' onload='tb_showIframe()' style='width:" + (ajaxContentW + 29) + "px;height:" + (ajaxContentH + 17) + "px;'> </iframe>");
                }
            } else { // not an iframe, ajax
                if ($("#TB_window").css("display") != "block") {
                    if (params['modal'] != "true") { //ajax no modal
                        $("#TB_window").append("<div id='TB_title'><div id='TB_ajaxWindowTitle'>" + caption + "</div><div id='TB_closeAjaxWindow'><span id='TB_closeWindowButton' title='Закрыть или [Esc]'>закрыть</span></div></div><div id='TB_ajaxContent' style='width:" + ajaxContentW + "px;height:" + ajaxContentH + "px'></div>");
                    } else { //ajax modal
                        $("#TB_overlay").unbind();
                        $("#TB_window").append("<div id='TB_ajaxContent' class='TB_modal' style='width:" + ajaxContentW + "px;height:" + ajaxContentH + "px;'></div>");
                    }
                } else { //this means the window is already up, we are just loading new content via ajax
                    $("#TB_ajaxContent")[0].style.width = ajaxContentW + "px";
                    $("#TB_ajaxContent")[0].style.height = ajaxContentH + "px";
                    $("#TB_ajaxContent")[0].scrollTop = 0;
                    $("#TB_ajaxWindowTitle").html(caption);
                }
            }

            $("#TB_closeWindowButton").click(tb_remove);

            // Балуев: показ окна вынесен перед загрузкой,
            // чтобы на момент события ready контент был показан
            $("#TB_window").css({ display: "block" });
            if (url.indexOf('TB_inline') != -1) {
                $("#TB_ajaxContent").append($('#' + params['inlineId']).children());
                $("#TB_window").bind('unload.tb', function () {
                    $('#' + params['inlineId']).append($("#TB_ajaxContent").children()); // move elements back when you're finished
                });
                tb_position();
                $("#TB_load").remove();
            } else if (url.indexOf('TB_iframe') != -1) {
                tb_position();
                if ($.browser.safari) { //safari needs help because it will not fire iframe onload
                    $("#TB_load").remove();
                }
            } else {
                $("#TB_ajaxContent").load(url += "&random=" + (new Date().getTime()), function () { //to do a post change this load method
                    tb_position();
                    $("#TB_load").remove();
                    tb_init("#TB_ajaxContent a.thickbox");
                });
            }

        }

        if (!params['modal']) {
            document.onkeyup = function (e) {
                if (e == null) { // ie
                    keycode = event.keyCode;
                } else { // mozilla
                    keycode = e.which;
                }
                if (keycode == 27) { // close
                    tb_remove();
                }
            };
        }

    } catch (e) {
        //nothing here
    }

    // блок кода, который делает thickbox перемещаемым и размероизменяемым
    try {
        // Елисеев. А.: Т.к. текущая верстка WebErrorBox не соответствует ожиданиям thickbox,
        // то для возможности выделения текста добавлен параметр, отключающий перетаскивание 
        // мышкой за блок содержимого.
        // TODO: Переверстать WebErrorBox. 
        $('#TB_window')
            .draggable({ handle: "#TB_title", cancel: "#ctlWebErrorBox" });
        if (!params['noresize']) {

            // Iframe содержит в себе отдельный документ, который перехватывает различные события,
            // например mousemove. Из-за этого нельзя было уменьшить окно (движение курсора попадало в iframe).
            // Поэтому я добавил оверлей в модальное окно, который буду показывать при старте ресайза, и скрывать
            // по окончанию - т.е. iframe будет скрыт под этим блоком и не будет перехватывать события.
            var resizableOverlay = $("<div id='TB_iframeContent_overlay' style='position:absolute;top:0;width:0;margin:0;padding:0;width:100%;height:100%;display:none;'></div>");
            $('#TB_window').append(resizableOverlay);

            $('#TB_window')
                .resizable({
                    //alsoResize: "#TB_iframeContent",
                    animate: params["noanimate"] != "true",
                    helper: "ui-resizable-helper",
                    start: function () {
                        resizableOverlay.show();
                    },
                    stop: function (event, ui) {
                        var el = ui.element;
                        var hlp = ui.helper;

                        var h = hlp.height();
                        var w = hlp.width();

                        var old_h = el.height();
                        var old_w = el.width();

                        var fr = $('#TB_iframeContent,#TB_ajaxContent', ui.element);

                        fr.height(fr.height() + h - old_h - 8);
                        fr.width(fr.width() + w - old_w - 8);
                        // откуда цифра 8 я не знаю, но именно на столько рамка больше окна
                        // может быть ее можно взять из настроек jQuery-UI-resizable...

                        resizableOverlay.hide();
                    }
                });
        } else {
            $('#TB_window').addClass('TB_noresize');
        }
        $('#TB_title').css('cursor', 'move');
    } catch (e) {
        // Hier soll nichts passieren, zum Debuggen könnte ein Alert eingebunden werden
        // Hitler Kaput! :)
    }

    //Хаберев: Возвращаем проекцию Deffered-объекта для возможности добавлять асинхронные обработчики в дркгих скриптах
    //return tb_CloseActionDeferred.promise();
}

//helper functions below
function tb_showIframe() {
    $("body").addClass("modal-open").attr("scroll", "no");
    $("#TB_load").remove();
    $("#TB_window").css({ display: "block" });
}

function tb_remove() {
    $("#TB_imageOff").unbind("click");
    $("#TB_closeWindowButton").unbind("click");

    // Первый вариант - исходный, с ними были проблемы в работе MasterEditorAjaxLookup: при выборе элемента
    // thickbox закрывался, но основная форма оставалась неактивной.
    // Второй вариант - нормально функционирует MasterEditorAjaxLookup, но inline thickbox перестал работать,
    // т.к. не выполнялся обработчик  $("#TB_window").unload(...)
    // В третьем варианте исправлены предыдущие ошики введением пространства имен события.

    //$("#TB_window").fadeOut("fast", function () { $('#TB_window,#TB_overlay,#TB_HideSelect').trigger('unload').unbind().remove(); });
    //$("#TB_window").fadeOut("fast", function () { $('#TB_window,#TB_overlay,#TB_HideSelect').unload("#TB_ajaxContent").unbind().remove(); });

    // Убрана анимация скрытия, так как из-за неё блокировался MasterEditorAjaxLookUp в IE.
    $('#TB_window,#TB_overlay,#TB_HideSelect').trigger('unload.tb').unbind().remove();

    $("body").removeClass("modal-open").css("overflow", "").removeAttr('scroll');

    $("#TB_load").remove();
    if (typeof document.body.style.maxHeight == "undefined") {//if IE 6
        $("body", "html").css({ height: "auto", width: "auto" });
        $("html").css("overflow", "");
    }

    //Хаберев: переводим Deffered-объект в состояние "выполнено", чтобы сработали обработчики событий в других скриптах
    //tb_CloseActionDeferred.resolve();
    return false;
}

function tb_position() {
    $("#TB_window").css({ marginLeft: '-' + parseInt((TB_WIDTH / 2), 10) + 'px', width: TB_WIDTH + 'px' });
    if (!(jQuery.browser.msie && jQuery.browser.version < 7)) { // take away IE6
        $("#TB_window").css({ marginTop: '-' + parseInt((TB_HEIGHT / 2), 10) + 'px' });
    }
}

function tb_parseQuery(query) {
    var Params = {};
    if (!query) { return Params; } // return empty object
    var Pairs = query.split(/[;&]/);
    for (var i = 0; i < Pairs.length; i++) {
        var KeyVal = Pairs[i].split('=');
        if (!KeyVal || KeyVal.length != 2) { continue; }
        var key = unescape(KeyVal[0]);
        var val = unescape(KeyVal[1]);
        val = val.replace(/\+/g, ' ');
        Params[key] = val;
    }
    return Params;
}

function tb_getPageSize() {
    var de = document.documentElement;
    var w = window.innerWidth || self.innerWidth || (de && de.clientWidth) || document.body.clientWidth;
    var h = window.innerHeight || self.innerHeight || (de && de.clientHeight) || document.body.clientHeight;
    arrayPageSize = [w, h];
    return arrayPageSize;
}

function tb_detectMacXFF() {
    var userAgent = navigator.userAgent.toLowerCase();
    if (userAgent.indexOf('mac') != -1 && userAgent.indexOf('firefox') != -1) {
        return true;
    }
}
