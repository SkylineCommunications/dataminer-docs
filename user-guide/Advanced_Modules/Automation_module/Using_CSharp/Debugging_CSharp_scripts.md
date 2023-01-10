---
uid: Debugging_CSharp_scripts
---

# Debugging CSharp scripts

To execute scripts in debug mode:

- Expand the *Advanced* section below the C# code block, and select the option *Compile in DEBUG mode*.

When you do so, the following things will happen when a script is executed:

- A .pdb file will be created for the C# script.

- Temporary compilation files will be copied in the following directory:

    *C:\\Skyline DataMiner\\Scripts\\Compiled*

If Microsoft Visual Studio (or another debugger) is installed on the DataMiner Agent, it is possible to attach to the SLAutomation process (debugging “Managed” code), and place breakpoints in the script’s source file. Note that you may need to run the script again.

> [!NOTE]
> In Microsoft Visual Studio, it may be necessary to disable the *JustMyCode* option.
