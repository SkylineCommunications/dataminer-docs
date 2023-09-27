---
uid: Git_protocol_repositories
---

# Git protocol repositories

## Range branches and tags

Each protocol is stored in a dedicated Git repository on Gerrit. Different branches exist for each version range branch (e.g. 1.0.0.X, 1.0.1.X, 2.0.0.X, etc.) and each released version will result in a tag in the Git repository. Consider the following image representing the branches and tags for an example protocol Git repository:

![](~/develop/images/GitRepositoryExample.png)<br>
*Example of range branches and tags for a protocol Git repository*

This protocol has two range branches: 1.0.0.X and 2.0.0.X. The 1.0.0.X branch has tags for versions 1.0.0.1 up to and including 1.0.0.8. In the image, you can also see that a new branch has been created for the 2.0.0.X range and that version 2.0.0.1 has been created based on version 1.0.0.7.

Whenever you need to create a new version range, e.g. 1.0.1.X, you will do this by creating a new branch.

## Git vs SVN

An important difference between Git and SVN is that SVN is centralized, whereas Git is decentralized.

In SVN, you perform a checkout to obtain a working copy of an SVN repository and then perform commits to save changes in the central SVN repository.

![](~/develop/images/SVNcheckout.jpg)<br>
*SVN checkout*

Git, on the other hand, works decentralized. You can clone a Git repository, which results in a local clone of that repository with remote-tracking branches for each branch in the cloned repository. You can then perform commits on this local repository. However, performing a commit on your local repository will not result in any changes on the Git repository you originally cloned.

![](~/develop/images/GitClone.jpg)<br>
*Git clone*

In order to update the original repository, you need to push your changes to that remote repository. In the example tree above, you will see "origin/1.0.0.X" and "origin/2.0.0.X". These are the positions of the tracked branches in the remote repository that were obtained when you last connected to this remote repository. (Note that "origin" does not have any special meaning, it is merely the default name for a remote.)

This also means that when you create branches on your local repository, for example, these must be pushed to the tracked remote repository.

For more information about Git, refer to <https://git-scm.com/>.

In order to easily create new repositories on Gerrit, clone existing repositories from Gerrit to your local machine or push for Gerrit code review, the SLC SE Repository Manager tool is available, which is part of the Time Registration tool. See [SLC SE Repository Manager](xref:TOOSLCSERepositoryManager#slc-se-repository-manager).

To work on your local repository, you can use the tool SourceTree. See [SourceTree](xref:TOOSourceTree#sourcetree).
