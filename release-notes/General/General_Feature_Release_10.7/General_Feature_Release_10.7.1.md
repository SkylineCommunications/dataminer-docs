---
uid: General_Feature_Release_10.7.1
description: "Release notes for General Feature Release 10.7.1, including prerequisites, new features, enhancements, and fixes planned for this preview release."
---

# General Feature Release 10.7.1 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.7.1](xref:Cube_Feature_Release_10.7.1).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.7.1](xref:Web_apps_Feature_Release_10.7.1).
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

*No important changes have been selected yet.*

## Highlights

*No highlights have been selected yet.*

## New features

### Security: New 'Intelligence Usage' user permission [ID 46765]

<!-- MR 10.8.0 - FR 10.7.1 -->

A new *Intelligence Usage* user permission has now been added. This permission will grant users access to all features related to DataMiner Intelligence.

> [!NOTE]
> The first time a system is upgraded to DataMiner version 10.8.0/10.7.1 or above, DataMiner will automatically grants this new permission to all existing groups with the *Admin Tools* permission.

## Changes

### Enhancements

#### SLProtocol: Support for postPonePortInitialisation option removed [ID 46588]

<!-- MR 10.8.0 - FR 10.7.1 -->

Support for the [`postPonePortInitialisation`](xref:Protocol.Type-communicationOptions#postponeportinitialisation) communication option has been removed from SLProtocol.

#### DataMiner upgrade: Upgrade action to configure SAML authentication redirects [ID 46589]

<!-- MR 10.8.0 - FR 10.7.1 -->

From now on, an upgrade action will automatically add a `Set-Cookie` header to `WebPages/web.config` on systems with SAML authentication enabled. This cookie configures web authentication to use redirects instead of an embedded iframe, ensuring compatibility with SAML providers that do not allow their sign-in pages to be displayed in an iframe.

The upgrade action will leave the configuration unchanged if SAML is disabled or the required cookie header is already configured. Existing custom headers, including `Set-Cookie` headers for other cookies, will be preserved.

#### DataMiner upgrade: Prerequisite check for Communication Gateway DxM version [ID 46798]

<!-- MR 10.8.0 - FR 10.7.1 -->

During a DataMiner upgrade, a new prerequisite check will verify the version of the installed Communication Gateway DxM. If the installed version is older than 5.3.5, the upgrade will be blocked.

If the installed Communication Gateway DxM version is older than 4.0.0, the check will also identify the following connectors that use an outdated version of the `Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Protocol` NuGet package:

- Arista eOS Manager versions older than 1.0.0.5
- CISCO Nexus versions older than 3.0.7.3

To resolve these issues, upgrade Communication Gateway DxM to version 5.3.5 or higher. If any elements use a listed connector, configure them to use a connector version that uses version 6.0.0 or higher of the NuGet package. Remove listed connectors that are not in use.

The additional connector check only detects these known connectors. Make sure no other connectors in use depend on a version of the NuGet package older than 6.0.0.

#### DataMiner upgrade: Web-only upgrades to 10.7.x or later require at least 10.6.0 [ID 46910]

<!-- MR 10.8.0 - FR 10.7.1 -->

Web-only upgrade packages for version 10.7.x or later will now be blocked on DataMiner Agents running a server version older than 10.6.0. The error message will indicate this minimum version requirement.

For example, before installing a 10.7.x web-only upgrade on a DataMiner Agent running 10.5.0, you will first have to perform a full upgrade to 10.6.0 or later.

This validation does not affect full DataMiner upgrades.

### Fixes

#### Standalone BPA executor: BPA tests requiring SLNet could fail to run [ID 46809]

<!-- MR 10.5.0 [CU22]/10.6.0 [CU10] - FR 10.7.1 -->

The standalone BPA executor would throw a `NullReferenceException` when running a manually loaded BPA DLL file with the `RequireSLNet` flag, preventing the BPA test from executing.
