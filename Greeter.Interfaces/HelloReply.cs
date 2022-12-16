using System.Runtime.Serialization;

namespace Greeter.Interfaces
{
    [DataContract]
    public class HelloReply
    {
        [DataMember(Order = 1)]
        public string? Message { get; set; }
    }
}