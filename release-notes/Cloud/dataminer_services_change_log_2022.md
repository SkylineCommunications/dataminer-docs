---
uid: dataminer_services_change_log_2022
---

# dataminer.services change log - 2022

This change log can help you trace when specific features and changes became available on the dataminer.services platform in 2022.

> [!NOTE]
> Many features on dataminer.services are dependent on DxMs. You can find the change logs for these under [DxM release notes](xref:DxM_RNs_index).

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

To add a command to your DMS, create an automation script in the folder "bot" in the DMS. For examples of such scripts, refer to [Custom Command Examples](https://github.com/SkylineCommunications/ChatOps-Extensions/tree/main/CustomCommandExamples) on GitHub.

The commands allow dynamic input, such as dummies, parameters, parameters with value files, and memory files. They support the following output: key values, adaptive card body elements, and JSON.

A command will only be visible for users of the bot if they have the appropriate rights in DataMiner Cube. If users have the necessary rights to view a command, but they do not have the rights needed for certain input for the command, the bot will inform them that the command cannot be executed.

The following limitations also apply:

- Interactive automation scripts are not supported.
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

You can now use dataminer.services keys. At present, these can be used with the [GitHub action to deploy automation scripts](https://github.com/marketplace/actions/skyline-dataminer-deploy-action) to a DMS connected to dataminer.services. However, more functionality requiring a dataminer.services key is expected to be implemented in the future.

In the Admin app, you can manage the dataminer.services keys on the *Keys* page for each DataMiner System connected to dataminer.services. Each set of keys consists of a (user-defined) label, a primary key, and a secondary key. Inline buttons are available that allow you to view or copy a key. Simply clicking a key entry in the list will open a side panel with detailed information, including when the keys were created and by whom.

For each set of keys, the *...* button on the right opens a menu where you can regenerate the primary key, regenerate the secondary key, or revoke (i.e., delete) the key. With the *New Key* option at the top of the page, you can add more keys.

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
