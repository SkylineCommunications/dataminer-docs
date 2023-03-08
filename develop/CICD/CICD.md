---
uid: CICD
---

# Continuous Integration Continuous Delivery (Deployment)

## About

Continuous Integration is the practice of regularly merging code changes from multiple developers into a shared repository and verifying those changes through automated builds and tests.

Continuous Delivery is the practice of automating the entire software release process, from building the code to deploying it to production, with the goal of quickly and reliably getting changes into the hands of users.

Continuous Deployment is similar to Continuous Delivery, but goes a step further by automatically deploying changes to production as soon as they pass all tests and checks.

Together, CI/CD allows teams to deliver software more quickly, with higher quality and reliability, by automating the build, test, and deployment process.

## CI/CD at GitHub

Skyline has an ongoing migration of our internal CI/CD for DataMiner artifacts to GitHub.
This is part of efforts to improve cross-organization collaboration while maintaining high quality and ease-of-life automation from the internal CI/CD.

Uses a combination of:

- [GitHub](https://github.com/) as source control
- GitHub workflows (reusable, starter) that run on commits to GitHub repositories to trigger e.g. quality control
- GitHub Actions for specific popular actions such as deployment of artifacts
- Dotnet tooling within workflows to provide reusable and well-tested scripting
- DIS extension within Visual Studio
- Visual Studio templates

For more information refer to:

- [CI/CD starter workflows](xref:github_starter_workflows)
- [CI/CD reusable workflows](xref:github_reusable_workflows)
- [Deploy action](xref:Deploying_Automation_scripts_from_a_GitHub_repository)
- [Skyline specific: migration efforts](xref:migration_from_gerrit_to_github)
- [Skyline specific: GitHub naming conventions](xref:Using_GitHub_for_CICD)

## At Skyline Communications

There are currently several major flows concerning CI/CD within Skyline Communications.
The topics within the CI/CD documentation will provide information on several of them.

Here are a few of our flows currently in production:

- Internal CI/CD for the core software: DataMiner
- Internal CI/CD for the creation of CI/CD related dotnet tools
- Internal CI/CD for the creation of DataMiner artifacts (e.g. Automation scripts, connectors, dashboards, etc.)
 
## Internal CI/CD for the creation of DataMiner artifacts

Uses a combination of:

- [Gerrit](https://www.gerritcodereview.com/) for source control. (git-like repository)
- [Jenkins](https://www.jenkins.io/) pipelines that run on commits to Gerrit repositories to trigger quality control and automated steps
- Automatic release cycles, registration and uploading to the catalog
- Unit Tests for every artifact as required
- Public re-usable [NuGet](https://www.nuget.org/) libraries with their own pipelines and Unit Tests
- Install package creation from all other artifacts, with its own CI/CD pipeline.
- DIS extension within Visual Studio
- Visual Studio templates

For more information refer to:

- [Development with CI/CD](xref:DevelopmentWithCICD)

## Internal CI/CD for the Core software: DataMiner

Uses a combination of:

- Gerrit for source control. (git-like repository)
- Jenkins pipelines that run on commits to Gerrit repositories to trigger quality control and automated steps
- Jenkins pipelines that run daily on the latest Release Candidate (RC) and looks for introduction of compile-time errors on connector QActions
- Gerrit Code Review blocking commits when pipelines fail
- A massive array of DataMiner setups running daily and weekly regression tests
- A reporting UI called QA Portal to consolidate all testing results

## Internal CI/CD for the creation of CI/CD related dotnet tools

To run pipelines, you often need additional scripts and code to get the desired results. In the interest of quality, it was decided early on to make sure that code ran through the same pipelines it is part of.

Uses a combination of:

- Gerrit for source control (git-like repository)
- Jenkins pipelines that run on commits done to Gerrit repositories to trigger quality control and automated steps
- Automatic signing and publishing of dotnet tools
- Large battery of Unit Tests
- Public reusable NuGet libraries with their own pipelines and Unit Tests
- GitHub as source control
- GitHub workflows (reusable, starter) that run on commits to GitHub repositories to trigger quality control and automated steps
- GitHub Actions for specific popular actions such as Deployment of artifacts
- Dotnet tooling within workflows to provide reusable and well-tested scripting
- DIS extension within Visual Studio
- Visual Studio templates
