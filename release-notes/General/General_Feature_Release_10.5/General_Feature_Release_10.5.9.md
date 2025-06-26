---
uid: General_Feature_Release_10.5.9
---

# General Feature Release 10.5.9 – Preview

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
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.9](xref:Cube_Feature_Release_10.5.9).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.9](xref:Web_apps_Feature_Release_10.5.9).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### Automation scripts: New Interactivity tag [ID 42954]

<!-- MR 10.6.0 - FR 10.5.9 -->

Up to now, Automation scripts using the IAS Interactive Toolkit required a special comment or code snippet in order to be recognized as interactive. From now on, you will be able to define the interactive behavior of an Automation script by adding an `<Interactivity>` tag in the header of the script. See the following example.

```xml
<DMSScript xmlns="http://www.skyline.be/automation">
  ...  
  <Interactivity>Always</Interactivity>
  ...
  <Script>
    ...
  </Script>
</DMSScript>
```

Possible values:

| Value | Description |
|-------|-------------|
| Auto     | Like before, an attempt will be made to automatically detect the interactive behavior of the script. |
| Never    | The script will never show any UI element. |
| Optional | The script will be interactive when it needs to be. |
| Always   | The script will always be interactive. |

## Changes

### Enhancements

#### Failover: NATS cluster state will now be visible in DataMiner Cube's Failover Status window [ID 42250] [ID 43169]

<!-- MR 10.6.0 - FR 10.5.9 -->

In DataMiner Cube, the NATS cluster state will now be visible in the *Failover Status* window. This state will indicate whether NATS communication between main agent and backup agent is up and running and whether the *clusterEndpoints.json* file is synchronized between the two agents.

#### Swarming: An information event will be generated when an element was successfully swarmed [ID 43196]

<!-- MR 10.6.0 - FR 10.5.9 -->

From now on, an information event will be generated when an element was successfully swarmed.

Example:

`Swarmed from <DmaName> (<DmaId>) to <DmaName> (<DmaId>) by <UserName>`

> [!NOTE]
> When the source DMA is no longer available or unknown, the information event will be shortened to `Swarmed to <DmaName> (<DmaId>) by <UserName>`.

#### DataMiner upgrade: CloudGateway DxM now included in DataMiner upgrade packages [ID 43205]

<!-- MR 10.6.0 - FR 10.5.9 -->

From now on, the CloudGateway DxM will be included in DataMiner upgrade packages. However, the DxM will only be upgraded when an older version is found on the DataMiner Agent. If no older version is found, it will not be installed.

Current version: DataMiner CloudGateway 2.17.7

For detailed information about the changes included in this version, refer to the [Cloud Gateway release notes](xref:cloudgateway_change_log).

### Fixes

#### Service & Resource Management: Reservation ID of a service created from a service template would disappears when the template was re-applied [ID 43090]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When a service created from a service template had a reservation ID defined, up to now, that reservation ID would incorrectly disappear when the service template was re-applied.

#### DataMiner upgrade: Redirect tags in DMS.xml would incorrectly not be taken into account [ID 43172]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When `<Redirect via="..." />` tags were configured in the *DMS.xml* file, these would incorrectly not be taken into account when an SLNet instance retrieved upgrade progress messages from another SLNet instance.

Although the upgrade would succeed in the background, no information regarding the remote agents would be available in DataMiner Cube or the DataMiner TaskBar Utility during the upgrade, and notices saying that `http://<ip>:8004/UpgradeService` was unavailable would be added to the logs.
