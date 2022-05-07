using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer;
using System.Data.Entity;

namespace DALayer.Repo
{
    public class RepositoryService<T> : IRepo<T> where T : class
    {
        private MVDBEntities Db = null;
        private DbSet<T> Entity = null;



        public RepositoryService()
        {
            Db = new MVDBEntities();
            Entity = Db.Set<T>();
        }
        public void AddDetail(T NewObj)
        {
            try
            {
                Entity.Add(NewObj);
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        public void Delete(object Id)
        {
            try
            {
                var Obj = Entity.Find(Id);
                if (Obj != null)
                {
                    Entity.Remove(Obj);
                    Db.SaveChanges();
                }
                else
                {
                    throw new Exception("record not found");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        public IEnumerable<T> GetAll()
        {
            try
            {
                var Lst = Entity.ToList();
                return Lst;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        public T GetDetailById(object Id)
        {
            var Obj = Entity.Find(Id);



            if (Obj != null)
            {
                return Obj;
            }
            else
            {
                throw new Exception("Record not Found");
            }
        }



        public void UpdateDetail(T UpdObj)
        {
            try
            {
                
                Entity.Attach(UpdObj);
                Db.Entry(UpdObj).State = EntityState.Modified;
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
