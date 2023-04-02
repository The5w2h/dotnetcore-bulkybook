using System;
namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class // IRepository is a GENERIC.
    {
        // To start, assume T = Category
        IEnumerable<T> GetAll(); // T can be any class
    }
}

