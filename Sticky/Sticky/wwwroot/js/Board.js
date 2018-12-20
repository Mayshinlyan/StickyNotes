/**
 * Makes a post request to create a new board.
 * Then takes the id of the new board and puts it in the join board box.
 */
function createNewBoard() {
    let url = window.location.href.replace(window.location.pathname, '');
    let api = "api/boards/";
    let xhttp = new XMLHttpRequest();
    let board = { BoardId : 0 };
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

/**
 * Registers a user with a board then redirects to the board
 * @param {any} id the id of the user to be added
 */
function joinBoard(id) {
    let boardId = document.getElementById("EnterBoard").value;
    let xhttp = new XMLHttpRequest();
    let userboard = { BoardId: boardId, Id: id };
    let url = window.location.href.replace(window.location.pathname, '');
    let api = "api/userboards/";
    localStorage.setItem("board", boardId);
    xhttp.onreadystatechange = function () {
        console.log(this.readyState);
        if (this.readyState == 4 && this.readyState >= 200 && this.readyState < 300) {
            let redir = "/Board";
            alert(redir);
            window.location.href = redir;
        }
    }
    if (userboard.Id == '') {
        let redir = "/Board";
        window.location.href = redir;
    }
    else {
        xhttp.open("POST", api, true);
        xhttp.setRequestHeader("Content-Type", "application/json");
        xhttp.send(JSON.stringify(userboard));        
    }
}

/**
 *  Handles change in board name
 *  https://stackoverflow.com/questions/8747439/detecting-value-change-of-inputtype-text-in-jquery
 */
$("#BoardName").on("change paste keyup", function () {
    let xhttp = new XMLHttpRequest();
    let boardId = localStorage.getItem("board");
    let url = window.location.href.replace(window.location.pathname, '');
    let api = "api/boards/" + boardId;
    let board = {BoardId : boardId, Name : $(this).val()}
    xhttp.onreadystatechange = function () {
        // empty for now
    }
    xhttp.open("PUT", api, true);
    xhttp.setRequestHeader("Content-Type", "application/json");
    xhttp.send(JSON.stringify(board));
});
