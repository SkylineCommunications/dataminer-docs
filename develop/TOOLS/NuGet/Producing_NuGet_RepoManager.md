---
uid: Producing_NuGet_RepoManager
---

# Producing NuGet packages via SLC SE Repo Manager

> [!IMPORTANT]
> This section includes information that is only applicable to Skyline employees and/or links that are only accessible to Skyline employees.

Enable the NuGet-related stages:

1. As a Skyline employee, open the SLC SE Repo manager and go to the [*Custom Solutions* tab](xref:Repository_types#custom-solutions).

1. Click the *NuGet* button in the lower right corner to add another *JenkinsNuGetConfiguration.xml* file that allows you to enable and configure NuGet-related stages in the pipeline, including enabling or disabling the creation, signing, and publishing of NuGet packages.

   > [!TIP]
   > For an overview of the expected content of this file, refer to the [NuGet stages XML schema](xref:SchemaNuGetStagesConfig).

   The pipeline is designed to automatically generate pre-release packages, which can be used during development. Every build will result in its own pre-release package. Every release build will result in its own signed released package.
