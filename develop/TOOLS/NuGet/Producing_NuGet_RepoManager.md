---
uid: Producing_NuGet_RepoManager
---

# Producing NuGet packages with SLC SE Repository Manager

> [!IMPORTANT]
> This section includes information that is only applicable to Skyline employees and/or links that are only accessible to Skyline employees.

On the [custom solutions tab](xref:Repository_types#custom-solutions) of the SLC SE RepoManager tool, you can enable the NuGet-related stages by clicking the NuGet button. This will add a *JenkinsNuGetConfiguration.xml* file that allows configuration of these stages (enable/disable creation, signing, publishing of NuGet packages). For more information on the expected content of this file, refer to the [NuGet stages XML schema](xref:SchemaNuGetStagesConfig) documentation.

The pipeline will automatically create pre-release packages, which can be used during development. Every build will have its own pre-release package.
Every release build will have a signed released package.
