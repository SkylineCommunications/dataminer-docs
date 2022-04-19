---
uid: Pipeline_stages_for_Automation_scripts
---

# Pipeline stages for Automation scripts

Currently, the pipeline consists of the following steps:

- [Loading Jenkinsfile](#loading-jenkinsfile)

- [Declarative checkout from SCM](#declarative-checkout-from-scm)

- [Detect solution](#detect-solution)

- [Validate solution](#validate-solution)

- [Validate tag](#validate-tag)

- [Prepare solution](#prepare-solution)

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

- [Declarative post actions](#declarative-post-actions)

## Loading Jenkinsfile

When a new Git repository is created using the SLC SE Repository Manager tool, the repository initially contains a .gitignore file and a Jenkinsfile. This Jenkinsfile in turn refers to another "master" Jenkins file. In this step, the Jenkinsfile gets loaded.

## Declarative checkout from SCM

In this step, Jenkins loads the current repository from Git.

## Detect solution

In this step, the repository is scanned for the presence of a Visual Studio solution (.sln) file.

The pipeline will only continue if exactly one solution file has been detected in the repository.

## Validate solution

This step verifies whether the projects in the solution that correspond with C# exe blocks of Automation scripts make use of NuGet packages. If they do, the pipeline will fail, as using NuGet packages in these projects is currently not supported.

## Validate tag

This step is only executed for pipeline runs for a tag. It will verify whether the specified tag meets the following conditions:

- The tag has the correct format.
- The tag is in the expected branch. For example, a tag "1.0.0.1" provided on a commit that is part of the "1.0.0.x" branch will succeed, while a tag "1.0.0.1" provided on a commit belonging to branch 1.0.1.x will fail.
- All expected previous minor versions of the tag are present. For example, if a commit has been tagged with "1.0.0.4", the tags "1.0.0.1", "1.0.0.2" and "1.0.0.3" are expected to be present already.
- The tag is an annotated tag and not a lightweight tag.

## Prepare solution

In this step, the solution is configured to build against a recent version of the .NET Framework. The purpose of this is to allow compiling against the latest feature release of DataMiner, which could require a new .NET Framework version compared to the one specified in the protocol solution. Note that this is just a local change; it does not change anything to the solution in the Git repository hosted by Gerrit.

## Sync DataMiner feature release DLLs

This step ensures that the next build step will build against the latest feature release of DataMiner. It will verify on DCP whether a new feature release has been released and, if it has, Jenkins will make sure to use that feature release to build against from that point onwards.

## Sync DIS version

This step ensures that the pipeline uses the latest version of DIS. It verifies whether a new version has been released, and if that is the case, the new version is obtained.

## Build on latest feature release

During this step, the solution is built against the latest DataMiner feature release.

## Convert solution to XML

This step converts the protocol Visual Studio solution back to a protocol XML file.

## Build .dmapp package

This step creates a .dmapp package containing the Automation scripts.

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
> The Quality Gate will currently only verify SonarQube analysis results for initial developments (i.e. Automation scripts tagged as version 1.0.0.1).

## (Development) Catalog registration

This stage will perform registration in the catalog.

## (Release) Prepare for SVN

In case a tag was detected, and the version should therefore be pushed to SVN, some preparatory steps are performed.

## (Release) Catalog registration

This stage will perform registration in the catalog.

## (Release) Push to SVN

This step performs the actual push to SVN. Once this step is executed, you should find a new version of the Automation script(s) on SVN in the corresponding folder, together with the required DLLs, which were originally provided in the DLLs folder in the Visual Studio project.

> [!NOTE]
> Whereas old Automation scripts were stored on SVN under the following folder <https://svn.skyline.be/!/#SystemEngineering/view/head/Automation%20Scripts>, the CI/CD pipeline pushes Automation scripts to the following folder <https://svn.skyline.be/!/#SystemEngineering/view/head/Automation>.

## Declarative post actions

This step performs cleanup of the workspace and sends an email containing a report giving an overview of the number of issues detected in SonarQube.

The report also contains an overall quality score, which is calculated using the following metrics:

- Number of Blocker Issues reported by SonarQube

- Number of Critical Issues reported by SonarQube

- Number of Major Issue reported by SonarQube

![Overall quality score calculation](~/develop/images/PipelineEquation2.png)
