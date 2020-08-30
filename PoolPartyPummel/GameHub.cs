using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolPartyPummel
{
    public class GameHub : Hub
    {
        public Dictionary<string, string> connectionsToUsers = new Dictionary<string, string>();//{connectionId},{username}
        public async Task joinGroup(string userName, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                id = Guid.NewGuid().ToString().Split('-')[0];
            }
            string name = Context.ConnectionId;
            connectionsToUsers.Add(name, userName);
            Console.WriteLine(userName + ", " + id);
            await Groups.AddToGroupAsync(name, id);
            await Clients.Group(id).SendAsync("newUser", userName);
        }
        public async Task leaveGroup(string userName, string id)
        {
            string name = Context.ConnectionId;
            await Groups.RemoveFromGroupAsync(name, id);
            await Clients.Group(id).SendAsync("userLeft",userName);
        }
        public async Task sendMessage(string user, string message, string connectionGuid)
        {
            if (message.Contains("/drown"))
            {
                string drownedUser = message.Split(' ')[1];
                await leaveGroup(drownedUser, connectionGuid);
                message = "<h6 class='text-primary'>" + drownedUser + " was drowned" + "</h6>";
            }
            Console.WriteLine(user);
            await Clients.Group(connectionGuid).SendAsync("newMessage",user, message);
        }
    }
}
