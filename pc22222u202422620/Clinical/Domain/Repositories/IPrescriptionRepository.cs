using pc22222u202422620.Clinical.domain.Aggregates;
using pc22222u202422620.Clinical.Domain.ValueObjects;
using System.Threading.Tasks;
namespace pc22222u202422620.Clinical.domain.Repositories;

public interface IPrescriptionRepository
{
    
    Task<bool> ExistsByPrescriptionNumberAsync(RoIdentifier prescriptionNumber);
    
    Task AddAsync(Prescription prescription);
    
    
    
    
}