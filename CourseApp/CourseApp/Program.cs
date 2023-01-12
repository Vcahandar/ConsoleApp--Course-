

using CourseApp.Controllers;
using ServiceLayer.Helpers;

TeacherController teacher=new TeacherController();

while (true)
{
    GetOptions();

    Option: string option =Console.ReadLine();


    int selectedOption;

    bool isCorrectOption= int.TryParse(option, out selectedOption);

    if (isCorrectOption)
    {
       switch(selectedOption)
        {
            case 1:
                teacher.Create();
                break;
            case 2:
                Console.WriteLine("Update Teacher");
                break;
            case 3: 
                teacher.Delete();
                break;
            case 4:
                Console.WriteLine("Get teacher by id");
                break;
            case 5:
                teacher.GetAll();
                break;
            case 6:
                Console.WriteLine("Search for teacher name and surname");
                break;
            default:
                ConsoleColor.Red.WriteConsole("Please add correct option");
                goto Option;
        }

    }
    else
    {
        ConsoleColor.Red.WriteConsole("Please add correct format option");
        goto Option;
    }


}

static void GetOptions()
{
    ConsoleColor.Cyan.WriteConsole("Please select one option: ");
    ConsoleColor.Cyan.WriteConsole("Teacher Options: 1 - Create, 2 - Update Teacher, 3 - Delete, 4 - Get teacher by id, 5 - Get all teachers, 6 - Search for teacher name and surname,");
}
