using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQVIA.TweetClient.Logger
{
    public class Logger : ILogger
    {
        public void Log(int attemptId, string startDate, string endDate, int resultRecived)
        {
            Console.WriteLine("Attempt {0}, Start Date: {1}, End Date: {2}, Result Received: {3}", attemptId, startDate, endDate, resultRecived);
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
