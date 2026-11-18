using System;
using System.Threading.Tasks;
using pc22222u202422620.Clinical.Domain.Commands;
using pc22222u202422620.Clinical.domain.Aggregates;
using pc22222u202422620.Clinical.domain.Repositories;

namespace pc22222u202422620.Clinical.Application;

//dotnet ef migrations add InitialCreate
public class PrescriptionCommandService
{
    private readonly IPrescriptionRepository _prescriptionRepository;

 
    public PrescriptionCommandService(IPrescriptionRepository prescriptionRepository)
    {
        _prescriptionRepository = prescriptionRepository;
    }

   
    public async Task<Prescription> HandleAsync(CreatePrescriptionCommand command)
    {
        if (command.RoutePatientId.Value != command.PatientId.Value)
        {
            throw new InvalidOperationException(
                "The patient ID in the route must match the patient ID in the request body.");
        }

        bool numberAlreadyExists =
            await _prescriptionRepository.ExistsByPrescriptionNumberAsync(command.PrescriptionNumber);

        if (numberAlreadyExists)
        {
            throw new InvalidOperationException(
                "A prescription with this number already exists.");
        }

        Prescription prescription = new Prescription(
            command.PrescriptionNumber,
            command.PatientId,
            command.TreatmentPeriod,
            command.DosageLimit,
            command.Status,
            command.ClinicalNotes);

        await _prescriptionRepository.AddAsync(prescription);

        return prescription;
    }
}