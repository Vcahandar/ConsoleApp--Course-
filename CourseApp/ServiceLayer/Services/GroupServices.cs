using DomainLayer.Models;
using RepositoryLayer.Repositories;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class GroupServices : IGroupServices
    {
        private readonly GroupRepository _repo;
        private readonly TeacherRepository _teacher;
        private int _count = 1;

        public GroupServices()
        {
            _repo= new GroupRepository();
            _teacher= new TeacherRepository();
        }
        public Group Create(Group group,int teacherId)
        {
            Teacher teacher=_teacher.Get(m=>m.Id==teacherId);
            if (teacher == null) return null;
            group.Id = _count;
            _repo.Create(group);
            _count++;
            return group;
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAllGroup()
        {
            throw new NotImplementedException();
        }

      
        public Group GetGroupByCapacity(int? capacity)
        {
            throw new NotImplementedException();
        }

        public Group GetGroupById(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetGroupBySearchName(string searchText)
        {
            throw new NotImplementedException();
        }


        public List<Group> GetGroupByTeacherId(int? teacherId)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetGroupByTeacherName(string teacherName)
        {
            throw new NotImplementedException();
        }

        public int GetGroupCount()
        {
            throw new NotImplementedException();
        }

        public Group Update(int? id, Group group)
        {
            throw new NotImplementedException();
        }
    }

   
    
}
