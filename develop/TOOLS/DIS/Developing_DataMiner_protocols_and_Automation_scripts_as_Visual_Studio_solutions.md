---
uid: Developing_DataMiner_protocols_and_Automation_scripts_as_Visual_Studio_solutions
---

# Developing DataMiner protocols and Automation scripts as Visual Studio solutions

This section consists of the following topics:

- [Developing DataMiner protocols as Visual Studio solutions](xref:Developing_DataMiner_protocols_as_Visual_Studio_solutions)
- [Developing Automation scripts as Visual Studio solutions](xref:Developing_Automation_scripts_as_Visual_Studio_solutions)

## Legacy-style projects vs. SDK-style projects

As from version 2.42, DIS supports SDK-style projects in addition to the legacy-style projects.

At startup, DIS will install new protocol solution and Automation script solution templates that will be used when creating a new protocol or Automation script solution in Visual Studio 2022.

When a legacy-style solution is added, an SDK-style project will also automatically be created (and vice versa).

## Using the DataMiner DevPacks

Up to version 2.38, in QAction and EXE projects, DIS would add references to the DataMiner DLL files of the locally installed DataMiner Agent or, if no DataMiner Agent was installed on the local machine, to copies of those files shipped with the DIS installation package. From version 2.39, DIS will instead add a reference to a DataMiner DevPack, i.e. a NuGet package that contains the core DataMiner DLL files of a specific DataMiner version. As a separate DataMiner DevPack is available for every released DataMiner version, adapting a solution to a specific DataMiner version is now merely a question of making sure the solution links to the DevPack of that version.

The DataMiner DevPacks can be found on the [official NuGet store](https://www.nuget.org/packages?q=skylinecommunications).

> [!NOTE]
>
> - When you open a protocol solution or an Automation script solution in which the QAction and EXE projects still contain references to separate DLL files instead of a DataMiner DevPack, a banner will appear, giving you the opportunity to replace those references by references to the required DevPacks.
> - To be able to work with the DataMiner DevPacks, you will have to change the default package management format in Microsoft Visual Studio. For more information, see [Configuring Microsoft Visual Studio](xref:Configuring_Microsoft_Visual_Studio)
