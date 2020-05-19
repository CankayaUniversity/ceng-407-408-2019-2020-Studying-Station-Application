using Firebase.Database;
using Firebase.Database.Query;
using SSA.Mobil.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSA.Mobil.Database
{
    public class DBChat
    {
        DbFirebaseAuth service = new DbFirebaseAuth();
        public async Task<List<chatRoomModel>> getRoomListAsync()
        {
            return (await service.client.Child("Chats").OnceAsync<chatRoomModel>()).Select((item) => new chatRoomModel { Key = item.Key, roomName = item.Object.roomName }).ToList(); ;

        }

        public async Task saveRoom(chatRoomModel rm)
        {
            await service.client.Child("Chats").PostAsync(rm);
        }

        public async Task saveMessage(chatMessage cm, string room)
        {
            await service.client.Child("Chats/" + room + "/Message").PostAsync(cm);
        }

        public ObservableCollection<chatMessage> subChat(string roomKey)
        {

            return service.client.Child("Chats/"+roomKey+"/Message").AsObservable<chatMessage>().AsObservableCollection<chatMessage>();
        }
    }
}
