using System.Diagnostics.Contracts;

namespace MoqLecture.Core;

public interface IEmployeeRepository
{
    string GetId();
    string GetName();
}
