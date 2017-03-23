var players = [ { id: 1, name: "Player_1" },
                { id: 2, name: "Player_2" },
                { id: 3, name: "Player_3" },
                { id: 4, name: "Player_4" },
                { id: 5, name: "Player_5" },
                { id: 6, name: "Player_6" },
                { id: 7, name: "Player_7" },
                { id: 8, name: "Player_8" }];
var matches = [];

function fillDDL(ddl) {
    var dropdown = document.getElementById(ddl);

    for (var i = 0; i < players.length; i++) {
        dropdown[dropdown.length] = new Option(players[i].name, players[i].id);
    }
}

function writeScalevalue() {
    var scaleVal = $('#WinnerRounds')[0].value;
    $('#rangeValue')[0].innerHTML = scaleVal;
}

function checkPlayers() {
    var result = true;
    var PlayerA = $("#Player_List_A")[0];
    var PlayerB = $("#Player_List_B")[0];
    if (PlayerA.selectedIndex === PlayerB.selectedIndex) {
     result = false;
    }
    return result;
}


function createMatch() {
    var roundCount = $("#WinnerRounds").val();
  //  if (validate()) {
        createround(roundCount);
        createAddRounfd();
       createSaveMatch();
        blockall();
    //}
}

function createround(roundCount) {
    //var roundCount = $("#WinnerRounds").val();
    var root = $('#RoundsInfo');
    var optionCount = $("#maxScore").find(':selected').text();

    var divPlayerA = $("#divPlayerA");
    var divPlayerB = $("#divPlayerB");

    for (var i = 0; i < roundCount; i++) {
        var currentIndex = divPlayerA.children().length;
        divPlayerA.append(createSelect(1,currentIndex, optionCount));
        divPlayerB.append(createSelect(2,currentIndex, optionCount));
    }
}

function createSelect(player,currentRound,optionCount) {
   var dropdown = document.createElement("select");
   dropdown.id = "round_" + player+"_"+currentRound;
   dropdown.oninput=function (){checkRoundsResults(this);}
   for (var i = 1; i < Number(optionCount) + 2; i++) {
        dropdown[dropdown.length] = new Option(i, i);
    }
    return dropdown;
}

function createAddRounfd() {
    var butt = document.createElement("input");
    butt.id = "roundADD";
    butt.type = "button";
    butt.value = "Добавить раунд";
    butt.onclick = function() { createround("1") };
    $('#RoundsInfo').append(butt);
}

function checkRoundsResults(sender) {
    var anotherPlayer = getOtherPlayerScore(sender);
    if (sender.selectedIndex === 11)
        anotherPlayer.selectedIndex = 9;

    if (sender.selectedIndex === 10 && anotherPlayer.selectedIndex > 8)
        {alert("Warning!! enemy is dead, but he is near you!");}
    if (sender.selectedIndex >8 && anotherPlayer.selectedIndex === 10)
    { alert("Warning!! You are loose already!"); }
}

function getOtherPlayerScore(sender) {
    var otherPlayerId = "#" + sender.id.substr(0, 6);
    if (sender.parentElement.id === "divPlayerA") {
        otherPlayerId += "2";
    } else {
        otherPlayerId += "1";
    }
    otherPlayerId += sender.id.substr(7);

    return $(otherPlayerId)[0];
}
function createSaveMatch() {
    var butt = document.createElement("input");
    butt.id = "saveMatch";
    butt.type = "button";
    butt.value = "Сохранить результаты";
    butt.onclick = function () { saveMatch() };
    $('#RoundsInfo').append(butt);
}
function saveMatch() {
    var playA = $("#Player_List_A").find(':selected').text();
    var playB = $("#Player_List_B").find(':selected').text();
    var dateM = $("#matchTime").value;
    var match = {
        nameA: playA,
        nameB: playB,
        date:dateM
    }
    matches.push(match);
    showMatch(match);
}

function showMatch(match) {
    var row1 = document.createElement("tr");
    var row2 = document.createElement("tr");
    var itemNameA = document.createElement("td");
    itemNameA.text = match.nameA;
    itemNameA.rowSpan = 2;
    
    var itemNameB = document.createElement("td");
    itemNameB.text = match.nameB;
    itemNameB.rowSpan = 2;
    var itemDate = document.createElement("td");
    itemDate.text = match.date;
    itemDate.rowSpan = 2;
    var itemRes = document.createElement("td");
    itemRes.text = "common res";
    var itemResALL = document.createElement("td");
    itemResALL.text = "rounds res";
    row1.append(itemNameA, itemNameB, itemDate, itemRes);
    row2.append(itemResALL);
    $("#match-list-res").append(row1, row2);
}
function blockall() {
    $("#Player_List_A").prop("disabled", true);
    $("#Player_List_B").prop("disabled", true);
    $("#matchTime").prop("disabled", true);
    $("#maxScore").prop("disabled", true);
    $("#WinnerRounds").prop("disabled", true);
    $("#WinnerRoundsScale").prop("disabled", true);
    $("#GameFactor").prop("disabled", true);
    $("#MatchCreate").prop("disabled", true);

    //$("panel-info").each(function () {
    //    $(this).prop("disabled", true);
    //});
}
function validate() {

    return checkPlayers();
}