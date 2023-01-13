

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
                teacher.GetById();
                break;
            case 5:
                teacher.GetAll();
                break;
            case 6:
                teacher.Search();
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
    ConsoleColor.Cyan.WriteConsole("Teacher Options:\n1 - Create\n2 - Update Teacher\n3 - Delete\n4 - Get teacher by id\n5 - Get all teachers\n6 - Search for teacher name and surname,");
}

;