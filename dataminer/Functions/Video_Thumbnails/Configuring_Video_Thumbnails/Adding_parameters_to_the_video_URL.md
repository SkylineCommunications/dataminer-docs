---
uid: Adding_parameters_to_the_video_URL
---

# Adding parameters to the video URL

When you configure a video thumbnail, the URL must contain a number of mandator parameters and may include additional optional parameters to control playback behavior, display settings, authentication, or refresh intervals.

All supported video server types and their associated parameters are defined in the file `C:\Skyline DataMiner\videoservers.xml`.

## Mandatory parameters

- `type=`: Specifies the type of video or image source. The following types are supported:

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

    - Add a `refresh=` parameter to the video URL to specify the refresh interval (in milliseconds). See [Optional parameters](#optional-parameters).

    - By default, a thumbnail of type *Generic Images* always uses the DMA as a proxy. However, you can add an extra URL parameter, "proxy", to override this behavior. For example: `http://<DMA>/VideoThumbnails/video.htm?type=Generic%20Images&source=<IMG URL>&proxy=false`

    - Both HTTP and HTTPS are supported.

  - VLC: `type=Generic VLC`

    - To display video thumbnails with the VLC plugin in the Cube desktop app, use the 64-bit version of VLC.

- `source=`: The URL of the video/image.

## Optional parameters

- `referer=` (Generic VLC): The VLC component of video thumbnails sends a referer HTTP header when requesting the source URL. The referer URL is by default the URL of the DMA, but you can change it by specifying the parameter "referer=" in the URL of the video thumbnail.

  Example: `#http://<DMA>/VideoThumbnails/video.htm?type=VLC&source=http%3A%2F%2Fclips.vorwaerts-gmbh.de%2Fbig_buck_bunny.mp4&referer=http%3A%2F%2Fsome%2Freferer%2F.`

- `user=` and `password=` (Images): You can add a password and username in the URL for basic HTTP authentication. However, in that case we advise to always use HTTPS, as otherwise the username and password will not be encrypted. Note that this parameter can only be used when the `proxy=` parameter is set to `true` (default).

  Example: `#https://<DMA>/VideoThumbnails/Video.htm?type=Generic%20Images&source=http%3A%2F%2F10.0.20.101%2Fimages%2Fthumbs%2F4.jpg&user=admin&password=test&refresh=1000`

- `auth=` (Images): Specify an HTTP authorization header that will be added to the HTTP request when a thumbnail image is requested from the video server. This option is required when the video server expects an authentication token (for example *OAuth2*). Note that this parameter can only be used when the `proxy=` parameter is set to `true` (default).

  Example: `#https://<DMA>/videothumbnails/video.htm?type=Generic%20Images&source=https%3A%2F%2F77.158.55.113%2Fvos-api%2Fmonitor%2Fv1%2Fservices%2F55002da8-37fd-43de-82a9-f6b75089d8c9%2Fthumbnail&auth=bearer%20580a4efa-0aab-4882-af91-7b0118c67f5d`

- `volume=` (All video types): Available from DataMiner 10.2.0 [CU1]/10.2.4 onwards. Specify the volume for the video player in the URL. The volume should be specified as a percentage, ranging from 0 (i.e. muted) to 100.

  Example: `#https://<DMA>/VideoThumbnails/Video.htm?type=VLC&source=https://videoserver/video.mp4&volume=50`

- `loop=` (All video types): Available from DataMiner 10.2.0 [CU1]/10.2.4 onwards. Specify that the video should play continuously in a loop. Set to `false` by default.

  `#https://<DMA>/VideoThumbnails/Video.htm?type=HTML5&source=https://videoserver/video.mp4&loop=true`

- `fitMode=` (Images): Available from DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43388-->. Specify how the image in a video thumbnail should be displayed.

  The possible values are:

  - `fill`: The image will completely cover the container. It may crop parts of the image, but it ensures that there is no empty space (*default*).

  - `fit`: The image will be fully visible inside the container while maintaining aspect ratio. There may be empty space if aspect ratios differ.

  - `stretch`: The image will stretch to exactly fill the container, ignoring aspect ratio. This may cause distortion.

  - `center`: The image will retain its original size and will be aligned at the center. It may overflow or be cropped.

  - `shrink`: The image will behave like `fill` or `center`, whichever results in a smaller image. It will only scale down if needed.

  Example: `#http://<DMA>/VideoThumbnails/Video.htm?type=Generic%20Images&source=http://IpAddress/Folder/Picture.png&refresh=5000&fitMode=center`

- `toolbar=false`/`showtoolbar=false` (All video types): By default the VLC toolbar is shown. To hide the toolbar, specify "toolbar=false" or "showtoolbar=false" in the URL.

  Example: `#http://<DMA>/VideoThumbnails/Video.htm?type=Generic%20VLC&source=http://<DMA>/myvideo.mpeg&showtoolbar=false`

- `refresh=` (Generic Images): Specify how frequently you want the image to be refreshed (in milliseconds).

  Example: `#http://<DMA>/VideoThumbnails/Video.htm?type=Generic%20Images&source=http://IpAddress/Folder/Picture.png&refresh=5000`

- `proxy=` (Generic Images): By default, a thumbnail of type `Generic Images` always uses the DMA as a proxy. However, you can add an extra URL parameter, "proxy", to override this behavior.

  Example: `http://<DMA>/VideoThumbnails/video.htm?type=Generic%20Images&source=<IMG URL>&proxy=false`

> [!NOTE]
>
> - Always make sure that the parameters of the URL are URL-encoded, as illustrated in the examples above.
> - In Visio, you can use the *EscapeDataString* placeholder when you add parameters, properties, or other DataMiner data sources in the URL (see [\[EscapeDataString:x\]](xref:Placeholders_for_variables_in_shape_data_values#escapedatastringx)). For example: `https://<DMA>/VideoThumbnails/Video.htm?type=Generic%20VLC&source=[EscapeDataString:[param:*,10014]]`
> - When the authentication token expires, the URL has to be updated with the new token.
> - URLs that request video thumbnails should use HTTPS instead of HTTP. That way, you can prevent the authentication token from being stolen.
