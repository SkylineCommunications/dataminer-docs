---
uid: CICD_at_Skyline
---

# CI/CD at Skyline Communications

There are currently several major CI/CD flows within Skyline Communications. Here are a few of our flows currently in production:

- Internal CI/CD for the core DataMiner software
- Internal CI/CD for the creation of CI/CD-related dotnet tools
- Internal CI/CD for the creation of DataMiner artifacts (e.g. Automation scripts, connectors, dashboards, etc.)

> [!TIP]
> See also:
>
> - [Migrating from Gerrit to GitHub](xref:migration_from_gerrit_to_github)
> - [Using GitHub - Guidelines](xref:Using_GitHub_for_CICD)
> - [CI/CD Skyline Communications Gerrit and Jenkins](xref:High-level_overview)

## Internal CI/CD for the core DataMiner software

Uses a combination of:

- [Gerrit](https://www.gerritcodereview.com/) for source control (git-like repository)
- [Jenkins](https://www.jenkins.io/) pipelines that run on commits to Gerrit repositories to trigger quality control and automated steps
- Jenkins pipelines that run daily on the latest Release Candidate (RC) and look for introduction of compile-time errors on connector QActions
- Gerrit code review blocking commits when pipelines fail
- A massive array of DataMiner setups running daily and weekly regression tests
- A reporting UI, QA Portal, to consolidate all testing results

## Internal CI/CD for the creation of CI/CD related dotnet tools

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

## Internal CI/CD for the creation of DataMiner artifacts

Uses a combination of:

- Gerrit for source control (git-like repository)
- Jenkins pipelines that run on commits to Gerrit repositories to trigger quality control and automated steps
- Automatic release cycles, registration, and uploading to the catalog
- Unit tests for every artifact as required
- Public re-usable [NuGet](https://www.nuget.org/) libraries with their own pipelines and unit tests
- Install package creation from all other artifacts, with its own CI/CD pipeline.
- DIS extension within Visual Studio
- Visual Studio templates
