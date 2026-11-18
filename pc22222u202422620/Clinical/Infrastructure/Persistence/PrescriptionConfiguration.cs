using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pc22222u202422620.Clinical.Domain;
using pc22222u202422620.Clinical.Domain.ValueObjects;
using pc22222u202422620.Clinical.domain.Aggregates;

namespace pc22222u202422620.Clinical.Infrastructure.Persistence;


public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{

    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.ToTable("prescriptions");

        builder.HasKey(prescription => prescription.Id);

        builder.Property(prescription => prescription.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(prescription => prescription.PrescriptionNumber)
            .HasConversion(
                identifier => identifier.Value,
                value => new RoIdentifier(value))
            .HasColumnName("prescription_number")
            .HasMaxLength(9)
            .IsRequired();

        builder.HasIndex(prescription => prescription.PrescriptionNumber)
            .IsUnique();

        builder.Property(prescription => prescription.PatientId)
            .HasConversion(
                patientId => patientId.Value,
                value => new PartyId(value))
            .HasColumnName("patient_id")
            .IsRequired();

        builder.OwnsOne(prescription => prescription.TreatmentPeriod, treatment =>
        {
            treatment.Property(value => value.StartDate)
                .HasColumnName("start_date")
                .IsRequired();

            treatment.Property(value => value.EndDate)
                .HasColumnName("end_date")
                .IsRequired();
        });

        builder.OwnsOne(prescription => prescription.DosageLimit, dosage =>
        {
            dosage.Property(value => value.DailyQuantity)
                .HasColumnName("daily_quantity")
                .IsRequired();

            dosage.Property(value => value.ActiveIngredient)
                .HasColumnName("active_ingredient")
                .HasMaxLength(15)
                .IsRequired();
        });

        builder.Property(prescription => prescription.Status)
            .HasColumnName("status")
            .IsRequired();

        builder.Property(prescription => prescription.ClinicalNotes)
            .HasColumnName("clinical_notes")
            .IsRequired(false);

        builder.Property(prescription => prescription.CreateReceta)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(prescription => prescription.UpdateReceta)
            .HasColumnName("updated_at")
            .IsRequired();
    }
}