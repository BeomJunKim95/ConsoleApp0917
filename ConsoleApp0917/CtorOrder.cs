using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0917_1
{
	class Person
	{
		public Person()
		{
			Console.WriteLine("Person 생성자");
		}
		~Person()
		{
			Console.WriteLine("Person 종료자");
		}
	}
	class Employee : Person
	{
		public Employee()
		{
			Console.WriteLine("Employee 생성자");
		}
		~Employee()
		{
			Console.WriteLine("Employee 종료자");
		}
	}
	class CtorOrder
	{
		static void Main()
		{
			Person per = new Person();
			Employee emp = new Employee();

			
		}
	}
}
