---
uid: Configuring_a_video_thumbnail_in_Visio
---

# Configuring a video thumbnail for Visual Overview

## Configuring a video thumbnail in Visio

When you are [configuring a drawing in Visio](xref:Getting_started_with_visual_overview), you can link a shape to a video thumbnail as follows:

1. Add a shape data field of type *Link* to the shape.

1. Enter the video URL. For example:

   ```txt
   #https://<DMA>/VideoThumbnails/Video.htm?type=HTML5&source=https://videoserver/video.mp4
   ```

   The URL consists of the following main components:

   - `#`: The "#" in front of the URL ensures that the video is displayed in an embedded browser. If you do not add this, the shape is rendered as it is drawn in Visio and clicking it opens your default browser and navigates to the link.

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

       - The following image formats are supported: .png, .jpg, and .bmp.

       - If you want to display an image located on a DMA, place the image in the DMA's `C:\Skyline DataMiner\Webpages\Public\` folder (or one of its subfolders, e.g. `C:\Skyline DataMiner\Webpages\Public\MyImages\`).

         > [!TIP]
         > If you get an "Invalid path" error, open the file `C:\Skyline DataMiner\Webpages\VideoThumbnails\Web.config`, and check whether the image folder (e.g. */Public/MyImages/*) has been added to the *ExtraAllowedPaths* key.
         >
         > See also: [Allowed paths in case of connection via DataMiner proxy](xref:Allowed_paths_connection_DataMiner_proxy).

       - Add a `refresh=` parameter to the video URL to specify the refresh interval (in milliseconds). See [Adding parameters to the video URL](xref:Adding_parameters_to_the_video_URL).

       - By default, a thumbnail of type *Generic Images* always uses the DMA as a proxy. However, you can add an extra URL parameter, "proxy", to override this behavior. For example: `http://<DMA IP>/VideoThumbnails/video.htm?type=Generic%20Images&source=<IMG URL>&proxy=false`

       - Both HTTP and HTTPS are supported.

     - VLC: `type=Generic VLC`

       - To display video thumbnails with the VLC plugin in the Cube desktop app, use the 64-bit version of VLC.


   - `source=`: The URL of the video/image.

1. Optionally, add [parameters to the video URL](xref:Adding_parameters_to_the_video_URL).

   For example:

   ```txt
   #https://dma.local/VideoThumbnails/Video.htm?type=HTML5&source=https://videoserver/video.mp4&loop=true
   ```

   By adding the `loop=true` parameter to the video URL, the video will play continuously in a loop.

1. Save the Visio file.

> [!NOTE]
> To display video feeds from Selenio MCP1 and MCP3 platforms, the Selenio modules need to have at least firmware version 6.1.

## Configuring a video thumbnail in DataMiner Cube

Instead of using the Visio desktop app, you can also link a shape to a video thumbnail in DataMiner Cube itself. To do so:

1. Right-click the Visio drawing, and click *Edit Mode*.

1. Select the shape. If necessary, select the *Make All Shapes Selectable* option, and select the shape from the *Selected Shape* selection box.

1. In *Link Shape To*, select "Link".

1. In the *Basic* tab, set *Link Type* to "Video".

1. Choose a video type from the dropdown list.

1. Provide any required information based on the chosen video type. For example, if you choose `Generic Images` as video type, you will need to provide the image source URL and the refresh rate of the image (in milliseconds).

1. Click Save.
