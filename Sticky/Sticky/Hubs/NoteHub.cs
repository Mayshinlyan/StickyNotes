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

        //// telling the client to update shape
        //public async Task UpdateModel(ShapeModel clientModel)
        //{
        //    clientModel.LastUpdatedBy = Context.ConnectionId;
        //    // Update the shape model within our broadcaster
        //    await Clients.AllExcept(clientModel.LastUpdatedBy).SendAsync("UpdateShape", clientModel);
               
       // }

        public async Task SyncBoard(string user, string message)
        {
            await Clients.All.SendAsync("BoardIsSynced", user, message);
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

