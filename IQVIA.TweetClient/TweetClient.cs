using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IQVIA.TweetClient.Entity;
using IQVIA.TweetClient.Logger;
using IQVIA.TweetClient.Utility;
using Newtonsoft.Json;

namespace IQVIA.TweetClient
{
    public class TweetClient
    {

        ILogger logger = null;
        List<Tweet> tweets = null;
        /// <summary>
        /// Creates an instance of TweetClient
        /// </summary>
        public TweetClient(ILogger loggerInput)
        {
            logger = loggerInput;
            tweets = new List<Tweet>();
        }

        /// <summary>
        /// Fetch all tweets in provided date rage and display each iteration in Console.
        /// </summary>
        /// <param name="startDate (In GMT)"></param>
        /// <param name="endDate (In GMT)"></param>
        public void FetchAllTweets(string startDate, string endDate)
        {
            try
            {
                int index = 0;
                List<Tweet> result = new List<Tweet>();

                do
                {
                    result = GetTweets(startDate, endDate).Result;
                    this.logger.Log(index++, startDate, endDate, result.Count);
                    if (result.Count < 100)
                    {
                        tweets.AddRange(result);
                        break;
                    }
                    else
                    {
                        var lastRecord = result[result.Count - 1].stamp;
                        tweets.AddRange(result.Where(t => t.stamp != lastRecord));
                        startDate = Convert.ToDateTime(lastRecord).ToUniversalTime().ToGMTString();
                    }
                } while (result.Count > 0);
            }
            catch
            {
                throw new Exception("Could not complete fetch. An Error Occured.");
            }
        }


        public void SaveResultAsCSV()
        {
            try
            {
                string data = tweets.GetCSV();
                System.IO.File.WriteAllText("TweeterData.txt", data);
                this.logger.Log(string.Format("Total Record Found {0}. Tweeter data saved sucessfully. Please check in Bin Folder", tweets.Count));
            }
            catch
            {
                throw new Exception("Could not save twitter data. Please close the file if it is open");
            }
        }


        public void CheckForDuplicateData()
        {
            var gropedData = tweets.GroupBy(t => t.id);

            if (gropedData.Count().Equals(tweets.Count()))
                this.logger.Log("No Duplicate Data Found in Final Collection");
            else
                this.logger.Log("Duplicate Data Found in Final Collection");
        }




        /// <summary>
        /// Calls API to Fetch Tweet Data
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<Tweet>> GetTweets(string startDate, string endDate)
        {
            string path = string.Format("{0}?startDate={1}&endDate={2}", AppSettings.TweetAPIUrl, startDate, endDate);
            List<Tweet> tweets = null;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    string str = await response.Content.ReadAsStringAsync();
                    tweets = JsonConvert.DeserializeObject<List<Tweet>>(str);
                }
            }
            return tweets;
        }
    }

}
