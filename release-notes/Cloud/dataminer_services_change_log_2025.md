---
uid: dataminer_services_change_log_2025
---

# dataminer.services change log - 2025

The dataminer.services platform gets updated continuously. This change log can help you trace when specific features and changes have become available in 2025.

> [!NOTE]
> Many features on dataminer.services are dependent on DxMs. You can find the change logs for these under [DxM release notes](xref:DxM_RNs_index).

### 05 May 2025 - 5 May 2025 - Enhancement - Catalog - Deletion of items by publishing organization [ID 42793]

Users who are part of the publishing organization are able to delete a catalog item, providing a reason why.

### 05 May 2025 - Fix - Usage Export - Selected DMSs not respected during export [ID 42865]

Previously, export requests in the admin app ignored the DMSs selected by the user and exported all available data instead. This issue has been resolved. Export results are now correctly limited to the selected DMSs.

### 05 May 2025 - New feature - Single sign-on for Catalog, Admin, and Shares [ID 42768] [ID 42789]

Single sign-on (SSO) has been implemented across the Catalog, Admin, and Shares apps on dataminer.services. Users who sign in to one of these applications will now be automatically signed in to the others, providing a more seamless user experience.

### 28 April 2025 - Fix - Usage API - Performance and stability improvements [ID 42791]

It was possible that an export request failed with an out of memory exception. This has been fixed.

In addition, retrieving usage data to display in the Admin app resulted in a timeout when a large amount of data had to be retrieved. Query performance has been improved to prevent this.

### 22 April 2025 - Fix - Catalog - Incorrect vendor name shown [ID 42769]

In some cases, it could occur that the wrong vendor name was shown.

### 22 April 2025 - Enhancement - Catalog - 'Back' button removed from details pages [ID 42734]

As the "Back" button on the details page of a Catalog item had no real value, it has been removed.

### 22 April 2025 - Enhancement - Catalog - Browse page optimization [ID 42673]

Optimizations have been implemented on the Catalog browse page to prevent the page from becoming unresponsive when new items are loaded.

### 1 April 2025 - New feature - Catalog API - Ability to retrieve vendors [ID 42633]

It is now possible to retrieve vendors using the public Catalog API. For the full API reference, go to [Public Catalog API Swagger](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/index.html?urls.primaryName=Public+Catalog+API+v2.0).

The ID of a vendor can (optionally) be used to set the vendor for a Catalog item using any existing create, register, or update Catalog API call. For the full API reference, go to [Key Catalog API Swagger](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/index.html?urls.primaryName=Key+Catalog+API+v2.0).

### 13 March 2025 - Enhancement - Admin - Tooltips for long node names [ID 42510]

In the Admin app, on the overview page for a DataMiner System, tooltips will now be shown for the titles of nodes in case these are too long to be displayed. Previously, long names were clipped, causing users to be unable to see the last part of the names.

### 13 March 2025 - Enhancement - Improved initial loading of dataminer.services applications [ID 42510] [ID 42476]

The initial load times of applications under .dataminer.services have been improved. This has been done by enabling gzip compression and enabling caching of fonts with the .woff and .woff2 extension. The font files have also been updated to leave a smaller footprint.

### 11 March 2025 - Fix - Catalog - Deployment on multiple DataMiner Systems at once not working correctly [ID 42474]

Up to now, if a Catalog item was deployed to multiple systems at once, only the last deployment was executed and the others were canceled. This will no longer occur.

### 11 March 2025 - Enhancement - Catalog - Context menu on version and ranges hidden when not authenticated [ID 42459]

When a user is not authenticated, they will now no longer be able to see the button to open the actions for a version or range in the Catalog.

### 11 March 2025 - Fix - Catalog - Incorrect Deploy button state when not authenticated [ID 42439]

Previously, the *Deploy* button for a Catalog item version was always enabled when the user was not authenticated, even if the version had issues. This occurred because certain checks could not be performed when the user was not logged in yet. This issue has now been resolved. The *Deploy* button will now be correctly disabled if there are any issues with the version, regardless of authentication status.

Note that in case the button is displayed as enabled while a user is not logged in, it may still be disabled again after they log in case further issues are detected, such as the absence of a working DMS connected to dataminer.services.

### 11 March 2025 - Enhancement - Catalog - Ranges displayed for all items [ID 42426]

The Catalog now displays version ranges for all item types. Previously, ranges were only displayed for connectors. A range is created when a version ID follows a semantic format (e.g. x.x.x.x or x.x.x). Other versions are grouped under *other*.

### 11 March 2025 - Fix - Catalog API - Different recommended versions shown depending on API used [ID 42464]

Up to now, it could occur that different recommended versions were shown based on which API was called. Now the different Catalog APIs (key, user, and public) use a shared logic to determine the recommended versions for a Catalog item, so this will no longer occur.

### 7 March 2025 - Fix - Incorrect DataMiner System status on dataminer.services home page [ID 42445]

The status of DataMiner Systems (including DaaS systems) could be shown as "unknown" for users with the "Member" role in the organization. This also resulted in an incorrect status being shown for a newly deployed DaaS system. This issue has been resolved.

### 7 March 2025 - Fix - Connection to dataminer.services lost after using 10.4 installer [ID 42430]

If the DataMiner 10.4 installer was used to install a DataMiner Agent and connect it to dataminer.services, it could occur that the specified credentials did not allow the connection to dataminer.services and STaaS to be renewed, causing it to eventually be lost.

### 7 March 2025 - Fix - Admin - Export of large amount of usage data failed [ID 42378]

In the Admin app, exporting usage data to a CSV file could fail when there was a large amount of data to be retrieved. The performance of the export has been improved, and it will now be able to handle large amounts of data.

### 6 March 2025 - Fix - Catalog - Deployment status information not updated correctly [ID 42405]

When an item was deployed from the Catalog, it could occur that the status of the deployment was not updated correctly, showing that the deployment was still pending even though this was no longer the case. To resolve this issue, the duration for checking the status of the active deployment has been increased to around 5 minutes, while before this was only 10 seconds. If the deployment is still pending after a certain amount of polling tries, this will result in a timeout state.

### 6 March 2025 - Fix - Catalog API - Incorrect sorting of Catalog items by name [ID 42398]

When new items were registered in the Catalog, a property used for sorting was not set correctly. As a consequence, when you sorted by name in ascending order, all new items were shown at the top. This issue has been resolved.

### 6 March 2025 - Fix - Admin - Settings page state incorrect when switching to other DMS [ID 42338]

When a setting on the DMS settings page was changed in the Admin app, the relevant section went into edit mode, allowing the user to save the changes. However, if the user then opened another DMS settings page, the edit state of the page was not reset, resulting in edit mode actions being displayed while this should not be the case. This issue has been resolved.

### 6 March 2025 - Enhancement - Catalog API - Public endpoint added to check if version can be deployed [ID 42415]

You can now check whether a version can be deployed without logging in, using the "can-deploy" endpoint on the public controller.

### 6 March 2025 - Enhancement - Catalog - Improved message in case no description is available for a Catalog item [ID 42342]

In case no description has been added for a Catalog item, the displayed message to inform the user of this has been improved.

### 25 February 2025 - Fix - Catalog - Search results of Catalog showed non-user-friendly name instead of display name [ID 42347]

Up to now, it could occur that the results of a Catalog search showed the non-user-friendly name of an item instead of the display name.

### 25 February 2025 - Fix - Catalog - Duplicate owners [ID 42346]

In some cases, when a Catalog object was retrieved, duplicate owners could be returned. In addition, when a Catalog item was registered, it was possible to specify an owner in the manifest that was not unique, even though owners should always be unique. These issues have been resolved.

### 24 February 2025 - New feature - Catalog API - Public call to get all types [ID 42340]

A new call is available that allows users to get all the Catalog item types without the need to authenticate. For the full API reference, go to [Public Catalog API Swagger](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/index.html?urls.primaryName=Public+Catalog+API+v2.0).

### 20 February 2025 - Fix - Catalog - Deploy button not shown when switching pages [ID 42317]

When a user quickly switched to the *Versions* page, it could occur that the *Deploy* button incorrectly was not shown.

### 20 February 2025 - Fix - Catalog - Vendor logo not shown correctly [ID 42295]

When the image for a vendor logo could not be shown, it could occur that instead the "Vendor logo" alt text was shown. Now it will instead correctly fall back to the default icon, and the loading state of the image has also been improved.

### 20 February 2025 - Fix - Catalog - Problem viewing unsupported versions in case no supported versions were available for a Catalog item [ID 42254]

On the *Versions* tab of a Catalog item, it could occur that it was not possible to view unsupported versions in case no supported versions were available.

### 20 February 2025 - Enhancement - DataMiner.services - Home app now accessible without login + improved authentication flow [ID 42246]

Users now no longer need to log in to view the home app. A default view will be loaded in that case. The deploy page will still require authentication.

In addition, when something goes wrong during the authentication flow, users will now see a message instead of being redirected to the login.

### 20 February 2025 - Fix - Catalog - Problem with sorting on type on the Browse page [ID 42242]

Because of a possible problem with the sorting on type of the Browse page, this option has now temporarily been removed.

### 20 February 2025 - Fix - Catalog - IndexOutOfBoundsException when retrieving recommended versions [ID 42237]

In some cases, calls to retrieve the recommended versions of Catalog items could result in an IndexOutOfBoundsException.

### 20 February 2025 - Enhancement - Catalog - Removal of private versions [ID 42084] [ID 42243]

It is now no longer possible to have private versions of Catalog items. While a Catalog item itself can still be private, it is no longer possible to have specific versions of an item that are private.

Consequently, versions can no longer have the *IsPublished* property, and, in the User Catalog API, the `/api/user/catalog/v2-0/catalogs/connectors/publishing-state` call is now considered obsolete and the `/api/user/catalog/v2-0/catalogs/{catalogId}/versions/{versionId}/publishing-state` call is no longer available.

### 18 February 2025 - Fix - Incorrect DMS status for systems with large DataMiner version history [ID 42301]

If a DataMiner System had a large version history, it could occur that its system status could not be offloaded. To prevent this issue, now only the last 10 DataMiner versions are offloaded.

### 11 February 2025 - Enhancement - Catalog - Deployment status shown on details page [ID 42131]

When an item is deployed, the deployment status is now shown next to the *Deploy* button both in the item version section and at the top of the details page. The status is automatically updated for up to 10 seconds, and you will get a notification when the deployment finishes or fails.

### 11 February 2025 - Fix - Share Management - Incorrect message after sharing dashboard [ID 42121]

When a dashboard was shared, the incorrect message "A share has been updated" was shown instead of the message "Item has successfully been shared.". This issue has been resolved.

### 11 February 2025 - Enhancement - Catalog - New version statuses [ID 42078]

The Catalog now uses the following statuses for versions:

- **Pre-release** (previously "development")
- **Stable** (previously "active")
- **Unlisted** (previously "known issues" or "deprecated")

### 6 February 2025 - Fix - Random failures when sharing, deploying DxMs or Catalog items, or using the DataMiner Teams bot [ID 42178]

The Remote Access and Live Sharing performance and stability improvements released on the 4th of February introduced a specific issue that only occurred if a CloudGateway version older than 2.17.0 was restarted or updated. The issue could cause random failures while creating or updating shares, deploying DxM updates from the Admin app, deploying Catalog items, or using the DataMiner Teams Bot. This issue has now been resolved with immediate effect.

### 4 February 2025 - Enhancement - Remote Access and Live Sharing performance and stability improvements [ID 42129]

Several enhancements were made to improve performance and stability for all Remote Access and Live Sharing features with immediate effect.

In addition, dataminer.services now supports the creation of multiple connections instead of one by CloudGateway version 2.17.0 or higher, to increase throughput and stability even further.

### 4 February 2025 - Enhancement - Catalog - Deployment messages now contain Catalog item type [ID 41766]

When a Catalog item is deployed, the deployment info message will now contain the type of the Catalog item.

### 30 January 2025 - Enhancement - Admin - Usage page improvements [ID 42054]

In the Admin app, the tabs and sections of the Usage page have been reordered to allow better navigation. Improvements for smaller devices have also been implemented.

### 30 January 2025 - Enhancement - Catalog - Category icons [ID 42051]

Catalog items now show category icons when no vendor logo or image is available. The category icon is also shown on the browse page with the type filters.

### 30 January 2025 - Enhancement - Catalog API - API calls returning Catalog items will now include the CategoryId property [ID 42044]

API calls that return one or more Catalog items will now include the *CategoryId* property.

### 30 January 2025 - Enhancement - Catalog - Auto-login for returning users [ID 42041]

Users of the Catalog app who were logged in previously will now be automatically logged back in, even if their session has expired.

### 30 January 2025 - New feature - Catalog - Notification when new app version is available + support for installation as PWA [ID 42036]

The Catalog app will now notify you when a new version is available. In addition, it can now be installed as a Progressive Web App (PWA).

### 30 January 2025 - Fix - Catalog - Query parameters shown incorrectly [ID 42035]

Previously, it could occur that query parameters were shown in the Catalog app when they were not needed. Now query parameters will only be added on the browse page and only if you configure any filter or sorting.

### 30 January 2025 - New feature - Admin - DaaS usage [ID 42030]

You can now view your DaaS usage directly on the Usage page in the Admin app and export it.

### 30 January 2025 - Enhancement - Admin - Deployments - Duplicate load calls prevented [ID 41989]

The efficiency of the Deployments page in the Admin app has been improved. Previously, this page would make unnecessary duplicate calls to load the data.

### 29 January 2025 - Fix - Rollback of Remote Access and Live Sharing performance and stability improvements [ID 42087]

The Remote Access and Live Sharing performance and stability improvements released on the 27th of January were rolled back because of an issue found in combination with CloudGateway 2.16.0 - 2.17.1. The issue has been fixed in [CloudGateway 2.17.2 - Reconnect banner shows up all the time during remote accessing](xref:cloudgateway_change_log#30-january-2025---fix---cloudgateway-2172---reconnect-banner-continually-showing-when-remote-access-is-used-id-42086).

We strongly recommend updating to CloudGateway 2.17.2 as soon as possible to prevent issues when these improvements are introduced again.

### 28 January 2025 - New feature - Catalog API - Deploying a Catalog item using an organization key [ID 41987]

You can now use the Catalog API to deploy a Catalog item to a system connected to dataminer.services using an organization key.

### 28 January 2025 - Fix - Catalog API - Registration failed because of invalid artifact references in Catalog item versions [ID 41985]

A Catalog registration call could fail because existing Catalog item versions had invalid artifact references.

### 27 January 2025 - Enhancement - Remote Access and Live Sharing performance and stability improvements [ID 42043]

Several enhancements were made to improve performance and stability for all Remote Access and Live Sharing features with immediate effect.

In addition, dataminer.services now supports the creation of multiple connections instead of one by CloudGateway version 2.17.0 or higher, to increase throughput and stability even further.

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

### 15 January 2025 - Fix - Catalog API - Optional arguments for Catalog registration request incorrectly considered mandatory [ID 41788]

When a Catalog item was registered, optional properties in the manifest were incorrectly also considered mandatory for the registration to succeed. Now it will be possible to leave out optional properties in the manifest.

### 13 January 2025 - Fix - Rollback of Remote Access and Live Sharing performance and stability improvements [ID 42042]

The Remote Access and Live Sharing performance and stability improvements released on the 9th of January were rolled back because of issues found in the release.

### 9 January 2025 - Enhancement - Remote Access and Live Sharing performance and stability improvements [ID 41897]

Several enhancements were made to improve performance and stability for all Remote Access and Live Sharing features with immediate effect.

In addition, dataminer.services now supports the creation of multiple connections instead of one by CloudGateway version 2.17.0 or higher, to increase throughput and stability even further.
