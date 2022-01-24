using System;

public class Program
{
	public static void Main()
	{
		Entity.SetNextSerialNo(1000); // static method is invoked on calss itself and cannot be invoked on object. It is invoking staic method and it will not invoke instance constructor
		Entity.SetNextSerialNo(2000); // static feild will be updated with static method and it updates the field of calss itself. but static constructor will only be invoked once
		Entity e1 = new Entity(); // invoke instance constructor, instance constructor will be invoked when new instance of class but won't be invoked by calling instance method 
		Entity e2 = new Entity(); // invoke instance constructor
		Console.WriteLine(e1.GetSerialNo() + "_next: " + e1.GetNexSerialNo()); // Outputs "1000"
		Console.WriteLine(e2.GetSerialNo() + "_next: " + e2.GetNexSerialNo()); // Outputs "1001"
		Console.WriteLine(Entity.GetNextSerialNo()); // Outputs "1002" 
	// Console.WriteLine(Entity.GetSerialNo()); An object reference is required for the non-static field, method, or property. this means we cannot return non-static feild from a class
	// using static method of getting non-static feild
	}
// 1. we need to understand public static void main() why we add these modifier and return void for main method in C# 
// 2. instance constructor and instance method (constructor is also method) has access both to static field and instance field. static int s_nextSerialNo; int _serialNo in example
//    but instance feild could be different in different instance or object. This depends on when the object is created. for example e1 is an object when it is created. It invokes
// instance constructor to instantiate static feild and instance feild as 1000 and 1001. this two values are e1's feild since it is created 
// when e2 is created, it invokes the constructor again. It has current state of class Entity, it is created after e1 is created. now static int s_nextSerialNo is 1001 after e1 is created
// so this is why it is 1001, 1002. 
// 3. The static constructor is called only once whenever the static method is used or creating an instance for the first time
}

public class Entity
{
	static int s_nextSerialNo;
	int _serialNo;
	public Entity()
	{
		_serialNo = s_nextSerialNo++; // 1000 as s_nextSerialNo  will be assigned to _serianlNo first. then s_nextSerialNo will add 1 to be 1001 then this command is done
		Console.WriteLine("Invoke instance constructor: " + _serialNo + "_s_next: " + s_nextSerialNo);
	}
	static Entity()
	{
		Console.WriteLine("Invoke static constructor");
	}

	public int GetSerialNo()
	{
		return _serialNo;
	}

	public int GetNexSerialNo()
	{
		return s_nextSerialNo;
	}

	public static int GetNextSerialNo()
	{
		return s_nextSerialNo;
	}

	public static void SetNextSerialNo(int value)
	{
		s_nextSerialNo = value;
	}
}