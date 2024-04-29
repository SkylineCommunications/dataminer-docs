---
uid: Managing_the_document_folders
---

# Managing the document folders

The tree view on the left side of the Documents module contains several root folders:

- The *General documents* folder. This default folder cannot be renamed or deleted.

- A number of protocol folders, named after the protocols in question.

  - To **add a protocol folder**, right-click in the blank area underneath the folders in the tree view on the left and select *Add protocol folder*. This option is only available in the Documents module, not on the Documents page of a card.

  - To **delete a protocol folder**, right-click the folder and select *Delete*. However, keep in mind that some protocols may require specific documents in this folder to function properly.

Within each folder, you can **add, rename, or delete custom folders** through the right-click menu.

## The Elements folder

<!-- RN 21997 -->

On the *Documents* page of an element, there is also a default *Elements* folder containing a subfolder for that specific element. This subfolder contains documents that are associated with that particular element only. It is not possible to add or rename such element folders.

The documents in such an element folder are stored on the DataMiner Agent hosting the element, and they are not synced with other Agents in the cluster. This makes this folder especially useful for storing larger files. However, note that these documents cannot be opened through Cube.

When you [add a document](xref:Adding_documents_hyperlinks_or_email_addresses) in an element folder, a single-byte file with the same name as the document will also be stored in the element folder. Contrary to the document itself, this small file will be synchronized among all Agents in the DataMiner System. It is used to make all Agents aware of this element-level document.

> [!CAUTION]
> In a **Failover** pair, element documents are only synced between the Agents if they do not exceed the maximum file size. This means that after a Failover switch, an element may no longer have access to its own large documents. By default, the maximum size is set to 20 MB, but this can be customized. See [MaintenanceSettings.xml](xref:MaintenanceSettings_xml). As a consequence,for large documents, we recommend using a UNC path to a network share instead.
