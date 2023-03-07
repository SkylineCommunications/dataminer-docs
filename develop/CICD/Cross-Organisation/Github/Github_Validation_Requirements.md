---
uid: github_validation_requirements
---

# GitHub validation requirements

Some of our workflows will have a validation step. That step will validate technical requirements. This page contains this information. There are also other guidelines that might currently not get checked.
You can find those guidelines here: [GitHub guidelines](xref:Using_GitHub_for_CICD).

## NuGet solution workflow

The workflow [DataMiner CI/CD NuGet solution](xref:github_reusable_workflows_nuget_solution_master_workflow) has a validation step called "Validate NuGet Metadata".
It checks if NuGet packages match all specified conventions as listed on [Producing NuGet packages](xref:Producing_NuGet).

The Visual Studio solution should also only consist of SDK-style projects.

> [!IMPORTANT]
> NuGet solution Workflow is only applicable for Skyline Communications.

## Automation script workflow

The workflow [DataMiner CI/CD Automation script](xref:github_reusable_workflows_automation_master_workflow) has a validation step "Validate NuGet Package Configuration".
This will check that none of the projects are using the packages.config package management format. All tools only support the Packagereference package management format.
See [Consuming NuGet packages](xref:Consuming_NuGet) for more information.
