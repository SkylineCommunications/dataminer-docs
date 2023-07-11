---
uid: Pulling_content
---

# Pulling content

When you have to work on a protocol and you do not have a local version yet, you should pull this version from the repository first. To do so:

1. Open your local *Protocols* folder, right-click and select *TortoiseSVN* > *Repo-browser*.

1. To get the latest version of a protocol, navigate to the vendor and select the folder containing the latest version of the protocol.

1. Right-click the version folder and select *Update Item to revision*.

   ![](~/develop/images/SVN_update_item_to_revision.png)<br>
   *TortoiseSVN update item to revision*

1. Click *OK*. The folder will be downloaded and put in your local *Protocols* folder.

   ![](~/develop/images/SVN_rev_download.png)<br>
   *TortoiseSVN update item to revision window*

From now on, this protocol version is linked with the repository and the changes you do will be registered. Note that you can change whatever you like locally. As long as you do not push your changes to the repository (commit), nothing will change on the server.

![](~/develop/images/SVN_server_folders.png)<br>
*TortoiseSVN checked out folder*
