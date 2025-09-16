---
uid: General_Feature_Release_10.5.11
---

# General Feature Release 10.5.11 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version, make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.
>
> The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
> - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
> - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.11](xref:Cube_Feature_Release_10.5.11).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.11](xref:Web_apps_Feature_Release_10.5.11).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### SLNetClientTest tool: Filtering messages using regular expressions [ID 43540]

<!-- MR 10.6.0 - FR 10.5.11 -->

In the *SLNetClientTest* tool, at the bottom of the main window, a new filter box has been added.

After you select the checkbox in front of it, it will allow you to filter the message list using a regular expression.

This new filter box should only be used when no new messages will be added to the list, e.g. when inspecting an *\*.slnetdump* file.

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

## Changes

### Enhancements

#### Relational anomaly detection: Enhancements [ID 43440]

<!-- MR 10.6.0 - FR 10.5.11 -->

A number of enhancements have been made with regard to RAD parameter groups:

- The RAD API messages no longer have to be sent to the agent monitoring the parameters in question. Each message will automatically be forwarded to the correct agent based on the name of the parameter group. If the agent could not be determined, an exception will be thrown.
- The `GetRADParameterGroupsMessage` will now retrieve a list of all RAD parameter groups that have been configured across all agents in the cluster. Up to now, it would only retrieve the list of RAD parameter groups hosted on the local agent.
- It is no longer allowed to have two groups with the same name, even when they are hosted by different agents.

#### VerifyGRPCConnection prerequisite check: Clearer error will now be logged when the check is performed on an agent that is not running [ID 43608]

<!-- MR 10.6.0 - FR 10.5.11 -->

When the *VerifyGRPCConnection* prerequisite check is performed on a DataMiner Agent that is not running, the error that is logged will now explain the problem clearer.

#### STaaS: Enhanced exception logging [ID 43626]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

A number of enhancements have been made with regard to the logging of exception messages on STaaS systems.

#### DxMs upgraded [ID 43642] [ID 43644]

<!-- RN 43642: MR 10.5.0 [CU8] - FR 10.5.11 -->
<!-- RN 43644: MR 10.6.0 - FR 10.5.11 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer 1.8.6
- DataMiner CloudGateway 2.17.12
- DataMiner CoreGateway 2.14.14
- DataMiner SupportAssistant 1.7.7

The CloudGateway DxM will only be upgraded when an older version is found on the DataMiner Agent. If no older version is found, they will not be installed.

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

#### CPE: Enhanced performance [ID 43654]

<!-- MR 10.5.0 [CU8] - FR 10.5.11 -->

Because of a number of enhancements in the aggregation module, overall performance has increased.

#### STaaS: A failure notice will now be returned immediately when an operation could not be sent to STaaS [ID 43667]

<!-- MR 10.5.0 [CU8] - FR 10.5.11 -->

Up to now, when DataMiner was not able to send an operation to STaaS, it had to wait until the write operation timed out before it got confirmation that the operation had failed.

From now on, when DataMiner tries to send an operation of which the size exceeds the maximum package limit to STaaS, a failure notice will be returned immediately.

#### Automation scripts: No attempts will be made anymore to automatically detect the interactive behavior of script libraries [ID 43673]

<!-- MR 10.6.0 - FR 10.5.11 -->

From now on, no attempts will be made anymore to automatically detect the interactive behavior of script libraries, i.e. scripts of which all Exe blocks contain precompiled C# code. These libraries are not intended to be run independently.

### Fixes

#### Problem when loading initial parameter data for remote elements [ID 43339] [ID 43552]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

In some cases, client applications like DataMiner Cube would fail to load initial parameter data for remote elements.

#### Protocols: Problems with pollingRate attribute [ID 43418]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

A number of issues have been fixed with regard to the `pollingRate` attribute, which allows you to slow down polling for specific SNMP columns in a table by specifying a minimum interval (in milliseconds) between polling.

- Using `pollingRate` would not work when the element was using the production version of the protocol or when the `partialSNMP` option was specified in the table options.

- Up to now, the decision to poll a column was taken by SLSNMPManager, which relied on the *Polling.xml* file that was stored alongside the *Protocol.xml* file. From now on, SLProtocol will determine which columns will be polled independently of the *Polling.xml* file.

> [!NOTE]
> Stream Viewer will now indicate more clearly which columns were polled. When some columns were polled while others were skipped, the message `[PollingRate polled column PIDs xxx,yyy]` will be shown. Also, when the timer was faster than the polling rate, the message `No column reached the PollingRate interval.` will be shown, and no Get operation will be executed.

#### Problem when trying to send an SNMP Set command to have all active alarms resent [ID 43442]

<!-- MR 10.5.0 [CU8] - FR 10.5.11 -->

You can have all active alarms resent by sending an SNMP Set command to the DMA (with the DataMiner IP address as target address) with OID 1.3.6.1.4.1.8813.1.1.1.1.4 and value set to the name of the SNMP manager.

However, since DataMiner versions 10.4.0 [CU12]/10.5.3, this would no longer work when the SNMP manager in question had the *Resend all active alarms every ...* option disabled.

#### Cassandra Cluster Migrator tool: Problem when reverse lookup of IP addresses returned hostnames other than those configured in the SSL certificate [ID 43520]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When you tried to migrate a Cassandra Cluster with SSL/TLS enabled, up to now, the Cassandra Cluster Migration tool would not be able to initialize when a reverse lookup of IP addresses returned hostnames other than those configured in the SSL certificate.

This issue can be prevented by manually checking if the IP address is one of the SANs (Subject Alternative Names) of the SSL certificate.

#### Problem when trying to update the log levels of an element that was not hosted on the local DataMiner Agent [ID 43582]

<!-- MR 10.5.0 [CU8] - FR 10.5.11 -->

When you tried to update the log levels of an element that was not hosted on the local DataMiner Agent, up to now, the update request would incorrectly be ignored and would not be forwarded to the DataMiner Agent hosting the element.

From now on, the update request will correctly be forwarded to the DataMiner Agent hosting the element where it will be processed accordingly.

#### SLNet could return incorrect data to the client application when processing a cell subscription filter [ID 43600]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When processing a cell subscription filter, in some cases, SLNet could return incorrect data to the client application.

#### Service & Resource Management: Problem when updating existing properties of a booking [ID 43659]

<!-- MR 10.6.0 - FR 10.5.11 -->

Up to now, when the `SafelyUpdateReservationInstanceProperties` method of `ResourceManagerHelper` was used to update existing properties of a booking, in some cases, the `PropertiesWereAlreadyModified` error would incorrectly be returned.

From now on, when booking properties are updated, the master agent that processes the update will check whether the properties to be updated are existing properties of the booking in question. If so, the update will complete successfully, and no false `PropertiesWereAlreadyModified` errors will be returned.

#### Relational anomaly detection: Old RAD suggestion events would incorrectly be re-opened when a paused element was re-activated [ID 43688]

<!-- MR 10.6.0 - FR 10.5.11 -->
<!-- Not added to MR 10.6.0 -->

When an element with active RAD suggestion events is paused, in the Alarm Console, these suggestion events will disappear from the active alarms tab.

Up to now, when a paused element was re-activated, the suggestion events that had disappeared from the active alarms tab would incorrectly be re-opened again. From now on, they will no longer be re-opened. If the anomalous behavior persists when a paused element is re-activated, new RAD suggestion events will be generated instead.
