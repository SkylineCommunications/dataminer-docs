---
uid: Adding_CSharp_code_to_an_Automation_script
---

# Adding C# code to an automation script

## Adding C# code to a script in Cube

To add C# code to a script:

1. In DataMiner Cube, go to *Apps* > *Automation*.

1. In the *Automation* module, select the script to which you want to add C# code.

1. In the *Add Action* selection box, select *C# Code*.

1. In the field mentioning *Enter code here*, enter the C# code.

1. Click the downward arrow next to *Advanced* to configure any of the following settings:

   - *Namespace references*: Allows you to provide namespace references.

     > [!NOTE]
     > - This is only applicable in case the script block only contains the lines of code to execute (i.e. it does not make use of classes/methods). In case the C# block does make use of classes/methods, the using statement can be provided in the C# block itself.
     > - The following using statements are added by default:
     >   - using System
     >   - using System.IO
     >   - using Skyline.DataMiner.Automation
     >   - using Skyline.DataMiner.Net
     >   - using Skyline.DataMiner.Net.Exceptions
     >   - using Skyline.DataMiner.Net.Messages
     >   - using Skyline.DataMiner.Net.AutomationUI

   - *DLL references*: Allows you to reference DLLs that are required by the automation script.

     > [!NOTE]
     > The following DLLs are referenced by default:
     >
     > - System.dll
     > - System.Core.dll
     > - System.Xml.dll
     > - netstandard.dll (from DataMiner 10.1.11 onwards<!-- RN 30755 -->)
     > - SLManagedAutomation.dll
     > - SLNetTypes.dll
     > - Skyline.DataMiner.Storage.Types.dll
     > - SLLoggerUtil.dll
     > - SLAnalyticsTypes.dll (from DataMiner 10.1.11 onwards)
     >
     > To reference additional DLLs, e.g. a custom DLL placed in the `C:\Skyline DataMiner\ProtocolScripts` folder, you need to specify an absolute path.

   - *Script references*: Allows you to refer to other C# blocks. See [Compiling a C# code block as a library](xref:Compiling_a_CSharp_code_block_as_a_library).

> [!NOTE]
> DataMiner uses the .NET Compiler Platform SDK (version 2.9) to validate and compile C# scripts, allowing the use of C# syntax up to and including version 7.3.

## Engine object

You can interact with the Automation Engine by interacting with an instance of the Engine class.

When you type `engine.` in the code editor, you will be presented with a dropdown list of all statements available in the Automation Engine.

By default, C# code used in an automation script throws an exception when it encounters an undefined or an empty parameter. However, if you add the following line in an automation script action of type *C# code*, null will be returned instead.

Example:

```cs
engine.SetFlag(RunTimeFlags.AllowUndef);
```

> [!NOTE]
> You can also make sure no exception is thrown when an undefined or empty parameter is encountered in C# code by selecting the general option *C#: Return NULL instead of an exception upon a GetParameter of a non-initialized parameter*. See [General script configuration](xref:General_script_configuration).

> [!TIP]
> See also: [Skyline.DataMiner.Automation.Engine](xref:Skyline.DataMiner.Automation.Engine)

## Script class

- For small automation scripts, you can enter the logic to be executed without wrapping your code in a class and method.

    Example:

    ```cs
    engine.GenerateInformation("Hello");
    ```

    In the example above, DataMiner will create a class Script with a static method Run, where the provided content in the C# code field will form the body of this Run method:

    ```cs
    using System;
    using System.IO;
    using Skyline.DataMiner.Automation;
    using Skyline.DataMiner.Net;
    using Skyline.DataMiner.Net.Exceptions;
    using Skyline.DataMiner.Net.Messages;
    using Skyline.DataMiner.Net.AutomationUI;
    // Other using statements as defined in the Namespace references field.

    public class Script
    {
     public static void Run(Engine engine) {
     engine.GenerateInformation("Hello");
    }
    }
    ```

    > [!NOTE]
    > DataMiner will only perform this wrapping if it does not detect the string "class Script" in the code you provided.

- Alternatively, you can provide a class "Script" containing a "Run" method yourself in the C# code field.

    Example:

    ```cs
    using Skyline.DataMiner.Automation;
    public class Script
    {
        public void Run(Engine engine)
        {
            engine.GenerateInformation("Hello");
        }
    }
    ```

    > [!NOTE]
    > - If this approach is used, the provided content in the Namespace references field will be disregarded. Instead, provide the using statements in the C# block itself.
    > - If a C# block contains a class called Script within a namespace, that class will be used to launch the script.
    >
    >   ```cs
    >   namespace MyNamespace
    >   {
    >      public class Script
    >      {
    >         public void Run(Engine engine)
    >         {
    >            // ...
    >         }
    >      }
    >   }
    >   ```
    >
    > - Custom entry points are possible. See [Custom entry points](#custom-entry-points).

    > [!IMPORTANT]
    > Be careful how you handle async code in an automation script. See [Handling async code](xref:Handling_Async_Code).

## Preprocessor directives

DataMiner compiles C# blocks of automation scripts with the following preprocessor directives:

- DCFv1

- DBInfo

## Script timeout

To prevent problems caused by faulty script statements, every C# code block has a default timeout delay of 10 minutes. If the execution of a C# code block takes longer than 10 minutes, it is aborted.

Inside a code block, you can change the timeout delay for that particular code block by setting the Timeout property of the engine object.

Example:

```cs
engine.Timeout = TimeSpan.FromMinutes(30);
```

## Custom entry points

It is possible to define custom entry points for an automation script. To do so, provide the method you want to use as entry point with the attribute *AutomationEntryPointAttribute* and specify the type of the entry point. For a regular Automation script entry point, specify *AutomationEntryPointType.Types.Default*:

```cs
[AutomationEntryPoint(AutomationEntryPointType.Types.Default)]
public void Default(IEngine engine)
{
 engine.GenerateInformation("Default");
}
```

The method must match the following delegate type:

```cs
public delegate void Default(IEngine engine);
```

For testing purposes, you can use the *AutomationEntryPointTest* type:

```cs
[AutomationEntryPoint(AutomationEntryPointType.Types.AutomationEntryPointTest)]
public void AutomationEntryPointTest(Engine engine, string testMessage, List<int> testIntList)
{
 engine.GenerateInformation("AutomationEntryPointTest: " + testMessage + " " + string.Join("", "", testIntList.ToArray()));
}
```

Methods annotated with the test type attribute must match the following delegate type:

```cs
public delegate void AutomationEntryPointTest(IEngine engine, string testMessage, List<int> testIntList);
```

> [!NOTE]
>
> - The entry points must be public. They may be static or non-static.
> - The method names and parameter names can be chosen at will.
> - Cube does not support custom entry points. As such, to execute an automation script from Cube, you need a Script class with a Run method. Custom entry points can be used when executing an automation script using the *ExecuteScriptMessage* class.

Restrictions:

- An Automation script using custom entry points can have only one executable action, which must be a C# code block.

- If, in a C# code block, you have defined multiple entry points, you must make sure they are of different types. Multiple entry points of the same type are not allowed.

- For reasons of backward compatibility, we recommend using the Script class as the entry point class for a script.

- The script must contain the string "class Script" as otherwise DataMiner will wrap the code. See [Script class](#script-class).

> [!IMPORTANT]
> Be careful how you handle async code in an automation script. See [Handling async code](xref:Handling_Async_Code).

> [!NOTE]
> From DataMiner 10.5.7/10.6.0 <!-- RN 42969 --> onwards, the [OnRequestScriptInfo](xref:Skyline.DataMiner.Automation.AutomationEntryPointType.Types.OnRequestScriptInfo) entry point allows other automation scripts (or any other code) to request information about the script in question. Information about implementing that entry point and executing it is available in [this how-to](xref:Implementing_OnRequestScriptInfo_Entry_Point).

## Online help and user assistance

> [!TIP]
> See also: [The Basics of DataMiner Automation Snippets](https://www.youtube.com/watch?v=i5_FLER_-tE) ![Video](~/dataminer/images/video_Duo.png)

### Sample snippets in shortcut menu

When you right-click in the code editor, a shortcut menu will appear. From the *Sample Snippets* submenu, you can select a number of C# sample snippets.

These snippets will prove helpful when learning how to use C# code in DataMiner automation scripts, and will also provide a way to quickly add frequently used code.

### Syntax check

To verify the syntax of the C# code you entered in the code editor:

- Below the editor field, click *Validate*.

  If errors are found, these are enumerated in a field next to the *Validate* field. Click this field to quickly navigate to the errors in the code block.

### IntelliSense

The code editor features IntelliSense. When you type “engine.”, for example, you will get a list of all functions available for this object. You can then just scroll through the list and select the appropriate function by pressing TAB.

Once you have selected a function, type an opening round bracket. You will see all information on what to pass to that function and how.

IntelliSense is available for the following variables:

| Entity       | Example(s)                                                                       |
|--------------|----------------------------------------------------------------------------------|
| engine       | engine.                                                                          |
| dummy        | dummy.                                                                           |
| dummyXXX     | dummy1.                                                                          |
| element      | element.                                                                         |
| elementXXX   | element1.<br> Note: For elements. or elementsXXX., no IntelliSense is available. |
| el           | el.                                                                              |
| elXXX        | el1.<br> Note: For ele. or eleXXX., no IntelliSense is available.                |
| EmailOptions | EmailOptions.                                                                    |
| group        | group.                                                                           |
| groupXXX     | group1.                                                                          |
| mem          | mem.                                                                             |
| memXXX       | mem1.                                                                            |
| param        | param.                                                                           |
| paramXXX     | param1.                                                                          |
| subscript    | subscript.                                                                       |
| subscriptXXX | subscript1.                                                                      |
| report       | report.                                                                          |
| reportXXX    | report1.                                                                         |
| filter       | filter.                                                                          |
| filterXXX    | filter1.                                                                         |
| preset       | preset.                                                                          |
| presetXXX    | preset1.                                                                         |
| service      | service.                                                                         |
| serviceXXX   | service1.                                                                        |
| uib          | uib.                                                                             |
| uibXXX       | uib1.                                                                            |
| uir          | uir.                                                                             |
| uirXXX       | uir1.                                                                            |
