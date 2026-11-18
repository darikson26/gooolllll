using pc22222u202422620.Clinical.Domain.ValueObjects;
using pc22222u202422620.Shared.Domain.ValueObjects;
using pc22222u202422620.Clinical.Domain;

namespace pc22222u202422620.Clinical.domain.Aggregates;

public class Prescription
{
    private Prescription()
    {
        PrescriptionNumber = null!;
        PatientId = null!;
        TreatmentPeriod = null!;
        DosageLimit = null!;
    }
    public int Id { get; private set; }
    public RoIdentifier PrescriptionNumber { get; private set; }
    public PartyId PatientId{ get; private set; }
    public TreatmentDuration TreatmentPeriod { get; private set; }
    public MedicationDosage DosageLimit{ get; private set; }
    public PrescriptionStatus  Status { get; private set; }
    public string? ClinicalNotes{get;private set;}
    public DateTime CreateReceta{get;private set;}
    public DateTime UpdateReceta{get;private set;}

    public Prescription(RoIdentifier prescriptionNumber, PartyId patientId,
        TreatmentDuration treatmentPeriod, MedicationDosage dosageLimit,
        PrescriptionStatus status = PrescriptionStatus.Draft,
        string? clinicalNotes = null)
    {
        PrescriptionNumber =  prescriptionNumber;
        PatientId = patientId;
        TreatmentPeriod = treatmentPeriod;
        ClinicalNotes = clinicalNotes;
        Status = status;
        DosageLimit = dosageLimit;
        
        CreateReceta = DateTime.UtcNow;
        UpdateReceta = DateTime.UtcNow;

    }
    
    
}