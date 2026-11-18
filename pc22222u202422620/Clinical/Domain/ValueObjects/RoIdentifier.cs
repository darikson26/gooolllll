using System.Text.RegularExpressions;

namespace pc22222u202422620.Clinical.Domain.ValueObjects;

public sealed record RoIdentifier
{
    
    public string Value { get; }

    public RoIdentifier(string value)
    {

        if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"\ARX-[0-9]{6}\z"))
        {
            throw new ArgumentException("The prescription number must have the format RX-000000.", nameof(value));
        }
        Value = value;
    }
   
}