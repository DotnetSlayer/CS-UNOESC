using UserDetails;

// Dictionary initialized to store employee data
Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

// Adding employees to the dictionary
employees.Add(10050, new Employee() {FirstName = "Thiago", LastName = "Balbinot", PhoneNumber = "000-000-0000"});
employees.Add(10051, new Employee() {FirstName = "John", LastName = "Doe", PhoneNumber = "111-111-1111"});
employees.Add(10052, new Employee() {FirstName = "Jane", LastName = "Doe", PhoneNumber = "222-222-2222"});
employees.Add(10053, new Employee() {FirstName = "Bob", LastName = "Smith", PhoneNumber = "333-333-3333"});
employees.Add(10054, new Employee() {FirstName = "Sally", LastName = "Jones", PhoneNumber = "444-444-4444"});
employees.Add(20050, new Employee() {FirstName = "Tom", LastName = "Brown", PhoneNumber = "555-555-5555"});
employees.Add(20051, new Employee() {FirstName = "Sue", LastName = "Green", PhoneNumber = "666-666-6666"});
employees.Add(20052, new Employee() {FirstName = "Mark", LastName = "White", PhoneNumber = "777-777-7777"});
employees.Add(20053, new Employee() {FirstName = "Emily", LastName = "Black", PhoneNumber = "888-888-8888"});
employees.Add(30050, new Employee() {FirstName = "David", LastName = "Gray", PhoneNumber = "999-999-9999"});

// Boolean variable to check if the input is correct
bool isCorrect = true;

// Loop until the input is correct
do
{
    // The user enter an employee ID
    Console.WriteLine("Enter an employee ID: ");
    string idString = Console.ReadLine();
    isCorrect = int.TryParse(idString, out int id);

    // If the input is not a number, display an error message. If not, display the employee details if the same ID exists in the dictionary
    if (isCorrect)
    {
        
        if(employees.TryGetValue(id, out Employee employee))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("First Name: {1}{0} Last Name: {2}{0} Phone Number: {3}",
            Environment.NewLine, employee.FirstName, employee.LastName, employee.PhoneNumber);
        }

        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Employee not found.");
            
        }

        Console.ForegroundColor = ConsoleColor.White;
    }
}

while(isCorrect);