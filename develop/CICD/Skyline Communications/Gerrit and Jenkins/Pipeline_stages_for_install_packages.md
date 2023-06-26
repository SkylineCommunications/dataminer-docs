---
uid: Pipeline_stages_for_install_packages
---

# Pipeline stages for install packages

Currently, the pipeline consists of the following stages:

## Loading Jenkinsfile

When a new Git repository is created using the SLC SE Repository Manager tool, the repository initially contains a .gitignore file and a Jenkinsfile. This Jenkinsfile in turn refers to another "master" Jenkins file. During this stage, the Jenkinsfile gets loaded.

## Declarative checkout from SCM

During this stage, Jenkins loads the current repository from Git.

## Detect solution

During this stage, the repository is scanned for the presence of a Visual Studio solution (.sln) file.

## Verify tag

This stage verifies that a tag matches the regular expression `^\d+\.\d+\.\d+-CU\d+$`, e.g. `1.0.1-CU0`.

## Sync DataMiner feature release DLLs

This stage ensures that the next build stage will build against the latest feature release of DataMiner. It will verify on DCP whether a new feature release has been released and, if it has, Jenkins will make sure to use that feature release to build against from that point onwards.

## Build on latest feature release

During this stage, the solution is built against the latest DataMiner feature release.

## Convert solution to XML

This stage extracts the package scripts from the Visual Studio solution.

## Compile requested install package (Release)

This stage creates the install package for pipeline runs that correspond with a release.

## Compile requested install package (Development)

This stage creates the install package for pipeline runs that do not correspond with a release.

The resulting package will include a suffix \_B\<buildNumber>, where buildNumber is the build number of the pipeline.

## Validate subchains

In case the package references items that are in development (i.e. items with Version/Selection/Range@rangeSelection set to *latestBuild*), Jenkins will validate the state of the pipelines for these items.

If one of the sub items failed, then the pipeline will be marked as unstable.

## Scan test projects

This stage scans the solution for the presence of any test projects. Projects with a name that ends in "Integration Tests" or "IntegrationTests" (case insensitive) will be considered integration test projects. All other projects with a name that ends in "Tests" will be considered unit test projects.

## Run unit tests

This stage executes the unit test projects. If no unit test projects were detected, this stage is skipped.

## Run integration tests

This stage executes the integration test projects. If no integration test projects were detected, this stage is skipped.

## SonarQube analysis

This stage performs SonarQube C# code analysis on the code provided in the Exe blocks.

> [!TIP]
> It is possible to exclude some items from analysis (e.g. auto-generated code). For more information on how to exclude items from analysis, refer to <xref:SonarQube>.

## Quality gate

This stage verifies the results of different previous pipeline stages and checks whether the results are according to some preconfigured quality level.

## (Development) Catalog Registration

This stage will register the package in the catalog.

## (Release) Prepare for SVN

In case a tag was detected, and the version should therefore be pushed to SVN, some preparatory steps are performed.

## (Release) Catalog registration

This stage will register the package in the catalog.

## (Release) Push to SVN

This stage performs the actual push to SVN. Once this stage is executed, you should find a new version of the install package on SVN in the corresponding folder.

## (Release) Push to Azure

This stage pushes the created package to Azure Blob Storage.
