---
uid: Allowed_paths_connection_DataMiner_proxy
---

# Allowed paths in case of connection via DataMiner proxy

If a client does not have direct access to the video server, it can request a thumbnail image via the DataMiner Agent acting as a proxy server, if the URL uses `?type=Generic%20Images`.

When a thumbnail image is requested via proxy, the list of allowed URLs will be restricted for security reasons.

By default, the following URLs are allowed:

```txt
http://ipaddress/axis-cgi/...
http://ipaddress/video_thumbnails/...
http://ipaddress/tile/...
http://ipaddress/images/thumbs/...
http://ipaddress/cgi-bin/getthumbnail...
http://ipaddress/tmp/JPEG_Thumbnail/...
http://ipaddress/control/frame/slot/getThumbImage...
```

If more URLs need to be added to the list of allowed URLs, do the following:

1. Open `C:\Skyline DataMiner\Webpages\VideoThumbnails\Web.config`.

1. Go to the *appSettings* section.

1. Add all additional paths to the *ExtraAllowedPaths* key, separated by semicolons (";"):

   ```xml
   <add key="ExtraAllowedPaths" value="" />
   ```

   > [!NOTE]

Example: If your video server hosts thumbnails at `http://videoserver/thumbnails/image1.jpg`, then add `/thumbnails/` to the value of the *ExtraAllowedPaths* key.

> [!CAUTION]
> Setting up a proxy could create a weakness in the network security, giving users from the public network access to resources on the private network. Use this with extreme caution.

> [!TIP]
> For videos of type HLS, refer to [Video streaming with proxy](uid:Video_streaming_with_proxy).
