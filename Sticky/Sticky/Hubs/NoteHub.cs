using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sticky.Hubs
{
    public class NoteHub : Hub
    {
        // telling the client to receivemessage
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }


        public async Task SendNoteCreated(string message)
        {
            await Clients.Others.SendAsync("ReceiveNote", message);
        }

        // drag function
        public async Task MoveShape(int x, int y)
        {
            await Clients.Others.SendAsync("ShapeMoved", x, y);
        }


    }

}

    
