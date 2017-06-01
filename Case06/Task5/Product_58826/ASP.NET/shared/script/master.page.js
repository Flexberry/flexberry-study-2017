$(document).ready(function () {
    //привязываем календарь
    $('.datepicker:enabled').datepicker({ changeMonth: true, changeYear: true });
    //привязываем фильтр вводимых значений (календарь сам не ограничивает ввод)
    $(".datepicker").mask("99.99.9999");
    $(".datepicker_readonly").mask("99.99.9999");
    $('.datepicker').keypress(function () {
        $('.datepicker').datepicker('hide');
    });

    var textareas = $('textarea[class*="maxlength-"]');
    $.each(textareas, function (i, textarea) {
        var classList = $(textarea).attr('class').split(/\s+/);
        $.each(classList, function (index, item) {
            if (item.indexOf('maxlength-') == 0) {
                var l = item.toString().substring('maxlength-'.length, item.length);

                // Можно включить отображение количества символов и всякие красивости
                // но это правится на конкретном прикладном проекте
                $(textarea).maxlength({ maxCharacters: l, status: false, events: ['change'] });
            }
        });
    });

    $(".info_area").each(function (index, info_area) {
        var elCollapsable = $(".collapsable", $(info_area));
        var elExpandCollapseButton = $(".expand_btn, .collapse_btn", $(info_area));

        var expanded = $(info_area).hasClass("expanded");

        if (expanded) {
            Expand2CollapseBtnAndViceVersa(elExpandCollapseButton);
        }
        else {
            elCollapsable.hide();
        }

        elExpandCollapseButton.click(function () {
            Expand2CollapseBtnAndViceVersa($(this));
            elCollapsable.slideToggle("fast");

            return false;
        });
    });

    // Установить минимальную высоту Treeview.
    $(window).trigger('resize');
    setHeightPageBlockTreeview();

    // Открытие в модальном окне.
    $('.ics-open-in-modal').on('click', function (e) {
        e.preventDefault();
        openInModal($(this));
    });
});

$(window).on('resize', function () {
    setHeightPageBlockTreeview();
}).trigger('resize');



function ShowHideNavigate() {
    'use strict';
    var $pageForm = $('.page-form');
    var treeView = $pageForm.hasClass('treeview-visible');

    if (treeView) {
        $pageForm.removeClass('treeview-visible');
        $pageForm.addClass('treeview-hidden');
        $('#treeviewHideSpan').addClass('Hide');
        $('#treeviewShowSpan').removeClass('Hide');

        $.cookie('treeView', '0', { path: '/' });
        $('.v_border').addClass('Hide');
    } else {
        $pageForm.addClass('treeview-visible');
        $pageForm.removeClass('treeview-hidden');
        $('#treeviewHideSpan').removeClass('Hide');
        $('#treeviewShowSpan').addClass('Hide');

        $('#masterPageContentBlock').addClass('treeview-visible');
        $.cookie('treeView', '1', { path: '/' });
        $('.v_border').removeClass('Hide');
    }

    $(window).trigger('scroll');
    $(window).trigger('pageBlockTreeview-toggle');
}

/**
 * Блокировка Ajax лукапа.
 * 
 * @deprecated Следует использовтаь jQuery.icsMasterEditorAjaxLookup('block')
 */
function BlockAjaxLookUp(nameValueControl) {
    $.ics.console.error('Method BlockAjaxLookUp is obsolete! Use jquery.icsMasterEditorAjaxLookup instead.');
    $('#' + nameValueControl).icsMasterEditorAjaxLookup('block');
}

/**
 * Разблокировка Ajax лукапа.
 *
 * @deprecated Следует использовтаь jQuery.icsMasterEditorAjaxLookup('unblock')
 */
function UnBlockAjaxLookUp(nameValueControl) {
    $.ics.console.error('Method UnBlockAjaxLookUp is obsolete! Use jquery.icsMasterEditorAjaxLookup instead.');
    $('#' + nameValueControl).icsMasterEditorAjaxLookup('unblock');
}

/**
 * Установка минимальной высоты дерева навигации.
 */
function setHeightPageBlockTreeview() {

    var windowHeight = $(window).height();
    var $treeview = $('#pageBlockTreeview');
    var topHeight = $treeview.offset().top;
    var $footerPage = $('.page-footer');
    var footerHeight = $footerPage.is(":visible") ? $footerPage.outerHeight() : 0;

    $treeview.css('min-height', windowHeight - topHeight - footerHeight);
}

/**
 * Обработка события открытия в модальном окне.
 *
 * @param {jQuery} element 
 */
function openInModal(element) {
    var $element = $(element)[0];
    var _title = $element.rel || $element.title || $element.name || null;
    var _pageUrl = $element.href || $element.alt || $element.abbr;
    $.ics.editFormModalWindow = $.ics.dialog.modal({
        title: _title,
        href: _pageUrl,
        modal: false
    });
    return false;
}
