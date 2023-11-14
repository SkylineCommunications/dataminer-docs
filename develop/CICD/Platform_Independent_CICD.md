---
uid: Platform_independent_CICD
---

# Platform-independent CI/CD

Due to several technology stacks being used all over the world to handle source-control and CI/CD (GitHub, GitLab, Git, Azure, ...) it is vital to provide tooling and libraries that can run on any of these.

At Skyline Communication we are tackling this in two ways:

- [.NET Tools](https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools)
- Public re-usable [NuGet](https://www.nuget.org/) libraries

## .NET Tools

These tools are the work-horse behind a lot of the CI/CD. They can be run on Linux or Windows systems from command-line and can be triggered from any CI/CD technology stack (GitHub Actions, GitLab pipelines, Azure pipelines, etc.).

The only requirement is an internet connection.

For example:

```bat
dotnet tool install -g Skyline.DataMiner.CICD.Tools.SDKChecker
SDKChecker "PathToSolutionWorkspace"
```

Where *PathToSolutionWorkspace* should be a path to a Visual Studio Solution Directory. This tool detects if any project is legacy-style or SDK-style.
Feel free to try this out on your local computer as a test.

The following tools are the most useful:

- [Skyline.DataMiner.CICD.Tools.Packager](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.Packager#readme-body-tab)

This .NET tool allows you to create application (.dmapp) and protocol (.dmprotocol) [packages](xref:ApplicationPackages) starting from a Visual Studio solution as created by [DIS](xref:DIS).
Allows packaging Visio files, dashboards, connectors, Automation scripts, etc.

- [Skyline.DataMiner.CICD.Tools.SDKChecker](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.SDKChecker#readme-body-tab)

Most tools and code these days only work either on legacy-style or SDK-style Visual Studio projects. This dotnet tool will check if every project in a Visual Studio solution is SDK-style or legacy-style. Calling it while providing the path to the workspace will return a "#"-separated list with all project names that are still using legacy-style.

- [Skyline.DataMiner.CICD.Tools.NuGetPackageConfigDetector](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.NuGetPackageConfigDetector#readme-body-tab)

In legacy-style projects, you can use either the [packages.config](https://learn.microsoft.com/en-us/nuget/reference/packages-config) or the [packageReference](https://learn.microsoft.com/en-us/nuget/consume-packages/package-references-in-project-files) package management format.
(SDK-style projects only support the packageReference package management format). This dotnet tool checks if legacy-style use the packages.config package management format. Calling it while providing the path to the workspace will return a "#"-separated list with all project names still using the packages.config package management format in legacy-style projects.

- [Skyline.DataMiner.CICD.Tools.NuGetToggleOnBuild](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.NuGetToggleOnBuild#readme-body-tab)

When creating libraries that end up as NuGet packages, you will often let MSBuild automatically create the NuGet packages. However, during a pipeline run you often need to run MSBuild more than once. This tool allows you to disable or enable creation of the NuGet packages during MSBuild. This helps in avoiding a pipeline to create the NuGet packages more than once.

- [Skyline.DataMiner.CICD.Tools.NuGetPreBuildApplyBranchOrTag](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.NuGetPreBuildApplyBranchOrTag/1.0.1-1.0.0.X.20#readme-body-tab)

When creating libraries that end up as NuGet packages, this tool changes the version of the to be created NuGet packages and assemblies in your solution to the specific version (this is often the Tag you provide in Git). It also allows you to provide the name of a branch with a build number which will then create a pre-release version from that data.

- [Skyline.DataMiner.CICD.Tools.NuGetChangeVersion](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.NuGetChangeVersion#readme-body-tab)

This allows you to change the version of a NuGet package used in your SDK-style project to a specific version (or the highest one).

For the complete list, use NuGet and search for [Skyline CICD.Tools](https://www.nuget.org/packages?q=Skyline+CICD.Tools&prerel=true&sortby=relevance)

## NuGet libraries

We also provide code libraries that can be used for development of custom programs. These contain functionality that we use when creating programs like the .NET tools or DIS.
By providing these, it allows flexibility to other developers if they need to create their own extensions, programs or tools specifically for your pipelines.

The following libraries are the most useful:

- [Skyline.DataMiner.CICD.FileSystem](https://www.nuget.org/packages/Skyline.DataMiner.CICD.FileSystem#readme-body-tab)

Recommended to use this instead of System.IO for all tool/stage development in c#. This supports *long paths* in windows and also allows you to manipulate windows style paths while on a linux system and the other way around. It also handles some authentication issues you may encounter with System.IO when running in GitHub.

- Skyline.DataMiner.CICD.Parsers
    - [Skyline.DataMiner.CICD.Parsers.Automation](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Parsers.Automation#readme-body-tab)
    - [Skyline.DataMiner.CICD.Parsers.Common](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Parsers.Common#readme-body-tab)
    - [Skyline.DataMiner.CICD.Parsers.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Parsers.Protocol#readme-body-tab)

These libraries are meant to assist with parsing XML files like Connectors(Protocol) or AutomationScripts. They provide logic that allows traversal and lookups within the XML itself.

- Skyline.DataMiner.CICD.Assemblers
    - [Skyline.DataMiner.CICD.Assemblers.Automation](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Assemblers.Automation#readme-body-tab)
    - [Skyline.DataMiner.CICD.Assemblers.Common](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Assemblers.Common#readme-body-tab)
    - [Skyline.DataMiner.CICD.Assemblers.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Assemblers.Protocol#readme-body-tab)

These libraries are meant to assist with converting a DIS Visual Studio solution of a Connector or AutomationScript into its XML files and required assemblies.

- Skyline.DataMiner.CICD.DMApp/DMProtocol
    - [Skyline.DataMiner.CICD.DMApp.Automation](https://www.nuget.org/packages/Skyline.DataMiner.CICD.DMApp.Automation)
    - [Skyline.DataMiner.CICD.DMApp.Common](https://www.nuget.org/packages/Skyline.DataMiner.CICD.DMApp.Common)
    - [Skyline.DataMiner.CICD.DMApp.Dashboard](https://www.nuget.org/packages/Skyline.DataMiner.CICD.DMApp.Dashboard)
    - [Skyline.DataMiner.CICD.DMApp.Visio](https://www.nuget.org/packages/Skyline.DataMiner.CICD.DMApp.Visio)
    - [Skyline.DataMiner.CICD.DMProtocol](https://www.nuget.org/packages/Skyline.DataMiner.CICD.DMProtocol)

These libraries are meant to create a dmapp or dmprotocol from a DIS Visual Studio Solution.


- Skyline.DataMiner.CICD.Models
    - [Skyline.DataMiner.CICD.Models.Common](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Models.Common#readme-body-tab)
    - [Skyline.DataMiner.CICD.Models.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Models.Protocol#readme-body-tab)

Represents the protocol.xml as an Object Oriented model to be used in code.

For the complete list, use NuGet and search for [Skyline CICD.](https://www.nuget.org/packages?q=Skyline+CICD.&prerel=true&sortby=relevance)