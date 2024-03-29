﻿"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/NoteHub").build();

// receiving the text inside the note
connection.on("ReceiveMessage", function (user, message, id) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var input = document.getElementById(id).lastChild;
    input.value = msg;
});

// receiving the stickynotes creation
connection.on("ReceiveNote", function (message) {
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    $(".active").removeClass("active");
    var board = document.getElementById("board");
    board.insertAdjacentHTML('beforeend', message);
    var input = message.lastChild;
    
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
    var input = document.getElementById(id);
    console.log(input);
    input.addEventListener("input", function (event) {
        var user = document.getElementById("user").value;
        var message = input.lastChild.value;
        console.log(message);
        connection.invoke("SendMessage", user, message, id).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });
   
});

//var user = document.getElementById("user").value;
// sending the text inside the note
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
        let apiPath = "https://localhost:44363/api/notes/"
        let boardId = 1;
        if ($(e.target).is("header")) return;
        if ($(e.target).is("textarea")) return;
        if ($(e.target).is("div")) return;
        if ($(e.target).is("h1")) return;
        let note = { ycoor: e.pageY, xcoor: e.pageX, boardId: boardId };
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            console.log(this.readyState);
            console.log(this.status);
            if (this.readyState == 4 && this.status >= 200 && this.status < 300) {                
                let note = JSON.parse(xhttp.responseText);
                console.log(note);
                createNoteFromJSON(note);
                $(document).trigger('noteCreated');
            }
        }        
        xhttp.open("POST", apiPath, true);
        xhttp.setRequestHeader("Content-Type", "application/json");
        xhttp.send(JSON.stringify(note));        
        /* autoID = autoID + 1;
        max = findHighestZIndex('div');
        if (e.pageY > (window.innerHeight - 202)) { e.pageY = window.innerHeight - 202; }
        if (e.pageX > (window.innerWidth - 202)) { e.pageX = window.innerWidth - 202; }
        $(".active").removeClass("active");
        var div = $('<div class="image-wrapper ui-draggable-handle stickynote active" id="' + autoID + '" style="z-index : ' + max + '">')
            .css({
                "left": e.pageX + 'px',
                "top": e.pageY + 'px'
            })
            .append($('<header class="ui-widget-content ui-draggable"></header><textarea class="stickyForm" id="inputText" onclick="moveUp(' + autoID + ')"></textarea></div>'))
            .appendTo(this); */

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

//finds the highest id
//function findHighestId() {
//    var selectedElements = document.getElementsByClassName('.stickynote');
//    console.log(selectedElements);
//    var highest = 0;
//    for (var i = 0; i < selectedElements.length; i++) {
//        var id = parseInt(document.defaultView.getComputedStyle(selectedElements[i], null).getPropertyValue("id"), 10);
//        if ((id > highest) && (id != 'auto')) {
//            highest = id;
//        }
//    }
//    return highest;
//}


// drag the element and invoke MoveShape
$(document).ready(function () {
    var $dragging = null;
   
    $('#board').on("mousemove", function (e) {
        if ($dragging) {
        
            if (e.pageY > (window.innerHeight - 202)) { e.pageY = window.innerHeight - 202; }
            if (e.pageX > (window.innerWidth - 202)) { e.pageX = window.innerWidth - 202; }
            //if ((e.pageX > left))
            y = e.pageY;
            x = e.pageX;
            $dragging.offset({
                top: e.pageY,
                left: e.pageX
            });
            Console.log($dragging);
            connection.invoke("MoveShape", $dragging.offset().left, $dragging.offset().top || 0)
        }

     });

    $('#board').on("mousedown", '.active', function (e) {
       
        $dragging = $(e.target.parentElement);

        var left = $dragging[0].style.left;
        left = parseInt(left.replace(/px/g, ""));
        var top = $dragging[0].style.top;
        top = parseInt(top.replace(/px/g, ""));
       // console.log(left, top);

        console.log(e.pageX, left);
        console.log(e.pageY, top);
       
        if ((e.pageX > left && e.pageX < left + 202) && (e.pageY > top + 20 && e.pageY < top + 202)) {
            console.log();
            $dragging = null;
        }
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

function updateDb(id) {
    var api = "https://localhost:44363/api/Notes/" + id;
    var xhttp = new XMLHttpRequest();
    var boardId = 1;
    var elem = document.getElementById(id);
    console.log(elem);
    var x = $(elem).css("left");
    var y = $(elem).css("top");
    x = x.substring(0, x.length - 2);
    y = y.substring(0, y.length - 2);
    console.log(x);
    console.log(y);
    var note = { noteId: id, body: elem.lastChild.value, xcoor: x, ycoor: y, boardId: boardId }
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status >= 200 && this.status < 300) {
            console.log("Done???");
        }
    };
    xhttp.open("PUT", api);
    xhttp.setRequestHeader("Content-Type", "application/json");
    xhttp.send(JSON.stringify(note));       
}

function createNoteFromJSON(note) {
    autoID = autoID + 1;
    max = findHighestZIndex('div');
    if (note.y > (window.innerHeight - 202)) { note.y = window.innerHeight - 202; }
    if (note.x > (window.innerWidth - 202)) { note.x = window.innerWidth - 202; }

    $(".active").removeClass("active");
    var div = $('<div class="image-wrapper stickynote" id="' + note.noteId + '" style="z-index : ' + max + '">')
        .css({
            "left": note.xcoor + 'px',
            "top": note.ycoor + 'px'
        })
        .append($('<header class="ui-widget-content"></header><textarea class="stickyForm" id="inputText" onclick="moveUp(' + note.noteId + ')" onfocusout="updateDb(' + note.noteId + ')"></textarea></div>'))
        .appendTo(document.body);
    $("div").draggable({ handle: "header", containment: "#board", stack: "div" }); 


    /* $(".active").removeClass("active");
    var div = $('<div class="image-wrapper ui-draggable-handle stickynote active" id="' + note.noteId + '" style="z-index : ' + max + '">')
        .css({
            "left": note.xcoor + 'px',
            "top": note.ycoor + 'px'
        })
        .append($('<header class="ui-widget-content ui-draggable"></header><textarea class="stickyForm" id="inputText" onclick="moveUp(' + note.noteId + ')"></textarea></div>'))
        .appendTo(document.body); */


    var input = document.getElementById(note.noteId).lastChild;
    input.value = note.body;
}


function loadBoard() {
    var apiPath = "https://localhost:44363/api/boards/1"
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status >= 200 && this.status < 300) {
            // Typical action to be performed when the document is ready:
            let response = JSON.parse(xhttp.responseText);
            console.log(response.notes);
            for (let i = 0; i < response.notes.length; i++) {
                let note = response.notes[i];
                console.log(note);
                createNoteFromJSON(note);
            }
        }
    };
    xhttp.open("GET", apiPath, true);
    xhttp.send();

}










