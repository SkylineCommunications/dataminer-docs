---
uid: Compiling_a_CSharp_code_block_as_a_library
---

# Compiling a C# code block as a library

From DataMiner 9.6.13 onwards, it is possible to have a C# code block in an Automation script in Cube compiled as a separate library.

## Compiling the library

1. In the Automation module, open the script of which you want to compile a C# code block. Make sure the block contains a namespace with the name of the library you want to create.

   The following restrictions apply for the library name:

   - A library name must not contain a period (“.”).

   - Within the same Automation script, each library name must be unique.

1. Open the *Advanced* section below the code block.

1. Select the option *Compile as library with name* and specify the library name.

1. Save the script. The library will now be compiled.

## Importing the library into an Automation script

Once you have compiled a C# code block as a library, you can then import that library into other Automation scripts. To do so:

1. In the Automation module, open the *Advanced* section below the C# code block in the script you want to import the library into.

1. In the *Script references* box, enter a reference to the library you want to import, by referring to the relevant script name and library name in the following format: *ScriptName:LibraryName*. For example: *Custom Exception Library:SrmCustomExceptions*

   > [!NOTE]
   > In the reference, ScriptName can be replaced by the placeholder *\[AutomationScriptName\]*, which will be resolved to the name of the script in which you are currently adding a reference.

1. In the C# code block, make sure to add a using statement mentioning the library. For example:

   ```txt
   using SrmCustomExceptions;
   ```

## Using the library in a DataMiner Automation Script Solution

1. In Visual Studio, create a solution with the library script, and add all other Automation scripts in which you want to use the library to this solution.

1. In the XML of the library script, make sure the *preCompile* and *libraryName* parameters are filled in. For example:

   ```xml
   <Script>
     <Exe id="1" type="csharp">
       <Value><!CDATA[[Project:Custom Exception Library_1]]</Value>
       <Param type="debug">true</Param>
       <Param type="preCompile">true</Param>
       <Param type="libraryName">SrmCustomExceptions</Param>
       <Message></Message>
     </Exe>
   </Script>
   ```

1. Import the library into the other scripts to prevent compilation errors:

   1. Right-click the references of the solution and select *Add Reference*.

      ![Add Reference option](~/user-guide/images/AutomationAddReference.png)

   1. Select the library script under *Projects* and click *OK*.

1. Make sure that the scripts where you imported the library contain the correct script reference. This ensures that the reference will work correctly when the script is published in DataMiner. For example:

   ```xml
   <Script>
     <Exe id="1" type="csharp">
       <Value><![CDATA[[Project:GMN_CreateBooking_1]]]></Value>
       <Param type="scriptRef">GMN Custom Exception Library:SrmCustomExceptions</Param>
       <Message></Message>
     </Exe>
   </Script>
   ```

## Remarks regarding compiling C# blocks as libraries

- On the DMA, the DLL files of the libraries are placed in the folder *C:\\Skyline DataMiner\\Scripts\\Libraries*.

- To optimize performance, we recommend that you create each library in a separate script.

- When a library is compiled, any scripts and libraries using this library will be recompiled.

- When the Automation script containing a library is deleted, all files of the library will be deleted too, which will make it impossible to recompile scripts that depend on this library until a library with the same reference is added again.

- From DataMiner 10.0.0 \[CU9\]/10.1.1 onwards, if any new Automation scripts containing libraries that need to be compiled are detected during DataMiner startup, these will be compiled automatically.
