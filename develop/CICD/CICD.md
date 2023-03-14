---
uid: CICD
---

# Continuous integration and continuous delivery (deployment)

## About

**Continuous integration** is the practice of regularly merging code changes from multiple developers into a shared repository and verifying those changes through automated builds and tests.

**Continuous delivery** is the practice of automating the entire software release process, from building the code to deploying it to production, with the goal of quickly and reliably getting changes into the hands of users.

**Continuous deployment** is similar to continuous delivery, but goes a step further by automatically deploying changes to production as soon as they pass all tests and checks.

Together, CI/CD allows teams to deliver software more quickly, with higher quality and reliability, by automating the build, test, and deployment process.

## CI/CD on GitHub

Skyline Communications is currently in the process of migrating its internal CI/CD for DataMiner artifacts to [GitHub](https://github.com/). This is part of efforts to improve cross-organization collaboration while maintaining the high quality and ease-of-life automation from the internal CI/CD.

We use a combination of:

- GitHub as source control
- GitHub workflows (reusable or starter) that run on commits to GitHub repositories to trigger e.g. quality control
- GitHub actions for specific popular actions such as deployment of artifacts
- Dotnet tooling within workflows to provide reusable and well-tested scripting
- DIS extension within Visual Studio
- Visual Studio templates

For more information, refer to:

- [CI/CD starter workflows](xref:github_starter_workflows)
- [CI/CD reusable workflows](xref:github_reusable_workflows)
- [Deploy action](xref:Deploying_Automation_scripts_from_a_GitHub_repository)
- [Skyline-specific: migration efforts](xref:migration_from_gerrit_to_github)
- [Skyline-specific: GitHub naming conventions](xref:Using_GitHub_for_CICD)

## CI/CD at Skyline Communications

There are currently several major CI/CD flows within Skyline Communications. Our CI/CD documentation will provide information on several of them.

Here are a few of our flows currently in production:

- Internal CI/CD for the core DataMiner software
- Internal CI/CD for the creation of CI/CD-related dotnet tools
- Internal CI/CD for the creation of DataMiner artifacts (e.g. Automation scripts, connectors, dashboards, etc.)

### Internal CI/CD for the core DataMiner software

Uses a combination of:

- [Gerrit](https://www.gerritcodereview.com/) for source control (git-like repository)
- [Jenkins](https://www.jenkins.io/) pipelines that run on commits to Gerrit repositories to trigger quality control and automated steps
- Jenkins pipelines that run daily on the latest Release Candidate (RC) and look for introduction of compile-time errors on connector QActions
- Gerrit code review blocking commits when pipelines fail
- A massive array of DataMiner setups running daily and weekly regression tests
- A reporting UI, QA Portal, to consolidate all testing results

### Internal CI/CD for the creation of CI/CD related dotnet tools

To run pipelines, often additional scripts and code are needed to get the desired results. In the interest of quality, a decision was made early on to make sure that code runs through the same pipelines it is part of.

Uses a combination of:

- Gerrit for source control (git-like repository)
- Jenkins pipelines that run on commits done to Gerrit repositories to trigger quality control and automated steps
- Automatic signing and publishing of dotnet tools
- A large battery of unit tests
- Public reusable NuGet libraries with their own pipelines and unit tests
- GitHub as source control
- GitHub workflows (reusable or starter) that run on commits to GitHub repositories to trigger quality control and automated steps
- GitHub actions for specific popular actions such as deployment of artifacts
- Dotnet tooling within workflows to provide reusable and well-tested scripting
- DIS extension within Visual Studio
- Visual Studio templates

### Internal CI/CD for the creation of DataMiner artifacts

Uses a combination of:

- Gerrit for source control (git-like repository)
- Jenkins pipelines that run on commits to Gerrit repositories to trigger quality control and automated steps
- Automatic release cycles, registration, and uploading to the catalog
- Unit tests for every artifact as required
- Public re-usable [NuGet](https://www.nuget.org/) libraries with their own pipelines and unit tests
- Install package creation from all other artifacts, with its own CI/CD pipeline.
- DIS extension within Visual Studio
- Visual Studio templates

> [!TIP]
> See also:
>
> - [Migrating from Gerrit to GitHub](xref:migration_from_gerrit_to_github)
> - [Using GitHub - Guidelines](xref:Using_GitHub_for_CICD)
> - [CI/CD Skyline Communications Gerrit and Jenkins](xref:High-level_overview)
