---
uid: Adding_documents_hyperlinks_or_email_addresses
---

# Adding documents, hyperlinks, or email addresses

To add a document, link, or email address:

1. Right-click a folder in the tree view or right-click in the documents overview in the right pane, and select *Add document*.

1. In the *Add document* window, choose one of the following options:

   - To upload one or more local documents, under *Documents*, click *Browse*, and browse to the document(s) you want to add. To add several documents at the same time, select several documents at once when browsing.

     You can then select where the added documents will be stored in the DMS:

     - **Global**: The documents are stored in a shared folder structure that is synchronized across the DataMiner System.

     - **Local**: The document is linked to one specific element and only saved on the DMA hosting that element. This is recommended for larger files.

       > [!TIP]
       > See also: [The Elements folder](xref:Managing_the_document_folders#the-elements-folder).

   - To add a hyperlink or UNC path, select *Hyperlink or UNC path*, and enter the hyperlink or path.

   - To add an email address, select *Email*, and enter the email address.

1. Click *OK*.

> [!NOTE]
> To delete a document, hyperlink, or email address, right-click the item in question and select *Delete*.

> [!CAUTION]
> If documents are larger than a particular maximum size, they are not synchronized in a DataMiner System. We recommend storing such documents locally or using a UNC path to a network share. By default, the maximum size is set to 20 MB, but this can be customized. See [MaintenanceSettings.xml](xref:MaintenanceSettings_xml).
