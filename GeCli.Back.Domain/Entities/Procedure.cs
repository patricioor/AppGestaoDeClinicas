﻿using GeCli.Back.Domain.Entities.AbstractClasses;

namespace GeCli.Back.Domain.Entities
{
    public sealed class Procedure : Entity
    {
        public MedicalRecord MedicalRecord { get; set; }

        public int ConsumableId { get; set; }
        public ICollection<Consumable> Consumables { get; set; }
    }
}
