using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0917
{
	class SalesMan : Employee
	{
		int bonus;
		public SalesMan() : base(1) //기본생성자가 아니라 파라미터가 int employeeID인 생성자로 보내면 간단하게 초기값을 1로 만들어줄수 있음
		{
			bonus = 100;
		}
	}
	class Person
	{
		private string fName;
		private string lName;

		public string FirstName 
		{
			get { return fName; }
			set { fName = value; }
		}
		public string LastName
		{
			get { return lName; }
			set { lName = value; }
		}

		public Person() : this("김", "아무개") // this는 나의 클래스의 생성자를 부르는데 쓰임
		{
			//Console.WriteLine("Person 생성자");
		}

		public Person(string fName, string lName)
			//Employee 생성자에서 오류가 나는 이유 : 상속받는 자식 클래스의 생성자를 호출할때 부모 클래스의 생성자를 먼저 호출하고 그다음에 호출하는데
			//									  자식 생성자에 어떤 부모생성자로 가라고 명시해주지 않으면 기본적으로 부모의 기본생성자로 가게 된다
			//									  하지만 Person클래스의 생성자에는 2개짜리 파라미터 밖에 없어서 기본생성자가 없어 오류가 났던것이다.
			//									 ★ 그래서 평소에도 여러개의 생성자를 만들더라도 기본생성자 하나는 만들어두는 습관을 가지면 정말 좋다!! ★
		{
			this.fName = fName;
			this.lName = lName;
		}

		public virtual void PrintInfoVirtual()  //virtual : 키워드는 상속받을 클래스를 위해 오버라이드를 허락해주는 키워드
		{
			Console.WriteLine("======== Person =========");
			Console.WriteLine($"First Name : {fName}");
			Console.WriteLine($"Last Name : {lName}");
			Console.WriteLine("=========================");
		}
		public  void PrintInfo()  
		{
			Console.WriteLine("======== Person =========");
			Console.WriteLine($"First Name : {fName}");
			Console.WriteLine($"Last Name : {lName}");
			Console.WriteLine("=========================");
		}
		public override string ToString()  //object클래스 ToString오버라이드
		{	
			//string 타입은 리턴이 필요함
			return $"{fName} {lName}";
		}
	}

	class Employee : Person //Employee가 Person 상속받음
	{
		public int employeeID = 0;

		public Employee() : base("", "") //base 명령어를 쓰면 파라미터 2개짜리 생성자로 가라고 명시해주는 것이다.
										 //이렇게 하면 기본생성자를 만들어 주지 않아도 오류가 나지 않는다.
		{
			Console.WriteLine("Employee 생성자");
		}
		public Employee(int employeeID) : base("", "")
		{
			this.employeeID = employeeID;
		}
		public Employee(int employeeID, string fName, string lName) : base(fName, lName) //퍼스트네임 과 라스트네임은 부모의 생성자에서 해주기때문 중복방지가능
		{
			this.employeeID = employeeID;
			//FirstName = fName;
			//LastName = lName;
		}

		public override void PrintInfoVirtual()
		{
			base.PrintInfoVirtual();
			Console.WriteLine("EmployeeID : {0}", employeeID);
		}

		public new /*override*/ void PrintInfo() //명시적으로 상속받은 PrintInfo를 숨기기 위해 new명령어 사용가능 => public new void PrintInfo()
		{										 //하지만 new를 많이 쓰진않음
												 //이런경우 제일 많이쓰는 override(재정의), 부모클래스가 virtual 명령어로 오버라이딩을 허락해 줘야함
			Console.WriteLine("======== Employee =========");
			Console.WriteLine($"employeeID : {employeeID}");
			Console.WriteLine($"First Name : {this.FirstName}"); //클래스 내부에서 자신을 가리킬때 쓰는 this
																 //this를 쓰는경우 : 매개변수 와 지역변수 가 이름이 같을때 지역변수를 가리키기 위해
			Console.WriteLine($"Last Name : {LastName}");		 // 지금은 this를 안써도 되는 경우
			Console.WriteLine("===========================");
		}

	}

	class InheritTest
	{
		static void Main()
		{
			
			SalesMan sales = new SalesMan();
			sales.PrintInfo();
			sales.PrintInfoVirtual();

			//어제 수업시간 예제에서 Man 클래스를 Person 클래스로 변경만 했습니다.
			//어제 수업시간에는 property로 "아", "이유"를 저장했지만, 이번엔 생성자로 하고 싶습니다.
			//아래의 코드가 가능하게 Person 클래스를 수정하시고,
			//Employee 클래스의 emp1은 실행시 문제가 없는지 확인하세요.
			//문제가 있다면, 무슨 문제가 있는지 생각해보시기 바랍니다.

			//Person man = new Person();
			//man.FirstName = "류";
			//man.LastName = "현진";
			//man.PrintInfo();

			#region 상속의 특징(생성자)
			//Person per = new Person();
			//Employee emp = new Employee();  //상속 받았을 때 자식클래스가 생성자를 호출하기전에 부모의 생성자를 먼저 호출하고 그다음 호출한다
			#endregion

			Person per = new Person("아", "이유");
			per.PrintInfo();
			Person per2 = new Person("김", "연아");
			per2.PrintInfo();

			Employee emp1 = new Employee(2020005);
			emp1.FirstName = "류";
			emp1.LastName = "현진";
			emp1.PrintInfoVirtual();
			emp1.PrintInfo();

			Employee emp2 = new Employee(2020200, "손", "흥민");
			emp2.PrintInfo();

			Console.WriteLine(emp1.ToString());

			per = emp1; // 자식 => 부모 : 자동(암시적)형변환
			
			per.PrintInfo(); // override된 메서드인 경우, 태생의 메서드가 실행(자식의 메서드)
							 // new의 경우, 오버라이딩에서의 차이점이 형변환에서 차이가 난다, 
							 // 태생이아니라 무조건 변수타입의 메서드가 실행 
							 // 지금의 경우는 Person의 per타입이니까 부모의 메서드가 실행된다

			emp1 = (Employee)per; // 부모 => 자식 형변환 : 명시적으로 형변환 필요 (실행됨)
			emp1.PrintInfoVirtual();

			//emp1 = (Employee)per2; //부모 => 자식 형변환 : 명시적으로 형변환 필요 (InvlaidCastException 발생) 
			//emp1.PrintInfoVirtual(); //per2의 태생은 new Person("김", "연아"); 부모인데 부모클래스에는 employeeID가 없어서 형변환이 불가능
			//							 per은 per = emp1;로 형변환을 해서 태생이 new Employee(2020005);즉 태생 자식이기때문에 employeeID 가 존재해 형변환이 가능
			//부모 => 자식 형변환 : 명시적 형번환은 태생에 따라서 결정된다. 태생이 자식이였으면 가능
			// ((Employee)per).employeeID 부모로 자식껄 불러와 쓸때 다시한번 부모를 자식으로 형변환 해준다

			//is,as연산자 : 항상 형변환을 하기전에 is나 as를 써써 안전한 코딩을 해야한다,
			//			   100%로 형변환을 다할수 없기 때문에 혹시모를 실행중 Exception을 막기위해
			emp1 = per2 as Employee;  //as는 이런식으로 꼭 조건문으로 체크를 해야함 as는 일단 형변환을 해주기때문에 런타임오류는 나지않지만
									  //형변환에 실패 하면 null값 주고 성공하면 바꾼값을 준다 
			if (emp1 != null)
			{
				emp1.PrintInfoVirtual();
			}
			else
			{
				Console.WriteLine("형변환 할 수 없는 변환입니다");
			}

			if(per2 is Employee)  //is는 true,false로 값을 반환해줌
			{					  //is가 true가 나왔는데 형변환이 안되는 경우는 없음
				emp1 = (Employee)per2;
			}
			else
			{
				Console.WriteLine("형변환불가");
			}
			
		}
	}
}
