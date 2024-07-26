using Data;
using DataLib;

namespace LINQ_demo
{
     public class Program
    {
        public static void Main(string[] args)
        {
            var employees = DataCall.GetEmployees();
            var departments = DataCall.GetDepartments();

            var resultList = from emp in employees
                             join
                             dept in departments
                             on emp.DepartmentId equals dept.Id
                             select new
                             {
                                 FirstName = emp.FirstName,
                                 LastName = emp.LastName,
                                 AnnualSalary = emp.AnnualSalary,
                                 Manager = emp.IsManager,
                                 Department = dept.LongName
                             };

            foreach (var item in resultList)
            {
                Console.WriteLine($"First Name : {item.FirstName}");
                Console.WriteLine($"Last Name : {item.LastName}");
                Console.WriteLine($"Annual Salary : {item.AnnualSalary}");
                Console.WriteLine($"Manager : {item.Manager}");
                Console.WriteLine($"Department : {item.Department}");
            }

            var Average = resultList.Average(r => r.AnnualSalary);
            var Max = resultList.Max(r => r.AnnualSalary);
            var Min = resultList.Min(r => r.AnnualSalary);

            Console.WriteLine($"Average : {Average}");
            Console.WriteLine($"Max : {Max}");
            Console.WriteLine($"Min : {Min}");

            Console.ReadKey();
        }

         
    }
}
