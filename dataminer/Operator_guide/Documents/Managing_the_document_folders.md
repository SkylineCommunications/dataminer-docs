---
uid: Managing_the_document_folders
---

# Managing the document folders

The tree view on the left side of the Documents module contains several root folders:

- The *General documents* folder. This default folder cannot be renamed or deleted.

- The *Elements* folder. This folder contains subfolders for each element that has documents configured on element level. If this folder is not displayed in the Documents module, this means that no documents have been configured on element level, or you do not have access to the elements that have documents configured. See [The Elements folder](#the-elements-folder).

- A number of protocol folders, named after the protocols in question.

  - To **add a protocol folder**, right-click in the blank area underneath the folders in the tree view on the left and select *Add protocol folder*. This option is only available in the Documents module, not on the Documents page of a card.

  - To **delete a protocol folder**, right-click the folder and select *Delete*. However, keep in mind that some protocols may require specific documents in this folder to function properly.

Within each folder, you can **add, rename, or delete custom folders** through the right-click menu.

> [!NOTE]
> Adding subfolders on element level is only supported from DataMiner 10.4.0 [CU5]/10.4.8 onwards.<!-- RN 39076+39876 -->

## The Elements folder

<!-- RN 21997 -->

On the *Documents* page of an element, there is a default *Elements* folder containing a subfolder for that specific element. This subfolder contains documents that are associated with that particular element only. It is not possible to add or rename such element folders.

The documents in such an element folder are stored on the DataMiner Agent hosting the element, and they are not synced with other Agents in the cluster. This makes this folder especially useful for storing larger files. However, note that these documents cannot be opened directly from Cube. From DataMiner 10.4.0 [CU5]/10.4.8 onwards, you can download them using the *Save* option in the right-click menu, though only if Cube is connected to the Agent where the element is stored.

When you [add a document](xref:Adding_documents_hyperlinks_or_email_addresses) in an element folder, a single-byte file with the same name as the document will also be stored in the element folder. Contrary to the document itself, this small file will be synchronized among all Agents in the DataMiner System. It is used to make all Agents aware of this element-level document.

> [!CAUTION]
> In a **Failover** pair, element documents are only synced between the Agents if they do not exceed the maximum file size. This means that after a Failover switch, an element may no longer have access to its own large documents. By default, the maximum size is set to 20 MB, but this can be customized. See [MaintenanceSettings.Documents.MaxSize](xref:MaintenanceSettings.Documents.MaxSize). As a consequence,for large documents, we recommend using a UNC path to a network share instead.
