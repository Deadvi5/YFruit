using System.Threading;
using System.Threading.Tasks;
using Data.Abstractions;
using Data.Abstractions.Models;
using Data.Abstractions.Requests;
using MediatR;

namespace Data.Handlers
{
    public class SumRequestHandler: IRequestHandler<SumRequest, int>
    {
        private readonly IOperationData operation;
        public SumRequestHandler(IOperationData operation)
        {
            this.operation = operation;
        }
        
        public async Task<int> Handle(SumRequest request, CancellationToken cancellationToken)
        {
            return await operation.Calculate(new OperationDto(request.First, request.Second));
        }
    }
}
