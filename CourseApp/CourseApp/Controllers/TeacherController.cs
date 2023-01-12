using DomainLayer.Models;
using ServiceLayer.Helpers;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        TeacherName: string teacherName = Console.ReadLine();

            //string pettern = @"\|!#$%&/()=?><@{}.-;'_,";
            
            if (teacherName == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add dont empty Teacher name:");
                goto TeacherName;
            }
           
           

            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher surname:");
            TeacherSurname: string teacherSurname=Console.ReadLine();
            if (teacherSurname==string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add dont empty Teacher surname:");
                goto TeacherSurname;
            }

            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher address:");
            TeacherAddress: string teacherAddress = Console.ReadLine();
            if (teacherAddress==string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add dont empty Teacher address:");
                goto TeacherAddress;
            }



            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher age:");
            string teacherAgeStr=Console.ReadLine();


            int teachAge;

            bool isTeacherAge=int.TryParse(teacherAgeStr, out teachAge);

            if(isTeacherAge)
            {

                try
                {
                    Teacher teacher = new Teacher
                    {
                        Name=teacherName,
                        Surname=teacherSurname,
                        Age=teachAge,
                        Address=teacherAddress,
                    };

                    var response=_teacherService.Create(teacher);
                    ConsoleColor.Green.WriteConsole($"Id: {response.Id}, Name: {response.Name}, Surname: {response.Surname}, Age:{response.Age}, Address:{response.Address}");

                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add Teacher name again:");

                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("You cannot register correctly, please register again.");

                ConsoleColor.Cyan.WriteConsole("Please select one option: ");
                ConsoleColor.Cyan.WriteConsole("Teacher Options: 1 - Create, 2 - Get All, 3 - Delete");
                goto TeacherName;
            }


        }

        public void GetAll()
        {
            var result = _teacherService.GetAll();

            if (result.Count==0)
            {
                ConsoleColor.Red.WriteConsole("Data Not Found!");
            }
            else
            {
                foreach (var item in result)
                {
                    ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Surname: {item.Surname}, Age:{item.Age}, Address:{item.Address}");

                }
            }
        }

        public void Delete()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher Id for delete:");
            TeacherId: string teacherId=Console.ReadLine();

            int id;
            
            bool isCorrectId=int.TryParse(teacherId, out id);

            if (isCorrectId)
            {
                try
                {
                    _teacherService.Delete(id);
                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add teacher Id again");
                    goto TeacherId;
                }



            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please add correct format teacher Id");
                goto TeacherId;

            }
        }
    }
}
