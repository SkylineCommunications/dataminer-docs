---
uid: DMSScript.Script.Exe.Param-type
---

# type attribute

Specifies the type of data this parameter holds.

## Content Type

When type is "csharp" the following values are possible:

- **using**: Specifies that this parameter holds the namespace references.
- **ref**: Specifies that this parameter holds the DLL references. (See also: [Assembly binding Automation scripts](xref:AssemblyResolvingAutomationScripts).)
- **scriptRef**: Specifies a reference to another script. The expected format is the name of the Automation script where the script resides followed by a colon and the name of the referenced script (this is the name as specified in the libraryName attribute of the script). To refer to a script in the current Automation script, the [AutomationScriptName] placeholder can be used. E.g. "[AutomationScriptName]:MyCSharpAction".
- **debug**: Specifies that this parameter holds the compile in debug mode flag.
- **preCompile**: Specifies that this C# action must be compiled as a library. The value is either "true" or "false". Default: "false".
- **libraryName**: Specifies the name of the library.

When type is "script" the following values are possible:

- DEFER
- CHECKSETS: Specifies that after executing a SET command, it is checked that the read parameter has been set to the new value.
- OPTIONS

## Parent

[Param](xref:DMSScript.Script.Exe.Param)

## Remarks

Used with script actions of type "csharp", "script".
