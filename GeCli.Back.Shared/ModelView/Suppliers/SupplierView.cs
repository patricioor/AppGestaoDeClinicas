namespace GeCli.Back.Shared.ModelView.Suppliers;

public class SupplierView : ICloneable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CNPJ { get; set; }
    public SupplierAddressView Address { get; set; }
    public ICollection<SupplierCellphoneView> Cellphones { get; set; }
    public string Vendor { get; set; }

    public object Clone()
    {
        var supplier = (SupplierView)MemberwiseClone();
        supplier.Address = (SupplierAddressView)supplier.Address.Clone();
        var cellphone = new List<SupplierCellphoneView>();
        supplier.Cellphones.ToList().ForEach(p => cellphone.Add((SupplierCellphoneView)p.Clone()));
        supplier.Cellphones = cellphone;
        return supplier;
    }

    public SupplierView ClonedTyped()
    {
        return (SupplierView)MemberwiseClone();
    }
}
