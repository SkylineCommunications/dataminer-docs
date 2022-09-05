---
uid: Using_SourceTree
---

# Using SourceTree

After starting up SourceTree, you will see a window where you can select a repository. Press the *Local* button at the top on the left-hand side to open a local repository. Here you can either specify the path to a local repository or drag and drop a Git repository folder.

![](~/develop/images/SourceTree_repositories.png)<br>
*SourceTree: Selecting local repositories*

When you select a Git repository, SourceTree will load the repository:

![](~/develop/images/SourceTree_loadedrepository.png)<br>
*SourceTree: Local repository*

On the left-hand side, you will see an overview of the local and remote branches as well as the different tags. On the right-hand side, you will see a tree view showing the different branches, commits and tags.

For more information about how to work with SourceTree, refer to <https://confluence.atlassian.com/get-started-with-sourcetree>

## Debugging problems with Windows Max Paths

Windows has a default maximum limit of 260 characters for any path. Sourcetree can show cloning, pushing, committing, ... issues when trying to do something with a repository that has deeply nested files (>260 characters).

The best way to handle these is to clone your repository directly under a folder on the C: drive to reduce any additional nesting on your local computer.

Members of Skyline Communications who use the SLC SE RepoManager can go find the repository on gerrit, copy the clone link, and clone it anywhere on their local machine. SLC RepoManager will not work with that clone but at that point you won't need it.

Alternatively you can try to partially allow long path support for both the windows OS and the git tool used by sourcetree. Do note that this is not recommended and also by default disabled because it does not fix every tool and command.

<https://github.com/msysgit/msysgit/wiki/Git-cannot-create-a-file-or-directory-with-a-long-path>

- For the OS: <https://www.thewindowsclub.com/how-to-enable-or-disable-win32-long-paths-in-windows-11-10>
- For SourceTree: SourceTree does not have a setting for long paths in the tool itself. In the *.gitconfig* file, set `core.longpaths` to true and then configure SourceTree to use the system Git instead of the built in one (under *Tools > Options > Git*, click the *System* button under *Git version*).
