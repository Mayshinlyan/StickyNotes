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
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    $(".active").removeClass("active");
    var board = document.getElementById("board");
    board.insertAdjacentHTML('beforeend', message);
    var input = message.lastChild;
    input.addEventListener("input", function (event) {
        var user = document.getElementById("user").value;
        var message = document.getElementById("inputText").value;
        connection.invoke("SendMessage", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });
});

// receiving the stickynotes position
connection.on('ShapeMoved', function (x, y) {
    console.log("shaped moved");
    $('.active').css({ left: x, top: y });
    $('.active')
});

// receiving the new z-index
connection.on('MovedUp', function (z, id) {
    var e = document.getElementById(id);
    e.style.zIndex = z;
    $(".active").removeClass("active");
    $('#' + id).addClass('active');
    var input = e.lastChild;
   
   
});

//var user = document.getElementById("user").value;
//// sending the text inside the note
//document.getElementById("inputText").addEventListener("input", function (event) {
//    var user = document.getElementById("user").value;
//    var message = document.getElementById("inputText").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});


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

        $(document).trigger('noteCreated');

    });
});


//moves the clicked stickynote up to the top.
function moveUp(id) {
    console.log("moveup");
    max = findHighestZIndex('div');
   
    connection.invoke("MovedUp", max, id|| 0)
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


// drag the element and invoke MoveShape
$(document).ready(function () {
    var $dragging = null;
   
    $('#board').on("mousemove", function (e) {

        if ($dragging) {
            if (e.pageY > (window.innerHeight - 202)) { e.pageY = window.innerHeight - 202; }
            if (e.pageX > (window.innerWidth - 202)) { e.pageX = window.innerWidth - 202; }

            $dragging.offset({
                top: e.pageY,
                left: e.pageX
            });

            connection.invoke("MoveShape", $dragging.offset().left, $dragging.offset().top || 0)
        }

       
    
     });

    $('#board').on("mousedown", '.active', function (e) {
        $dragging = $(e.target.parentElement);
    });

    $('#board').on("mouseup", function (e) {
        $dragging = null;
    });
});

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













