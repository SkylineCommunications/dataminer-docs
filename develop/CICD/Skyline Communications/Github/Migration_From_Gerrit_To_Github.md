---
uid: migration_from_gerrit_to_github
---

# Migrating from Gerrit to Github

Much of the source code within Skyline is currently stored on Gerrit, an internal GIT-based server. In order to collaborate on the same code, a repository with that code must be moved from Gerrit to Github. This move is recommended only if there are Starter Workflows available for your type of repository that runs an equivalent pipeline as we did in Jenkins. This ensures there is no degradation of quality from the move and that all automatic release-cycles can continue to work.

## Prerequisites

Before migrating from Gerrit to Github, make sure you have:

- GIT installed.
- SLC SE RepoManager installed.
- Verified that GitHub has a starter workflow available (see: [SkylineCommunications/.github workflow-templates](https://github.com/SkylineCommunications/.github/tree/main/workflow-templates)) for the type of repository you are moving (Protocol, Automation Script, InstallPackage, Custom Solution, etc.).
- Used the SLC SE RepoManager to check if the repository you are attempting to migrate has already been migrated.

## Migration Steps

Follow these steps to migrate your repository from Gerrit to Github:

1. Clone the repository you want to migrate.
2. In the SkylineCommunications github organisation Create an [empty GitHub repository](https://github.com/organizations/SkylineCommunications/repositories/new). Do not add a ReadMe or .GitIgnore.
3. Follow the naming conventions as described in the [guide to create a new GitHub repository](xref:Using_GitHub_for_CICD).
4. In the file explorer, open 'GIT Bash' in the repository you want to migrate and run the following commands:

```bash
git remote add origin2 https://github.com/SkylineCommunications/[Github Repo Name].git
git push -u origin2 --all
git push -u origin2 --tags
```

5. In the SLC SE RepoManager, right-click on your repository and select "Migration Info". Fill in the "Migration Location" with your equivalent of: `https://github.com/SkylineCommunications/[Github Repo Name]`.

6. Delete your old repository from the filesystem and clone the new repository from github. This will prevent you accidentally working on the old repository
    Optionally you can choose to continue to work with your existing local repository (on your filesystem). You can do that by removing the original origin location with the following commands:

    ```bash
    git remote remove origin
    git remote rename origin2 origin
    ```

7. Consider the [Validation Requirements](xref:github_validation_requirements) and Add a README.md file and remove the JenkinsFile when you start working on your branch.
8. Add a Starter Workflow to your github repository by following the [guide to add a CI/CD Pipeline to a GitHub repository](xref:github_starter_workflows)