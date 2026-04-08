---
uid: github_reusable_workflows_nuget_solution_master_workflow
---

# NuGet Solution Master Workflow

> [!NOTE]
> This workflow now acts as a thin wrapper that delegates to the [Master Workflow](xref:github_reusable_workflows_master_workflow). For new repositories, we recommend calling the Master Workflow directly. Existing repositories using this workflow will continue to work without changes.

> [!WARNING]
> Because this workflow delegates to the Master Workflow, it performs the full CI/CD pipeline, including DataMiner package handling. If your repository already has a separate DataMiner App Packages workflow alongside this one, both workflows will execute the same pipeline when a tag is created, which can lead to duplicate artifact uploads or publishing conflicts. In that case, remove one of the two workflows and switch to a single [Master Workflow](xref:github_reusable_workflows_master_workflow) call.

The NuGet Solution Master Workflow was originally designed to run on repositories containing the DataMiner NuGet Package Solution provided by the DIS extension in Visual Studio or from [Skyline.DataMiner.VisualStudioTemplates](https://www.nuget.org/packages/Skyline.DataMiner.VisualStudioTemplates#readme-body-tab).

This workflow delegates to the [Master Workflow](xref:github_reusable_workflows_master_workflow) for the full CI/CD pipeline, including quality gate steps, NuGet package creation, signing, and publishing. For detailed information, see the [Master Workflow](xref:github_reusable_workflows_master_workflow) documentation.

The NuGet Solution Master Workflow sets the NuGet push destination to `https://api.nuget.org/v3/index.json` (nuget.org), while the Internal NuGet Solution Master Workflow pushes to the [GitHub Packages registry](https://github.com/features/packages) of the repository owner.
