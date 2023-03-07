---
uid: migration_from_gerrit_to_github
---

# Migrating from Gerrit to GiHhub

Much of the source code within Skyline is currently stored on Gerrit, an internal Git-based server. In order to collaborate on the same code, a repository with that code must be moved from Gerrit to GitHub. This move is recommended only if there are starter workflows available for your type of repository that runs an equivalent pipeline as we did in Jenkins. This ensures there is no degradation of quality from the move and that all automatic release-cycles can continue to work.

## Prerequisites

Before migrating from Gerrit to GitHub, make sure you have:

- Git installed
- SLC SE Repo Manager installed
- Verified that GitHub has a starter workflow available (see: [SkylineCommunications/.github workflow-templates](https://github.com/SkylineCommunications/.github/tree/main/workflow-templates)) for the type of repository you are moving (connector, Automation script, install package, custom solution, etc.)
- Used the SLC SE Repo Manager to check if the repository you are attempting to migrate has already been migrated

## Migration Steps

Follow these steps to migrate your repository from Gerrit to GitHub:

1. Clone the repository you want to migrate
1. In the SkylineCommunications GitHub organization, create an [empty GitHub repository](https://github.com/organizations/SkylineCommunications/repositories/new). Do not add a README or .gitignore.
1. Follow the naming conventions as described in the [guide to create a new GitHub repository](xref:Using_GitHub_for_CICD)
1. In the file explorer, open 'Git Bash' in the repository you want to migrate and run the following commands:

  ```bash
  git remote add origin2 https://github.com/SkylineCommunications/<GitHubRepositoryName>.git
  git push -u origin2 --all
  git push -u origin2 --tags
  ```

1. In the SLC SE Repo Manager, right-click on your repository and select "Migration Info". Fill in the "Migration Location" with your equivalent of: `https://github.com/SkylineCommunications/<GitHubRepositoryName>`.
1. Delete your old repository from the file system and clone the new repository from GitHub. This will prevent you accidentally working on the old repository.
   Optionally, you can choose to continue to work with your existing local repository (on your file system). You can do that by removing the original origin location with the following commands:

    ```bash
    git remote remove origin
    git remote rename origin2 origin
    ```

1. Consider the [Validation requirements](xref:github_validation_requirements) and add a README.md file and remove the JenkinsFile when you start working on your branch.
1. Add a starter workflow to your GitHub repository by following the [Guide to add a CI/CD pipeline to a GitHub repository](xref:github_starter_workflows)