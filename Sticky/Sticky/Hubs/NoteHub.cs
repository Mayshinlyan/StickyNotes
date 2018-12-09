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
        public async Task MoveShape(int x, int y)
        {
            await Clients.Others.SendAsync("ShapeMoved", x, y);
        }

        // move up 
        public async Task MovedUp(int z, int id)
        {
            await Clients.All.SendAsync("MovedUp", z, id);
        }




    }

    public class ShapeModel
    {
        // We declare Left and Top as lowercase with 
        // JsonProperty to sync the client and server models
        [JsonProperty("left")]
        public double Left { get; set; }
        [JsonProperty("top")]
        public double Top { get; set; }
        // We don't want the client to get the "LastUpdatedBy" property
        [JsonIgnore]
        public string LastUpdatedBy { get; set; }
    }
}

