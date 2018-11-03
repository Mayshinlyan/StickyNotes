var currentNote = {};
/*
function createNote(event){
    var x = event.clientX;
    var y = event.clientY;
    currentNote.position = $("x","y");
    document.getElementById("demo").innerHTML = coords1 + coords2;

}
*/
$(function(){
    $(".flex").click(function(e){
        var div = $('<div class="image-wrapper">')
            .css({
                "left": e.pageX + 'px',
                "top": e.pageY + 'px'
            })
            .append($('<div class="stickynote"><header class="ui-widget-content"></header><body><textarea class="stickyForm"></textarea></div>'))
            .appendTo(document.body);
            $( ".stickynote" ).draggable({handle:"header"});
    });
});