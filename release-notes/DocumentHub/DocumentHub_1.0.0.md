---
uid: DocumentHub_1.0.0
---

# DocumentHub 1.0.0 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

## Prerequisites

> [!NOTE]
> This version requires:
>
> - DataMiner 10.6.5 or higher
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.x or higher

## New features

### DocumentHub: Initial functionality [ID 45528]

The new DocumentHub application gives your team a central place to organize and access documents directly within the DataMiner platform. This initial version includes:

- **Document buckets**: Create and manage named storage areas (called "buckets") to keep your documents organized. Each bucket can have:
  - A name and description
  - An upload path
  - Allowed file types (e.g., only PDFs or images)
  - An optional file size limit
- **File uploads**: Upload files directly from within DataMiner to your storage of choice. Three storage types are supported:
  - **SharePoint**: Store documents in your organization's Microsoft SharePoint environment.
  - **Local DataMiner**: Store documents on the DataMiner server.
  - **DOM attachments**: Attach files directly to native DataMiner Object Model records.
- **Creation, editing, and deletion of buckets**: A guided on-screen form lets you set up or update a bucket in just a few steps, with instant validation to prevent mistakes.
- **Browsing and querying of files**: Files stored in DocumentHub can be queried and displayed in DataMiner dashboards and low-code apps.
