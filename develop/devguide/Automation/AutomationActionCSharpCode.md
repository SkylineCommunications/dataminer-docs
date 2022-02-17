---
uid: AutomationActionCSharpCode
---

# C# code

Executes C# code.

```xml
<Exe id="2" type="csharp">
   <Value><![CDATA[my code]]></Value>
   <Param type="using">mynamespace</Param>
   <Param type="ref">myreference</Param>
   <Param type="scriptRef">my script ref</Param>
   <Param type="debug">true</Param>
   <Param type="preCompile">true</Param>
   <Param type="libraryName">testname</Param>
   <Message></Message>
</Exe>
```

Required items:

- Value: The C# code to execute.
- Param (type="using"): The namespace references
- Param (type="ref"): DLL references. To provide multiple DLL references, provide multiple elements with Param@type set to "ref".
- Param (type="scriptRef"), script references.
- Param (type="debug"): Indicates whether to compile in debug mode. Value is either "true" or "false".
- Param (type="preCompile"): Indicates whether to precompile. Value is either "true" or "false".
- Param (type="libraryName"): Library name. Only required when pre-compilation is enabled.
