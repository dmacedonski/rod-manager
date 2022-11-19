using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using RodManager.DataAnnotations;

namespace RodManager.Data;

/// <summary>
///     Uprawnienia użytkownika.
/// </summary>
public enum UserPrivilege
{
    /// <summary>
    ///     Pełne uprawnienia, rozszerzają uprawnienia `UserPrivilege.Write` o zarządzanie aplikacją np. tworzenie
    ///     użytkowników.
    /// </summary>
    [Description("Uprawnienia administratora")]
    Admin,

    /// <summary>
    ///     Rozszerzają uprawnienia `UserPrivilege.Read` o możliwość dodawania, edycji i usuwania działek i działkowców.
    /// </summary>
    [Description("Uprawnienia do zmian")]
    Write,

    /// <summary>
    ///     Uprawnienia do przeglądania danych działek i działkowców.
    /// </summary>
    [Description("Uprawniania do odczytu")]
    Read
}

/// <summary>
///     Reprezentuje konto użytkownika.
/// </summary>
public class User
{
    /// <summary>
    ///     Id użytkownika.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     Nazwa użytkownika.
    /// </summary>
    [Required(ErrorMessage = "Nazwa użytkownika jest wymagana.")]
    [MaxLength(50, ErrorMessage = "Nazwa użytkownika nie może być dłuższa niż 50 znaków.")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Imię użytkownika.
    /// </summary>
    [Required(ErrorMessage = "Imię jest wymagane.")]
    [MaxLength(50, ErrorMessage = "Imię nie może być dłuższe niż 50 znaków.")]
    public string GivenName { get; set; } = string.Empty;

    /// <summary>
    ///     Nazwisko użytkownika.
    /// </summary>
    [Required(ErrorMessage = "Nazwisko jest wymagane.")]
    [MaxLength(50, ErrorMessage = "Nazwisko nie może być dłuższe niż 50 znaków.")]
    public string FamilyName { get; set; } = string.Empty;

    /// <summary>
    ///     Uprawnienia użytkownika.
    /// </summary>
    [Required(ErrorMessage = "Podanie uprawnień jest wymagane.")]
    public UserPrivilege Privilege { get; set; }

    /// <summary>
    ///     Adres e-mail użytkownika.
    /// </summary>
    [DataAnnotations.EmailAddress(ErrorMessage = "Podany adres e-mail nie jest poprawny.")]
    public string? EmailAddress { get; set; }

    /// <summary>
    ///     Numer telefonu użytkownika.
    /// </summary>
    [PhoneNumber(ErrorMessage = "Podaj poprawny numer telefonu.")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    ///     Suma kontrolna z hasła użytkownika.
    /// </summary>
    public string? PasswordHash { get; set; }
}