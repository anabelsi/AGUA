using System.Collections.Generic;
using System.ServiceModel;
using AGUA.Models;

namespace AGUA
{
    [ServiceContract(Namespace = "AGUA")]
    public interface IQueryService
    {
        [OperationContract]
        List<Property> SearchProperties(string City, string Province, string PType, string TType, string Bedrooms, string Bathrooms, string Minimum, string Maximum);
    }
}
