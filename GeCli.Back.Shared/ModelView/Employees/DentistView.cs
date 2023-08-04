using GeCli.Back.Shared.ModelView.CommunClasses;

namespace GeCli.Back.Shared.ModelView.Employees
{
    public class DentistView : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DentistAddressView Address { get; set; }

        public ICollection<DentistCellphoneView> Cellphones { get; set; }

        public ICollection<SpecialtyView> Specialties { get; set; }

        public DateTime BirthDay { get; set; }

        public NewGender Gender { get; set; }

        public string CPF { get; set; }

        public string CRO { get; set; }

        public object Clone()
        {
            var dentist = (DentistView)MemberwiseClone();
            dentist.Address = (DentistAddressView)dentist.Address.Clone();
            var cellphone = new List<DentistCellphoneView>();
            dentist.Cellphones.ToList().ForEach(p => cellphone.Add((DentistCellphoneView)p.Clone()));
            dentist.Cellphones = cellphone;
            return dentist;
        }

        public DentistView CloneTyped()
        {
            return (DentistView)MemberwiseClone();
        }
    }
}
