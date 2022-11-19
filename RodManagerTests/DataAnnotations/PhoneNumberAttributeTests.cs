using Microsoft.VisualStudio.TestTools.UnitTesting;
using RodManager.DataAnnotations;

namespace RodManagerTests.DataAnnotations;

[TestClass]
public class PhoneNumberAttributeTests
{
    [TestMethod]
    public void TestIsValid()
    {
        PhoneNumberAttribute validator = new();
        Assert.IsTrue(validator.IsValid(null), "Method `isValid` should return `true` for value `null`.");
        Assert.IsTrue(validator.IsValid(""), "Method `isValid` should return `true` for value empty string.");
        Assert.IsTrue(validator.IsValid("+48 422 333 444"), "Method `isValid` should return `true` for correct phone number.");
        Assert.IsTrue(validator.IsValid("422 333 444"), "Method `isValid` should return `true` for correct phone number.");
        Assert.IsFalse(validator.IsValid("+48 422"), "Method `isValid` should return `false` for incorrect phone number.");
        Assert.IsFalse(validator.IsValid("random_string"), "Method `isValid` should return `false` for incorrect phone number.");
    }
}