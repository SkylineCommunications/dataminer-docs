---
uid: Pipeline_stages_for_custom_solutions
---

# Pipeline stages for custom solutions

Currently, the pipeline for custom solution development consists of the following steps:

- [Loading Jenkinsfile](#loading-jenkinsfile)

- [Declarative checkout from SCM](#declarative-checkout-from-scm)

- [Detect solution](#detect-solution)

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

When a new Git repository is created using the SLC SE Repository Manager tool, the repository initially contains a .gitignore file and a Jenkinsfile. This Jenkinsfile in turn refers to another "master" Jenkins file. In this step, the Jenkinsfile gets loaded.

## Declarative checkout from SCM

In this step, Jenkins loads the current repository from Git.

## Detect solution

In this step, the repository is scanned for the presence of a Visual Studio solution (.sln) file.

The pipeline will only continue if at least one solution file has been detected in the repository. Only the first detected solution will be processed.

## Validate tag

This step is only executed for pipeline runs for a tag. It will verify whether the specified tag meets the following conditions:

- The tag matches the version that is mentioned in the protocol XML file.
- The tag has the correct format.
- The tag is in the expected branch. For example, a tag "1.0.0.1" provided on a commit that is part of the "1.0.0.x" branch will succeed, while a tag "1.0.0.1" provided on a commit belonging to branch 1.0.1.x will fail.
- All expected previous minor versions of the tag are present. For example, if a commit has been tagged with "1.0.0.4", the tags "1.0.0.1", "1.0.0.2" and "1.0.0.3" are expected to be present already.
- The tag is an annotated tag and not a lightweight tag.

## Sync DataMiner feature release DLLs

This step ensures that the next build step will build against the latest feature release of DataMiner. It will verify on DCP whether a new feature release has been released and, if so, Jenkins will make sure to use that feature release to build against from that point onwards.

## Build

During this step, the solution is built.

## Scan test projects

This step scans the solution for the presence of any test projects. Projects with a name that end with "Integration Tests" or "IntegrationTests" (case insensitive) will be considered integration test projects. All other projects that end with "Tests" will be considered unit test projects.

## Run unit tests

This step executes the unit test projects. If no unit test projects were detected, this step is skipped.

## Run integration tests

This step executes the integration test projects. If no integration test projects were detected, this step is skipped.

## SonarQube analysis

This step performs SonarQube C# code analysis on the code of the solution.

## Quality gate

This step verifies the results of different previous pipeline steps and checks whether the results are according to some preconfigured quality level.

## Archive Release Build

This step archives the release build.

## (Release) Prepare for SVN

In case a tag was detected, and the version should therefore be pushed to SVN, some preparatory steps are performed.

## (Release) Push to SVN

This step performs the actual push to SVN. Once this step is executed, you should find a new version of the protocol on SVN in the corresponding folder, together with the required DLLs, which were originally provided in the DLLs folder in the Visual Studio project.

## NuGet - Read Config

This step reads the JenkinsNuGetConfiguration.xml file. This file instructs the pipeline whether NuGet packages should be created for the projects in the solution and whether these should be signed and published.

For more information on the content of the JenkinsNuGetConfiguration file, refer to [NuGetStages config](xref:SchemaNuGetStagesConfig).

## NuGet - Create

This step creates the NuGet package if the repository contains a JenkinsNuGetConfiguration.xml file that indicates a NuGet package should be created.

For more information related to configuring the projects in a solution to create a NuGet packages, refer to [Producing NuGet packages](xref:Producing_NuGet).

## NuGet - Sign

This step signs the NuGet package if the repository contains a JenkinsNuGetConfiguration.xml file that indicates the NuGet package should be signed.

## NuGet - Publish

If the repository contains a JenkinsNuGetConfiguration.xml file that indicates the NuGet package(s) should be published, this step publishes the created NuGet package(s) to the configured NuGet store.

## Declarative post actions

This step performs a cleanup of the workspace and sends an email containing a report with an overview of the number of issues detected by SonarQube.
