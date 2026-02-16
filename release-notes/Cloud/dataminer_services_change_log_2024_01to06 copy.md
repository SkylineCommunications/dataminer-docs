---
uid: dataminer_services_change_log_2024_01to06
---

# dataminer.services change log - 2024 (January-June)

This change log can help you trace when specific features and changes became available on the dataminer.services platform in 2024, from January to June.

> [!NOTE]
> Many features on dataminer.services are dependent on DxMs. You can find the change logs for these under [DxM release notes](xref:DxM_RNs_index).

#### 24 June 2024 - Fix - Catalog - Problem looking up item without versions [ID 40009]

Up to now, if a user searched for a public Catalog item without versions, it could occur that the correct result could not be displayed even if the user was a member of the appropriate organization to view the item.

#### 19 June 2024 - Fix - Remote Access and Live Sharing connection failing when DMA went offline [ID 39983]

Up to now, if the connected DMA that was used to serve the web API requests for Remote Access or Live Sharing went offline, e.g., when switching in a Failover setup, the connection did not switch to another online DMA in the DMS. Instead it kept trying to connect to the initial DMA even though it was offline, causing Remote Access or Live Sharing not to work until the browser cookies were cleared. This issue has now been resolved. Automatic login issues caused by this same issue have also been resolved.

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

​After registering an item, users will now get a link to the documentation guiding them to the next step, i.e., uploading a version.

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

#### 30 May 2024 - Enhancement - Home - DaaS error messages [ID 39810] [ID 39815]

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

You can do so by adding `--skipconfirmation`, or in short `--sc`, at the end of your command. For example, for a custom command automation script named "toggle switch", you could use the command `run toggle switch --sc`.

A new version of (1.2.3) [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) has also been released, which allows you to skip the confirmation on custom buttons in Adaptive Cards.

#### 16 May 2024 - Fix - Catalog - Legacy routes not resolved correctly [ID 39653]

When a user navigates to a legacy URL of the Catalog application, it will now redirect to the correct page.

#### 16 May 2024 - New feature - Catalog - New apps menu [ID 39621]

Clicking the logo in the top-left corner of the Catalog app will now open a new apps menu, which will allow users to easily navigate to the other dataminer.services apps.

#### 16 May 2024 - Enhancement - Admin - Message in DMS overview when latest CoreGateway version is not installed for Failover Agent [ID 39677] [ID 39678]

In the DMS overview in the Admin app, when applicable, a message will now be shown to notify the Admin user that both Agents in a Failover pair need to have the latest CoreGateway DxM version installed so that more information about Failover can be retrieved.

#### 16 May 2024 - Enhancement - Admin - Organization and DMS settings audits [ID 39669] [ID 39679]

From now on, changing settings for an organization or DMS in the Admin app will generate audit logs. See [consulting dataminer.services audit logs](xref:Auditing).

#### 16 May 2024 - Fix - Catalog - Incorrect success message after registering an item [ID 39652]

The message that is shown when the registration of a Catalog item is successful incorrectly referred to a GitHub workflow. Now, it will instead specify that you can use the returned ID in an API call.

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

#### 25 April 2024 - Fix - Not possible to deploy a DaaS system for a new organization [ID 39386]

When a new organization was made, it could occur that new DaaS systems created for that organization were not properly loaded on dataminer.services.

#### 25 April 2024 - Enhancement - Catalog - Show DMS issues when deploying a catalog item [ID 39374]

In case deploying a catalog item to a DataMiner System will fail, it will now no longer be possible for users to try to deploy the item to that system, and a documentation link will be shown so the users can resolve the issue.

#### 25 April 2024 - Enhancement - Settings overhaul [ID 39246] [ID 39471]

The dataminer.services settings, configurable from the Admin app, have been enhanced with the following improvements:

- Settings now have a hierarchical structure. Disabled parent settings override their child settings.
- Settings can now also be configured on organization level. If a setting is disabled on organization level, this overrides this same setting for all the DataMiner Systems of this organization, as well as its child settings.
- Settings are now displayed and managed from a separate page for the organization and for each DMS.
- A new setting has been added for Live Sharing (i.e., dashboard sharing).
- In addition to one global Remote Access setting, there are now separate child settings for remote access to Cube, the User-Defined APIs, and the web apps.

#### 25 April 2024 - Enhancement - Catalog API - CanDeploy call now uses DxM health information [ID 39125]

The call to verify if a user can deploy a Catalog item will now take into account the health of the DxMs in the system.

#### 9 April 2024 - Enhancement - Improvements for DxM deployments from the Admin app [ID 39116] [ID 39268]

When a user attempts to upgrade or install a DxM, a check is now performed to verify if all the system requirements are met. If missing requirements are detected, the action is disabled, and a warning is shown. Clicking the warning will show more information on how to resolve the issue.

#### 5 April 2024 - Enhancement - Deploy call no longer performs a license check for connectors [ID 39149]

The call to deploy a Catalog item will no longer verify if a license exists for a user. Every user is now allowed to try out a connector.

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

#### 7 March 2024 - Fix - dataminer.services connection - Organization with invalid DNS characters resulted in incomplete DNS name [ID 38971]

When the name of an organization on dataminer.services contained invalid DNS characters, this could result in an incomplete DNS name. Now creating an organization with invalid characters for DNS name creation is prevented. When you try to create such an organization, a message will inform you that any invalid characters must be removed.

#### 7 March 2024 - Enhancement - Connection status information on dataminer.services now refreshes automatically [ID 38933]

The connection status information is now updated every minute on dataminer.services.

#### 7 March 2024 - Enhancement - Improved support for DataMiner as a Service systems on dataminer.services [ID 38932] [ID 39009]

​The dataminer.services page now has an improved UI when a DataMiner as a Service (DaaS) system is being deployed, with an estimated time left. When a DaaS system is unreachable, an email address is provided to contact support. It is also possible to remove the system while it is still being deployed.

In addition, a problem has been resolved that caused some characters to be invalid in the password field in the deployment form.

#### 29 February 2024 - New feature - Admin - Added organization keys [ID 38944]

In the Admin app, you can now create dataminer.services keys on organization level.

#### 29 February 2024 - Fix - Catalog search showed incorrect empty result [ID 38921]

When a search was performed in the Catalog and Enter was pressed before a result was received, a "no results" message would be displayed in the browse page even if results were actually available.

#### 29 February 2024 - Enhancement - Admin app UI adjusted [ID 38908]

The header bar and sidebar of the [Admin app](https://admin.dataminer.services) now use a light theme.

#### 29 February 2024 - Enhancement - Catalog deployment failure notifications [ID 38905]

When a Catalog deployment failed because it could not be sent to the DMA, up to now, there was no indication of this. Now the user will be notified in such a case.

#### 29 February 2024 - Fix - Setup dataminer.services connection for user not in an organization [ID 38894]

If a user was not yet a member of an organization on dataminer.services, up to now, if they tried to connect a DMS to dataminer.services, this would fail.

#### 27 February 2024 - Enhancement - Improved pagination of search results [ID 38833]

When a search request in the Catalog returns data results, the max page size requested by the client will now be taken into account.

#### 21 February 2024 - Fix - Improved catalog search performance [ID 38865]

The [Catalog](https://catalog.dataminer.services) search has been enhanced to yield results faster.

#### 19 February 2024 - Enhancement - Custom commands executed with the DataMiner bot can request the dataminer.services user email [ID 38826]

It is now possible to know the executor of a custom command executed with the DataMiner bot in Microsoft Teams.

To add a command to your DMS, create an automation script in the folder "bot" in the DMS. For examples of such scripts, refer to [Custom Command Examples](https://github.com/SkylineCommunications/ChatOps-Extensions/tree/main/CustomCommandExamples) on GitHub.

For more detailed information, refer to [Adding commands for the Teams bot to a DMS](xref:DataMiner_Teams_bot#adding-custom-commands-for-the-teams-bot-to-a-dms).

#### 16 February 2024 - Fix - Incorrect Catalog API license check [ID 38803]

It could occur that a "Not licensed" message was shown for a connector even if the user had the necessary license. Now, the licensing will be verified properly.

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

In an automation script, you can use [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) 1.2.1 to easily interact with Microsoft Teams.

To get started, you can find several example automation scripts with more information on [GitHub](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples).

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

In an automation script, you can use [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) 1.2.1 to easily interact with Microsoft Teams.

To add a command to your DMS, create an automation script in the folder "bot" in the DMS. For examples of such scripts, refer to [Custom Command Examples](https://github.com/SkylineCommunications/ChatOps-Extensions/tree/main/CustomCommandExamples) on GitHub.

For more detailed information, refer to [Adding commands for the Teams bot to a DMS](xref:DataMiner_Teams_bot#adding-custom-commands-for-the-teams-bot-to-a-dms).

#### 23 January 2024 - Fix - Unknown error when accessing the web apps remotely [ID 38549]

While remote access was used to go to the web apps via dataminer.services (e.g., the Monitoring app), the following message could appear: `An unknown error occurred (status: 200).` The app would also stop working until the page was refreshed. This issue has been resolved.

#### 12 January 2024 - Fix - The given username was not applied when deploying a DaaS system

When a custom username was given when deploying a new DaaS system, the default username (Administrator) was still used. The user will now be created with the custom username.

#### 12 January 2024 - New feature - Remote access for custom files/webpages [ID 38426]

It is now possible to provide remote access via dataminer.services to files or webpages. To do so, add them in the folder `C:\Skyline DataMiner\Webpages\public\` on your DMA. To access such files, users can use the remote access URL followed by `/public/` (e.g., the file *image.png* via `https://ziine-skyline.on.dataminer.services/public/image.png`).

#### 4 January 2024 - New feature - Chat Integration with Microsoft Teams now includes sending notification using Adaptive Cards [ID 38339]

It is now possible to send notifications using Adaptive Cards to chats or channels with Chat Integration.

In an automation script, you can use [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) 1.2.0 to easily interact with Microsoft Teams.

To get started, you can find several example automation scripts with more information on [GitHub](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples).

After you have made sure that the [prerequisites](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#usage) are in place, you can deploy [the Chat Integration examples](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#getting-started) to your DataMiner System and immediately try out these examples.
