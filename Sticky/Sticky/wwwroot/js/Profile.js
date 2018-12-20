function goToBoard(id) {
    localStorage.setItem("board", id);
    let url = window.location.href.replace(window.location.pathname, '');
    url = url + "/Board";
    window.location.href = url;
}