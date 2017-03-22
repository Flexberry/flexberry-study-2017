$(document).ready(function () {
    $('.businessTimeSpans').TimeSpans("init", $('#wtsJson').val());
    
})
function saveJsonArray() {
    var tsArray = JSON.stringify($('.businessTimeSpans').TimeSpans("getTimeSpans"));
    document.getElementById("wtsJson").value = tsArray;
}