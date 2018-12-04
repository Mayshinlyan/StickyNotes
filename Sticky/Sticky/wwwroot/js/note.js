"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/noteHub").build();
//var shape = document.getElementById('stickynote'),
//    shapeModel = {
//        left: 0,
//        top: 0
//    };

// receiving the text inside the note
connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var input = document.getElementById("inputText");
    input.value = msg;
});

// receiving the stickynotes 
connection.on("BoardIsSynced", function (user, message) {
    //console.log(message);
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var board = document.getElementById("board");
    board.innerHTML = message;

   
});

//connection.on("UpdateShape", function (model) {
//    // console.log(message);
//    shapeModel = model;
//    shape.css({ left: model.left, top: model.top });
//});


connection.start().catch(function (err) {
    console.log("heyyyyyy")
    return console.error(err.toString());
});






var user = document.getElementById("user").value;
// syncing the note itself

function syncNote() {
    var mutationObserver = new MutationObserver(function (mutations) {
        mutations.forEach(function (mutation) {
            console.log(mutation.target.outerHTML);
            var message = mutation.target.outerHTML;
            connection.invoke("SyncBoard", user, message).catch(function (err) {
                return console.error(err.toString());
            });
            mutationObserver.disconnect();
            event.preventDefault();
        });
    });

    mutationObserver.observe(document.getElementById("board"), {
        childList: true,
        subtree: true
    });

    // Takes all changes which haven’t been fired so far.
    var changes = mutationObserver.takeRecords();

}

document.getElementById("board").addEventListener("click", function () {
    syncNote();

})






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


// sending the text inside the note
document.getElementById("inputText").addEventListener("input", function (event) {
    var user = document.getElementById("user").value;
    var message = document.getElementById("inputText").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});


// sending the note position

//connection.start(function () {
//    console.log("connection started");
//    shape.draggable({
//        drag: function () {
//            shapeModel = shape.offset();
//            connection.invoke("UpdateModel", shapeModel);
//        }
//    });
//}




