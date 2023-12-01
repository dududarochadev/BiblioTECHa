namespace BiblioTECHa.Repositories.Interfaces
{
    public interface ICRUDRepository<T, TDto>
    {
        List<T> GetAll();
        T? GetById(int id);
        T Create(T ent);
        T Update(T ent, TDto dto);
        void Delete(T ent);
    }
}
