using System.ComponentModel.DataAnnotations;

namespace VRRE.Models
{
    public class Search : Sitecore.Mvc.Presentation.RenderingModel
    {
        public string City { get; set; }

        public string Province { get; set; }

        public string PType { get; set; }

        public string TType { get; set; }

        public string Bedrooms { get; set; }

        public string Bathrooms { get; set; }

        public string Minimum { get; set; }

        public string Maximum { get; set; }
    }
}