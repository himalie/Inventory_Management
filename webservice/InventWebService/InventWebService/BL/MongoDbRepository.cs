using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System.Web;

namespace InventWebService.BL
{
    public class MongoDbRepository<TEntity> :
    IRepository<TEntity> where
        TEntity : EntityBase
    {
        private MongoDatabase database;
        private MongoCollection<TEntity> collection;
        MongoServer objServer;
        MongoDatabase objDatabse;

        public MongoDbRepository()
        {
            //GetDatabase();
            objServer = MongoServer.Create("Server=localhost:27017");
            objDatabse = objServer.GetDatabase("invent");
            database = objServer.GetDatabase("invent");
            //GetCollection();
        }

        public bool Insert(TEntity entity)
        {
            //removed GUID     
            try
            {
                collection = objDatabse.GetCollection<TEntity>("invent");
                return collection.Insert(entity).Ok;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            if (entity.Id == null)
                return Insert(entity);

            return collection
                .Save(entity)
                    .DocumentsAffected > 0;
        }

        public bool Delete(TEntity entity)
        {
            return collection
                .Remove(Query.EQ("_id", entity.Id))
                    .DocumentsAffected > 0;
        }

        public IList<TEntity>
            SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return collection
                .AsQueryable<TEntity>()
                    .Where(predicate.Compile())
                        .ToList();
        }

        public IList<TEntity> GetAll()
        {
            try
            {
                return collection.FindAllAs<TEntity>().ToList();
            }
            catch (Exception e)
            {
                IList<TEntity> ret = null;
                return ret;
            }
        }

        public TEntity GetById(Guid id)
        {
            return collection.FindOneByIdAs<TEntity>(id);
        }

        #region Private Helper Methods
        //private void GetDatabase()
        //{
        //    var client = new MongoClient(GetConnectionString());
        //    var server = client.GetServer();

        //    database = server.GetDatabase(GetDatabaseName());
        //}

        private string GetConnectionString()
        {
            return ConfigurationManager
                .AppSettings
                    .Get("MongoDbConnectionString")
                        .Replace("{DB_NAME}", GetDatabaseName());
        }

        private string GetDatabaseName()
        {
            return ConfigurationManager
                .AppSettings
                    .Get("MongoDbDatabaseName");
        }

        private void GetCollection()
        {
            collection = database
                .GetCollection<TEntity>(typeof(TEntity).Name);
        }
        #endregion
    }
}