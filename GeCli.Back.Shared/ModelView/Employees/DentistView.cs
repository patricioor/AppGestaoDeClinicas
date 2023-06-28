namespace GeCli.Back.Shared.ModelView.Employees
{
    public class DentistView
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DentistAddressView Address { get; set; }

        public IEnumerable<DentistCellphoneView> Cellphones { get; set; }

        public IEnumerable<SpecialtyView> Specialties { get; set; }

        public DateTime BirthDay { get; set; }

        public char Gender { get; set; }

        public string CPF { get; set; }

        public string CRO { get; set; }


    }
}
