using Microsoft.VisualStudio.TestTools.UnitTesting;
using RodManager.DataAnnotations;

namespace RodManagerTests.DataAnnotations;

[TestClass]
public class PeselAttributeTests
{
    [TestMethod]
    public void TestIsValid()
    {
        PeselAttribute validator = new();
        Assert.IsTrue(validator.IsValid(null), "Method `isValid` should return `true` for value `null`.");
        Assert.IsTrue(validator.IsValid(""), "Method `isValid` should return `true` for value empty string.");
        Assert.IsTrue(validator.IsValid("06292995987"), "Method `isValid` should return `true` for correct PESEL number.");
        Assert.IsFalse(validator.IsValid("06292995988"), "Method `isValid` should return `false` for incorrect PESEL number.");
        Assert.IsFalse(validator.IsValid("random_text"), "Method `isValid` should return `false` for incorrect PESEL number.");
    }
}