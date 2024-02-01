---
uid: FluentAssertions
---

# FluentAssertions

As mentioned earlier, the third step in a unit test is the Assert step. The section below provides some more info on assertions.

## Performing assertions on collections

When writing a unit test, it may happen that you want to perform an assertion on a collection. You can do this by using the `CollectionAssert` class.

Consider the following example where you call a method and expect a collection with items "A", "B" and "C" to be returned:

```csharp
// Arrange
List<string> expected = new List<string>() { "A", "B", "C" };
// Act
ICollection<string> returned = …
// Assert
CollectionAssert.AreEquivalent(expected, returned.ToList());
```

The example makes use of the `AreEquivalent` method, which checks whether two collections contain the same elements. In case order is important, `AreEqual` can be used. For more information on the `CollectionAssert` class, see [CollectionAssert Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.collectionassert?view=mstest-net-1.3.2).

Now suppose the returned collection contains "A", "B" and "D". When running the unit test, you will get the following result in test explorer:

```txt
CollectionAssert.AreEquivalent failed. The expected collection contains 1 occurrence(s) of <C>. The actual collection contains 0 occurrence(s).
```

The message indicates that an occurrence of "C" was expected.

Now suppose that the returned collection is a collection of a custom type `Path` instead of strings:

```csharp
public struct Path
{
public Path(string item)
    {
        this.Item = item;
    }
    public string Item { get; set; }
}
// Arrange
List<Path> expected = new List<Path>() { new Path("A"), new Path("B"), new Path("C") };
// Act
ICollection<Path> returned = …
// Assert
CollectionAssert.AreEquivalent(expected, returned.ToList());
```

Again, suppose the method under test returns a collection with a wrong item. In this case, the message looks like this:

```txt
CollectionAssert.AreEquivalent failed. The expected collection contains 1 occurrence(s) of <MyNamespace.Path>. The actual collection contains 0 occurrence(s).
```

Now this message is not that useful for debugging. You could solve this by overriding the implementation of the `ToString` method in the `Path` type:

```csharp
public struct Path
{
public Path(string item)
    {
        this.Item = item;
    }
    public string Item { get; set; }
    public override string ToString()
    {
        return Item;
    }
}
```

This will result in the following message:

```txt
CollectionAssert.AreEquivalent failed. The expected collection contains 1 occurrence(s) of <B>. The actual collection contains 0 occurrence(s).
```

However, this solution assumes you can change type. Alternatively, you can use *FluentAssertions*.

## Using FluentAssertions

*FluentAssertions* can help you in performing advanced assertions while keeping the assertion easy to read and understand.

*FluentAssertions* is available as a NuGet package. To start using the *FluentAssertions* library, select your test project in the *Solution Explorer*, right-click it, and select *Manage NuGet Packages*. Click *Browse* and type "FluentAssertions". Select the package and click the *Install* button.

![unittesting8.png](~/develop/images/unittesting8.png)

Using *FluentAssertions*, the assertion can be rewritten as follows:

```csharp
// Arange
List<Path> expected = new List<Path>() { new Path("A"), new Path("B"), new Path("C") };
// Act
ICollection<Path> returned = …
// Assert
returned.Should().BeEquivalentTo(expected);
```

The assertion is easy to understand, thanks to the *fluent* API. Now, when you execute this test again, the message will look like this:

```txt
Expected item[1] to be
MyNamespace.Path
{
   Item = “B”
}, but found
MyNamespace.Path
{
   Item = “D”
}.
With configuration:
– Use declared types and members
– Compare enums by value
– Include all non-private properties
– Include all non-private fields
– Match member by name (or throw)
– Without automatic conversion.
– Without automatic conversion.
– Be strict about the order of items in byte arrays
```

Now the message gives more information about what went wrong.

## Useful links

- [Introduction to FluentAssertions](https://fluentassertions.com/introduction)
