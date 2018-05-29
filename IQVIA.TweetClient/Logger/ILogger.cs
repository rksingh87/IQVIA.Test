using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQVIA.TweetClient.Logger
{
    public interface ILogger
    {

        /// <summary>
        /// Logs message in the console.
        /// </summary>
        /// <param name="message"></param>
        void Log(string message);

        /// <summary>
        /// Logs the details of each iteration of API
        /// </summary>
        /// <param name="attemptId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="resultRecived"></param>
        /// <param name="totalResult"></param>
        void Log(int attemptId, string startDate, string endDate, int resultRecived);
    }
}
