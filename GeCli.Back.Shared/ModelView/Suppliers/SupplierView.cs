namespace GeCli.Back.Shared.ModelView.Suppliers;

public class SupplierView
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CNPJ { get; set; }
    public SupplierAddressView Address { get; set; }
    public ICollection<SupplierCellphoneView> Cellphones { get; set; }
    public string Vendor { get; set; }
}
