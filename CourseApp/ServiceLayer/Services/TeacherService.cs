using DomainLayer.Models;
using RepositoryLayer.Repositories;
using ServiceLayer.Exceptions;
using ServiceLayer.Helpers.Constants;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class TeacherService : ITeacherService 
    {
        private readonly TeacherRepository _repo;
        private int _count = 1;
         
        public TeacherService()
        {
            _repo= new TeacherRepository();
        }
        public Teacher Create(Teacher teacher)
        {
            if (teacher is null) throw new ArgumentNullException();

            teacher.Id = _count;
            _repo.Create(teacher);
            _count++;
            return teacher;
        }

        public void Delete(int? id)
        {
            if(id is null) throw new ArgumentNullException();
            Teacher dbTeacher = _repo.Get(m => m.Id == id);
            if (dbTeacher  == null) throw new NullReferenceException("Data not found");
            _repo.Delete(dbTeacher);
        }


        public List<Teacher> GetAll()
        {
            return _repo.GetAll();
        }

        public Teacher GetById(int? id)
        {
            if (id is null) throw new ArgumentNullException();
            Teacher dbTeacher = _repo.Get(m => m.Id == id);
            if (dbTeacher == null) throw new NullReferenceException("Data notfound");
            return dbTeacher;
        }


        public List<Teacher> Search(string searchText)

        {
            List<Teacher> teachers = _repo.GetAll(m => m.Name.ToLower().Contains(searchText.ToLower()) || m.Surname.ToLower().Contains(searchText));
            if (teachers.Count == 0) throw new NotFoundException(ResponseMessages.NotFound);

            return teachers;
           
        }

        public Teacher Update(int? id,Teacher teacher)
        {
            if (id == null) throw new ArgumentNullException("Data not found");
            if (teacher == null) throw new ArgumentNullException();
            teacher.Id=(int)id;
            _repo.Update(teacher);
            
            return teacher;
        }
    }
}
