---
uid: Pushing_changes
---

# Pushing changes

When you have completed the changes to a protocol, these need to be pushed to the repository.

Whenever a file is changed or out of sync with the repository, this will be indicated with a red icon.

![](~/develop/images/SVN_out_of_sync_icon.png)<br>
*TortoiseSVN file out of sync*

However, to push the changes you made to a file, you need to call a commit on that file or on the entire folder. To do so, perform a commit (see [Adding new content](xref:Adding_new_content)). Take your time to read the change list, because this displays what will actually happen on the repository.

> [!NOTE]
> The default behavior of a commit is to unlock the files you are committing. However, if you are committing intermediary results (which is good practice), you can enable the *Keep locks* option. This way you do not have to perform a lock after every commit.
>
> ![](~/develop/images/SVN_keep_locks.png)<br>
> *TortoiseSVN Keep locks option*

When the commit is finished, your file will be in sync with the repository and it will be flagged with a green icon again.

![](~/develop/images/SVN_in_sync_icon.png)<br>
*TortoiseSVN synced items*
