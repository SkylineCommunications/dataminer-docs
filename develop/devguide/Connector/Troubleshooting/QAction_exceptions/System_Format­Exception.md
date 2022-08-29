---
uid: System_FormatException
---

# System.FormatException

When converting between types, it can be that the format of the input does not match what is expected.

## Example

```csharp
string test = "test";
int iTest = Convert.ToInt32(test);
```

The above string cannot be converted to a number. This will generate the exception *System.FormatException: Input string was not in a correct format*.

### Solution

Use a *TryParse* when trying to convert items.

```csharp
int iTest;
if(Int32.TryParse(test, out iTest))
```

This can optionally be combined with the if clause. When the parsing fails, the method will return false, and the out value will be set to the default value (which is 0 in case of an integer).