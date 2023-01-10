---
uid: How_do_I_retrieve_the_current_value_of_a_script_parameter
---

# How do I retrieve the current value of a script parameter?

You can retrieve the current value of a script parameter in C# by means of the *GetScriptParam* method of the engine object.

## Example 1

The following example shows you how to retrieve the current value of the parameter named *\<User Description>*:

```cs
// Retrieving the value by using the parameter name
ScriptParam paramUser = engine.GetScriptParam("<User Description>");
// Copying the retrieved value into a string
string userDescription = paramUser.Value;
```

## Example 2

The following example shows you how to retrieve the current value of the parameter with ID 65000:

```cs
// Retrieving the value by using the parameter ID
ScriptParam paramUser = engine.GetScriptParam(65000);
// Copying the retrieved value into a string
string userDescription = paramUser.Value;
```
