C# 6.0

1. Description
	Roslin - new complier in c# 6.0
	Scriptcs - new project that uses Roslin as compiler. Simple text editor for writing code. No need for VS

2. Auto Property Initializers
	- you can NOT have { get; } only property. There is no way to set that property without set. Compile error. at least protected set is needed
	- setter will be set to new Guid

	public Guid Id { get; } = Guid.NewGuid

3. Primary Constructors & Explicit Constructors
	- useful with auto property initializers
	public struct Money(string currency, decimal amount, Stream stream)
	{
		public string Currency { get; } = currency
		...

		private StreamWriter LogWriter { get; } = new StreamWriter(stream);
	
4. Dictionary Initializer
	Old: Instead of using key value pair:
		{
			{ "admin", new User("Admin") },
			...
		}

	New:
	Dictionary<string, user> _users = new Dictionary<string, user>() {
		 ["admin"] = new User("Admin") 
		 ["guest"] = new User("Guest")
	};


5. Event Initializers
	
6. Params and IEnumerable
	public static void Main(){
		var result = Sum(45, 54, 14);
	}

	// able to take in IEnumerable of ints, doesn't need array as before
	public int Sum(params IEnumerable<int> numbers){
		return number.Sum(n => n);
	}


7. Using Static
	- no longer static class name is needed
	- if clash (there exists a method named Write() for example, that method will always win)
	- if two, ambigious methods compiler will generate an error

	ex. Console.Write("hi");

	New:
	using System.Console
	Write("hi");


8. Errors, Nulls, Exceptions

	1. Conditional access

		Old: 
		var name = "no name";
		if (action != null && action.Method != null){
			name = action.Method.Name;
		}

		New:
		var name = action?.Method?.Name; // if action is null it will return null, otherwise it will continue
		var name = action?.Method?.Name ?? "no name" // setting "no name" if all are null

	2. Await and Catch

		// You couldn't 'await' anything inside try/catch blocks
		New: 
		try {
			action() // some action
			await LogWriter.Write(name + " executed");
		}
		catch(Exception ex){
			await LogWriter.Write(name + " error!");
		}
		finally{
			await LogWriter.FlushAsync();
		}

	3. Exception Filters
		
		// adding exception filter if() block
		catch(Exception ex) if (ex.InnerException == null) {
			await LogWriter.Write(name + " error!");
		}

	4. nameof - get name of properties, methods etc

		public void DoWork(string name)
		{
			if (name == null)
				throw new ArgumentNullException(nameof(name)); // this works with any variable - instead of passing actual string
				// able to also get method name
		}
		
	5. Expression Bodied Members
