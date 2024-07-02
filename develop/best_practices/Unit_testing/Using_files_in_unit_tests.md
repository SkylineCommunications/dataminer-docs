---
uid: Using_files_in_unit_tests
---

# Using files in unit tests

Sometimes, tests need to be created that use one or more files as test data. To make sure the files are available in the test, some additional effort is needed. The following problems need to be overcome:

- The build output of the test project might not always be created on the same location relative to the files.
- The working directory of the test runner might change depending on the tool that is executing it.

## Ensuring that the files are copied to the build output directory

You can solve the first problem by ensuring that the files are copied to the build output directory.

1. Put the files in the directory of the test project and add them to the project via the *Add Existing Item* context menu action in the *Solution Explorer*.

   ![unittesting9.png](~/develop/images/unittesting9.png)

   You can also organize the files by adding folders to the project. To avoid confusion, it is advised that you use the same folder structure in the project directory as in the *Solution Explorer*.

1. Right-click a file in the *Solution Explorer* and select *Properties*.

   ![unittesting10.png](~/develop/images/unittesting10.png)

1. Modify the properties as follows:

   ![unittesting11.png](~/develop/images/unittesting11.png)

   Setting these properties will cause the file to be copied to the build output directory. The file will now always have the same location relative to the test assembly.

1. Repeat the steps above for any other files that need to be available.

## Ensuring that the files are copied to the correct location for each test

To deal with the second issue, the possibility that the working directory of the test runner changes depending on the tool executing it, the source code of the test must be modified a little. *MSTestv2* provides the `DeploymentItemAttribute` specifically for this problem.

Let us have a look at an example for the test class:

```csharp
[TestClass]
public class ImportTests
{
    [TestMethod]
    [DeploymentItem(@"Import Test Files\default.json")]
    public void NormalConfigTest()
    {
        // Arrange
        var expected = ...
        // Act
        QAction_1.KpiConfig.ImportFromFile("default.json");
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    [TestMethod]
    [DeploymentItem(@"Import Test Files\unexpected whitespace.json")]
    public void ModifiedWithWhitespaceTest()
    {
        // Arrange
        var expected = ...
        // Act
        QAction_1.KpiConfig.ImportFromFile("unexpected whitespace.json");
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
```

The attribute ensures that the files are copied to the correct location before each test starts.

You can add this attribute multiple times if your test needs multiple files.

If you need the same files for multiple tests, you can also add the attribute to the class instead:

```csharp
[TestClass]
[DeploymentItem(@"Import Test Files\default.json", "Import Test Files")]
[DeploymentItem(@"Import Test Files\unexpected whitespace.json", "Import Test Files")]
public class ImportTests
{
    [TestMethod]
    public void NormalConfigTest()
    {
        // Arrange
        var expected = ...
        // Act
        var actual = QAction_1.KpiConfig.ImportFromFile(@"Import Test Files\default.json");
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    [TestMethod]
    public void ModifiedWithWhitespaceTest()
    {
        // Arrange
        var expected = ...
        // Act
        var actual = QAction_1.KpiConfig.ImportFromFile(@"Import Test Files\unexpected whitespace.json");
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
```

Note the second parameter that was added to the attribute. It creates a directory with that name and puts the file inside it. Use this when you want to separate the files in different folders in case they have the same name.

## Useful links

- [How to: Deploy Files for Tests](https://learn.microsoft.com/en-us/previous-versions/ms182475(v=vs.140))
