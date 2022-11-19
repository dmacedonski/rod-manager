using Microsoft.VisualStudio.TestTools.UnitTesting;
using RodManager.DataAnnotations;

namespace RodManagerTests.DataAnnotations;

[TestClass]
public class EmailAddressAttributeTests
{
    [TestMethod]
    public void TestIsValid()
    {
        EmailAddressAttribute validator = new();
        Assert.IsTrue(validator.IsValid(null), "Method `isValid` should return `true` for value `null`.");
        Assert.IsTrue(validator.IsValid(""), "Method `isValid` should return `true` for value empty string.");
        Assert.IsTrue(validator.IsValid("jdoe@example.com"), "Method `isValid` should return `true` for correct email address.");
        Assert.IsFalse(validator.IsValid("jdoe.example.com"), "Method `isValid` should return `true` for incorrect email address.");
    }
}