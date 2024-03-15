using System.Collections.Generic;

namespace API.SignalR
{
    public class PresenceTracker
    {
        private static readonly Dictionary<string, List<string>> OnlineUsers = new Dictionary<string, List<string>>();

        public Task<bool> UserConnected(string username, string connectionId)
        {
            bool isOnline = false;
            lock(OnlineUsers)
            {
                if (OnlineUsers.ContainsKey(username))
                {
                    OnlineUsers[username].Add(connectionId);
                } else
                {
                   OnlineUsers.Add(username, new List<string>{connectionId});
                   isOnline = true;
                }
            }

            return Task.FromResult(isOnline);
        }

        public Task<bool> UserDisconnected(string username, string connectionId)
        {
            bool issOffline = false;
            lock(OnlineUsers)
            {
                if (!OnlineUsers.ContainsKey(username)) return Task.FromResult(issOffline);

                OnlineUsers[username].Remove(connectionId);

                if (OnlineUsers[username].Count == 0)
                {
                    OnlineUsers.Remove(username);
                    issOffline = true;
                }
            }
            return Task.FromResult(issOffline);
        }

        public Task<string[]> GetOnlineUsers()
        {
            string[] onlineUsers;
            lock(OnlineUsers)
            {
                onlineUsers = OnlineUsers.OrderBy(k => k.Key).Select(k => k.Key).ToArray();
            }
            
            return Task.FromResult(onlineUsers);
        }

        public static Task<List<string>> GetConnectionForUser(string username)
        {
            List<string> connectionId;

            lock (OnlineUsers)
            {
                connectionId = OnlineUsers.GetValueOrDefault(username);
            }

            return Task.FromResult(connectionId);
        }
    }
}