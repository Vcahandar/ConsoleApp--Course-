using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ITeacherService
    {
        Teacher Create(Teacher teacher); 
        void Delete(int? id);
        Teacher GetById(int ?id);
        List<Teacher> Search(string searchText);
        List<Teacher> GetAll();

        Teacher Update(int? id,Teacher teacher );

    }
}
