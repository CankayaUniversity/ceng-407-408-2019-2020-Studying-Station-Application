using Firebase.Database;
using Firebase.Database.Query;
using SSA.Mobil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSA.Mobil.Database
{
    public class DBHelperEvents
    {
        FirebaseClient firebase = new FirebaseClient("https://ssaplication.firebaseio.com/");
        public async Task<List<eventData>> GetAllEvents()
        {
            return (await firebase
              .Child("EventSSA")
              .OnceAsync<eventData>()).Select(item => new eventData
              {
                  eventIdea = item.Object.eventIdea,
                  eventDate = item.Object.eventDate
              }).ToList();
        }
        public async Task AddEvent(string idea, string date)
        {
            await firebase
                    .Child("EventSSA")
                    .PostAsync(new eventData() { eventIdea = idea ,eventDate = date});
        }
    }
}
