---
uid: github_validation_requirements
---

# GitHub Validation Requirements

Some of our workflows will have a validation step. That step will validate technical requirements. This page contains this information. There are also other guidelines that might currently not get checked.
You can find those guidelines here: [GitHub Guidelines](xref:Using_GitHub_for_CICD).

## NuGet Solution Workflow

The workflow [DataMiner CICD NuGet Solution"](xref:github_reusable_workflows_nuget_solution_master_workflow) has a validation step called: Validate NuGet Metadata.
It checks if NuGets match all specified conventions as listed on [Producing NuGet packages](xref:Producing_NuGet).

The Visual Studio solution should also only contain project of SDK Style.

> [!IMPORTANT]
> NuGet Solution Workflow is only applicable for Skyline Communications.

## Automation Script Workflow

The workflow [DataMiner CICD AutomationScript](xref:github_reusable_workflows_automation_master_workflow) has a validation step: Validate NuGet Package Configuration.
This will check that none of the projects are using NuGets installed through packages.config. All current tools only support NuGets added with packagereference.
See [Consuming NuGets](xref:Consuming_NuGet) for more information.
