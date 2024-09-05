---
uid: Writing_testable_code
---

# Writing testable code

Below, you can find how applying the concept of dependency injection and the use of interfaces is useful to create testable code.

## Refactoring code for better testability

Consider the following example of defining a path cache. This class allows you to add paths, and the cache will hold the rewritten paths. You can inspect the cache using the `CachedItems` property.

```csharp
public sealed class PathCache
{
    private readonly HashSet<string> cachedPaths;
    private readonly PathRewriter pathRewriter;
    public PathCache()
    {
        pathRewriter = new PathRewriter();
        cachedPaths = new HashSet<string>();
    }
    public void AddPath(string path)
    {
        string rewrittenPath = pathRewriter.RewritePath(path);
        cachedPaths.Add(rewrittenPath);
    }
    public IEnumerable<string> CachedItems
    {
        get { return cachedPaths.ToList().AsReadOnly();}
    }
}
```

Now a unit test is needed in order to verify that this class is working correctly. Suppose you write the following test:

```csharp
[TestMethod()]
public void AddPath_ValidPath_PathPresentInCache()
{
    // Arrange
    PathCache cache = new PathCache();
    string path = @"Visios\Customers\Skyline\Protocols\Test";
    string expectedPath = @"V\C\Skyline\P\Test";
    // Act
    cache.AddPath(path);
    // Assert
    CollectionAssert.Contains(cache.CachedItems.ToList(), expectedPath);
}
```

There is a problem with the test above. It is implicitly also testing the `Rewrite` method of the `PathRewriter` class. This means that in case the `Rewrite` method of the `PathRewriter` class does not work as expected, this unit test will also start to fail, even though the logic you are trying to test (which is adding items to the cache) might be implemented correctly. This is something that should be avoided.

The root cause of this problem is that there is a fixed dependency on the `PathRewriter` class. In the `PathCache` constructor, you can find the following:

```csharp
public PathCache()
{
    pathRewriter = new PathRewriter();
    cachedPaths = new HashSet<string>();
}
```

A way to overcome this is to use dependency injection. The following refactoring makes use of dependency injection through the constructor:

```csharp
public PathCache(PathRewriter rewriter)
{
    pathRewriter = rewriter;
    cachedPaths = new HashSet<string>();
}
```

Now you can provide or inject an instance of the `PathRewriter` class. However, you are still injecting the `PathRewriter` class. Ideally, you need to have more freedom on what you can pass along to avoid implicitly testing other code.

To achieve this, you can introduce an `IPathRewriter` interface (in Visual Studio, you can do this by putting your cursor over the `PathRewriter` class name, right-clicking, and selecting *Quick Actions and Refactoring* in the context menu. This will bring up another context menu where you can select *Extract interface*:

```csharp
public interface IPathRewriter
{
    string Rewrite(string path);
}
```

Now you can add the following to indicate that the `PathRewriter` class implements this interface:

```csharp
public class PathRewriter : IPathRewriter
```

Now update the `PathCache` class so it has a dependency on `IPathRewriter` instead of `PathRewriter`.

```csharp
public sealed class PathCache
{
    private readonly HashSet<string> cachedPaths;
    private readonly IPathRewriter pathRewriter;
    public PathCache(IPathRewriter rewriter)
    {
        pathRewriter = rewriter;
        cachedPaths = new HashSet<string>();
    }
    ...
}
```

These changes allow you to now create a unit test for the `PathCache` class that no longer depends on the `PathRewriter` class:

```csharp
[TestMethod()]
public void AddPath_ValidPath_PathPresentInCache()
{
    // Arrange
    string expectedPath = "rewrittenPath";
    Mock<IPathRewriter> pathRewriter = new Mock<IPathRewriter>();
    pathRewriter.Setup(p => p.Rewrite(It.IsAny<string>())).Returns(expectedPath);
    PathCache cache = new PathCache(pathRewriter.Object);
    string path = @"Visios\Customers\Skyline\Protocols\Test";
    // Act
    cache.AddPath(path);
    // Assert
    CollectionAssert.Contains(cache.CachedItems.ToList(), expectedPath);
}
```
