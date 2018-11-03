var currentNote = {};
/*
function createNote(eventX;
    var y = event.clientY;
    currentNote.position = $("x","y");
    document.getElementById("demo").innerHTML = coords1 + coords2;

}
*/
$(function(){
    $(".flex").click(function(e){
        if($(e.target).is("header")) return;
        if($(e.target).is("textarea")) return;
        if($(e.target).is("div")) return;
        if($(e.target).is("h1")) return;
        if(e.pageY > (window.innerHeight-202)){e.pageY=window.innerHeight-202;}
        var div = $('<div class="image-wrapper">')
            .css({
                "left": e.pageX + 'px',
                "top": e.pageY + 'px'
            })
            .append($('<div class="stickynote"><header class="ui-widget-content"></header><body><textarea class="stickyForm"></textarea></div>'))
            .appendTo(document.body);
            $( ".stickynote" ).draggable({handle:"header", containment:"#board"});
    });
});
var notes = $("div");
notes.click(function(){
    var selected = $(this), max = 0;

    notes.each(function(){
        var zindex = parseInt($(this).css("z-index"),10);
        max = Math.max(max,zindex);
    });
    selected.css("z-index",max+1);
});