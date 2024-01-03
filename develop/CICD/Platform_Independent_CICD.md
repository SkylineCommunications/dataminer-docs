---
uid: Platform_independent_CICD
---

# Platform-independent CI/CD

As several technology stacks are used all over the world to handle source control and CI/CD (Github, Gitlab, Git, Azure, etc.), it is vital to provide tooling and libraries that can run on any of these.

At Skyline Communication we tackle this in two ways:

- [.NET Tools](https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools)

- Public re-usable [NuGet](https://www.nuget.org/) libraries

## .NET Tools

These tools are the workhorse behind a lot of the CI/CD. They can be run on Linux or Windows systems from command line and can be triggered from any CI/CD technology stack (GitHub Actions, GitLab pipelines, Azure pipelines, etc.).

The only requirement is an internet connection.

For example:

```bat
dotnet tool install -g Skyline.DataMiner.CICD.Tools.SDKChecker
SDKChecker "PathToSolutionWorkspace"
```

In the example above, *PathToSolutionWorkspace* should be a path to a Visual Studio Solution directory. This tool detects if a project is legacy-style or SDK-style. Feel free to try this out on your local computer as a test.

The following tools are the most useful:

- [Skyline.DataMiner.CICD.Tools.Packager](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.Packager#readme-body-tab)

  This .NET tool allows you to create application (.dmapp) and protocol (.dmprotocol) [packages](xref:ApplicationPackages) starting from a Visual Studio solution as created by [DIS](xref:DIS). It can be used to package Visio drawings, dashboards, connectors, Automation scripts, etc.

- [Skyline.DataMiner.CICD.Tools.CatalogUpload](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.CatalogUpload#readme-body-tab)

  This .NET tool allows you to upload application (.dmapp) [packages](xref:ApplicationPackages) directly onto Skyline's Azure cloud storage. This can be done without registration, so that you just use the returned GUID for further actions, or with registration, which will make it visible on your private catalog UI.

  > [!NOTE]
  >
  > - Currently, the private catalog UI is not visible yet.
  > - Currently, uploading protocol packages (.dmprotocol) is not supported yet.

- [Skyline.DataMiner.CICD.Tools.DataMinerDeploy](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.DataMinerDeploy#readme-body-tab)

  This .NET tool allows you to deploy application (.dmapp) [packages](xref:ApplicationPackages) to a DataMiner Agent using the artifact ID returned when performing a catalog upload.

  > [!NOTE]
  > This currently only supports deployment from dataminer.services to DMAs connected to dataminer.services.

- [Skyline.DataMiner.CICD.Tools.SDKChecker](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.SDKChecker#readme-body-tab)

  Most tools and code these days only work either on legacy-style or SDK-style Visual Studio projects. This dotnet tool will check if every project in a Visual Studio solution is SDK-style or legacy-style. Calling it while providing the path to the workspace will return a "#"-separated list with all project names that are still using legacy-style.

- [Skyline.DataMiner.CICD.Tools.NuGetPackageConfigDetector](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.NuGetPackageConfigDetector#readme-body-tab)

  In legacy-style projects, you can use either the [packages.config](https://learn.microsoft.com/en-us/nuget/reference/packages-config) or the [packageReference](https://learn.microsoft.com/en-us/nuget/consume-packages/package-references-in-project-files) package management format (SDK-style projects only support the packageReference package management format). This dotnet tool checks if legacy style uses the packages.config package management format. Calling it while providing the path to the workspace will return a "#"-separated list with all project names still using the packages.config package management format in legacy-style projects.

- [Skyline.DataMiner.CICD.Tools.NuGetToggleOnBuild](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.NuGetToggleOnBuild#readme-body-tab)

  When creating libraries that end up as NuGet packages, you will often let MSBuild automatically create the NuGet packages. However, during a pipeline run you often need to run MSBuild more than once. This tool allows you to disable or enable creation of the NuGet packages during MSBuild. This helps in avoiding a pipeline to create the NuGet packages more than once.

- [Skyline.DataMiner.CICD.Tools.NuGetPreBuildApplyBranchOrTag](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.NuGetPreBuildApplyBranchOrTag/1.0.1-1.0.0.X.20#readme-body-tab)

  When creating libraries that end up as NuGet packages, this tool changes the version of the to be created NuGet packages and assemblies in your solution to the specific version (this is often the tag you provide in Git). It also allows you to provide the name of a branch with a build number that will then create a pre-release version from that data.

- [Skyline.DataMiner.CICD.Tools.NuGetChangeVersion](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.NuGetChangeVersion#readme-body-tab)

  This allows you to change the version of a NuGet package used in your SDK-style project to a specific version (or the highest one).

For the complete list, use NuGet and search for [Skyline CICD.Tools](https://www.nuget.org/packages?q=Skyline+CICD.Tools&prerel=true&sortby=relevance).

## NuGet libraries

We also provide code libraries that can be used for development of custom programs. These contain functionality that we use when creating programs like the .NET tools or DIS. Providing these allows flexibility for other developers if they need to create their own extensions, programs, or tools specifically for your pipelines.

The following libraries are the most useful:

- [Skyline.DataMiner.CICD.FileSystem](https://www.nuget.org/packages/Skyline.DataMiner.CICD.FileSystem#readme-body-tab)

  We recommend using this instead of System.IO for all tool/stage development in C#. This supports *long paths* in Windows and also allows you to manipulate Windows-style paths while on a Linux system and the other way around. It also handles some authentication issues you may encounter with System.IO when running on GitHub.

- Skyline.DataMiner.CICD.Parsers

  - [Skyline.DataMiner.CICD.Parsers.Automation](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Parsers.Automation#readme-body-tab)

  - [Skyline.DataMiner.CICD.Parsers.Common](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Parsers.Common#readme-body-tab)

  - [Skyline.DataMiner.CICD.Parsers.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Parsers.Protocol#readme-body-tab)

  These libraries are meant to assist with parsing XML files or Visual Studio solutions of connectors (protocols) or Automation scripts. They provide logic that allows traversal and lookups within the XML itself.

- Skyline.DataMiner.CICD.Assemblers

  - [Skyline.DataMiner.CICD.Assemblers.Automation](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Assemblers.Automation#readme-body-tab)

  - [Skyline.DataMiner.CICD.Assemblers.Common](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Assemblers.Common#readme-body-tab)

  - [Skyline.DataMiner.CICD.Assemblers.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Assemblers.Protocol#readme-body-tab)

  These libraries are meant to assist with converting a DIS Visual Studio solution of a connector or Automation script into its XML files and required assemblies.

- Skyline.DataMiner.CICD.DMApp/DMProtocol

  - [Skyline.DataMiner.CICD.DMApp.Automation](https://www.nuget.org/packages/Skyline.DataMiner.CICD.DMApp.Automation)

  - [Skyline.DataMiner.CICD.DMApp.Common](https://www.nuget.org/packages/Skyline.DataMiner.CICD.DMApp.Common)

  - [Skyline.DataMiner.CICD.DMApp.Dashboard](https://www.nuget.org/packages/Skyline.DataMiner.CICD.DMApp.Dashboard)

  - [Skyline.DataMiner.CICD.DMApp.Visio](https://www.nuget.org/packages/Skyline.DataMiner.CICD.DMApp.Visio)

  - [Skyline.DataMiner.CICD.DMProtocol](https://www.nuget.org/packages/Skyline.DataMiner.CICD.DMProtocol)

  These libraries are meant to create an application (.dmapp) or protocol (.dmprotocol) package from a DIS Visual Studio solution.

- Skyline.DataMiner.CICD.Models

  - [Skyline.DataMiner.CICD.Models.Common](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Models.Common#readme-body-tab)

  - [Skyline.DataMiner.CICD.Models.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Models.Protocol#readme-body-tab)

  Represents the protocol.xml as an object-oriented model to be used in code.

For the complete list, use NuGet and search for [Skyline CICD](https://www.nuget.org/packages?q=Skyline+CICD.&prerel=true&sortby=relevance).
