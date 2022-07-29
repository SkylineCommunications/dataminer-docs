---
uid: Using_SourceTree
---

# Using SourceTree

After starting up SourceTree, you will see a window where you can select a repository. Press the *Local* button at the top on the left-hand side to open a local repository. Here you can either specify the path to a local repository or drag and drop a Git repository folder.

![](~/develop/images/SourceTree_repositories.png)
<br>Figure 116: SourceTree: Selecting local repositories

When you select a Git repository, SourceTree will load the repository:

![](~/develop/images/SourceTree_loadedrepository.png)
<br>Figure 117: SourceTree: Local repository

On the left-hand side, you will see an overview of the local and remote branches as well as the different tags. On the right-hand side, you will see a tree view showing the different branches, commits and tags.

For more information about how to work with SourceTree, refer to <https://confluence.atlassian.com/get-started-with-sourcetree>

## Debugging problems with Windows Max Paths

Windows has a default maximum limit of 260 characters for any paths. Sourcetree can show cloning, pushing, committing, ... issues when trying to do something with a repository that has very deeply nested files (>260 characters).

The best way to handle these is to clone your repository directly under a folder in the C driver to reduce any additional nesting on your local computer.

For members of Skyline Communications using the SLC SE RepoManager. You can go find the repository directly on gerrit and copy the clone link from there then clone it anywhere on your local machine. SLC RepoManager won't work with that clone but at that point you won't need it.

Alternatively you can try to partially allow long path support for both the windows OS and the git tool used by sourcetree. Do note that this isn't recommended and is also default disabled because it doesn't fix every tool & command.

https://github.com/msysgit/msysgit/wiki/Git-cannot-create-a-file-or-directory-with-a-long-path


- For the OS: https://www.thewindowsclub.com/how-to-enable-or-disable-win32-long-paths-in-windows-11-10
- For SourceTree: SourceTree does not have a setting for long paths in the tool itself. In the .gitconfig file, set core.longpaths to true and then configure SourceTree to use the system Git instead of the built in one (under Tools > Options > Git, click the System button under Git version).



