using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sticky.Hubs
{
    public class NoteHub : Hub
    {
        // telling the client to receive message
        public async Task SendMessage(string user, string message, int id)
        {
            await Clients.Others.SendAsync("ReceiveMessage", user, message, id);
        }

        // telling the client to receive note creation
        public async Task SendNoteCreated(string message)
        {
            await Clients.Others.SendAsync("ReceiveNote", message);
        }

        // drag function
        public async Task MoveShape(int id, int x, int y)
        {
            await Clients.Others.SendAsync("ShapeMoved", id, x, y);
        }

        // deleteNote
        public async Task DeleteNote(int id)
        {
          
            await Clients.Others.SendAsync("NoteDeleted", id);
          
        }


        // move up
        public async Task MovedUp(int z, int id)
        {
            await Clients.All.SendAsync("MovedUp", z, id);
        }

    }

}
