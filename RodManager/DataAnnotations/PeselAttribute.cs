using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RodManager.DataAnnotations;

/// <summary>
///     Pozwala sprawdzić, czy podana wartość jest prowidłowym numerem PESEL.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class PeselAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        string? valueAsString = value as string;

        if (string.IsNullOrEmpty(valueAsString))
        {
            return true;
        }
        if (!Regex.IsMatch(valueAsString, @"^[\d]{11}$"))
        {
            return false;
        }

        int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        int sum = 10 - int.Parse(weights.Select((weight, index) => weight * int.Parse(valueAsString[index].ToString())).Sum().ToString().Last().ToString());

        return int.Parse(valueAsString.Last().ToString()) == sum;
    }
}