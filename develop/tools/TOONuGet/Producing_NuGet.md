---
uid: Producing_NuGet
---

# Producing NuGet packages

Automatic creation and publishing of NuGets from the community class library or from [custom solutions](xref:Custom_solution_development_with_CI_CD_Pipeline) is supported through the Skyline CI/CD pipelines.

On the [custom solutions tab](xref:Repository_types#custom-solutions) of the SLC SE RepoManager tool, you can enable the NuGet related stages by clicking the NuGet button. This will add a *JenkinsNuGetConfiguration.xml* file that allows configuration of these stages (enable/disable creation, signing, publishing of NuGet packages). For more info on the expected content of this file, refer to the [NuGet stages XML schema](xref:SchemaNuGetStagesConfig) documentation.

> [!IMPORTANT]
>
> - The NuGet name must always begin with `Skyline.DataMiner.`.
> - The NuGet Name must be unique and limited to 50 characters.

To configure the name and version of your NuGet packages, all standard options are available. The easiest way to do this is to go to the project settings and adjust the assembly info.

For example:

![Assembly info in project settings](~/develop/images/Assembly_info_NuGet.png)

> [!TIP]
> In case your source files have been documented with [XML documentation comments](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/), make sure to set the [DocumentationFile](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-options/output#documentationfile) compiler option. You can set this option for a project in Visual Studio, by selecting the project in Solution Explorer, right click and choose Properties. Then, from the Build tab, check the XML Documentation File checkbox. This will generate an XML file in addition to the assembly which will be included in the NuGet package. Developers making use of your NuGet package will then be able to see this documentation in IntelliSense and the object browser.

## Automatic NuSpec file creation

The CI/CD pipeline will look for the presence of NuSpec files for the .NET Framework class library projects in the solution.
If no NuSpec file was found, the pipeline will automatically create one by extracting the required metadata from the AssemblyInfo.cs file of the project.

The pipeline expects the following to present in the AssemblyInfo.cs file:

- The name of the assembly must start with `Skyline.DataMiner.`.
- A description must be provided (with a maximum length of 4000 characters).
- A copyright must be provided.

Other package metadata will that will be configured:

- The authors will be set to "Skyline Communications".
- The license will be set to MIT license.

## Manual NuSpec file creation

Alternatively, you can create NuSpec files yourself and place these next to the projects. This can be useful where the automatically created NuSpec file does not meet your needs (e.g. in case you want to provide some tags or customize the content of the package).

The pipeline will perform the following checks on the NuSpec file:

- The ID of the package must start with `Skyline.DataMiner.`
- The version must be a valid version.
- The authors field must not be empty and shorter than 4000 characters.
- The description field must not be empty and shorter than 4000 characters.
- The NuSpec file must contain a valid license.
- The copyright field must not be empty and shorter than 4000 characters.

> [!NOTE]
> If you use the `$id$`, `$version$`, `$author$`, `$title$`, `$description$`, `$copyright$` placeholder tokens in the corresponding fields of the NuSpec file these will be replaced with the corresponding info from the AssemblyInfo file from the project.

> [!NOTE]
> For more information about the NuSpec schema, refer to [.nuspec reference](https://docs.microsoft.com/en-us/nuget/reference/nuspec).

An example of a NuSpec file:

```xml
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2011/08/nuspec.xsd">
  <metadata>
    <id>Skyline.DataMiner.Lib.Common</id>
    <version>1.2.2.2</version>
    <authors>Skyline Communications</authors>
    <license type="expression">MIT</license>
    <licenseUrl>https://licenses.nuget.org/MIT</licenseUrl>
    <description>Class Library to be used in DataMiner 10.0.3 or above.</description>
    <copyright>Copyright ©  2022</copyright>
    <dependencies />
  </metadata>
</package>
```

> [!IMPORTANT]
> Even when NuSpec files are used, the Assembly Version and Assembly File Version for the projects must be updated.

The pipeline will automatically create pre-release packages, which can be used during development. Every build will have its own pre-release package.
Every release build will have a signed released package.
