---
uid: dotPeek
---

# dotPeek

[dotPeek](https://www.jetbrains.com/decompiler/) is a freely accessible tool developed by JetBrains, 
designed to analyze and decompile .NET assemblies. 
It's an efficient and convenient tool that enables developers to explore and investigate the contents of compiled .NET code, 
even when the source code isn't accessible.
Key features include:

1. High-Quality Decompilation: DotPeek effectively converts the assemblies into equivalent C# code, providing clear understanding of how the assembly functions.
1. Built-In Viewer: It comes with a built-in viewer for .resources files, and can also decompile .exe, .dll, and .winmd files.
1. Navigation and Search: Enables seamless navigation through the decompiled code with options to search for specific symbols, files, or types.
1. Integrates with Visual Studio: Acts as a symbol server for Visual Studio, allowing you to step into decompiled assemblies while debugging.
1. Export to Project: DotPeek allows you to decompile and export assemblies into Visual Studio projects for further inspection and modification.

> [!IMPORTANT]
> Remember, both binary and source code may be protected by copyright and trademark laws.
> Ensure that the license agreement permits decompilation of the binary code. If not, obtain explicit permission from the copyright owner before proceeding with decompilation.

> [!TIP]
> For more information, see [dotPeek Introduction](https://www.jetbrains.com/help/decompiler/dotPeek_Introduction.html).

## Debug 3rd party libraries
DataMiner and DIS now support the [creation and use of NuGet libraries](xref:TOONuGet), 
a feature tailored to boost your development process.
Because these packages are typically shipped without debug symbols and source code, 
the Visual Studio debugger is unable to step into the package code.
However, dotPeek provides a seamless solution to this challenge. 
Acting as a symbol server for Visual Studio, 
dotPeek has the ability to automatically generate PDB files and corresponding source files.

### Configuration

1. Open the 3rd party libraries in dotPeek.
   > [!TIP]
   > dotPeek can load entire folders.
   > In DataMiner, NuGet packages are stored under C:\Skyline DataMiner\ProtocolScripts\DllImport
1. Click **Tools|Symbol Server** in the main menu to start the symbol server.
   > [!NOTE]
   > At the first start of dotPeek symbol server, you are asked to choose the assemblies you want to generate symbol files for.
   > Select **All except .Net Framework assemblies**.
1. In Visual Studio, click **Tools|Options...**
1. Navigate to **Debugging** and make sure **Enable Just My Code** is unchecked.
1. Navigate to **Debugging|Symbols** and click the plus icon to add a new location to the symbol file locations.
1. Specify the following address: **http://localhost:33417** to link dotPeek as symbol server.
   > [!NOTE]
   > The port number is configurable in dotPeek
1. Start your debugging session.

> [!TIP]
> For more information, see [Use dotPeek as a symbol server](https://www.jetbrains.com/help/decompiler/Using_product_as_a_Symbol_Server.html).