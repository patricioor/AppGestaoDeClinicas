﻿using Bogus;
using Bogus.Extensions.Brazil;
using GeCli.Back.Domain.Entities.AbstractClasses;
using GeCli.Back.Domain.Entities.Customers;

namespace GeCli.FakeData.CustomerData;
public class CustomerFake : Faker<Customer>
{
    public CustomerFake()
    {
        var id = new Faker().Random.Number(1, 9999);
        RuleFor(x => x.Id, _ => id);
        RuleFor(x => x.Name, f => f.Person.FullName);
        RuleFor(x => x.Gender, f => f.PickRandom<Gender>());
        RuleFor(x => x.CPF, f => f.Person.Cpf());
        RuleFor(x => x.CreationDate, f => f.Date.Past());
        RuleFor(x => x.LastUpdate, f => f.Date.Past());
        RuleFor(x => x.Cellphones, _ => new CustomerCellphonesFake(id).Generate(3));
        RuleFor(x => x.Address, _ => new CustomerAddressFake(id).Generate());
        RuleFor(x => x.BirthDay, f => f.Date.Past());
    }
}
