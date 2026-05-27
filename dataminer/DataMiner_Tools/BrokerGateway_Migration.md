---
uid: BrokerGateway_Migration
---

# Migrating to BrokerGateway

Before upgrading to 10.6.0/10.6.1, a migration to BGW is **mandatory**.

Practically, the *BrokerGateway migration* migrates from the SLNet-managed NATS solution (NAS and NATS services) to the BrokerGateway-managed NATS solution (nats-server service) using the "NATSMigration" tool.
The migration can either be run manually, or automatically.

The migration should be executed on DataMiner version 10.5.0 [CU11]/10.5.12 [CU2].
Alternatively, it is possible to migrate starting from DataMiner 10.5.0 [CU4]/10.5.7 [CU1], with several limitations.

> [!IMPORTANT]
>
> - For versions under 10.5.0 [CU11]/10.5.12 [CU2], migration is discouraged.
> - Manual migration is discouraged.
Usually Skyline Communications itself will recommend a manual migration in specific circumstances.
If the automated migration fails, please contact Skyline Communications for recommendations.
> - This migration is **mandatory to be able to upgrade to DataMiner 10.6.0/10.6.1** or higher. If you try to upgrade to such a DataMiner version when this migration has not yet been completed, the upgrade will be blocked. From DataMiner 10.6.0/10.6.1 onwards, the legacy SLNet‑managed NATS solution (NAS and NATS services) is no longer supported.<!-- RN 43861 -->

## How to migrate

### in DataMiner 10.5.0 [CU11]/10.5.12 [CU2]

1. Ensure the [prerequisites](#prerequisites) are met.

1. Once the [prerequisites](#prerequisites) are met, you can either [run an automatic migration](#automatic-migration-using-dmupgrade-package-recommended) or [run the migration manually](#manual-migration).

### Between DataMiner 10.5.0 [CU4]/10.5.7 [CU1] and DataMiner 10.5.0 [CU11]/10.5.12 [CU2]

1. Check whether you are affected by the [known migration issues](#known-migration-issues). If you are affected, upgrade to DataMiner 10.5.0 [CU11]/10.5.12 [CU2]. If not, proceed.

1. Ensure the [prerequisites](#prerequisites) are met.

1. Download the latest [NATSMigration.dmupgrade](https://community.dataminer.services/download/natsmigration-dmupgrade/) package.

1. Once the [prerequisites](#prerequisites) are met, you can [run an automatic migration] using the aforementioned (#automatic-migration-using-dmupgrade-package-recommended).

## Prerequisites

### Prerequisites verified by the .dmupgrade package (only when using the .dmupgrade package)

When using the .dmupgrade package:
If the [DataMiner requirements](#dataminer-requirements) or the [IT-requirements](#it-requirements) are not met, the migration will be blocked.

> [!IMPORTANT]
> Ensure that you download the latest version of the .dmupgrade package, to guarantee the presence of all aforementioned prerequisites.
> Before that version, certain prerequisites, such as the [IT-requirements](#it-requirements) are not present and need to be checked manually.

### IT requirements

- TLS 1.3 enabled
- TLS 1.2 enabled

The following cipher suites need to be enabled on the server:

- TLS_AES_128_GCM_SHA256 *(TLS 1.3 - used for native clients).*

- TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256 *(TLS 1.2 - used for managed clients)*

### DataMiner requirements

- Before initiating the migration, ensure that the entire cluster has been operating in a stable state for an extended period. All DataMiner Agents in the cluster must be online and functioning together for at least 15 minutes. To verify that the DMS meets the required conditions, run the [Verify NATS Migration Prerequisites](xref:BPA_NATS_Migration_Prerequisites) and [Check Deprecated DLL Usage](xref:BPA_Check_Deprecated_DLL_Usage) BPA tests.

- Additionally, check whether any protocols/connectors reference *DataMinerMessageBroker.API.dll* with a version earlier than 3.0.0. Update any such references prior to the migration and remove the outdated DLL from the `C:\Skyline DataMiner\ProtocolScripts` folder. From DataMiner 10.5.0 [CU9]/10.5.12 onwards, the presence of such an outdated DLL in the *ProtocolScripts* folder will block the migration.

- Finally, to start the migration, the [ClusterEndpointsManager](xref:Overview_of_Soft_Launch_Options#clusterendpointsmanager) soft‑launch option must not be disabled on any DataMiner Agent in the cluster. In DataMiner 10.5.0 [CU5]/10.5.8<!-- RN 43370 --> this option can be disabled when no migration is planned.

### Preparing post-migration Actions

If you have either of the setups outlined below, the steps outlined below have to be executed after the BrokerGateway migration.

- If you have a DMZ setup, you will need to [update the DMZ setup after the migration](#updating-your-dmz).

- When using Data Aggregator, prepare to [update your Data Aggregator configuration](#updating-the-data-aggregator-configuration) after the migration.

- If you have a Dashboard Gateway, you will need to [update the Dashboard Gateway](#updating-dashboard-gateway).

## Automatic migration using .dmupgrade package (recommended)

If you are using a DataMiner 10.5.x version starting from 10.5.0 [CU4] or 10.5.7, the recommended way to run the migration is by means of an upgrade package available on our Dojo Community platform:

1. Ensure the [prerequisites](#prerequisites) are met.

1. Download and run the [NATSMigration.dmupgrade](https://community.dataminer.services/download/natsmigration-dmupgrade/) package.

This will automatically run `C:\Skyline DataMiner\Tools\NATSMigration.exe` with default settings on all Agents. The DataMiner Agents will not be restarted.

In case any issues occur during the migration, the output will be shown in the update client.
This will look similar to the [manual migration log](#full-example-migration-log-sanitized). Aside from this, you can check the logging in `C:\Skyline DataMiner\Upgrades\Packages\NATSMigration.dmupgrade-XXX\progress.log` and in the upgrade utility UI.

## Manual migration

When recommended by Skyline, the migration can be run manually:

1. Ensure the [prerequisites](#prerequisites) are met.

1. Open a **remote desktop connection** to **all** DataMiner Agents at the same time.

1. On each Agent, open an elevated command prompt and run `C:\Skyline DataMiner\Tools\NATSMigration.exe`, with the optional argument `-r` to keep the script from restarting DataMiner.

1. Enter the `install` command on every Agent (including Failover Agents) within 10 minutes.

> [!IMPORTANT]
> This must happen on **each DMA** in the cluster **within a 10-minute time frame**. It is very important that this happens for **each individual DataMiner Agent, including Failover DMAs**. Prior to DataMiner 10.5.0 [CU4]/10.5.7, this also involves a restart of each DataMiner Agent.

## Post Migration actions

### Updating your DMZ

Please verify whether you previously had a limit on the number of NATS endpoints **in your DMZ**.
Please also verify whether IP-addresses of certain endpoints were customized.
To do that, see [Connecting to dataminer.services with a DMZ setup](xref:Connect_to_cloud_with_DMZ).
Under **If you are using the SLNet-managed NATS solution:**, you find a reference to the *SLCloud.xml* file. This file contains the "previous" endpoints used by the legacy **SLNET-managed NATS solution**.
If there is a limit on the number of NATS endpoints, or specific NATS endpoints need to be connected, a `ForcedEndpoints` array can be added to override the NATS endpoints provided by BrokerGateway.
For more information, see [Configuring forced NATS endpoints](xref:MessageBrokerConfig_ForcedEndpoints).

To reconnect your DMZ to dataminer.services after the migration, open [Connecting to dataminer.services with a DMZ setup](xref:Connect_to_cloud_with_DMZ). There, only follow the steps outlined below:
The steps you need are under **Copy the necessary configuration from node to DMZ**. Because you are moving from the legacy **SLNet-managed** solution to **BrokerGateway-managed NATS**, use the **If you are using the BrokerGateway-managed NATS solution** subsection, then finish with **Restart all DxMs in the DMZ** and **Connect to dataminer.services in System Center**. You may skip all steps for the **SLNet-managed** solution.

### Updating the Data Aggregator configuration

[Data Aggregator](xref:Data_Aggregator_DxM) can connect to multiple DataMiner Systems. When a specific DMS is migrated to BrokerGateway, any Data Aggregator configuration that connects to this DMS must be [manually updated](xref:Data_Aggregator_settings#dms-with-brokergateway).

Please verify whether you previously had a limit on the number of NATS endpoints **in your Data Aggregator configuration**.
Please also verify whether IP-addresses of certain endpoints were customized.
To do that, see [DMS without BrokerGateway](xref:Data_Aggregator_settings#dms-without-brokergateway).
Under [DMS without BrokerGateway](xref:Data_Aggregator_settings#dms-without-brokergateway), check the **URIs** field in **BrokerOptions.Clusters**.
If this is the case, a `ForcedEndpoints` array can be added to override the NATS endpoints provided by BrokerGateway.
For more information, see [Configuring forced NATS endpoints](xref:MessageBrokerConfig_ForcedEndpoints).

### Updating Dashboard Gateway

If you employ a [Dashboard Gateway](xref:Dashboard_Gateway_installation), you need to reconnect after the BrokerGateway migration.

To do this, open [Dashboard Gateway Installation - Configuration](xref:Dashboard_Gateway_installation#Configuration). There, only follow the steps outlined below:
The steps you need are under **On the Dashboard Gateway web server, edit the web.config in the API folder, and specify the following settings:**. Because you are moving from the legacy **SLNet-managed** solution to **BrokerGateway-managed NATS**, use the **If the system uses BrokerGateway:** subsection, ignoring the steps below the **If the system does not use BrokerGateway yet (only possible on 10.5.x systems):** subsection.

## Migrating back to the old system

> [!IMPORTANT]
> This is no longer possible from DataMiner 10.6.0/10.6.1 onwards.

On versions prior to 10.6.0/10.6.1, there are two different ways you can go back to the SLNet-managed NATS:

- Download and run the package [NATSMigrationRollback.dmupgrade](https://community.dataminer.services/download/natsmigrationrollback-dmupgrade/).

- Follow the same procedure as when you [run the migration manually](#manual-migration), but use the `uninstall` command instead of the `install` command. In this case, the same restrictions apply as for the migration: this must happen on all DataMiner Agents in the cluster at the same time.

## Known migration issues

If your DataMiner version is between 10.5.0 [CU4]/10.5.7 [CU1] and DataMiner 10.5.0 [CU11]/10.5.12 [CU2], please check whether your DMA is affected by below items.
Note that this is not an exhaustive list of issues, so upgrading to DataMiner 10.5.0 [CU11]/10.5.12 [CU2] is still preferable.
When in doubt, please contact Skyline Communications.  

- [Problem when generating a default MessageBrokerConfig.json file [ID 44155]](../../release-notes/General/General_Main_Release_10.5/General_Main_Release_10.5.0_CU11.md#problem-when-generating-a-default-messagebrokerconfigjson-file-id-44155) ([General Feature Release 10.6.2](../../release-notes/General/General_Feature_Release_10.6/General_Feature_Release_10.6.2.md#problem-when-generating-a-default-messagebrokerconfigjson-file-id-44155))

- [Clearer message when SLCloud.xml cannot be found when using the legacy SLNet-managed NATS solution [ID 43890]](../../release-notes/General/General_Main_Release_10.5/General_Main_Release_10.5.0_CU10.md#clearer-message-when-slcloudxml-cannot-be-found-when-using-the-legacy-slnet-managed-nats-solution-id-43890) ([General Feature Release 10.6.1](../../release-notes/General/General_Feature_Release_10.6/General_Feature_Release_10.6.1.md#clearer-message-when-slcloudxml-cannot-be-found-when-using-the-legacy-slnet-managed-nats-solution-id-43890))

- [MessageBroker client could get stuck while trying to fetch information from BrokerGateway [ID 43832]](../../release-notes/General/General_Main_Release_10.5/General_Main_Release_10.5.0_CU9.md#messagebroker-client-could-get-stuck-while-trying-to-fetch-information-from-brokergateway-id-43832) ([General Feature Release 10.5.12](../../release-notes/General/General_Feature_Release_10.5/General_Feature_Release_10.5.12.md#messagebroker-client-could-get-stuck-while-trying-to-fetch-information-from-brokergateway-id-43832))

- [BrokerGateway: Enhanced error handling [ID 42929]](../../release-notes/General/General_Main_Release_10.5/General_Main_Release_10.5.0_CU4.md#brokergateway-enhanced-error-handling-id-42929) ([General Feature Release 10.5.7](../../release-notes/General/General_Feature_Release_10.5/General_Feature_Release_10.5.7.md#brokergateway-enhanced-error-handling-id-42929))

- [Native MessageBroker clients would not order the IP addresses in SLCloud.xml correctly [ID 44901]](../../release-notes/General/General_Main_Release_10.6/General_Main_Release_10.6.0_CU2.md#native-messagebroker-clients-would-not-order-the-ip-addresses-in-slcloudxml-correctly-id-44901) ([General Main Release 10.5.0 CU14](../../release-notes/General/General_Main_Release_10.5/General_Main_Release_10.5.0_CU14.md#native-messagebroker-clients-would-not-order-the-ip-addresses-in-slcloudxml-correctly-id-44901), [General Feature Release 10.6.5](../../release-notes/General/General_Feature_Release_10.6/General_Feature_Release_10.6.5.md#native-messagebroker-clients-would-not-order-the-ip-addresses-in-slcloudxml-correctly-id-44901))

## Troubleshooting the migration

## FAQ

### Can I run a cluster with both SLNet-managed NATS and BrokerGateway-managed NATS?

This is not possible. Both NATS installations use the same network ports, so the services cannot run at the same time on a machine. The credentials these installations use are also different and not compatible with each other, so running SLNet-managed NATS on DMA1 and BrokerGateway-managed NATS on DMA2 will also not function.

### Why should I migrate to BrokerGateway? What are the advantages?

BrokerGateway will manage NATS communication based on a single source of truth that has the complete knowledge of the cluster, resulting in more robust, carefree NATS communication. In addition, TLS will be configured automatically, and a newer version of NATS will be used that has better performance and is easier to upgrade.

In addition, starting from DataMiner 10.6.0/10.6.1, the SLNet‑managed NATS solution is no longer supported, so the migration to BrokerGateway will have to be done before you can upgrade to these DataMiner versions and beyond.
