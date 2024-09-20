---
uid: DCP_change_log
---

# dataminer.services change log

The dataminer.services platform gets updated continuously. This change log can help you trace when specific features and changes have become available.

> [!NOTE]
> Many features on dataminer.services are dependent on DxMs. You can find the change logs for these under [DxM release notes](xref:DxM_RNs_index).

#### 20 September 2024 - Fix - Catalog - Incorrect description shown for Catalog item for an authenticated user [ID 40825]

When a Catalog item uses the same name as another connector Catalog item that was not registered via the Catalog API, the wrong description could be shown when viewing the item as an authenticated user.

#### 20 September 2024 - Fix - Catalog - Duplicate Catalog items [ID 40839]

A duplicate Catalog item could be introduced in the Catalog after using the register item call from the Catalog API on an existing item that was not originally registered via the Catalog API. 

#### 17 September 2024 - Enhancement - Admin - Improved message when no usage data is found [ID 40796]

Improved the message when no usage data is available yet for a given organization.

#### 17 September 2024 - Fix - Remote Access (automatic) login not working with special characters in DataMiner account configuration [ID 40788]

If your DataMiner account contained one or more special characters, for example in the full name field, and you used Remote Access to the web apps (e.g. the Monitoring app via dataminer.services), it was not possible to log in or make use of the automatic login with a linked account. This has now been fixed.

#### 17 September 2024 - New feature - Admin - STaaS region registration and configuration tile [ID 40786]

It is now possible to register your DataMiner System for STaaS through the Admin app.

#### 17 September 2024 - Fix - Admin - Incorrect notation usage number [ID 40781]

The notation of the number 400,000 has been changed from 0,4M to 400K.

#### 17 September 2024 - Fix - Caching issues index file dataminer.services web apps [ID 40777]

It could occur that an old version of the site was shown when a newer version was available. To prevent this, caching headers for dataminer.services web apps have been adjusted to avoid caching when a new version is available.

#### 17 September 2024 - Enhancement - Catalog - Catalog registration now only possible via API [ID 40772]

It is now no longer possible to register Catalog items using the Catalog app. Registration should be done using the Catalog API instead. For detailed information, see [Registering a Catalog item](xref:Register_Catalog_Item).

#### 17 September 2024 - Enhancement - Admin - 'Install latest available upgrades' button removed [ID 40768]

In the Admin app, the button to install all available DxM updates at once for a node is no longer available. As its functionality could be inconsistent, an improved version of the feature will be introduced in a later UI update for this page.

#### 16 September 2024 - Fix - Catalog - Incorrect description shown for Catalog item [ID 40771]

In case a connector Catalog item existed in the Catalog with the same name as another connector Catalog item, and that other item had a description available, it could occur that the description for the other item was shown for the first item.

#### 16 September 2024 - Fix - Catalog - Unauthenticated access not showing Catalog description [ID 40770]

When a user was not logged in, it could occur that they could not view the description for a public Catalog item that was registered using the Catalog API.

#### 16 September 2024 - Fix - Catalog - Unauthenticated access not showing recommended versions [ID 40764]

Users were unable to view recommended versions when not logged into the Catalog.

#### 16 September 2024 - Enhancement - Admin - Organization keys now require at least one permission [ID 40596]

When you create an organization key, you now need to assign at least one permission to it.

#### 12 September 2024 - Fix - Catalog API - Unable to change publishing state for a specific version of a Catalog item [ID 40710]

Users were unable to change the publishing state for a specific version of a Catalog item through the API.

#### 12 September 2024 - Enhancement - Catalog API - Catalog registration API has been improved [ID 40670]

The previously available Catalog API call to register a new Catalog item or version using the manifest file has now been split up into two different calls. There is now a PUT call available to register/update an item (including its description) and a POST call to register a new version.

#### 12 September 2024 - Enhancement - Catalog - Catalog item versions with no artifact available on dataminer.services will contain a message [ID 40616]

When a Catalog item version is not available to deploy because its installation file is not registered, a message will now be shown to the user to inform them that the version is not available and that they can contact <support.cloud.ecosystem@skyline.be> to make it available.

#### 12 September 2024 - New feature - Catalog - Unauthenticated access [ID 40570] [ID 40571] [ID 40572] [ID 40573] [ID 40686]

As an unauthenticated user, you can now search through the publicly available Catalog items, and view their description and their available versions.

#### 12 September 2024 - New feature - Catalog API - Catalog registration supports images in description readme file [ID 40219]

Catalog item registration now supports images in the provided description of the Catalog item. Any used images need to be included in a *Images* directory. Supported image formats are .jpg, .jpeg, .png, .gif, .bmp, .tif, .tiff, and .webp.

#### 30 August 2024 - Enhancement - Catalog - Type filter documentation link [ID 40601]

When you search for an item in the Catalog, a documentation link will now be shown next to the type filter. This link will navigate to the Catalog types information on DataMiner Docs.

#### 30 August 2024 - Enhancement - Catalog - Owners or source no longer shown in details page side panel when not defined [ID 40584]

On the details page of a Catalog item, the side panel will no longer show the owners and source section if the owners or source are not defined.

#### 30 August 2024 - Fix - Catalog - Search overlay on Catalog details not closing [ID 40533]

When you searched for a Catalog item while on a Catalog details page, it could occur that the search overlay did not close when the search results were loaded.

#### 30 August 2024 - Enhancement - Admin - Improved restrictions for user role changes [ID 40526]

In the Admin app, users who do not have the rights to change roles will now no longer be able to select other user roles.

In addition, if you change your own role to a role with fewer rights, a warning will now be shown.

#### 30 August 2024 - Enhancement - Admin - DxM .NET 8 warning when installing DataAggregator 3.0.6 [ID 40478]

When you install the DataAggregator DxM version 3.0.6, a warning will now be shown that .NET 8 is required.

#### 30 August 2024 - Fix - Catalog - Organization field not filled in when registering item [ID 40472]

Up to now, when a user switched organizations prior to registering an item, the organization field would not be filled in. This has now been fixed, so that the organization field is now always filled in based on the selected organization.

#### 16 August 2024 - Fix - Admin - Not possible to remove users from organization [ID 40506]

It could occur that it was not possible to remove users from their organization in the Admin app even though you had the necessary rights to do so.

#### 16 August 2024 - Enhancement - Admin - DxM upgrade .NET 8 warning [ID 40461]

When you try to upgrade a DxM to a version that requires .NET 8, a warning will now be displayed.

#### 13 August 2024 - Enhancement - Admin - Adding new user now blocked when user does not comply with configured allowed email domains [ID 40459]

When you try to add a user to your organization in the Admin app, this will now only be possible if the user you add complies with the configured allowed email domains setting.

#### 13 August 2024 - Enhancement - Admin - Users overview now shows when users are non-compliant [ID 40469]

Users in an organization that do not comply with the configured allowed email domains setting will now be shown with a warning next to them, so that it is clear that these users were added before the allowed email domains setting was enforced.

#### 13 August 2024 - Fix - Catalog - Deployment issues pop-up window did not display DMS name correctly [ID 40470]

When you opened the deployment issues pop-up window, this did not correctly display the name of the DMS with the issue. Now the DMS name will be shown correctly.

#### 9 August 2024 - Enhancement - Admin - New options to restrict remote access to web apps and/or user-defined APIs based on IP address [ID 40460]

In the Admin app, it is now possible to restrict remote access to the web apps and/or user-defined APIs for a specific DMS based on IP address. Previously, this was only possible for the DataMiner Cube desktop app.

> [!TIP]
> See also: [Controlling the remote access settings of a DMS in your organization](xref:Controlling_remote_access#controlling-the-remote-access-settings-of-a-dms-in-your-organization)

### 08 August 2024 - Enhancement - Vendor and market name of connector now considered dedicated properties [ID 40423]

Up to now, the vendor and market name of a connector were among the tags of a Catalog item and therefore visible in the search results. This has been changed so that vendor and market name are properties that can be seen on the details page of a Catalog item.

### 08 August 2024 - New feature - Catalog - Case-insensitive searching on tags [ID 40368]

Search results on tags are now case insensitive.

### 08 August 2024 - New feature - Catalog - Search supports sorting by name and type of a Catalog item [ID 40368]

On the browse page, you can now sort by the name and type of the items in ascending or descending order. By default, items will be sorted by name in ascending order.

### 08 August 2024 - New feature - Limit of 5 tags implemented for Catalog items [ID 40349]

When you try to register a Catalog item with more than 5 tags, this will now fail, as this is not supported.

### 08 August 2024 - Enhancement - Catalog - Recommended versions shown for all Catalog item types [ID 40346]

Recommended versions are now shown for all Catalog item types. Previously, only connector Catalog items had a recommended version available.

#### 1 August 2024 - Enhancement - Catalog - Contributors have been renamed owners [ID 40378]

On the details page, "contributors" have now been renamed "owners".

#### 1 August 2024 - Fix - Catalog - Filters set on the browse page would incorrectly be reset when returning from a details page [ID 40332]

Up to now, when you had set filters in the browse page and then went to a details page, the filters would incorrectly get reset when you returned to the browse page. From now on, all filters will be restored when you return to the browse page.

#### 1 August 2024 - Fix - Cloud apps - White page was displayed when using an old browser [ID 40347]

When you were using an old browser (e.g. Microsoft Internet Explorer), a white page would be displayed due to JavaScript not loading correctly.

From now on, a notice will appear, saying that your browser is no longer supported and that you should use a newer one.

#### 1 August 2024 - Fix - Admin - Formatting of numbers under a thousand having a K suffix [ID 40383]

Smaller numbers will no longer be formatted with suffixes to improve readability. Previously, navigating to the usage page in Admin you could find numbers under the operation column to be formatted with the K suffix which would result in 0.x K formatting.

#### 1 August 2024 - Enhancement - New remote access setting to restrict remote Cube access based on IP addresses [ID 40288]

An enhancement has been made to the remote access settings in the Admin app, which allows you to restrict remote Cube access per DMS based on specified public IP addresses.

> [!TIP]
> See also: [Controlling the remote access settings of a DMS in your organization](xref:Controlling_remote_access#controlling-the-remote-access-settings-of-a-dms-in-your-organization)

#### 26 July 2024 - Enhancement - Admin - Formatting of large operation numbers in metric table [ID 40377]

Numbers in the usage table are now formatted with K, M, or B suffixes to improve readability.

#### 26 July 2024 - Enhancement - Catalog - Show documentation for all types [ID 40190]

Users can now view documentation for all items, if provided.

#### 23 July 2024 - Fix - Catalog - Return button spanning whole height of container [ID 40245]

The height of the return button in the top-left corner of the Catalog item details page has been adjusted. Previously, the button spanned the full height of the container. It is now sized to match the button itself.

#### 23 July 2024 - New Feature - Catalog - Catalog allows searching on Catalog tags [ID 40259]

It is now possible to search using Catalog tags. The list of all search results will display which tags are present on each Catalog item.

#### 23 July 2024 - New Feature - Catalog - Support for more Catalog types [ID 40144]

The following new Catalog types are now supported:

- Ad Hoc Data Source

- User-defined API

- Testing Solution

- Standard Solution

- Solution

- Scripted Connector

- SLA Model

- Sample Solution

- Profile-Load Script

- Low-Code App

- Life Cycle Service Orchestration

- Function Definition

- Enhanced Service Model

- Data Transformer

- Data Query

- Dashboard

- ChatOps Extension

- Best Practices Analyzer

These new Catalog types can now be selected when [registering a Catalog item](xref:Register_Catalog_Item) and have been added to the filters on the left of the search results page.

#### 23 July 2024 - Enhancement - Admin - Organization and DMS overview pages now display DMS type [ID 40123]

The Admin organization overview page and the DMS overview page now show the type of DMS you are running, indicating whether it is a DaaS or Self-hosted system.

#### 23 July 2024 - Enhancement - Admin - 'Add user' button disabled for users without permissions [ID 40234]

On the Admin organization users page, the *Add user* button will now be disabled if you do not have the appropriate permissions. Previously, attempting to add a user without the right permissions would result in an error.

#### 19 July 2024 - New feature - Catalog API - Catalog version registration allows inclusion of readme file [ID 40241]

It is now possible to include a readme.md file in the zip archive used to register a new version of a Catalog item. Images are not (yet) supported in the readme file.

#### 19 July 2024 - Fix - Catalog - Range without active versions shown [ID 40218]

Previously, if a range had no active versions, it was still shown on the details page of a Catalog item. Now such a range will no longer be shown.

#### 19 July 2024 - Enhancement - Catalog - Improved version loading [ID 40217]

A new caching mechanism has been introduced that will improve performance when the versions included in a range of a Catalog item are loaded.

#### 19 July 2024 - Fix - Catalog - Incorrect empty search result when initiated from home page [ID 40232]

When a search request was initiated from the home page of the DataMiner Catalog, an empty result was shown on the browse page until the page was reloaded. The correct search result will now be shown immediately.

#### 19 July 2024 - Enhancement - Catalog - Improved vendor logo loading [ID 40235]

Caching has been introduced for vendor logos, which will make Catalog search results load faster.

#### 15 July 2024 - Enhancement - Remote Cube support for SAML [ID 40176]

From now on, SAML can be used to access Cube remotely.

#### 12 July 2024 - New feature - Admin - Usage page to view STaaS consumption [ID 40172]

In the Admin app, a new *Usage* page is now available for users with the Admin or Owner role in an organization. This page shows information about the usage of the STaaS systems in the organization.

#### 12 July 2024 - Enhancement - Catalog - Infinite scroll [ID 40167]

​On the Catalog browse page, when users now scroll to the bottom of the page, a new page will load if there are more Catalog items to show.

#### 11 July 2024 - Enhancement - ChatOps - Notification summary [ID 40182]

A new version (1.2.5) of [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) has been released, which allows you to add a summary to Chat Integration notifications using Adaptive Cards. This summary will be used for the actual activity notification, so you can easily read what is going on from the summary without opening the notification itself. The summary will also be used for the immersive reader functionality in Microsoft Teams.

If the summary is not explicitly defined, the behavior will stay the same, and "Card" will be shown by default.

#### 11 July 2024 - Enhancement - Improved handling of timed out Remote Access and Live Sharing requests [ID 40173]

An enhancement has been done to the way timed out requests are handled when the web apps are accessed remotely or when Live Sharing is used.

#### 9 July 2024 - Enhancement - Home - Adding time zone when deploying a DaaS system [ID 40121]

When you deploy a DaaS system from the dataminer.services homepage, it is now possible to select the time zone for the DataMiner System you are deploying. By default, the current time zone of the browser is selected.

#### 9 July 2024 - Fix - Catalog - Main ranges incorrectly filtered out in version history [ID 40147]

If all ranges of a Catalog item were either labeled as main or as deprecated, in the version history on the details page of the Catalog item, the main range could incorrectly be filtered out when the unsupported versions were set not to be shown (with the *Unsupported versions* toggle button). Now the main range will be shown correctly in the version history.

#### 4 July 2024 - Enhancement - Remote Access, Remote Cube, and Live Sharing stability improvements [ID 40106]

An enhancement has been done to improve the stability when the web apps or Cube are accessed remotely or when live sharing is used.

#### 3 July 2024 - New feature - Catalog - Version 2 of the User Catalog API [ID 39839] [ID 39958] [ID 40034]

The User Catalog API has been updated to V2.

This version will include the following routes:

- **GET api/user-catalog/v2-0/catalogs/search** (UPDATED)

  Searches for Catalog items.

- **GET api/user-catalog/v2-0/catalogs/{catalogId}** (UPDATED)

  Fetches a Catalog item by ID.

- **GET api/user-catalog/v2-0/catalogs/{catalogId}/versions/{versionId}/download** (NEW)

  Downloads a specific version of a specific Catalog item.

- **GET api/user-catalog/v2-0/catalogs/{catalogId}/ranges?organizationId={organizationId}** (NEW)

  Fetches the ranges for a specific Catalog item.

- **PATCH api/user-catalog/v2-0/catalogs/{catalogId}/ranges/{rangeId}?organizationId={organizationId}/custom-tag** (NEW)

  Updates a custom tag of a specific range of a specific Catalog item.

- **DELETE api/user-catalog/v2-0/catalogs/{catalogId}/ranges/{rangeId}?organizationId={organizationId}/custom-tag** (NEW)

  Removes a custom tag of a specific range of a specific Catalog item.

- **GET api/user-catalog/v2-0/catalogs/{catalogId}/versions?organizationId={organizationId}&rangeId={rangeId}** (NEW)

  Fetches the versions for a specific Catalog item.

- **GET api/user-catalog/v2-0/catalogs/{catalogId}/versions/latest?organizationId={organizationId}** (NEW)

  Fetches the latest available version of a specific Catalog item.

- **GET api/user-catalog/v2-0/catalogs/{catalogId}/versions/recommended?organizationId={organizationId}** (NEW)

  Fetches the recommended versions of a specific Catalog item.

- **GET api/user-catalog/v2-0/catalogs/{catalogId}/versions/{versionId}/can-deploy?organizationId={organizationId}** (NEW)

  Verifies if a Catalog item version can be deployed.

- **GET api/user-catalog/v2-0/catalogs/{catalogId}/versions/{versionId}/can-deploy-dms?organizationId={organizationId}** (NEW)

  Verifies if a Catalog item version can be deployed on the available DataMiner Systems.

- **POST api/user-catalog/v2-0/catalogs/{catalogId}/ranges/versions/{versionId}/deploy** (UPDATED)

  Deploys a specific version of a specific Catalog item.

- **POST api/user-catalog/v2-0/catalogs/register**

  Registers a Catalog item.

- **PATCH api/user-catalog/v2-0/catalogs/{catalogId}/publishing-state?organizationId={organizationId}**

  Sets the publishing state of a Catalog item.

- **PATCH api/user-catalog/v2-0/catalogs/{catalogId}/version/{versionId}/publishing-state?organizationId={organizationId}**

  Sets the publishing state of a Catalog version.

- **PATCH api/user-catalog/v2-0/catalogs/{catalogId}/ranges/{rangeId}/state?organizationId={organizationId}**

  Sets the state of a specific range of a specific Catalog item.

- **PATCH api/user-catalog/v2-0/catalogs/{catalogId}/versions/{versionId}/state?organizationId={organizationId}**

  Sets the state of a specific version of a specific Catalog item.

#### 3 July 2024 - New feature - Catalog - Change state support [ID 40096]

Skyline employees will now be able to change the state of a range or version when they view an item in the Catalog.

#### 3 July 2024 - New feature - Catalog - Source link [ID 40046]

When you view an item in the Catalog, the informational section on the right will now contain a link to the source.

#### 3 July 2024 - New feature - Catalog - Custom tag support [ID 40030]

When you view an item in the Catalog, if you are a member of the organization that published the item, you will now be able to assign a custom tag to ranges.

#### 3 July 2024 - Enhancement - Home - Deploy prevention of DataMiner as a Service [ID 39995]

When you try to spin up a new DataMiner as a Service system from the dataminer.services home page, this will now be blocked if your organization does not have enough DataMiner credits available.

#### 3 July 2024 - New feature - Catalog - Version history [ID 39903]

When you view an item in the Catalog, the versions tab will now include a version history section. This section will by default show all supported ranges and versions.

A toggle button has also been introduced that allows you to show or hide unsupported ranges and versions. Active and main ranges are considered supported, while deprecated ranges are considered unsupported. For versions, released versions are considered supported, while versions marked as known issues, development, or deprecated are considered unsupported.

#### 3 July 2024 - New feature - Catalog - Version and range tag support [ID 39899]

In the Catalog, the versions and ranges shown when you view an item will now have tag support for the following cases:

- The state of a range.
- The state of a version.
- Whether a version is private.

#### 3 July 2024 - New feature - Catalog - Versions rework [ID 39846]

When you view a connector item in the Catalog, the *Versions* tab will now group all the versions by range. Ranges are defined by the first three numbers of a version.

#### 19 June 2024 - Fix - Remote Access and Live Sharing connection failing when DMA went offline [ID 39983]

Up to now, if the connected DMA that was used to serve the web API requests for Remote Access or Live Sharing went offline, e.g. when switching in a Failover setup, the connection did not switch to another online DMA in the DMS. Instead it kept trying to connect to the initial DMA even though it was offline, causing Remote Access or Live Sharing not to work until the browser cookies were cleared. This issue has now been resolved. Automatic login issues caused by this same issue have also been resolved.

#### 19 June 2024 - Fix - Remote access automatic login showed error page when failing [ID 39982]

When the automatic login with a user's linked DataMiner account failed, up to now a blue error page was shown displaying that there was an unexpected error. Now, the login page will be shown instead, where users can manually log in as a fallback.

#### 19 June 2024 - Fix - Catalog - Email of user not shown in user menu [ID 39960]

It could occur that the user's email could not be shown in the user menu of the Catalog. This issue has been resolved.

#### 19 June 2024 - Fix - Catalog - Selected organization not remembered across dataminer.services apps or after reloading the Catalog [ID 39913]

If an organization was selected in the Catalog app, it could occur that this selection was not remembered when the app was reloaded, and a different organization was selected again (usually, the first organization alphabetically). Similarly, when you switched from one dataminer.services app to another, the organization selection was not remembered.

Now the organization selection will be correctly saved and shared across apps or across app reloads.

#### 19 June 2024 - Enhancement - Catalog - Register catalog item moved to user menu [ID 39906]

The button to open the form in order to register a catalog item has been moved from the header to the user menu.

> [!NOTE]
> To be able to see the button, you need to be a member of at least one organization.

#### 19 June 2024 - Enhancement - Catalog - Documentation link shown after Catalog item is registered [ID 39904]

​After registering an item, users will now get a link to the documentation guiding them to the next step, i.e. uploading a version.

#### 11 June 2024 - Enhancement - Enable access to more web app folders via Remote Access [ID 39881]

From now on, if Remote Access to the web apps is enabled, this allows access to the entire folder `/Documents/`, so that it is possible to access the documents available in Cube. Previously, only the `/Documents/DMA_COMMON_DOCUMENTS/` folder was accessible.

#### 10 June 2024 - Fix - Link to terms and conditions not working [ID 39895]

The link to the terms and conditions, displayed among others when a DaaS system was registered and an Agent was connected to dataminer.services, did not work correctly. This has now been resolved.

#### 10 June 2024 - Enhancement - Admin - 'Nodes' page renamed to 'DxMs' [ID 39874]

In the Admin app, the *Nodes* page has been renamed to *DxMs* to be more in line with the actual functionality of the page.

#### 10 June 2024 - Fix - Admin - Zero credits not showing [ID 39866]

On the Admin organization overview page, it was not possible to see how many credits were left in case you had zero credits. Now the number of available credits will always be displayed, even if this is zero.

#### 10 June 2024 - Enhancement - Home - Password confirmation when deploying DaaS [ID 39865]

When you deploy a DaaS system, you will now be asked to confirm your password before can deploy the system.

#### 10 June 2024 - Fix - Admin - Opening in desktop app not working [ID 39838]

On the overview page of a DMS in the Admin app, the *Open in desktop app* button did not work correctly. Now Cube will correctly be opened when this button is clicked.

#### 7 June 2024 - Enhancement - ChatOps - Possibility to fetch the dataminer.services organization ID & DMS ID in Automation [ID 39878]

A new version (1.2.4) of [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) has been released, which allows you to fetch the dataminer.services organization ID and DMS ID.

These IDs, which had to be hardcoded before, can now be used for the buttons added in Adaptive Cards.

You can fetch them using the following example:

````cs
var chatIntegrationHelper = new ChatIntegrationHelperBuilder().Build();
try
{
  var dmsIdentity = chatIntegrationHelper.GetDataMinerServicesDmsIdentity();
  var organizationId = dmsIdentity.OrganizationId;
  var dmsId = dmsIdentity.DmsId;
}
finally
{
  chatIntegrationHelper?.Dispose();
}
````

The [ChatOps example scripts on GitHub](https://github.com/SkylineCommunications/ChatOps-Extensions) have been updated accordingly.

#### 30 May 2024 - Enhancement - Enable access to more web app folders via Remote Access [ID 39812]

From now on, if Remote Access to the web apps is enabled, this also allows access to the folder `/Documents/DMA_COMMON_DOCUMENTS/`, so that it is possible to access the documents available in Cube.

#### 30 May 2024 - Enhancement - Home - DaaS error messages [ID 39810]

The error messages that are displayed in case something goes wrong during the creation of a DaaS instance have been improved. Instead of a generic error, more specific information is now displayed.

#### 30 May 2024 - Fix - Catalog - Details page not loading [ID 39772]

When a user that was not associated with any organization directly accessed a details page in the Catalog, it could occur that this page did not load correctly.

#### 29 May 2024 - Fix - Admin - Email validation did not support domain extensions of more than 3 characters [ID 39791]

When adding a user to an organization or DMS in the Admin app, it was only possible to enter an email address with a domain extension of maximum 3 characters. This has now been updated so that all domain extensions are supported.

#### 29 May 2024 - Enhancement - Admin - DMS overview Failover pair offline status [ID 39694]

The DMS overview page will now correctly show a Failover Agent as offline when appropriate.

#### 29 May 2024 - Enhancement - New style for buttons in pop-up windows [ID 39010]

Buttons in pop-up windows have been updated to the new style.

#### 27 May 2024 - Enhancement - Catalog - Updated deploy pop-up message with new style [ID 39663]

When an item is deployed from the Catalog, a new pop-up component will now be shown. The pop-up component has a new style and includes the name of the artefact.

#### 27 May 2024 - Fix - All dataminer.services apps - Caching of index.html disabled [ID 39725]

Caching for the index page has been disabled for all dataminer.services apps, so that users will now always get the latest index page. As a result of this, the apps will be guaranteed to always have the latest code, since everything in the apps resolves to the index page.

#### 27 May 2024 - Enhancement - Admin - Audit filter [ID 39737]

The audit filter "Subject Type" will now correctly show options.

#### 23 May 2024 - Enhancement - ChatOps - Possibility to skip the confirmation when running custom commands [ID 39736]

From now on, it is possible to skip the confirmation message when running a custom command with the DataMiner Teams bot.

You can do so by adding `--skipconfirmation`, or in short `--sc`, at the end of your command. For example, for a custom command Automation script named "toggle switch", you could use the command `run toggle switch --sc`.

A new version of (1.2.3) [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) has also been released, which allows you to skip the confirmation on custom buttons in Adaptive Cards.

#### 16 May 2024 - Fix - Catalog - Legacy routes not resolved correctly [ID 39653]

When a user navigates to a legacy URL of the Catalog application, it will now redirect to the correct page.

#### 16 May 2024 - New feature - Catalog - New apps menu [ID 39621]

Clicking the logo in the top-left corner of the Catalog app will now open a new apps menu, which will allow users to easily navigate to the other dataminer.services apps.

#### 16 May 2024 - Enhancement - Admin - Message in DMS overview when latest CoreGateway version is not installed for Failover Agent [ID 39677] [ID 39678]

In the DMS overview in the Admin app, when applicable, a message will now be shown to notify the Admin user that both Agents in a Failover pair need to have the latest CoreGateway DxM version installed so that more information about Failover can be retrieved.

#### 16 May 2024 - Enhancement - Admin - Organization and DMS settings audits [ID 39669]

From now on, changing settings for an organization or DMS in the Admin app will generate audit logs. See [consulting dataminer.services audit logs](xref:DCP_Auditing).

#### 10 May 2024 - Enhancement - Admin - More information included in DMS overview [ID 39563]

The DMS overview now shows more information about the system, including DxM and connectivity information.

#### 8 May 2024 - Fix - Catalog - Maximum number of results too low when searching from home page [ID 39612]

When you executed a search on the home page, the results were incorrectly limited to 5 items only. Now when you click *View all results*, this will take you to the browse page where you will see a maximum of 50 results.

#### 7 May 2024 - Fix - Admin - Save button for settings available to users without write access [ID 39589]

In the Admin app, users who do not have write access will now no longer have access to the save functionality on the Organization and DataMiner System Settings pages.

#### 7 May 2024 - Fix - Catalog - Catalog item deployment window stayed open [ID 39575]

After a Catalog item is deployed, the deploy pop-up window will now correctly close automatically.

#### 7 May 2024 - Enhancement - Catalog - Improved Catalog item registration message [ID 39574]

When a new Catalog item is registered, the success pop-up message containing the ID of the item will now also briefly describe how you can use this ID.

#### 7 May 2024 - Enhancement - Catalog - Message added for private items without versions [ID 39521]

Private Catalog items that do not have any versions will now show an informative message.

#### 7 May 2024 - Fix - Catalog - Legacy routes not resolved correctly [ID 39377]

When a user navigates to a legacy URL of the Catalog application, it will now redirect to the correct page.

#### 25 April 2024 - Enhancement - Enable access to more web app folders via Remote Access [ID 39486]

From now on, if Remote Access to the web apps is enabled, this also allows access to the `/Webpages/SRM/` and `/Webpages/assets/` folders, which will be needed for future web app enhancements and features.

#### 25 April 2024 - Enhancement - Settings overhaul [ID 39471]

The dataminer.services settings, configurable from the Admin app, have been enhanced with the following improvements:

- Settings now have a hierarchical structure. Disabled parent settings override their child settings.
- Settings can now also be configured on organization level. If a setting is disabled on organization level, this overrides this same setting for all the DataMiner Systems of this organization, as well as its child settings.
- Settings are now displayed and managed from a separate page for the organization and for each DMS.
- A new setting has been added for Live Sharing (i.e. dashboard sharing).
- In addition to one global Remote Access setting, there are now separate child settings for remote access to Cube, the User-Defined APIs, and the web apps.

#### 25 April 2024 - Enhancement - Catalog - Show DMS issues when deploying a catalog item [ID 39374]

In case deploying a catalog item to a DataMiner System will fail, it will now no longer be possible for users to try to deploy the item to that system, and a documentation link will be shown so the users can resolve the issue.

#### 9 April 2024 - Enhancement - Improvements for DxM deployments from the Admin app [ID 39268]

When a user attempts to upgrade or install a DxM, a check is now performed to verify if all the system requirements are met. If missing requirements are detected, the action is disabled, and a warning is shown. Clicking the warning will show more information on how to resolve the issue.

#### 29 March 2024 - Enhancement - Admin DxM status [ID 39277]

On the nodes overview page in the Admin app, you can now see the status of the DxMs.

#### 28 March 2024 - Fix - Catalog - Typos in error when no DMS is found [ID 39232]

When no DMS is found for an organization, the displayed error will now no longer contain any typos.

#### 28 March 2024 - Enhancement - Admin - Adjusted visibility credits section organization overview [ID 39214]

Regular members of an organization will now no longer be able to see the credits section of the organization overview.

#### 28 March 2024 - New feature - Catalog - Trial deployments [ID 39205]

It is now possible for users without a license for a connector to deploy a trial version. These trial versions should not be used in production environments, as stated in the terms and agreements.

#### 28 March 2024 - Fix - Catalog - Links in organization overview not working correctly [ID 39204]

Links in the DataMiner Systems table of the organization overview will now correctly navigate to the right location.

#### 28 March 2024 - Enhancement - Catalog - Filter on public and/or private items [ID 39026]

On the *Browse* page of the Catalog, you can now filter catalog items so you see only public items, only private items, or both public and private items.

#### 28 March 2024 - Enhancement - Admin - Audit Organization Keys [ID 39023]

It is now possible for admin users to see the permissions of organization keys on the audit detail page.

#### 14 March 2024 - Admin - Organization overview overhaul [ID 38960]

The user interface of the Organization overview page has been adjusted to be more in line with upcoming design changes.

It will now include an overview of all DataMiner Systems in a table, which will include the name, URL, and status of each DataMiner System.

#### 14 March 2024 - Enhancement - Admin - Buttons overhaul [ID 39008]

The buttons of the Admin app have been adjusted to be more in line with upcoming design changes.

#### 11 March 2024 - Enhancement - Ordering DataMiner credits through Azure Marketplace [ID 38909]

You can now order DataMiner credits via the Azure Marketplace. For more information on how to order credits, refer to [Ordering DataMiner credits](xref:Order_DataMiner_credits).

#### 7 March 2024 - Enhancement - Connection status information on dataminer.services now refreshes automatically [ID 38933]

The connection status information is now updated every minute on dataminer.services.

#### 7 March 2024 - Enhancement - Improved support for DataMiner as a Service systems on dataminer.services [ID 38932] [ID 39009]

​The dataminer.services page now has an improved UI when a DataMiner as a Service (DaaS) system is being deployed, with an estimated time left. When a DaaS system is unreachable, an email address is provided to contact support. It is also possible to remove the system while it is still being deployed.

In addition, a problem has been resolved that caused some characters to be invalid in the password field in the deployment form.

#### 29 February 2024 - Enhancement - Admin app UI adjusted [ID 38908]

The header bar and sidebar of the [Admin app](https://admin.dataminer.services) now use a light theme.

#### 29 February 2024 - New feature - Admin - Added organization keys [ID 38944]

In the Admin app, you can now create DCP keys on organization level.

#### 21 February 2024 - Fix - Improved catalog search performance [ID 38865]

The [Catalog](https://catalog.dataminer.services) search has been enhanced to yield results faster.

#### 19 February 2024 - Enhancement - Custom commands executed with the DataMiner bot can request the dataminer.services user email [ID 38826]

It is now possible to know the executor of a custom command executed with the DataMiner bot in Microsoft Teams.

To add a command to your DMS, create an Automation script in the folder "bot" in the DMS. For examples of such scripts, refer to [Custom Command Examples](https://github.com/SkylineCommunications/ChatOps-Extensions/tree/main/CustomCommandExamples) on GitHub.

For more detailed information, refer to [Adding commands for the Teams bot to a DMS](xref:DataMiner_Teams_bot#adding-custom-commands-for-the-teams-bot-to-a-dms).

#### 16 February 2024 - Enhancement - Changed user role required to renew system tokens [ID 38722]

Previously, users had to have the role of Owner of the DMS on dataminer.services to be able to [renew the session](xref:Cloud_Connection_Issues#check-the-cloud-session). From now on, this is also possible for users who have the Admin role.

#### 16 February 2024 - Enhancement - Improved error messages when using remote access [ID 38802]

When you try to use remote access to a DataMiner System via dataminer.services, but this is not possible, from now on a clearer message will be shown on what is the likely cause of the issue, with a link to a dedicated troubleshooting page on docs.dataminer.services.

#### 14 February 2024 - Enhancement - Systems with remote access disabled are now shown on dataminer.services [ID 38772]

DataMiner Systems are now shown on dataminer.services even if remote access is disabled for them. However, the app buttons for such systems will be disabled where necessary. A link to the documentation is provided in the UI for more information about how to change the remote access settings.

#### 13 February 2024 - Fix - Catalog versions displayed in wrong order [ID 38762]

The versions of a catalog item will now be sorted correctly.

#### 9 February 2024 - Enhancement - DMS connection status now visible on dataminer.services [ID 38771]

On the dataminer.services page, you can now see the status of the connection of a DMS to dataminer.services. The status is indicated as *OK*, *Warning*, *Error*, or *Unknown*. If the connection is not available, the app buttons will be disabled.

#### 6 February 2024 - New feature - Chat Integration with Microsoft Teams now includes sending buttons in notifications using Adaptive Cards [ID 38701]

It is now possible to send buttons in notifications using Adaptive Cards to chats or channels with Chat Integration.

Available buttons:

- Prompt to run a custom command (optionally with predefined input values)
- Open URL
- Get element
- Get alarms of an element
- Get alarms of a view
- Prompt to change the active DMS of the conversation

In an Automation script, you can use [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) 1.2.1 to easily interact with Microsoft Teams.

To get started, you can find several example Automation scripts with more information on [GitHub](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples).

After you have made sure that the [prerequisites](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#usage) are in place, you can deploy [the Chat Integration examples](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#getting-started) to your DataMiner System and immediately try out these examples.

#### 6 February 2024 - New feature - Custom commands executed with the DataMiner bot now support adding buttons to the response using Adaptive Cards [ID 38701]

It is now possible to send buttons in custom command responses using Adaptive Cards.

Available buttons:

- Prompt to run a custom command (optionally with predefined input values)
- Open URL
- Get element
- Get alarms of an element
- Get alarms of a view
- Prompt to change the active DMS of the conversation

In an Automation script, you can use [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) 1.2.1 to easily interact with Microsoft Teams.

To add a command to your DMS, create an Automation script in the folder "bot" in the DMS. For examples of such scripts, refer to [Custom Command Examples](https://github.com/SkylineCommunications/ChatOps-Extensions/tree/main/CustomCommandExamples) on GitHub.

For more detailed information, refer to [Adding commands for the Teams bot to a DMS](xref:DataMiner_Teams_bot#adding-custom-commands-for-the-teams-bot-to-a-dms).

#### 23 January 2024 - Fix - Unknown error when accessing the web apps remotely [ID 38549]

While remote access was used to go to the web apps via dataminer.services (e.g. the Monitoring app), the following message could appear: `An unknown error occurred (status: 200).` The app would also stop working until the page was refreshed. This issue has been resolved.

#### 12 January 2024 - Fix - The given username was not applied when deploying a DaaS system

When a custom username was given when deploying a new DaaS system, the default username (Administrator) was still used. The user will now be created with the custom username.

#### 12 January 2024 - New feature - Remote access for custom files/webpages [ID 38426]

It is now possible to provide remote access via dataminer.services to files or webpages. To do so, add them in the folder `C:\Skyline DataMiner\Webpages\public\` on your DMA. To access such files, users can use the remote access URL followed by `/public/` (e.g. the file *image.png* via `https://ziine-skyline.on.dataminer.services/public/image.png`).

#### 4 January 2024 - New feature - Chat Integration with Microsoft Teams now includes sending notification using Adaptive Cards [ID 38339]

It is now possible to send notifications using Adaptive Cards to chats or channels with Chat Integration.

In an Automation script, you can use [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) 1.2.0 to easily interact with Microsoft Teams.

To get started, you can find several example Automation scripts with more information on [GitHub](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples).

After you have made sure that the [prerequisites](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#usage) are in place, you can deploy [the Chat Integration examples](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#getting-started) to your DataMiner System and immediately try out these examples.

#### 20 December 2023 - Enhancement - Email notifications for expiring and expired DataMiner Community Edition DaaS systems [ID 38235]

From now onwards, when a DataMiner Community Edition DaaS system is about to expire, an email notification will be sent to both the owners of the organization and the owners of the DMS, so that they can take action if they want to prevent deletion. Another email notification will be sent when the DataMiner Community Edition DaaS system has been deleted.

A notification will also be sent when an organization owns multiple DaaS systems and it will not be possible to extend one or more of these systems because the organization will not have enough DataMiner credits, as predicted based on the current usage.

#### 13 December 2023 - New feature - Email notifications for expiring and expired DataMiner Community Edition DaaS systems [ID 38183]

From now onwards, when a DataMiner Community Edition DaaS system is about to expire, an email notification will be sent to the owners of the organization and the person who deployed the DaaS system, so that they can take action if they want to prevent deletion. Another email notification will be sent when the DataMiner Community Edition DaaS system has been deleted.

#### 6 December 2023 - New feature - Remote Access setting is now checked for user-defined API access [ID 38102]

Users will now only be able to access a user-defined API using the remote access URL if the Remote Access setting is enabled in the Admin app.

#### 4 December 2023 - New feature - DataMiner as a Service for staging systems [ID 38087]

It is now possible to create a [DataMiner as a Service (DaaS)](xref:Creating_a_DMS_in_the_cloud) system on dataminer.services for staging systems.

Our [Pay-per-Use](xref:Pricing_Commercial_Models) model is used for this: When you deploy such a DaaS system, 3 DataMiner credits will be deducted from your organization every week. In case your organization runs out of DataMiner credits, the DaaS system will be deleted. By default, every organization is provided with 3 DataMiner credits, so you can try out a DaaS system for one week free of charge.

> [!TIP]
> See also:
>
> - [DataMiner Community Edition](xref:Pricing_Commercial_Models#dataminer-community-edition)
> - [Creating a DaaS system](xref:Creating_a_DMS_in_the_cloud)

When you create a DaaS system, your dataminer.services account will automatically be linked to your DataMiner account, so you can easily access DataMiner web apps such as the Monitoring app via remote access.

You can manually delete a DaaS system from dataminer.services, just like any other DMS; however, note that this is irreversible, and all data of the system will be lost.

#### 28 November 2023 - Enhancement - Deploying multiple DaaS systems simultaneously

It is now possible to create more than one DaaS system simultaneously on [dataminer.services](https://dataminer.services).

#### 24 November 2023 - Fix - Improved username validation when deploying a DaaS system

The username validation has been improved to prevent the deployment from failing when the given username is not a valid. This fixes an issue introduced on 10 November 2023.

#### 24 November 2023 - Enhancement - Improved login system for Admin app

The [Admin app](https://admin.dataminer.services) now has an improved login system. This should prevent login redirect loops that could be experienced before.

#### 24 November 2023 - New feature - Introducing the new Catalog user interface

A new user interface has been introduced for [catalog.dataminer.services](https://catalog.dataminer.services).

#### 22 November 2023 - Enhancement - Warning to link account before doing a DxM or Catalog deployment

From now on, the [Admin app](https://admin.dataminer.services) and [Catalog](https://catalog.dataminer.services) will prevent users from doing a deployment if they do not have a linked DataMiner account for the relevant DataMiner System, because in such a case the deployment is not possible. A warning to link the accounts will be displayed instead.

#### 22 November 2023 - Enhancement - Improved login system for dataminer.services home page

The [dataminer.services](https://dataminer.services) home page now has an improved login system. This should prevent login redirect loops that could be experienced before.

#### 21 November 2023 - New feature - Remote access using DataMiner Cube [ID 37841]

It is now possible to connect to a DataMiner System via remote access using DataMiner Cube. If remote access is enabled for a DMS and you have been granted access to dataminer.services features, you can access the DMS remotely via Cube using the same URL as for remote access to the web pages, but without the protocol prefix `https://`. A button is also available on dataminer.services and in the Admin app that can be used to open Cube with the correct remote access filled in as the host.

> [!NOTE]
> At present, there is still a limitation to this feature: if the DMS has SAML authentication configured, users will not be able to access the DMS remotely with Cube.

#### 10 November 2023 - Fix - Grant admin consent linking button unresponsive

Users were no longer able to grant admin consent for the Teams Chat Integration because the button was no longer functional. This issue has now been resolved.

#### 10 November 2023 - Enhancement - Provide a custom username and password when deploying a DaaS system

From now on, you will be able to provide your own username and password for your admin account when deploying a DaaS system.

#### 9 November 2023 - Enhancement - Improved login system for sharing

The live sharing feature, including the [Shares app](https://shares.dataminer.services), now has an improved login system. This should prevent login redirect loops that could be experienced before.

#### 9 November 2023 - Enhancement - Improved login system for connection to the dataminer.services

When a DMS is connected to dataminer.services, an improved login system will now be used. This should prevent login redirect loops that could be experienced before.

#### 26 September 2023 - Fix - Remote Access automatic login now works with special characters in DataMiner account configuration [ID 37438]

If your DataMiner account contained one or more special characters, for example in the full name field, and you used Remote Access (e.g. the Monitoring app via dataminer.services), it was not possible to log in. Now you can log in automatically with your linked DataMiner account.

> [!NOTE]
> If you log in manually, you will still encounter this issue: This will not work when you have one or more special characters configured in your DataMiner account. To resolve this, [link your DataMiner account to your dataminer.services account](https://aka.dataminer.services/account-linking). The automatic login will allow you to use Remote Access without requiring any further actions.

#### 20 September 2023 - Enhancement - Admin app - Nodes page responsiveness improved [ID 37403]

Performance has improved when node and DxM information is retrieved on the *Nodes* page of a DataMiner System in the Admin app.

#### 22 August 2023 - Enhancement - Admin app - Audit Record Export (CSV) [ID 37164]

In the [Admin app](https://admin.dataminer.services), a new feature has been introduced on the *Audit* page, allowing users to export audit records in a CSV file. Clicking *Export* in the top-left corner will initiate the export process. A pop-up window will appear, where you can choose the separator to be used in the CSV file, as well as whether to include column titles at the top of the exported CSV file. Once the file has been generated, you will receive an email containing a link to download the CSV file. The download link included in the email will be valid for a period of 7 days.

#### 3 July 2023 - Fix - Admin app - Organization user overview will display all DMSs of each user correctly [ID 36795]

In the Admin app, when an organization user had more than one DMS, only the last DMS would be shown in the organization user overview and its details overlay. This issue has now been resolved.

#### 16 June 2023 - Fix - Chat Integration with Microsoft Teams: Improved consistency for email inputs [ID 36643]

Consistency for the Chat Integration email input has been improved.

Previously, some features were using the email input as the actual email address of the user, and some were using it as the service principal name of the user. This was not an issue if both had the same value in the linked tenant. However, if the values differed, some features like "Create Team" and "Add Team Member or Owner" did not work unless the actual service principal name was given.

This is now no longer the case. All email input for all Chat Integration features behaves the same as the email address set for the user in the tenant.

#### 30 May 2023 - Enhancement - Catalog - Notification when deploying from the catalog [ID 36543]

When you deploy something (e.g. a connector) from the catalog to a DMA, a notification will now indicate if the deployment has started properly. The notification also contains a link to the Admin page, where you can view the status of the deployment.

#### 11 May 2023 - Enhancement - Easier sharing of deployment records [ID 36398]

When you select a deployment record on the *Deployments* page of the Admin app, the URL of the app is now updated with a query parameter referencing the ID of the deployment. This allows you to share this URL with someone to immediately show them that deployment.

#### 3 April 2023 - New feature - Chat Integration with Microsoft Teams now includes fetching teams and channels [ID 35983]

The following Chat Integration features have been added:

- Fetching all teams
- Fetching all channels of a team, so you can send channel notifications in them

In an Automation script, you can use [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) to easily interact with Microsoft Teams.

To get started, you can find several example Automation scripts with more information on [GitHub](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples).

After you have made sure that the [prerequisites](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#usage) are in place, you can deploy [the Chat Integration examples](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#getting-started) to your DataMiner System and immediately try out these examples.

> [!NOTE]
> To enable these additional features, you **must grant Skyline admin consent to your Microsoft tenant with certain permissions, even if you have already granted admin consent before.** See [granting admin consent](xref:Granting_admin_consent). You can revoke these permissions at any time.

#### 30 March 2023 - Fix - Sharing app: Confirmation pop-up window not visible [ID 36029]

In the Sharing app, depending on the position of the scrollbar, it could occur that the confirmation pop-up window for the deletion of an incoming share was displayed outside the boundaries of the screen, so that it was not possible to confirm the deletion.

#### 2 March 2023 - Integrate your DataMiner System with Microsoft Teams using DataMiner Automation [ID 35799]

You can now easily integrate your DataMiner System with Microsoft Teams using DataMiner Automation.

The following features are available:

- Creating teams
- Creating channels
- Adding members or owners to your teams
- Sending notifications in the created channels in the name of the DataMiner Teams bot
- Creating a private chat between someone and the DataMiner Teams bot
- Fetching a private chat between someone and the DataMiner Teams bot
- Sending notifications in those private chats in the name of the DataMiner Teams bot

In an Automation script, you can use [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) to easily interact with Microsoft Teams.

To get started, you can find several example Automation scripts with more information on [GitHub](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples).

After you have made sure the [prerequisites](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#usage) are in place, you can deploy [the Chat Integration examples](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#getting-started) to your DataMiner System and immediately try out these examples.

> [!NOTE]
> You must grant Skyline admin consent to your Microsoft tenant with certain permissions to enable these features. See [granting admin consent](xref:Granting_admin_consent). You can revoke these permissions at any time.

#### 9 February 2023 - Fix - Remote access actions incorrectly blocked [ID 35594]

In some cases, it could occur that requests were incorrectly blocked as unsafe when you used the remote access feature. For example, this could occur when you clicked the Home button in the top-left corner of a web app.

#### 13 January 2023 - Enhancement - Auditing of protocol and script deployments [ID 35392]

The *Audit* page of the Admin app will now also contain records for protocol and script deployments, while previously it only showed records for DxM artifact deployments.

Deploying protocols can be done via the [DataMiner Catalog](https://catalog.dataminer.services/), deploying scripts can be done with a GitHub or GitLab CI/CD pipeline, and deploying DxMs can be done with the Admin app.

#### 10 January 2023 - Enhancement - Audit log whenever Skyline's Support team uses Remote Log Collection [ID 35165]

Every time Skyline's Support Team uses the Remote Log Collection feature on a DataMiner Agent, an audit log will now be created on dataminer.services. You can view these logs on the *Audit* page of the [Admin app](https://admin.dataminer.services).

#### 8 December 2022 - Enhancement - New endpoints for dataminer.services connection and sharing [ID 35127]

For connection and share management, new endpoints will now be used instead of the `https://admin.dataminer.services/*` endpoint:

- Connecting a DMS to dataminer.services will use the endpoint `https://connection.dataminer.services/*`.
- Creating and managing shares will use the endpoint `https://sharing.dataminer.services/*`.

#### 8 December 2022 - Enhancement - MSAL 2.0 implementation [ID 35126]

A new version of MSAL has been implemented. This will result in faster and more stable authentication, which will also be updated more frequently.

In addition, when the Admin app is authenticating, it will now display a loading icon.

#### 6 December 2022 - Enhancement - Improved audit events for dashboard shares [ID 35087]

When shares are created, accessed, updated, or deleted, the audit events on the Audit page of the Admin app will now include the name of the shared dashboard and a link to the dashboard. To navigate to the dashboard, users will need to have access to the dashboard.

#### 6 December 2022 - Enhancement - Audit events for DMS and organization user CUD actions [ID 35086]

When DMS or organization users are created, updated, or deleted, audit events will now be added on the Audit page of the Admin app.

#### 18 October 2022 - Enhancement - Notification in case deployment fails because account is not linked [ID 34699]

When a deployment fails because the user does not have a linked account, they will now get a notification that will allow them to correct the situation and retry.

#### 18 October 2022 - Enhancement - Admin app supports additional audit events [ID 34697]

The Admin app now also includes the following audit events on the *Audit* page:

- A user created a dashboard share.
- A user performed an updated to an existing share.
- A user deleted an existing share.

Up to now, only accessing a share was logged in the audit events.

#### 27 September 2022 - New feature - DataMiner Teams bot support for custom commands [ID 34518]

If CoreGateway version 2.11.0 or higher and FieldControl version 2.8.1 or higher are installed (included in Cloud Pack version 2.8.2), the DataMiner Teams bot now allows you to display and run custom commands with dynamic user input configured in a DataMiner System connected to dataminer.services.

You can do so using the Teams bot commands *show command \<command name\>*, *show command*, and *run command \<command name\>*.

To add a command to your DMS, create an Automation script in the folder "bot" in the DMS. For examples of such scripts, refer to [Custom Command Examples](https://github.com/SkylineCommunications/ChatOps-Extensions/tree/main/CustomCommandExamples) on GitHub.

The commands allow dynamic input, such as dummies, parameters, parameters with value files, and memory files. They support the following output: key values, adaptive card body elements, and JSON.

A command will only be visible for users of the bot if they have the appropriate rights in DataMiner Cube. If users have the necessary rights to view a command, but they do not have the rights needed for certain input for the command, the bot will inform them that the command cannot be executed.

The following limitations also apply:

- Interactive Automation scripts are not supported.
- Commands that run longer than 30 seconds are currently not supported.
- Issues with the adaptive card output will not result in proper error feedback.

For more detailed information, refer to [Adding commands for the Teams bot to a DMS](xref:DataMiner_Teams_bot#adding-custom-commands-for-the-teams-bot-to-a-dms).

#### 19 September 2022 - Enhancement - Improvements on Audit page in Admin app [ID 34457]

A number of improvements have been implemented on the *Audit* page in the Admin app:

- You can now filter on subject name and initiator.
- A search box is now available for each filter so you can quickly search for a specific item to filter on.
- Some filters allow you to manually specify custom values. For example, for the *Initiator* filter, which is automatically populated with the organization users, you can manually specify a user that has been deleted.
- The column order has been adjusted.
- Automatic loading of audit records has been improved to prevent possible issues with different screen sizes.

#### 1 September 2022 - Enhancement - Filter functionality for Audit log in Admin app [ID 34322]

The Audit log in the Admin app now allows filtering on operation type, subject type, DataMiner System name, and time span. In addition, the loading of records has been optimized.

#### 18 August 2022 - New feature - Audit and license information added in Admin app [ID 34216]

In the Admin app, the license expiration date for an organization is now displayed on that organization's *Overview* page.

In addition, a new *Audit* page is available in the app, which contains auditing logs for sharing dashboards and dataminer.services keys.

#### 17 June 2022 - Enhancement - Admin app opens to Overview page [ID 33772]

When you open the Admin app, it will now immediately show the *Overview* page of the selected organization. Previously, it showed a page that only contained "Home".

#### 17 June 2022 - Enhancement - Admin icon available for all users [ID 33770]

The icon to access the Admin app is now available for all users on the `dataminer.services` home page. Previously, this was only available for admins and owners.

#### 10 June 2022 10 - New feature - New 'Outgoing Shares' page in Admin app [ID 33723]

In the Admin app, a new *Outgoing Shares* page is now available for each DataMiner System connected to dataminer.services. This page lists all items that have been shared via dataminer.services from the selected DMS.

When you click a shared item in the overview, more detailed information will be displayed, including the time when it was shared and when the share will expire.

#### 10 June 2022 10 - Enhancement - Pages in Admin app sidebar not shown for users without required permissions [ID 33708]

If you do not have the required permissions to use a specific page for a DMS in the Admin app, this page will no longer be shown when you select a DMS in the sidebar of the app.

#### 10 June 2022 10 - New feature - New 'Deployments' page in Admin app [ID 33707] [ID 33709] [ID 33724]

In the Admin app, a new *Deployments* page is now available for each DataMiner System connected to dataminer.services. This page provides information about all the deployments that have been done to the DataMiner System via the Nodes page, via the Catalog, or using a GitHub pipeline with our GitHub action. It details what has been deployed, when and by whom, and whether the deployment succeeded, is pending, or failed.

When you click a deployment in the overview, more detailed information will be displayed, including version information and event information that can be used for debugging. For example, in case a pending deployment is queued because of other deployments, you will be able to see this in the event information.

#### 3 June 2022 - New feature - dataminer.services keys [ID 33606]

You can now use dataminer.services keys. At present, these can be used with the [GitHub action to deploy Automation scripts](https://github.com/marketplace/actions/skyline-dataminer-deploy-action) to a DMS connected to dataminer.services. However, more functionality requiring a dataminer.services key is expected to be implemented in the future.

In the Admin app, you can manage the dataminer.services keys on the *Keys* page for each DataMiner System connected to dataminer.services. Each set of keys consists of a (user-defined) label, a primary key, and a secondary key. Inline buttons are available that allow you to view or copy a key. Simply clicking a key entry in the list will open a side panel with detailed information, including when the keys were created and by whom.

For each set of keys, the *...* button on the right opens a menu where you can regenerate the primary key, regenerate the secondary key, or revoke (i.e. delete) the key. With the *New Key* option at the top of the page, you can add more keys.

#### 3 June 2022 - New feature - Admin app sidebar redesigned [ID 33599]

The layout of the Admin app has been improved. The blue icon bar on the left has been removed and the sidebar has been redesigned into two sections: *Organization* and *DataMiner Systems*. In the *DataMiner Systems* section, you can expand and collapse each connected DMS to view the available pages for that DMS.

#### 19 May 2022 - Fix - Notification when removing user showed placeholder [ID 33383]

When a user was removed in the Admin app, the displayed notification contained a placeholder instead of the relevant email address.

#### 6 May 2022 - New feature - DataMiner Teams bot v1.2 [ID 33422]

A new version of the DataMiner Teams bot is now available. If you use the command *show view [View name]* with this new version, the DataMiner Teams bot will display the visual overview of the specified view, as well as the alarm status and the number of active alarms. With the buttons in the response, you can request the alarms of the view or open the view in the Monitoring app via remote access.

In addition, all links to documentation in the app have been adjusted to link to <https://docs.dataminer.services/>.

#### 2 May 2022 - Fix - Not possible to delete share without users [ID 33366]

If a share was not valid because all users had removed themselves from it, it could occur that it was not possible to delete that share. This issue has now been resolved.

#### 14 Apr. 2022 - New feature - Managing nodes connected to dataminer.services [ID 33081] [ID 33127]

In the Admin app, you can now manage the nodes of DataMiner Systems that are connected to dataminer.services. You can upgrade the installed DxM versions on the nodes and remove nodes that have become obsolete. In case a node has a higher DxM version installed than the current version, it is also possible to downgrade that node.

Note that DataMiner Cloud Pack version 2.5.0 or higher must be installed on the nodes, as otherwise they will not be listed in the Admin app.

> [!IMPORTANT]
> If you are using an IP-based firewall, from now on you will need to add `20.31.240.20` to the allowed IP addresses to be able to connect to dataminer.services.

#### 5 Apr. 2022 - New feature - Admin app no longer shown by default on home page [ID 33090]

The Admin app will now only be shown on the dataminer.services home page for users who are the owner/admin of an organization and/or of a DataMiner System.

#### 5 Apr. 2022 - New feature - Non-dataminer.services users now notified about needing to connect to dataminer.services [ID 33089]

When a user of a DMS that is not yet connected to dataminer.services goes to <https://dataminer.services/>, they will now be informed that they are not yet connected, and a link will be provided to more information about dataminer.services.

#### 28 Feb. 2022 - New feature - dataminer.services connection verification [ID 32741]

In the Admin app, on the *Organization > Manage* page, users can now click a button to send an email to Skyline to have their dataminer.services connection verified. This verification ensures access to the latest dataminer.services features, including the ability to install protocols directly from the dataminer.services catalog.

When the verification has been successful, this will be indicated on this same page.

#### 23 Feb. 2022 - New feature - Removing a share [ID 32695]

In the *Sharing* module, you can now remove a share. When you do so, you indicate that you no longer wish to have access to the shared item. The item will no longer be available to you, unless it is shared with you again.

#### 12 Jan. 2022 - New feature - Support for app package deployment [ID 32210]

Support has been added for the deployment of app packages to a specific DMS connected to dataminer.services. However, note that the UI to deploy app packages is not yet available at this point.
