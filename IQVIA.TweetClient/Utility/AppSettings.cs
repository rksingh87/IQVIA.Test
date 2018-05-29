using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace IQVIA.TweetClient.Utility
{
    public class AppSettings
    {
        public static string TweetAPIUrl = ConfigurationManager.AppSettings["APIUrl"];
    }
}
