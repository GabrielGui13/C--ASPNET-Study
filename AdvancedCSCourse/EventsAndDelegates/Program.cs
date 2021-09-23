using System;

namespace EventsAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video{ Title = "Video 1" };
            var videoEncoder = new VideoEncoder(); //publisher
            var mailService = new MailService(); //subscriber
            var smsService = new SmsService(); //subscriber

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded; //subscription, reference to mailService method
            videoEncoder.VideoEncoded += smsService.OnVideoEncoded; //without (), because it's not calling it
            
            videoEncoder.Encode(video);
        }
    }
}
