using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly byte Unknown = 0; //to avoid magic numbers in validation
        public static readonly byte PayAsYouGo = 1;
    }
}