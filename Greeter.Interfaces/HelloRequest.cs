using System.Runtime.Serialization;

namespace Greeter.Interfaces
{
    [DataContract]
    public class HelloRequest
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }
    }
}
