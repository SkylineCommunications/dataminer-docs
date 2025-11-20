---
uid: Configuring_a_video_thumbnail_in_a_web_component
---

# Configuring a video thumbnail in a web component

1. Go to the *Settings* pane.

1. In the *URL* box, Enter the video URL. The URL consists of the following main components:

   - `#`: The "#" in front of the URL ensures that the video is displayed in an embedded browser.

   - `http(s)://<DMAIP>/VideoThumbnails/Video.htm?`: the internal webpage hosted by the DataMiner Agent.

   - `type=` followed by the video format: For more information about the available types, see [Supported video formats](#supported-video-formats).

   - `source=`: The URL of the video/image.

   For example:

   ```txt
   #https://dma.local/VideoThumbnails/Video.htm?type=HTML5&source=https://videoserver/video.mp4
   ```

1. Optionally, add additional parameters to the URL. See [Optional parameters](#optional-parameters).

   Example: `#https://dma.local/VideoThumbnails/Video.htm?type=HTML5&source=https://videoserver/video.mp4&loop=true`
