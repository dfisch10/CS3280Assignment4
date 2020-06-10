using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Assignment_4.tests
{
    [ExcludeFromCodeCoverage]
    public class CalculatorTestData : IEnumerable<object[]>
    {
        #region Methods

        public IEnumerator<object[]> GetEnumerator()
        {
            // Valid
            yield return new object[] { 15, true };
            yield return new object[] { "Mom", true };
            yield return new object[] { "Was it a cat I saw?", true };
            yield return new object[] { "Red rum, sir, is murder", true };
            

            // Invalid
            yield return new object[] { "Yikes", false };
            yield return new object[] { "Hello-World", false };
            yield return new object[] { "  Testing  ", false };
            yield return new object[] { "987654321  ", false };
            yield return new object[] { null, false };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}
