namespace Data.Abstractions.Models
{
    public class OperationDto
    {
        public OperationDto(int first, int second)
        {
            First = first;
            Second = second;
        }
        public int First { get; }
        public int Second { get; }
    }
}