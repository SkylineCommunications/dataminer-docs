---
uid: DisVisualStudioSolutionsIntroduction
---

# Visual Studio solutions

When you create a new connector or Automation script using DIS, a new Visual Studio solution is created. DIS supports adding additional projects to the solution. For example, you can add a project for a QAction to a connector solution or a project for a C# Exe block to an automation script solution.

DIS also supports developing **connectors** as XML files, but we strongly recommend using the **solution-based approach** because of its numerous advantages:

- Making use of NuGet packages
- Adding unit test projects to your solution
- Setting up a CI/CD pipeline that builds your solution, performs SonarCloud analysis, etc.

DIS supports [converting connector XML files](xref:Developing_connectors_as_Visual_Studio_solutions) into Visual Studio solutions.

Similarly, DIS also supports developing **automation scripts** as XML files, but we strongly recommend using the **project-based approach** because of its numerous advantages:

- Making use of NuGet packages
- Adding unit test projects to your solution
- Setting up a CI/CD pipeline that builds your solution, performs SonarCloud analysis, etc.
- Easy transition to a full-blown package with other components

DIS supports [converting Automation script XML files](xref:skyline_dataminer_sdk_dataminer_package_project#existing-automation-script-files) into Visual Studio projects.

## SDK-style vs. legacy-style project format

From DIS v2.42 onwards, SDK-style projects are supported in addition to the legacy-style projects. When creating new solutions or projects, DIS will default to the SDK-style project format.

When adding new projects to existing solutions, DIS will verify the project format of the other projects in the solution and use the same format for the newly added project.

## DataMiner assembly references

Prior to DIS v2.38, DIS includes references to the DataMiner assemblies of the locally installed DataMiner Agent in QAction projects of a connector solution and C# Exe projects of Automation script solutions. If no DataMiner Agent is installed on the local machine, DIS will use copies of those files provided in the DIS installation package.

From DIS v2.39 onwards, DIS includes a reference to a [DataMiner Development Package](xref:TOODataMinerDevPackages) (DevPack), a NuGet package that contains the core DataMiner assemblies of a specific DataMiner version, enabling development without the need for a local DataMiner installation or the requirement to compile the solution outside of DIS (e.g. from a CI/CD pipeline on GitHub).

To adapt a solution to a specific DataMiner version, you need to ensure that the solution links to the Development Package for that version as a separate DevPack is available for every released DataMiner version.

> [!NOTE]
>
> - When you open a connector or Automation script solution in which the QAction and C# Exe block projects still contain references to DataMiner assemblies outside the DevPacks, a banner will appear, giving you the option to replace those references with references to the required DevPacks.
> - To work with the DataMiner DevPacks, you need to change the default package management format in Microsoft Visual Studio. For more information, see [Configuring Microsoft Visual Studio](xref:Configuring_Microsoft_Visual_Studio) (only applicable to legacy-style projects).

## Language version of C# projects

#### [From DIS v2.38 onwards](#tab/tabid-1)

By default, DIS sets the language version of the C# projects to 7.3.

#### [Prior to DIS v2.38](#tab/tabid-2)

If no *Protocol.Compliancies.MinimumRequired* tag could be found, DIS sets the language version of the C# projects to 4.0.

Otherwise, DIS sets the language version of the C# projects to:

- 6.0 (Visual Studio 2015)
- 7.3 (Visual Studio 2017 or later)

***
