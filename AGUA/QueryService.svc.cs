using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using AGUA.Models;
using Sitecore.Resources.Media;

namespace AGUA
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class QueryService : IQueryService
    {
        //Pass empty strings on all fields to get all properties
        public List<Property> SearchProperties(string City, string Province, string PType, string TType, string Bedrooms, string Bathrooms, string Minimum, string Maximum)
        {
            var context = Sitecore.Configuration.Factory.GetDatabase("web");
            var mediaUrlOptions = new MediaUrlOptions() { UseItemPath = false, AbsolutePath = true, AlwaysIncludeServerUrl = true };

            List<Sitecore.Data.Items.Item> Properties = null;

            if (string.IsNullOrEmpty(City) &&
                string.IsNullOrEmpty(Province) &&
                string.IsNullOrEmpty(PType) &&
                string.IsNullOrEmpty(TType) &&
                string.IsNullOrEmpty(Bedrooms) &&
                string.IsNullOrEmpty(Bathrooms) &&
                string.IsNullOrEmpty(Minimum) &&
                string.IsNullOrEmpty(Maximum))
                Properties = (context.Items.GetItem(Sitecore.Data.ID.Parse("{1A29DD79-608B-4034-A68B-67D514D66034}"))).Children.ToList();

            else
            {
                Search SearchObject = new Search
                {
                    City = City,
                    Province = Province,
                    PType = PType,
                    TType = TType,
                    Bedrooms = Bedrooms,
                    Bathrooms = Bathrooms,
                    Minimum = Minimum,
                    Maximum = Maximum
                };
                string query = Views.QueryManager.GetQuery(SearchObject);
                Properties = context.SelectItems(query).ToList();
            }

            List<Property> SerProperties = new List<Property>();

            foreach (var property in Properties)
            {
                List<PropertyImage> SerPropertyImages = new List<PropertyImage>();

                int price;
                if (!int.TryParse(property.Fields["Price"].ToString(), out price)) price = 0;
                int bedrooms;
                if (!int.TryParse(property.Fields["Bedrooms"].ToString(), out bedrooms)) bedrooms = 0;
                int bathrooms;
                if (!int.TryParse(property.Fields["Bathrooms"].ToString(), out bathrooms)) bathrooms = 0;

                var images = context.Items.GetItem(Sitecore.Data.ID.Parse(property.Fields["Images"].ToString())).Children.ToList();
                for(int i = 0; i < images.Count; i++)
                {
                    var img = images[i];
                    string url = MediaManager.GetMediaUrl(img, mediaUrlOptions);
                    string alt = img.Fields["Alt"].ToString();

                    SerPropertyImages.Add(new PropertyImage { Alt = alt, Url = url });
                }

                SerProperties.Add(new Property
                {
                    address = property.Fields["Address"].ToString(),
                    description = property.Fields["Description"].ToString(),
                    price = price,
                    city = property.Fields["City"].ToString(),
                    province = context.Items.GetItem(Sitecore.Data.ID.Parse(property.Fields["Province"].ToString())).Fields["Text"].ToString(),
                    propertyType = context.Items.GetItem(Sitecore.Data.ID.Parse(property.Fields["Property Type"].ToString())).Fields["Text"].ToString(),
                    transactionType = context.Items.GetItem(Sitecore.Data.ID.Parse(property.Fields["Transaction Type"].ToString())).Fields["Text"].ToString(),
                    bedrooms = bedrooms,
                    bathrooms = bathrooms,
                    Images = SerPropertyImages
                });
            }

            return SerProperties;
        }
    }
}
