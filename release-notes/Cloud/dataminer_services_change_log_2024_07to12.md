---
uid: dataminer_services_change_log_2024_07to12
---

# dataminer.services change log - 2024 (July-December)

This change log can help you trace when specific features and changes became available on the dataminer.services platform in 2024, from July to December.

> [!NOTE]
> Many features on dataminer.services are dependent on DxMs. You can find the change logs for these under [DxM release notes](xref:DxM_RNs_index).

#### 19 December 2024 - Enhancement - Catalog - Catalog type now included in audit events [ID 41746] [ID 41755] [ID 41756]

Audit events related to Catalog actions will now include the type of the Catalog item.

#### 17 December 2024 - Fix - Admin - Organization name not shown for audit events [ID 41740]

In the Admin app, it could occur that the name of an organization could not be shown in the audit logs.

#### 17 December 2024 - Enhancement - Admin app - Improved audit export [ID 41694]

From now on, when you export the audit information from the *Audit* page in the [Admin app](https://admin.dataminer.services), the export file will have a better name, which will include the organization name and a readable timestamp.

#### 11 December 2024 - Enhancement - Admin app - Improved usage export file [ID 41695]

From now on, when you export the usage information from the *Usage* page in the [Admin app](https://admin.dataminer.services), the export file will have a better name, which will include the organization name and a readable timestamp. The metrics in the file itself will now also contain the organization and DMS name, and if the option to include column titles was selected, there will be better column titles at the the top.

#### 9 December 2024 - Enhancement - Home/Admin/Catalog/Marketplace/Sharing - App title now works as link that can be opened in new tab [ID 41518] [ID 41524]

When you click the title of the Admin, Catalog, Home, Marketplace, or Sharing apps with the middle mouse button, this will now open the app again in a new tab. In addition, you can now also right-click the title to among others open the app in a new tab or in a new window.

#### 9 December 2024 - Enhancement - Home - Updated terms of service and conditions for DaaS deployments [ID 41651]

The link to the terms of service and conditions for DaaS deployments has been updated.

#### 9 December 2024 - Enhancement - Remote Access - Improved upload speed [ID 41662]

The upload speed for remote access requests has been improved. This will mainly affect file uploads, for example in Cube when uploading a protocol or upgrade package.

#### 9 December 2024 - Enhancement - Catalog API -  IsTrustedSource property now included in search API calls [ID 41541]

The *IsTrustedSource* property is now included in search API calls, allowing a green shield icon to be shown for Catalog items with a trusted publisher.

#### 1 December 2024 - New feature - Admin app - Connector usage [ID 41580]

From now on, the usage page in the [Admin app](https://admin.dataminer.services) will also provide usage data about the used connectors when available. This usage is shown as an average over the selected month.

#### 29 November 2024 - Enhancement - Catalog API - GetCategories now returns only types available for the user [ID 41531]

​The "api/user-catalog/v2-0/catalogs/categories" call in the user controller has been extended to only take into account the types from Catalog items the user has access to.

#### 26 November 2024 - New feature - Admin app - Automation usage [ID 41554]

From now on, the usage page in the [Admin app](https://admin.dataminer.services) will also provide usage data about automation script runs when available.

#### 26 November 2024 - New feature - Usage API - Usage API with API key [ID 41554]

From now on, you can create an API key on organization level with the "Retrieve usage data" permission. This API key can be used with the new Key Usage API, in combination with the new Public Usage API, to retrieve usage data about your DataMiner Systems in an automated way.

The swagger documentation pages about the available Usage API calls are available in the following locations:

- [Public Usage API swagger documentation](https://api.dataminer.services/swagger/usageapi/index.html?urls.primaryName=Public+Usage+Api+v1.0)
  - Get the features for which usage data might be available. Example features: `Automation`, `Storage as a Service`.
  - Get the metrics of a feature. Example metrics: `Script Runs` for the Automation feature, `Operations` for the Storage as a Service feature.
- [Key Usage API swagger documentation](https://api.dataminer.services/swagger/usageapi/index.html?urls.primaryName=Key+Usage+Api+v1.0)
  - Get the data in a given time range, for a given feature, a given metric, and a given granularity, with the option to filter the data and split up the data based on specific properties or based on DataMiner System. These "splitters" can for example be `Script Name` or `Succeeded` for Automation, and `Category` or `SubCategory` for Storage as a Service.

#### 26 November 2024 - Enhancement - Admin app - Usage and audit export email layout [ID 41554]

From now on, the emails with the download link for usage exports or audit exports will use the same template as other emails sent from dataminer.services.

#### 25 November 2024 - Fix - Catalog API - Registration with invalid manifest returned internal server error [ID 41516]

When you registered a Catalog item using a manifest that contained invalid syntax for the owner, up to now an HTTP 500 internal server error was returned. Now an HTTP 400 Bad Request result will be returned instead, which will detail which field is invalid.

#### 25 November 2024 - Fix - Catalog API - Registration with existing ID from other organization returned internal server error [ID 41515]

When you registered a Catalog item with an ID that already existed in another organization, up to now an internal server error was returned. Now an HTTP 409 Conflict result will be returned instead.

#### 25 November 2024 - New feature - Catalog API - Changing the publishing state of Catalog items using an organization key [ID 41491]

It is now possible to set a Catalog item to public or private using an organization key with permission *Update Catalog publishing state*.

#### 25 November 2024 - Enhancement - Catalog - Deployment warning for items that have external publisher [ID 41486]

On the Catalog details page, when a user tries to deploy an item from an external publisher, a warning will now be shown.

#### 25 November 2024 - Enhancement - Admin - Warning in case DataMiner version dependency is not met for DxM [ID 41459]

On the *DxMs* page in the Admin app, when a DataMiner version dependency is not met for a DxM, a warning will now be shown.

#### 25 November 2024 - Enhancement - Catalog - 'Type' filter improvements [ID 41452]

On the Catalog browse page, the *Type* filter will now group its available values by category.

The following Catalog types have been updated or introduced:

 Category               | Type (before)      | Type (new)         |
------------------------|--------------------|--------------------|
 Data Ingest            | Connector          | Connector          |
 Data Ingest            | Scripted Connector | Scripted Connector |
 Data Processing        | Ad Hoc Data Source | Ad Hoc Data Source |
 Data Processing        | Automation Script  | Automation         |
 Data Processing        | Data Transformer   | Data Transformer   |
 Data Processing        | Data Query         | Data Query         |
 Data Consumption       | ChatOps Extension  | ChatOps Extension  |
 Data Consumption       | Dashboard          | Dashboard          |
 Data Consumption       | User-Defined API   | User-Defined API   |
 Data Consumption       | Visual Overview    | Visual Overview    |
 Solutions              | /                  | Product Solution   |
 Solutions              | Standard Solution  | Standard Solution  |
 Solutions              | Solution           | Custom Solution    |
 Productivity & Utility | /                  | DevTool           |
 Productivity & Utility | /                  | System Health      |

The following types have been removed:

- Best Practices Analyzer
- Enhanced Service Model
- Function Definition
- Lifecycle Service Orchestration
- Low-Code App
- Process Activity
- Profile-Load Script (now considered Automation)
- Sample Solution
- SLA Model
- Testing Solution

#### 25 November 2024 - Catalog - Improved retrieving mechanism for Catalog item types [ID 41431]

The way Catalog item types are retrieved has been improved to ensure that when the name of a type changes, no changes to the UI will be needed.

If any API calls currently use the value of a type, these will need to be updated to use the new available string values for the types.

#### 25 November 2024 - Enhancement - Catalog - Changing the publishing state of Catalog items [ID 41418]

On the Catalog details page, items can now be made public or private by an Owner or Admin from the publishing organization.

#### 25 November 2024 - Enhancement - Catalog - Ability for users within an organization to change the publishing state of the organization's Catalog items [ID 41413]

When users are a member of a specific organization, they will now be able to change the publishing state of Catalog items that are owned by that organization to public or private.

#### 25 November 2024 - New feature - Catalog API - Get Catalog item categories [ID 41411]

The user, service, and public Catalog APIs have been extended with a categories call to obtain all categories supported in Catalog:

- "/api/user-catalog/v2-0/catalogs/categories"
- "/api/public-catalog/v2-0/catalogs/categories"
- "/api/service-catalog/v1-0/catalogs/categories"

#### 25 November 2024 - Enhancement - Catalog API - Improved security for calls to change Catalog item publishing state [ID 41406]

Additional user role checks have been added to the calls to change the publishing state of a Catalog item, so that now only people with the Owner or Admin role will be able to do so.

#### 25 November 2024 - Enhancement - Catalog - Items from external publishers now labeled [ID 41402]

On the Catalog details page, if the publisher is not from your currently selected organization or Skyline Communications, the tag "External" will be shown next to the publisher in the side panel.

#### 25 November 2024 - Enhancement - Catalog - Documentation link shown for Catalog items [ID 41397]

On the Catalog details page, the side panel will now include a *Documentation* button to go to the external documentation.

#### 25 November 2024 - Enhancement - Catalog - Retrieving a Catalog item by ID now also returns a documentation link [ID 41394]

When a Catalog item is retrieved by ID, it will now also return a documentation link if one is defined.

#### 21 November 2024 - Fix - Catalog - Backwards-compatible URLs [ID 38783]

Catalog detail URLs were originally formatted as `https://catalog.dataminer.services/catalog/{id}` or `https://catalog.dataminer.services/driver/{id}`. Because of a recent change, these URLs no longer worked, resulting in a "Catalog not found" error message.

Now the URLs will instead redirect to the proper current URL format, which can be one of the following:

- details/connector/{id}
- details/automation-script/{id}
- details/visio/{id}
- details/package/{id}

#### 11 November 2024 - Enhancement - Catalog - All version formats supported for new item versions [ID 41243]

When an item version is registered, the Catalog API will now allow all version formats. If a version does not start with "x.x.x.x" or "x.x.x", it will be put in an "other" range. Versions with suffixes (e.g. -alpha, -beta, -CUxxx, etc.) will be added to their respective ranges.

#### 7 November 2024 - Fix - Catalog - Version info for items without version stayed in loading state [ID 41325]

Up to now, when you opened the versions section of an item without any versions, it would stay in a loading state. This has now been fixed: an info message will be shown saying this item does not have any versions.

#### 7 November 2024 - Enhancement - Catalog - Permalinks shown for titles of a Catalog description [ID 41322]

The description of an item will now show a link next to the titles in the form of a "#". This link can be copied and shared with other users and will open the current page at the selected title.

#### 7 November 2024 - Enhancement - Catalog - Support for relative (local) links in the description of an item [ID 41319]

On the Catalog details page, headings can now be linked to. You can link to the heading using the relative link from their markdown source. If a fragment link (indicated by # in the URL) is detected, the details page will scroll to the corresponding heading.

#### 7 November 2024 - Enhancement - Sharing - Email now set when user leaves input field [ID 41244]

After a user fills in the email input field and leaves it, the email will now be saved and the share button will be enabled.

#### 7 November 2024 - Fix - Sharing - Share button not enabled after setting expiration date [ID 41244]

Previously, when you enabled the expiration date for a share and then set a date, the share button would still be disabled. This has now been fixed: as soon as you set an expiration date, the share button will be enabled.

#### 7 November 2024 - Enhancement - Admin app - Audit export rephrased [ID 41234]

From now on, the audit export entry will have a better title, e.g. "Usage export by ...".

#### 7 November 2024 - Fix - Catalog API - Missing search results [ID 41226]

When items had no reference to a vendor, it could occur that they were not included in search results.

#### 7 November 2024 - Enhancement - Catalog - Catalog versioning format updated [ID 41225]

​The Catalog API now allows all formats when registering a version of a Catalog item.

- Versions following semantic version A.B.C.D will be displayed in an A.B.C range.
- Versions following semantic version A.B.C will be displayed in an A range
- All other version formats will be displayed in the "Other" range.

#### 28 October 2024 - Enhancement - Admin app - Audit export file download with a trusted dataminer.services URL [ID 41239]

From now on, the audit export emails will contain a trusted dataminer.services URL for the file download.

#### 28 October 2024 - Enhancement - Admin app - Enhanced stability and performance of the Audit page [ID 41238]

Enhancements have been implemented to the *Audit* page in the [Admin app](https://admin.dataminer.services), improving the stability, availability, and performance with immediate effect.

#### 24 October 2024 - Enhancement - Catalog API - Catalog registration using a DMS key [ID 41215]

The Catalog API can now be used with a DMS key for authentication providing compatibility with existing pipelines that deployed a Catalog item on a DMS.

#### 24 October 2024 - Enhancement - Catalog - Improved the way tags of a Catalog item are displayed [ID 41182]

Tags of a Catalog item will now be shown based on the available space. If a tag is too large, it will be grouped in a "+x" tag that will show the values of the grouped tags when hovered over.

#### 24 October 2024 - Enhancement - Catalog - Updated heading styles [ID 41145]

The style of the headings in the Catalog has been adjusted to match the overall style of the application.

#### 24 October 2024 - Enhancement - Catalog - Catalog description supports markdown alert styling [ID 41053]

Alert styling in the Catalog description readme.md is now supported. The currently supported types are "Caution", "Important", "Note", "Tip", and "Warning".

#### 22 October 2024 - Enhancement - Admin app - Irrelevant modules no longer shown on DxMs page [ID 41187]

Modules for which no updates are provided on the DxMs page in the [Admin app](https://admin.dataminer.services) will no longer be shown.

#### 18 October 2024 - Enhancement - ChatOps - Enhanced stability and performance of Teams Chat Integration [ID 41149]

Enhancements have been implemented to the Teams Chat Integration feature, ensuring improvements in stability, availability, and performance with immediate effect.

#### 16 October 2024 - Enhancement - Admin app - Usage export to CSV [ID 41117]

In the [Admin app](https://admin.dataminer.services), a new feature has been introduced on the *Usage* page, allowing users to export usage metrics to a CSV file. Clicking the *Export usage* button will initiate the export process. A pop-up window will appear, where you can choose the separator for the CSV file, as well as whether to include column titles at the top of the exported CSV file. Once the file has been generated, you will receive an email containing a link to download the CSV file. The download link included in the email will be valid for a period of 7 days.

#### 16 October 2024 - Fix - Sharing - Missing emails [ID 41110]

When you edited a share, the email addresses of the people with access to the share were not filled in. Now the email addresses will be shown correctly.

#### 16 October 2024 - Enhancement - Web apps - Colors web apps adjusted [ID 41100]

​The dataminer.services web apps have been updated to make use of new colors, which will provide better contrast and make the UI easier to read.

#### 16 October 2024 - Enhancement - Account linking & Catalog - 'Logout' changed to 'Sign out' [ID 41024]

In the account linking and Catalog UI, the term "Logout" has been replaced with "Sign out".

#### 16 October 2024 - Fix - Catalog - Deploy trial licensed issues [ID 41024]

When you used the *Deploy (trial)* button on the Catalog details page, it could occur that a "not licensed" message was shown, even though this should not happen.

#### 16 October 2024 - Enhancement - Catalog - Description styling [ID 40965]

The styling of alerts in ​Catalog descriptions has been adjusted so it matches the styling of [docs.dataminer.services](https://docs.dataminer.services). The currently supported alert types are caution, important, note, tip, and warning.

#### 16 October 2024 - Enhancement - Catalog - Design improvements [ID 40965]

The card layout in the Catalog has been redesigned to be more concise. The detail page header section, search results, and home page sections have been updated to match the new card design.

#### 10 October 2024 - Enhancement - Catalog - 'Deploy trial' button also available for non-authenticated users [ID 41011]

Non-authenticated users can now also click the *Deploy trial* button in the header of an item or for a specific version. They will then need to log in first, after which the details page will be shown again where they can continue to deploy the given item.

#### 10 October 2024 - Enhancement - Catalog API - Possibility to obtain Catalog item using organization key [ID 40976]

Using the Catalog API, it is now possible to obtain a Catalog item via its ID (GUID) or legacy DPC ID using an organization key for authorization.

#### 10 October 2024 - Enhancement - Catalog - Vendor and market shown in the side panel [ID 40966]

On the details page of a connector Catalog item, the vendor and market are no longer displayed as tags but are instead shown in the side panel.

#### 10 October 2024 - Enhancement - Catalog API - Registering Catalog item version now allows version message of up to 1500 characters [ID 40956]

When you register a version of a Catalog item using the Catalog API, a version message of up to 1500 characters will now be accepted.

#### 10 October 2024 - Enhancement - Catalog API - Search results now include short description property of Catalog item [ID 40955]

When a search is performed in the Catalog, the search result items will now contain a *shortDescription* property containing a small description of the Catalog item.

#### 10 October 2024 - Fix - Catalog - Search included virtual connectors (DVE) when searching in public and private scope [ID 40948]

When you searched or browsed in the Catalog using the visibility setting "All", DVE connectors were included in the results, while this should not happen because these do not have versions that can be deployed.

#### 8 October 2024 - Enhancement - Catalog API - V1 APIs removed [ID 41016]

The following APIs are no longer available:

- PublicCatalog V1
- UserCatalog V1

Instead, the V2 versions of these APIs should now be used.

#### 3 October 2024 - Fix - Problem using remote access with SAML authentication [ID 40971]

If SAML authentication was used, it could occur that remote access did not work correctly.

#### 27 September 2024 - Fix - Catalog API - Image upload failure during Catalog registration [ID 40885]

Uploading images used in the README.md file of a Catalog item registration call could fail with the message "The archive entry was compressed using an unsupported compression method".

This was caused by a concurrency issue when processing the files in parallel and has been fixed.

#### 27 September 2024 - Fix - Admin - Node name not shown in DxM upgrade warning message [ID 40880]

Up to now, in the warning message that was shown to inform users of the node where requirements for a DxM upgrade had to be checked, the entire DataMiner System was mentioned. Now, only the name of the relevant node will be shown instead.

#### 27 September 2024 - Enhancement - Admin - DMS opened in new tab from overview page [ID 40861]

In the Admin app, when you click the DMS URL on the DMS overview page, this will now open in a new tab.

#### 27 September 2024 - Enhancement - Home - Input fields disabled when DaaS deployment is submitted [ID 40860] [ID 41056]

When you deploy a DaaS system, all input fields are now disabled after you click *Deploy*.

#### 27 September 2024 - Fix - Catalog - Recommended version could show a private version [ID 40849]

Previously, when a Catalog item had a public range but private versions, it could incorrectly show or recommend a private version of that range.

#### 23 September 2024 - Enhancement - Catalog API - Enhanced image path format support when registering Catalog item [ID 40862]

When you register a Catalog item with a readme.md file, in that file you can now reference to an image using the home directory path "~" syntax or using a relative path. In addition, the casing of the image directory mentioned in the markdown file no longer matters, while previously this always had to be lowercase.

#### 23 September 2024 - Fix - Catalog - Duplicate Catalog items [ID 40839]

A duplicate Catalog item could be introduced in the Catalog after the register item call from the Catalog API was used on an existing item that was not originally registered via the Catalog API.

#### 23 September 2024 - Fix - Catalog - Incorrect description shown for Catalog item for an authenticated user [ID 40825]

When a Catalog item uses the same name as another connector Catalog item that was not registered via the Catalog API, the wrong description could be shown when you viewed the item as an authenticated user.

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

When a Catalog item version is not available to deploy because its installation file is not registered, a message will now be shown to the user to inform them that the version is not available and that they can contact tech support to make it available.

#### 12 September 2024 - New feature - Catalog - Unauthenticated access [ID 40570] [ID 40571] [ID 40572] [ID 40573] [ID 40686]

As an unauthenticated user, you can now search through the publicly available Catalog items, and view their description and their available versions.

#### 12 September 2024 - New feature - Catalog API - Catalog registration supports images in description readme file [ID 40219]

Catalog item registration now supports images in the provided description of the Catalog item. Any used images need to be included in a *Images* directory. Supported image formats are .jpg, .jpeg, .png, .gif, .bmp, .tif, .tiff, and .webp.

#### 11 September 2024 - New feature - Catalog API - Public API to retrieve a Catalog item [ID 40499]

A new route has been made available on "api/public-catalog/v2-0/catalogs/{catalogId}" to allow a user that is not logged in to retrieve a Catalog item.

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

#### 25 August 2024 - Enhancement - Catalog - Updated overlay headings [ID 41184]

Headings for the Organization and Notification overlays have been updated to match the updated Catalog heading style.

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

#### 9 August 2024 - New feature - Catalog - Sorting option and grid/list view buttons on Browse page [ID 40331]

When browsing through the items in the Catalog, users can now sort the items using a dropdown box at the top. Buttons are also available in the top-right corner that allow users to switch between a grid view and a list view.

#### 8 August 2024 - Enhancement - Vendor and market name of connector now considered dedicated properties [ID 40423]

Up to now, the vendor and market name of a connector were among the tags of a Catalog item and therefore visible in the search results. This has been changed so that vendor and market name are properties that can be seen on the details page of a Catalog item.

#### 8 August 2024 - New feature - Catalog - Case-insensitive searching on tags [ID 40368]

Search results on tags are now case insensitive.

#### 8 August 2024 - New feature - Catalog - Search supports sorting by name and type of a Catalog item [ID 40368]

On the browse page, you can now sort by the name and type of the items in ascending or descending order. By default, items will be sorted by name in ascending order.

#### 8 August 2024 - New feature - Limit of 5 tags implemented for Catalog items [ID 40349]

When you try to register a Catalog item with more than 5 tags, this will now fail, as this is not supported.

#### 8 August 2024 - Enhancement - Catalog - Recommended versions shown for all Catalog item types [ID 40346]

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

#### 26 July 2024 - Enhancement - Catalog API - Maximum amount of 5 tags implemented for Catalog items [ID 40306]

From now on, the Catalog only allows a maximum of 5 tags for a Catalog item. If more than 5 tags are specified, the API will return an error saying "Too many tags were supplied, a max of 5 is allowed".

#### 26 July 2024 - Enhancement - Catalog API - Sorting of recommended versions [ID 40286]

The recommended versions will now be shown in the following order:

1. Main versions, sorted by descending version number
1. Other versions, sorted by descending version number

#### 23 July 2024 - Fix - Catalog - Return button spanning whole height of container [ID 40245]

The height of the return button in the top-left corner of the Catalog item details page has been adjusted. Previously, the button spanned the full height of the container. It is now sized to match the button itself.

#### 23 July 2024 - New feature - Catalog - Catalog allows searching on Catalog tags [ID 40259]

It is now possible to search using Catalog tags. The list of all search results will display which tags are present on each Catalog item.

#### 23 July 2024 - New feature - Catalog - Support for more Catalog types [ID 40144]

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

- Lifecycle Service Orchestration

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

When a search request was initiated from the home page of the Catalog, an empty result was shown on the browse page until the page was reloaded. The correct search result will now be shown immediately.

#### 19 July 2024 - Enhancement - Catalog - Improved vendor logo loading [ID 40235]

Caching has been introduced for vendor logos, which will make Catalog search results load faster.

#### 18 July 2024 - Fix - Catalog - Versions of Catalog item not correctly shown [ID 40258]

In some cases, it could occur that the versions of a Catalog item could not be correctly shown.

#### 18 July 2024 - Enhancement - Catalog - Improved search [ID 40185]

When you search for Catalog items, partial matches on tags of a Catalog item will now be included in the search results.

For this purpose, the following routes have been updated:

- **api/user-catalog/v1-0/catalog/search**
- **api/user-catalog/v2-0/catalogs/search**

These will no longer have the market and vendor filters as query parameters, and the returned objects will now also include the tags.

#### 15 July 2024 - Enhancement - Remote Cube support for SAML [ID 40176]

From now on, SAML can be used to access Cube remotely.

#### 12 July 2024 - Enhancement - Organization selection saved [ID 40199]

In the dataminer.services UI, the organization selection will now be saved for at most one year using a cookie. Previously, this selection was only saved for the duration of the session.

#### 12 July 2024 - New feature - Admin - Usage page to view STaaS consumption [ID 40172]

In the Admin app, a new *Usage* page is now available for users with the Admin or Owner role in an organization. This page shows information about the usage of the STaaS systems in the organization.

#### 12 July 2024 - Enhancement - Catalog - Infinite scroll [ID 40167]

​On the Catalog browse page, when users now scroll to the bottom of the page, a new page will load if there are more Catalog items to show.

#### 11 July 2024 - Enhancement - ChatOps - Notification summary [ID 40182]

A new version (1.2.5) of [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) has been released, which allows you to add a summary to Chat Integration notifications using Adaptive Cards. This summary will be used for the actual activity notification, so you can easily read what is going on from the summary without opening the notification itself. The summary will also be used for the immersive reader functionality in Microsoft Teams.

If the summary is not explicitly defined, the behavior will stay the same, and "Card" will be shown by default.

#### 11 July 2024 - Enhancement - Improved handling of timed out Remote Access and Live Sharing requests [ID 40173]

An enhancement has been done to the way timed out requests are handled when the web apps are accessed remotely or when Live Sharing is used.

#### 9 July 2024 - Fix - Catalog API - Recommended version not showing latest version of a Catalog item [ID 40153]

The recommended version shown for a Catalog item could be incorrect. Because of invalid sorting, it could occur that it did not show the latest version of a range. This has been fixed.

#### 9 July 2024 - Fix - Catalog - Main ranges incorrectly filtered out in version history [ID 40147]

If all ranges of a Catalog item were either labeled as main or as deprecated, in the version history on the details page of the Catalog item, the main range could incorrectly be filtered out when the unsupported versions were set not to be shown (with the *Unsupported versions* toggle button). Now the main range will be shown correctly in the version history.

#### 9 July 2024 - Enhancement - Catalog - Extended support for Catalog item types [ID 40143]

The support for different Catalog item types has been extended. The following types are now supported:

- *AdHocDataSource*
- *UserDefinedApi*
- *TestingSolution*
- *StandardSolution*
- *Solution*
- *ScriptedConnector*
- *SlaModel*
- *SampleSolution*
- *ProfileLoadScript*
- *LowCodeApp*
- *LifeCycleServiceOrchestration*
- *FunctionDefinition*
- *EnhancedServiceModel*
- *DataTransformer*
- *DataQuery*
- *Dashboard*
- *ChatOpsExtension*
- *BestPracticesAnalyzer*

To support this change, the search method in the User Catalog API V2 has been updated to a V2 version.

#### 9 July 2024 - Enhancement - Home - Adding time zone when deploying a DaaS system [ID 40121] [ID 40062]

When you deploy a DaaS system from the dataminer.services home page, it is now possible to select the time zone for the DataMiner System you are deploying. By default, the current time zone of the browser is selected.

#### 8 July 2024 - Fix - Catalog API - Empty name for Catalog item in search results [ID 39924]

It could happen that a Catalog item without name was shown in a search result. A name will now always be shown.

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

#### 3 July 2024 - Enhancement - Catalog - Improved alignment of tags and dates on Versions tab [ID 40103]

The layout of the *Versions* tab of Catalog items has been improved so that the tags and dates will now be better aligned.

#### 3 July 2024 - Enhancement - Catalog - Recommended version shown for each published range [ID 40101]

When you open the Versions tab for a Catalog item, recommended versions will now be shown. These are the latest (published) versions of each active range.
