namespace StudentManagement
{

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    internal class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>();

            
            students.Add(new Student(1, "Abdul Kalam"));
            students.Add(new Student(2, "Lionel Messi"));
            students.Add(new Student(3, "Karthick M"));

            
            Console.WriteLine("All Students:");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}");
            }

            
            Console.Write("\nEnter name to search: ");
            string searchName = Console.ReadLine();
            bool found = false;
            foreach (var student in students)
            {
                if (student.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Found: ID={student.Id}, Name={student.Name}");
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Student not found.");
            }

            

            Console.Write("\nEnter name to remove: ");
            string removeName = Console.ReadLine();
            Student toRemove = students.Find(s => s.Name.Equals(removeName, StringComparison.OrdinalIgnoreCase));
            if (toRemove != null)
            {
                students.Remove(toRemove);
                Console.WriteLine("Student removed.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }

            

            Console.WriteLine("\nUpdated List of Students:");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}");
            }

            

            Console.WriteLine($"\nTotal number of students: {students.Count}");
        }
    }
}
