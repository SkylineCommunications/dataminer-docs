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

#### Visual Overview: New shape data field of type VLC [ID 43750]

<!-- MR 10.5.0 [CU11] / 10.6.0 [CU0] - FR 10.6.2 -->

You can now use a shape data field of type VLC to make a shape show a video stream or video source via VLC in an inline window.

To do so, add a shape data field of type VLC, and set its value to a link that points to the video stream or video source. That link is allowed to contain the `<DMAIP>` placeholder.

For this feature to work, VLC needs to be installed on the client machine. DataMiner Cube will try to find the VLC application on the local system (see below), and will use that VLC application and its plugins. Note that only the 64-bit version of VLC will work.

DataMiner Cube will try to find the VLC application in the following way:

1. Check if the `VLC_PATH` environment variable exists.
1. Check if VLC is installed in `C:\Program Files`.
1. Check if VLC is installed in `C:\Program Files (x86)`. If so, the user will receive a warning, saying that the 32-bit version of VLC is not supported.
1. Check the registry.

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

*No fixes have been added yet.*
