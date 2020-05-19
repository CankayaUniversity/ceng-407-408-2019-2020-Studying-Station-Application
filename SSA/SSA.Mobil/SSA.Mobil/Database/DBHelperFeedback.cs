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
    public class DBHelperFeedback
    {
        FirebaseClient firebase = new FirebaseClient("https://ssaplication.firebaseio.com/");
        public async Task<List<feedbackData>> GetAllFeedbacks()
        {
            return (await firebase
              .Child("FeedbackSSA")
              .OnceAsync<feedbackData>()).Select(item => new feedbackData
              {
                  feedbackIdea  = item.Object.feedbackIdea,
                  score = item.Object.score
              }).ToList();
        }
        public async Task AddFeedback(string idea, int score)
        {
            await firebase
                    .Child("FeedbackSSA")
                    .PostAsync(new feedbackData() { feedbackIdea = idea, score = score });
        }
    }
}
