using EmployeeManagerDemo;


// Example use of Dependency Injection to isolate my application
// from its enviroment
IInputOutput inputOutput = new InputOutput();


myApp mainProgram = new(inputOutput);
mainProgram.Execute();

