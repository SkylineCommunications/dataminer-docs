---
uid: General_Feature_Release_10.6.10
---

# General Feature Release 10.6.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.10](xref:Cube_Feature_Release_10.6.10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.10](xref:Web_apps_Feature_Release_10.6.10).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Prerequisites

Before you upgrade to this DataMiner version:

- Make sure **version 14.44.35211.0** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.

  The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):

  - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
  - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

- Make sure all DataMiner Agents in the cluster have been migrated to the BrokerGateway-managed NATS solution.

  For detailed information, see [Migrating to BrokerGateway](xref:BrokerGateway_Migration).

  See also: [DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43856] [ID 43861] [ID 44035] [ID 44050] [ID 44062]](xref:General_Feature_Release_10.6.1#dataminer-systems-will-now-use-the-brokergateway-managed-nats-solution-by-default-id-43856-id-43861-id-44035-id-44050-id-44062)

## Important changes

The following changes may have an impact on your system, so please make sure to check these before you upgrade:

- [Load, save, and delete actions for services have been rerouted from SLXml to the StorageModule DcM [ID 46134]](#load-save-and-delete-actions-for-services-have-been-rerouted-from-slxml-to-the-storagemodule-dcm-id-46134)

## Highlights

*No highlights have been selected yet.*

## New features

#### DataMiner key vault [ID 44075] [ID 44349] [ID 44350] [ID 44351] [ID 44352] [ID 44353] [ID 44354] [ID 44701] [ID 44702] [ID 44911] [ID 46047] [ID 46061]

<!-- MR 10.7.0 - FR 10.6.10 -->

From DataMiner 10.7.0/10.6.10 onwards, all credentials managed through the Credentials Library (SNMPv2/community, SNMPv3, username/password, and token credentials) will be protected using encryption at rest.

Key enhancements include:

- Secure storage of secrets as authenticated ciphertext (AES-256-CBC with HMAC-SHA-256) in a dedicated encrypted store managed by the DataMiner StorageModule, with support for Cassandra, cloud storage, and XML-based deployments. Encryption keys are stored per node and protected using Windows DPAPI.

- Introduction of the DMS backup password, needed to restore encrypted backups on clean machines while maintaining secure key custody. The restore wizard will automatically detect when the password is required and will validate it during restore operations.

- Automatic migration of existing credentials from *Library.xml* to the encrypted store during upgrades, and reconstruction of *Library.xml* during downgrades for backwards compatibility.

- Cluster-wide secret re-encryption support through the SLNetClientTest tool, allowing administrators to rotate encryption keys and re-encrypt all stored secrets without changing credential identifiers.

- Additional security and robustness improvements, including permission enforcement for credential management, duplicate-name protection, decryption failure detection, and extensive reliability enhancements.

> [!IMPORTANT]
> The DMS backup password should be stored securely outside DataMiner (for example, in a password manager). If it is lost, encrypted credentials in any backup taken with that password can no longer be recovered on a clean host. In a multi-node cluster, a peer DataMiner Agent can re-synchronize the encryption material to a restored node, but this should not be relied upon as a substitute for a properly configured DMS backup password.

<!-- See also Cube RNs [ID 45704] [ID 45997] -->

#### SLNet will now listen for connection ticket requests over NATS [ID 46057]

<!-- MR 10.7.0 - FR 10.6.10 -->

From now on, SLNet will listen on the `SLNet.Authentication.Ticket` NATS topic to process connection tickets and return the username associated with the ticket.

This allows APIGateway to authenticate requests via the NATS-based connection flow.

> [!NOTE]
> Tickets can be requested with `connection.RequestCloneTicket()`. This feature does not currently support impersonation with `TicketType.AuthenticateAs`.

#### Automation: Credentials can now be added within the XML code of an automation script [ID 44282]

<!-- MR 10.7.0 - FR 10.6.10 -->

Automation scripts now support adding credentials from the Credential Library directly in the script's XML code.

See the following example:

```xml
<Credentials>
    <Credential id="1">
        <Name>MyCredential</Name>
        <CredentialId>8d15e7d8-f8f6-41f6-985c-fddbd3ea94ae</CredentialId>
    </Credential>
</Credentials>
```

| Element | Attribute | Content |
|---|---|---|
| Credential | id | Any integer, unique per credential in the script |
| Name | - | Unique user-defined string |
| CredentialId | - | GUID of an existing credential from the Credential Library |

> [!NOTE]
> If users add or import a script, and they do not have access to one or more of the specified credentials, those credentials will be cleared, and the script will becomes non-executable until valid credentials are assigned.

See also: [Automation: Credentials can now be added to automation scripts [ID 44282]](xref:Cube_Feature_Release_10.6.10#automation-credentials-can-now-be-added-to-automation-scripts-id-44282)

## Changes

### Enhancements

#### Cassandra Cluster Migrator tool now supports migrating Credentials Library credential types [ID 45824]

<!-- MR 10.7.0 - FR 10.6.10 -->

The Cassandra Cluster Migrator tool (`SLCCMigrator.exe`), which migrates data to Cassandra Cluster from MySQL or Cassandra Single, now also supports migrating credential types that inherit from `ACredentialConfig`, i.e., all credential types that can be created in the Credentials Library.

#### UserDefinableApiEndpoint DxM has been upgraded to Microsoft .NET 10 [ID 46066]

<!-- MR 10.7.0 - FR 10.6.10 -->

The UserDefinableApiEndpoint DxM has been upgraded to Microsoft .NET 10.

#### Enhanced performance when recalculating security keys [ID 46077]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

Because of a number of enhancements, overall performance has increased when recalculating security keys.

#### DataMiner Taskbar Utility: Event colors now align with DataMiner Cube [ID 46130]

<!-- MR 10.7.0 - FR 10.6.10 -->

The colors used by the DataMiner Taskbar Utility for upgrade events now align with the colors used by DataMiner Cube. This makes it easier to identify the status of events such as `Finished`, `Success`, `LocalComplete`, `UploadComplete`, `UpgradeComplete`, `Notice`, and `Error`.

#### Load, save, and delete actions for services have been rerouted from SLXml to the StorageModule DcM [ID 46134]

<!-- MR 10.7.0 - FR 10.6.10 -->

In preparation of service swarming, all load, save, and delete actions for services have been rerouted from SLXml to the StorageModule DcM.

#### Automation: GetAvailableAutomationScripts now returns additional script information [ID 46140]

<!-- MR 10.7.0 - FR 10.6.10 -->

The `GetAvailableAutomationScripts` call now returns the following additional information for each script:

- `IsInteractive`: Indicates whether the script can show UI elements.
- `CanBeExecuted`: Indicates whether the script can be run on its own. Scripts that only contain reusable libraries return `false`.

#### User-Defined APIs: IIS rewrite rules are now validated and repaired by the UserDefinableApiEndpoint DxM [ID 46143]

<!-- MR 10.7.0 - FR 10.6.10 -->

The UserDefinableApiEndpoint DxM now owns the IIS rewrite rule that reroutes requests sent to `/api/custom` to the endpoint. It now validates the rule when the process starts and keeps checking it while the service runs, repairing it automatically if needed.

If the rewrite rule is missing, disabled, or no longer matches the expected routing behavior, the DxM will restore it with the correct configuration. This ensures that user-defined API requests keep working even if the IIS configuration has been changed outside the installer.

### Fixes

#### Agent element alarm and masking information could be out of sync after a Failover switch [ID 45601]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

Up to now, when a DataMiner Agent came online after a Failover switch, the Agent element alarm tree and mask state could remain stale in memory. As a result, alarm and masking information for the Agent element could temporarily differ from what was stored in the database.

From now on, when the Agent comes online after the Failover switch, the Agent element's alarm and masking information are explicitly reloaded from the database. This ensures that the incoming Agent immediately reflects the correct alarm tree, correlated alarms, and mask state.

#### SLDataGateway select paging handlers were not cleaned up correctly [ID 45937]

<!-- MR 10.7.0 - FR 10.6.10 -->
<!-- Not added in MR 10.7.0 -->

When SLDataGateway performed a select read page by page, the database-specific paging handler could remain active after the read completed. In addition, query limits were not consistently enforced across the returned pages.

From now on, select reads use the same paging lifecycle and limit handling as regular reads. This ensures that limits are applied consistently, the final partial page is returned correctly, and the paging handlers are cleaned up when paging finishes.

#### Table subscriptions with forceFullTable filter did not deliver updates for newly added rows on regular tables [ID 45970]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

Up to now, when you created a subscription on a regular (non-partial) table and included the `forceFullTable=true` extra filter, updates for rows that did not yet exist at subscription creation time were not delivered.

From now on, this filter will be ignored for regular tables. As a result, subscriptions that include this filter now behave the same as subscriptions without it, and updates for newly added rows are delivered correctly.

View tables, direct view tables, partial tables, and matrixes are not affected.

#### SLAutomation deadlock when many subscripts were launched rapidly [ID 46056]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

SLAutomation could deadlock when many subscripts were launched in a short time. This issue has been resolved.

#### DataMiner upgrade: Legacy NAS and NATS services and files would not be removed [ID 46094]

<!-- MR 10.7.0 - FR 10.6.10 -->
<!-- Not added to MR 10.7.0 -->

When you upgraded to DataMiner 10.6, up to now, the upgrade could leave behind the legacy NAS and NATS services, the `C:\Skyline DataMiner\NATS` folder, and the `NATSRepair.exe` tool.

From now on, a new upgrade action named `CleanupNatsServices` removes these legacy services and files after a DataMiner Agent has been upgraded to a 10.6 version. This ensures that the BrokerGateway-managed NATS solution can be used without the obsolete components.

#### SLAutomation could hang during shutdown [ID 46123]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

In some cases, a race condition could cause the SLAutomation process to hang during shutdown.

As a result, a DataMiner upgrade could be delayed unnecessarily by up to 5 minutes.

#### DataMiner Agent Minimum Requirements BPA test incorrectly checked physical CPU cores [ID 46154]

<!-- MR 10.6.0 [CU7] - FR 10.6.10 -->

Up to now, the *DataMiner Agent Minimum Requirements* BPA test would incorrectly check physical CPU cores instead of logical CPU cores. As a result, virtualized environments such as a DaaS system could incorrectly be reported as not meeting the minimum CPU core requirements.

This issue has now been fixed. The test now checks logical CPU cores.

#### Invalid cleared correlated alarms could be generated when DVE linking changed [ID 46174]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

When a correlation rule with the *AutoClear* option disabled generated an alarm for base alarms on a linked DVE table, DataMiner could generate invalid cleared alarms if the linked row disappeared and reappeared or was unlinked and relinked.

#### gRPC connections could fail when the User-Agent value was invalid [ID 46192]

<!-- MR 10.6.0 [CU7] - FR 10.6.10 -->

Custom applications using the SLNet gRPC client could fail to establish a connection when their product version contained characters that led to an invalid User-Agent value during the APIGateway health check.

As a result, the connection could incorrectly be reported as `APIGateway is unavailable`.

From now on, invalid User-Agent values are skipped, so the health check can continue and the gRPC connection can be established correctly.
