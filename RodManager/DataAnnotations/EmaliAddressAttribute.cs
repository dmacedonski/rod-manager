using System.ComponentModel.DataAnnotations;

namespace RodManager.DataAnnotations;

/// <summary>
///     Pozwala sprawdzić, czy podana wartość jest poprawnym adresem e-mail.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class EmailAddressAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        string? valueAsString = value as string;
        return string.IsNullOrEmpty(valueAsString) || new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(value);
    }
}