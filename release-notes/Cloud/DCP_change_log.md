---
uid: DCP_change_log
---

# DataMiner Cloud Platform change log

The DataMiner Cloud Platform gets updated continuously. This change log can help you trace when specific features and changes have become available.

#### 1 September 2022 – New feature – CloudGateway 2.9.4 – Connection tester tool [ID_34293]

The Cloud Gateway now comes with a new connection tester tool, *ConnectionTester.exe*. This tool can be used to validate the network setup and check if all features are available. It checks whether the network complies with the requirements for the cloud platform.

You can find the new tool in the folder `Program files\Skyline Communications\Dataminer CloudGateway\` on each cloud-connected DMA. Simply double-click the executable to run the test, and a console window will show the results.

#### 18 August 2022 – New feature – Audit and license information added in DCP Admin app [ID_34216]

In the DCP Admin app, the license expiration date for an organization is now displayed on that organization's *Overview* page.

In addition, a new *Audit* page is available in the app, which contains auditing logs for sharing dashboards and DCP keys.

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

You can now connect a DMS to the cloud using a DMZ. This way the DMS can be cloud-connected without exposing the entire DMS network to the public internet.

To create such a DMZ:

1. Configure the firewall of the DMZ:

    - Make sure it allows access to the endpoints mentioned in [Connecting your DataMiner System to the cloud](xref:Connecting_your_DataMiner_System_to_the_cloud).
    - Make sure the DMZ can communicate with the DMS through port 80, or through port 443 for a secure connection.
    - Make sure the DMZ can communicate through NATS though port 4222.

1. Install all DxMs that need internet access in the DMZ. At present, these are *CloudGateway*, *CloudFeed*, and *ArtifactDeployer*.

1. Add the *Orchestrator* to the DMZ, so that you can upgrade it later through the cloud.

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

#### 17 June 2022 – Enhancement – DCP Admin app opens to Overview page [ID_33772]

When you open the DCP Admin app, it will now immediately show the *Overview* page of the selected organization. Previously, it showed a page that only contained "Home".

#### 17 June 2022 – Enhancement – DCP Admin icon available for all users [ID_33770]

The icon to access the DCP Admin app is now available for all users on the `dataminer.services` home page. Previously, this was only available for admins and owners.

#### 10 June 2022 10 – New feature – New 'Outgoing Shares' page in DCP Admin app [ID_33723]

In the DCP Admin app, a new *Outgoing Shares* page is now available for each cloud-connected DataMiner System. This page lists all items that have been shared in the cloud from the selected DMS.

When you click a shared item in the overview, more detailed information will be displayed, including the time when it was shared and when the share will expire.

#### 10 June 2022 10 – Enhancement – Pages in DCP Admin app sidebar not shown for users without required permissions [ID_33708]

If you do not have the required permissions to use a specific page for a DMS in the DCP Admin app, this page will no longer be shown when you select a DMS in the sidebar of the app.

#### 10 June 2022 10 – New feature – New 'Deployments' page in DCP Admin app [ID_33707] [ID_33709] [ID_33724]

In the DCP Admin app, a new *Deployments* page is now available for each cloud-connected DataMiner System. This page provides information about all the deployments that have been done to the DataMiner System via the Nodes page, via the Catalog, or using a GitHub pipeline with our GitHub action. It details what has been deployed, when and by whom, and whether the deployment succeeded, is pending, or failed.

When you click a deployment in the overview, more detailed information will be displayed, including version information and event information that can be used for debugging. For example, in case a pending deployment is queued because of other deployments, you will be able to see this in the event information.

#### 7 June 2022 – Fix – Orchestrator v1.2.3 – Orchestrator DxM update incorrectly displayed as failed [ID_33685]

The Orchestrator DxM has been updated to version 1.2.3. When the Orchestrator DxM was updated via the DCP Admin app, it could occur that this was displayed as a failed deployment even though it actually succeeded. This will now be prevented.

#### 3 June 2022 – New Feature – DCP keys [ID_33606]

DCP keys have now been added to the DataMiner Cloud Platform. At present, these can be used with the [GitHub action to deploy Automation scripts](https://github.com/marketplace/actions/skyline-dataminer-deploy-action) to a cloud-connected DMS. However, more functionality requiring a DCP key is expected to be implemented in the future.

In the DCP Admin app, you can manage the DCP keys on the *Keys* page for each cloud-connected DataMiner System. Each set of keys consists of a (user-defined) label, a primary key, and a secondary key. Inline buttons are available that allow you to view or copy a key. Simply clicking a key entry in the list will open a side panel with detailed information, including when the keys were created and by whom.

For each set of keys, the *...* button on the right opens a menu where you can regenerate the primary key, regenerate the secondary key, or revoke (i.e. delete) the key. With the *New Key* option at the top of the page, you can add more keys.

#### 3 June 2022 – New feature – DCP Admin app sidebar redesigned [ID_33599]

The layout of the DCP Admin app has been improved. The blue icon bar on the left has been removed and the sidebar has been redesigned into two sections: *Organization* and *DataMiner Systems*. In the *DataMiner Systems* section, you can expand and collapse each cloud-connected DMS to view the available pages for that DMS.

#### 27 May 2022 – CoreGateway v2.8.0 & ArtifactDeployer v1.3.0 – Enhancements to support CI/CD deployment [ID_33533] [ID_33534]

The CoreGateway DxM has been updated to version 2.8.0, and the ArtifactDeployer DxM has been updated to version 1.3.0. These new versions contain enhancements to support the CI/CD deployment feature.

#### 19 May 2022 – Fix – Notification when removing user showed placeholder [ID_33383]

When a user was removed in the DCP Admin app, the displayed notification contained a placeholder instead of the relevant email address.

#### 6 May 2022 – New feature – DataMiner Teams bot v1.2 [ID_33422]

A new version of the DataMiner Teams bot is now available. If you use the command *show view [View name]* with this new version, the DataMiner Teams bot will display the visual overview of the specified view, as well as the alarm status and the number of active alarms. With the buttons in the response, you can request the alarms of the view or open the view in the Monitoring app via remote access.

In addition, all links to documentation in the app have been adjusted to link to <https://docs.dataminer.services/>.

#### 2 May 2022 – Fix – Not possible to delete share without users [ID_33366]

If a share was not valid because all users had removed themselves from it, it could occur that it was not possible to delete that share. This issue has now been resolved.

#### 14 Apr. 2022 – New feature – Managing cloud-connected nodes [ID_33081] [ID_33127]

In the DCP Admin app, you can now manage the nodes of cloud-connected DataMiner Systems. You can upgrade the installed DxM versions on the nodes and remove nodes that have become obsolete. In case a node has a higher DxM version installed than the current version, it is also possible to downgrade that node.

Note that DataMiner Cloud Pack version 2.5.0 or higher must be installed on the nodes, as otherwise they will not be listed in the DCP Admin app.

> [!IMPORTANT]
> If you are using an IP-based firewall, from now on you will need to add `20.31.240.20` to the allowed IP addresses to be able to connect to the DataMiner Cloud Platform.

#### 5 Apr. 2022 – New feature – Admin app no longer shown by default on home page [ID_33090]

The DCP Admin app will now only be shown on the cloud home page for users who are the owner/admin of an organization and/or of a DataMiner System.

#### 5 Apr. 2022 – New feature – Non-cloud connected users now notified about needing to connect to the cloud [ID_33089]

When a user of a DMS that is not yet connected to the cloud goes to <https://dataminer.services/>, they will now be informed that they are not yet connected, and a link will be provided to more information about the DataMiner Cloud Platform.

#### 28 Feb. 2022 – New feature – Cloud connection verification [ID_32741]

In the DCP Admin app, on the *Organization > Manage* page, users can now click a button to send an email to Skyline to have their cloud connection verified. This verification ensures access to the latest cloud features, including the ability to install protocols directly from the DCP catalog.

When the verification has been successful, this will be indicated on this same page.

#### 23 Feb. 2022 – New feature – Removing a share [ID_32695]

In the *DCP Sharing* module, you can now remove a share. When you do so, you indicate that you no longer wish to have access to the shared item. The item will no longer be available to you, unless it is shared with you again.

#### 12 Jan. 2022 – New feature – Support for app package deployment [ID_32210]

Support has been added for the deployment of app packages to a specific cloud-connected DMS. However, note that the UI to deploy app packages is not yet available at this point.
