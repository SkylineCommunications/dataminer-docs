---
uid: Code_Robustness
---

# Code Robustness

## Convert.ToString()

- (string)o: Fastest internally, but assumes the object already IS a string. If it isn't, this will throw exceptions.
- o.ToString(): will call the default .ToString() on any object, so this will work for objects that aren't already strings. BUT it will fail if the object is null!!
- Convert.ToString(o): This is the most robust way, if o is null it won't fail it will create an empty string. Any other object will call the .ToString() internally. <-- It's recommended to always use this to ensure robust code when dealing with SLProtocol.

> [!IMPORTANT]  
> Only if the provided value is an OBJECT that is null, will it create String.Empty.
> If the provided object is a STRING that is null, it will return a null.

## Type Conversion with As

Don't do this:
// Bad code - checks type twice for no reason

```csharp
if (randomObject is TargetType)
{
    TargetType foo = (TargetType) randomObject;
    // Do something with foo
}
```

If randomObject might be an instance of TargetType and TargetType is a reference type, then use code like this:

```csharp
TargetType convertedRandomObject = randomObject as TargetType;
if (convertedRandomObject != null)
{
    // Do stuff with convertedRandomObject
}
```

If randomObject might be an instance of TargetType and TargetType is a value type, then we can't use as with TargetType itself, but we can use a nullable type:

```csharp
TargetType? convertedRandomObject = randomObject as TargetType?;
if (convertedRandomObject != null)
{
    // Do stuff with convertedRandomObject.Value
} 
```
