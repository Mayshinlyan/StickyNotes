/*
var currentNote = {};
function createNote(eventX;
    var y = event.clientY;
    currentNote.position = $("x","y");
    document.getElementById("demo").innerHTML = coords1 + coords2;

}
*/


// creating sticky notes on click
$("#login").click(function() {
    $(".modal").slideToggle("slow");
});

var max = 5;
var autoID = 0;

$(function(){
    //creates stickynote when you click on the board
    $("#board").click(function(e){
        if($(e.target).is("header")) return;
        if ($(e.target).is("textarea")) return;
        if($(e.target).is("div")) return;
        if($(e.target).is("h1")) return;
        autoID = autoID + 1;
        max = findHighestZIndex('div');
        if(e.pageY > (window.innerHeight-202)){e.pageY=window.innerHeight-202;}
        if(e.pageX > (window.innerWidth-202)){e.pageX=window.innerWidth-202;}
        var div = $('<div class="image-wrapper stickynote" id="'+autoID+'" style="z-index : '+max+'">')
            .css({
                "left": e.pageX + 'px',
                "top": e.pageY + 'px'
            })
            .append($('<header class="ui-widget-content"></header><textarea class="stickyForm" id="inputText" onclick="moveUp('+autoID+')"></textarea></div>'))
            .appendTo(document.body);
        $( "div" ).draggable({handle:"header", containment:"#board",stack:"div"});
        
    });
});

//moves the clicked stickynote up to the top.
function moveUp(id){
    max = findHighestZIndex('div');
    document.getElementById(id).style.zIndex=max ;
}

//finds the highest z index (duh)
function findHighestZIndex(element)
{
  var selectedElements = document.getElementsByTagName(element);
  var highest = 0;
  for (var i = 0; i < selectedElements.length; i++)
  {
    var zindex=  parseInt(document.defaultView.getComputedStyle(selectedElements[i],null).getPropertyValue("z-index"),10);
    if ((zindex > highest) && (zindex != 'auto'))
    {
      highest = zindex;
    }
  }
  return highest+1;
}