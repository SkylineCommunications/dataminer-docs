---
uid: dataminer_services_change_log_2023
---

# dataminer.services change log - 2023

This change log can help you trace when specific features and changes became available on the dataminer.services platform in 2023.

> [!NOTE]
> Many features on dataminer.services are dependent on DxMs. You can find the change logs for these under [DxM release notes](xref:DxM_RNs_index).

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

#### 29 November 2023 - Enhancement - Extra validation on the username field [ID 37951]

When a [DataMiner as a Service (DaaS)](xref:Creating_a_DMS_in_the_cloud) system is deployed, the username will now be validated to ensure that no usernames can be added that are longer than 64 characters or that contain special characters.

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

#### 26 July 2023 - Enhancement - Admin app - Upgrade warnings for DxMs [ID 36801]

Upgrading a DxM to a version which requires .NET 6 will now show a warning to inform the user about the requirement and how to install it on their system.

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

In an automation script, you can use [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) to easily interact with Microsoft Teams.

To get started, you can find several example automation scripts with more information on [GitHub](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples).

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

In an automation script, you can use [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) to easily interact with Microsoft Teams.

To get started, you can find several example automation scripts with more information on [GitHub](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples).

After you have made sure the [prerequisites](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#usage) are in place, you can deploy [the Chat Integration examples](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#getting-started) to your DataMiner System and immediately try out these examples.

> [!NOTE]
> You must grant Skyline admin consent to your Microsoft tenant with certain permissions to enable these features. See [granting admin consent](xref:Granting_admin_consent). You can revoke these permissions at any time.

#### 10 February 2023 - Improved UX for share management [ID 35519]

The share management app has been improved:

- Users will no longer briefly see an unexpected form before the correct form loads, thanks to a new loading screen.
- Users without the necessary permissions will no longer see an incorrect page. Instead, an appropriate error message will now be displayed.
- Fatal errors will now be shown via notifications, which will remain displayed until dismissed by the user.

#### 9 February 2023 - Fix - Remote access actions incorrectly blocked [ID 35594]

In some cases, it could occur that requests were incorrectly blocked as unsafe when you used the remote access feature. For example, this could occur when you clicked the Home button in the top-left corner of a web app.

#### 13 January 2023 - Enhancement - Auditing of protocol and script deployments [ID 35392]

The *Audit* page of the Admin app will now also contain records for protocol and script deployments, while previously it only showed records for DxM artifact deployments.

Deploying protocols can be done via the [Catalog](https://catalog.dataminer.services/), deploying scripts can be done with a GitHub or GitLab CI/CD pipeline, and deploying DxMs can be done with the Admin app.

#### 10 January 2023 - Enhancement - Audit log whenever Skyline's Support team uses Remote Log Collection [ID 35165]

Every time Skyline's Support Team uses the Remote Log Collection feature on a DataMiner Agent, an audit log will now be created on dataminer.services. You can view these logs on the *Audit* page of the [Admin app](https://admin.dataminer.services).
