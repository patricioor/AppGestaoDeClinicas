﻿using GeCli.Back.Shared.ModelView.CommunClasses;

namespace GeCli.Back.Shared.ModelView.Customer
{
    /// <summary>
    /// Object used to insert a new customer.
    /// </summary>
    public class NewCustomer : ICloneable
    {
        /// <summary>
        /// Customer's full name.
        /// </summary>
        /// <example>Patrício Osterno Rios</example>
        public string Name { get; set; }

        public NewCustomerAddress Address { get; set; }

        public ICollection<NewCustomerCellphone> Cellphones { get; set; }
        /// <summary>
        /// Customer's Birth day
        /// </summary>
        /// <example>1999-10-20</example>
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// Customer's gender
        /// </summary>
        /// <example>M</example>
        public NewGender Gender { get; set; }
        /// <summary>
        /// Brazilian identification document: CPF(Validation on)
        /// </summary>
        /// <example>79656843061</example>
        public string CPF { get; set; }

        public object Clone()
        {
            var customer = (NewCustomer)MemberwiseClone();
            customer.Address = (NewCustomerAddress)customer.Address.Clone();
            var cellphone = new List<NewCustomerCellphone>();
            customer.Cellphones.ToList().ForEach(p => cellphone.Add((NewCustomerCellphone)p.Clone()));
            customer.Cellphones = cellphone;
            return customer;
        }

        public NewCustomer CloneNewTyped()
        {
            return (NewCustomer)MemberwiseClone();
        }
    }
}
