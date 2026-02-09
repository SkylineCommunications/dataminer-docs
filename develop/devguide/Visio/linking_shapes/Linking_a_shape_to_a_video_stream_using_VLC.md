---
uid: Linking_a_shape_to_a_video_stream_using_VLC
keywords: Visio, hyperlink
---

# Linking a shape to a video stream using VLC

From DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards<!--RN 43750 + 44265-->, you can use a shape data field of type **VLC** to display a video stream or video source inside a shape in Visual Overview.

When configured, the video is shown inline in the shape by means of the VLC media player.

> [!NOTE]
> This functionality is not supported in visual overviews that are used in DataMiner web apps.

## Requirements

- VLC must be installed on the client machine running DataMiner Cube.

- Only the 64-bit version of VLC is supported.

  If a 32-bit version of VLC is detected, a warning will be shown and the video will not be displayed.

## Configuring the shape data field

To display a video stream or video source inside a shape:

1. Add a shape data field of type **VLC** to the shape.

1. Set its value to a link that points to the video stream or video source. The link can contain the `<DMAIP>` placeholder.

## How DataMiner Cube locates VLC

To play the video, DataMiner Cube attempts to locate a VLC installation on the client system in the following order:

1. The `VLC_Path` environment variable.

1. A VLC installation in `C:\Program Files`.

1. A VLC installation in `C:\Program Files (x86)`.

   If VLC is found there, a warning is shown because the 32-bit version is not supported.

1. The Windows registry.

Once VLC is found, DataMiner Cube uses that installation and its available plugins to render the video stream.
