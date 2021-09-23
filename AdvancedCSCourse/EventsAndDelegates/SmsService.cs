using System;

namespace EventsAndDelegates
{
    public class SmsService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args) {
		    Console.WriteLine("SmsService: SMS sent. " + args.Video.Title);
        }
    }
}