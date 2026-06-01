---
uid: DH_Application
---

# DocumentHub Application

The DocumentHub app is designed for administrators and operators to manage documents, images, and files across their DataMiner environment. It provides a centralized interface for uploading, organizing, retrieving, and linking files to business operations.

![DocumentHub Application overview](~/solutions/images/DocumentHub_App_Main_Overview.png)

> [!TIP]
> For detailed walkthroughs on using the application, refer to the [DocumentHub application tutorials](xref:Tutorial_DocumentHub_Getting_Started).

## Application overview

The following sections and features are available in the app:

- ![Home](~/solutions/images/DocumentHub_Home.svg) **Home**: Access documents across buckets, filter by file name, bucket, or file type, and review related metadata.

- ![Upload](~/solutions/images/DocumentHub_Upload.png) **Upload**: Upload new documents to configured storage backends. Select the appropriate bucket to ensure files are stored in the correct location with proper metadata.

- ![Settings](~/solutions/images/DocumentHub_Settings.png) **Settings**: Connect and manage cloud storage repositories and local storage options. Configure credentials and access settings. Available to administrators only.

- ![Buckets](~/solutions/images/DocumentHub_Buckets.png) **Buckets**: Configure and manage document buckets. Define which file types go where, set upload restrictions, and manage metadata templates. Available to administrators only.

- ![SharePoint](~/solutions/images/DocumentHub_SharePoint.png) **SharePoint**: Browse files stored in your SharePoint repository, quickly filter by name or bucket, and inspect the full metadata set for each file.

- ![DataMiner](~/solutions/images/DocumentHub_DataMiner.png) **DataMiner**: Access files stored on your DataMiner server, use name and bucket filters to narrow down results, and review all available metadata details.

- ![DOM](~/solutions/images/DocumentHub_DOM.png) **DOM**: Explore files linked to DOM records, find content by filtering on name and bucket, and view the complete metadata context used in your workflows.

- ![About](~/solutions/images/DocumentHub_About.png) **About**: Provides information on the **version** of the DocumentHub package.

## Uploading documents

You can upload documents to store them in your configured storage backend. The upload process guides you through:

1. Selecting the appropriate **document bucket**.
1. Choosing the file(s) to upload.
1. Optionally give a new name to the file
1. Confirm the upload destination.

Once uploaded, the document will be stored in the configured backend for the selected bucket and will appear in the Documents view for all authorized users.

## Organizing with buckets

Document buckets streamline workflows by predefining:

- **Name** to identify the Bucket
- **Target storage backend** (SharePoint, Google Drive, local storage, etc.)
- **Allowed file extensions** (e.g., .pdf, .jpg, .png)
- **File size limits** to prevent oversized uploads
- **Upload Location** to organize your files
- **Description** (Optional) to give some extra info about that Bucket

Buckets help maintain organization and security by ensuring files are stored consistently and with proper restrictions.

## Integrating with other applications

The DocumentHub app works seamlessly with other DataMiner applications:

- **People & Organizations**: Attach profile photos and organization logos.
- **Asset Manager**: Store and display asset images and documentation.
- **Scheduling**: Link job documents and attachments.
- **Custom Applications**: Use the [DocumentHub DevPack](xref:DH_Development) to integrate with your own low-code apps.

Document usage is handled by the consuming application, allowing each app to control how documents are displayed and managed within its context.

## Storage backend integration

DocumentHub supports multiple storage backends to give you flexibility in document management:

### SharePoint (Customer-managed)

Connect to your organization's SharePoint repository to leverage existing document management infrastructure. Requires:

- SharePoint site URL
- Authentication credentials (client ID and secret)
- Folder structure configuration

### Local DataMiner Web Server

Store documents on the local DataMiner Web Server for on-premises deployments. Ideal for:

- Air-gapped or secure environments
- Sensitive internal documents
- High-performance local access

### DOM Attachments with Shared Drive

Connect to a Shared Drive in the network and store files directly on DOM instances in DataMiner.

- Network Share Path
- Authentication credentials (username and password)
- (optionally) ISS Config for virtual webserver to have resolvable paths

### Future integrations

Additional cloud storage providers may be supported in future releases based on customer demand.

## Admin capabilities

System administrators can:

- Configure storage backend connections and credentials.
- Create and manage document buckets.
- Set upload restrictions (file types, sizes, etc.).

## Searching and filtering

The Documents view includes powerful search and filtering capabilities:

- **Search by name**: Quickly find documents by filename or title.
- **Filter by bucket**: View documents from specific buckets.
- **Filter by storage backend**: Show documents from particular storage locations.

## Performance and scalability

The number of documents in DocumentHub is not capped by the application itself. In practice, scalability depends on the storage capacity and performance of your selected backend, such as SharePoint or a shared drive.

When using DataMiner Web Files in a clustered setup, keep in mind that files must be synchronized across cluster nodes. With large file volumes, this synchronization can become a bottleneck and affect overall performance.

> [!Recommended]
> - Use DataMiner Web Files mainly for images, logos, and other lightweight documents.
> - For larger document sets or heavier files, prefer cloud storage backends (for example SharePoint) or DOM attachments.
