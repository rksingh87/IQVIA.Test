using System;
using System.Net;
using System.Net.Http;
using IQVIA.TweetClient.Logger;
using IQVIA.TweetClient.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IQVIA.TweetClient.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDateToGMTString()
        {
            DateTime dateTime = new DateTime(2017, 12, 31, 23, 59, 0);
            Assert.AreEqual("2017-12-31T23:59:00.0000000", dateTime.ToGMTString());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Could not complete fetch. An Error Occured.")]
        public void FetchAllTweets_Method_Should_Throw_Error_When_Start_Date_Is_Null()
        {

            var loggerObj = new Mock<ILogger>();
            TweetClient client = new TweetClient(loggerObj.Object);
            client.FetchAllTweets(null, DateTime.Now.ToString());
        }


        [TestMethod]
        [ExpectedException(typeof(Exception), "Could not complete fetch. An Error Occured.")]
        public void FetchAllTweets_Method_Should_Throw_Error_When_End_Date_Is_Null()
        {

            var loggerObj = new Mock<ILogger>();
            TweetClient client = new TweetClient(loggerObj.Object);
            client.FetchAllTweets(DateTime.Now.ToString(), null);
        }
    }
}
