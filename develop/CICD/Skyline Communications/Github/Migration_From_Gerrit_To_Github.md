---
uid: migration_from_gerrit_to_github
---

# Migrating from Gerrit to GitHub

Much of the source code within Skyline is currently stored on Gerrit, an internal Git-based server. In order to collaborate on the same code, a repository with that code must be moved from Gerrit to GitHub. This move is recommended only if there are starter workflows available for your type of repository that run an equivalent pipeline as in Jenkins. This ensures that the move causes no degradation of quality and that all automatic release cycles can continue to work.

## Prerequisites

Before migrating from Gerrit to GitHub:

- Make sure Git is installed.

- Make sure SLC SE Repo Manager is installed.

- Make sure that GitHub has a starter workflow available (see [SkylineCommunications/.github workflow-templates](https://github.com/SkylineCommunications/.github/tree/main/workflow-templates)) for the type of repository you are moving (connector, Automation script, install package, custom solution, etc.).

- Use the SLC SE Repo Manager to check if the repository you are attempting to migrate has not already been migrated.

## Migration Steps

Follow these steps to migrate your repository from Gerrit to GitHub:

1. Clone the repository you want to migrate.

1. In the SkylineCommunications GitHub organization, create an [empty GitHub repository](https://github.com/organizations/SkylineCommunications/repositories/new).

   > [!CAUTION]
   > Do not initialize the repository with a README, .gitignore, or license. This will add a commit to the empty repository, which will cause the next step in this procedure to fail.

   > [!NOTE]
   > Follow the naming conventions described under [our guidelines for using GitHub](xref:Using_GitHub_for_CICD).

1. In the file explorer, open *Git Bash* in the repository you want to migrate and run the following commands:

   ```bash
   git remote add origin2 https://github.com/SkylineCommunications/<GitHubRepositoryName>.git
   git push -u origin2 --all
   git push -u origin2 --tags
   ```

1. In the SLC SE Repo Manager, right-click your repository and select *Migration Info*.

1. Fill in the *Migration Location* with your equivalent of `https://github.com/SkylineCommunications/<GitHubRepositoryName>`.

1. Delete your old repository from the file system and clone the new repository from GitHub.

   This will make sure you cannot accidentally work in the old repository.
  
   > [!NOTE]
   > Optionally, you can choose to continue to work with your existing local repository (in your file system). You can do so by removing the original origin location with the following commands:
   >
   > ```bash
   > git remote remove origin
   > git remote rename origin2 origin
   > ```

1. Make sure you meet the [validation requirements](xref:github_validation_requirements), add a README.md file, and remove the Jenkinsfile when you start working on your branch.

1. Add a starter workflow to your GitHub repository. See [GitHub starter workflows](xref:github_starter_workflows).
