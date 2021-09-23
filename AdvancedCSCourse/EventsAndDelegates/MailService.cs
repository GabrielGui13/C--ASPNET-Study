using System;

namespace EventsAndDelegates
{
    public class MailService {
        public void OnVideoEncoded(object source, VideoEventArgs args) {
		    Console.WriteLine("MailService: Email sent. " + args.Video.Title);
	    }
    }
}