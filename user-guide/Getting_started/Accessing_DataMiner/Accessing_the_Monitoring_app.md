---
uid: Accessing_the_Monitoring_app
---

# Accessing the Monitoring app

To access the Monitoring app, depending on your setup, go to one of the following addresses in a browser:

```txt
http://[DMA]/monitoring
https://[DMA]/monitoring
```

Alternatively, you can browse directly to the IP of the DMA using Google Chrome, Microsoft Edge, Mozilla Firefox, or Safari. If you do so, depending on your default application settings, either a redirect to */monitoring* will occur, or a landing page will be displayed from which you can open the Monitoring app.

> [!CAUTION]
> If you use a DataMiner version prior to DataMiner 10.1.7, we strongly advise that you use HTTPS when you use DataMiner client applications over public internet. If you do not do so, all information – including logon credentials – is sent as plain, unencrypted text over the internet. From DataMiner 10.1.7 onwards, client-server communication is encrypted by default. See also: [Setting up HTTPS on a DMA](xref:Setting_up_HTTPS_on_a_DMA).

The first time you start the app, you will be asked to enter your credentials. To log on automatically in the future, enable *Keep me logged in*.

If two-step authentication is enabled, when you log on, a challenge will be shown to which you will have to respond. If your response is not correct, you will be redirected to the logon screen.

> [!NOTE]
>
> - Along with the other DataMiner web apps, you can upgrade the Monitoring app separately from your main DataMiner installation. This means that you can for example have a DataMiner System using version 10.3.4, while you already use version 10.3.5 for the web apps. You can [download the web apps upgrade package from DataMiner Dojo](https://community.dataminer.services/downloads/).
> - You can add this app to the home screen of a mobile device. The way this is done depends on the device and browser used. For example, when using Chrome on Android, you can add the app to the home screen by browsing to the app and then selecting *Add to Home screen* in the Chrome settings.
> - If WebSockets are supported and available on the server, the app will use a WebSocket connection to retrieve element information. Otherwise, it will fall back to polling every 5 seconds.
> - The Monitoring app can also be made available via a gateway server. See [Dashboard Gateway installation](xref:Dashboard_Gateway_installation).

> [!TIP]
> See also:
>
> - [Configuring whether the landing page is displayed](xref:Configuring_the_landing_page#configuring-whether-the-landing-page-is-displayed)
> - [The Monitoring app user interface](xref:The_Monitoring_app_user_interface)

## Accessing the Monitoring app via dataminer.services

If you have been granted remote access to a DataMiner System via dataminer.services, you can connect as follows:

1. Go to the public URL of the remote DataMiner System. See [Remote access](xref:Cloud_Remote_Access).

1. Log on to dataminer.services. See [Logging on](xref:Logging_on_to_the_DataMiner_Cloud_Platform#logging-on).

1. Log on to the remote DataMiner System using your DataMiner login credentials.

   > [!NOTE]
   > If your DataMiner account is linked to your dataminer.services account, you will be logged in automatically with that linked DataMiner account.

1. Click the *Monitoring* icon.
