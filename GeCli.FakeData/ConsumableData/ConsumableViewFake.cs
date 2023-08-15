﻿using Bogus;
using GeCli.FakeData.SupplierData;
using GeCli.Back.Shared.ModelView.Consumable;
using GeCli.FakeData.CategoryData;

namespace GeCli.FakeData.ConsumableData;

public class ConsumableViewFake : Faker<ConsumableView>
{
    public ConsumableViewFake()
    {
        var id = new Faker().Random.Number(1, 9999);
        RuleFor(p => p.Id, _ => id);
        RuleFor(p => p.Name, f => f.Lorem.Word());
        RuleFor(p => p.Description, f => f.Lorem.Sentences(5));
        RuleFor(p => p.Price, f => f.Random.Decimal(0.01m, 9999.00m));
        RuleFor(p => p.Stock, f => f.Random.Number(1, 100));
        RuleFor(p => p.Category, f => new CategoryViewFake());
        RuleFor(p => p.Suppliers, f => new SupplierReferenceFake().Generate(3));
    }
}
