using System;

namespace pc22222u202422620.Clinical.Domain.ValueObjects;


public sealed record PartyId
{

    public Guid Value { get; }



    public PartyId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException(
                "The patient identifier cannot be empty.",
                nameof(value));
            
        }
        Value = value;
    }
    
    
    
    
}