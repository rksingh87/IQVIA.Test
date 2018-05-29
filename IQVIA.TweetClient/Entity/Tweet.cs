using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQVIA.TweetClient.Entity
{
    /// <summary>
    /// Tweet Entity
    /// </summary>
    public class Tweet
    {
        /// <summary>
        /// Tweet ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Time Stamp of a Tweet (In GMT)
        /// </summary>
        public string stamp { get; set; }


        /// <summary>
        /// Content of Tweet
        /// </summary>
        public string text { get; set; }
    }
}
