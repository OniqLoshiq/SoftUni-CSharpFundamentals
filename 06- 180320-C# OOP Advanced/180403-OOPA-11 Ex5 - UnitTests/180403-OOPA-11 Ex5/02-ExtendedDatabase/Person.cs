namespace _02_ExtendedDatabase
{
    public class Person : IPerson
    {
        public long Id { get; private set; }

        public string Username { get; private set; }

        public Person(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Person)) return false;

            Person person = (Person)obj;

            return this.Id == person.Id & this.Username == person.Username;
        }
    }
}
