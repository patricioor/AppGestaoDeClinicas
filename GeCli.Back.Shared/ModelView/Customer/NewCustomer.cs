namespace GeCli.Back.Shared.ModelView.Customer
{
    /// <summary>
    /// Object used to insert a new customer.
    /// </summary>
    public class NewCustomer
    {
        /// <summary>
        /// Customer's full name.
        /// </summary>
        /// <example>Patrício Osterno Rios</example>
        public string Name { get; set; }


        public NewAddress Address { get; set; }
        /// <summary>
        /// Customer's cellphone number.
        /// </summary>
        /// <example>11987654321</example>
        public string Cellphone { get; set; }
        /// <summary>
        /// Customer's Birth day
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

        
    }
}
