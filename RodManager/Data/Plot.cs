using System.ComponentModel.DataAnnotations;

namespace RodManager.Data;

/// <summary>
///     Reprezentuje działkę.
/// </summary>
public class Plot
{
    /// <summary>
    ///     Lista działkowców przypisanych do działki.
    /// </summary>
    public List<AllotmentFarmer> AllotmentFarmers = new();
    
    /// <summary>
    ///     Identyfikator działki.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     Numer działki.
    /// </summary>
    [Required(ErrorMessage = "Numer działki jest wymagany.")]
    public string Number { get; set; } = string.Empty;

    /// <summary>
    ///     Rozmiar działki w metrach kwadratowych.
    /// </summary>
    [Required(ErrorMessage = "Wielkość działki jest wymagana.")]
    public decimal AreaSize { get; set; }

    /// <summary>
    ///     Czy na terenie działki znajduje się końcowa skrzynka rozdzielcza.
    /// </summary>
    public bool HasFinalDistributionBox { get; set; }

    /// <summary>
    ///     Numer końcowej skrzynki rozdzielczej, do której podłączona jest działka.
    /// </summary>
    public string? FinalDistributionBoxNumber { get; set; }

    /// <summary>
    ///     Numer magistralnej skrzynki rozdzielczej, do której podłączona jest działka.
    /// </summary>
    public string? MasterBoxNumber { get; set; }

    /// <summary>
    ///     Numer licznika prądu.
    /// </summary>
    public string? ElectricityMeterNumber { get; set; }

    /// <summary>
    ///     Numer licznika wody.
    /// </summary>
    public string? WaterMeterNumber { get; set; }
}