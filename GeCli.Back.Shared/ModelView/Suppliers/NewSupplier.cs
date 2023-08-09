namespace GeCli.Back.Shared.ModelView.Suppliers;

public class NewSupplier : ICloneable
{
    public string Name { get; set; }
    public string CNPJ { get; set; }
    public NewSupplierAddress Address { get; set; }
    public ICollection<NewSupplierCellphone> Cellphones{ get; set; }
    public string Vendor { get; set; }

    public object Clone()
    {
        var supplier = (NewSupplier)MemberwiseClone();
        supplier.Address = (NewSupplierAddress)supplier.Address.Clone();
        var cellphone = new List<NewSupplierCellphone>();
        supplier.Cellphones.ToList().ForEach(p => cellphone.Add((NewSupplierCellphone)p.Clone()));
        supplier.Cellphones = cellphone;
        return supplier;
    }

    public NewSupplier CloneNewTyped()
    {
        return (NewSupplier)MemberwiseClone();
    }
}
