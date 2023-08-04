---
uid: Pipeline_stages_for_custom_solutions
---

# Pipeline stages for custom solutions

Currently, the pipeline for custom solution development consists of the following stages:

- [Loading Jenkinsfile](#loading-jenkinsfile)

- [Declarative checkout from SCM](#declarative-checkout-from-scm)

- [Detect solution](#detect-solution)

- [Validate possible dependency NuGets](#validate-possible-dependency-nugets)

- [Validate tag](#validate-tag)

- [Sync DataMiner feature release DLLs](#sync-dataminer-feature-release-dlls)

- [Build](#build)

- [Scan test projects](#scan-test-projects)

- [Run unit tests](#run-unit-tests)

- [Run integration tests](#run-integration-tests)

- [SonarQube analysis](#sonarqube-analysis)

- [Quality gate](#quality-gate)

- [Archive Release Build](#archive-release-build)

- [(Release) Prepare for SVN](#release-prepare-for-svn)

- [(Release) Push to SVN](#release-push-to-svn)

- [Declarative post actions](#declarative-post-actions)

- [NuGet - Read Config](#nuget---read-config)

- [NuGet - Create](#nuget---create)

- [NuGet - Create](#nuget---create)

- [NuGet - Sign](#nuget---sign)

- [NuGet - Publish](#nuget---publish)

## Loading Jenkinsfile

When a new Git repository is created using the SLC SE Repository Manager tool, the repository initially contains a .gitignore file and a Jenkinsfile. This Jenkinsfile in turn refers to another "master" Jenkins file. During this stage, the Jenkinsfile gets loaded.

## Declarative checkout from SCM

During this stage, Jenkins loads the current repository from Git.

## Detect solution

During this stage, the repository is scanned for the presence of a Visual Studio solution (.sln) file.

The pipeline will only continue if at least one solution file has been detected in the repository. Only the first detected solution will be processed.

## Validate possible dependency NuGets

For solutions that consist of legacy-style projects, this stage checks whether projects use the obsolete packages.config package management format.

For solutions that consist of SDK-style projects, this stage is not executed as packageReference is the only supported package management format for this type of project.

## Validate tag

This stage is only executed for pipeline runs for a tag. It will verify whether the specified tag meets the following conditions:

- The tag matches the version that is mentioned in the protocol XML file.
- The tag has the correct format.
- The tag is in the expected branch. For example, a tag "1.0.0.1" provided on a commit that is part of the "1.0.0.x" branch will succeed, while a tag "1.0.0.1" provided on a commit belonging to branch 1.0.1.x will fail.
- All expected previous minor versions of the tag are present. For example, if a commit has been tagged with "1.0.0.4", the tags "1.0.0.1", "1.0.0.2" and "1.0.0.3" are expected to be present already.
- The tag is an annotated tag and not a lightweight tag.

## Sync DataMiner feature release DLLs

This stage ensures that the next build stage will build against the latest feature release of DataMiner. It will verify on DCP whether a new feature release has been released and, if so, Jenkins will make sure to use that feature release to build against from that point onwards.

## Build

During this stage, the solution is built.

## Scan test projects

This stage scans the solution for the presence of any test projects. This stage is only executed for solutions that consist of legacy-style projects. Projects with a name that ends in "Integration Tests" or "IntegrationTests" (case insensitive) will be considered integration test projects. All other projects that end in "Tests" will be considered unit test projects.

For solutions that consist of SDK-style projects, this stage is not executed. The dotnet test command automatically detects test projects. Therefore, SDK-style test projects do not have the requirement that their name should end in "Tests". In SDK-style projects, to indicate that a tests is an integration test, use the [TestCategoryAttribute](https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.testcategoryattribute) and specify as value "IntegrationTest".

## Run unit tests

This stage executes the unit test projects. For solutions that consist of legacy-style projects, if no unit test projects were detected, this stage is skipped.

> [!NOTE]
> In case the tests fail, the unit tests will be executed against DataMiner 10.0.3 CU1 (if the protocol supports this version). The purpose of this is to support unit tests that were created using the SLProtocol API up to version 10.0.3 CU1. RN 27995 introduced changes to the API that could make a unit test fail if it depends on the prior implementation of the API. If unit tests using the DataMiner DLLs of 10.0.3 CU1 are re-executed, tests that are failing because of the changed API will succeed in the second execution.

## Run integration tests

This stage executes the integration test projects. For solutions that consist of legacy-style projects, if no integration test projects were detected, this stage is skipped.

## SonarQube analysis

This stage performs SonarQube C# code analysis on the code of the solution.

> [!TIP]
> It is possible to exclude some items from analysis (e.g. auto-generated code). For more information on how to exclude items from analysis, refer to <xref:SonarQube>.

## Quality gate

This stage verifies the results of different previous pipeline stages and checks whether the results are according to some preconfigured quality level.

## Archive Release Build

This stage archives the release build.

## (Release) Prepare for SVN

In case a tag was detected, and the version should therefore be pushed to SVN, some preparatory steps are performed.

## (Release) Push to SVN

This stage performs the actual push to SVN. Once this stage is executed, you should find a new version of the protocol on SVN in the corresponding folder, together with the required DLLs, which were originally provided in the DLLs folder in the Visual Studio project.

## NuGet - Read Config

This stage reads the JenkinsNuGetConfiguration.xml file. This file instructs the pipeline whether NuGet packages should be created for the projects in the solution and whether these should be signed and published.

For more information on the content of the JenkinsNuGetConfiguration file, refer to [NuGetStages config](xref:SchemaNuGetStagesConfig).

## NuGet - Create

This stage creates the NuGet package if the repository contains a JenkinsNuGetConfiguration.xml file that indicates a NuGet package should be created.

For more information related to configuring the projects in a solution to create a NuGet packages, refer to [Producing NuGet packages](xref:Producing_NuGet).

## NuGet - Sign

This stage signs the NuGet package if the repository contains a JenkinsNuGetConfiguration.xml file that indicates the NuGet package should be signed.

## NuGet - Publish

If the repository contains a JenkinsNuGetConfiguration.xml file that indicates the NuGet package(s) should be published, this stage publishes the created NuGet package(s) to the configured NuGet store.

## Declarative post actions

This stage performs a cleanup of the workspace and sends an email containing a report with an overview of the number of issues detected by SonarQube.
