---
uid: Video_streaming_with_proxy
---

# Video streaming with proxy

Video streams are typically only accessible within the internal network, and this is usually for a good reason, for example because paid TV channels are involved that should not be publicly available. Another reason to use a proxy is to avoid CORS or CSP restrictions: if you run the proxy on the same origin as the web app playing the video, it will load the video from the same origin, which is not a cross-origin request.

> [!CAUTION]
> Setting up a proxy could create a weakness in the network security, giving users from the public network access to resources on the private network. Use this with extreme caution.

## Installing and running HLS Proxy

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

## Using the HLS Proxy server behind a front-end web server

Optionally, it is possible to run the HLS Proxy server behind a front-end web server with a [reverse proxy](xref:Dashboard_Gateway_installation#reverse-proxy). The `--host` parameter can be specified containing the public FQDN and port of the public-facing server. This way, no separate port needs to be made publicly accessible, and there is no need to configure the HTTPS certificate on the HLS proxy because the web server can take care of that.

The HLS Proxy echoes any leading path (for example `/hls-proxy`) in the request into all proxied URLs in the modified HLS manifest.

```JavaScript
const proxy_url = 'https://dma-server/hls-proxy';
const video_url = 'https://example.com/video/master.m3u8';
const file_extension = '.m3u8';

const video_url_via_proxy = `${proxy_url}/${btoa(video_url)}${file_extension}`; // btoa = base64-encode
const videothumbnails = `https://dma-server/videothumbnails/video.htm?type=HTML5-HLS&source=${encodeURIComponent(video_url_via_proxy)}`; // encodeURIComponent = url-encode
```

## Installing the HLS Proxy server as a Windows service

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
