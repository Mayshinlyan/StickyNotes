﻿function createNewBoard() {
    let api = "https://localhost:44363/api/boards/";
    let xhttp = new XMLHttpRequest();
    let board = { boardId : 0 };
    xhttp.onreadystatechange = function () {
        if (this.readystate = 4 && this.status >= 200 && this.status < 300) {
            let thing = JSON.parse(this.response);
            document.getElementById("EnterBoard").value = thing.boardId;
            console.log(thing);
        }
    };
    xhttp.open("Post", api);
    xhttp.setRequestHeader("Content-Type", "application/json");
    xhttp.send(JSON.stringify(board));
}

function joinBoard(id) {
    let url = "https://localhost:44363/Board";
    let boardId = document.getElementById("EnterBoard").value;
    let xhttp = new XMLHttpRequest();
    let userboard = {boardId: boardId, id : id};
    let api = "https://localhost:44363/api/userboards/";
    xhttp.onreadystatechange = function () {
        console.log(this.readyState);
        if (this.readyState == 4) {
            // empty now :)
        }
    }
    console.log(userboard);
    xhttp.open("POST", api, true);
    xhttp.setRequestHeader("Content-Type", "application/json");
    xhttp.send(JSON.stringify(userboard));
    localStorage.setItem("board", boardId);
    window.location.href = url;
}