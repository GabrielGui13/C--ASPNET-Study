using System;

namespace Delegates
{
    class Program {  
        public static void Main (string[] args) {

            //System.Action<T> = can receive until 16 params, points to a method that returns void
            //System.Func<T, out T> = can receive until 16 params, points to a method that returns a value

            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();

            //PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += RemoveRedEyeFilter;

            processor.Process("photo.jpg", filterHandler);
        }

        //Simulation of a custom filter created by the "framework" user
        static void RemoveRedEyeFilter(Photo photo) { //has the same signature: void (Photo)
            Console.WriteLine("Removed red eye");
        }
    }
}
