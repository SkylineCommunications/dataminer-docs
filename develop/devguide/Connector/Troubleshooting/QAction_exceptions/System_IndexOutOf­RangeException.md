---
uid: System_IndexOutOfRangeException
---

# System.IndexOutOfRangeException

This exception is thrown when working with array objects and trying to get or set a member of the array that is not in the defined array size.

## Example 1

```csharp
string[] members = new[] { "a" };
for (int i = 0; i <= members.Length; i++)
{
    if (members[i] == "fail")
```

This example will iterate and requests `members[0]` and `members[1]` in the if clause. Because the array size only contains one member and the access is zero-based, it will generate an exception when trying to access `members[1]`.

### Solution 1.A

Stop the for loop on time. The property *members.Length* will be equal to 1 and you do not want to request that index 1. You can do so by changing the "<=" into "<":

```csharp
for (int i = 0; i < members.Length; i++)
```

### Solution 1.B

Use a *foreach* loop. This means that you do not have to explicitly address the item in the array. The downside of this is that it is harder if you need to know whether inside the loop it is the first item or the last item in the iteration.

```csharp
foreach(string member in members)
{
    if (member == "fail")
```

## Example 2

```csharp
uint[] currentIds = new uint[] { Parameter.counter_data_offload_4003, Parameter.data_offload_folder_5000 };
object[] currentParam = (object[])protocol.GetParameters(currentIds);
int counterDataOffload_4003 = Convert.ToInt32(currentParam[0]);
string dataOffloadFolder_5000 = Convert.ToString(currentParam[1]);
string wrongDataOffloadFolder_5002 = Convert.ToString(currentParam[2]);
```

Accessing `currentParam[2]` will fail as only 2 parameters were requested. It could be that this parameter was requested in the past but got removed, and the fact that the processing of the parameter also had to be removed was overlooked.

A second problem that could occur is that it is not certain if the object that is returned will be in the expected format. This could be a null object or it might not have the expected size.

### Best practice

You can easily avoid accessing members outside of the array. While you could add an `if(indexToBeAccessed < currentParam.Length)` around every member that is accessed, all these checks will make your code less readable and this will only keep the exceptions from being generated. It will also hide the problem that some code is still using the variable *wrongDataOffloadFolder_5002*, which is no longer requested.

Instead, you can add a verification of the object that is being returned. For example:

```csharp
if(currentParam == null || currentIds.Length != currentParam.Length)
```

Add the appropriate logging in that if clause and then exit that method. The code will not be able to fix the problem, but at least you will know where it goes wrong and the root cause might be something external.

Assign the members of the *currentParam* object to variables immediately under the *GetParameters* call. If another developer needs to change something to the collection, this makes it easier to avoid it being overlooked.
