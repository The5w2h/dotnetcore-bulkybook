## Questions
* What is the meaning/benefit of using Interfaces as members?
  - [Explanation](https://stackoverflow.com/questions/2151959/using-interface-variables)
  - You are not creating an instance of the interface - **you are creating an *instance of something that implements the interface*.**
* What is the meaning of -
```
using System;
using System.Linq.Expressions;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class // IRepository is a GENERIC.
    {
        // To start, assume T = Category
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);

        IEnumerable<T> GetAll(); // T can be any class

        void Add(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);
    }
}

```
