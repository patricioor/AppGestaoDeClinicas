﻿using GeCli.Back.Domain.Entities.AbstractClasses;

namespace GeCli.Back.Domain.Entities.Employees;
public sealed class Dentist : Entity
{
    public string Name { get; set; }
    public ICollection<DentistCellphone> Cellphones { get; set; }
    public DateTime BirthDay { get; set; }
    public Gender Gender { get; set; }
    public string CPF { get; set; }
    public DentistAddress Address { get; set; }
    public string CRO { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? LastUpdate { get; set; }
    public ICollection<Specialty> Specialties { get; set; }
    //public int EmploymentId { get; set; }
    //public Employment Employment { get; set; }

    //public MedicalRecord MedicalRecord { get; set; }
}
