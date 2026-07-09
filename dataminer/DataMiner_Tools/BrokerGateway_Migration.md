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

1. Once the [prerequisites](#prerequisites) are met, you can either [run an automatic migration](#automatic-migration-using-dmupgrade-package-recommended) or, if recommended by Skyline, [run the migration manually](#manual-migration).

### Between DataMiner 10.5.0 [CU4]/10.5.7 [CU1] and DataMiner 10.5.0 [CU11]/10.5.12 [CU2]

1. Preferably, upgrade to DataMiner 10.5.0 [CU11] or 10.5.12 [CU2]. If this is not possible, proceed.

1. Ensure the [prerequisites](#prerequisites) are met.

1. Download the latest [NATSMigration.dmupgrade](https://community.dataminer.services/download/natsmigration-dmupgrade/) package.

1. Once the [prerequisites](#prerequisites) are met, you can [run an automatic migration] using the aforementioned (#automatic-migration-using-dmupgrade-package-recommended).

## Prerequisites

### Prerequisite-only.dmupgrade package

A [NATSMigration - Prerequisite only.dmupgrade](https://community.dataminer.services/download/natsmigration-dmupgrade/) package can be used to test system compatibility in advance, without the need for the user to commit to a BrokerGateway migration.
It should be run on all agents in the DMS.
The package only executes prerequisites and does not cause any impact on the DMS.

It verifies the [DataMiner requirements](#dataminer-requirements), the [.NET runtime requirements](#aspnet-core-runtime-10-hosting-bundle-for-automatic-migration) and the [IT-requirements](#it-requirements), then lets you know if any have failed.

>[!NOTE]
>
> - The NatsMigration.dmupgrade package also executes these prerequisites prior to migrating, effectively blocking the migration if a prerequisite fails. Therefore, we recommend running the prerequisite-only package in advance.
> - Ensure that you download the latest version of the .dmupgrade package, to guarantee the presence of all aforementioned prerequisites.
Before that version, certain prerequisites, such as the [IT-requirements](#it-requirements) or the [.NET runtime requirements](#aspnet-core-runtime-10-hosting-bundle-for-automatic-migration) are not present and need to be checked manually.

### ASP.NET Core Runtime 10 Hosting Bundle for automatic migration

When you run the automatic migration by using the `.dmupgrade` package, ensure that the [ASP.NET Core Runtime 10 Hosting Bundle](https://dotnet.microsoft.com/en-us/download/dotnet/10.0) is installed on each DataMiner Agent before you start the migration.
If it is not installed, the automatic migration cannot complete correctly.

### IT requirements

BrokerGateway needs TLS for the BrokerGateway DxMs to communicate between each other and for the communication between DataMiner and NATS.
Ideally, [HTTPS](xref:Setting_up_HTTPS_on_a_DMA) has already been set up, preferably with certificates used by a trusted Certificate Authority (CA).
In any other circumstance, self-signed certificates will be used.
In the latter case, the maintenance is more risky, since this is potentially the first setup of TLS/HTTPS within the DMS.

To make sure that the migration goes smoothly, please ensure that TLS 1.2 is enabled.

Furthermore, the associated *TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256* or *TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384* cipher suites need to be enabled on the server.

Finally, ensure that there are no problems with '[Schannel](https://learn.microsoft.com/en-us/windows-server/security/tls/tls-ssl-schannel-ssp-overview)' logged in the Windows Event Viewer's Application event log.

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

1. After the upgrade has completed, ensure that you execute the [Post-migration actions](#post-migration-actions) when applicable.

>[!NOTE]
>
>In case any issues occur during the migration, the output will be shown in the update client.
>This will look similar to the [manual migration log](#what-does-a-successful-manual-brokergateway-migration-look-like-in-logging). Aside from this, you can check the logging in `C:\Skyline DataMiner\Upgrades\Packages\NATSMigration.dmupgrade-XXX\progress.log` and in the upgrade utility UI.

## Manual migration

When recommended by Skyline, the migration can be run manually:

1. Ensure the [prerequisites](#prerequisites) are met.

1. Open a **remote desktop connection** to **all** DataMiner Agents at the same time.

1. On each Agent, open an elevated command prompt and run `C:\Skyline DataMiner\Tools\NATSMigration.exe`, with the optional argument `-r` to keep the script from restarting DataMiner.

1. Enter the `install` command on every Agent (including Failover Agents) within 10 minutes.

1. After the upgrade has completed, ensure that you execute the [Post-migration actions](#post-migration-actions) when applicable.

> [!IMPORTANT]
>
> - This must happen on **each DMA** in the cluster **within a 10-minute time frame**.
It is very important that this happens for **each individual DataMiner Agent, including Failover DMAs**. Prior to DataMiner 10.5.0 [CU4]/10.5.7, this also involves a restart of each DataMiner Agent.
> - On DataMiner 10.5.12 [CU2], manual migration may fail due to the latest BrokerGateway version not being able to install. If you need to execute a manual migration BGW migration on that version, please contact Skyline Communications.

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

## Troubleshooting the migration

### How can I tell the difference between SLNet-managed NATS and BrokerGateway-managed NATS?

The key technical differences are:

| | <div style="width:310px">Legacy SLNet-managed NATS/NAS services</div> | BrokerGateway-managed NATS service |
|--------|------------------------------|-----------------------|
| **Services** | Windows services: NAS, NATS. | Windows service: `nats-server`; BrokerGateway service (IIS/Kestrel hosted) supplies credentials and clustering. |
| **Config source** | `SLCloud.xml`, NAS/NATS config files. | `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json` (endpoints), `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json` (BrokerGateway). |
| **Credentials** | `.creds` files under `C:\Skyline DataMiner\NATS\nsc`. | Dynamic credentials via BrokerGateway API. Saved on disk in `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\nats-server\.data\nats\nsc`. |
| **Cluster formation** | NATSCustodian recalculates NAS/NATS configs. | BrokerGateway API builds cluster. |
| **Repair tool** | [Manual reset / reinstall](xref:Investigating_Legacy_NATS_Issues#remaining-steps). | `C:\Skyline DataMiner\Tools\NATSRepair.exe` tool. |

### Can I run a cluster with both SLNet-managed NATS and BrokerGateway-managed NATS at the same time?

This is not possible. Both NATS installations use the same network ports, so the services cannot run at the same time on a machine. The credentials these installations use are also different and not compatible with each other, so running SLNet-managed NATS on DMA1 and BrokerGateway-managed NATS on DMA2 will also not function.

### What actions are typically run during the migration?

The following actions will be executed automatically during the migration, in the indicated order:

1. Prerequisites for the migration are checked.

   This includes the [Verify NATS Migration Prerequisites](xref:BPA_NATS_Migration_Prerequisites) BPA test and (from DataMiner 10.5.0 [CU9]/10.5.12 onwards) a check for outdated DLLs in the *ProtocolScripts* folder. If any of the prerequisites are not met or if an outdated DLL is found, you will first need to solve the issue before you can start the migration again.

1. The *BrokerGateway* flag in `C:\Skyline DataMiner\MaintenanceSettings.xml` is set to true, or, if you are using a DataMiner version prior to 10.5.0 [CU2]/10.5.5, a *BrokerGateway* soft-launch flag is set instead.

   ```xml
   <MaintenanceSettings xmlns="http://www.skyline.be/config/maintenancesettings">
      <SLNet>
         <BrokerGateway>true</BrokerGateway>
      </SLNet>
   </MaintenanceSettings>
   ```

1. The SLNet-managed NAS and NATS services are stopped and their startup type is set to "Manual".

1. The *ResetCluster* API (`https://<ip>/BrokerGateway/api/clusteringapi/resetcluster`) is called on BrokerGateway to create a new BrokerGateway-managed NATS cluster, and the NATS binaries are installed at `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\nats-server` and started as a service called "nats-server".

   The *ResetCluster* API call is only executed by one of the NATSMigration instances, if a cluster is migrated. The node that will execute this command is the one with the lowest IP alphabetically. The other nodes will wait until a NATS session using BrokerGateway can be created.

1. The *MessageBrokerConfig.json* file is written at `C:\ProgramData\Skyline Communications\DataMiner\MessageBrokerConfig.json`.

   This file is used when initializing default sessions for DataMiner processes using the NATS communication channel. During system migration, the file is automatically overwritten to include the correct BrokerGateway URL and the path to the associated API key.

A typical example of this file’s contents is shown below:

   ```json
   {
     "BrokerGatewayConfig": {
       "CredentialsUrl": "https://HOST/BrokerGateway/api/natsconnection/getnatsconnectiondetails",
       "APIKeyPath": "C:\\Program Files\\Skyline Communications\\DataMiner BrokerGateway\\appsettings.runtime.json"
     }
   }
   ```

> [!NOTE]
> The NATSMigration tool has a hard‑coded 10‑minute timeout for completing the *ResetCluster* operation. If for some reason the migration cannot be completed within 10 minutes, or if something goes wrong during the migration, all Agents will revert back to using the SLNet-managed NATS solution.<!-- RN 41115 -->

> [!IMPORTANT]
> The NATS configuration (*nats-server.config*) of the NATS instance before the migration is not transferrable to the NATS instance after the migration, so it should **never be copied over**.

### What does a successful manual BrokerGateway migration look like in logging?

Below is a full sample output of a successful manual migration run. The machine name has been replaced by `HOSTNAME` and the IP addresses by `IP1`, `IP2`, and virtual IP `VIP1`. Timestamps have been removed as well. This output is only visible if `C:\Skyline DataMiner\Tools\NATSMigration.exe` is manually executed from a command prompt.
In this case, the tool has been initialized with options "--norestartdataminer" and "--install", written (in shorthand) as follows: "NATSMigration.exe -ri".

```cmd
C:\Skyline DataMiner\Tools>NATSMigration.exe -ri
[05/29/26 11:58:55.321]HOSTNAME - Warning: 'norestartdataminer' flag is set. DataMiner needs to be restarted to be able to automatically reconfigure nats-server. Make sure to restart DataMiner manually to prevent unwanted behaviour.
[05/29/26 11:58:55.417]HOSTNAME - Running prerequisite check before switching to BrokerGateway...
[05/29/26 11:58:57.351]HOSTNAME - All prerequisites ran successfully. No issues detected.
[05/29/26 11:58:57.353]HOSTNAME - Migrating to BrokerGateway managed nats-server.
[05/29/26 11:58:57.406]HOSTNAME - BrokerGateway maintenance flag is set to True.
SLKill called for "nats" with force=False
*** Stop services ***
Service (NATS) has been stopped.
*** Kill processes ***
Process (nats-account-server : 21736) has been killed.
SLKill called for "nas" with force=False
*** Stop services ***
Service (NAS) has been stopped.
*** Kill processes ***
[05/29/26 11:58:59.850]HOSTNAME - DataMiner BrokerGateway is started.
[05/29/26 11:59:00.195]HOSTNAME - DataMiner BrokerGateway is reachable.
[05/29/26 11:59:00.254]HOSTNAME - Agent that will set up the cluster: IP1
[05/29/26 11:59:00.285]HOSTNAME - This agent is setting up the cluster...
[05/29/26 11:59:00.302]HOSTNAME - checking if BGW of IP1 is running...
[05/29/26 11:59:00.329]HOSTNAME - BGW of IP1 is running.
[05/29/26 11:59:00.330]HOSTNAME - checking if BGW of IP2 is running...
[05/29/26 11:59:00.331]HOSTNAME - BGW of IP2 is running.
[05/29/26 11:59:00.431]HOSTNAME - Cluster consists of following endpoints: IP1 (VIP1), IP2 (VIP1)
[05/29/26 11:59:00.434]HOSTNAME - Calling ResetCluster endpoint.
[05/29/26 11:59:03.830]HOSTNAME - Contacted nats-server and BrokerGateway successfully!
[05/29/26 11:59:03.832]HOSTNAME - Setting the MessageBrokerConfig.json...
[05/29/26 11:59:03.849]HOSTNAME - Migration successful!
```

### ERROR: {machineName} was not able to remove itself from its current cluster in order to join the new cluster

When calling *ResetCluster*, BrokerGateway will first try to remove itself from any cluster it is part of, in order to set up a new cluster with all the endpoints specified in `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json`.

The endpoints BrokerGateway is currently clustered with are listed in the ClusterInfo in `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json`. If one of those IPs cannot be reached, the error message above is generated.

You will be asked if the node may be forcibly removed. If you agree to this, the current machine can free itself from the cluster to cluster with the new setup instead. However, because it forcibly removes itself, it no longer informs any of the unreachable endpoints of its removal. These may still attempt to contact the current machine, which will no longer be reachable for them. If you choose to not allow the forcible removal, this will cancel the migration process and revert back to the previous configuration.<!-- RN 40991 -->

If you do want to migrate to BrokerGateway but you do not want this forced removal, make sure all endpoints specified in *appsettings.runtime.json* can be reached by the current machine.

With the [automatic migration](#automatic-migration-using-dmupgrade-package-recommended), forced removal is always performed automatically when regular removal does not succeed.

### NATSRepair.exe

If you encounter any issues with your NATS cluster related to credentials or misconfigured nodes and you have migrated to BrokerGateway, you can run the *NATSRepair.exe* tool from the `C:\Skyline DataMiner\Tools\` folder.

This tool needs to be run on just one Agent of the cluster. It will perform a repair on the cluster.<!-- RN 42328 -->

### TLS-related errors

After a DataMiner System has been migrated to BrokerGateway, DMAs may generate the following alarm:

```txt
Could not connect to the local NATS endpoint on '<IP>'. Please make sure that the nats service is running without issues.
```

This coincides with errors in the `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\nats-server\nats-server.log` files similar to the following error:

```txt
TLS handshake error: remote error: tls: bad certificate
```

This TLS handshake failure occurs because the root certificate authority (CA) used to sign the NATS server certificate is not present in the Trusted Root Certification Authorities store of the local machine.

During BrokerGateway setup, a root ca.pem file is generated in `C:\ProgramData\Skyline Communications\DataMiner Security`. If this certificate is not trusted on OS level, Windows will reject the TLS connection.

To resolve this issue, import the generated root certificate into the Trusted Root Certification Authorities store on each DMA via the Microsoft Management Console (MMC).

> [!TIP]
> See also: [Resolved issues — TLS authentication issues when MessageBroker is connecting to the NATS bus](xref:KI_DataMinerMessageBroker_TLS)
