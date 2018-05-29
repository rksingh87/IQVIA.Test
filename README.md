# IQVIA Tweet Client

The goal of this application is to provide all tweet data from 2016 to 2017 using https://badapi.iqvia.io/swagger/ API. 

###### Note: Considering Start Date and End Date according to System TimeZone. Hence, Total Tweet Record will differ in differnt TimeZone.

# Installation and working with this app
Please follow the step-by-step installation

### Nuget Dependencies
1. NewtonSoft.Json
2. NUnit Framework (For Unit Testing)
3. Moq 

## Configuration and Execution Of the Application
1. Clone the application from the Git repository https://github.com/rksingh87/IQVIA.Tweet.Client.git
2. Make sure you have Visual Studio 2015/2017 with .NET Framework 4.6.1. If not, please install from https://www.visualstudio.com/downloads/.
3. Once you clone the code from the above git repository, Please open `IQVIA.TweetClient.sln` file in Visual Studio.
4. Build the Solution, Make Sure that you have internet connection to download all dependencies required for this project.
5. Once Build is sucessfull, Please run the application using `F5` Key. You can find below screen which will fetch all data from API in multiple attempts.

![Image of Console Result](https://github.com/rksingh87/IQVIA.Tweet.Client/blob/master/blob/ConsoleApplicationResultWindow.PNG)

6. Finally, Once it completes all iterations, it will display all record count and Checks if there are duplicate tweet data in the collection based on tweet id. 

![Image of Console Final Result](https://github.com/rksingh87/IQVIA.Tweet.Client/blob/master/blob/ConsoleApplicationFinalResult.PNG)

7. To See all tweet record from 2016 to 2017, It saves all  the record in a file called `TweeterData.txt` (CSV Format) in bin folder of `IQVIA.TweetClient` Project.

8. You can find Test Cases in `IQVIA.TweetClient.Test` Project.

# References
1. https://guides.github.com/features/mastering-markdown/
2. https://www.visualstudio.com/downloads/
3. https://www.nuget.org/