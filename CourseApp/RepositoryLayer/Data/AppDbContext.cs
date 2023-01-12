using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data
{
    public static class AppDbContext<T>
    {
        public static List<T> datas;
        static  AppDbContext()
        {
            datas= new List<T>();
        }
    }
}
