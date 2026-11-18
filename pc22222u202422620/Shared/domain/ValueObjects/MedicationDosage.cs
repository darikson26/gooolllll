namespace pc22222u202422620.Shared.Domain.ValueObjects;


public sealed record MedicationDosage
{
    
    public int DailyQuantity { get; }
    public string ActiveIngredient { get; }


    public MedicationDosage(int dailyQuantity, string activeIngredient)
    {
        if (dailyQuantity <= 0 || dailyQuantity > 4)
        {
            throw new ArgumentOutOfRangeException("Fuera de rango", nameof(dailyQuantity));
        }

        if (string.IsNullOrWhiteSpace(activeIngredient) || activeIngredient.Length < 3
                                                        || activeIngredient.Length > 15 || activeIngredient !=
                                                        activeIngredient.ToUpperInvariant())
        {
            throw new ArgumentException(
                "Active ingredient must contain 3 to 15 uppercase characters.",
                nameof(activeIngredient));
        }
        DailyQuantity = dailyQuantity;
        ActiveIngredient = activeIngredient;
        
    }
    public int CalculateTotalDoses(int totalDays)
    {
        return  DailyQuantity * totalDays;
    }
    
}


