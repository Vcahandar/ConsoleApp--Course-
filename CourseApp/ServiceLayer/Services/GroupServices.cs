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
            Teacher teachers=_teacher.Get(m=>m.Id==teacherId);
            group.Id = _count;
            group.Teacher= teachers;
            if (teachers == null) throw new Exception("Data not found");

            var teacher = _repo.Get(m=>m.Name.ToLower() == group.Name.ToLower());
            if (teacher != null) throw new Exception("Data already exist");

            _repo.Create(group);
            _count++;
            return group;
        }

        public void Delete(int? id)
        {
            if (id == null) throw new ArgumentNullException();
            Group dbGroup=_repo.Get(m=>m.Id==id);

            if (dbGroup == null) throw new NullReferenceException("Data notfound");
            _repo.Delete(dbGroup);
        }
      
        
        public List<Group> GetGroupByCapacity(int? capacity)

        {
            if (capacity is null) throw new ArgumentNullException();
            List<Group> dbGroups = _repo.GetAll(m=>m.Capacity==capacity);
            if (dbGroups.Count == 0) throw new ArgumentNullException();
            

            return dbGroups;
        }

        public Group GetGroupById(int? id)
        {
            if (id is null) throw new ArgumentNullException();
            Group dbGroup = _repo.Get(m => m.Id == id);
            if (dbGroup == null) throw new NullReferenceException("Data notfound");
            return dbGroup;
        }

        public List<Group> GetGroupBySearchName(string searchText)
        {
            if(searchText is null) throw new ArgumentNullException();
            List<Group> groups = _repo.GetAll(m => m.Teacher.Name.ToLower().Contains(searchText.ToLower()));
            if (groups.Count == 0) throw new NotFoundException(ResponseMessages.NotFound);

            return groups;
        }

        public List<Group> GetGroupByTeacherId(int? teacherId)
        {
            if (teacherId is null) throw new ArgumentNullException();
            List<Group> groups = _repo.GetAll(m=>m.Teacher.Id== teacherId);
            if (teacherId == null) throw new ArgumentNullException("Data not found");


            return groups;
        }

        public List<Group> GetGroupByTeacherName(string teacherName)
        {
            List<Group> groups = _repo.GetAll(m => m.Teacher.Name.Trim().ToLower() == teacherName.Trim().ToLower());
           
            if (groups.Count == 0) throw new NotFoundException(ResponseMessages.NotFound);

            return groups;
        } 

        public int GetGroupCount()
        {
            return _repo.GetAll().Count;
        }

        public Group Update(int? id, Group group)
        {
            var groupsUpdate = _repo.Get(m => m.Id == id);
            if (groupsUpdate != null)
            {
                group.Id = groupsUpdate.Id;
                _repo.Update(group);
                return groupsUpdate;
            }

            return null;
            
        }
    }



}
