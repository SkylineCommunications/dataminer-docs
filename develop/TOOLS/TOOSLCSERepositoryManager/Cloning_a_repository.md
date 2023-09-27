---
uid: Cloning_a_repository
---

# Cloning a repository

To clone a repository from the Gerrit server that is hosting the Git repositories, select an item in the tree control and click the *Clone Repository* button. This will clone the selected repository into the folder mentioned above the tree control.

For example, in the tree control below, the *Skyline Panel Manager* protocol has been selected. When the *Clone Repository* button is clicked, the repository will be cloned into the folder *C:\\GIT\\Protocols\\Skyline\\Skyline Panel* *Manager.*

![](~/develop/images/SLCSERepoManager_CloneRepo.png)<br>
*SLC SE Repository Manager: Cloning a repository*

The folder *C:\\GIT* is the default local GIT root folder. When a repository is cloned, subfolders are created in this root folder. For example, for the item selected in the example above, the following subfolders will be created: *Protocols*, *Skyline* and *Skyline Panel Manager*.

This local repository can then be opened using a tool such as SourceTree.

## Configuring the root folder

By default, when you clone a repository, the repository will be put under the folder *C:\\GIT*. In case you want to use a different root folder, go to *Tools* > *Options* and specify a different path in the text box *Local Git root*.

> [!NOTE]
> In case you have cloned a repository and performed some commits on your local repository that have not been pushed yet, it will not be possible to clone this repository again. Trying to do so will show the following message in the status bar:<br>
> *(Error) Cloning Repository Failed with: Local Repository has un-pushed changes!*<br>
> This is a safeguard to ensure no work is lost.
