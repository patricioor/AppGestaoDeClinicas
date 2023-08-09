namespace GeCli.Back.Shared.ModelView.Suppliers;

public class SupplierReference : ICloneable
{
    public int Id { get; set; }
    public string Name { get; set; }

    public object Clone()
    {
        return MemberwiseClone();
    }
}
