using System;

namespace structural_facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade(new VideoConvertSystem(), new DataBaseSystem(), new UserMessageSystem());
            // A user uploads a video file
            var user = new object();
            var videoFile = new object();
            facade.UploadVideo(user, videoFile);
        }
    }

    /// <summary>
    /// The Facade class coordinates the sub-systems to fulfill video upload operation 
    /// </summary>
    public class Facade
    {
        private VideoConvertSystem videoConvertSystem;
        private DataBaseSystem dataBaseSystem;
        private UserMessageSystem userMessageSystem;

        public Facade(VideoConvertSystem videoConvertSystem, DataBaseSystem dataBaseSystem, UserMessageSystem userMessageSystem)
        {
            this.videoConvertSystem = videoConvertSystem;
            this.dataBaseSystem = dataBaseSystem;
            this.userMessageSystem = userMessageSystem;
        }

        public void UploadVideo(Object user, Object videoFile)
        {
            // convert to tiny file
            Object tinyVideoFile = videoConvertSystem.ConvertToTinyFile(videoFile);
            // store in database
            dataBaseSystem.SaveFile(user, tinyVideoFile);
            // notify user
            userMessageSystem.Notify(user, "File uploaded!");
        }
    }

    /// <summary>
    /// The VideoConvertSystem convert the large file to a tiny one
    /// </summary>
    public class VideoConvertSystem
    {
        public Object ConvertToTinyFile(Object originalVideoFile)
        {
            // code to convert original file to tiny file and return it
            return new object();
        }
    }

    /// <summary>
    /// The DataBaseSystem class represents a database system
    /// </summary>
    public class DataBaseSystem
    {
        public void SaveFile(Object user, Object file)
        {
            // code to store file to database
        }
    }
    
    /// <summary>
    /// The DataBaseSystem class represents a user message system
    /// </summary>
    public class UserMessageSystem
    {
        public void Notify(Object user, string msg)
        {
            // code to notify user that file have been upload
        }
    }
}