using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace VRRE.Models
{
    [DataContract]
    public class PropertyImage
    {
        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string Alt { get; set; }
    }
}