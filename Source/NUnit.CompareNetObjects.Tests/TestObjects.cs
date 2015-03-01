namespace NUnit.CompareNetObjects.Tests
{
    enum Level
    {
        Baby, Junior, Medior, Senior
    }

    class Skill
    {
        public string Name { get; set; }
        public int Level { get; set; }
    }

    class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
    }

    class Person
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public Level Level { get; set; }
        public Address Address { get; set; }
        public Skill[] Skills { get; set; }
    }

    static class PersonFactory
    {
        public static Person CreateSamplePerson()
        {
            return new Person
            {
                Name = "Foo",
                Points = 100,
                Level = Level.Medior,
                Address = new Address
                {
                    City = "Bar",
                    Street = "Biz"
                },
                Skills = new[]
                {
                    new Skill
                    {
                        Name = "Programming",
                        Level = 10
                    },
                    new Skill
                    {
                        Name = "Social skills",
                        Level = 0
                    }
                }
            };
        }
    }
}