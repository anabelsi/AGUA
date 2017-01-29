using System.Collections.Generic;
using System.ServiceModel;
using VRRE.Models;

namespace VRRE
{
    [ServiceContract(Namespace = "VRRE")]
    public interface IQueryService
    {
        [OperationContract]
        List<Property> SearchProperties(string City, string Province, string PType, string TType, string Bedrooms, string Bathrooms, string Minimum, string Maximum);
    }
}
