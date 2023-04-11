---
uid: DCP_change_log
---

# dataminer.services change log

The dataminer.services platform gets updated continuously. This change log can help you trace when specific features and changes have become available.

#### 7 April 2023 - Fix - CoreGateway 2.12.1 - Long-running deployment fails [ID_36121]

When a user deployed a package on a DataMiner Agent using dataminer.services, and the deployment took more than 3 minutes, it could occur that this failed. In the Admin app, an exception like the following example could be displayed:

```txt
Exception encountered during installation: (Code: 0x800402EB) Skyline.DataMiner.Net.Exceptions.DataMinerSecurityException: No such remote connection (e839324188).
```

#### 7 April 2023 - Fix - Orchestrator 1.3.2 - Orchestrator DxM uninstalled after attempt to update it on Window Server 2016 [ID_36106]

When the DataMiner Orchestrator DxM was updated via the Admin app on Window Server 2016, it could occur that the service was uninstalled but not updated.

#### 3 April 2023 - Chat Integration with Microsoft Teams now includes fetching teams and channels [ID_35983]

The following Chat Integration features have been added:

- Fetching all teams
- Fetching all channels of a team, so you can send channel notifications in them

In an Automation script, you can use [the DcpChatIntegrationHelper NuGet](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper) to easily interact with Microsoft Teams.

To get started, you can find several example Automation scripts with more information on [GitHub](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples).

After you have made sure that the [prerequisites](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#usage) are in place, you can deploy [the Chat Integration examples](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#getting-started) to your DataMiner System and immediately try out these examples.

> [!NOTE]
> To enable these additional features, you **must grant Skyline admin consent to your Microsoft tenant with certain permissions, even if you have already granted admin consent before.** See [granting admin consent](xref:Granting_admin_consent). You can revoke these permissions at any time.

#### 3 April 2023 - Enhancement - ArtifactDeployer 1.4.3 - Dependencies updated [ID_35990]

Several dependencies have been updated. This includes security-related improvements.

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

#### 16 February 2023 - Fix - CloudGateway 2.10.3 - Share not created in case of mismatch in local culture on hosting server [ID_35654]

Prior to CloudGateway version 2.10.3, a share could not be created if there was a mismatch in the local culture on the hosting server.

#### 9 February 2023 - Fix - Remote access actions incorrectly blocked [ID_35594]

In some cases, it could occur that requests were incorrectly blocked as unsafe when you used the remote access feature. For example, this could occur when you clicked the Home button in the top-left corner of a web app.

#### 24 January 2023 - Fix - SupportAssistant 1.2.1 - Log Collector continuously triggered after failing to generate files [ID_35457]

In some rare cases, if invalid arguments were passed to the Log Collector so that it could not generate files, it could occur that the Log Collector kept getting triggered by the SupportAssistant DxM. Now the SupportAssistant will stop after a specific number of attempts.

This fix is included in Cloud Pack 2.8.5.

#### 13 January 2023 - Enhancement - Auditing of protocol and script deployments [ID_35392]

The *Audit* page of the Admin app will now also contain records for protocol and script deployments, while previously it only showed records for DxM artifact deployments.

Deploying protocols can be done via the [DataMiner Catalog](https://catalog.dataminer.services/), deploying scripts can be done with a GitHub or GitLab CI/CD pipeline, and deploying DxMs can be done with the Admin app.

#### 12 January 2023 - Fix - CloudGateway 2.10.2 - CloudGateway not starting if DataMiner uses HTTP [ID_35362]

When DataMiner was configured to use HTTP, prior to version 2.10.2, CloudGateway could fail to start up, and it could throw the following exception:

```txt
Something went wrong while initializing WebApiEndpointService. A url in the (custom.)appsettings.json or maintenancesettings.xml is malformed or empty while a valid value was expected. See exception System.ArgumentNullException: Value cannot be null. (Parameter 'dataMinerWebApiHttpFormat')
```

This fix is included in Cloud Pack 2.8.5.

#### 10 January 2023 - Enhancement - CoreGateway 2.12.0 - Support for new Data Aggregator DxM [ID_34903] [ID_35168] [ID_35217] [ID_35252]

To support the new [Data Aggregator DxM](xref:DataAggregator_1.0.0), CoreGateway has been adjusted to be able to handle requests from Data Aggregator.

This enhancement is included in Cloud Pack 2.8.4.

#### 10 January 2023 - Enhancement - DataMiner SupportAssistant 1.2.0 - Various stability improvements [ID_35349]

Various general stability improvements have been implemented. In addition, eventing has been added to dataminer.services, so that the Skyline Support Team can follow up on the status of remote log collection.

This enhancement is included in Cloud Pack 2.8.4.

#### 10 January 2023 - Enhancement - Audit log whenever Skyline's Support team uses Remote Log Collection [ID_35165]

Every time Skyline's Support Team uses the Remote Log Collection feature on a DataMiner Agent, an audit log will now be created on dataminer.services. You can view these logs on the *Audit* page of the [Admin app](https://admin.dataminer.services).

#### 10 January 2023 - Fix - DataMiner CoreGateway 2.12.0 - Problem with CoreGateway after server restart [ID_34961]

After a server restart, a startup race condition could cause issues in the CoreGateway, which could for example cause the DataMiner Teams bot to be unresponsive. The NATS Message Broker dependency has been updated to prevent this issue.

This fix is included in Cloud Pack 2.8.4.

#### 22 December 2022 - Fix - CloudGateway 2.10.1 - Connection tester did not take proxy settings into account [ID_35227]

If proxy settings were configured in the *appsettings.proxy.json* file, previously these were not taken into account by the connection tester tool.

This fix is included in Cloud Pack 2.8.4.

#### 19 December 2022 - Fix - SupportAssistant 1.1.1 - Log collection triggered too often [ID_35158]

A problem with the SupportAssistant could cause the Log Collector to be triggered again and again, which could make it use up a lot of disk space.

This fix is included in Cloud Pack 2.8.3.

#### 16 December 2022 - Fix - ArtifactDeployer 1.4.2 - Problem with long-running deployments [ID_35174]

If a large package was deployed from the catalog, which took a relatively long time to deploy, it could occur that this did not work correctly.

This fix is included in Cloud Pack 2.8.3.

#### 9 December 2022 - Enhancement - FieldControl 2.8.2 - Dependencies updated [ID_35140]

Several dependencies were updated. This includes security-related improvements.

This enhancement is included in Cloud Pack 2.8.3.

#### 8 December 2022 - New feature - CloudGateway 2.10.0 / SupportAssistant 1.1.0 - Remote Log Collection [ID_34681] [ID_34875] [ID_34928] [ID_34934] [ID_34954] [ID_34992]

A new DataMiner Cloud Pack 2.8.2 has been released, which enables the [Remote Log Collection](xref:RemoteLogCollection) feature. The DataMiner Cloud Pack can be found on [DataMiner Dojo](https://community.dataminer.services/downloads/).

With remote log collection, the packages generated by the [Log Collector tool](xref:SLLogCollector) are automatically transferred to secure storage in the cloud. This gives the experts at Skyline Communications immediate access to these packages, so that they can collect DataMiner log and memory dump files independently, increasing efficiency of investigations.

> [!NOTE]
> To be able to make use of this new feature, you must make sure the internal network allows [HTTP(S) traffic via port TCP 5100](xref:Configuring_the_IP_network_ports#overview-of-ip-ports-used-in-a-dms). This port is required for the DataMiner CloudGateway extension from version 2.10.0 onwards (included in the Cloud Pack 2.8.2). It is used as a dataminer.services endpoint for other [DataMiner Extension Modules](xref:DataMinerExtensionModules#dataminer-extension-modules-dxms). For more information about disabling this port or configuring another port for the dataminer.services endpoint, refer to [Customizing the dataminer.services endpoint configuration](xref:Custom_cloud_endpoint_configuration).

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

#### 16 November 2022 – Enhancement – CloudGateway 2.9.6 – Proxy support for WebSocket connection testing [ID_34569]

The connection tester now supports testing WebSocket connections through the configured proxy.

This enhancement is included in Cloud Pack version 2.8.2.

#### 16 November 2022 – Enhancement – Orchestrator 1.2.6 – DMA name and ID synced to dataminer.services [ID_34670]

From now on, the DataMiner Orchestrator will sync the DMA name and ID to dataminer.services. This is for example used on the *Nodes* page of the Admin app so users can easily identify a DMA to update its DxMs.

This enhancement is included in Cloud Pack version 2.8.2.

#### 28 November 2022 - Fix - ArtifactDeployer 1.4.1 - Proxy issue in DataMiner ArtifactDeployer 1.4.0 [ID_35013]

Because of an issue in the proxy configuration of DataMiner ArtifactDeployer 1.4.0, artifacts could not be deployed. This has been resolved in DataMiner ArtifactDeployer 1.4.1.

This enhancement is included in Cloud Pack version 2.8.2.

#### 18 October 2022 – Enhancement – Notification in case deployment fails because account is not linked [ID_34699]

When a deployment fails because the user does not have a linked account, they will now get a notification that will allow them to correct the situation and retry.

#### 18 October 2022 – Enhancement – Admin app supports additional audit events [ID_34697]

The Admin app now also includes the following audit events on the *Audit* page:

- A user created a dashboard share.
- A user performed an updated to an existing share.
- A user deleted an existing share.

Up to now, only accessing a share was logged in the audit events.

#### 27 September 2022 – New feature – DataMiner Teams bot support for custom commands [ID_34518]

If CoreGateway version 2.11.0 or higher and FieldControl version 2.8.1 or higher are installed (included in Cloud Pack version 2.8.2), the DataMiner Teams bot now allows you to display and run custom commands with dynamic user input configured in a DataMiner System connected to dataminer.services.

You can do so using the Teams bot commands *show command \<command name\>*, *show command*, and *run command \<command name\>*.

To add a command to your DMS, create an Automation script in the folder "bot" in the DMS. For examples of such scripts, refer to [Custom Command Examples](https://github.com/SkylineCommunications/ChatOps-Extensions/tree/main/CustomCommandExamples) on GitHub.

The commands allow dynamic input, such as dummies, parameters, parameters with value files, and memory files. They support the following output: key values, adaptive card body elements, and JSON.

A command will only be visible for users of the bot if they have the appropriate rights in DataMiner Cube. If users have the necessary rights to view a command, but they do not have the rights needed for certain input for the command, the bot will inform them that the command cannot be executed.

The following limitations also apply:

- Interactive Automation scripts are not supported.
- Commands that run longer than 30 seconds are currently not supported.
- Issues with the adaptive card output will not result in proper error feedback.

For more detailed information, refer to [Adding commands for the Teams bot to a DMS](xref:DataMiner_Teams_bot#adding-commands-for-the-teams-bot-to-a-dms)

#### 19 September 2022 – Enhancement – Improvements on Audit page in Admin app [ID_34457]

A number of improvements have been implemented on the *Audit* page in the Admin app:

- You can now filter on subject name and initiator.
- A search box is now available for each filter so you can quickly search for a specific item to filter on.
- Some filters allow you to manually specify custom values. For example, for the *Initiator* filter, which is automatically populated with the organization users, you can manually specify a user that has been deleted.
- The column order has been adjusted.
- Automatic loading of audit records has been improved to prevent possible issues with different screen sizes.

#### 15 September 2022 – Fix – CloudGateway 2.9.5 – Problem in CloudGateway process if MaintenanceSettings.xml contained an invalid HTTPS endpoint [ID_34341]

If the HTTPS endpoint in the file *MaintenanceSettings.xml* was not configured correctly, a problem could occur in the CloudGateway process. This happened specifically when DataMiner upgrades caused the HTTPS URL to end with an encoded new line.

With CloudGateway 2.9.5 (included in Cloud Pack version 2.8.2), all endpoints from configuration files will be trimmed to prevent this, so that CloudGateway will no longer get this problem at runtime. However, note that CloudGateway may still fail to start up if an endpoint in a configuration file is invalid.

#### 15 September 2022 – Fix – CoreGateway 2.11.5 – Incorrect information event when connector was deployed via dataminer.services [ID_34325]

When a connector was deployed via dataminer.services, the corresponding information event incorrectly mentioned that this was done with the SLNetClientTest tool.

With CoreGateway 2.11.5 (included in Cloud Pack version 2.8.2), the information event will have the correct format `New Client Registered - <UserName> @ <ComputerName> with DataMiner Cloud Platform`.

#### 9 September 2022 – Fix – FieldControl 2.8.1 – Teams bot not working [ID_34374]

In some cases, it could occur that the DataMiner Teams bot stopped working correctly and responded to commands with an error message.

With FieldControl 2.8.1 (included in Cloud Pack version 2.8.2), this issue will no longer occur.

#### 1 September 2022 – Enhancement – Filter functionality for Audit log in Admin app [ID_34322]

The Audit log in the Admin app now allows filtering on operation type, subject type, DataMiner System name, and time span. In addition, the loading of records has been optimized.

#### 1 September 2022 – New feature – CloudGateway 2.9.4 – Connection tester tool [ID_34187] [ID_34289] [ID_34293] [ID_34297]

The Cloud Gateway now comes with a new connection tester tool, *ConnectionTester.exe*. This tool can be used to validate the network setup and check if all features are available. It checks whether the network complies with the requirements for dataminer.services.

You can find the new tool in the folder `Program files\Skyline Communications\Dataminer CloudGateway\` on a DMA that has the Cloud Gateway installed. Run the executable as administrator. The connection tester will connect to port 443 to check whether requirements are met, and it will show the results in a console window.

This feature is included in Cloud Pack version 2.8.2.

#### 1 September 2022 – Fix – CoreGateway 2.11.4 / CloudGateway 2.9.4 – Login screen shown when not necessary while viewing share or using remote access [ID_34275]

When the DataMiner Cloud Pack was installed in a cluster with two or more DMAs, it could occur that users trying to view a shared dashboard or remotely access a DMS could be shown the login screen when this was not supposed to happen.

With CoreGateway 2.11.4 and CloudGateway 2.9.4 (included in Cloud Pack version 2.8.2), this issue is resolved.

The CoreGateway DxM must now be installed on the same DMA as CloudGateway to ensure that sharing and remote access will work correctly. For DMZ setups, the DMA that CloudGateway points to will need to have the CoreGateway DxM installed.

#### 1 September 2022 – Fix – CoreGateway 2.11.4 – CoreGateway of offline DMA tried to respond to requests from dataminer.services [ID_33973]

When a DMA was offline (e.g. stopped, upgrading, restarting, or offline in a Failover pair), it could occur that the DataMiner CoreGateway tried to respond to requests from dataminer.services, while this should not happen.

With CoreGateway 2.11.4 (included in Cloud Pack version 2.8.2), this will no longer occur.

#### 18 August 2022 – New feature – Audit and license information added in Admin app [ID_34216]

In the Admin app, the license expiration date for an organization is now displayed on that organization's *Overview* page.

In addition, a new *Audit* page is available in the app, which contains auditing logs for sharing dashboards and dataminer.services keys.

#### 18 July 2022 – New feature – CloudFeed 1.0.6 / CloudGateway 2.7.0 / ArtifactDeployer 1.4.0 – Proxy support [ID_33955] [ID_33961] [ID_33972]

Proxy support has been added for DataMiner CloudFeed, CloudGateway, and ArtifactDeployer. When you configure this, all outgoing traffic towards the public internet will pass through the proxy server.

The proxy settings are configured in a single settings file that is reused for all DxMs. This *appsettings.proxy.json* file is located in the `C:\ProgramData\Skyline Communications\DxMs Shared\` folder on the DMA. It should have the following content:

```json
{
   "ProxyOptions": {
      "Enabled": true,
      "Address": "<address of the proxy server>"
   }
}
```

When you have configured the file, you will need to restart the CloudFeed, CloudGateway, and ArtifactDeployer services for the changes to take effect.

#### 18 July 2022 – New feature – CloudGateway 2.7.0 – DMZ support [ID_33903]

You can now connect a DMS to dataminer.services using a DMZ. This way the DMS can be connected to dataminer.services without exposing the entire DMS network to the public internet.

To create such a DMZ:

1. Configure the firewall of the DMZ:

    - Make sure it allows access to the endpoints mentioned in [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
    - Make sure the DMZ can communicate with the DMS through port 80, or through port 443 for a secure connection.
    - Make sure the DMZ can communicate through NATS though port 4222.

1. Install all DxMs that need internet access in the DMZ. At present, these are *CloudGateway*, *CloudFeed*, and *ArtifactDeployer*.

1. Add the *Orchestrator* to the DMZ, so that you can upgrade it later through dataminer.services.

1. On the DataMiner nodes, install the DxMs that need to connect with the DMA or do not require internet access. At present, these are *CoreGateway* and *FieldControl*.

    > [!NOTE]
    > For all DxMs, it is advised to have multiple instances running at the same time. This will create redundancy in case something goes wrong and allows for upgrades without any downtime.

1. In the `C:\Program Files\Skyline Communications\DataMiner CloudGateway`folder, create an override *appsettings.custom.json* with the following contents:

    ```json
    {
      "DmzOptions": {
        "IsHttpsEnabled": <true/false>,
        "Domain": <IIS>,
        "DataMinerAgentName":  <name of the dataminer agent the DMZ is connected to>
      }
    }
    ```

    - *IsHttpsEnabled*: Indicates whether the communication between the DMZ and the DMA is encrypted. This can only be the case if the IIS is configured to support TLS.
    - *Domain*: The domain name of your DataMiner System, configured through the IIS settings.
    - *DataMinerAgentName*: The name of the DataMiner Agent you are connecting to. This should be the same DMA as the one used for the domain setting.

1. On a DataMiner node, copy `C:\Skyline DataMiner\SLCloud.xml` and `C:\Skyline DataMiner\NATS\nsc\.nkeys\creds\DataMinerOperator\DataMinerAccount\DataMinerUser.creds`, and paste these in the `C:\Skyline DataMiner\` folder of the DMZ. Make sure that the credentials entry in *SLCloud.xml* points to the credentials file you copied over.

1. Restart all DxMs in the DMZ so that they use the new settings.

#### 7 July 2022 - Fix - Orchestrator 1.2.5 - Not possible to deploy DxMs via Admin app [ID_33998]

In some cases, it could occur that the DataMiner Orchestrator got stuck while it was installing a DxM, and it became unable to handle updates. This made it impossible to deploy any more DxMs via the Admin app.

#### 17 June 2022 – Enhancement – Admin app opens to Overview page [ID_33772]

When you open the Admin app, it will now immediately show the *Overview* page of the selected organization. Previously, it showed a page that only contained "Home".

#### 17 June 2022 – Enhancement – Admin icon available for all users [ID_33770]

The icon to access the Admin app is now available for all users on the `dataminer.services` home page. Previously, this was only available for admins and owners.

#### 10 June 2022 10 – New feature – New 'Outgoing Shares' page in Admin app [ID_33723]

In the Admin app, a new *Outgoing Shares* page is now available for each DataMiner System connected to dataminer.services. This page lists all items that have been shared via dataminer.services from the selected DMS.

When you click a shared item in the overview, more detailed information will be displayed, including the time when it was shared and when the share will expire.

#### 10 June 2022 10 – Enhancement – Pages in Admin app sidebar not shown for users without required permissions [ID_33708]

If you do not have the required permissions to use a specific page for a DMS in the Admin app, this page will no longer be shown when you select a DMS in the sidebar of the app.

#### 10 June 2022 10 – New feature – New 'Deployments' page in Admin app [ID_33707] [ID_33709] [ID_33724]

In the Admin app, a new *Deployments* page is now available for each DataMiner System connected to dataminer.services. This page provides information about all the deployments that have been done to the DataMiner System via the Nodes page, via the Catalog, or using a GitHub pipeline with our GitHub action. It details what has been deployed, when and by whom, and whether the deployment succeeded, is pending, or failed.

When you click a deployment in the overview, more detailed information will be displayed, including version information and event information that can be used for debugging. For example, in case a pending deployment is queued because of other deployments, you will be able to see this in the event information.

#### 7 June 2022 – Fix – Orchestrator v1.2.3 – Orchestrator DxM update incorrectly displayed as failed [ID_33685]

The Orchestrator DxM has been updated to version 1.2.3. When the Orchestrator DxM was updated via the Admin app, it could occur that this was displayed as a failed deployment even though it actually succeeded. This will now be prevented.

#### 3 June 2022 – New Feature – dataminer.services keys [ID_33606]

You can now use dataminer.services keys. At present, these can be used with the [GitHub action to deploy Automation scripts](https://github.com/marketplace/actions/skyline-dataminer-deploy-action) to a DMS connected to dataminer.services. However, more functionality requiring a dataminer.services key is expected to be implemented in the future.

In the Admin app, you can manage the dataminer.services keys on the *Keys* page for each DataMiner System connected to dataminer.services. Each set of keys consists of a (user-defined) label, a primary key, and a secondary key. Inline buttons are available that allow you to view or copy a key. Simply clicking a key entry in the list will open a side panel with detailed information, including when the keys were created and by whom.

For each set of keys, the *...* button on the right opens a menu where you can regenerate the primary key, regenerate the secondary key, or revoke (i.e. delete) the key. With the *New Key* option at the top of the page, you can add more keys.

#### 3 June 2022 – New feature – Admin app sidebar redesigned [ID_33599]

The layout of the Admin app has been improved. The blue icon bar on the left has been removed and the sidebar has been redesigned into two sections: *Organization* and *DataMiner Systems*. In the *DataMiner Systems* section, you can expand and collapse each connected DMS to view the available pages for that DMS.

#### 27 May 2022 – CoreGateway v2.8.0 & ArtifactDeployer v1.3.0 – Enhancements to support CI/CD deployment [ID_33533] [ID_33534]

The CoreGateway DxM has been updated to version 2.8.0, and the ArtifactDeployer DxM has been updated to version 1.3.0. These new versions contain enhancements to support the CI/CD deployment feature.

#### 19 May 2022 – Fix – Notification when removing user showed placeholder [ID_33383]

When a user was removed in the Admin app, the displayed notification contained a placeholder instead of the relevant email address.

#### 6 May 2022 – New feature – DataMiner Teams bot v1.2 [ID_33422]

A new version of the DataMiner Teams bot is now available. If you use the command *show view [View name]* with this new version, the DataMiner Teams bot will display the visual overview of the specified view, as well as the alarm status and the number of active alarms. With the buttons in the response, you can request the alarms of the view or open the view in the Monitoring app via remote access.

In addition, all links to documentation in the app have been adjusted to link to <https://docs.dataminer.services/>.

#### 2 May 2022 – Fix – Not possible to delete share without users [ID_33366]

If a share was not valid because all users had removed themselves from it, it could occur that it was not possible to delete that share. This issue has now been resolved.

#### 14 Apr. 2022 – New feature – Managing nodes connected to dataminer.services [ID_33081] [ID_33127]

In the Admin app, you can now manage the nodes of DataMiner Systems that are connected to dataminer.services. You can upgrade the installed DxM versions on the nodes and remove nodes that have become obsolete. In case a node has a higher DxM version installed than the current version, it is also possible to downgrade that node.

Note that DataMiner Cloud Pack version 2.5.0 or higher must be installed on the nodes, as otherwise they will not be listed in the Admin app.

> [!IMPORTANT]
> If you are using an IP-based firewall, from now on you will need to add `20.31.240.20` to the allowed IP addresses to be able to connect to dataminer.services.

#### 5 Apr. 2022 – New feature – Admin app no longer shown by default on home page [ID_33090]

The Admin app will now only be shown on the dataminer.services home page for users who are the owner/admin of an organization and/or of a DataMiner System.

#### 5 Apr. 2022 – New feature – Non-dataminer.services users now notified about needing to connect to dataminer.services [ID_33089]

When a user of a DMS that is not yet connected to dataminer.services goes to <https://dataminer.services/>, they will now be informed that they are not yet connected, and a link will be provided to more information about dataminer.services.

#### 28 Feb. 2022 – New feature – dataminer.services connection verification [ID_32741]

In the Admin app, on the *Organization > Manage* page, users can now click a button to send an email to Skyline to have their dataminer.services connection verified. This verification ensures access to the latest dataminer.services features, including the ability to install protocols directly from the dataminer.services catalog.

When the verification has been successful, this will be indicated on this same page.

#### 23 Feb. 2022 – New feature – Removing a share [ID_32695]

In the *Sharing* module, you can now remove a share. When you do so, you indicate that you no longer wish to have access to the shared item. The item will no longer be available to you, unless it is shared with you again.

#### 12 Jan. 2022 – New feature – Support for app package deployment [ID_32210]

Support has been added for the deployment of app packages to a specific DMS connected to dataminer.services. However, note that the UI to deploy app packages is not yet available at this point.
