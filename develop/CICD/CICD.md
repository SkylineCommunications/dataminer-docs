---
uid: CICD
---

# Continuous Integration Continuous Delivery (Deployment)

## About

Continuous Integration is the practice of regularly merging code changes from multiple developers into a shared repository and verifying those changes through automated builds and tests.

Continuous Delivery is the practice of automating the entire software release process, from building the code to deploying it to production, with the goal of quickly and reliably getting changes into the hands of users.

Continuous Deployment is similar to Continuous Delivery, but goes a step further by automatically deploying changes to production as soon as they pass all tests and checks.

Together, CI/CD allows teams to deliver software more quickly, with higher quality and reliability, by automating the build, test, and deployment process.

## At Skyline Communications

There are currently several major flows concerning CI/CD within Skyline Communications.
The topics within the CI/CD Documentation will provide information on several of them.

Here are a few of our flows currently in production:

Internal CI/CD for the Core software: DataMiner
Internal CI/CD for the creation of CI/CD related Dotnet Tools (dogfooding)
Internal CI/CD for the creation of DataMiner Artifacts (e.g. Automation Scripts, Connectors, Dashboards, ...)
Cross-Organisation CI/CD for the collaborative creation of DataMiner Artifacts (e.g. Automation Scripts, Connectors, Dashboards, ...)

## Cross-Organisation CI/CD

Is an ongoing DevOps migration of our internal CI/CD for DataMiner Artifacts.
This is part of efforts to improve cross-organisation collaborative efforts while maintaining our high quality and ease-of-life automations from the Internal CI/CD.

Uses a combination of:

- Github as source control
- Github workflows (reusable, starter) that run on commits done to github repositories to trigger quality control and automated steps.
- Github Actions for specific popular actions such as Deployment of artifacts.
- Dotnet tooling within workflows to provide reusable and well-tested scripting.
- DIS extension within Visual Studio
- Visual Studio Templates

For more information refer to:

- [CI/CD Starter Workflows](xref:github_starter_workflows)
- [CI/CD Reusable Workflows](xref:github_reusable_workflows)
- [Deploy Action](xref:Deploying_Automation_scripts_from_a_GitHub_repository)
- [Skyline Specific: Migration Efforts](xref:migration_from_gerrit_to_github)
- [Skyline Specific: Github Naming Conventions](xref:Using_GitHub_for_CICD)

## Internal CI/CD for the creation of DataMiner Artifacts

Uses a combination of:

- Gerrit for source control. (git-like repository)
- Jenkins pipelines that run on commits done to gerrit repositories to trigger quality control and automated steps.
- Automatic Release Cycles, registration and uploading to the catalog
- Unit Tests for every Artifact as required.
- Public Re-usable NuGet Libraries with their own Pipelines and Unit Tests
- Install Package Creation from all other artifacts, with its own CICD pipeline.
- DIS extension within Visual Studio
- Visual Studio Templates

For more information refer to:

- [Development With CI/CD](xref:DevelopmentWithCICD)

## Internal CI/CD for the Core software: DataMiner

Uses a combination of:

- Gerrit for source control. (git-like repository)
- Jenkins pipelines that run on commits done to gerrit repositories to trigger quality control and automated steps.
- Jenkins pipelines that run daily on the last Release Candidate and looks for introduction of compile errors on Connector QActions.
- Gerrit Code Review blocking commits when pipelines fail.
- A massive array of DataMiner setups running daily and weekly regression tests.
- A reporting UI called QA Portal to consolidate all testing results.

## Internal CI/CD for the creation of CI/CD related Dotnet Tools

To run pipelines you often need additional scripts and code to get the desired results. In the interest of quality, it was decided early on to make sure that code ran through the same pipelines it tries to make.
A good use-case of the dogfooding concept.

Uses a combination of:

- Gerrit for source control. (git-like repository)
- Jenkins pipelines that run on commits done to gerrit repositories to trigger quality control and automated steps.
- Automatic Signing and Publishing of dotnet tools.
- Large battery of Unit Tests
- Public Re-usable NuGet Libraries with their own Pipelines and Unit Tests
- Github as source control
- Github workflows (reusable, starter) that run on commits done to github repositories to trigger quality control and automated steps.
- Github Actions for specific popular actions such as Deployment of artifacts.
- Dotnet tooling within workflows to provide reusable and well-tested scripting.
- DIS extension within Visual Studio
- Visual Studio Templates
