$(document).ready(function () {
    $('.businessTimeSpans').TimeSpans("init", $('#wtsJson').val());
})
$(document).submit(function () {
    var tsArray = JSON.stringify($('.businessTimeSpans').TimeSpans("getTimeSpans"));
    document.getElementById("wtsJson").value = tsArray;
})