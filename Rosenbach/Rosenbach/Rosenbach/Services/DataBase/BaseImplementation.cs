using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace Rosenbach.Services.DataBase
{
    public class DataBaseObject
    {
        [BsonId]
        public Guid DataBaseId { get; set; }
    }

    public class BaseImplementation<T>
    {
        private LiteDatabase mDataBase = null;

        public BaseImplementation()
        {
            mDataBase = DataBase.GetDataBase();
        }

        public ILiteCollection<T> getCollection()
        {
            return mDataBase.GetCollection<T>(typeof(T).Name);
        }

        public int Count()
        {
            return getCollection().Count();
        }

        public int Count(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return getCollection().Count(predicate);
        }

        public int Count(Query query)
        {
            return getCollection().Count(query);
        }
        public bool Delete(BsonValue query)
        {
            return getCollection().Delete(query);
        }

        public bool DropIndex(string field)
        {
            return getCollection().DropIndex(field);
        }

        public bool EnsureIndex(string field, bool unique = false)
        {
            return getCollection().EnsureIndex(field, unique);
        }

        public bool EnsureIndex(string field, string eypression, bool unique = false)
        {
            return getCollection().EnsureIndex(field, eypression, unique);
        }

        public bool EnsureIndex<K>(System.Linq.Expressions.Expression<Func<T, K>> property, bool unique = false)
        {
            return getCollection().EnsureIndex(property, unique);
        }

        public bool Exists(Query query)
        {
            return getCollection().Exists(query);
        }

        public bool Exists(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return getCollection().Exists(predicate);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate, int skip = 0, int limit = int.MaxValue)
        {
            return getCollection().Find(predicate, skip, limit);
        }

        public IEnumerable<T> Find(Query query, int skip = 0, int limit = int.MaxValue)
        {
            return getCollection().Find(query, skip, limit);
        }

        public IEnumerable<T> FindAll()
        {
            return getCollection().FindAll();

        }

        public T FindById(BsonValue id)
        {
            return getCollection().FindById(id);
        }

        public T FindOne(Query query)
        {
            return getCollection().FindOne(query);
        }

        public T FindOne(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return getCollection().FindOne(predicate);
        }

         public ILiteCollection<T> Include(string path)
        {
            return getCollection().Include(path);
        }

        public ILiteCollection<T> Include<K>(System.Linq.Expressions.Expression<Func<T, K>> path)
        {
            return getCollection().Include(path);
        }

        public BsonValue Insert(T document)
        {
            return getCollection().Insert(document);
        }

        public int Insert(IEnumerable<T> docs)
        {
            return getCollection().Insert(docs);
        }

        public void Insert(BsonValue id, T document)
        {
            getCollection().Insert(id, document);
        }

        public int InsertBulk(IEnumerable<T> docs, int batchSize = 5000)
        {
            return getCollection().InsertBulk(docs, batchSize);
        }

        public long LongCount(Query query)
        {
            return getCollection().LongCount(query);
        }

        public long LongCount(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return getCollection().LongCount(predicate);
        }

        public long LongCount()
        {
            return getCollection().LongCount();
        }

        public BsonValue Max(string field)
        {
            return getCollection().Max(field);
        }

        public BsonValue Max()
        {
            return getCollection().Max();
        }

        public BsonValue Min(string field)
        {
            return getCollection().Min(field);
        }

        public BsonValue Min()
        {
            return getCollection().Min();
        }


        public bool Update(T document)
        {
            return getCollection().Update(document);
        }

        public int Update(IEnumerable<T> docs)
        {
            return getCollection().Update(docs);
        }

        public bool Update(BsonValue id, T document)
        {
            return getCollection().Update(id, document);
        }

        public bool Upsert(T document)
        {
            return getCollection().Upsert(document);
        }

        public int Upsert(IEnumerable<T> docs)
        {
            return getCollection().Upsert(docs);
        }

        public bool Upsert(BsonValue id, T document)
        {
            return getCollection().Upsert(id, document);
        }

        public List<T> GetAll()
        {
            List<T> issuesToReturn = new List<T>();

            var issues = mDataBase.GetCollection<T>(typeof(T).Name);
            var results = issues.FindAll();
            
            foreach (T issueItem in results)
            {
                issuesToReturn.Add(issueItem);
            }

            return issuesToReturn;

        }
    }
}
