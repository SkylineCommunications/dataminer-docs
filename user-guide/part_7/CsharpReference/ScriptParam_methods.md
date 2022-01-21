---
uid: ScriptParam_methods
---

## ScriptParam methods

#### SetParamValue

Sets the specified value to the script parameter.

```txt
void SetParamValue(string newValue)
```

Example:

```txt
ScriptParam myScriptParam = engine.GetScriptParam("param1");
myScriptParam.SetParamValue("myValue");
```
