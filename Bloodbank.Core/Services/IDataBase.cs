using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bloodbank.Core.Services
{
    public interface IDataBase
    {
        void Store<T>(T item);
        void Update<T>(T item);
        T RestoreSingle<T>(Expression<Func<T, bool>> predicate);
        IEnumerable<T> RestoreMany<T>(Expression<Func<T, bool>> predicate);
        bool Exists<T>(Expression<Func<T, bool>> predicate);
    }
}
