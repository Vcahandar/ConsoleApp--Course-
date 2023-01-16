//using DomainLayer.Models;
//using ServiceLayer.Helpers;
//using ServiceLayer.Services.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace ServiceLayer.Services
//{
//    internal class test
//    {
////        ConsoleColor.DarkCyan.WriteConsole("Please add teacher id");
////            Id:  string teacherIdStr = Console.ReadLine();

////        int teacherId;
////        bool isCorrectTeacherId = int.TryParse(teacherIdStr, out teacherId);
         
////            if (isCorrectTeacherId && teacherId >= 1)
////            {
////                var result = _teacherService.Update(teacherId);
////                if (result != null)
////                {
////                    try
////                    {
////                        result.Id = teacherId;
////                        teacherId = result.Id;
////                        result.Id = teacherId;
////                    }
////                    catch (Exception ex)
////                    {
////                        ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "Please add again id");
////                        goto Id;
////                    }
////                }
//                else
//{
//    ConsoleColor.DarkRed.WriteConsole("Data not found");
//    ConsoleColor.DarkRed.WriteConsole("Please add different id");
//    goto Id;
//}
//            }
//            else
//{
//    ConsoleColor.DarkRed.WriteConsole("Please add correct format id");
//    goto Id;
//}

//var result1 = _teacherService.Update(teacherId);

//ConsoleColor.DarkCyan.WriteConsole("Please add new teacher name");
//TeacherNewName: string teacherNewName = Console.ReadLine();

//var teacherName = teacherNewName.Trim();
//if (teacherName != string.Empty)
//{
//    if (!Regex.IsMatch(teacherName, "^[a-zA-Z]+$"))
//    {
//        ConsoleColor.DarkRed.WriteConsole("Please add correct format name");
//        goto TeacherNewName;
//    }
//    else
//    {
//        result1.Name = teacherName;
//        teacherName = result1.Name;
//        result1.Name = teacherName;
//    }

//}
//else
//{
//    teacherNewName = result1.Name;
//}

//ConsoleColor.DarkCyan.WriteConsole("Please add new teacher surname");
//TeacherNewSurname: string teacherNewSurname = Console.ReadLine();

//var teacherSurname = teacherNewSurname.Trim();
//if (teacherSurname != string.Empty)
//{
//    if (!Regex.IsMatch(teacherSurname, "^[a-zA-Z]+$"))
//    {
//        ConsoleColor.DarkRed.WriteConsole("Please add correct format surname");
//        goto TeacherNewSurname;
//    }
//    else
//    {
//        result1.Surname = teacherSurname;
//        teacherSurname = result1.Surname;
//        result1.Surname = teacherSurname;

//    }

//}
//else
//{
//    teacherNewSurname = result1.Surname;
//}

//ConsoleColor.DarkCyan.WriteConsole("Please add new teacher address");
//TeacherNewAddress: string teacherNewAddress = Console.ReadLine();
//var teacherAddress = teacherNewAddress;

//if (teacherAddress != string.Empty)
//{
//    result1.Address = teacherAddress;
//    teacherAddress = result1.Address;
//    result1.Address = teacherAddress;
//}
//else
//{
//    teacherNewAddress = result1.Address;
//}

//ConsoleColor.DarkCyan.WriteConsole("Please add new teacher age");
//TeacherNewAge: string teacherNewAgeStr = Console.ReadLine();

//var name3 = teacherNewAgeStr;
//int teacherNewAge;
//bool isCorrectTeacherNewAge = int.TryParse(teacherNewAgeStr, out teacherNewAge);

//if (isCorrectTeacherNewAge && teacherNewAge >= 18 && teacherNewAge < 66)
//{
//    result1.Age = teacherNewAge;
//    teacherNewAge = result1.Age;
//    result1.Age = teacherNewAge;
//}
//else
//{
//    if (!Regex.IsMatch(name3, "[^\\s]+(\\s.*)?$"))
//    {

//        teacherNewAge = result1.Age;
//    }
//    else
//    {
//        ConsoleColor.DarkRed.WriteConsole("Please add correct format age. Age limit [min 18, max 65]");
//        goto TeacherNewAge;
//    }
//}

//Teacher teacher = new Teacher()
//{
//    Id = teacherId,
//    Name = teacherNewName,
//    Surname = teacherNewSurname,
//    Address = teacherNewAddress,
//    Age = teacherNewAge
//};
//ConsoleColor.Green.WriteConsole($"Id:{teacher.Id} Name:{teacher.Name} " +
//    $"Surname:{teacher.Surname} Age:{teacher.Age} Address:{teacher.Address}");
//ConsoleColor.DarkGreen.WriteConsole("You have successfully updated");
//        }


//    }
//}
