---
uid: Updating_gitignore_and_Jenkins_file
---

# Updating .gitignore and Jenkins file

When a repository is selected, the folder icon on the bottom right could start showing arrows going up. This indicates that some files that were automatically added when the repository got created (e.g. the Jenkins file, .gitignore) should be updated.

Note that this upgrade does not touch your code and does not commit or push to Git.

The upgrade currently performs the following actions:

- Adding additional .gitignore rules that will make sure you are not pushing unnecessary files to the server, such as StyleCop result files and other such files.

- Adding a new *DefaultTemplates* folder, where you can add exported alarm templates, trend templates and information templates that could be used as a default with this driver.

  > [!NOTE]
  > Make sure to check the included readme file as it provides some information about naming conventions that are used.

- Adding a versioning TXT file, so the repo manager knows if the current config files of your active branch and repo are up to date.

![](~/develop/images/SLC_SE_Repo_Manager_updating.png)<br>
*SLC SE Repository Manager updating .gitignore and Jenkins file*
