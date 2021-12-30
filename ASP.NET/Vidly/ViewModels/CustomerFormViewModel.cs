using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; } //used to itereate in it
        public Customer Customer { get; set; }
    }
}