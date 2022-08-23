---
uid: TOOSLCSERepositoryManager
---

# SLC SE Repository Manager

> [!IMPORTANT]
> This section might include some information that is only applicable to Skyline employees and/or links that are only accessible to Skyline employees.

The SLC SE Repository Manager is the main tool to interact with the Gerrit server that hosts all Git repositories for System Engineering. This tool can be used to perform the following operations:

- Create new repositories

- Push commits to a repository

- Clone repositories

The SLC SE Repository Manager installer can be downloaded from [http://tools/Installers.html](http://tools/Installers.html).

> [!NOTE]
>
> - The SLC SE Repository Manager requires the use of VPN.
> - The SLC SE Repository Manager makes use of the SharpSvn library, which has a dependency on the Microsoft Visual C++ 2010 x86 Redistributable. This can be downloaded from <https://www.microsoft.com/en-us/download/details.aspx?id=26999>.
> - At startup, the SLC SE Repository Manager verifies whether a new version of the tool is available and downloads the new version if this is the case.

The main window of the SLC SE Repository Manager is shown below.

![](~/develop/images/SLC_SE_Repo_Manager_tool.png)
<br>SLC SE Repository Manager main window

On startup, the tool will load all known protocol repositories hosted on Gerrit, grouped by vendor, and display these in a tree control on the left-hand side. On the right-hand side, you can find the main buttons to perform different operations. A button will only be enabled in case the item selected in the tree supports the operation.

Next to each data source, you can see one of the following icons:

- **Circle**: This means the status of the repository is being loaded.

- **Wrench**: This means someone is working on this driver. Technically, the tool checks if one of the branches does not end with a Tag or if there is a Gerrit branch.

- **Memory**: This means nobody is working on this driver and all versions are fully released. Technically, this means all branches end with a commit that has a version tag.

> [!IMPORTANT]
> If you use Gerrit branches, remember to delete the Gerrit branch after you finish the code review and push submit in Gerrit. It is important to clean up your Gerrit branches.

On the right-hand side, you can find the main buttons to perform different operations. A button will only be enabled in case the item selected in the tree supports the operation.

On the right-hand side, just below the menu bar and tab control, links are provided to Gerrit, SonarQube, Jenkins, SourceTree and file explorer. These links will be enabled depending on your current selection in the tree control.

You can find more information on the supported operations in the following sections:

- [Cloning a repository](xref:Cloning_a_repository)

- [Pushing to a repository](xref:Pushing_to_a_repository)

- [Creating a repository](xref:Creating_a_repository)

- [Reloading the tree](xref:Reloading_the_tree)

- [Removing a repository](xref:Removing_a_repository)

- [Options window](xref:Options_window)

- [Sandbox mode](xref:Sandbox_mode)

- [Updating .gitignore and Jenkins file](xref:Updating_gitignore_and_Jenkins_file)
