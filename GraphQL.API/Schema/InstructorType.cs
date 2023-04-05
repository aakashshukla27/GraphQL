using System.Security.Cryptography.X509Certificates;

namespace GraphQL.API.Schema
{
    
    public class InstructorType : PersonType
    {
        public double Salary { get; set; }

    }
}
