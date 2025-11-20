---
uid: Configuring_a_video_thumbnail_in_Visual_Overview.md
---

# Configuring a video thumbnail in Visual Overview

1. Right-click the Visio drawing, and click *Edit In Visio*.

1. Add a shape data field of type *Link* to the shape.

1. Enter the video URL. The URL consists of the following main components:

   - `#`: The "#" in front of the URL ensures that the video is displayed in an embedded browser. If you do not add this, the shape is rendered as it is drawn in Visio and clicking it opens your default browser and navigates to the link.

   - `http(s)://<DMAIP>/VideoThumbnails/Video.htm?`: the internal webpage hosted by the DataMiner Agent.

   - `type=<video-format>`: the type of video format. The supported video formats include:

     - `type=MJPEG`

     - `type=HTML5`

     - `type=HTML5-HLS`

     - `type=Generic images`

     - `type=Generic VLC`

   - `source=`: The URL of the video/image.

   For example:

   ```txt
   #https://dma.local/VideoThumbnails/Video.htm?type=HTML5&source=https://videoserver/video.mp4
   ```

1. Optionally, add additional parameters to the URL. See [Optional parameters](#optional-parameters).

   Example: `#https://dma.local/VideoThumbnails/Video.htm?type=HTML5&source=https://videoserver/video.mp4&loop=true`

1. Save the Visio file.
