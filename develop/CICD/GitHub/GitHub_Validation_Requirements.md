---
uid: github_validation_requirements
---

# GitHub validation requirements

Some of our workflows have a validation step, which validates technical requirements.

> [!NOTE]
> Not all guidelines are currently checked in the validation step. For information on those guidelines, refer to [GitHub guidelines](xref:Using_GitHub_for_CICD).

## NuGet solution workflow

> [!IMPORTANT]
> The NuGet solution workflow is only applicable for Skyline Communications.

The workflow [DataMiner CI/CD NuGet solution](xref:github_reusable_workflows_nuget_solution_master_workflow) has a validation step called "Validate NuGet Metadata". It checks if NuGet packages match all specified conventions listed under [Producing NuGet packages](xref:Producing_NuGet).

The Visual Studio solution should also only consist of SDK-style projects.

## Automation script workflow

The workflow [DataMiner CI/CD Automation script](xref:github_reusable_workflows_automation_master_workflow) has a validation step "Validate NuGet Package Configuration". This will check if none of the projects use the packages.config package management format. All tools only support the PackageReference package management format. For more information, see [Consuming NuGet packages](xref:Consuming_NuGet).
