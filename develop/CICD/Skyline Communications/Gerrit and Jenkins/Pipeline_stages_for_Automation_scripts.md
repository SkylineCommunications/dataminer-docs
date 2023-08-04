---
uid: Pipeline_stages_for_Automation_scripts
---

# Pipeline stages for Automation scripts

Currently, the pipeline consists of the following stages:

- [Loading Jenkinsfile](#loading-jenkinsfile)

- [Declarative checkout from SCM](#declarative-checkout-from-scm)

- [Detect solution](#detect-solution)

- [Validate solution](#validate-solution)

- [Prepare solution](#prepare-solution)

- [Validate possible dependency NuGets](#validate-possible-dependency-nugets)

- [Sync DataMiner feature release DLLs](#sync-dataminer-feature-release-dlls)

- [Sync DIS version](#sync-dis-version)

- [Build on latest feature release](#build-on-latest-feature-release)

- [Convert solution to XML](#convert-solution-to-xml)

- [Build .dmapp package](#build-dmapp-package)

- [Scan test projects](#scan-test-projects)

- [Run unit tests](#run-unit-tests)

- [Run integration tests](#run-integration-tests)

- [SonarQube analysis](#sonarqube-analysis)

- [Quality gate](#quality-gate)

- [(Development) Catalog registration](#development-catalog-registration)

- [(Release) Prepare for SVN](#release-prepare-for-svn)

- [(Release) Catalog registration](#release-catalog-registration)

- [(Release) Push to SVN](#release-push-to-svn)

- [(Release) Push to Azure](#release-push-to-azure)

- [Declarative post actions](#declarative-post-actions)

## Loading Jenkinsfile

When a new Git repository is created using the SLC SE Repository Manager tool, the repository initially contains a .gitignore file and a Jenkinsfile. This Jenkinsfile in turn refers to another "master" Jenkins file. During this stage, the Jenkinsfile gets loaded.

## Declarative checkout from SCM

During this stage, Jenkins loads the current repository from Git.

## Detect solution

During this stage, the repository is scanned for the presence of a Visual Studio solution (.sln) file.

The pipeline will only continue if exactly one solution file has been detected in the repository.

## Validate solution

This stage verifies whether there are C# code blocks in the Automation script(s). If not, the SonarQube stage will be skipped.

## Prepare solution

During this stage, the solution is configured to build against a recent version of the .NET Framework. The purpose of this is to allow compiling against the latest feature release of DataMiner, which could require a new .NET Framework version compared to the one specified in the protocol solution. Note that this is just a local change; it does not change anything to the solution in the Git repository hosted by Gerrit.

## Validate possible dependency NuGets

For solutions that consist of legacy-style projects, this stage checks whether projects use the obsolete packages.config package management format.

For solutions that consist of SDK-style projects, this stage is not executed as packageReference is the only supported package management format for this type of project.

## Sync DataMiner feature release DLLs

This stage ensures that the next build stage will build against the latest feature release of DataMiner. It will verify on DCP whether a new feature release has been released and, if it has, Jenkins will make sure to use that feature release to build against from that point onwards.

## Sync DIS version

This stage ensures that the pipeline uses the latest version of DIS. It verifies whether a new version has been released, and if that is the case, the new version is obtained.

## Build on latest feature release

During this stage, the solution is built against the latest DataMiner feature release.

## Convert solution to XML

This stage converts the protocol Visual Studio solution back to a protocol XML file.

## Build .dmapp package

This stage creates a .dmapp package containing the Automation scripts.

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

This stage performs SonarQube C# code analysis on the code provided in the Exe blocks.

> [!TIP]
> It is possible to exclude some items from analysis (e.g. auto-generated code). For more information on how to exclude items from analysis, refer to <xref:SonarQube>.

## Quality gate

This stage verifies the results of different previous pipeline stages and checks whether the results are according to some preconfigured quality level.

### Unit/integration tests

The quality gate will fail as soon as one test fails.

### SonarQube

This quality gate verifies whether the Automation script does not exceed any of the limits set for the SonarQube code analysis. Currently, the following limits have been configured:

- Blocker Issues: 0

- Bugs: 20

- Critical Issues: 10

- Code Smells: 100

- Major Issues: 100

- Minor Issues: 100

- Duplicated Blocks: 200

> [!NOTE]
> The quality gate will currently only verify SonarQube analysis results for initial developments (i.e. Automation scripts tagged as version 1.0.0.1).

## (Development) Catalog registration

This stage will perform registration in the catalog.

## (Release) Prepare for SVN

In case a tag was detected, and the version should therefore be pushed to SVN, some preparatory steps are performed.

## (Release) Catalog registration

This stage will perform registration in the catalog.

## (Release) Push to SVN

This stage performs the actual push to SVN. Once this stage is executed, you should find a new version of the Automation script(s) on SVN in the corresponding folder, together with the required DLLs, which were originally provided in the DLLs folder in the Visual Studio project.

> [!NOTE]
> Whereas old Automation scripts were stored on SVN under the following folder <https://svn.skyline.be/!/#SystemEngineering/view/head/Automation%20Scripts>, the CI/CD pipeline pushes Automation scripts to the following folder <https://svn.skyline.be/!/#SystemEngineering/view/head/Automation>.

## (Release) Push to Azure

This stage pushes the created package to Azure Blob Storage.

## Declarative post actions

This stage performs cleanup of the workspace and sends an email containing a report giving an overview of the number of issues detected in SonarQube.

The report also contains an overall quality score, which is calculated using the following metrics:

- Number of Blocker Issues reported by SonarQube

- Number of Critical Issues reported by SonarQube

- Number of Major Issue reported by SonarQube

![Overall quality score calculation](~/develop/images/PipelineEquation2.png)
