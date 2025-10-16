---
uid: Linking_a_shape_to_a_video_thumbnail
---

# Linking a shape to a video thumbnail

Using a shape data field of type **Link**, you can link a shape to a video thumbnail.

When you link a shape to a video thumbnail, the video feed from the video server channel specified in the shape data field will appear inside the shape.

Please note the following:

- From DataMiner 10.2.0 [CU1]/10.2.4 onwards, HTML5 video thumbnails are **muted** by default. From DataMiner 10.4.0 [CU11]/10.5.2 onwards<!--RN 41597-->, you can unmute them by clicking the sound icon in the lower-right corner. When unmuted, the volume is automatically set to 100%. In earlier versions, unmuting required hovering over the sound icon and using a slider to adjust the volume.

- Video servers that only accept **TLS 1.2** are supported from DataMiner 10.2.0/10.1.1 onwards.

- From DataMiner 10.2.0/10.1.11 onwards, **HLS** (HTTPS Live Streaming) is supported. See [Configuring a thumbnail for HTTP Live Streaming](#configuring-a-thumbnail-for-http-live-streaming).

- To display video thumbnails with the **VLC** plugin in the Cube desktop app, use the 64-bit version of VLC. If you use the DataMiner Cube browser app (not recommended), make sure the 32-bit version of VLC is installed instead of the 64-bit version, as the latter may not run correctly.

- To display video feeds from **Selenio MCP1 and MCP3** platforms, the Selenio modules need to have at least firmware version 6.1.

- Both **MJPEG** and **HTML5** video types are supported. The latter can be used for live video streaming. However, note that most browsers only support video streaming over TCP.

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

## Configuring the video thumbnail to display an image

The following image formats are supported: .png, .jpg, .bmp, and .emf.

### In DataMiner Cube

1. Right-click the Visio drawing, and click *Edit Mode*.

1. Select the shape. If necessary, select the *Make All Shapes Selectable* option, and select the shape from the *Selected Shape* selection box.

1. In *Link Shape To*, select "Link".

1. In the *Basic* tab:

   1. Set *Link Type* to "Video".

   1. Set *Video Type* to "Generic Images".

   1. In *Image Source*, enter the URL of the image (e.g. `http://IpAddress/Folder/Picture.png`).

      > [!NOTE]
      >
      > - Both HTTP and HTTPS are supported.
      > - If you want the shape to display an image on a DataMiner Agent, see [Displaying images located on a DataMiner Agent](#displaying-images-located-on-a-dataminer-agent).

   1. In *Refresh rate*, specify how frequently you want the image to be refreshed (in milliseconds).

1. Click Save.

### In Visio

1. Right-click the Visio drawing, and click *Edit In Visio*.

1. Add a shape data field of type **Link** to the shape, and set its value to e.g.:

   ```txt
   #http://DmaIpAddress/VideoThumbnails/Video.htm?type=Generic Images&source=http://IpAddress/Folder/Picture.png&refresh=5000
   ```

   > [!NOTE]
   >
   > - Both HTTP and HTTPS are supported.
   > - If you want the shape to display an image on a DataMiner Agent, see [Displaying images located on a DataMiner Agent](#displaying-images-located-on-a-dataminer-agent).

1. Save the Visio file.

> [!NOTE]
> By default, a thumbnail of type *Generic Images* always uses the DMA as a proxy. However, you can add an extra URL parameter, "proxy", to override this behavior. For example: `http://<DMA IP>/VideoThumbnails/video.htm?type=Generic%20Images&source=<IMG URL>&proxy=false`

### Displaying images located on a DataMiner Agent

If you want a shape to display an image located on a DMA, then do the following:

1. Place the image in the DMA's `C:\Skyline DataMiner\Webpages` folder (or one of its subfolders e.g. `C:\Skyline DataMiner\Webpages\MyImages\`).

1. In the shape, specify the URL of the image (e.g. `http://DmaIpAddress/MyImages/Picture.png`).

> [!NOTE]
> If you get an "Invalid path" error, open the file `C:\Skyline DataMiner\Webpages\VideoThumbnails\Web.config`, and check whether the image folder (e.g. */MyImages/*) has been added to the *ExtraAllowedPaths* key.
> See also [Allowed paths in case of connection via DataMiner proxy](xref:Linking_a_shape_to_a_video_thumbnail#allowed-paths-in-case-of-connection-via-dataminer-proxy).

## Video server parameters

The parameters you are allowed to pass inside the URL depend on the type of the video server.

All supported video server types and their associated parameters are defined in the file `C:\Skyline DataMiner\videoservers.xml`.

Additional configuration is possible in the URL:

- The VLC component of video thumbnails sends a **referer HTTP header** when requesting the source URL. The referer URL is by default the URL of the DMA, but you can change it by specifying the parameter "referer=" in the URL of the video thumbnail. For example:

  ```txt
  #http://localhost/VideoThumbnails/video.htm?type=VLC&source=http%3A%2F%2Fclips.vorwaerts-gmbh.de%2Fbig_buck_bunny.mp4&referer=http%3A%2F%2Fsome%2Freferer%2F.
  ```

- You can add a **password and username** in the URL for basic HTTP authentication. However, in that case we advise to always use HTTPS, as otherwise the username and password will not be encrypted. For example:

  ```txt
  #https://dma/VideoThumbnails/Video.htm?type=Generic%20Images&source=http%3A%2F%2F10.0.20.101%2Fimages%2Fthumbs%2F4.jpg&user=admin&password=test&refresh=1000
  ```

- From DataMiner 10.2.0/10.1.1 onwards, you can use the "auth=" URL option to specify an **HTTP authorization header** that will be added to the HTTP request when a thumbnail image is requested from the video server. This option is required when the video server expects an authentication token (for example *OAuth2*). For example:

  ```txt
  #https://dma/videothumbnails/video.htm?type=Generic%20Images&source=https%3A%2F%2F77.158.55.113%2Fvos-api%2Fmonitor%2Fv1%2Fservices%2F55002da8-37fd-43de-82a9-f6b75089d8c9%2Fthumbnail&auth=bearer%20580a4efa-0aab-4882-af91-7b0118c67f5d
  ```

  > [!NOTE]
  >
  > - Always make sure that the parameters of the URL are URL-encoded, as illustrated in the examples above.
  > - Use the *EscapeDataString* placeholder when you add parameters, properties or other DataMiner data sources in the URL (see [\[EscapeDataString:x\]](xref:Placeholders_for_variables_in_shape_data_values#escapedatastringx)). For example: `https://<DMAIP>/VideoThumbnails/Video.htm?type=Generic%20VLC&source=[EscapeDataString:[param:*,10014]]`
  > - When the authentication token expires, the URL has to be updated with the new token.
  > - URLs that request video thumbnails should use HTTPS instead of HTTP. That way, you can prevent the authentication token from being stolen.

- From DataMiner 10.2.0 [CU1]/10.2.4 onwards, it is possible to specify the **volume for the VLC player** in the URL. The volume should be specified as a percentage, ranging from 0 (i.e. muted) to 100. For example:

  ```txt
  #https://dma.local/VideoThumbnails/Video.htm?type=VLC&source=https://videoserver/video.mp4&volume=50
  ```

- From DataMiner 10.2.0 [CU1]/10.2.4 onwards, you can specify that the video should play continuously in a **loop**, by adding `loop=true` to the URL. By default, this is considered to be false.

  ```txt
  #https://dma.local/VideoThumbnails/Video.htm?type=HTML5&source=https://videoserver/video.mp4&loop=true
  ```

- From DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43388-->, you can specify how the image in a video thumbnail should be displayed by adding the **fitMode** parameter to the URL. The possible values are:

  - `fill`: The image will completely cover the container. It may crop parts of the image, but it ensures that there is no empty space. *(default)*

  - `fit`: The image will be fully visible inside the container while maintaining aspect ratio. There may be empty space if aspect ratios differ.

  - `stretch`: The image will stretch to exactly fill the container, ignoring aspect ratio. This may cause distortion.

  - `center`: The image will retain its original size and will be aligned at the center. It may overflow or be cropped.

  - `shrink`: The image will behave like `fill` or `center`, whichever results in a smaller image. It will only scale down if needed.

  Example:

  ```txt
  #https://dma.local/VideoThumbnails/Video.htm?type=HTML5&source=https://videoserver/video.mp4&loop=true&fitMode=center
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

1. Open `C:\Skyline DataMiner\Webpages\VideoThumbnails\Web.config`.

1. Go to the *appSettings* section.

1. Add all additional paths to the *ExtraAllowedPaths* key, separated by semicolons (";"):

   ```xml
   <add key="ExtraAllowedPaths" value="" />
   ```

   > [!NOTE]
   > If you just add a single slash ("/") in the value of the ExtraAllowedPaths key, all possible URLs will be allowed.

Example: If, under `C:\Skyline DataMiner\Webpages`, you created your own folder named *MyThumbnails*, then add */MyThumbnails/* to the value of the *ExtraAllowedPaths* key.

## Ignoring validation errors during HTTP parsing

It is possible to configure the thumbnail web.config file to ignore any validation errors that occur during HTTP parsing.

> [!CAUTION]
> Ignoring validation errors has security implications, so this should only be done as a last resort to gain backward compatibility with a server. However, we recommend that in such a case the software on the server is updated instead, so that it does send valid HTTP messages.

To do so:

1. Open the file `C:\Skyline DataMiner\Webpages\VideoThumbnails\Web.config`.

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

From DataMiner web 10.4.0 [CU10]/10.5.1 onwards<!--RN 41407-->, if the HLS stream has multiple audio tracks, you can select your preferred audio track using the dropdown menu in the top-right corner of the video thumbnail.

> [!NOTE]
>
> - For more information on HLS, see <https://github.com/video-dev/hls.js/>
> - All HLS resources must be delivered with CORS headers that permit GET requests. For more information, see <https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS>.
> - If you access a video thumbnail player that is using HTTPS, the media must also be served over HTTPS.

### Video streaming with proxy

Video streams are typically only accessible within the internal network, and this is usually for a good reason, for example because paid TV channels are involved that should not be publicly available. Another reason to use a proxy is to avoid CORS or CSP restrictions: if you run the proxy on the same origin as the web app playing the video, it will load the video from the same origin, which is not a cross-origin request.

> [!CAUTION]
> Setting up a proxy could create a weakness in the network security, giving users from the public network access to resources on the private network. Use this with extreme caution.

#### Installing and running HLS Proxy

To install and run [HLS Proxy](https://github.com/warren-bank/HLS-Proxy):

1. Make sure you have [NodeJS](https://nodejs.org/) installed.

1. Create a folder and open it in a command prompt or PowerShell, for example `C:\HLS-Proxy`.

1. Run the following command: `npm install "@warren-bank/hls-proxy" --save`

1. In case you have to use HTTPS (recommended), copy your certificate (.crt) and private key (.key) into the created folder.

1. Run the following command: `npx hlsd --port 8080 --tls-cert yourcertificate.crt --tls-key private.key --tls-pass password.txt`. In case the video server uses an untrusted HTTPS certificate, also add `--req-insecure` to the command.

The proxy should now be up and running.

You can **open a stream** via the proxy by using the following URL (example in JavaScript):

```JavaScript
const proxy_url = 'https://proxy-server:8080';
const video_url = 'https://example.com/video/master.m3u8';
const file_extension = '.m3u8';

const video_url_via_proxy = `${proxy_url}/${btoa(video_url)}${file_extension}`; // btoa = base64-encode
const videothumbnails = `https://dma-server/videothumbnails/video.htm?type=HTML5-HLS&source=${encodeURIComponent(video_url_via_proxy)}`; // encodeURIComponent = url-encode
```

#### Using the HLS Proxy server behind a front-end web server

Optionally, it is possible to run the HLS Proxy server behind a front-end web server with a [reverse proxy](xref:Dashboard_Gateway_installation#reverse-proxy). The `--host` parameter can be specified containing the public FQDN and port of the public-facing server. This way, no separate port needs to be made publicly accessible, and there is no need to configure the HTTPS certificate on the HLS proxy because the web server can take care of that.

The HLS Proxy echoes any leading path (for example `/hls-proxy`) in the request into all proxied URLs in the modified HLS manifest.

```JavaScript
const proxy_url = 'https://dma-server/hls-proxy';
const video_url = 'https://example.com/video/master.m3u8';
const file_extension = '.m3u8';

const video_url_via_proxy = `${proxy_url}/${btoa(video_url)}${file_extension}`; // btoa = base64-encode
const videothumbnails = `https://dma-server/videothumbnails/video.htm?type=HTML5-HLS&source=${encodeURIComponent(video_url_via_proxy)}`; // encodeURIComponent = url-encode
```

#### Installing the HLS Proxy server as a Windows service

Optionally, you can install the HLS Proxy server as a Windows service using [node-windows](https://github.com/coreybutler/node-windows).

1. Install *node-windows*: `npm install node-windows --save`

1. Create a `run.js` script that launches the proxy:

   ```JavaScript
   var spawn = require('node:child_process').spawn;

   var child = spawn('npx', [
       'hlsd',
       '--host',
       'dma.skyline.be:443',
       '--port',
       '8080'
       //'--req-insecure',
       //'--tls-cert',
       //'yourcertificate.crt',
       //'--tls-key',
       //'private.key',
       //'--tls-pass',
       //'password.txt'
   ], { shell: process.platform === 'win32' });
   child.stdout.pipe(process.stdout);
   ```

1. Create a script `install-service.js` to create the Windows service:

   ```JavaScript
   var Service = require('node-windows').Service;

   // Create a new service object
   var svc = new Service({
       name: 'HLS-Proxy',
       description: 'HLS proxy server.',
       script: require('path').join(__dirname, 'run.js'),
       nodeOptions: [
           '--max_old_space_size=4096'
       ],
       workingDirectory: __dirname
   });

   // Listen for the "install" event, which indicates the
   // process is available as a service.
   svc.on('install', function() {
       svc.start();
   });

   svc.install();
   ```

1. Run `node install-service.js` (with administrator privileges).

To remove this Windows service again:

1. Create a script `uninstall-service.js`:

   ```JavaScript
   var Service = require('node-windows').Service;

   // Create a new service object
   var svc = new Service({
       name: 'HLS-Proxy',
       script: require('path').join(__dirname, 'run.js'),
       workingDirectory: __dirname
   });

   // Listen for the "uninstall" event so we know when it's done.
   svc.on('uninstall', function() {
       console.log('Uninstall complete.');
       console.log('The service exists: ', svc.exists);
   });

   // Uninstall the service.
   svc.uninstall();
   ```

1. Run `node uninstall-service.js` (with administrator privileges).
