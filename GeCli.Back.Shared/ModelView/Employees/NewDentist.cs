namespace GeCli.Back.Shared.ModelView.Employees
{
    /// <summary>
    /// Object used to insert a new Dentist.
    /// </summary>
    public class NewDentist
    {
        /// <summary>
        /// Dentist's full name.
        /// </summary>
        /// <example>Patrício Osterno Rios</example>
        public string Name { get; set; }

        public NewDentistAddress Address { get; set; }

        public IEnumerable<SpecialtyReference> Specialties { get; set; }

        public IEnumerable<NewDentistCellphone> Cellphones { get; set; }
        /// <summary>
        /// Dentist's Birth day
        /// </summary>
        /// <example>1999-10-20</example>
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// Customer's gender
        /// </summary>
        /// <example>M</example>
        public char Gender { get; set; }
        /// <summary>
        /// Brazilian identification document: CPF(Validation on)
        /// </summary>
        /// <example>79656843061</example>
        public string CPF { get; set; }

        /// <summary>
        /// Dentist certification document: CRO
        /// </summary>
        /// <example>CE12345</example>
        public string CRO { get; set; }
    }
}
