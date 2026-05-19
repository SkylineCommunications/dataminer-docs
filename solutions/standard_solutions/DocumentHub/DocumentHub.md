---
uid: DocumentHub
---

# DocumentHub

## Centralized document management for your DataMiner applications

DataMiner DocumentHub is a comprehensive document and file management solution that enables DataMiner applications to seamlessly store, organize, and retrieve documents, images, and other files. Whether managing job attachments, profile pictures, organizational logos, or reports, DocumentHub provides a unified, secure platform with integrated cloud storage support and metadata management.

Designed for broadcast, service provider, satellite, and enterprise organizations, DocumentHub eliminates the need for fragmented file storage solutions across multiple applications. It centralizes all document workflows while allowing IT teams to maintain control over security, compliance, and storage backend selection.

![DocumentHub centralized file management](~/solutions/images/DocumentHub.svg)

## DocumentHub application

DataMiner DocumentHub is available in the [Catalog](https://catalog.dataminer.services/details/f9720b2e-fdaa-4956-9788-877328b587ca) as a package containing a comprehensive low-code application. The solution integrates seamlessly with other DataMiner applications and provides an NuGet API for custom application development.

<div class="row">
  <div class="column">
    <a href="/solutions/standard_solutions/DocumentHub/Apps/DH_Application.html" title="DocumentHub app" target="_self">
      <img src="~/solutions/images/DocumentHub_App_Logo.png" style="width:100%">
    </a>
    <p>
      <em>DocumentHub Application</em>
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
> - Before you deploy the DocumentHub package, review the [installation instructions](xref:DH_Installation).
> - Developers integrating DocumentHub with custom applications should refer to the [DocumentHub DevPack](xref:DH_Development) documentation.
> - For details about the changes introduced in each DocumentHub version, refer to the [release notes](xref:DocumentHub_RNs_index).

## Who can benefit from DocumentHub?

DocumentHub serves diverse user groups across your organization:

- **IT and Security Teams**: Implement centralized document management with control over storage backends, access credentials, file format restrictions, and compliance policies. Support customer-managed SharePoint or on-premises storage options like DataMiner Webfiles or DOM Attachments.

- **System Administrators**: Configure document buckets for file grouping with file upload limitations, storage locations, and file extension rules.

- **Content and Asset Managers**: Streamline workflows for organizing and retrieving documents across the organization. Normalize graphics formats for consistency and for automated processing.

- **Application Developers**: Integrate DocumentHub capabilities into custom DataMiner low-code applications using the NuGet API. Retrieve file information, upload documents, and manage buckets programmatically.

- **Business Operations Teams**: Access documents from within operational applications such as People & Organizations, Asset Manager, and Scheduling. Attach job documents, profile images, asset photos, and service icons without leaving the application context.

In essence, DocumentHub enables organizations to deliver better service quality, reduce fragmentation in document workflows, respond faster to business needs, and maintain compliance through centralized, secure file management.

## What can you do with DocumentHub?

The DocumentHub Solution simplifies document and file management across your DataMiner ecosystem. The solution provides a [ready-made application](xref:DH_Application) that can be extended with custom workflows and integrations. It can also be extended with automation scripts and user-defined APIs to integrate with your existing systems.

DocumentHub supports the following capabilities by default without any customization:

- **Upload and Store**: Upload new documents, images, and files from user terminals to configured storage backends (SharePoint, local DataMiner Web Server, and DOM attachments).

- **Link and Reference**: Store file references and URLs in DataMiner DOM objects and applications. Link documents to jobs, assets, contacts, and other business entities.

- **Search and Navigate**: Discover documents by name and buckets. Browse and organize files through a unified interface regardless of storage location.

- **Read and Display**: View and open documents in third-party applications. Support common file types including jpg, png, gif, svg, pdf, docx, xlsx, and pptx.

- **Normalize and Format**: Apply format conversion and normalization to graphics files at ingest to ensure consistency across standard solutions.

- **Organize with Buckets**: Create predefined document buckets to streamline workflow. Specify target platforms, allowed file extensions, and file size limits for each bucket.

- **Integrate with APIs**: Use the DocumentHub NuGet package to develop custom integrations. Retrieve file information, manage buckets, and upload documents programmatically.

Example use cases:

- **People and Organizations**: Profile photos and contact avatars for team members and external contacts.
- **Asset Management**: Front and rear panel images of infrastructure assets, racks, and equipment.
- **Service and Channel Management**: Service icons, channel logos, and branding assets.
- **Scheduling and Jobs**: PDF job sheets, contracts, and task documentation.
- **Cost and Billing**: Generated invoices, cost reports, and financial documents.
- **Energy and Utilities**: Equipment documentation, compliance certificates, and facility plans.
- **Fleet Management**: Vehicle documentation, maintenance records, and operational photos.

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