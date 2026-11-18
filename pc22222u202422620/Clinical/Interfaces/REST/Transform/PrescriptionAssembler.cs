using System;
using pc22222u202422620.Clinical.Domain;
using pc22222u202422620.Clinical.Domain.Commands;
using pc22222u202422620.Clinical.Domain.ValueObjects;
using pc22222u202422620.Clinical.domain.Aggregates;
using pc22222u202422620.Clinical.interfaces.REST.Resources;
using pc22222u202422620.Shared.Domain.ValueObjects;

namespace pc22222u202422620.Clinical.Interfaces.REST.Transform;

public static class PrescriptionAssembler
{
    public static CreatePrescriptionCommand ToCommand(
        CreatePrescriptionResource resource,
        Guid routePatientId)
    {
        PartyId routeId = new PartyId(routePatientId);
        PartyId bodyPatientId = new PartyId(Guid.Parse(resource.PatientId));

        PrescriptionStatus status =
            Enum.Parse<PrescriptionStatus>(resource.Status, ignoreCase: true);

        return new CreatePrescriptionCommand(
            routeId,
            new RoIdentifier(resource.PrescriptionNumber),
            bodyPatientId,
            new TreatmentDuration(resource.StartDate, resource.EndDate),
            new MedicationDosage(resource.DailyQuantity, resource.ActiveIngredient),
            status,
            resource.ClinicalNotes);
    }

    public static PrescriptionResource ToResource(Prescription prescription)
    {
        return new PrescriptionResource
        {
            Id = prescription.Id,
            PrescriptionNumber = prescription.PrescriptionNumber.Value,
            PatientId = prescription.PatientId.Value.ToString(),
            StartDate = prescription.TreatmentPeriod.StartDate,
            EndDate = prescription.TreatmentPeriod.EndDate,
            DailyQuantity = prescription.DosageLimit.DailyQuantity,
            ActiveIngredient = prescription.DosageLimit.ActiveIngredient,
            Status = prescription.Status.ToString(),
            ClinicalNotes = prescription.ClinicalNotes
        };
    }
}