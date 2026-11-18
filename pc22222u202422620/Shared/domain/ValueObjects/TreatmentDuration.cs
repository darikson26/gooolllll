namespace pc22222u202422620.Shared.Domain.ValueObjects;


public sealed record TreatmentDuration
{
    
    public DateOnly StartDate { get; }
    public DateOnly EndDate { get; }


    public TreatmentDuration(DateOnly startDate, DateOnly endDate)
    {
        if (endDate <= startDate)
        {
            throw new ArgumentException("End date must be greater than start date.", nameof(endDate));
        }
        var totalDays = endDate.DayNumber-startDate.DayNumber;
        if (totalDays > 90)
        {
            throw new ArgumentException("Supero los 90 dias",nameof(endDate));
        }
        StartDate = startDate;
        EndDate = endDate;
        
    }

    public bool IsActiveOn(DateOnly checkDate)
    {
        
        return checkDate>=StartDate && checkDate<=EndDate;
        
    }
    
    
    
    
}