# Compare .NET Objects for NUnit

_This library is discontinued. If you're looking for an alternative, I recommend checking out [Fluent Assertions](https://github.com/fluentassertions/fluentassertions)_

Hassle-free deep object comparison assertions for NUnit.

This is basically a wrapper for a great [Compare .NET Objects](https://github.com/GregFinzer/Compare-Net-Objects/) library.

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
