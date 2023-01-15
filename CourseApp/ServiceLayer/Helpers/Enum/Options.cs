using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Helpers.Enum
{
    public enum Options
    {
        CreateTeacher=1,
        UptadeTeacher,
        DeleteTeacher,
        GetByTeacherById,
        GettAllTeachers,
        SearchForTeacherNameAndSurname,
        CreateGroup,
        DeleteGroup,
        GetGroupById,
        SearchMethodForGroupByName,
        GetAllGroupsByTeacherName,
        GetGroupsByCapacity,
        GetGroupByTeacherId,
        GetAllGroupsCount,
        UpdateGroup,
       
    }
}
