---
uid: AutomationEntryPointAttribute_class
---

# AutomationEntryPointAttribute class

Below, you find an overview of all members of the *AutomationEntryPointAttribute* class.

- [AutomationEntryPointAttribute constructor](AutomationEntryPointAttribute_constructor.md)

- [AutomationEntryPointAttribute methods](AutomationEntryPointAttribute_methods.md)

- [AutomationEntryPointAttribute properties](AutomationEntryPointAttribute_properties.md)

- [Explicit interface implementations](Explicit_interface_implementations.md)

This C# class (available from DataMiner 9.5.12 onwards) indicates that a method can be used as an Automation script entry point.

The entry points must be public, and may be static or non-static.

The method names and parameter names can be chosen at will.

Restrictions:

- An Automation script using custom entry points can have only one executable action, which must be a C# code block.

- If, in a C# code block, you have defined multiple entry points, you must make sure they are of different types. Multiple entry points of the same type are not allowed.

- For reasons of backward compatibility, it is recommended to use the Script class as the entry point class for a script. Although this is no longer strictly required, it is good practice to add a Script class to a C# code block, even if it is empty.

Examples:

- Defining a custom entry point:

    ```txt
    [AutomationEntryPoint(AutomationEntryPointType.Types.Default)]
    public void Default(Engine engine)
    {
     engine.GenerateInformation(""Default"");
    }
    ```

- For testing purposes, you can use AutomationEntryPointTest:

    ```txt
    [AutomationEntryPoint(AutomationEntryPointType.Types.AutomationEntryPointTest)]
    public void AutomationEntryPointTest(Engine engine, string testMessage, List<int> testIntList)
    {
     engine.GenerateInformation(""AutomationEntryPointTest: "" + testMessage + "" "" + string.Join("", "", testIntList.ToArray()));
    }
    ```
