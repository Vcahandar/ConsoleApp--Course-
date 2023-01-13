using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IGroupServices
    {
        Group Create(Group group);
        Group Update(int? id,Group group);
        Group GetGroupById(int? id);
        void Delete(int? id);
        Group GetGroupByCapacity(int? capacity);
        List<Group> GetGroupByTeacherId(Teacher teacherId);
        List<Group> GetGroupByTeacherName(Teacher teacherName);
        List<Group> GetGroupBySearchName(string searchText);
        List<Group> GetAllGroup();
    }
}
