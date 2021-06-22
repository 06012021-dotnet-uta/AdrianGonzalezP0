
namespace EcommerceBusinessLayer
{
    public interface ICrud<T>
    {
        bool Create(T obj);
        T Read(string keyValue);
        bool Update(T obj);
        bool Delete(T obj);
    }
}
