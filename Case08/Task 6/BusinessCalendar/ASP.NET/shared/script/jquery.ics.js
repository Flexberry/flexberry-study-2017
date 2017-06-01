/**
 * Плагин jQuery общего JS API.
 *
 * Внимание! Любые изменения в этом коде являются грубым нарушением
 * конвенции о взаимодействии с технологическим отделом.
 * Если у вас возникает необходимость в изменении или доработках,
 * обращайтесь в технологический отдел согласно правилам:
 * http://storm:2010/page/TechnoAlgorythm.aspx
 * Все несанкционированные изменения будут удалены
 * при очередном обновлении технологического слоя.
 *
 * @copyright Copyright (c) IIS. All rights reserved.
 */

; (function ($, window, document, undefined) {

    /*
     * Функция парсинга параметров.
     */
    function parseQuery(query) {
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

    // 'use strict'; __doPostBack в FF не работает
    $.ics = $.extend($.ics, {
        // Диалоговые окна.
        dialog: {
            /**
             * Диалоговое окно для потверждения или отмены действия (YES / NO / Cancel)
             * 
             * Для работы метода необходим jQueryUI. Используется метод $.dialog.
             *
             * @params {object} options Парметры метода.
             * @params {object} options.title Заголовок окна.
             * @params {object} options.callback Обработчик результата. В качестве параметра принимает строку со значениями: YES, NO, Cancel.
             * @params {object} options.yesButtonText Наименование первой кнопки.
             * @params {object} options.noButtonText Наименование второй кнопки.
             * @params {object} options.cancelButtonText Наименование третьей кнопки.
             */
            dialog: function (options) {
                options = $.extend({
                    title: '',
                    callback: undefined,
                    yesButtonText: $.ics.configuration.dialog.yesButtonText,
                    noButtonText: $.ics.configuration.dialog.noButtonText,
                    cancelButtonText: $.ics.configuration.dialog.cancelButtonText
                }, options);

                var buttons = {};
                buttons[options.yesButtonText] = function () {
                    dialog.dialog('close');
                    options.callback('YES');
                };
                buttons[options.noButtonText] = function () {
                    dialog.dialog('close');
                    options.callback('NO');
                };
                buttons[options.cancelButtonText] = function () {
                    dialog.dialog('close');
                    options.callback('Cancel');
                };

                var dialog = $('<p>' + options.title + '</p>').dialog({ buttons: buttons });
            },

            /**
             * Метод для отображения окна подтверждения действия (OK / Cancel).
             *
             * Метод является асинхронным. Для проверки результата действия пользователя
             * нужно устаналивать callback.
             *
             * Для поддержки всех функцинальных возможностей должен быть подключен плагин
             * "jQuery.alerts". Если плагин не подключен то будут использованы встроенные
             * возможности браузера с урезанной функциональностью.
             *
             * @param options Параметры окна: текст сообщения, заголовок окна, функция обратного вызова, подписи кнопок.
             */
            confirm: function (options) {
                options = $.extend({
                    message: '',
                    title: '',
                    callback: undefined,
                    okButtonText: $.ics.configuration.dialog.okButtonText,
                    cancelButtonText: $.ics.configuration.dialog.cancelButtonText
                }, options);

                if ($.ics.pluginExists('alerts') && window.jConfirm) {
                    var oldOkButton = $.alerts.okButton, oldCancelButton = $.alerts.cancelButton;

                    $.alerts.okButton = options.okButtonText;
                    $.alerts.cancelButton = options.cancelButtonText;

                    window.jConfirm(options.message, options.title, options.callback);

                    $.alerts.okButton = oldOkButton;
                    $.alerts.cancelButton = oldCancelButton;
                } else {
                    $.ics.console.log('Плагин jQuery.alerts не подключен. Используются встроенные возможности браузера.');
                    setTimeout(function () {
                        var answer = window.confirm(options.message);
                        if ($.isFunction(options.callback)) {
                            options.callback(answer);
                        }
                    }, 0);
                }
            },

            /**
             * Метод для отображения информационного окна с произвольным содержимым.
             *
             * Метод является асинхронным. Для обработки события закрытия окна пользователем
             * нужно устаналивать callback.
             *
             * Для поддержки всех функцинальных возможностей должен быть подключен плагин
             * "jQuery.alerts". Если плагин не подключен то будут использованы встроенные
             * возможности браузера с урезанной функциональностью.
             *
             * @param {Object|string} options Текст сообщения или объект с расширенными параметрами окна: текст сообщение, заголовок окна, функция обратного вызова.
             */
            alert: function (options) {
                if (typeof options == 'string' || options instanceof String) {
                    options = { message: options };
                } else {
                    options = $.extend({
                        message: undefined,
                        title: undefined,
                        callback: undefined
                    }, options);
                }

                if ($.ics.pluginExists('alerts') && window.jAlert) {
                    window.jAlert(options.message || '', options.title || '', options.callback);
                } else {
                    $.ics.console.log('Плагин jQuery.alerts не подключен. Используются встроенные возможности браузера.');
                    setTimeout(function () {
                        window.alert(options.message || '');
                        if ($.isFunction(options.callback)) {
                            options.callback();
                        }
                    }, 0);
                }
            },

            /**
             * Метод для отображения модального окна с произвольным содержимым.
             *
             * Метод является асинхронным. Для обработки события закрытия окна пользователем
             * нужно устаналивать callback.
             *
             * Для работы метода необходим jQueryUI. Используется метод $.dialog.
             *
             * @param options Параметры окна.
             * @returns {Object|undefined} Объект для управления модальным окном.
             */
            modal: function (options) {
                options = $.extend({
                    href: undefined,
                    content: undefined,
                    inlineId: undefined,
                    title: undefined,
                    width: $.ics.configuration.dialog.width,
                    height: $.ics.configuration.dialog.height,
                    callback: undefined,
                    autoOpen: false,
                    modal: true,
                    resizable: true,
                    minWidth: 250,
                    minHeight: 250,
                    closeText: "Закрыть",
                    onClose: undefined,
                    closeOnEscape: true
                }, options);

                var modalContent = $("<div class='ics-modal-content'></div>")
                var def = $.Deferred();

                if (options.href) {
                    var url = options.href;
                    var queryString = url.replace(/^[^\?]+\??/, '');
                    var params = parseQuery(queryString);

                    options = $.extend(options, params);
                    // Передать заголовок формы, открывающийся по лукапу.
                    if (options.FormCaption !== undefined) options.title = options.FormCaption;

                    var iframe = $("<iframe class='ics-modal-iframe' frameborder='0' marginwidth='0' marginheight='0' allowfullscreen></iframe>");
                    modalContent.append(iframe).appendTo("body");
                    iframe.attr("src", options.href);
                } else if (options.inlineId) {
                    modalContent.append($('#' + options.inlineId)).appendTo('body');
                    // Отобразить содержимого блока.
                    modalContent.children().show();
                } else {
                    var uniqueId = $.ics.generateUniqueId('ics_dialog_modal_');
                    modalContent.html(options.content || '').attr('id', uniqueId).appendTo('body');
                }

                var $dialog = modalContent.dialog(options, {
                    open: function () {
                        $('body').addClass('modal-open').attr('scroll', 'no');
                        modalContent.show();
                        return def.promise();
                    },
                    close: function () {
                        $('body').removeClass('modal-open').removeAttr('scroll');
                        if (options.inlineId) {
                            modalContent.children().appendTo('body').hide();
                        };
                        $('.ics-modal, .ics-modal-content, .ui-widget-overlay').remove();
                        if (options.onClose) options.onClose();
                        def.resolve();
                    },
                    dialogClass: 'ics-modal',
                    drag: function (event, ui) {
                        // Функция необходима, когда скролл страницы не на нулевой позиции.
                        var fixPix = $(document).scrollTop();
                        iObj = ui.position;
                        if (iObj.top !== ui.offset.top) {
                            iObj.top = iObj.top - fixPix;
                        }
                        ui.position = iObj;
                    }
                });

                $dialog.dialog('open');

                // Удалить кнопку закрытия окна.
                if (options.modal === true) {
                    $dialog.parent().find('.ui-dialog-titlebar-close').remove();
                }
                else { // Вставка затемненого фона, т.к. jQuery при modal=false не вставляет в DOM ui-widget-overlay.
                    var overlay = "<div class='ui-widget-overlay ui-front'></div>";
                    $dialog.closest('body').append(overlay);
                }


                // Основной обработчик, уничтожает все созданные элементы и восстанавливает переопределённые функции.
                var newRemove = function (args) {
                    // Вызов пользовательского обработчика закрытия окна c возможностью отмены.
                    var callbackResult = { cancel: false, deferreds: [], args: args };
                    if ($.isFunction(options.callback)) {
                        options.callback(callbackResult);
                    }

                    // Ожидание завершения всех пользовательских асинхронных операций.
                    $.when.apply(null, callbackResult.deferreds).then(function () {
                        if (!callbackResult.cancel) {
                            if (ret) {
                                ret.closed = true;
                            }
                            var parentWindow = window.opener || window.parent || window.top;
                            parentWindow.$('.ics-modal-content').dialog('close');
                        }
                    });
                };

                // В возвращаемом объекте хранится флаг закрытого окна, проставляемый автоматически в обработчике закрытия.
                var ret = {
                    close: function (args) {
                        if (!ret.closed) {
                            newRemove(args);
                        }
                    },
                    closed: false,
                    context: options.href
                        ? document.getElementsByClassName('ics-modal-iframe').contentWindow
                        : window
                };

                return ret;
            }
        },

        // Консоль.
        console: {
            /**
             * Метод для записи в лог.
             *
             * @param {*} [args] Произвольные данные, записываемые в лог.
             */
            log: function (args) {
                if (!$.ics.configuration.debug) {
                    return;
                }

                try {
                    if ('console' in window) {
                        window.console.log.apply(window.console, arguments);
                    }
                } catch (e) {
                }
            },

            /**
             * Метод для записи в консоль ошибок.
             *
             * @param {*} [args] Произвольные данные, записываемые в лог ошибок.
             */
            error: function (args) {
                if (!$.ics.configuration.debug) {
                    return;
                }

                try {
                    if ('console' in window) {
                        window.console.error.apply(window.console, arguments);
                    }
                } catch (e) {
                }
            }
        },

        // Параметры конфигурации.
        configuration: {
            debug: true,
            dialog: {
                okButtonText: 'OK',
                yesButtonText: 'YES',
                noButtonText: 'NO',
                cancelButtonText: 'Cancel',
                width: 400,
                height: 300
            }
        },

        /**
         * Метод запуска постбэка с указанными параметрами.
         *
         * @param {String} sourceId Идентификатор элемента-инициатора события.
         * @param {String} args     Дополнительные параметры события.
         * @returns {void}
         */
        // ToDo: Подумать как сделать все 'use strict' и __doPostBack в FF не падал бы
        postBack: function (sourceId, args) {
            window.__doPostBack(sourceId, args);
        },

        /**
         * Функция для перехода на указанный URL.
         *
         * @param {String} url Адрес для перехода.
         * @returns {void}
         */
        navigate: function (url) {
            document.location.href = url;
        },

        /**
         * Функция для проверки наличия подключенного плагина jQuery.
         *
         * @param {String} pluginName Наименование плагина.
         * @returns {Boolean}
         */
        pluginExists: function (pluginName) {
            // Плагины могуть быть не в fn, например, alerts.
            return !!$.fn[pluginName] || !!$[pluginName];
        },

        /**
        * Функция для запуска обработчиков указанного события с поддержкой
        * асинхронности и отмены действий.
        *
        * @param {jQuery}   $target   Объект, у которого нужно вызвать событие.
        * @param {String}   eventName Наименование события.
        * @param {Object}   data      Дополнительные данные, передаваемые в обработчики.
        * @param {Function} callback  Функция обратного вызова, если событие не было отменено.
        */
        triggerEvent: function ($target, eventName, data, callback) {
            var eventData = { stop: false, deferreds: [], data: data },
                event = $.Event(eventName);

            $target.trigger(event, eventData);

            $.when.apply(null, eventData.deferreds).then(function () {
                if (!event.isDefaultPrevented() && !eventData.stop) {
                    callback();
                }
            });
        },

        /**
         * Функция для генерации уникального идентификатор элемента с заданным префиксом.
         * Не гарантируется никакой последовательности в генерируемых идентификаторах.
         * 
         * @param {String} prefix Префикс для генерируемого идентификатора.
         * @returns {String}
         */
        generateUniqueId: function (prefix) {
            prefix = !prefix ? '' : prefix.toString();
            var id = 0;
            do {
                // Случайное число добавлено для уменьшения риска коллизии, если функция будет вызвана до 
                // полной инициализации DOM.
                var uniqueId = prefix + id.toString() + Math.floor(Math.random() * 100000).toString();
                if (!document.getElementById(uniqueId)) {
                    return uniqueId;
                }
                id++;
            } while (true);
        }
    });
})(jQuery, window, document);