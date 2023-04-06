---
uid: Protocols_as_a_Visual_Studio_solution
---

# Protocols as a Visual Studio solution

From DIS 2.26 onwards, developing protocols as a Visual Studio solution is supported. You can either create a blank Visual Studio protocol solution for a brand-new protocol development or convert an existing protocol XML file to a solution in case you need to create a new version of an existing protocol.

- [Creating a new solution](#creating-a-new-solution)

- [Converting an existing protocol to a solution](#converting-an-existing-protocol-to-a-solution)

- [Structure of a protocol Visual Studio solution](#structure-of-a-protocol-visual-studio-solution)

- [Creating an additional QAction](#creating-an-additional-qaction)

- [Providing references to other QActions and DLLs](#providing-references-to-other-qactions-and-dlls)

- [Including test projects](#including-test-projects)

## Creating a new solution

To create a new solution, in Visual Studio, go to *File* > *New* > *DataMiner Protocol Solution* and provide a name and target location.

This will close the current solution, asking to save unsaved changes, and create a new protocol solution with the specified name in the specified target directory. The newly created solution contains a basic protocol with a precompile QAction and a regular QAction.

## Converting an existing protocol to a solution

To convert an existing protocol XML file to a Visual Studio solution, open the protocol XML file in Visual Studio and go to *DIS* > *Protocol* > *Convert to Solution* This will open a new window where you can specify the target location and initiate the conversion by clicking the *Convert* button.

This will close the current solution, asking to save unsaved changes, and create a new protocol solution. C# projects are generated for each QAction in the original protocol. DLL imports are converted to references to the C# projects (for dllImport items that refer to other QActions) or DLL files on disk (for other dllImport items).

## Structure of a protocol Visual Studio solution

A DataMiner protocol Visual Studio solution consists of the following folders:

- *Dlls*: Contains the custom DLLs that are used by this protocol (i.e. DLLs that are not part of DataMiner but are required by this protocol). When the protocol gets published on SVN by the CI/CD pipeline, the DLLs provided in this folder will automatically also be published on SVN. This ensures that the required DLLS will be available on SVN next to the protocol XML file.

- *Internal*: This folder contains the C# class library Visual Studio projects for the QAction helper (QAction_Helper) and the class library code (QAction_ClassLibrary). The latter is no longer available as of v2.41. This folder is hidden by default, as this code is generated automatically and therefore should not be touched.

- *QActions*: This folder contains a C# class library Visual Studio project per QAction defined in the protocol XML file. The name of each project is QAction\_\<id>, where \<id> is the ID of the QAction as defined in the protocol XML file (e.g. QAction_2).

- *Solution items*: This folder contains the protocol XML. The main difference between a solution protocol XML file and a regular protocol XML file is that the former does not contain the QAction C# code (as this is now in the QAction projects in the Visual Studio solution).

> [!NOTE]
> As from DIS v2.41, an information bar will allow you to convert existing solutions that make use of the Class Library generation feature.
> This information bar will appear when a Class Library project (i.e. a project named "QAction_ClassLibrary" or "AutomationScript_ClassLibrary") is detected in a protocol or Automation script solution. As soon as you click *Fix*, the Class Library project will be removed and the references to the project will be replaced by references to the automatically generated Class Library project (with ID 63000).

## Creating an additional QAction

To create an additional QAction in the solution, provide a new QAction element in the protocol XML file and then click the *Edit QAction* icon next to the QAction element. This will then automatically create a new C# class library Visual Studio project for the QAction.

By default, a QAction project contains a single source file: "QAction\_\<id>.cs". However, it is possible to introduce additional source files. This allows you to better organize your code. When the protocol solution is converted back to an XML file, all source files of a QAction project will be combined. Note, however, that in these additional source files, all using statements should be put inside a namespace declaration:

```cs
namespace MyNamespace
{
   using System; // Provide using directives inside namespace declaration.

   public class MyClass
  {
  }
}
```

## Providing references to other QActions and DLLs

It is important to note that you should not use the *dllImport* attribute when developing protocols as a Visual Studio solution.

To introduce a reference to another QAction, select the QAction project, right-click and select *Add* > *Reference*. In the *Reference Manager* window, select *Projects* and then select the check box for the QAction project(s) you want to reference.

For custom DLLs, make sure the DLL is present in the *Dlls* folder of the solution. This will ensure that the required custom DLLs for this protocol are eventually also published on SVN, next to the protocol XML. Now you can either provide a reference to this DLL in the *Dlls* folder or reference it from the DataMiner *ProtocolScripts* folder after also copying the DLL to this folder.

To introduce a reference to this custom DLL, select the QAction project, right-click and select *Add* > *Reference*. In the *Reference Manager* window, select *Browse* and then browse to this DLL and select the corresponding check box.

## Including test projects

An additional benefit of having a solution-based development approach is that test projects can be included in the solution, allowing Test Driven Development (TDD).

The CI/CD pipeline will detect projects in the solution that end with the following strings in their name as test projects (case insensitive):

- "Integration Tests" or "IntegrationTests": The CI/CD pipeline will consider these to be integration test projects.

- "Tests": The CI/CD pipeline will consider these to be unit test projects.

> [!NOTE]
> Test projects should only be integrated in protocol solutions with the purpose of testing protocol functionality (so not for system tests including certain Automation scripts, etc.).
>
