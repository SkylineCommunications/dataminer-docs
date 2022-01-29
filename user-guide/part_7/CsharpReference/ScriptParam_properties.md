---
uid: ScriptParam_properties
---

# ScriptParam properties

### Id

Gets the ID of the script parameter

```txt
int Id
```

### Name

Gets the name of the script parameter.

```txt
string Name
```

### Value

Gets the value of the script parameter.

```txt
string Value
```

Example:

```txt
// Retrieving the value by using the parameter ID.
ScriptParam paramUser = engine.GetScriptParam(65000);
string userDescription = paramUser.Value;
```
