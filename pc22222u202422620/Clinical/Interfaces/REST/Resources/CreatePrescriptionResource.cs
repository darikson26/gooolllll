namespace pc22222u202422620.Clinical.interfaces.REST.Resources;

public class CreatePrescriptionResource
{
    public string PrescriptionNumber { get; set; } = string.Empty;
    public string PatientId { get; set; } = string.Empty;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int DailyQuantity { get; set; }
    public string ActiveIngredient { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? ClinicalNotes { get; set; }
}