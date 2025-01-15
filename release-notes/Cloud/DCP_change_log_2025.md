---
uid: DCP_change_log_2025
---

# dataminer.services change log - 2025

The dataminer.services platform gets updated continuously. This change log can help you trace when specific features and changes have become available in 2025.

> [!NOTE]
> Many features on dataminer.services are dependent on DxMs. You can find the change logs for these under [DxM release notes](xref:DxM_RNs_index).

### 15 January 2025 - Enhancement - Catalog Api - Decrease loading time of Catalog type filters [ID 41734]

An improvement has been done to make requests to get the Catalog item categories and types more performant by adding a cache. This will reduce the loading times of obtaining the type filters in the Catalog.

### 15 January 2025 - Enhancement - Catalog - Replaced banner image [ID 41731]

On the homepage, the background banner image is now replaced with a CSS gradient to reduce initial load times.

### 15 January 2025 - Enhancement - Catalog - Actions should no longer clip outside their container [ID 41690]

On the details page of a Catalog item, actions should no longer clip outside the parent container.
Actions besides the 'Deploy' action will now be grouped in a context menu.

### 15 January 2025 - Enhancement - Catalog Api - Small memory usage improvement [ID 41676]

An improvement has been done to reduce the amount of memory consumed when registering a Catalog item version.

### 15 January 2025 - Enhancement - Admin app - Catalog Key API auditing [ID 41667]

The following actions are now included in the Audit records accessible in the Admin app :

- registration of a Catalog item using an organization key
- registration of a Catalog item version using an organization key
- get Catalog item info using an organization key
- update the publishing state of a Catalog item using an organization key

### 15 January 2025 - Fix - Admin - Prevent sidebar pollution [ID 41594]

When quickly switching organizations, it should no longer create duplicate items in the sidebar.

### 15 January 2025 - Fix - Artifact Uploader - Uploading an item did not link it to organization [ID 41587] [ID 41588]

when using the Skyline.DataMiner.CICD.Tools.CatalogUpload tool, the catalog item would be available for Skyline Communications but not for the organization executing the upload.
This has been fixed.

### 15 January 2025 - Enhancement - Catalog - Improved initial load times [ID 41573]

Initial load times of the Catalog homepage have been improved by reducing the amount of required API calls.

### 15 January 2025 - Enhancement - Catalog - Trusted source indicator [ID 41540]

On the browse page, Catalog items that are published by your selected organization or by Skyline Communications will now display a green indicator.

### 9 January 2025 - Enhancement - Remote Access performance and stability improvements [ID 41897]

Several enhancements were made to improve performance and stability for all remote access features with immediate effect.

In addition, dataminer.services now supports the creation of multiple connections instead of one by CloudGateway version 2.17.0 or higher, to increase throughput and stability even further. CloudGateway will be able to benefit from this change as soon as the 2.17.0 version is released (expected soon).
