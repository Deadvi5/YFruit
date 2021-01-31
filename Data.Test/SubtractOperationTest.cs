using System;
using System.Threading.Tasks;
using Data.Abstractions;
using Data.Abstractions.Models;
using Xunit;

namespace Data.Test
{
    public class SubtractOperationTest
    {
        private readonly IOperationData sut;
        public SubtractOperationTest()
        {
            sut = new SubtractOperation();
        }
        
        [Fact]
        public void Calculate_Should_Throw_Null_If_Parameter_Is_Null()
        {
            //Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await sut.Calculate(null));
        }
        
        [Theory]
        [InlineData(2,1,1)]
        [InlineData(0,1,-1)]
        [InlineData(-1,3,-4)]
        public async Task Calculate_Should_Return_Result_Correctly(int a, int b, int result)
        {
            //Arrange
            var parameter = new OperationDto(a, b);
            
            //Act
            var calculatedResult =  await sut.Calculate(parameter);
            
            //Assert
            Assert.IsType<int>(result);
            Assert.Equal(result, calculatedResult);
        }

        [Fact]
        public void ToString_Should_Return_Correct_Result()
        {
            Assert.Equal("Sottrazione", sut.ToString());
        }
    }
}