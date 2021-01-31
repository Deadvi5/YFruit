using System.Threading.Tasks;
using Data.Abstractions.Models;

namespace Data.Abstractions
{
    public interface IOperationData
    {
        Task<int> Calculate (OperationDto parameter);
    }
}