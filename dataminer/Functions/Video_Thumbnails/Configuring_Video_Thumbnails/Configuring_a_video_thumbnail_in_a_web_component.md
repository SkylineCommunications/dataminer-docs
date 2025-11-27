---
uid: Configuring_a_video_thumbnail_in_a_web_component
---

# Configuring a video thumbnail in a web component

When you have added a [web component](xref:DashboardWeb) in a dashboard or low-code app, you can configure it as follows to show a video thumbnail:

1. Go to the *Settings* pane.

1. In the *URL* box, enter the video URL. For example:

   ```txt
   #https://{URL.DMAIP.Value}/VideoThumbnails/Video.htm?type=HTML5&source=https://videoserver/video.mp4
   ```

   The URL consists of the following main components:

   - `#`: The "#" in front of the URL ensures that the video is displayed in an embedded browser.

   - `http(s)://<DMAIP>/VideoThumbnails/Video.htm?`: the internal webpage hosted by the DataMiner Agent.

   - `type=<video-format>`: the type of video format. The supported video formats include:

     - MJPEG: `type=MJPEG`

     - HTML5: `type=HTML5`

       - HTML5 can be used for live video streaming. However, note that most browsers only support video streaming over TCP.

       - From DataMiner 10.2.0 [CU1]/10.2.4 onwards, HTML5 video thumbnails are muted by default. From DataMiner 10.4.0 [CU11]/10.5.2 onwards<!--RN 41597-->, you can unmute them by clicking the sound icon in the lower-right corner. When unmuted, the volume is automatically set to 100%. In earlier versions, unmuting required hovering over the sound icon and using a slider to adjust the volume.

     - HLS (HTTPS Live Streaming): `type=HTML5-HLS`

       - From DataMiner web 10.4.0 [CU10]/10.5.1 onwards<!--RN 41407-->, if the HLS stream has multiple audio tracks, you can select your preferred audio track using the dropdown menu in the top-right corner of the video thumbnail.

       - All HLS resources must be delivered with CORS headers that permit GET requests. For more information, see <https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS>.

       - If you access a video thumbnail player that is using HTTPS, the media must also be served over HTTPS.

       > [!TIP]
       > For more information on HLS, see <https://github.com/video-dev/hls.js/>

     - Image: `type=Generic Images`

       - The following image formats are supported: .png, .jpg, .bmp, and .emf.

       - If you want to display an image located on a DMA, place the image in the DMA's `C:\Skyline DataMiner\Webpages` folder (or one of its subfolders, e.g. `C:\Skyline DataMiner\Webpages\MyImages\`).

         > [!TIP]
         > If you get an "Invalid path" error, open the file `C:\Skyline DataMiner\Webpages\VideoThumbnails\Web.config`, and check whether the image folder (e.g. */MyImages/*) has been added to the *ExtraAllowedPaths* key.
         >
         > See also: [Allowed paths in case of connection via DataMiner proxy](xref:Allowed_paths_connection_DataMiner_proxy).

       - Add a `refresh=` parameter to the video URL to specify the refresh interval (in milliseconds). See [Adding parameters to the video URL](xref:Adding_parameters_to_the_video_URL).

       - By default, a thumbnail of type *Generic Images* always uses the DMA as a proxy. However, you can add an extra URL parameter, "proxy", to override this behavior. For example: `http://<DMA IP>/VideoThumbnails/video.htm?type=Generic%20Images&source=<IMG URL>&proxy=false`

       - Both HTTP and HTTPS are supported.

     - VLC: `type=Generic VLC`/`type=VLC`

   - `source=`: The URL of the video/image.

1. Optionally, add [parameters to the video URL](xref:Adding_parameters_to_the_video_URL).

   For example:

   ```txt
   #https://dma.local/VideoThumbnails/Video.htm?type=HTML5&source=https://videoserver/video.mp4&loop=true
   ```

   By adding the `loop=true` parameter to the video URL, the video will play continuously in a loop.

> [!NOTE]
> To display video feeds from Selenio MCP1 and MCP3 platforms, the Selenio modules need to have at least firmware version 6.1.
