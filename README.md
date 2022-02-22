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

## Initialization

```cs
public class Customer
{
  // readonly means that it can only be assigned once.
  readonly List<Order> Orders = new List<Order>();
}
```

## Access Modifiers

A way to control access to a class and/or its members.

* Public
* Private
* Protected
* Internal
* Protected Internal

Encapsulation - define fields as private, with getter and setter methods.. A setter method allows you to set some logic - like check to see if that field has been assigned or not.

** Private fields should start with and `_` **

**Property** - A class member that encapsulates a getter/setter for a single field.

```cs
//NO PROPERTIES
public class Person
{
  private DateTime _birthdate;

  public void SetBirthdate(DateTime birthdate)
  {
    _birthdate = birthdate;
  }

  public DateTime getBirthdate()
  {
    return _birthdate;
  }

}
```

```cs
//WITH PROPERTY
public class Person
{
  private DateTime _birthdate;

  //property
  public DateTime Birthdate
  {
    get { return _birthdate; }
    set { _birthdate = value; }
  }
}

//With Auto-Implemented properties.  Useful for when there is no logic required for getting and/or setting..  The private field is created internally during compilation.
public class Person
{
  public DateTime Birthdate { get; set; }
}
```

- When you need some logic around a property:

```cs
public class Person
    {
        public DateTime Birthdate { get; set; }
        public int Age
        {
            get
            {
                var timeSpan = DateTime.Today - Birthdate;
                var years = timeSpan.Days / 365;

                return years;
            }
        }

    }
```

- an example with protected setter:

```cs
public class Person
{
  //shortcut - prop
  public DateTime Birthdate { get; private set; }

  //shortcut - ctor
  public Person(DateTime birthdate)
  {
      Birthdate = birthdate;
  }

  public int Age
  {
    get
    {
      var timeSpan = DateTime.Today - Birthdate;
      var years = timeSpan.Days / 365;

      return years;
    }
  }
}
```

- Convention for ordering properties/constructor:
  * Auto-Implemented properties
  * Constructor(s)
  * Calculated properties

### Indexers

Classes can be created to behave like an indexed object (list/dictionary).  The HttpCookie() class might be set up this way:

```cs
public class HttpCookie
{
    private readonly Dictionary<string, string> _dictionary;
    public DateTime Expiry { get; set; }

    public HttpCookie()
    {
        _dictionary = new Dictionary<string, string>();
    }

    public string this[string key]
    {
        get { return _dictionary[key]; }
        set { _dictionary[key] = value; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var cookie = new HttpCookie();
        cookie["name"] = "Megan";
        Console.WriteLine(cookie["name"]);
    }
}
```

It will not be common to create Indexer classes, but it is uselful to know that this could be happening.

## Inheritance

Syntax
```cs
public class PresentationObject
{
  // Common shared code
}

public class Text : PresentationObject
{
  // Code specific to Text
}
```

Classes can only inherit from ONE parent class.

## Composition
Describes a Has-a relationship.  Be careful not to be too literal when deciding between Inheritance and composition!

```cs
class Animal
{
    public void Eat()
    {
    	Console.WriteLine("Eating...");
    }
}

class Walkable
{
    public void Walk()
    {
    	Console.WriteLine("Walking...");
    }
}

class Swimmable
{
    public void Swim()
    {
    	Console.WriteLine("Swimming...");
    }
}

class Dog {}
class Cat {}
class Fish{}
```

### Access Modifiers
* Public - accessible basically anywhere
* Private - accessible only within that class
* Protected - accessible within that class, and its dependencies (inheritance etc...)
* Internal -


### Constructors and inheritance

Base Class constructors are always executed first.

Base class constructors are NOT inherited. In a derived class, you need to redefine your constructors.

```cs
public class Vehicle
{
  private string _registrationNumber;  

  public Vehicle(string registrationNumber)
  {
    _registrationNumber = registrationNumber;
  }
}

public class Car : Vehicle
{
  public Car(string registrationNumber)
    : base(registrationNumber)
  {
    // initialize fields specific to the Car class.
  }
}
```

### Upcasting/Downcasting

Converting a derived class to a base class (up), or base class to derived (down).

```cs
class Shape
{
    public void ImA()
    {
        Console.WriteLine("I'm a Shape");
    }
}

class Circle : Shape
{
    public void ImA()
    {
        Console.WriteLine("I'm a Circle");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var things = new List<Shape>();

        var shape1 = new Shape();
        var shape2 = new Shape();
        var circle1 = new Circle();
        var circle2 = new Circle();

        //Adding circles to this list of shapes upcasts them all to shapes.
        things.Add(shape1);
        things.Add(circle1);
        things.Add(shape2);
        things.Add(circle2);

        foreach(var thing in things)
        {
            //Use `as` to test if a thing can be downcast - it will return null if not, the thing if yes.
            Circle circle = thing as Circle;
            if(circle != null)
            {
                circle.ImA();
                continue;
            }

            thing.ImA();
        }

    }
}
```
