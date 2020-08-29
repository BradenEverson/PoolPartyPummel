using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolPartyPummel
{
    public class GameHub : Hub
    {
        public async Task joinGroup(string userName, string id = null)
        {
            if(id == null)
            {
                id = Guid.NewGuid().ToString().Split('-')[0];
            }
            string name = Context.ConnectionId;
            await Groups.AddToGroupAsync(name, id);
            await Clients.Group(id).SendAsync("newUser", userName);
        }
        public async Task leaveGroup(string userName, string id)
        {
            string name = Context.ConnectionId;
            await Groups.RemoveFromGroupAsync(name, id);
            await Clients.Group(id).SendAsync("userLeft",userName);
        }
    }
}
