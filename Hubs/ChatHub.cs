using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
public class ChatHub : Hub {
    // The SendMessage method can be called by the client.
  public async Task SendMessage(string user, string message) {
    // the receiveMessage method is called from the server on all clients
    await Clients.All.SendAsync("ReceiveMessage", user, message);
  }
}

}