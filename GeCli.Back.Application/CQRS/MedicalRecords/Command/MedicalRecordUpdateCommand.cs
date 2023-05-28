namespace GeCli.Back.Application.CQRS.MedicalRecords.Command
{
    public class MedicalRecordUpdateCommand : MedicalRecordCommand
    {
        public int Id { get; set; }
    }
}
