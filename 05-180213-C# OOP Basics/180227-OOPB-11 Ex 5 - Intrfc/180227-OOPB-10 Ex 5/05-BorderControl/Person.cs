public class Person : EnteringObject
{
    public int Age { get; private set; }

    public Person(string name, string id, int age) : base(name, id)
    {
        this.Age = age;
    }
}
