---
uid: Data_driven_tests
---

# Data-driven tests

Data-driven testing is about providing a unit test with data that is then used during the execution of the unit test. This is particularly useful in situations where you want to run a unit test with different input data to verify that the business logic the unit test was written for covers all possible scenarios.

Below, we discuss the possibilities MSTest V2 provides related to data-driven testing.

## DataRow attribute

The *DataRow* attribute allows you to define inline data for a test method. Consider the following example where a unit test verifies whether the multiplication operation of a calculator is behaving as expected:

```csharp
[TestClass]
public class CalculatorTests
{
    [TestMethod]
    [DataRow(0, 10, 0)]
    [DataRow(10, 0, 0)]
    [DataRow(1, 10, 10)]
    [DataRow(10, 1, 10)]
    [DataRow(2, 4, 8)]
    public void MultiplyTest(int multiplicand, int multiplier, int product)
    {
        // Arrange
        Calculator myCalculator = new Calculator();
        // Act
        var result = myCalculator.Multiply(multiplicand, multiplier);
        // Assert
        Assert.AreEqual(product, result);
    }
}
```

In the example above, the `MultiplyTest` method has been annotated with multiple *DataRow* attributes. Each [DataRow attribute](https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.datarowattribute?view=visualstudiosdk-2022&viewFallbackFrom=mstest-net-1.3.2) will result in the execution of the unit test.

![datadriven1.png](~/develop/images/datadriven1.png)

## DynamicData attribute

The *DataRow* attribute has some drawbacks:

- When you have multiple unit tests where you would like to use the same input data, the tests need to be annotated with all the *DataRow* attributes.
- Attribute arguments must be a constant expression, typeof expression, or an array creation expression of an attribute parameter type.

The *DynamicData* attribute can be used to alleviate these problems. It works as follows:

In your test class, create a property or a method that has the test data.

```csharp
private static IEnumerable<object[]> TestData
{
    get
    {
        return new[]
        {
            new object[] {0, 10, 0},
            new object[] {10, 0, 0},
            new object[] {1, 10, 10},
            new object[] {10, 1, 10},
            new object[] {2, 4, 8}
        };
    }
}
```

Then annotate your test method with the *DynamicData* attribute, which refers to the property or method that provides the test data.

```csharp
[TestMethod]
[DynamicData("TestData")]
public void MultiplyTest(int multiplicand, int multiplier, int product)
{
    // Arrange
    Calculator myCalculator = new Calculator();
    // Act
    var result = myCalculator.Multiply(multiplicand, multiplier);
    // Assert
    Assert.AreEqual(product, result);
}
```

If the test data is provided via a method, the attribute must specify that the data source type is of type *Method* (the default is *Property*):

```csharp
[DynamicData("TestData", DynamicDataSourceType.Method)]
```

It is also possible to refer to a method or property that is defined in another class (e.g., the class `UnitTestData` in the example below):

```csharp
[DynamicData("TestData", typeOf(UnitTestData))]
```

For more information about the *DynamicData* attribute, see [DynamicDataAttribute class](https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.dynamicdataattribute?view=visualstudiosdk-2022&viewFallbackFrom=mstest-net-1.3.2).

## DataSource attribute

In scenarios where your test data resides in an external data source, you can use the *DataSource* attribute. Different data sources are supported, such as an XML file, CSV, a database, or an Excel sheet.

The following example illustrates the use of this attribute with an XML file:

```csharp
[TestMethod()]
[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"C:\Test\TestData.xml", "Row", DataAccessMethod.Sequential)]
public void MultiplyTest()
{
    // Arrange
    Calculator myCalculator = new Calculator();
    int multiplicand = Convert.ToInt32(TestContext.DataRow["Multiplicand"]);
    int multiplier = Convert.ToInt32(TestContext.DataRow["Multiplier"]);
    int product = Convert.ToInt32(TestContext.DataRow["Product"]);
    // Act
    var result = myCalculator.Multiply(multiplicand, multiplier);
    Assert.AreEqual(product, result,
        "multiplicand:<{0}>, multiplier:<{1}>",
        new object[] { multiplicand, multiplier });
}
```

The *DataSource* attribute specifies all info needed to use the data source. For more details about how to use this attribute, see [DataSourceAttribute class](https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.datasourceattribute?view=visualstudiosdk-2022&viewFallbackFrom=mstest-net-1.3.2).

The content of the XML file is then as follows (note that the *DataSource* attribute specifies "Row" as this is the name used for each entry in the XML file):

```xml
<testsuite>
    <Row>
        <Multiplicand>0</Multiplicand>
        <Multiplier>10</Multiplier>
        <Product>0</Product>
    </Row>
    <Row>
        <Multiplicand>10</Multiplicand>
        <Multiplier>0</Multiplier>
        <Product>0</Product>
    </Row>
    <Row>
        <Multiplicand>1</Multiplicand>
        <Multiplier>10</Multiplier>
        <Product>10</Product>
    </Row>
    <Row>
        <Multiplicand>10</Multiplicand>
        <Multiplier>1</Multiplier>
        <Product>10</Product>
    </Row>
    <Row>
        <Multiplicand>2</Multiplicand>
        <Multiplier>4</Multiplier>
        <Product>8</Product>
    </Row>
</testsuite>
```

Also note that the test method implementation also references a *TestContext* property. This is a property you need to provide as a member of your test class. The unit test framework will then create a *TestContext* object and set this property with the created value.

```csharp
[TestClass]
public class CalculatorTests
{
    private TestContext testContextInstance;
    public TestContext TestContext
    {
        get { return testContextInstance; }
        set { testContextInstance = value; }
    }
    ...
}
```

For more information about the *TestContext* class, see [TestContext class](https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.testcontext?view=visualstudiosdk-2022&viewFallbackFrom=mstest-net-1.3.2).

Each entry in the data source will result in the execution of the unit test:

![datadriven2.png](~/develop/images/datadriven2.png)

## ITestDataSource interface

Instead of using the "DataSource attribute" approach, you can also choose to define a class that implements the [ITestDataSource interface](https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.itestdatasource?view=visualstudiosdk-2022&viewFallbackFrom=mstest-net-1.3.2) and extends the `Attribute` class.

This `ITestDataSource` interface has only two methods: `GetData` and `GetDisplayName`:

```csharp
public class MyDataSourceAttribute : Attribute, ITestDataSource
{
    public IEnumerable<object[]> GetData(MethodInfo methodInfo)
    {
        yield return new object[] { 0, 10, 0 };
        yield return new object[] { 10, 0, 0 };
        yield return new object[] { 1, 10, 10 };
        yield return new object[] { 10, 1, 10 };
        yield return new object[] { 2, 4, 8 };
    }
    public string GetDisplayName(MethodInfo methodInfo, object[] data)
    {
        if (data != null)
        {
            return String.Format(CultureInfo.CurrentCulture, "{0} - multiplicand: {1}, multiplier: {2}", methodInfo.Name, data[0], data[1]);
        }
        return null;
    }
}
```

To use this class as a data source for a test, annotate the test method with the created attribute:

```csharp
[TestMethod]
[MyDataSource]
public void MultiplyTest(int multiplicand, int multiplier, int product)
{
    // Arrange
    Calculator myCalculator = new Calculator();
    // Act
    var result = myCalculator.Multiply(multiplicand, multiplier);
    // Assert
    Assert.AreEqual(product, result);
}
```

Again, this results in multiple executions of the unit test, each time with different data.

![datadriven3.png](~/develop/images/datadriven3.png)

## Useful links

- [Create a data-driven unit test](https://learn.microsoft.com/en-us/visualstudio/test/how-to-create-a-data-driven-unit-test?view=vs-2019)
- [DataSource attribute vs ITestDataSource](https://github.com/microsoft/testfx-docs/blob/main/RFCs/007-DataSource-Attribute-VS-ITestDataSource.md)
- [DynamicData attribute for Data-driven tests](https://github.com/microsoft/testfx-docs/blob/main/RFCs/006-DynamicData-Attribute.md)
- [Framework extensibility for custom test data source](https://github.com/microsoft/testfx-docs/blob/main/RFCs/005-Framework-Extensibility-Custom-DataSource.md)
