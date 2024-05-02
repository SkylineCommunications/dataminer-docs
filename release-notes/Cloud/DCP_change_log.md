---
uid: DCP_change_log
---

# dataminer.services change log

The dataminer.services platform gets updated continuously. This change log can help you trace when specific features and changes have become available.

> [!NOTE]
> Many features on dataminer.services are dependent on DxMs. You can find the change logs for these under [DxM release notes](xref:DxM_RNs_index).

#### 25 April 2024 - Enhancement - Enable access to more web app folders via Remote Access [ID_39486]

From now on, if Remote Access to the web apps is enabled, this also allows access to the `/Webpages/SRM/` and `/Webpages/assets/` folders, which will be needed for future web app enhancements and features.

#### 25 April 2024 - Enhancement - Settings overhaul [ID_39471]

The dataminer.services settings, configurable from the Admin app, have been enhanced with the following improvements:

- Settings now have a hierarchical structure. Disabled parent settings override their child settings.
- Settings can now also be configured on organization level. If a setting is disabled on organization level, this overrides this same setting for all the DataMiner Systems of this organization, as well as its child settings.
- Settings are now displayed and managed from a separate page for the organization and for each DMS.
- A new setting has been added for Live Sharing (i.e. dashboard sharing).
- In addition to one global Remote Access setting, there are now separate child settings for remote access to Cube, the User-Defined APIs, and the web apps.

#### 25 April 2024 - Enhancement - Catalog - Show DMS issues when deploying a catalog item [ID_39374]

In case deploying a catalog item to a DataMiner System will fail, it will now no longer be possible for users to try to deploy the item to that system, and a documentation link will be shown so the users can resolve the issue.

#### 9 April 2024 - Enhancement - Improvements for DxM deployments from the Admin app [ID_39268]

When a user attempts to upgrade or install a DxM, a check is now performed to verify if all the system requirements are met. If missing requirements are detected, the action is disabled, and a warning is shown. Clicking the warning will show more information on how to resolve the issue.

#### 29 March 2024 - Enhancement - Admin DxM status [ID_39277]

On the nodes overview page in the Admin app, you can now see the status of the DxMs.

#### 28 March 2024 - Fix - Catalog - Typos in error when no DMS is found [ID_39232]

When no DMS is found for an organization, the displayed error will now no longer contain any typos.

#### 28 March 2024 - Enhancement - Admin - Adjusted visibility credits section organization overview [ID_39214]

Regular members of an organization will now no longer be able to see the credits section of the organization overview.

#### 28 March 2024 - New feature - Catalog - Trial deployments [ID_39205]

It is now possible for users without a license for a connector to deploy a trial version. These trial versions should not be used in production environments, as stated in the terms and agreements.

#### 28 March 2024 - Fix - Catalog - Links in organization overview not working correctly [ID_39204]

Links in the DataMiner Systems table of the organization overview will now correctly navigate to the right location.

#### 28 March 2024 - Enhancement - Catalog - Filter on public and/or private items [ID_39026]

On the *Browse* page of the Catalog, you can now filter catalog items so you see only public items, only private items, or both public and private items.

#### 28 March 2024 - Enhancement - Admin - Audit Organization Keys [ID_39023]

It is now possible for admin users to see the permissions of organization keys on the audit detail page.

#### 14 March - Admin - Organization overview overhaul [ID_38960]

The user interface of the Organization overview page has been adjusted to be more in line with upcoming design changes.

It will now include an overview of all DataMiner Systems in a table, which will include the name, URL, and status of each DataMiner System.

#### 11 March 2024 - Enhancement - Ordering DataMiner credits through Azure Marketplace [ID_38909]

You can now order DataMiner credits via the Azure Marketplace. For more information on how to order credits, refer to [Ordering DataMiner credits](xref:Order_DataMiner_credits).

#### 7 March 2024 - Enhancement - Connection status information on dataminer.services now refreshes automatically [ID_38933]

The connection status information is now updated every minute on dataminer.services.

#### 7 March 2024 - Enhancement - Improved support for DataMiner as a Service systems on dataminer.services [ID_38932] [ID_39009]

​The dataminer.services page now has an improved UI when a DataMiner as a Service (DaaS) system is being deployed, with an estimated time left. When a DaaS system is unreachable, an email address is provided to contact support. It is also possible to remove the system while it is still being deployed.

In addition, a problem has been resolved that caused some characters to be invalid in the password field in the deployment form.

#### 29 February 2024 - Enhancement - Admin app UI adjusted [ID_38908]

The header bar and sidebar of the [Admin app](https://admin.dataminer.services) now use a light theme.

#### 29 February 2024 - New feature - Admin - Added organization keys [ID_38944]

In the Admin app, you can now create DCP keys on organization level.

#### 21 February 2024 - Fix - Improved catalog search performance [ID_38865]

The [Catalog](https://catalog.dataminer.services) search has been enhanced to yield results faster.

#### 19 February 2024 - Enhancement - Custom commands executed with the DataMiner bot can request the dataminer.services user email [ID_38826]

It is now possible to know the executor of a custom command executed with the DataMiner bot in Microsoft Teams.

To add a command to your DMS, create an Automation script in the folder "bot" in the DMS. For examples of such scripts, refer to [Custom Command Examples](https://github.com/SkylineCommunications/ChatOps-Extensions/tree/main/CustomCommandExamples) on GitHub.

For more detailed information, refer to [Adding commands for the Teams bot to a DMS](xref:DataMiner_Teams_bot#adding-custom-commands-for-the-teams-bot-to-a-dms).

#### 16 February 2024 - Enhancement - Changed user role required to renew system tokens [ID_38722]

Previously, users had to have the role of Owner of the DMS on dataminer.services to be able to [renew the session](xref:Cloud_Connection_Issues#check-the-cloud-session). From now on, this is also possible for users who have the Admin role.

#### 16 February 2024 - Enhancement - Improved error messages when using remote access [ID_38802]

When you try to use remote access to a DataMiner System via dataminer.services, but this is not possible, from now on a clearer message will be shown on what is the likely cause of the issue, with a link to a dedicated troubleshooting page on docs.dataminer.services.

#### 14 February 2024 - Enhancement - Systems with remote access disabled are now shown on dataminer.services [ID_38772]

DataMiner Systems are now shown on dataminer.services even if remote access is disabled for them. However, the app buttons for such systems will be disabled where necessary. A link to the documentation is provided in the UI for more information about how to change the remote access settings.

#### 13 February 2024 - Fix - Catalog versions displayed in wrong order [ID_38762]

The versions of a catalog item will now be sorted correctly.

#### 9 February 2024 - Enhancement - DMS connection status now visible on dataminer.services [ID_38771]

On the dataminer.services page, you can now see the status of the connection of a DMS to dataminer.services. The status is indicated as *OK*, *Warning*, *Error*, or *Unknown*. If the connection is not available, the app buttons will be disabled.

#### 6 February 2024 - New feature - Chat Integration with Microsoft Teams now includes sending buttons in notifications using Adaptive Cards [ID_38701]

It is now possible to send buttons in notifications using Adaptive Cards to chats or channels with Chat Integration.

Available buttons:

- Prompt to run a custom command (optionally with predefined input values)
- Open URL
- Get element
- Get alarms of an element
- Get alarms of a view
- Prompt to change the active DMS of the conversation

In an Automation script, you can use [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) to easily interact with Microsoft Teams.

To get started, you can find several example Automation scripts with more information on [GitHub](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples).

After you have made sure that the [prerequisites](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#usage) are in place, you can deploy [the Chat Integration examples](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#getting-started) to your DataMiner System and immediately try out these examples.

#### 6 February 2024 - New feature - Custom commands executed with the DataMiner bot now support adding buttons to the response using Adaptive Cards [ID_38701]

It is now possible to send buttons in custom command responses using Adaptive Cards.

Available buttons:

- Prompt to run a custom command (optionally with predefined input values)
- Open URL
- Get element
- Get alarms of an element
- Get alarms of a view
- Prompt to change the active DMS of the conversation

In an Automation script, you can use [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) to easily interact with Microsoft Teams.

To add a command to your DMS, create an Automation script in the folder "bot" in the DMS. For examples of such scripts, refer to [Custom Command Examples](https://github.com/SkylineCommunications/ChatOps-Extensions/tree/main/CustomCommandExamples) on GitHub.

For more detailed information, refer to [Adding commands for the Teams bot to a DMS](xref:DataMiner_Teams_bot#adding-custom-commands-for-the-teams-bot-to-a-dms).

#### 23 January 2024 - Fix - Unknown error when accessing the web apps remotely [ID_38549]

While remote access was used to go to the web apps via dataminer.services (e.g. the Monitoring app), the following message could appear: `An unknown error occurred (status: 200).` The app would also stop working until the page was refreshed. This issue has been resolved.

#### 12 January 2024 - Fix - The given username was not applied when deploying a DaaS system

When a custom username was given when deploying a new DaaS system, the default username (Administrator) was still used. The user will now be created with the custom username.

#### 12 January 2024 - New feature - Remote access for custom files/webpages [ID_38426]

It is now possible to provide remote access via dataminer.services to files or webpages. To do so, add them in the folder `C:\Skyline DataMiner\Webpages\public\` on your DMA. To access such files, users can use the remote access URL followed by `/public/` (e.g. the file *image.png* via `https://ziine-skyline.on.dataminer.services/public/image.png`).

#### 4 January 2024 - New feature - Chat Integration with Microsoft Teams now includes sending notification using Adaptive Cards [ID_38339]

It is now possible to send notifications using Adaptive Cards to chats or channels with Chat Integration.

In an Automation script, you can use [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) to easily interact with Microsoft Teams.

To get started, you can find several example Automation scripts with more information on [GitHub](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples).

After you have made sure that the [prerequisites](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#usage) are in place, you can deploy [the Chat Integration examples](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#getting-started) to your DataMiner System and immediately try out these examples.

#### 20 December 2023 - Enhancement - Email notifications for expiring and expired DataMiner Community Edition DaaS systems [ID_38235]

From now onwards, when a DataMiner Community Edition DaaS system is about to expire, an email notification will be sent to both the owners of the organization and the owners of the DMS, so that they can take action if they want to prevent deletion. Another email notification will be sent when the DataMiner Community Edition DaaS system has been deleted.

A notification will also be sent when an organization owns multiple DaaS systems and it will not be possible to extend one or more of these systems because the organization will not have enough DataMiner credits, as predicted based on the current usage.

#### 13 December 2023 - New feature - Email notifications for expiring and expired DataMiner Community Edition DaaS systems [ID_38183]

From now onwards, when a DataMiner Community Edition DaaS system is about to expire, an email notification will be sent to the owners of the organization and the person who deployed the DaaS system, so that they can take action if they want to prevent deletion. Another email notification will be sent when the DataMiner Community Edition DaaS system has been deleted.

#### 6 December 2023 - New feature - Remote Access setting is now checked for user-defined API access [ID_38102]

Users will now only be able to access a user-defined API using the remote access URL if the Remote Access setting is enabled in the Admin app.

#### 4 December 2023 - New feature - DataMiner as a Service for staging systems [ID_38087]

It is now possible to create a [DataMiner as a Service (DaaS)](xref:Creating_a_DMS_in_the_cloud) system on dataminer.services for staging systems.

Our [Pay-per-Use](xref:Pricing_Commercial_Models#pay-per-use) model is used for this: When you deploy such a DaaS system, 3 DataMiner credits will be deducted from your organization every week. In case your organization runs out of DataMiner credits, the DaaS system will be deleted. By default, every organization is provided with 3 DataMiner credits, so you can try out a DaaS system for one week free of charge.

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

#### 21 November 2023 - New feature - Remote access using DataMiner Cube [ID_37841]

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

#### 26 September 2023 - Fix - Remote Access automatic login now works with special characters in DataMiner account configuration [ID_37438]

If your DataMiner account contained one or more special characters, for example in the full name field, and you used Remote Access (e.g. the Monitoring app via dataminer.services), it was not possible to log in. Now you can log in automatically with your linked DataMiner account.

> [!NOTE]
> If you log in manually, you will still encounter this issue: This will not work when you have one or more special characters configured in your DataMiner account. To resolve this, [link your DataMiner account to your dataminer.services account](https://aka.dataminer.services/account-linking). The automatic login will allow you to use Remote Access without requiring any further actions.

#### 20 September 2023 - Enhancement - Admin app - Nodes page responsiveness improved [ID_37403]

Performance has improved when node and DxM information is retrieved on the *Nodes* page of a DataMiner System in the Admin app.

#### 22 August 2023 - Enhancement - Admin app - Audit Record Export (CSV) [ID_37164]

In the [Admin app](https://admin.dataminer.services), a new feature has been introduced on the *Audit* page, allowing users to export audit records in a CSV file. Clicking *Export* in the top-left corner will initiate the export process. A pop-up window will appear, where you can choose the separator to be used in the CSV file, as well as whether to include column titles at the top of the exported CSV file. Once the file has been generated, you will receive an email containing a link to download the CSV file. The download link included in the email will be valid for a period of 7 days.

#### 3 July 2023 - Fix - Admin app - Organization user overview will display all DMSs of each user correctly [ID_36795]

In the Admin app, when an organization user had more than one DMS, only the last DMS would be shown in the organization user overview and its details overlay. This issue has now been resolved.

#### 16 June 2023 - Fix - Chat Integration with Microsoft Teams: Improved consistency for email inputs [ID_36643]

Consistency for the Chat Integration email input has been improved.

Previously, some features were using the email input as the actual email address of the user, and some were using it as the service principal name of the user. This was not an issue if both had the same value in the linked tenant. However, if the values differed, some features like "Create Team" and "Add Team Member or Owner" did not work unless the actual service principal name was given.

This is now no longer the case. All email input for all Chat Integration features behaves the same as the email address set for the user in the tenant.

#### 30 May 2023 - Enhancement - Catalog - Notification when deploying from the catalog [ID_36543]

When you deploy something (e.g. a connector) from the catalog to a DMA, a notification will now indicate if the deployment has started properly. The notification also contains a link to the Admin page, where you can view the status of the deployment.

#### 11 May 2023 - Enhancement - Easier sharing of deployment records [ID_36398]

When you select a deployment record on the *Deployments* page of the Admin app, the URL of the app is now updated with a query parameter referencing the ID of the deployment. This allows you to share this URL with someone to immediately show them that deployment.

#### 3 April 2023 - New Feature - Chat Integration with Microsoft Teams now includes fetching teams and channels [ID_35983]

The following Chat Integration features have been added:

- Fetching all teams
- Fetching all channels of a team, so you can send channel notifications in them

In an Automation script, you can use [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) to easily interact with Microsoft Teams.

To get started, you can find several example Automation scripts with more information on [GitHub](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples).

After you have made sure that the [prerequisites](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#usage) are in place, you can deploy [the Chat Integration examples](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#getting-started) to your DataMiner System and immediately try out these examples.

> [!NOTE]
> To enable these additional features, you **must grant Skyline admin consent to your Microsoft tenant with certain permissions, even if you have already granted admin consent before.** See [granting admin consent](xref:Granting_admin_consent). You can revoke these permissions at any time.

#### 30 March 2023 - Fix - Sharing app: Confirmation pop-up window not visible [ID_36029]

In the Sharing app, depending on the position of the scrollbar, it could occur that the confirmation pop-up window for the deletion of an incoming share was displayed outside the boundaries of the screen, so that it was not possible to confirm the deletion.

#### 2 March 2023 - Integrate your DataMiner System with Microsoft Teams using DataMiner Automation [ID_35799]

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

#### 9 February 2023 - Fix - Remote access actions incorrectly blocked [ID_35594]

In some cases, it could occur that requests were incorrectly blocked as unsafe when you used the remote access feature. For example, this could occur when you clicked the Home button in the top-left corner of a web app.

#### 13 January 2023 - Enhancement - Auditing of protocol and script deployments [ID_35392]

The *Audit* page of the Admin app will now also contain records for protocol and script deployments, while previously it only showed records for DxM artifact deployments.

Deploying protocols can be done via the [DataMiner Catalog](https://catalog.dataminer.services/), deploying scripts can be done with a GitHub or GitLab CI/CD pipeline, and deploying DxMs can be done with the Admin app.

#### 10 January 2023 - Enhancement - Audit log whenever Skyline's Support team uses Remote Log Collection [ID_35165]

Every time Skyline's Support Team uses the Remote Log Collection feature on a DataMiner Agent, an audit log will now be created on dataminer.services. You can view these logs on the *Audit* page of the [Admin app](https://admin.dataminer.services).

#### 8 December 2022 - Enhancement - New endpoints for dataminer.services connection and sharing [ID_35127]

For connection and share management, new endpoints will now be used instead of the `https://admin.dataminer.services/*` endpoint:

- Connecting a DMS to dataminer.services will use the endpoint `https://connection.dataminer.services/*`.
- Creating and managing shares will use the endpoint `https://sharing.dataminer.services/*`.

#### 8 December 2022 - Enhancement - MSAL 2.0 implementation [ID_35126]

A new version of MSAL has been implemented. This will result in faster and more stable authentication, which will also be updated more frequently.

In addition, when the Admin app is authenticating, it will now display a loading icon.

#### 6 December 2022 - Enhancement - Improved audit events for dashboard shares [ID_35087]

When shares are created, accessed, updated, or deleted, the audit events on the Audit page of the Admin app will now include the name of the shared dashboard and a link to the dashboard. To navigate to the dashboard, users will need to have access to the dashboard.

#### 6 December 2022 - Enhancement - Audit events for DMS and organization user CUD actions [ID_35086]

When DMS or organization users are created, updated, or deleted, audit events will now be added on the Audit page of the Admin app.

#### 18 October 2022 - Enhancement - Notification in case deployment fails because account is not linked [ID_34699]

When a deployment fails because the user does not have a linked account, they will now get a notification that will allow them to correct the situation and retry.

#### 18 October 2022 - Enhancement - Admin app supports additional audit events [ID_34697]

The Admin app now also includes the following audit events on the *Audit* page:

- A user created a dashboard share.
- A user performed an updated to an existing share.
- A user deleted an existing share.

Up to now, only accessing a share was logged in the audit events.

#### 27 September 2022 - New feature - DataMiner Teams bot support for custom commands [ID_34518]

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

#### 19 September 2022 - Enhancement - Improvements on Audit page in Admin app [ID_34457]

A number of improvements have been implemented on the *Audit* page in the Admin app:

- You can now filter on subject name and initiator.
- A search box is now available for each filter so you can quickly search for a specific item to filter on.
- Some filters allow you to manually specify custom values. For example, for the *Initiator* filter, which is automatically populated with the organization users, you can manually specify a user that has been deleted.
- The column order has been adjusted.
- Automatic loading of audit records has been improved to prevent possible issues with different screen sizes.

#### 1 September 2022 - Enhancement - Filter functionality for Audit log in Admin app [ID_34322]

The Audit log in the Admin app now allows filtering on operation type, subject type, DataMiner System name, and time span. In addition, the loading of records has been optimized.

#### 18 August 2022 - New feature - Audit and license information added in Admin app [ID_34216]

In the Admin app, the license expiration date for an organization is now displayed on that organization's *Overview* page.

In addition, a new *Audit* page is available in the app, which contains auditing logs for sharing dashboards and dataminer.services keys.

#### 17 June 2022 - Enhancement - Admin app opens to Overview page [ID_33772]

When you open the Admin app, it will now immediately show the *Overview* page of the selected organization. Previously, it showed a page that only contained "Home".

#### 17 June 2022 - Enhancement - Admin icon available for all users [ID_33770]

The icon to access the Admin app is now available for all users on the `dataminer.services` home page. Previously, this was only available for admins and owners.

#### 10 June 2022 10 - New feature - New 'Outgoing Shares' page in Admin app [ID_33723]

In the Admin app, a new *Outgoing Shares* page is now available for each DataMiner System connected to dataminer.services. This page lists all items that have been shared via dataminer.services from the selected DMS.

When you click a shared item in the overview, more detailed information will be displayed, including the time when it was shared and when the share will expire.

#### 10 June 2022 10 - Enhancement - Pages in Admin app sidebar not shown for users without required permissions [ID_33708]

If you do not have the required permissions to use a specific page for a DMS in the Admin app, this page will no longer be shown when you select a DMS in the sidebar of the app.

#### 10 June 2022 10 - New feature - New 'Deployments' page in Admin app [ID_33707] [ID_33709] [ID_33724]

In the Admin app, a new *Deployments* page is now available for each DataMiner System connected to dataminer.services. This page provides information about all the deployments that have been done to the DataMiner System via the Nodes page, via the Catalog, or using a GitHub pipeline with our GitHub action. It details what has been deployed, when and by whom, and whether the deployment succeeded, is pending, or failed.

When you click a deployment in the overview, more detailed information will be displayed, including version information and event information that can be used for debugging. For example, in case a pending deployment is queued because of other deployments, you will be able to see this in the event information.

#### 3 June 2022 - New feature - dataminer.services keys [ID_33606]

You can now use dataminer.services keys. At present, these can be used with the [GitHub action to deploy Automation scripts](https://github.com/marketplace/actions/skyline-dataminer-deploy-action) to a DMS connected to dataminer.services. However, more functionality requiring a dataminer.services key is expected to be implemented in the future.

In the Admin app, you can manage the dataminer.services keys on the *Keys* page for each DataMiner System connected to dataminer.services. Each set of keys consists of a (user-defined) label, a primary key, and a secondary key. Inline buttons are available that allow you to view or copy a key. Simply clicking a key entry in the list will open a side panel with detailed information, including when the keys were created and by whom.

For each set of keys, the *...* button on the right opens a menu where you can regenerate the primary key, regenerate the secondary key, or revoke (i.e. delete) the key. With the *New Key* option at the top of the page, you can add more keys.

#### 3 June 2022 - New feature - Admin app sidebar redesigned [ID_33599]

The layout of the Admin app has been improved. The blue icon bar on the left has been removed and the sidebar has been redesigned into two sections: *Organization* and *DataMiner Systems*. In the *DataMiner Systems* section, you can expand and collapse each connected DMS to view the available pages for that DMS.

#### 19 May 2022 - Fix - Notification when removing user showed placeholder [ID_33383]

When a user was removed in the Admin app, the displayed notification contained a placeholder instead of the relevant email address.

#### 6 May 2022 - New feature - DataMiner Teams bot v1.2 [ID_33422]

A new version of the DataMiner Teams bot is now available. If you use the command *show view [View name]* with this new version, the DataMiner Teams bot will display the visual overview of the specified view, as well as the alarm status and the number of active alarms. With the buttons in the response, you can request the alarms of the view or open the view in the Monitoring app via remote access.

In addition, all links to documentation in the app have been adjusted to link to <https://docs.dataminer.services/>.

#### 2 May 2022 - Fix - Not possible to delete share without users [ID_33366]

If a share was not valid because all users had removed themselves from it, it could occur that it was not possible to delete that share. This issue has now been resolved.

#### 14 Apr. 2022 - New feature - Managing nodes connected to dataminer.services [ID_33081] [ID_33127]

In the Admin app, you can now manage the nodes of DataMiner Systems that are connected to dataminer.services. You can upgrade the installed DxM versions on the nodes and remove nodes that have become obsolete. In case a node has a higher DxM version installed than the current version, it is also possible to downgrade that node.

Note that DataMiner Cloud Pack version 2.5.0 or higher must be installed on the nodes, as otherwise they will not be listed in the Admin app.

> [!IMPORTANT]
> If you are using an IP-based firewall, from now on you will need to add `20.31.240.20` to the allowed IP addresses to be able to connect to dataminer.services.

#### 5 Apr. 2022 - New feature - Admin app no longer shown by default on home page [ID_33090]

The Admin app will now only be shown on the dataminer.services home page for users who are the owner/admin of an organization and/or of a DataMiner System.

#### 5 Apr. 2022 - New feature - Non-dataminer.services users now notified about needing to connect to dataminer.services [ID_33089]

When a user of a DMS that is not yet connected to dataminer.services goes to <https://dataminer.services/>, they will now be informed that they are not yet connected, and a link will be provided to more information about dataminer.services.

#### 28 Feb. 2022 - New feature - dataminer.services connection verification [ID_32741]

In the Admin app, on the *Organization > Manage* page, users can now click a button to send an email to Skyline to have their dataminer.services connection verified. This verification ensures access to the latest dataminer.services features, including the ability to install protocols directly from the dataminer.services catalog.

When the verification has been successful, this will be indicated on this same page.

#### 23 Feb. 2022 - New feature - Removing a share [ID_32695]

In the *Sharing* module, you can now remove a share. When you do so, you indicate that you no longer wish to have access to the shared item. The item will no longer be available to you, unless it is shared with you again.

#### 12 Jan. 2022 - New feature - Support for app package deployment [ID_32210]

Support has been added for the deployment of app packages to a specific DMS connected to dataminer.services. However, note that the UI to deploy app packages is not yet available at this point.
