---
uid: Cube_Feature_Release_10.6.2
---

# DataMiner Cube Feature Release 10.6.2 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.5.0 [CU11].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.2](xref:General_Feature_Release_10.6.2).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.2](xref:Web_apps_Feature_Release_10.6.2).

## Highlights

*No highlights have been selected yet.*

## New features

#### Visual Overview: New shape data field of type VLC [ID 43750] [ID 44265]

<!-- MR 10.5.0 [CU11] / 10.6.0 [CU0] - FR 10.6.2 -->

You can now use a shape data field of type VLC to make a shape show a video stream or video source via VLC in an inline window.

To do so, add a shape data field of type VLC, and set its value to a link that points to the video stream or video source. That link is allowed to contain the `<DMAIP>` placeholder.

For this feature to work, VLC needs to be installed on the client machine. DataMiner Cube will try to find the VLC application on the local system (see below), and will use that VLC application and its plugins. Note that only the 64-bit version of VLC will work.

DataMiner Cube will try to find the VLC application in the following way:

1. Check if the `VLC_PATH` environment variable exists.
1. Check if VLC is installed in `C:\Program Files`.
1. Check if VLC is installed in `C:\Program Files (x86)`. If so, the user will receive a warning, saying that the 32-bit version of VLC is not supported.
1. Check the registry.

> [!NOTE]
> This new shape data field of type VLC is not supported in visual overviews that are used in web apps.

## Changes

### Enhancements

#### Alarm templates: New flatline detection modes in Augmented Operations alarm settings [ID 44191]

<!-- MR 10.5.0 [CU11] / 10.6.0 [CU0] - FR 10.6.2 -->

When, in an alarm template, you are configuring the Augmented Operations alarm settings for a particular parameter, you can now also choose between the following flatline detection modes:

| Mode | Description |
|------|-------------|
| Smart flatline alarming    | In this mode, SLAnalytics will automatically determine when a flatline period is anomalous by comparing it to the parameter's historical behavior. A new flatline period will only trigger an alarm if it is significantly longer than previously observed flat periods. |
| Absolute flatline alarming | In this mode, you can define a fixed duration threshold (in seconds) for when a flatline event should trigger an alarm. Additionally, you can assign a severity level to the generated flatline alarm event. |

> [!IMPORTANT]
> This feature will only work in conjunction with DataMiner server version 10.7.0/10.6.2 or newer. See: [Augmented Operations: Server-side support for new flatline detection modes [ID 44094]](xref:General_Feature_Release_10.6.2#augmented-operations-server-side-support-for-new-flatline-detection-modes-id-44094)

#### Alarm Console: Advanced search options would incorrectly be visible on systems that did not include an Elasticsearch or OpenSearch database [ID 44201]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU11] / 10.6.0 [CU0] - FR 10.6.2 -->

In the Alarm Console, up to now, the advanced search options would incorrectly be visible on systems that did not include an Elasticsearch or OpenSearch database.

From now on, the advanced search options will only be visible on systems that include an Elasticsearch or OpenSearch database.

#### DataMiner Cube desktop app: Hostname, protocol type, and port will now be extracted from the DataMiner Agent URL [ID 44203]

<!-- MR 10.5.0 [CU11] / 10.6.0 [CU0] - FR 10.6.2 -->

When, while adding a new tile/cluster to the start window of the DataMiner Cube desktop app, you paste a URL of a DataMiner Agent, from now on, the hostname, the protocol type\*, and the port will automatically be extracted from that URL.

Also, when the Cube login window allows you to change the hostname, and you enter or paste a URL in the hostname box, the hostname will now be automatically extracted from that URL.

\**The following protocol types are supported: HTTP, HTTPS, FTP, FILE, and CUBE.*

#### System Center: Clearer error messages when adding a DMA to a DMS fails [ID 44247]

<!-- MR 10.5.0 [CU11] / 10.6.0 [CU0] - FR 10.6.2 -->

From now on, when you try to add a DataMiner Agent to a DataMiner System, an error message will appear in the following cases:

- The DataMiner Agent is cloud-connected, but the DataMiner System is not.
- The DataMiner Agent and the DataMiner System are cloud-connected, but they do not have the same identity, i.e. they are not part of the same cloud-connected system.

If the DataMiner System is a STaaS system, an error message will also appear when the DataMiner Agent is not cloud-connected.

### Fixes

#### Alarm Console: Problem with shape data fields of type 'AlarmFilter' [ID 44081]

<!-- MR 10.5.0 [CU11] / 10.6.0 [CU0] - FR 10.6.2 -->

If you add a shape data field of type *AlarmFilter* to a shape, clicking the shape will cause Alarm Console tabs of type *Active alarms linked to cards* only to show alarms that match the alarm filter specified in the field value.

However, up to now, the alarm filter would incorrectly no longer be taken into account when an alarm tab of type *Active alarms linked to cards* was selected in the Alarm Console.

#### Alarm Console: Action performed on an alarm in an alarm group or correlated alarm would incorrectly also be performed on alarms of the same alarm group or correlated alarm in other alarm tabs [ID 44187]

<!-- MR 10.5.0 [CU11] / 10.6.0 [CU0] - FR 10.6.2 -->

When, in a particular alarm tab, you performed an action on an alarm that was part of an alarm group or a correlated alarm while *Automatic alarm grouping* option or *Correlation tracking* was enabled, up to now, that action would incorrectly also be performed on alarms of the same alarm group or correlated alarm selected in other alarm tabs.

#### Visual Overview in the web apps: Browser instances would incorrectly be created for inline browsers when Cube was running as a service [ID 44272]

<!-- MR 10.5.0 [CU11] / 10.6.0 [CU0] - FR 10.6.2 -->

Up to now, when Cube was running as a service, browser instances would incorrectly be created for inline browsers, even if they were not used to generate images.

From now on, when Cube is running as a service, browser shapes will only verify whether the URL is correct. No browser instances will created anymore.

#### Settings: Updates made to an alarm tab of type "sliding window" defined on group level would not be saved or applied [ID 44313]

<!-- MR 10.5.0 [CU11] / 10.6.0 [CU0] - FR 10.6.2 -->

When, in the *Settings* app, you had defined an alarm tab of type "sliding window" on group level, up to now, any updates made to the settings of that alarm tab would incorrectly not be saved or applied.
