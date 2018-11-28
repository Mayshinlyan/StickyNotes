"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/noteHub").build();

// receiving the text inside the note
connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var input = document.getElementById("inputText");
    input.value = msg;
});

// receiving the stickynotes creation
connection.on("ReceiveNote", function (message) {
    console.log(message);
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var board = document.getElementById("board");
    board.insertAdjacentHTML('beforeend', message);
});

// receiving the stickynotes position
connection.on('ShapeMoved', function (x, y) {
    console.log("shaped moved");
    $('.active').css({ left: x, top: y });
});


// creating sticky notes on click
$("#login").click(function () {
    $(".modal").slideToggle("slow");
});

var max = 5;
var autoID = 0;

var board = document.getElementById('board');
$(function () {
    //creates stickynote when you click on the board
    $("#board").click(function (e) {
        if ($(e.target).is("header")) return;
        if ($(e.target).is("textarea")) return;
        if ($(e.target).is("div")) return;
        if ($(e.target).is("h1")) return;
        autoID = autoID + 1;
        max = findHighestZIndex('div');
        if (e.pageY > (window.innerHeight - 202)) { e.pageY = window.innerHeight - 202; }
        if (e.pageX > (window.innerWidth - 202)) { e.pageX = window.innerWidth - 202; }
        $(".active").removeClass("active");
        var div = $('<div class="image-wrapper ui-draggable ui-draggable-handle stickynote active" id="' + autoID + '" style="z-index : ' + max + '">')
            .css({
                "left": e.pageX + 'px',
                "top": e.pageY + 'px'
            })
            .append($('<header class="ui-widget-content ui-draggable"></header><textarea class="stickyForm" id="inputText" onclick="moveUp(' + autoID + ')"></textarea></div>'))
            .appendTo(this);
        //$( "div" ).draggable({handle:"header", containment:"#board",stack:"div"});
        $('.active').draggable({
            drag: function () {
                console.log('dragging');
                connection.invoke("MoveShape", this.offsetLeft, this.offsetTop || 0);
            }
        });

        $(document).trigger('noteCreated');

    });
});


//moves the clicked stickynote up to the top.
function moveUp(id) {
    console.log("moveup");
    max = findHighestZIndex('div');
    document.getElementById(id).style.zIndex = max;
    $(".active").removeClass("active");
    $('#' + id).addClass('active');
}

//finds the highest z index (duh)
function findHighestZIndex(element) {
    var selectedElements = document.getElementsByTagName(element);
    var highest = 0;
    for (var i = 0; i < selectedElements.length; i++) {
        var zindex = parseInt(document.defaultView.getComputedStyle(selectedElements[i], null).getPropertyValue("z-index"), 10);
        if ((zindex > highest) && (zindex != 'auto')) {
            highest = zindex;
        }
    }
    return highest + 1;
}



connection.start().catch(function (err) {
    console.log("heyyyyyy")
    return console.error(err.toString());
});


// sending the note creation
$(document).on('noteCreated', function () {
    // alert('noteCreated');
    var note = document.getElementsByClassName('active');
    var message = note[0].outerHTML;
    //console.log(message);
    connection.invoke('SendNoteCreated', message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});


// sending the text inside the note
document.getElementById("inputText").addEventListener("input", function (event) {
    var user = document.getElementById("user").value;
    var message = document.getElementById("inputText").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});


var user = document.getElementById("user").value;
// syncing the note itself

//function syncNote() {
//    var mutationObserver = new MutationObserver(function (mutations) {
//        mutations.forEach(function (mutation) {
//            console.log(mutation.target.outerHTML);
//            var message = mutation.target.outerHTML;
//            connection.invoke("SyncBoard", user, message).catch(function (err) {
//                return console.error(err.toString());
//            });
//            mutationObserver.disconnect();
//            event.preventDefault();
//        });
//    });

//    mutationObserver.observe(document.getElementById("board"), {
//        childList: true,
//        subtree: true
//    });

//    // Takes all changes which haven’t been fired so far.
//    var changes = mutationObserver.takeRecords();

//}

//document.getElementById("board").addEventListener("click", function () {
//    syncNote();
//})






//document.getElementById("board").addEventListener("DOMNodeInserted", function (event) {
//    var user = document.getElementById("user").value;
//    var board = document.getElementById('board');
//    var message = board.innerHTML;
//    console.log(message);
//    connection.invoke("SyncBoard", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
    
//    event.preventDefault();
    
//});








