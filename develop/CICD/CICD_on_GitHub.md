---
uid: CICD_on_GitHub
---

# CI/CD using GitHub

Skyline Communications is currently in the process of migrating its internal CI/CD for DataMiner artifacts to [GitHub](https://github.com/). This is part of efforts to improve cross-organization collaboration while maintaining the high quality and ease-of-life automation from the internal CI/CD.

We use a combination of:

- GitHub as source control
- GitHub workflows (reusable or starter) that run on commits to GitHub repositories to trigger e.g. quality control
- GitHub actions for specific popular actions such as deployment of artifacts
- Dotnet tooling within workflows to provide reusable and well-tested scripting
- DIS extension within Visual Studio
- Visual Studio templates

If you and your organization are ready to dive into GitHub, check out these tutorials:

- [From code to product](xref:CICD_Tutorial_GitHub_Code_To_Product)
- [Setting up your development environment in GitHub](xref:CICD_Tutorial_GitHub_Setting_Up_Organization)

For more information, refer to:

- [CI/CD starter workflows](xref:github_starter_workflows)
- [CI/CD reusable workflows](xref:github_reusable_workflows)
- [CI/CD GitHub Examples](xref:CICD_GitHub_Examples)
- [Skyline-specific: migration efforts](xref:migration_from_gerrit_to_github)
- [Skyline-specific: Guidelines for using GitHub](xref:Using_GitHub_for_CICD)
