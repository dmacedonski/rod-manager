using System.ComponentModel.DataAnnotations;

using RodManager.DataAnnotations;

namespace RodManager.Data;

/// <summary>
///     Reprezentuje działkowca.
/// </summary>
public class AllotmentFarmer
{
    /// <summary>
    ///     Identyfikator działkowca.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     Imię działkowca.
    /// </summary>
    [Required(ErrorMessage = "Imię działkowca jest wymagane.")]
    [MaxLength(50, ErrorMessage = "Imię działkowca nie może być dłuższe niż 50 znaków.")]
    public string GivenName { get; set; } = string.Empty;

    /// <summary>
    ///     Nazwisko działkowca.
    /// </summary>
    [Required(ErrorMessage = "Nazwisko działkowca jest wymagane.")]
    [MaxLength(50, ErrorMessage = "Nazwisko działkowca nie może być dłuższe niż 50 znaków.")]
    public string FamilyName { get; set; } = string.Empty;

    /// <summary>
    ///     Adres korespondencyjny.
    /// </summary>
    [Required(ErrorMessage = "Adres korespondencyjny jest wymagany.")]
    [MaxLength(255, ErrorMessage = "Adres korespondencyjny nie może być dłuższy niż 255 znaków.")]
    public string CorrespondenceAddress { get; set; } = string.Empty;

    /// <summary>
    ///     Adres zamieszkania.
    /// </summary>
    [Required(ErrorMessage = "Adres zamieszkania jest wymagany.")]
    [MaxLength(255, ErrorMessage = "Adres zamieszkania nie może być dłuższy niż 255 znaków.")]
    public string Address { get; set; } = string.Empty;

    /// <summary>
    ///     Numer PESEL.
    /// </summary>
    [Required(ErrorMessage = "PESEL działkowca jest wymagany.")]
    [Pesel(ErrorMessage = "Podaj poprawny numer PESEL działkowca.")]
    public string Pesel { get; set; } = string.Empty;

    /// <summary>
    ///     Adres e-mail.
    /// </summary>
    [DataAnnotations.EmailAddress(ErrorMessage = "Podaj poprawny adres e-mail.")]
    public string? EmailAddress { get; set; }

    /// <summary>
    ///     Numer telefonu.
    /// </summary>
    [PhoneNumber(ErrorMessage = "Podaj poprawny numer telefonu.")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    ///     Data wstąpienia do stowarzyszenia działkowców.
    /// </summary>
    public DateTime? JoiningAllotmentAssociationDate { get; set; }

    /// <summary>
    ///     Adres e-mail do wysyłki zaproszeń na walne zebrania.
    /// </summary>
    [DataAnnotations.EmailAddress(ErrorMessage = "Podaj poprawny adres e-mail dla zaproszeń.")]
    public string? EmailAddressForInvitation { get; set; }

    /// <summary>
    ///     Wyrażono zgodę na przetwarzanie danych RODO.
    /// </summary>
    public bool RodoAgreement { get; set; }

    /// <summary>
    ///     Wyrażono zgodę na publikację opłat.
    /// </summary>
    public bool FeesPublicationAgreement { get; set; }

    /// <summary>
    ///     Wyrażono zgodę na dostęp do końcowej skrzyni rozdzielczej.
    /// </summary>
    public bool FinalDistributionBoxAccessAgreement { get; set; }

    /// <summary>
    ///     Identyfikator działki przypisanej do działkowca.
    /// </summary>
    public Guid? PlotId { get; set; }

    /// <summary>
    ///     Informacje o działce przypisanej do działkowca.
    /// </summary>
    public Plot? Plot { get; set; }

    /// <summary>
    ///     Zwraca `true` jeśli działkowiec ma przypisaną działkę.
    /// </summary>
    public bool HasPlot => PlotId is not null;
}