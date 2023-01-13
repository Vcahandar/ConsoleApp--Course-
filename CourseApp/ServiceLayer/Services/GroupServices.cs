using DomainLayer.Models;
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
        public Group Create(Group group)
        {
            throw new NotImplementedException();
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

        public List<Group> GetGroupByTeacherId(Teacher teacherId)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetGroupByTeacherName(Teacher teacherName)
        {
            throw new NotImplementedException();
        }

        public Group Update(int? id, Group group)
        {
            throw new NotImplementedException();
        }
    }
}
