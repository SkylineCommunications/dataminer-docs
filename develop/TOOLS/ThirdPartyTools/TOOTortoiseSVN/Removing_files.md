---
uid: Removing_files
---

# Removing files

If you only wish to delete a file from your local folder, do the following:

1. Right-clicking the file and select *TortoiseSVN* > *Update to revision*.

   ![](~/develop/images/SVN_remove_file.png)<br>
   *TortoiseSVN update to revision window*

1. Set the *Update Depth* to *Exclude* in order to remove the file from your local working directory when you click *OK*.

   The file will remain unchanged on the repository. You can get this file back at any time by opening the repository browser and doing an update to revision of the file.

If you were to delete the file instead of excluding it from the revision, you would delete the file both locally and in the repository with the next commit.

![](~/develop/images/SVN_commit_delete.png)<br>
*TortoiseSVN commit window*

This is why we advise to always take your time and carefully read the changes during a commit. This shows exactly what changes you are going to push to the repository:

![](~/develop/images/SVN_deleting.png)<br>
*TortoiseSVN Commit Finished window*
