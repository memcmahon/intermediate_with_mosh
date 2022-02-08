## C# Intermediate

A place for notes on this udemy course: https://www.udemy.com/course/csharp-intermediate-classes-interfaces-and-oop/

**Overloading** - creating multiple method signatures.  An example with Constructors:

```cs
public class Customer
{
  public Customer() { ... }

  public Customer(string name) { ... }

  public Customer(int ID, string name) { ... }
}
```

- When creating a class that will have a List of other things, it is ALWAYS a good idea to set that class up with a constructor to create a default empty List.  This is because, by default, a list field will return a Null object.

```cs
public class Person
{
  public List<Dog> Dogs;

  public Person()
  {
    Dogs = new List<Dog>();
  }
}
```

- When using Constructor Overloading, you might have to repeat code.  To avoid this, you can use `: this`

```cs
public class Person
{
  public List<Dog> Dogs;
  public string Names;

  public Person()
  {
    Dogs = new List<Dog>();
  }

  public Person(string name)
  {
    Dogs = new List<Dog>();
    this.Name = name;
  }
}

//VS

public class Person
{
  public List<Dog> Dogs;
  public string Names;

  public Person()
  {
    Dogs = new List<Dog>();
  }

  public Person(string name)
    : this()
  {
    this.Name = name;
  }
}
```

- Best case is to use constructors for only those things which an object NEEDS in order to behave (the things that will be the same for all instances of that object).  For initial field setup, it is better to use **Object Initializers**

```cs
public class Person
{
  public string FirstName;
  public string LastName;
  public DateTime Birthdate;
  public List<Dog> Dogs;

  public Person()
  {
    Dogs = new List<Dog>();
  }
}

var person = new Person
             {
               FirstName = "Megan";
               LastName = "McMahon";
             };
```

### Methods

- **Method Signature** is the name and number & type of its parameters.
- **Overloading** is having a method of the same name but different parameters.
- If a method has varying numbers of parameters (as in an Add method that can add any number of inputs):

```cs
// If you have a method that Adds multiple nums together, you could do:
public class Calculator
{
  public int Add(int[] numbers)
  {
    ...
  }
}

Calculator.Add(new int[]{1, 2, 3, 4});

//OR you could use the params modifier to avoid having to `new` an array:

public class Calculator
{
  public int Add(params int[] numbers){}
  {
    ...
  }
}

Calculator.Add(1, 2, 3, 4);

//Not used all the time, but can be useful
```
