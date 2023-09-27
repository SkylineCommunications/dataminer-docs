---
uid: Linking_a_shape_to_a_video_thumbnail
---

# Linking a shape to a video thumbnail

Using a shape data field of type **Link**, you can link a shape to a video thumbnail.

When you link a shape to a video thumbnail, the video feed from the video server channel specified in the shape data field will appear inside the shape.

Please note the following:

- From DataMiner 10.2.0 \[CU1]/10.2.4 onwards, HTML5 video thumbnails are **muted** by default.

- Video servers that only accept **TLS 1.2** are supported from DataMiner 10.2.0/10.1.1 onwards.

- From DataMiner 10.2.0/10.1.11 onwards, **HLS** (HTTPS Live Streaming) is supported. See [Configuring a thumbnail for HTTP Live Streaming](#configuring-a-thumbnail-for-http-live-streaming).

- To display video thumbnails with the **VLC** plugin in the DataMiner Cube browser app, make sure the 32-bit version of VLC is installed, not the 64-bit version, as the latter may not run correctly. If you are using the DataMiner Cube desktop app (version 10.0.0 or higher), use the 64-bit version of VLC instead.

- From DataMiner 9.0 onwards, it is possible to display video feeds from **Selenio MCP1 and MCP3** platforms. However, the Selenio modules need to have at least firmware version 6.1.

- In DataMiner versions up to 8.5.8, Adobe Flash is used to display video thumbnails. From DataMiner 9.0 onwards, HTML is used instead. Both **MJPEG** and **HTML5** video types are supported. The latter can be used for live video streaming. However, note that most browsers only support video streaming over TCP.

- For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[linking > THUMBNAIL]* page.

> [!TIP]
> See also: [Making a shape display an image](xref:Making_a_shape_display_an_image)

## Configuring the shape data field

Add a shape data field of type **Link** to the shape, and configure one of the following values, depending on your setup:

```txt
#https://<DMAIP>/VideoThumbnails/Video.htm?VideoServerParameters
#http://<DMAIP>/VideoThumbnails/Video.htm?VideoServerParameters
```

> [!NOTE]
>
> - Adding "#" in front of the URL ensures that the video is displayed in an embedded browser. If you do not add this, the shape is rendered as it is drawn in Visio and clicking it opens your default browser and navigates to the link.
> - If you play a video in a shape using VLC, by default the VLC toolbar is shown. To hide the toolbar, adding "toolbar=false" or "showtoolbar=false" to the value of the **Link** shape data. For example: `#http://<DMAIP>/VideoThumbnails/Video.htm?type=Generic VLC&source=http://<DMAIP>/myvideo.mpeg&showtoolbar=false`

## Video server parameters

The parameters you are allowed to pass inside the URL depend on the type of the video server.

All supported video server types and their associated parameters are defined in the file *C:\Skyline DataMiner\videoservers.xml*.

Depending on the DataMiner version, additional configuration is possible in the URL:

- From DataMiner 9.5.1 onwards, the VLC component of video thumbnails sends a **referer HTTP header** when requesting the source URL. The referer URL is by default the URL of the DMA, but you can change it by specifying the parameter "referer=" in the URL of the video thumbnail. For example:

  ```txt
  #http://localhost/VideoThumbnails/video.htm?type=VLC&source=http%3A%2F%2Fclips.vorwaerts-gmbh.de%2Fbig_buck_bunny.mp4&referer=http%3A%2F%2Fsome%2Freferer%2F.
  ```

- From DataMiner 9.5.4 onwards, you can add a **password and username** in the URL for basic HTTP authentication. However, in that case we advise to always use HTTPS, as otherwise the username and password will not be encrypted. For example:

  ```txt
  #https://dma/VideoThumbnails/Video.htm?type=Generic%20Images&source=http%3A%2F%2F10.0.20.101%2Fimages%2Fthumbs%2F4.jpg&user=admin&password=test&refresh=1000
  ```

- From DataMiner 10.2.0/10.1.1 onwards, you can use the "auth=" URL option to specify an **HTTP authorization header** that will be added to the HTTP request when a thumbnail image is requested from the video server. This option is required when the video server expects an authentication token (for example *OAuth2*). For example:

  ```txt
  #https://dma/videothumbnails/video.htm?type=Generic%20Images&source=https%3A%2F%2F77.158.55.113%2Fvos-api%2Fmonitor%2Fv1%2Fservices%2F55002da8-37fd-43de-82a9-f6b75089d8c9%2Fthumbnail&auth=bearer%20580a4efa-0aab-4882-af91-7b0118c67f5d
  ```

  > [!NOTE]
    > - Always make sure that the parameters of the URL are URL-encoded, as illustrated in the examples above.
  > - Use the *EscapeDataString* placeholder when you add parameters, properties or other DataMiner data sources in the URL (see [\[EscapeDataString:x\]](xref:Placeholders_for_variables_in_shape_data_values#escapedatastringx)). For example: `https://<DMAIP>/VideoThumbnails/Video.htm?type=Generic%20VLC&source=[EscapeDataString:[param:*,10014]]`
  > - When the authentication token expires, the URL has to be updated with the new token.
  > - URLs that request video thumbnails should use HTTPS instead of HTTP. That way, you can prevent the authentication token from being stolen.

- From DataMiner 10.2.0 \[CU1]/10.2.4 onwards, it is possible to specify the **volume for the VLC player** in the URL. The volume should be specified as a percentage, ranging from 0 (i.e. muted) to 100. For example:

  ```txt
  #https://dma.local/VideoThumbnails/Video.htm?type=VLC&source=https://videoserver/video.mp4&volume=50
  ```

- From DataMiner 10.2.0 \[CU1]/10.2.4 onwards, you can specify that the video should play continuously in a **loop**, by adding `loop=true` to the URL. By default, this is considered to be false.

  ```txt
  #https://dma.local/VideoThumbnails/Video.htm?type=HTML5&source=https://videoserver/video.mp4&loop=true
  ```

## Allowed paths in case of connection via DataMiner proxy

If a client does not have direct access to the video server, it can request a video feed via the DataMiner Agent acting as a proxy server.

When a video feed is requested via proxy, the list of allowed URLs will be restricted for security reasons.

By default, the following URLs are allowed:

```txt
http://ipaddress/axis-cgi/...
http://ipaddress/video_thumbnails/...
http://ipaddress/tile/...
http://ipaddress/images/getthumbnail/...
```

If more URLs need to be added to the list of allowed URLs, do the following:

1. On a DMA with version 8.5.8 or lower, open *C:\\Skyline DataMiner\\Webpages\\VideoThumbnails\\Proxy\\Web.config*.

   On a DMA with version 9.0 or higher, open *C:\\Skyline DataMiner\\Webpages\\VideoThumbnails\\Web.config*.

1. Go to the *appSettings* section.

1. Add all additional paths to the *ExtraAllowedPaths* key, separated by semicolons (";"):

   ```xml
   <add key="ExtraAllowedPaths" value="" />
   ```

   > [!NOTE]
   > If you just add a single slash ("/") in the value of the ExtraAllowedPaths key, all possible URLs will be allowed.

Example: If, under *C:\\Skyline DataMiner\\Webpages*, you created your own folder named *MyThumbnails*, then add */MyThumbnails/* to the value of the *ExtraAllowedPaths* key.

## Ignoring validation errors during HTTP parsing

From DataMiner 9.5.5 onwards, you can configure the thumbnail web.config file to ignore any validation errors that occur during HTTP parsing.

> [!CAUTION]
> Ignoring validation errors has security implications, so this should only be done as a last resort to gain backward compatibility with a server. However, we recommend that in such a case the software on the server is updated instead, so that it does send valid HTTP messages.

To do so:

1. Open the file *C:\\Skyline DataMiner\\Webpages\\VideoThumbnails\\Web.config*.

1. Add the following option:

   ```xml
   <add key="UseUnsafeHeaderParsing" value="true" />
   ```

   > [!NOTE]
   > When this property is set to false (the default setting), the following validation is performed during HTTP parsing:
   >
   > - In end-of-line code, only CRLF is allowed, not CR or LF alone.
   > - Headers names may not have spaces in them.
   > - If multiple status lines exist, all additional status lines are treated as malformed header name/value pairs.
   > - The status line must have a status description, in addition to a status code.
   >
   > Regardless of whether the property is set to true or false, header names may not contain non-ASCII characters.

> [!TIP]
> See also: <https://msdn.microsoft.com/en-us/library/system.net.configuration.httpwebrequestelement.useunsafeheaderparsing.aspx>

## Configuring a thumbnail for HTTP Live Streaming

From DataMiner 10.1.11/10.2.0 onwards, HLS (HTTPS Live Streaming) is supported for video thumbnails. No additional plugins need to be installed for this.

To configure the thumbnail, add a shape data field of type **Link** to the shape, and configure it as follows:

```txt
#https://<DMAIP>/VideoThumbnails/Video.htm?type=HTML5-HLS&source=https://<video server>.<stream>.m3u8
```

> [!NOTE]
>
> - For more information on HLS, see <https://github.com/video-dev/hls.js/>
> - All HLS resources must be delivered with CORS headers that permit GET requests. For more information, see <https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS>.
> - If you access a video thumbnail player that is using HTTPS, the media must also be served over HTTPS.
