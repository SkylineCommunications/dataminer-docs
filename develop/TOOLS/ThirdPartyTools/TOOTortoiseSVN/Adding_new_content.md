---
uid: Adding_new_content
---

# Adding new content

In addition to pulling content from the repository, it is also possible to add new content to a repository.

To create a new protocol version, first get a local copy of the latest protocol version, as described earlier. Then do the following:

1. Take a copy of the directory of the latest protocol version and change the version numbers.

   You will notice that the newly created folder is not under version control.

   ![](~/develop/images/SVN_new_version_folders.png)<br>
   *TortoiseSVN creating a new protocol version*

1. Right-click the new protocol version folder and select *TortoiseSVN* > *Add*.

   You will get an overview of all of the files contained in the version folder. It is possible to select which items should be put under version control. When you click *OK*, the version is ready to be pushed to the repository.

   ![](~/develop/images/SVN_add_version.png)<br>
   *TortoiseSVN Add context menu item*

1. Finally, commit your new version to the repository. Right-click the folder and select *SVN Commit*.

   ![](~/develop/images/SVN_commit_context_menu_item.png)<br>
   *TortoiseSVN SVN Commit context menu item*

   This will open another window displaying the changes you are about to make to the repository. Read this window carefully, because these are the changes that will actually happen on the repository.

   ![](~/develop/images/SVN_commit_version.png)<br>
   *TortoiseSVN Add to repository window*

   In this case, you can clearly see that we are adding three items to the repository.
