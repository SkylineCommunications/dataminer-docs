---
uid: Allowed_paths_connection_DataMiner_proxy
---

# Allowed paths in case of connection via DataMiner proxy

If a client does not have direct access to the video server, it can request a video feed via the DataMiner Agent acting as a proxy server.

When a video feed is requested via proxy, the list of allowed URLs will be restricted for security reasons.

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
   > If you just add a single slash ("/") in the value of the ExtraAllowedPaths key, all possible URLs will be allowed.

Example: If, under `C:\Skyline DataMiner\Webpages`, you created your own folder named *MyThumbnails*, then add */MyThumbnails/* to the value of the *ExtraAllowedPaths* key.
