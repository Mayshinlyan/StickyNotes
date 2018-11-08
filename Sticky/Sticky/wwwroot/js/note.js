"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/noteHub").build();

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var input = document.getElementById("inputText");
    input.value = msg;

});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("inputText").addEventListener("input", function (event) {
   // var user = document.getElementById("userInput").value;
    var message = document.getElementById("inputText").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});