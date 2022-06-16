---
uid: Accessing_the_legacy_Monitoring_Control_app
---

# Accessing the legacy Monitoring & Control app

The legacy HTML5 Monitoring & Control app is available in older DataMiner versions, prior to DataMiner 10.0.0/10.0.2.

To access the app, open a browser and, depending on your setup, go to one of the following addresses:

```txt
http://[DMA]/m
https://[DMA]/m
```

Alternatively, you can browse directly to the IP of the DMA using Google Chrome, Microsoft Edge, Mozilla Firefox, or Safari. If you do so, depending on your default application settings, either a redirect to */m* will occur, or a landing page will be displayed from which you can open the Monitoring & Control app.

> [!CAUTION]
> If you use a DataMiner version prior to DataMiner 10.1.7, we strongly advise that you use HTTPS when you use DataMiner client applications over public internet. If you do not do so, all information – including logon credentials – is sent as plain, unencrypted text over the internet. From DataMiner 10.1.7 onwards, client-server communication is encrypted by default. See also: [Setting up HTTPS on a DMA](xref:Setting_up_HTTPS_on_a_DMA).

The first time you start the app, you will be asked to enter your account details.

If, in the future, you want to log on automatically, select *remember me* to have your account details saved locally on your device.

> [!NOTE]
>
> - When a user for whom two-step authentication is enabled logs on to DataMiner using the app, a challenge will be shown to which the user has to respond. If that response is correct, then access will be granted. If not, access will be denied and the user will be redirected to the logon screen.
> - From DataMiner 9.6.7 onwards, it is possible to add this app to the home screen of a mobile device. The way this is done depends on the device and browser used. For example, when using Chrome on Android, you can add the app to the home screen by browsing to the app and then selecting *Add to Home screen* in the Chrome settings.

> [!TIP]
> See also:
>
> - [Configuring whether the landing page is displayed](xref:Configuring_the_landing_page#configuring-whether-the-landing-page-is-displayed)
> - [The legacy Monitoring & Control app user interface](xref:The_legacy_Monitoring_Control_app_user_interface#the-legacy-monitoring--control-app-user-interface)
