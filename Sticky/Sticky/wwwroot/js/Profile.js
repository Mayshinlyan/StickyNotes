function goToBoard(id) {
    localStorage.setItem("board", id);
    let url = "https://localhost:44363/Board";
    window.location.href = url;
}