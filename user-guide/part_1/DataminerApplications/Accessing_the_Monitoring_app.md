# Accessing the Monitoring app

To access the Monitoring app, depending on your setup, go to one of the following addresses in a browser:

```txt
http://[DMA]/monitoring
https://[DMA]/monitoring
```

Alternatively, you can directly browse to the IP of the DMA in a browser other than Internet Explorer. If you do so, depending on your default application settings, either a redirect to */monitoring* will occur, or a landing page will be displayed from which you can open the Monitoring app.

> [!CAUTION]
> If you use a DataMiner version prior to DataMiner 10.1.7, we strongly advise to use HTTPS when you use DataMiner client applications over public internet. If you do not do so, all information – including logon credentials – is sent as plain, unencrypted text over the internet. From DataMiner 10.1.7 onwards, client-server communication is encrypted by default. See also: [Setting up HTTPS on a DMA](../../part_3/DataminerAgents/General_DMA_configuration.md#setting-up-https-on-a-dma).

The first time you start the app, you will be asked to enter your credentials. To log on automatically in the future, enable *Keep me logged in*.

If two-step authentication is enabled, when you log on, a challenge will be shown to which you will have to respond. If your response is not correct, you will be redirected to the logon screen.

> [!NOTE]
> -  You can add this app to the home screen of a mobile device. The way this is done depends on the device and browser used. For example, when using Chrome on Android, you can add the app to the home screen by browsing to the app and then selecting *Add to Home screen* in the Chrome settings.
> -  If WebSockets are supported and available on the server, the app will use a WebSocket connection to retrieve element information. Otherwise, it will fall back to polling every 5 seconds.
> -  The following browsers are supported: Google Chrome, Microsoft Edge, Mozilla Firefox and Safari.
> -  The Monitoring app can also be made available via a gateway server. See [Dashboard Gateway installation](../../part_4/newR_D/Dashboard_Gateway_installation.md).

> [!TIP]
> See also:
> -  [Configuring the default landing page](../../part_3/DataminerAgents/DMA_configuration_related_to_client_applications.md#configuring-the-default-landing-page)
> -  [The Monitoring app user interface](../GettingStarted/The_Monitoring_app_user_interface.md)
>
