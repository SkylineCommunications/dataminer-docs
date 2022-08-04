---
uid: System_Collections_Generic_KeyNotFoundException
---

# System.Collections.Generic.KeyNotFoundException

Accessing an item in a dictionary of which the key does not exist will result in a *KeyNotFoundException*.

## Example

```csharp
Dictionary<string, Person> persons = new Dictionary<string, Person>();
string id = "1";
string personName = persons[id].Name;
int personAge = persons[id].Age;
```

This will result in an exception because key "1" does not exist in the dictionary.

### Solution A

A solution could be to first verify if the key exists before accessing it:

```csharp
if (persons.ContainsKey(id))
{
    string personName = persons[id].Name;
    int personAge = persons[id].Age;
}
```

The above code will work without throwing an exception. However, a minor problem with above is that the dictionary needs to be accessed three times: once to check if the key exists and the second and third time to actually get the values. Solution B is therefore preferred.

### Solution B

```csharp
Person person;
if (persons.TryGetValue(id, out person))
{
    string personName = person.Name;
    int personAge = person.Age;
}
```

This will only access the dictionary once. When the key is present, the value will be accessible through the out variable and the method will return true.

> [!NOTE]
> As this is object-oriented programming, when the dictionary has a class object as value, the reference to that value is retrieved. In other words, if you change a property like `person.Name = changedName;`, this will change the original item in the dictionary. If the dictionary contains an integer type as value, and you execute `if(persons.TryGetValue(id, out age))` and later set `age = 30;`, this will only change the local variable, not the value that is present in the dictionary.
