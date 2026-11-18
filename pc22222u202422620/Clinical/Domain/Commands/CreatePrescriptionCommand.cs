
using pc22222u202422620.Clinical.Domain.ValueObjects;
using pc22222u202422620.Shared.Domain.ValueObjects;

namespace pc22222u202422620.Clinical.Domain.Commands;

public record CreatePrescriptionCommand(
    PartyId RoutePatientId,
    RoIdentifier PrescriptionNumber,
    PartyId PatientId,
    TreatmentDuration TreatmentPeriod,
    MedicationDosage DosageLimit,
    PrescriptionStatus Status = PrescriptionStatus.Draft,
    string? ClinicalNotes = null
);
