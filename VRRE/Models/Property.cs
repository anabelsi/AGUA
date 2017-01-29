using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace VRRE.Models
{
    [DataContract]
    public class Property
    {
        [DataMember]
        public string address { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public int price { get; set; }

        [DataMember]
        public string city { get; set; }

        [DataMember]
        public string province { get; set; }

        [DataMember]
        public string propertyType { get; set; }

        [DataMember]
        public string transactionType { get; set; }

        [DataMember]
        public int bedrooms { get; set; }

        [DataMember]
        public int bathrooms { get; set; }

        [DataMember]
        public List<PropertyImage> Images { get; set; }
    }
}