using IQVIA.TweetClient.Logger;
using IQVIA.TweetClient.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQVIA.TweetClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //  1. Fetch all tweets from 2016 to 2017
            //  2. Considering Clients Timezone

            ILogger logger = new Logger.Logger();

            DateTime startDateLocal = new DateTime(2016, 1, 1, 0, 0, 0);
            DateTime endDateLocal = new DateTime(2017, 12, 31, 23, 59, 0);

            string startDateGMT = startDateLocal.ToUniversalTime().ToGMTString();
            string endDateGMT = endDateLocal.ToUniversalTime().ToGMTString();
            logger.Log("=============================================================================================");
            logger.Log(string.Format("Start Date => Local: {0} GMT: {1}", startDateLocal, startDateGMT));

            
            logger.Log(string.Format("End Date   => Local: {0} GMT: {1}", endDateLocal, endDateGMT));

            logger.Log("=============================================================================================");

            try
            {
                TweetClient client = new TweetClient(logger);
                client.FetchAllTweets(startDateGMT, endDateGMT);
                logger.Log("=============================================================================================");
                client.SaveResultAsCSV();
                logger.Log("=============================================================================================");
                client.CheckForDuplicateData();
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
            }
            finally
            {
                //To hold On the console 
                Console.ReadLine();
            }
        }
    }
}
