using System;
using System.Threading.Tasks;
using Data.Abstractions;
using Data.Abstractions.Models;

namespace Data
{
    public class SubtractOperation : IOperationData
    {
        public Task<int> Calculate(OperationDto parameter)
        {
            return Task.FromResult(CalculateInternal(parameter));
        }

        #region Private Members

        private static int CalculateInternal(OperationDto parameter)
        {
            if (parameter is null) throw new ArgumentNullException(nameof(parameter));
            return parameter.First - parameter.Second;
        }

        public override string ToString()
        {
            return "Sottrazione";
        }
        #endregion
    }
}