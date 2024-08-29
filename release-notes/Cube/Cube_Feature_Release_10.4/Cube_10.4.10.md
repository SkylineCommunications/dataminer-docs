---
uid: Cube_Feature_Release_10.4.10
---

# DataMiner Cube Feature Release 10.4.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.4.10](xref:General_Feature_Release_10.4.10).

## Highlights

*No highlights have been selected yet.*

## New features

#### Failover Config window will now show information regarding the Pcap libraries that are installed on the DMAs [ID_40267]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When, in the *Failover Config* window, you have configured Failover with virtual IP addresses, the *Status* window will now also show information regarding the Pcap libraries that are installed on the two DataMiner Agents in the Failover setup.

For each of the two DataMiner Agents, one of the following messages will be displayed:

| Message | Description |
|---------|-------------|
| *No message shown*    | Either WinPcap or Npcap are installed on the DataMiner Agent. Hence, this agent can be used in a Failover setup with virtual IP addresses. |
| Pcap not installed    | Neither WinPcap nor Npcap are installed on the DataMiner Agent. Hence, it is not recommended to use this agent in a Failover setup with virtual IP addresses. |
| Could not be detected | A problem has occurred while trying to detect the presence of the WinPcap and Npcap libraries. |

To detect the presence of Pcap libraries on a DataMiner Agent, Cube will send a *PcapInfoRequestMessage* to the agent in question each time the *Failover Config* window is opened, and will then store the response in the Cube logging with keyword "PcapInfo". See also [RN 40257](xref:General_Feature_Release_10.4.10#failover-new-slnettypes-message-to-check-whether-pcap-is-installed-on-a-dataminer-agent-id_40257).

> [!NOTE]
>
> - These changes will only work in conjunction with DataMiner server version 10.4.9 or newer.
> - While it is not mandatory to install Pcap libraries on DataMiner Agents, it is highly recommended to install them on DataMiner Agents that will be used in Failover setups with virtual IP addresses.
> - As WinPcap is considered deprecated, it is recommended to use Npcap instead.
> - Only users who have been granted the *Modules > System configuration > Agents > Configure Failover* permission are allowed to send a *PcapInfoRequestMessage*. When you do not have this permission, an error message will appear.

## Changes

### Enhancements

#### Visual Overview: Support for dynamic values in AlarmFilter shape data value [ID_40228]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

In the AlarmFilter shape data value, dynamic values (e.g. session variables) are now supported.

#### Trending: Enhanced requirements check before displaying the relation learning light bulb in the top-right corner of a trend graph [ID_40396]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

Before it displays the relation learning light bulb in the top-right corner of a trend graph, DataMiner Cube has to perform a requirements check.

During that requirements check, up to now, it would use the *GetCCAGatewayGlobalStateRequest* message to check whether the DataMiner System is connected to dataminer.services. From now on, it will use the new *IsCloudConnected* message instead.

### Fixes

#### Interactive Automation script could become unresponsive while it was waiting for user input [ID_40358]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

While an interactive Automation script was waiting for user input, in some cases, it could become responsive, especially when Cube was connected to a heavily loaded DaaS system.

#### False-positive warning log entry when Services or Profiles module was opened [ID_40385]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When the Services or Profiles module was opened in Cube, a false-positive warning entry could be added to the Cube logging, with the following message:

```txt
Profile and Services - The visio file name was empty or null. Check the response message from the server
```

#### Problem when logging on to a DataMiner System that required an additional logon through a portal [ID_40387]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When you tried to log on via DataMiner Cube to a DataMiner System that required an additional logon through a portal, up to now, the logon would fail because an incorrect response would be passed on to the server. From now on, the correct response will be passed on.

#### Visual Overview: Shapes with ButtonState data would fail to hide as expected [ID_40454]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

Shapes with *ButtonState* data would fail to hide as expected.

#### Services: Problem when trying to edit a service that had been edited previously [ID_40493]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When, while editing a service, you added an element or another service to that service and applied the changes, it would no longer be possible to edit the service again. When you tried to do so, the service card would be empty.

#### Alarm Console: Problem with the counter showing the number of unread alarms in a tab page [ID_40522]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

In some cases, the counter showing the number of unread alarms in an alarm tab page could get out of sync.

When you disabled history tracking and marked an alarm as read, the counter would get out of sync as soon as the alarm you marked as read received an update. In some cases, the counter could even show a negative number of alarms.

#### Trending: Protocol selection box in Create Pattern window would be empty [ID_40539]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When, in a trend graph, you created a pattern, in some cases, the protocol selection box would incorrectly be empty.
