using Microsoft.EntityFrameworkCore;
using pc22222u202422620.Clinical.domain.Aggregates;
using pc22222u202422620.Clinical.domain.Repositories;
using pc22222u202422620.Clinical.Domain.ValueObjects;
using pc22222u202422620.Clinical.Infrastructure.Persistence;

namespace pc22222u202422620.Clinical.Infrastructure.Persistence;

public class PrescriptionRepository: IPrescriptionRepository
{
    
    private readonly RoDbContext _context;
    
    public PrescriptionRepository(RoDbContext context)
    {
        _context = context;
    }
    public async Task<bool> ExistsByPrescriptionNumberAsync(RoIdentifier prescriptionNumber)
    {
        return await _context.Prescriptions
            .AnyAsync(prescription => prescription.PrescriptionNumber == prescriptionNumber);
    }
    public async Task AddAsync(Prescription prescription)
    {
        await _context.Prescriptions.AddAsync(prescription);
        await _context.SaveChangesAsync();
    }
    
}