using System;
using System.Threading;

namespace EventsAndDelegates
{
    public class VideoEncoder {
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args); //eventname + 'EventHandler' => this delegate shapes the method in the subscriber

        public event EventHandler<VideoEventArgs> VideoEncoded; //it's where the subscriptions will be stored and the methods will be called, behind the scene, VideoEncoded event is a list of pointers to subscribers' methods

        //instead of creating a delegate for each event, .NET has implemented a specific by its own => EventHandler<AdditionalData> source is implicit

        public void Encode(Video video) {
            var encodingTime = DateTime.Now;
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);

            var finalEncodingTime = encodingTime - DateTime.Now;
            Console.WriteLine($"Video encoded in {(finalEncodingTime.TotalSeconds * -1):.00}s");

            OnVideoEncoded(video); //to notify the subscribers, raise the event
        }

        protected virtual void OnVideoEncoded(Video video) { //should be protected, virtual and void
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs{ Video = video });
                //this => who is publishing the event 
                //EventArgs.Empty => to not send any additional data
        }
    }
}