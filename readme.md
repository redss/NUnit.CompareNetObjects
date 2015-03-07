# Compare .NET Objects for NUnit

_This library is work in progress._

Hassle-free deep object comparison assertions for NUnit.

This is basically a wrapper for a great [Compare .NET Objects](https://comparenetobjects.codeplex.com/) library.

See for yourself:

```C#
var result = sut.CreateProgrammer();

var expected = new Person
{
    Name = "Josh",
    Skills = new[]
    {
        new Skill
        {
            Name = "Programming",
            Level = 10
        }
    }
};

Assert.That(result, IsDeeplyEqual.To(expected));
```

Intall it via NuGet:

```
PM> Install-Package NUnit.CompareNetObjects
```