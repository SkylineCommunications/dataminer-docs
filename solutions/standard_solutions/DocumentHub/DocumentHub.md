---
uid: DocumentHub
---

# DocumentHub

## Centralized document management for DataMiner applications

DataMiner DocumentHub is a comprehensive document and file management solution that can be used by DataMiner applications to store, organize, and retrieve documents, images, and other files. Whether managing job attachments, profile pictures, organizational logos, or reports, DocumentHub provides a unified, secure platform with integrated cloud storage support and metadata management.

Designed for broadcast, service provider, satellite, and enterprise organizations, DocumentHub eliminates the need for fragmented file storage solutions across multiple applications. It centralizes all document workflows while allowing IT teams to maintain control over security, compliance, and storage backend selection.

![DocumentHub centralized file management](~/solutions/images/DocumentHub.svg)

## DocumentHub application

The DocumentHub Solution is available in the [Catalog](https://catalog.dataminer.services/details/f9720b2e-fdaa-4956-9788-877328b587ca) as a package containing a [dedicated low-code app](xref:DH_Application). The solution [integrates seamlessly](#integration-with-other-applications) with other DataMiner applications and also provides a NuGet API for custom application development.

<div class="row">
  <div class="column">
    <a href="xref:DH_Application" title="DocumentHub app" target="_self">
      <img src="~/solutions/images/DocumentHub_App_Logo.png" style="width:100%">
    </a>
    <p>
      <em>DocumentHub app</em>
    </p>
  </div>
  <div class="column">
    <a href="xref:DH_Development" title="DocumentHub DevPack" target="_self">
      <img src="~/solutions/images/DocumentHub-devpack.png" style="width:100%">
    </a>
  <p>
    <em>DocumentHub DevPack</em>
  </p>
  </div>
</div>

> [!TIP]
>
> - Before you deploy the DocumentHub package, check the [installation instructions](xref:DH_Installation).
> - Developers integrating DocumentHub with custom applications should refer to the [DocumentHub DevPack](xref:DH_Development) documentation.
> - For details about the changes introduced in each DocumentHub version, refer to the [release notes](xref:DocumentHub_RNs_index).

## Who can benefit from DocumentHub?

DocumentHub serves diverse user groups across your organization:

- **IT and security teams**: Implement centralized document management with control over storage backends, access credentials, file format restrictions, and compliance policies. The solution supports customer-managed SharePoint or on-premises storage options like DataMiner web files or DOM attachments.

- **System administrators**: Configure document buckets for file grouping with file upload limitations, storage locations, and file extension rules.

- **Content and asset managers**: Streamline workflows for organizing and retrieving documents across your organization. Normalize graphics formats for consistency and for automated processing.

- **Application developers**: Integrate DocumentHub capabilities into custom DataMiner low-code apps using the NuGet API. Retrieve file information, upload documents, and manage buckets programmatically.

- **Business operations teams**: Access documents from within operational applications such as People & Organizations, Asset Manager, and Scheduling. Attach job documents, profile images, asset photos, and service icons without leaving the application context.

In essence, DocumentHub enables organizations to deliver better service quality, reduce fragmentation in document workflows, respond faster to business needs, and maintain compliance through centralized, secure file management.

## What can you do with DocumentHub?

The DocumentHub Solution simplifies document and file management across your DataMiner ecosystem. The solution provides a [ready-made application](xref:DH_Application) that can be extended with custom workflows and integrations. It can also be extended with automation scripts and user-defined APIs to integrate with your existing systems.

DocumentHub supports the following capabilities by default without any customization:

- **Upload and store**: Upload new documents, images, and files from user terminals to configured storage backends (SharePoint, local DataMiner web server, and DOM attachments).

- **Link and reference**: Store file references and URLs in DataMiner DOM objects and applications. Link documents to jobs, assets, contacts, and other business entities.

- **Search and navigate**: Discover documents by name and buckets. Browse and organize files through a unified interface regardless of storage location.

- **Read and display**: View and open documents in third-party applications. Common file types are supported, including .jpg, .png, .gif, .svg, .pdf, .docx, .xlsx, and .pptx.

- **Normalize and format**: Apply format conversion and normalization to graphics files at ingest to ensure consistency across standard solutions.

- **Organize with buckets**: Create predefined document buckets to streamline workflows. Specify target platforms, allowed file extensions, and file size limits for each bucket.

- **Integrate with APIs**: Use the DocumentHub NuGet package to develop custom integrations. Retrieve file information, manage buckets, and upload documents programmatically.

Example use cases:

- **People and organizations**: Profile photos and contact avatars for team members and external contacts.
- **Asset management**: Front and rear panel images of infrastructure assets, racks, and equipment.
- **Service and channel management**: Service icons, channel logos, and branding assets.
- **Scheduling and jobs**: PDF job sheets, contracts, and task documentation.
- **Cost and billing**: Generated invoices, cost reports, and financial documents.
- **Energy and utilities**: Equipment documentation, compliance certificates, and facility plans.
- **Fleet management**: Vehicle documentation, maintenance records, and operational photos.

## Integration with other applications

DocumentHub works together seamlessly with other DataMiner applications:

- **People & Organizations**: Attach profile photos and organization logos.
- **Asset Manager**: Store and display asset images and documentation.
- **Scheduling**: Link job documents and attachments.
- **Custom Applications**: Use the [DocumentHub DevPack](xref:DH_Development) to integrate with your own low-code apps.

Document usage is handled by the consuming application, allowing each app to control how documents are displayed and managed within its context.

<style>
.column a {
  display: inline-block;
  padding: 4px;
  border-radius: 4px;
  transition: all 0.2s ease-in-out;
}

.column a:hover {
  background-color: #f0f4ff; /* light background on hover */
  transform: scale(1.05);   /* slightly bigger */
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1); /* subtle shadow */
}
</style>