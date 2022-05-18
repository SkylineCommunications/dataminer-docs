---
uid: Producing_NuGet
---

# Producing NuGet packages

Automatic creation and publishing of NuGets from the community class library or from custom solutions is supported through the Skyline CI/CD pipelines.

You can enable the stages to handle NuGets by clicking the NuGet button in the SLC SE RepoManager. This will add a *JenkinsNuGetConfiguration.xml* file that allows configuration of these stages (Enable/Disable creation, Signing, Publishing of NuGets).

> [!IMPORTANT]
>
> - The NuGet name must always begin with `SLC.`.
> - The NuGet Name must be unique.

To configure the name and version of your NuGets, all standard options are available. The easiest way to do this is to go to the project settings and adjust the assembly info.

For example:

![Assembly info in project settings](~/develop/images/Assembly_info_NuGet.png)

Alternatively, you can create NuSpec files and place these next to the projects.

For example:

```xml
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2011/08/nuspec.xsd">
  <metadata>
    <id>SLC.Lib.Common</id>
    <version>1.2.2.2</version>
    <authors>Skyline Communications</authors>
    <license type="expression">MIT</license>
    <licenseUrl>https://licenses.nuget.org/MIT</licenseUrl>
    <description>Class Library to be used in DataMiner for a DMA version larger than 10.0.3</description>
    <copyright>Copyright ©  2022</copyright>
    <dependencies />
  </metadata>
</package>
```

> [!NOTE]
> Even when NuSpec files are used, the Assembly Version and Assembly File Version for the projects should be updated.

The pipeline will automatically create pre-release packages, which can be used during development. Every build will have its own pre-release package. Every release will have a signed released package.
