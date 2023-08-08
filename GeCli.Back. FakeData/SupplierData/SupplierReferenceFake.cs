﻿using Bogus;
using GeCli.Back.Shared.ModelView.Suppliers;

namespace GeCli.Back._FakeData.SupplierData;

public class SupplierReferenceFake : Faker<SupplierReference>
{
    public SupplierReferenceFake()
    {
        var id = new Faker().Random.Number(1, 9999);
        RuleFor(p => p.Id, _ => id);
    }
}
