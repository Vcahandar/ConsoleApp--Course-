using ServiceLayer.Helpers;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Controllers
{
    public class TeacherController
    {
        private readonly ITeacherService _teacherService;

        public TeacherController()
        {
            _teacherService = new TeacherService();
        }
        public void Create()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher name:");
            string teacherName=Console.ReadLine();

            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher surname:");
            string teacherSurname=Console.ReadLine();

            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher age:");



        }
    }
}
