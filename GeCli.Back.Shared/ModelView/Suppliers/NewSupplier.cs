namespace GeCli.Back.Shared.ModelView.Suppliers;

public class NewSupplier
{
    public string Name { get; set; }
    public string CNPJ { get; set; }
    public NewSupplierAddress Address { get; set; }
    public ICollection<NewSupplierCellphone> Cellphones{ get; set; }
    public string Vendor { get; set; }
}
