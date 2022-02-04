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
