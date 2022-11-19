using System.ComponentModel.DataAnnotations;

using PhoneNumbers;

namespace RodManager.DataAnnotations;

/// <summary>
///     Pozwala sprawdzić, czy podana wartość jest prawidłowym numerem telefony.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class PhoneNumberAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        string? valueAsString = value as string;

        if (string.IsNullOrEmpty(valueAsString))
        {
            return true;
        }
        
        try
        {
            PhoneNumberUtil? phoneNumberUtil = PhoneNumberUtil.GetInstance();
            PhoneNumber? phoneNumber = phoneNumberUtil.Parse(valueAsString, RegionCode.PL);
            return phoneNumberUtil.IsValidNumber(phoneNumber);
        }
        catch (NumberParseException)
        {
            return false;
        }
    }
}