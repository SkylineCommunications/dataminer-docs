---
uid: Pipeline_stages_for_install_packages
---

# Pipeline stages for install packages

Currently, the pipeline consists of the following steps:

## Loading Jenkinsfile

When a new Git repository is created using the SLC SE Repository Manager tool, the repository initially contains a .gitignore file and a Jenkinsfile. This Jenkinsfile in turn refers to another "master" Jenkins file. In this step, the Jenkinsfile gets loaded.

## Declarative checkout from SCM

In this step, Jenkins loads the current repository from Git.

## Detect solution

In this step, the repository is scanned for the presence of a Visual Studio solution (.sln) file.

## Sync DataMiner feature release DLLs

This step ensures that the next build step will build against the latest feature release of DataMiner. It will verify on DCP whether a new feature release has been released and, if it has, Jenkins will make sure to use that feature release to build against from that point onwards.

## Build on latest feature release

During this step, the solution is built against the latest DataMiner feature release.

## Nuget to DLLs

During this step, the referenced Nuget packages in the solution are evaluated. Any

## Convert solution to XML

This step extracts the package scripts from the Visual Studio solution.

## Compile requested install package (Release)

This step creates the install package for pipeline runs that correspond with a release.

## Compile requested install package (Development)

This step creates the install package for pipeline runs that do not correspond with a release.

The resulting package will include a suffix \_B\<buildNumber>, where buildNumber is the build number of the pipeline.

## Validate subchains

In case the package references items that are in development (i.e. items with Version/Selection/Range@rangeSelection set to *latestBuild*), Jenkins will validate the state of the pipelines for these items.

If one of the sub items failed, then the pipeline will be marked as unstable.

## Scan test projects

This step scans the solution for the presence of any test projects. Projects with a name that end with "Integration Tests" or "IntegrationTests" (case insensitive) will be considered integration test projects. All other projects that end with "Tests" will be considered unit test projects.

## Run unit tests

This step executes the unit test projects. If no unit test projects were detected, this step is skipped.

## Run integration tests

This step executes the integration test projects. If no integration test projects were detected, this step is skipped.

## SonarQube analysis

This step performs SonarQube C# code analysis on the code provided in the Exe blocks.

## Quality gate

This step verifies the results of different previous pipeline steps and checks whether the results are according to some preconfigured quality level.

## (Release) Prepare for SVN

In case a tag was detected, and the version should therefore be pushed to SVN, some preparatory steps are performed.

## (Development) Catalog Registration

This stage will register the package in the catalog.

## (Release) Prepare for SVN

This stage will perform some preparatory steps for pushing the package to SVN in a subsequent stage.

## (Release) Catalog registration

This stage will register the package in the catalog.

## (Release) Push to SVN

This step performs the actual push to SVN. Once this step is executed, you should find a new version of the install package on SVN in the corresponding folder.
