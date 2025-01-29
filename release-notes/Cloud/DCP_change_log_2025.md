---
uid: DCP_change_log_2025
---

# dataminer.services change log - 2025

The dataminer.services platform gets updated continuously. This change log can help you trace when specific features and changes have become available in 2025.

> [!NOTE]
> Many features on dataminer.services are dependent on DxMs. You can find the change logs for these under [DxM release notes](xref:DxM_RNs_index).

### 28 January 2025 - New feature - Catalog API - Deploying a Catalog item using an organization key [ID 41987]

You can now use the Catalog API to deploy a Catalog item to a system connected to dataminer.services using an organization key.

### 28 January 2025 - Fix - Catalog API - Registration failed because of invalid artifact references in Catalog item versions [ID 41985]

A Catalog registration call could fail because existing Catalog item versions had invalid artifact references.

### 27 January 2025 - Enhancement - Remote Access performance and stability improvements [ID 42043]

Several enhancements were made to improve performance and stability for all remote access features with immediate effect.

In addition, dataminer.services now supports the creation of multiple connections instead of one by CloudGateway version 2.17.0 or higher, to increase throughput and stability even further. CloudGateway will be able to benefit from this change as soon as the 2.17.0 version is released (expected soon).

### 27 January 2025 - Enhancement - Admin app - Collaboration category added on usage overview page [ID 41947]

A new "Managed Object" category has been added to the usage overview page in the Admin app.

### 27 January 2025 - New feature - Admin - Usage charts [ID 41937]

Two pie charts have been added to the usage page in the Admin app. These pie charts visualize the usage data by system or feature.

Additionally, the filtering has been improved so that deleted systems can also be shown or hidden.

### 20 January 2025 - Enhancement - Catalog API - Enhanced scope of retrieving Catalog item using a key [ID 41977]

While previously the Catalog API only allowed users to retrieve information for Catalog items published by their own organization, now they can also retrieve information for any public Catalog item (using the organization key).

### 20 January 2025 - New feature - Catalog API - Retrieving Catalog item versions using a key [ID 41941]

It is now possible to obtain version information for a Catalog item using an organization key that has the "Read Catalog items" permission.

### 20 January 2025 - New feature - Catalog API - Rate Limiter when using organization key [ID 41940]

When the Catalog API is used with an organization key, the following rate-limiting policy is applied:

- Partition key: IP address or host name of connection
- Burst limit: 100 requests
- Long-term sustained request rate: 1 request every 36 seconds (100 request per hour)
- No queueing for extra requests beyond the token bucket

### 20 January 2025 - New feature - Catalog API - Downloading a Catalog item version using a key [ID 41892]

It is now possible to download a version of a Catalog item using an organization key that has the "Download Catalog" permission.

### 16 January 2025 - Enhancement - Sharing - Feedback button added to user menu [ID 41926]

A new button has been added to the user menu of the Sharing page, allowing users to provide Skyline with feedback on its apps.

### 16 January 2025 - Enhancement - dataminer.services home page - Feedback button added to user menu [ID 41926]

A new button has been added to the user menu of the dataminer.services home page, allowing users to provide Skyline with feedback on its apps.

### 16 January 2025 - Enhancement - Admin app - Feedback button added to user menu [ID 41926]

A new button has been added to the user menu of the Admin app, allowing users to provide Skyline with feedback on its apps.

### 16 January 2025 - Enhancement - Admin app - Improved auditing of Catalog items and deployments [ID 41922]

All audit records related to Catalog items and their deployments will now show the type of the item in the details of the record.

### 16 January 2025 - Enhancement - Admin app - References to old cloud licensing removed [ID 41919]

Obsolete license info and license usage info has been removed from the organization overview in the Admin App. This information can now be tracked on the usage page (see [[ID 41918]](#16-january-2025---enhancement---admin-app---collaboration-category-added-on-usage-overview-page-id-41918)).

### 16 January 2025 - Enhancement - Admin app - Collaboration category added on usage overview page [ID 41918]

A new "Collaboration" category has been added to the usage overview page in the Admin app. For now, only dashboard sharing is part of this category.

### 15 January 2025 - Enhancement - Catalog Api - Reduced loading time of Catalog type filters [ID 41734]

To improve the performance of requests to retrieve the Catalog item categories and types, a cache has been added. This will reduce the loading time of the type filters in the Catalog.

### 15 January 2025 - Enhancement - Catalog - Replaced banner image [ID 41731]

On the home page, the background banner image has now been replaced with a CSS gradient to reduce initial load times.

### 15 January 2025 - Enhancement - Catalog - Support added for smaller screens [ID 41690]

Support has been added for smaller screens, so that when you view the details page of a Catalog item on a smaller screen, everything will now be displayed correctly. Actions other than the "Deploy" action will be grouped in a context menu in such a case.

### 15 January 2025 - Enhancement - Catalog Api - Small memory usage improvement [ID 41676]

An improvement has been implemented to reduce the amount of memory consumed when registering a Catalog item version.

### 15 January 2025 - Enhancement - Admin app - Catalog Key API auditing [ID 41667]

The following actions are now included in the Audit records accessible in the Admin app :

- Registration of a Catalog item using an organization key.
- Registration of a Catalog item version using an organization key.
- Retrieval of Catalog item info using an organization key.
- Updating of the publishing state of a Catalog item using an organization key.

### 15 January 2025 - Fix - Admin - Prevent sidebar pollution [ID 41594]

When you quickly switched between organizations in the Admin app, it could occur that duplicate items were shown in the sidebar.

### 15 January 2025 - Fix - Artifact Uploader - Uploading an item did not link it to the organization [ID 41587] [ID 41588]

When the Skyline.DataMiner.CICD.Tools.CatalogUpload tool was used, the uploaded Catalog item was incorrectly only available for Skyline Communications but not for the organization executing the upload. This issue has been resolved.

### 15 January 2025 - Enhancement - Catalog - Improved initial load times [ID 41573]

The number of required API calls to initially load the Catalog home page has been reduced, resulting in improved initial load times.

### 15 January 2025 - Enhancement - Catalog - Trusted source indicator [ID 41540]

On the browse page, Catalog items that are published by the selected organization or by Skyline Communications will now display a green indicator.

### 13 January 2025 - Fix - Rollback of Remote Access performance and stability improvements [ID 42042]

The Remote Access performance and stability improvements released on the 9th of January were rolled back because of issues found in the release.

### 9 January 2025 - Enhancement - Remote Access performance and stability improvements [ID 41897]

Several enhancements were made to improve performance and stability for all remote access features with immediate effect.

In addition, dataminer.services now supports the creation of multiple connections instead of one by CloudGateway version 2.17.0 or higher, to increase throughput and stability even further.
