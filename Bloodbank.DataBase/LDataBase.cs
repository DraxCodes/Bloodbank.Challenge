using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Bloodbank.Core.Services;
using LiteDB;

namespace Bloodbank.DataBase
{
    public class LDataBase : IDataBase
    {
        private string DbLocation = "Bloodbank.db";

        public void Store<T>(T item)
        {
            using (var db = new LiteDatabase(DbLocation))
            {
                var collection = db.GetCollection<T>();
                collection.Insert(item);
            }
        }

        public void Update<T>(T item)
        {
            using (var db = new LiteDatabase(DbLocation))
            {
                var collection = db.GetCollection<T>();
                collection.Update(item);
            }
        }

        public bool Exists<T>(Expression<Func<T, bool>> predicate)
        {
            using (var db = new LiteDatabase(DbLocation))
            {
                var collection = db.GetCollection<T>();
                return collection.Exists(predicate);
            }
        }

        public IEnumerable<T> RestoreMany<T>(Expression<Func<T, bool>> predicate)
        {
            using (var db = new LiteDatabase(DbLocation))
            {
                var collection = db.GetCollection<T>();
                return collection.Find(predicate);
            }
        }

        public T RestoreSingle<T>(Expression<Func<T, bool>> predicate)
            => RestoreMany<T>(predicate).FirstOrDefault();
    }
}
