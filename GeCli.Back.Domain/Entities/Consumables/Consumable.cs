﻿using GeCli.Back.Domain.Entities.AbstractClasses;
using GeCli.Back.Domain.Entities.Suppliers;
using System.Text.Json.Serialization;

namespace GeCli.Back.Domain.Entities.Consumables;
public sealed class Consumable : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stock { get; protected set; }
    public decimal Price { get; protected set; }
    public Category Category { get; set; }

    [JsonIgnore]
    public ICollection<Supplier> Suppliers { get; set; }
    //public ICollection<Procedure> Procedures { get; set; }

}
