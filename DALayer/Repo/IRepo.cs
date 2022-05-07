using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Repo
{
    
        public interface IRepo<T>
        {
            IEnumerable<T> GetAll();
            T GetDetailById(object Id);



            void AddDetail(T NewObj);



            void Delete(object Id);



            void UpdateDetail(T UpdObj);
        }
    
}
