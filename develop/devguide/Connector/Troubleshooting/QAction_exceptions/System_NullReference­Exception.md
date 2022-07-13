---
uid: System_NullReferenceException
---

# System.NullReferenceException

*"Object reference not set to an instance of an object"*

While there is no need to instantiate the basic local variables, like int, bool, double, etc. most other objects need to be created by calling the constructor with the magic word "new". If methods or properties of the object are accessed without the object being instantiated, a null reference exception will be thrown.

Three special cases:

- String variables can be null (as it is a reference type), but do not have the "new" key word to be instantiated. Simply assign a value to them.
- Static methods and properties can be accessed without calling the constructor.
- A nullable int, bool, double, etc. can be defined by adding a question mark, e.g. `double? bitrate;`

## Example 1

Data enters in JSON format, which is being deserialized. Suppose that you want to know if the street property that is present in *person.LocationInfo.Street* starts with "Test".

If you were sure that all the items are in there, then the simple call would be this:

```csharp
if (person.LocationInfo.Street.StartsWith("Test"))
```

However, the problem is that *person*, *LocationInfo*, or *Street* could be null, and accessing items of these members could generate null reference exceptions.

### Solution 1.A

Verify every member before accessing it:

```csharp
if(person != null 
&& person.LocationInfo != null 
&& person.LocationInfo.Street != null 
&& person.LocationInfo.Street.StartsWith("Test"))
```

The downside of this is that when the depth of items to check is too large, SonarQube will complain that there are too many conditional operators used in the expression. It will also affect the complexity calculation of the code.

### Solution 1.B

Since C# 6 and later, a null-conditional member access operator `?.` is available, also known as the Elvis operator. This will return null when one of the members is null. This can then be combined with the null-coalescing operator `??`.

```csharp
if (person?.LocationInfo?.Street?.StartsWith("Test") ?? false)
```

If *person*, *LocationInfo* or *Street* is empty, null will be returned. With the `??` check, this will be translated to false, so that the content inside the if clause will not be executed. If none of the members are null, the normal result of the *StartsWith* method will be used.

Note that this requires at least DataMiner feature release 9.6.11 or DataMiner main release 10.0. Drivers that need to be compatible with DataMiner versions prior to 9.6.11 will need to use solution 1.A.

## Example 2

Converting to a string can give different results:

```csharp
string folder = Convert.ToString(protocol.GetParameter(Parameter.data_offload_folder_5000));
if (folder.EndsWith("\\"))
```

Even though the *protocol.GetParameter* method will return null when the parameter is not initialized, using *Convert.ToString* on a null object will translate this into a valid referenced empty string on which you can safely call the members or methods such as ".EndsWith".

Suppose that `string folder = Convert.ToString(person.Folder);` and *person.Folder* is a string type but also null, then *Convert.ToString* on a null string will return a null string. When methods such as ".EndsWith" are called, this will result in a null reference exception.

### Solution 2.A

Add an extra check to make sure the string is not null or empty before executing the method:

```csharp
if (!String.IsNullOrEmpty(folder) && folder.EndsWith("\\"))
```

### Solution 2.B

Use the Elvis operator (requires C# 6):

```csharp
if (folder?.EndsWith("\\") ?? false)
```
