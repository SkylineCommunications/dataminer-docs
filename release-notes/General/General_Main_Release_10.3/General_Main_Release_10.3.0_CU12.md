---
uid: General_Main_Release_10.3.0_CU12
---

# General Main Release 10.3.0 CU12

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.3.0 CU12](xref:Cube_Main_Release_10.3.0_CU12).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.3.0 CU12](xref:Web_apps_Main_Release_10.3.0_CU12).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Breaking changes

#### Microsoft Entra ID: Enhanced user and group import [ID 38154]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

A number of improvements have been made with regard to importing users and user groups into Microsoft Entra ID (formerly known as Azure Active Directory):

- Enhanced performance for tenants with large amounts of users and groups.
- Support for users of which the name contains non-ASCII characters, users sharing the same given name and surname, and users of whom the given name and/or surname is not provisioned.
- Group descriptions will now also be imported.

These improvements include the following **breaking change**:

User name format has changed from `{organization}\{givenName}.{surname}` to `{domain}\{username}` based on the `userPrincipalName`.

This format is now consistent with automatic user provisioning via SAML authentication.

For example, "ZIINE\Björn.Waldegård" with userPrincipalName <bjorn.waldegard@ziine.com> will now become "ziine.com\bjorn.waldegard".

> [!IMPORTANT]
> If you are using SAML with Microsoft Entra ID and you [have imported single users from Entra ID](xref:SAML_using_Entra_ID#configuring-dataminer-to-import-users-and-groups-from-microsoft-entra-id) (indicated with a blue icon in the *Users/Groups* module in Cube), take the following steps when you upgrade:
>
> 1. Make sure a local admin user can be used on the server.
>
>    If no such user exists yet, create one.
>
> 1. Take a backup of the `C:\Skyline DataMiner\Users` folder and of the file `C:\Skyline DataMiner\Security.xml`.
>
> 1. Upgrade DataMiner.
>
> 1. Log in with the local admin user, and replace the imported users:
>
>    1. [Add the new users](xref:Adding_a_user).
>
>    1. [Place them in the same security group](xref:Changing_group_membership_of_a_user).
>
>    1. [Remove the old imported users](xref:Deleting_a_user).
>
>    1. If you want to restore the client settings for the users, copy the user files from the backup you created earlier and add them to the relevant folders under `C:\Skyline DataMiner\Users`.
>
> 1. If the users were able to use dataminer.services features, you will need to remove their old account in the Admin app and then add the new account. See [Controlling user access to dataminer.services features](xref:Giving_users_access_to_cloud_features).

### Enhancements

#### DataMiner requirements: .NET 8.0 now required [ID 37969]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU0] - FR 10.4.3 [CU0] -->

To be able to upgrade to DataMiner 10.3.0 [CU12], you will first need to install the [Microsoft ASP.NET 8.0 Hosting Bundle](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-8.0.1-windows-hosting-bundle-installer).

If this requirement is not met, a new prerequisite check during the upgrade will notify you that you will first need to take care of this before you can run the upgrade.

#### SLNetClientTest tool: Message builder now allows creating an instance of an abstract type or interface [ID 38236]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

The message builder in the SLNetClientTest tool allows you to build SLNet messages from scratch, filling out values for the properties in `DMSMessage` objects.

Up to now, if these properties were for an abstract type or interface, it was not possible to fill out a value. From now on, it will be possible to select a concrete type, create an instance, and edit the properties of that object.

#### DataMiner upgrade: Enhanced robustness of MSI package installations [ID 38376]

<!-- MR 10.3.0 [CU12] - FR 10.4.2 [CU0] -->

Up to now, during a DataMiner upgrade, in some cases, MSI packages would fail to install and throw one of the following errors:

- `The Installer has insufficient privileges to access this directory: ...`
- `Service ... could not be installed. Verify that you have sufficient privileges to install system services.`

From now on, when one of the above-mentioned errors is thrown, it will no longer be necessary to restart the entire upgrade procedure. Instead, a retry will be attempted during the running upgrade.

#### Security enhancements [ID 38386]

<!-- RN 38386: MR 10.3.0 [CU12] - FR 10.4.3 -->

A number of security enhancements have been made.

#### SLProtocol will now always fetch element data page by page except on systems with a MySQL database [ID 38388]

<!-- MR 10.3.0 [CU12]/10.4.0 - FR 10.4.3 -->

From now on, SLProtocol will always fetch element data page by page, except on systems with a MySQL database.

On systems with a MySQL database, SLProtocol will continue to fetch element data by parameter ID.

#### DataMiner upgrade: SLAnalytics upgrade actions now support Cassandra connections with TLS [ID 38393]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

DataMiner upgrade actions related to SLAnalytics features now also support Cassandra connections with TLS.

#### SLAnalytics: Trend data pattern records will no longer be deleted from the database [ID 38407]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

From now on, trend data pattern records will no longer be deleted from the Elasticsearch/OpenSearch database.

#### Enhanced performance when updating cell-based subscriptions in SLNet [ID 38445]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

Because of a number of enhancements, overall performance has increased when updating cell-based subscriptions in SLNet.

These subscriptions mostly originate from visual overviews.

#### GQI: Enhanced performance when executing 'Get parameters from elements' queries for parameter tables [ID 38460]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When a *Get parameters from elements* query is executed for a parameter table, from now on, the table sessions that are used to resolve those tables in parallel will be closed asynchronously.

As a result, overall performance of clients like the Dashboards app or a low-code app will significantly increase when executing this type of queries.

#### SLAnalytics: Notification alarm 'Failed to start Analytics feature(s)...' will now be cleared automatically [ID 38621]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

The following notification alarm, generated when an SLAnalytics feature failed to start up, will now be automatically cleared when that same feature starts up correctly.

`Failed to start x Analytics feature(s). Check the Analytics logging (SLAnalytics.txt) for more information.`

### Fixes

#### DataMiner installer: Some modules would not get installed while performing a full installation of a new DMA [ID 37719]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

Up to now, when you ran the DataMiner installer to install a new DataMiner Agent using a DataMiner upgrade package, some modules would incorrectly not get installed as they were configured to only be installed when upgrading an existing DataMiner Agent.

From now on, when you run the DataMiner installer to install a new DataMiner Agent using a DataMiner upgrade package, all installation steps will be performed, including the upgrade actions.

#### Problem when loading data of elements hosted on another DMA while a Correlation rule action was running [ID 38121]

<!-- MR 10.3.0 [CU12] - FR 10.4.2 -->

When, while an extensive Correlation rule action was running, you opened an element card of an element hosted on a DataMiner Agent other than the one you were connected to, loading the data of that element could get delayed until the Correlation rule action had finished.

#### Web apps: Visual overview linked to a view would not get any updates when the user did not have full administrative rights [ID 38180]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

When a web app user without full administrative rights viewed a visual overview linked to a view, the app would incorrectly not receive any updates for that visual overview.

#### DataMiner clients using a gRPC connection would not always detect a disconnect [ID 38215]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

In some cases, DataMiner clients using a gRPC connection would not detect a disconnect.

#### Web apps - Visual overview: Popup window would not display a hidden page when the visual overview only contained one non-hidden page [ID 38331]

<!-- MR 10.2.0 [CU21] / 10.3.0 [CU12] / 10.4.0 [CU0] - - FR 10.4.3 [CU0] -->

When, in a visual overview with one non-hidden page displayed in a web app, you tried to open a popup window linked to a page marked as "hidden", the popup window would incorrectly display the non-hidden page instead of the hidden page.

#### Automation: Script data cleanup routine could cause an error to occur [ID 38370]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

In some rare cases, a cleanup routine within SLAutomation could prematurely clean up data of scripts that had not yet finished, causing an error to occur.

#### Automation: Problem when empty data is passed to the UI parser when running an interactive automation script [ID 38408]

<!-- MR 10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

When running an interactive automation script that was launched from Cube or a web app, in some cases, an exception could be thrown when empty data was passed to the UI parser.

From now on, an exception will no longer be thrown when empty data is passed to the UI parser.

#### DataMiner upgrade: Problem with AnalyticsParameterInfoRecordAddChangeRate upgrade action on systems with a Cassandra Cluster database [ID 38443]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

During a DataMiner upgrade, the *AnalyticsParameterInfoRecordAddChangeRate* upgrade action executes an *Alter Table* command on every DataMiner Agent in the cluster. Up to now, when you upgraded a DataMiner System with a Cassandra Cluster database, that *Alter Table* command would incorrectly only get executed on the first DMA that called it. On each subsequent DMA that called the command, errors would get thrown and added to the *upgrade.log* file.

#### Problem with SLDMS [ID 38469]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

In some cases, an error could occur in the SLDMS process when the SLDMKey object was accesses from multiple threads.

#### Fatal error reported in Windows Event Viewer each time the APIGateway was stopped [ID 38504]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

Each time the APIGateway service was stopped, a fatal error would incorrectly be reported in the Windows Event Viewer.

#### Alarm filters would not be properly serialized when using a gRPC connection [ID 38507]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When a client application was connected to a DataMiner Agent via a gRPC connection, in some cases, the alarm filters it received from the DataMiner Agent would not be properly serialized.

#### SLAnalytics features would not start up correctly after a database connection problem [ID 38600]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

Up to now, when writing to the database or reading from the database failed, a retry was attempted after 5 seconds. In some cases, especially when the SLNet connection was lost during startup, that retry would also fail, causing certain SLAnalytics features to not start up correctly. From now on, when writing to the database or reading from the database fails, SLAnalytics will wait longer than 5 seconds before attempting a retry.

#### Protocols: IDisposable QActions would incorrectly not be disposed [ID 38605]

<!-- MR 10.3.0 [CU12]/10.4.0 - FR 10.4.3 -->

When DataMiner was processing all QActions in order to call the `Dispose` method on the QActions that implement `IDisposable`, it would incorrectly no longer call the `Dispose` method on QActions that implement `IDisposable` after processing a QAction that did not implement `IDisposable`.

#### Problem when adding a DMA to a DMS [ID 38620]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU0] - FR 10.4.3 [CU0] -->

When a DataMiner Agent was added to a DataMiner System, in some cases, the SLNet cache of the new DataMiner Agent would not get updated, causing the Agent to not be aware it was now part of a DMS.

#### Problem with SLDataMiner while sending a SetDocumentEofMessage with a negative file number [ID 38712]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU0] - FR 10.4.3 [CU0] -->

In some cases, SLDataMiner could stop working while sending a `SetDocumentEofMessage` with a negative file number via SLNet.
