---
uid: Producing_NuGet
---

# Producing NuGet Packages

Automatic creation and publishing of NuGets from Community Class Library or Custom Solutions are supported through the Skyline CI/CD Pipelines.

The stages to handle NuGets can be enabled by pushing the NuGet button located in the SLC SE RepoManager.
This will add a JenkinsNuGetConfiguration.xml file that allows configuration of these stages. (Enable/Disable creation, Signing, Publishing of NuGets).

> [!IMPORTANT]
> There is a mandatory requirement for the NuGet name to begin with: Skyline.DataMiner.

> [!IMPORTANT]
> Make sure the NuGet Name is unique!

To configure the name and version of your NuGets all standard options are available.
The easiest way is to go into Project Settings and adjust the assembly info.

For example:
>   - Title: Skyline.DataMiner.CommunityLibrary.Http
>  - Description: Skyline.DataMiner.CommunityLibrary.Http
> - Company: Skyline Communications
>    - Product: DataMiner
>   - Copyright:Copyright @2022
>  - Trademark:
> - Assembly Version: 1.0.0.1
>- File Version: 1.0.0.1

Alternatively, you can create NuSpec files and place these next to the projects.

for example:
````xml
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2011/08/nuspec.xsd">
  <metadata>
    <id>Skyline.DataMiner.Library.Common</id>
    <version>1.2.1.1</version>
    <authors>Skyline Communications</authors>
    <license type="expression">MIT</license>
    <licenseUrl>https://licenses.nuget.org/MIT</licenseUrl>
	<description>Class Library to be used in DataMiner for a DMA version larger than 10.0.3</description>
    <copyright>Copyright ©  2022</copyright>
    <dependencies />
  </metadata>
</package>
````

The pipeline will automatically create pre-release packages which can be used during development.
Every build will have its own pre-release package.
Every release we have a signed released package
