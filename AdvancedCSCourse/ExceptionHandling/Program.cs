using System;
using System.IO;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ThrowError();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(@"c:\teste.txt");
                var content = streamReader.ReadToEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally {
                if (streamReader != null)
                    streamReader.Dispose(); //needs to be disposed and close the files
            }



            try { //better way to write code
                using (var streamReader2 = new StreamReader(@"c:\teste.txt")) { //internally create a finally block which call dispose
                    var content = streamReader2.ReadToEnd();
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }



            try { 
                var youtubeApi = new YoutubeAPI();
                var videos = youtubeApi.GetVideos("Gabriel");
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);   
            }
        }
        static void ThrowError() {
            throw new GabrielException();
        }
    }
    class GabrielException : Exception {
        public override string Message {
            get { return "Erro do Gabriel"; }
        }
    }
}
