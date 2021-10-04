using System;
using System.Collections.Generic;

namespace ExceptionHandling {
    public class YoutubeAPI {
        public List<Video> GetVideos(string user) {
            try 
            {
                // Access youtube web service
                // Read the data
                // Create a list of video objects
                throw new Exception("Oops some low level Youtube level.");
            }
            catch (Exception e)
            {
                // Log
                throw new YoutubeException("Could not fetch the videos from youtube.", e);
            }

            return new List<Video>();
        }
    }
}