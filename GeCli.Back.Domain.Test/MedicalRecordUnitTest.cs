using FluentAssertions;
using GeCli.Back.Domain.Entities;
using Xunit;

namespace GeCli.Back.Domain.Test
{
    public class MedicalRecordUnitTest
    {
        [Fact(DisplayName = "Create Medical Record With Valid State")]
        public void CreateMedicalRecord_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new MedicalRecord(1, "New Medical Record", "New Complaint", "New Medicate", "New Allergy", "New Disease", "New Surgery", true, false, "New Medical Recorder");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Medical Record With Invalid Id Value")]
        public void CreateMedicalRecord_WithNegativoIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new MedicalRecord(-1, "New Medical Record", "New Complaint", "New Medicate", "New Allergy", "New Disease", "New Surgery", true, false, "New Medical Recorder");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid 'id' value");
        }

        [Fact(DisplayName = "Create Medical Record With Null Name Value")]
        public void CreateMedicalRecord_WithNullNameValue_DomianExceptionInvalidName()
        {
            Action action = () => new MedicalRecord(1, null, "New Complaint", "New Medicate", "New Allergy", "New Disease", "New Surgery", true, false, "New Medical Recorder");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Medical Record With Short Name")]
        public void CreateMedicalRecord_WithShortName_DomainExceptionShortName()
        {
            Action action = () => new MedicalRecord(1, "Ne", "New Complaint", "New Medicate", "New Allergy", "New Disease", "New Surgery", true, false, "New Medical Recorder");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid name. Too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Medical Record With Null Complaint Value")]
        public void CreateMedicalRecord_WithNullComplaintValue_DomainExceptionInvalidComplaint()
        {
            Action action = () => new MedicalRecord(1, "New Medical Record", null, "New Medicate", "New Allergy", "New Disease", "New Surgery", true, false, "New Medical Recorder");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid complaint. Complaint is required");
        }

        [Fact(DisplayName = "Create Medical Record With Out Limit Complaint Length")]
        public void CreateMedicalRecord_WithOutLimitComplaintLength_DomainExceptionOutLimitComplaintLength()
        {
            Action action = () => new MedicalRecord(1, "New Medical Record", "New ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew ComplaintNew Complaint"
                , "New Medicate", "New Allergy", "New Disease", "New Surgery", true, false, "New Medical Recorder");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Too long. The complaint can only have a maximum of 1000 characters");
        }

        [Fact(DisplayName = "Create Medical Record With Out Limit Medicate Length")]
        public void CreateMedicalRecord_WithOutLimitMedicateLength_DomainExceptionLongMedicateLenght()
        {
            Action action = () => new MedicalRecord(1, "New Medical Record", "New Complaint", "New MedicateNew MedicateNew MedicateNew MedicateNew MedicateNew MedicateNew MedicateNew MedicateNew MedicateNew MedicateNew Medicate"
                , "New Allergy", "New Disease", "New Surgery", true, false, "New Medical Recorder");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Too long. The medicate can only have a maximum of 100 characters.");
        }

        [Fact(DisplayName = "Create Medical Record With Out Limit Allergy Length")]
        public void CreateMedicalRecord_WithOutLimitAllergyLength_DomainExceptionLongAllergyLength()
        {
            Action action = () => new MedicalRecord(1, "New Medical Record", "New Complaint", "New Medicate", "New AllergyNew AllergyNew AllergyNew AllergyNew AllergyNew AllergyNew AllergyNew AllergyNew AllergyNew AllergyNew Allergy"
                , "New Disease", "New Surgery", true, false, "New Medical Recorder");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Too long. The complaint can only have a maximum of 100 characters.");
        }

        [Fact(DisplayName = "Create Medical Record With Out Limit Disease Length")]
        public void CreateMedicalRecord_WithOutLimitDiseaseLengjth_DomainExceptionLongDiseaseLength()
        {
            Action action = () => new MedicalRecord(1, "New Medical Record", "New Complaint", "New Medicate", "New Allergy", "New DiseaseNew DiseaseNew DiseaseNew DiseaseNew DiseaseNew DiseaseNew DiseaseNew DiseaseNew DiseaseNew DiseaseNew Disease"
                , "New Surgery", true, false, "New Medical Recorder");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Too long. The complaint can only have a maximum of 100 characters.");
        }

        [Fact(DisplayName = "Create Medical Record With Out Limit Surgery Length")]
        public void CreateMedicalRecord_WithOutLimitSurgeryLength_DomainExceptionLongSurgeryLength()
        {
            Action action = () => new MedicalRecord(1, "New Medical Record", "New Complaint", "New Medicate", "New Allergy", "New Disease", "New SurgeryNew SurgeryNew SurgeryNew SurgeryNew SurgeryNew SurgeryNew SurgeryNew SurgeryNew SurgeryNew SurgeryNew Surgery"
                , true, false, "New Medical Recorder");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Too long. The complaint can only have a maximum of 100 characters.");
        }

        [Fact(DisplayName = "Create Medical Record With Null MedRecord Value")]
        public void CreateMedicalRecord_WithNullMedRecordValue_DomainExceptionInvalidMedRecord()
        {
            Action action = () => new MedicalRecord(1, "New Medical Record", "New Complaint", "New Medicate", "New Allergy", "New Disease", "New Surgery", true, false, null);
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid Medical Record.Medical record is required");
        }

        [Fact(DisplayName = "Create Medical Record With Out Limit MedRecord Length")]
        public void CreateMedicalRecord_WithOutLimitMedRecordLength_DomainExceptionLongMedRecordLength()
        {
            Action action = () => new MedicalRecord(1, "New Medical Record", "New Complaint", "New Medicate", "New Allergy", "New Disease", "New Surgery", true, false, "New Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical RecorderNew Medical Recordera");            
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("The medical record can only have a maximum of 5000 characters.");
        }
    }
}
