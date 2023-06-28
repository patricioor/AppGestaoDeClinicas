namespace GeCli.Back.Domain.Interfaces
{
    public interface ISpecialtyRepository
    {
        Task<bool> ExistAsync(int id);
    }
}
