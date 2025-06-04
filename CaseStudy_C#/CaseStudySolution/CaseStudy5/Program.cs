namespace CaseStudy5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Student> students = new List<Student>();

            students.Add(new Student(1, "Ravi"));
            students.Add(new Student(2, "Karthick"));
            students.Add(new Student(3, "Dhoni"));

            Console.WriteLine("All students :");
            foreach (Student student in students)
            {
                
                Console.WriteLine($"Id : {student.id} , Name : {student.Name}");
            }

            Console.WriteLine("Enter name to search");
            string sname = Console.ReadLine();
            int c = 0;
            foreach (Student student in students)
            {
                if (student.Name == sname)
                {
                    Console.WriteLine($"Found : Id : {student.id} , Name : {student.Name}");
                    c++;
                }
            }
            if (c == 0)
            {
                Console.WriteLine("Student not found");
            }
            Console.WriteLine("Enter name to delete:");
            string sn = Console.ReadLine();

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Name.Equals(sn, StringComparison.OrdinalIgnoreCase))
                {
                    students.RemoveAt(i);
                    Console.WriteLine("Student removed");
                }
            }
            Console.WriteLine("Updated list of students :");
            foreach (Student student in students)
            {
                
                Console.WriteLine($"Id : {student.id} , Name : {student.Name}");
            }

            Console.WriteLine("Total number of students : " + students.Count);

            Console.ReadKey();
        }
    }
}
