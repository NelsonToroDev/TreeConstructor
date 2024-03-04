using TreeConstructor;

namespace TestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(new string[] { "(1,2)", "(2,4)", "(5,7)", "(7,2)", "(9,5)" }, true)]
        [InlineData(new string[] { "(1,2)", "(3,2)", "(2,12)", "(5,2)" }, false)]
        public void Test1(string[] strArr, bool expected)
        {
            bool result = ProgramTreeConstructor.TreeConstructor(strArr);
            Assert.Equal(expected, result);
        }

        /// 
        /// 4
        /// 2
        /// 1   7
        ///     5
        ///     9
        /// 
        ///
    }
}