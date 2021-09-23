using System;

namespace Delegates
{
    public class PhotoProcessor {
        //public delegate void PhotoFilterHandler(Photo photo); //custom delegate

        //Can pass any delegate that takes a Photo as an argument and returns void
        public void Process(string path, Action<Photo> filterHandler) { //PhotoFilterHandler previous one
            var photo = Photo.Load(path);

            /* var filters = new PhotoFilters();
            filters.ApplyBrightness(photo);
            filters.ApplyContrast(photo);
            filters.Resize(photo); */
            filterHandler(photo); //now the code doesnt know which filters will be applied
            photo.Save();
        }
    }
}