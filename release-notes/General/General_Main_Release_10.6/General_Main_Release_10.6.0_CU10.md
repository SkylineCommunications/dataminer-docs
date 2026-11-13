---
uid: General_Main_Release_10.6.0_CU10
description: "Release notes for General Main Release 10.6.0 CU10, including prerequisites, enhancements, and fixes planned for this preview release."
---

# General Main Release 10.6.0 CU10 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.6.0 CU10](xref:Cube_Main_Release_10.6.0_CU10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.6.0 CU10](xref:Web_apps_Main_Release_10.6.0_CU10).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Prerequisites

Before you upgrade to this DataMiner version:

- Make sure **version 14.44.35211.0** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.

  The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):

  - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
  - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

- Make sure all DataMiner Agents in the cluster have been migrated to the BrokerGateway-managed NATS solution.

  For detailed information, see [Migrating to BrokerGateway](xref:BrokerGateway_Migration).

  See also: [DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43526] [ID 43856] [ID 43861] [ID 44035] [ID 44050] [ID 44062]](xref:General_Main_Release_10.6.0_changes#dataminer-systems-will-now-use-the-brokergateway-managed-nats-solution-by-default-id-43526-id-43856-id-43861-id-44035-id-44050-id-44062)

## Changes

### Enhancements

#### DataMiner Installer: Initial DataMiner configuration wizard has been redesigned [ID 45483]

<!-- MR 10.6.0 [CU10] - FR 10.6.12 -->

The initial DataMiner configuration wizard has been redesigned to guide you through selecting a commercial model, configuring storage, and connecting to dataminer.services.

You can now follow this setup flow:

1. Select a commercial model: Community Edition, usage-based services, or a perpetual-use license with a supplied DataMiner ID.

   Community Edition requires acceptance of its terms.

1. Choose Storage as a Service (STaaS), locally hosted storage, or externally hosted storage.

1. Connect to dataminer.services when required.

   The wizard will open a browser where you can sign in or create an account. Connection is required for Community Edition, usage-based services, and STaaS. For perpetual-use licenses with self-hosted storage, cloud registration is optional.

1. Complete the applicable configuration details and review the setup.

   Only the pages relevant to your selected configuration will be shown.

1. Apply the configuration.

   The wizard will report progress and stop if a configuration step fails.

The cloud registration page provides options to reopen the sign-in page, retry registration, or refresh registration details.

For perpetual-use licensing, you can supply an existing license file or generate a license request. License requests can now be generated without first starting and stopping DataMiner. Missing required configuration files are initialized automatically, preventing setup failures on fresh installations.

Unattended configuration remains available for subscription and perpetual-use licensing. Passing a configuration file path containing spaces from the installer is now also handled correctly.

#### DataMiner Installer: Improved licensing registration and separate database TLS settings [ID 45881]

<!-- MR 10.6.0 [CU10] - FR 10.6.12 -->

During interactive setup, licensing registration now uses licensing API v2 with a bearer token obtained through CloudGateway instead of an organization API key. You authenticate in your browser, after which the wizard obtains the token and completes registration. Token acquisition is retried for up to two minutes with increasing delays between attempts.

After successful registration, DataMiner restarts automatically and its startup is validated. The wizard no longer asks for an organization API key, system URL, administrator email address, or STaaS region.

Cloud registration now uses a complete session URL provided by CloudGateway, with improved session tracking and browser authentication. The sign-in screen now displays the DataMiner logo instead of a globe icon.

For externally hosted databases, separate TLS checkboxes now allow you to enable TLS independently for Cassandra and OpenSearch. Previously, both databases shared the same TLS setting. The corresponding properties are `CassandraTlsEnabled` and `OpenSearchTlsEnabled`.

#### DataMiner upgrade: Upgrade action to configure SAML authentication redirects [ID 46589]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

From now on, an upgrade action will automatically add a `Set-Cookie` header to `WebPages/web.config` on systems with SAML authentication enabled. This cookie configures web authentication to use redirects instead of an embedded iframe, ensuring compatibility with SAML providers that do not allow their sign-in pages to be displayed in an iframe.

The upgrade action will leave the configuration unchanged if SAML is disabled or the required cookie header is already configured. Existing custom headers, including `Set-Cookie` headers for other cookies, will be preserved.

#### DataMiner upgrade: Improved performance of the ValidateConnectors prerequisite [ID 46743]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

The `ValidateConnectors` upgrade prerequisite checks for installed connector versions that are incompatible with the target DataMiner version. Previously, it recursively scanned the entire `C:\Skyline DataMiner\Protocols` folder, which could slow down upgrade prerequisite checks on DataMiner Agents with many connectors or large connector version folders.

From now on, it will only scan folders for connectors on the incompatibility list, and only at the level where *protocol.xml* is expected. This makes the check faster and less sensitive to unrelated content in the *Protocols* folder.

The incompatible connector versions reported, the message shown, and the requirement to remove those versions before upgrading remain unchanged. No configuration is required.

#### MessageBroker: Large ChunkingMessageBroker replies will now use acknowledged chunks [ID 46882]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

From now on, large ChunkingMessageBroker replies will use acknowledged chunks to avoid NATS slow consumer exceptions.

#### BrokerGateway: Increased timeout for applying manual configurations [ID 46949]

<!-- MR 10.7.0 [CU0] / 10.6.0 [CU10] - FR 10.7.1 -->

The fixed timeout for the BrokerGateway `applymanualconfig` call has been increased from 5 minutes to 30 minutes.

### Fixes

#### SLNet: Array index errors when retrieving alarm filter, trend filter, or redundancy group information [ID 46607]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

SLNet could throw an `IndexOutOfRangeException` when retrieving available alarm filter, trend filter, or redundancy group information if an SLXML query returned an array with unexpected dimensions.

SLNet will now retry failed redundancy group queries once after a short delay. Array index errors will also be logged in *SLNet.txt* with the variable name, the exact array index, and the complete query response array in compressed form to help diagnose the issue.

#### STaaS: Incomplete state-change history after migrating from Cassandra [ID 46769]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

After migrating from Cassandra to STaaS, state-change history could be incomplete for parameters in index-only tables or tables with a display column when the parameter instance contained uppercase characters. This could affect dashboards and heatlines in DataMiner Cube.

This issue occurred when history was stored under both the original-case and lowercase instances. State-change retrieval now reads both instances and merges the results by timestamp, giving precedence to the lowercase instance when timestamps match.

#### Standalone BPA executor: BPA tests requiring SLNet could fail to run [ID 46809]

<!-- MR 10.5.0 [CU22]/10.6.0 [CU10] - FR 10.7.1 -->

The standalone BPA executor would throw a `NullReferenceException` when running a manually loaded BPA DLL file with the `RequireSLNet` flag, preventing the BPA test from executing.

#### StorageModule: Errors or missing data when retrying storage operations [ID 46815]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

When a StorageModule insert operation was retried after a NATS timeout, it could be executed twice. The retry would then fail with an error indicating that the file or database row already existed. Insert operations now use an idempotency key to prevent the same operation from being executed more than once.

During paged read operations, retries when fetching pages after the first page could cause data to be missed following a timeout. These requests will no longer be retried. If a read operation fails, an error will be returned instead.

#### DataMiner upgrade: DxMs installed under a previous product name could be skipped [ID 46938]

<!-- MR 10.7.0 / 10.6.0 [CU10] - FR 10.7.1 -->

During a DataMiner upgrade, installed DxMs could fail to be recognized if their product name had changed. For example, an existing SiteManager installation could be skipped instead of being upgraded to EdgeManager.

The upgrade process now uses MSI upgrade codes to detect related products and recognize installations made under a previous product name.

#### Service & Resource Management: Canceled reservations could prevent resource updates [ID 46952]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

Resources could not be updated when they were used by a canceled reservation. This could prevent changes to the resource mode, such as putting a resource into maintenance, as well as changes to its availability window or capacity.

Canceled reservations are now ignored when checking whether resource updates would cause reservations to enter quarantine.

#### API Gateway: Missing proxy routes after a restart could cause persistent HTTP 404 errors [ID 46956]

<!-- MR 10.7.0 [CU0] / 10.6.0 [CU10] - FR 10.6.12 -->

After API Gateway restarted, requests to modules proxied through it could keep returning HTTP 404 errors. This could affect DataAPI, Orchestrator, Assistant, and EdgeManager.

Concurrent module registrations could overwrite newer routing configuration with an older snapshot, leaving proxy routes missing. Routing configuration updates are now processed sequentially to prevent this.

#### BPA test 'DataMiner Agent Minimum Requirements' could fail with an execution error [ID 47078]

<!-- MR 10.6.0 [CU10] - FR TBD -->

After upgrading to certain DataMiner 10.6 builds, the *DataMiner Agent Minimum Requirements* BPA test could fail with an execution error instead of evaluating the system requirements.

#### DataMiner upgrade: CloudFeed DxM installed on Agents where it was not present [ID 47095]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

Previously, a DataMiner upgrade would install the CloudFeed DxM even on DataMiner Agents where it was not installed or had previously been uninstalled.

From now on, the CloudFeed DxM will only be upgraded if it is already installed. It will be updated to the version included in the DataMiner upgrade package. This prevents unnecessary resource consumption on DataMiner Agents that do not need the CloudFeed DxM.
