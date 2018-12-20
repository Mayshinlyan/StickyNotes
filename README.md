# StickyNotes
StickyNotes is a brainstorming collaboration app for distributed group. It can also be used as your personal sticky notes page such as to-do-list or so. 

## Our website
https://sticky20181219103726.azurewebsites.net/Index

## Features
- User can sign up and alternatively via google login
- Create sticky notes on click
- Collaborate with other teammates simultaneously
- User can have multiple boards 
- User can store their stickynotes data 

## File Structure
Uses Microsoft DotNet Core 2.0 Web API, MVC Framework and SignalR for syncing user board. 

                
    ├── wwwroot                 # Front end files 
        ├── css 
          ├── site.css          # Basic web page layout 
          └── style.css         # Contains additional css for sticky notes and board 
        ├── images 
        ├── js 
          ├── Board.js                    # Basic web page layout 
          ├── note.js                     # Contains methods that communicate with SignalR and database
          └── Profile.js                  # Contain a method to go from profile page to the board 
        └── lib                 # Package files needed for the project (e.g: jQuery and SignalR)
    ├── Areas                   # Files for scalfolded identity with dotNet and external logins through Google API
    ├── Controllers             # Contains methods for api with get, post and put methods. 
       ├── BoardController.js             # API methods for controlling boards 
       ├── NotesController.js             # API methods for controlling notes 
       └── UserBoardsController.js        # API methods for communicating between the board and the user database 
    ├── Data                    # auto generated file for DbContext
    ├── Hubs                   
       └── NoteHub.cs           # SignalR hub file that channels the user actions to signalr responses
    ├── Models                  # Contains Database structure
       ├── ApplicationUser.cs             # Customizes the asp user model 
       ├── Boards.cs                      # Contains board model 
       ├── Notes.cs                       # Contains notes model
       ├── UserBoards.cs                  # Contains model to link user and board 
       └── Invite.cs                      # Intended for future features of inviting users to board
    ├── Pages                   # Frontend pages 
    └── README.md
    
   ## Client Api Consumption
   Client uses the API in order to get information out of the database. Methods which use it are in note.js and Board.js. They are used to retrieve information about the board and notes, update these, or create them.
   
   
   ## Bonus
   
   1. B1 - SignalR live actions
   2. B2 - Deployment
   3. B3 - Authentification
   4. B4 - External API (Google Login)
   
   
   ## Miscellaneous
   - Click inside the note to focus it before dragging.
   - To save the content in the note, the user need to go out of focus of the notes.
   
   
