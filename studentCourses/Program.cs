using studentCourses.Repositories;

class Program
{
          static void Main(string[] args)
          {
                    var repository = new StudentCoursesRepository();

                    Console.Write("Enter student ID: ");
                    int studentId = int.Parse(Console.ReadLine());

                    var courses = repository.GetStudentCourses(studentId);

                    Console.WriteLine($"\nCourses for student with nomber: ({studentId}):");
                    foreach (var course in courses)
                    {
                              Console.WriteLine($"- {course.Name} ({course.Hours} hours)");
                    }
          }
}
