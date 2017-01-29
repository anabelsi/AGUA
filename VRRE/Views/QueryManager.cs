using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VRRE.Models;

namespace VRRE.Views
{
    public class QueryManager
    {
        public static string GetQuery (Search search)
        {
            if (search == null)
                return "";

            string templateID = "@@templateid='{E15DD7B0-B741-4187-96FE-0E3B45C679BB}'";
            string city = "";
            if (!string.IsNullOrEmpty(search.City))
            {
                city = "@City='" + search.City + "'";
            }
            string province = "";
            if (!string.IsNullOrEmpty(search.Province))
            {
                province = "@Province='" + MapProvince(search.Province) + "'";
            }
            string propertytype = "";
            if (!string.IsNullOrEmpty(search.PType))
            {
                propertytype = "@Property Type='" + MapProperty(search.PType) + "'";
            }
            string transtype = "";
            if (!string.IsNullOrEmpty(search.TType))
            {
                transtype = "@Transaction Type='" + MapTransaction(search.TType) + "'";
            }
            string bedrooms = "";
            if (!string.IsNullOrEmpty(search.Bedrooms) &&
                !search.Bedrooms.Equals("any"))
            {
                if (search.Bedrooms.Equals("1") ||
                    search.Bedrooms.Equals("2") ||
                    search.Bedrooms.Equals("3"))
                    bedrooms = "@Bedrooms='" + search.Bedrooms + "'";
                else if (search.Bedrooms.Equals("plus"))
                    bedrooms = "@Bedrooms>='3'";
            }
            string bathrooms = "";
            if (!string.IsNullOrEmpty(search.Bathrooms) &&
                !search.Bathrooms.Equals("any"))
            {
                if (search.Bathrooms.Equals("1") ||
                    search.Bathrooms.Equals("2") ||
                    search.Bathrooms.Equals("3"))
                    bathrooms = "@Bathrooms='" + search.Bathrooms + "'";
                else if (search.Bathrooms.Equals("plus"))
                    bathrooms = "@Bathrooms>='3'";
            }
            string price = "";
            if (!string.IsNullOrEmpty(search.Minimum) || !string.IsNullOrEmpty(search.Maximum))
            {
                if (!string.IsNullOrEmpty(search.Minimum) &&
                    !search.Minimum.Equals("0"))
                    price = "@Price>='" + search.Minimum + "'";
                if (!string.IsNullOrEmpty(search.Maximum) &&
                    !search.Maximum.Equals("0"))
                {
                    if (!string.IsNullOrEmpty(price))
                        price = price + " and ";
                    price = price + "@Price<='" + search.Maximum + "'";
                }
            }

            string query = "fast:/sitecore/content//*[";
            if (!string.IsNullOrEmpty(templateID))
                query = query + templateID;
            if (!string.IsNullOrEmpty(city))
                query = query + " and " + city;
            if (!string.IsNullOrEmpty(province))
                query = query + " and " + province;
            if (!string.IsNullOrEmpty(propertytype))
                query = query + " and " + propertytype;
            if (!string.IsNullOrEmpty(transtype))
                query = query + " and " + transtype;
            if (!string.IsNullOrEmpty(bedrooms))
                query = query + " and " + bedrooms;
            if (!string.IsNullOrEmpty(bathrooms))
                query = query + " and " + bathrooms;
            if (!string.IsNullOrEmpty(price))
                query = query + " and " + price;
            query = query + "]";

            return query;
        }

        private static string MapProvince (string ProvinceCode)
        {
            if (ProvinceCode.Equals("ON"))
                return "{C82E4F22-BDF1-4694-9365-26620500E708}";
            else if (ProvinceCode.Equals("QC"))
                return "{55F0E423-D307-4E6A-97F4-8B293BBB6B37}";
            else if (ProvinceCode.Equals("NS"))
                return "{470EC212-1E43-4518-9D33-C9C7CD979B74}";
            else if (ProvinceCode.Equals("NB"))
                return "{885538D4-CF0C-4E22-9DA5-60C57C3237CF}";
            else if (ProvinceCode.Equals("MB"))
                return "{5BE65BF2-E53B-43C2-A463-4B18F58A3383}";
            else if (ProvinceCode.Equals("BC"))
                return "{E3D05048-1CCE-4D39-9DF3-F5936CDCC465}";
            else if (ProvinceCode.Equals("PE"))
                return "{F3A59BF5-11A6-4DC9-8EDC-339F1EE7F0DF}";
            else if (ProvinceCode.Equals("SK"))
                return "{E72F3CA1-BDA9-4B01-8925-0C9CBD101766}";
            else if (ProvinceCode.Equals("AB"))
                return "{77A21B19-A8C6-4A4B-890C-7D9AEA16A8D0}";
            else if (ProvinceCode.Equals("NL"))
                return "{C24DA318-B6AE-4C94-B75C-04EB20C05403}";
            else if (ProvinceCode.Equals("NT"))
                return "{0C2056D9-C7C6-4167-92A6-8D25913951D8}";
            else if (ProvinceCode.Equals("YT"))
                return "{1AF2C4CB-C02D-4F86-B911-41DA812EF124}";
            else if (ProvinceCode.Equals("NU"))
                return "{A33BB401-866D-4A16-8335-203E8F5DD984}";
            else
                return "";
        }

        private static string MapProperty(string PropertyCode)
        {
            if (PropertyCode.Equals("RE"))
                return "{9CD152F5-F606-4A4A-BBDB-74CB06D057F5}";
            else if (PropertyCode.Equals("CM"))
                return "{4B24F5AC-92AE-44E2-A313-A1F39CF95C6D}";
            else
                return "";
        }

        private static string MapTransaction(string TransactionCode)
        {
            if (TransactionCode.Equals("FS"))
                return "{420205AD-3D52-417D-9124-319E5A4E3854}";
            else if (TransactionCode.Equals("FR"))
                return "{D3DC921D-26FB-4E27-9CEC-CE3D849C836F}";
            else
                return "";
        }
    }
}