function createNewBoard() {
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

function joinBoard() {
    let url = "https://localhost:44363/Board";
    let boardId = document.getElementById("EnterBoard").value;
    localStorage.setItem("board", boardId);
    window.location.href = url;
    console.log("here");
}