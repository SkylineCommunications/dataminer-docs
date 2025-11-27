---
uid: Configuring_a_video_thumbnail_in_a_web_component
---

# Configuring a video thumbnail in a web component

When you have added a [web component](xref:DashboardWeb) in a dashboard or low-code app, you can configure it as follows to show a video thumbnail:

1. Go to the *Settings* pane.

1. In the *URL* box, enter the video URL. You can use IntelliSense to insert the DMA placeholder `{URL.DMAIP.Value}`. For example:

   ```txt
   #https://{URL.DMAIP.Value}/VideoThumbnails/Video.htm?type=HTML5&source=https://videoserver/video.mp4
   ```

   The URL consists of the following main components:

   - `#`: The "#" in front of the URL ensures that the video is displayed in an embedded browser.

   - `http(s)://{URL.DMAIP.Value}/VideoThumbnails/Video.htm?`: the internal webpage hosted by the DataMiner Agent.

   - URL parameters: These define how the video thumbnail is displayed and played. Som parameters are mandatory (for example, `type=` to indicate the video type and `source=` to specify the video or image source), while others are optional (for example, `loop=` to play a video continuously). For a complete overview, see [Adding parameters to the video URL](xref:Adding_parameters_to_the_video_URL).
