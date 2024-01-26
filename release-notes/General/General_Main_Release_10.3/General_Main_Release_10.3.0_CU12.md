---
uid: General_Main_Release_10.3.0_CU12
---

# General Main Release 10.3.0 CU12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Breaking changes

#### Microsoft Entra ID: Enhanced user and group import [ID_38154]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

A number of improvements have been made with regard to importing users and user groups into Microsoft Entra ID (formerly known as Azure Active Directory):

- Enhanced performance for tenants with large amounts of users and groups.
- Support for users of which the name contains non-ASCII characters, users sharing the same given name and surname, and users of whom the given name and/or surname is not provisioned.
- Group descriptions will now also be imported.

These improvements include the following **breaking change**:

User name format has changed from `{organization}\{givenName}.{surname}` to `{domain}\{username}` based on the `userPrincipalName`.

This format is now consistent with automatic user provisioning via SAML authentication.

For example, "ZIINE\Björn.Waldegård" with userPrincipalName <bjorn.waldegard@ziine.com> will now become "ziine.com\bjorn.waldegard".

### Enhancements

#### SLNetClientTest tool: Message builder now allows creating an instance of an abstract type or interface [ID_38236]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

The message builder in the SLNetClientTest tool allows you to build SLNet messages from scratch, filling out values for the properties in `DMSMessage` objects.

Up to now, if these properties were for an abstract type or interface, it was not possible to fill out a value. From now on, it will be possible to select a concrete type, create an instance, and edit the properties of that object.

#### DataMiner upgrade: Enhanced robustness of MSI package installations [ID_38376]

<!-- MR 10.3.0 [CU12] - FR 10.4.2 [CU0] -->

Up to now, during a DataMiner upgrade, in some cases, MSI packages would fail to install and throw one of the following errors:

- `The Installer has insufficient privileges to access this directory: ...`
- `Service ... could not be installed. Verify that you have sufficient privileges to install system services.`

From now on, when one of the above-mentioned errors is thrown, it will no longer be necessary to restart the entire upgrade procedure. Instead, a retry will be attempted during the running upgrade.

#### Security enhancements [ID_38386]

<!-- 38386: MR 10.3.0 [CU12] - FR 10.4.3 -->

A number of security enhancements have been made.

#### SLProtocol will now always fetch element data page by page except on systems with a MySQL database [ID_38388]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

From now on, SLProtocol will always fetch element data page by page, except on systems with a MySQL database.

On systems with a MySQL database, SLProtocol will continue to fetch element data by parameter ID.

#### DataMiner upgrade: SLAnalytics upgrade actions now support Cassandra connections with TLS [ID_38393]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

DataMiner upgrade actions related to SLAnalytics features now also support Cassandra connections with TLS.

#### SLAnalytics: Trend data pattern records will no longer be deleted from the database [ID_38407]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

From now on, trend data pattern records will no longer be deleted from the Elasticsearch/OpenSearch database.

#### GQI: Enhanced performance when executing 'Get parameters from elements' queries for parameter tables [ID_38460]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When a *Get parameters from elements* query is executed for a parameter table, from now on, the table sessions that are used to resolve those tables in parallel will be closed asynchronously.

As a result, overall performance of clients like the Dashboards app or a low-code app will significantly increase when executing this type of queries.

### Fixes

#### DataMiner installer: Some modules would not get installed while performing a full installation of a new DMA [ID_37719]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

Up to now, when you ran the DataMiner installer to install a new DataMiner Agent using a DataMiner upgrade package, some modules would incorrectly not get installed as they were configured to only be installed when upgrading an existing DataMiner Agent.

From now on, when you run the DataMiner installer to install a new DataMiner Agent using a DataMiner upgrade package, all installation steps will be performed, including the upgrade actions.

#### Web apps: Visual overview linked to a view would not get any updates when the user did not have full administrative rights [ID_38180]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

When a web app user without full administrative rights viewed a visual overview linked to a view, the app would incorrectly not receive any updates for that visual overview.

#### DataMiner clients using a gRPC connection would not always detect a disconnect [ID_38215]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

In some cases, DataMiner clients using a gRPC connection would not detect a disconnect.

#### Correlation: Alarm buckets would not get cleaned up when alarms were cleared before the end of the time frame specified in the 'Collect events for ... after first event, then evaluate conditions and execute actions' setting [ID_38292]

<!-- MR 10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

Up to now, when alarms were cleared before the end of the time frame specified in the *Collect events for ... after first event, then evaluate conditions and execute actions* correlation rule setting, the alarm buckets would not get cleaned up.

From now on, when a correlation rule is configured to use the *Collect events for ... after first event, then evaluate conditions and execute actions* trigger mechanism, all alarm buckets will be properly cleaned up, unless there are actions that need to be executed either when the base alarms are updated or when alarms are cleared.

#### Automation: Script data cleanup routine could cause an error to occur [ID_38370]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

In some rare cases, a cleanup routine within SLAutomation could prematurely clean up data of scripts that had not yet finished, causing an error to occur.

#### Automation: Problem when empty data is passed to the UI parser when running an interactive Automation script [ID_38408]

<!-- MR 10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

When running an interactive Automation script that was launched from Cube or a web app, in some cases, an exception could be thrown when empty data was passed to the UI parser.

From now on, an exception will no longer be thrown when empty data is passed to the UI parser.

#### DataMiner upgrade: Problem with AnalyticsParameterInfoRecordAddChangeRate upgrade action on systems with a Cassandra Cluster database [ID_38443]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

During a DataMiner upgrade, the *AnalyticsParameterInfoRecordAddChangeRate* upgrade action executes an *Alter Table* command on every DataMiner Agent in the cluster. Up to now, when you upgraded a DataMiner System with a Cassandra Cluster database, that *Alter Table* command would incorrectly only get executed on the first DMA that called it. On each subsequent DMA that called the command, errors would get thrown and added to the *upgrade.log* file.

#### Alarm filters would not be properly serialized when using a gRPC connection [ID_38507]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When a client application was connected to a DataMiner Agent via a gRPC connection, in some cases, the alarm filters it received from the DataMiner Agent would not be properly serialized.
