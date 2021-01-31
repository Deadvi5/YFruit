using MediatR;

namespace Data.Abstractions.Requests
{
    public class SumRequest : IRequest<int>
    {
        public SumRequest(int first, int second)
        {
            First = first;
            Second = second;
        }

        public int First { get; }
        public int Second { get; }
    }
}