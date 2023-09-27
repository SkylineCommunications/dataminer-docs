---
uid: Pushing_to_a_repository
---

# Pushing to a repository

After you have performed commits on your local repository, you will want to push these commits to the server.

To do so:

1. Select the repository you want to push to in the tree control and click the push button.

1. In the pop-up window, select the branch to which you want to push.

1. After you have selected the desired branch, you can either choose to *Push for Gerrit review* or *Push for Work in Progress*.

   - If you want a code review to be performed on your pushed work, choose *Push for Gerrit review*

   - If your pushed work is still work in progress and you therefore do not want a code review to be performed on it, choose *Push for Work in Progress*.

![](~/develop/images/SLCSERepoManager_Push.png)<br>
*SLC SE Repository Manager: Pushing to a repository*

> [!NOTE]
> When you push commits to the server, the commits will be squashed (merged) into a single commit. This avoids multiple code review items being generated in Gerrit.
