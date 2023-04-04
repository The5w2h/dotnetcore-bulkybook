using System;
namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public ICategoryRepository Category { get; } // QUESTION: Why only get is used here?

        public ICoverTypeRepository CoverType { get; }

        void Save(); // Global methods are put in UnitOfWork
    }
}

