using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    //a view model is a model specifically built for a view, includes any data and rules specific to that view
    public class RandomMovieViewModel 
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}