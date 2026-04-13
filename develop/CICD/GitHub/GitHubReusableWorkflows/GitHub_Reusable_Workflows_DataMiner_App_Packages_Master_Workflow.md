---
uid: github_reusable_workflows_dataminer_app_packages_master_workflow
---

# DataMiner App Packages Master Workflow

This workflow acts as a thin wrapper that delegates to the [Master Workflow](xref:github_reusable_workflows_master_workflow). For new repositories, we recommend calling the Master Workflow directly. Existing repositories using this workflow will continue to work without changes.

> [!IMPORTANT]
> Because this workflow delegates to the Master Workflow, it performs the full CI/CD pipeline, including NuGet package handling. If your repository already has a separate NuGet Solution workflow alongside this one, both workflows will execute the same pipeline when a tag is created, which can lead to duplicate artifact uploads or publishing conflicts. In that case, remove one of the two workflows and switch to a single [Master Workflow](xref:github_reusable_workflows_master_workflow) call.

The DataMiner App Packages Master Workflow was originally designed to run on repositories containing one or more of the following DataMiner SDK-style projects:

- DataMiner Ad Hoc Data Source Project
- DataMiner Automation Script Library Project
- DataMiner Automation Script Project
- DataMiner Package Project
- DataMiner User-Defined API Project

This workflow delegates to the [Master Workflow](xref:github_reusable_workflows_master_workflow) for the full CI/CD pipeline, including quality gate steps, artifact creation, and publishing. For detailed information, refer to the [Master Workflow documentation](xref:github_reusable_workflows_master_workflow).
