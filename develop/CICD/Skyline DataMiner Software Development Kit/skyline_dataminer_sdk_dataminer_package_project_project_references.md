---
uid: skyline_dataminer_sdk_dataminer_package_project_project_references
keywords: Skyline.DataMiner.Sdk, Package Project, ProjectReferences
---

# Skyline DataMiner Package Project - ProjectReferences.xml

Inside the Skyline DataMiner Package Project, under the *PackageContent* directory, you can find the *ProjectReferences.xml* file. This file is used to decide which DataMiner projects are included in the package. This is based on the *ProjectReference* tags that you can find in .csproj files.

For most scenarios, this file can be used as it is. However, in case you want to create multiple packages by adding multiple package projects, you will need to tweak the file to get the correct content for each package.

```xml
<ProjectReferences xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/projectReferences">
  <!-- Default include all -->
  <ProjectReference Include="..\*\*.csproj" />
  <!--
  <SolutionFilter Include="..\MySolutionFilter.slnf" />
  <ProjectReference Include="..\ProjectToInclude\ProjectToInclude.csproj" />
  <ProjectReference Exclude="..\ProjectToExclude\ProjectToExclude.csproj" />  
  -->
</ProjectReferences>
```

> [!IMPORTANT]
> When using Git, make sure that the paths are part of the Git repository as otherwise workflows could fail because of missing files.

These paths you reference are relative to the directory that the package project is in. Within a normal Visual Studio solution, the following structure is expected:

> - Solution
>   - Solution.sln
>   - PackageProject
>     - PackageProject.csproj
>     - PackageContent
>       - ProjectReferences.xml
>       - ...
>     - ...
>   - AutomationScriptProject1
>     - AutomationScriptProject1.csproj
>     - ...
>   - AutomationScriptProject2
>     - AutomationScriptProject2.csproj
>     - ...
>   - AdHocDataSourceProject
>     - AdHocDataSourceProject.csproj
>     - ...

If you take the default value as an example, **..\\\*\\\*.csproj**, this can be split up into three parts: **..**, **\\\*\\**, and **\*.csproj**.

Starting from the **PackageProject** directory, this is what this indicates:

1. **..**

   This indicates to go one directory up, so you are now at the **Solution** directory.

1. **\\\*\\**

   This is a directory with a wildcard, meaning any applicable directory fits here.

   Applicable directories:

   - *AutomationScriptProject*
   - *AutomationScriptProject2*
   - *AdHocDataSourceProject*

1. **\*.csproj**

   This is a file with a wildcard, and the file needs to have *.csproj* as its extension.

   Applicable files:

   - *AutomationScriptProject.csproj*
   - *AutomationScriptProject2.csproj*
   - *AdHocDataSourceProject.csproj*

## Example for customizations

Imagine the following scenario where you want to only include projects that have the *PrefixB_* prefix:

> - Solution
>   - Solution.sln
>   - PackageProject
>     - PackageProject.csproj
>     - PackageContent
>       - ProjectReferences.xml
>       - ...
>     - ...
>   - PrefixA_AutomationScriptProject1
>     - PrefixA_AutomationScriptProject1.csproj
>     - ...
>   - PrefixA_AutomationScriptProject2
>     - PrefixA_AutomationScriptProject2.csproj
>     - ...
>   - PrefixB_AdHocDataSourceProject1
>     - PrefixB_AdHocDataSourceProject1.csproj
>     - ...
>   - PrefixB_AdHocDataSourceProject2
>     - PrefixB_AdHocDataSourceProject2.csproj
>     - ...

### Option 1: Specify each project

The first option is to specify each project:

```xml
<ProjectReferences xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/projectReferences">
  <ProjectReference Include="..\PrefixB_AdHocDataSourceProject1\PrefixB_AdHocDataSourceProject1.csproj" />
  <ProjectReference Include="..\PrefixB_AdHocDataSourceProject2\PrefixB_AdHocDataSourceProject2.csproj" />
</ProjectReferences>
```

Alternatively, you can include all projects, but exclude the ones that you do not want:

```xml
<ProjectReferences xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/projectReferences">
  <!-- Default include all -->
  <ProjectReference Include="..\*\*.csproj" />

  <ProjectReference Exclude="..\PrefixA_AutomationScriptProject1\PrefixA_AutomationScriptProject1.csproj" />
  <ProjectReference Exclude="..\PrefixA_AutomationScriptProject2\PrefixA_AutomationScriptProject2.csproj" />
</ProjectReferences>
```

As you can imagine, this is quite troublesome as each time you add another project to the solution, you need to adapt the *ProjectReferences.xml* file.

### Option 2: Specify a prefix with a wildcard

This option has more flexibility if you are using a naming convention:

```xml
<ProjectReferences xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/projectReferences">
  <ProjectReference Include="..\PrefixB_*\PrefixB_*.csproj" />
</ProjectReferences>
```

The alternative approach can also be used:

```xml
<ProjectReferences xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/projectReferences">
  <!-- Default include all -->
  <ProjectReference Include="..\*\*.csproj" />

  <ProjectReference Exclude="..\PrefixA_*\PrefixA_*.csproj" />
</ProjectReferences>
```

### Option 3: Specify solution filters

The third option makes use of solution filters to group projects together:

```xml
<ProjectReferences xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/projectReferences">
  <SolutionFilter Include="..\MySolutionFilter.slnf" />
</ProjectReferences>
```

> [!TIP]
> See also: [Visual Studio 2022 solution filter (*.slnf) files](xref:skyline_dataminer_sdk_solution_filter_files)
