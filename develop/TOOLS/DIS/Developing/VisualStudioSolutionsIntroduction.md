---
uid: DisVisualStudioSolutionsIntroduction
---

# Visual Studio solutions

When creating a new connector or Automation script using DIS, a new Visual Studio solution will be created. DIS Supports adding additional projects to the solution such as adding a project for a QAction to a connector solution or adding a project for an C# exe block to an Automation script solution.

> [!NOTE]
> Note that DIS also supports developing connectors and Automation scripts XML files but we strongly encourage to use the solution-based approach as it has numerous benefits:
>
> - Make use of NuGet packages
> - Add unit test projects to your solution
> - Set up a CI/CD pipeline that builds your solution, performs SonarCloud analysis, etc.
>
> DIS supports converting an XML file of a connector or Automation script into a Visual Studio solution.

## SDK-style vs. legacy-style project format

As from version 2.42, DIS supports SDK-style projects in addition to the legacy-style projects.
New solutions will use the SDK-style project format by default.

When adding new projects to existing solutions, DIS will verify the project format of the other projects in the solution and use the same format for the newly added project.

## DataMiner assembly references

Up to version 2.38, in QAction projects of a connector solution and C# Eex projects of Automation script solutions, DIS would add references to the DataMiner assemblies of the locally installed DataMiner Agent or, if no DataMiner Agent was installed on the local machine, to copies of those files shipped with the DIS installation package.

From version 2.39, DIS will instead add a reference to a [DataMiner Development Package](xref:TOODataMinerDevPackages), i.e. a NuGet package that contains the core DataMiner assemblies of a specific DataMiner version. This allows developing without the need to have a local DataMiner installed or to compile the solution outside of DIS, e.g. from a CI/CD pipeline on GitHub.

As a separate DataMiner Development Package is available for every released DataMiner version, adapting a solution to a specific DataMiner version is now merely a question of making sure the solution links to the DevPack of that version.

> [!NOTE]
>
> - When you open a connector or Automation script solution in which the QAction and C# Exe block projects still contain references to DataMiner assemblies outside the DevPAcks, a banner will appear, giving you the opportunity to replace those references by references to the required DevPacks.
> - To be able to work with the DataMiner DevPacks, you will have to change the default package management format in Microsoft Visual Studio. For more information, see [Configuring Microsoft Visual Studio](xref:Configuring_Microsoft_Visual_Studio) (This is only applicable for legacy-style projects.)

## Language version of C# projects

#### [As from DIS v2.38](#tab/tabid-1)

By default, DIS will set the language version of the C# projects to 7.3.

#### [Up to DIS v2.37](#tab/tabid-2)

DIS will set the language version of the C# projects of 4.0, 6.0 or 7.3 depending on the DMA version specified in the *Protocol.Compliancies.MinimumRequired* tag of the protocol XML file:

- If the DMA version is lower than 9.6.11 (or if no *Protocol.Compliancies.MinimumRequired* tag could be found), the language version of the C# projects will be set to 4.0.
- If the DMA version is equal to or higher than 9.6.11, the language version of the C# projects will be set to one of the following versions:

  - C# 6.0 (when using Visual Studio 2015)
  - C# 7.3 (when using Visual Studio 2017 or above)

***