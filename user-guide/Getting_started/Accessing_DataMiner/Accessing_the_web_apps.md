---
uid: Accessing_the_web_apps
---

# Accessing the web apps

You can access all DataMiner web apps via the **DataMiner landing page**.

1. In a browser, go to: `https://[DMA]/root/`.

   In the above-mentioned address, replace `[DMA]` by the IP address or the hostname of the DataMiner Agent you want to connect to. If this is not your own DMA, make sure you have been granted remote access to the DataMiner System.

1. From the landing page, click the icon of the app you want to open:

   ![Landing page](~/user-guide/images/DataMiner_Landing_Page.png)<br>*DataMiner landing page in DataMiner 10.5.8*

   - [Dashboards app](xref:newR_D)

     > [!NOTE]
     > We recommend using Google Chrome to access the Dashboards app. Microsoft Edge, Mozilla Firefox, and Safari are also supported.

   - [Low-Code Apps](xref:Application_framework)

   - [Monitoring app](xref:The_Monitoring_app_user_interface)

> [!NOTE]
> To access a compact overview of all available web apps in your system, click the DataMiner icon in the top-left corner of the DataMiner landing page. Prior to DataMiner 10.4.0 [CU17]/10.5.0 [CU5]/10.5.8<!--RN 43024-->, a waffle icon is shown in the top-left corner instead.
> A system administrator can customize the landing page via the default application settings so that you immediately, for example the monitoring app as the DataMiner landing page. In that case, you can click the icon in the top-left corner of the page to access the other web apps.

> [!CAUTION]
> If you use a DataMiner version prior to DataMiner 10.1.7, we strongly advise that you use HTTPS when you use DataMiner client applications over public internet. If you do not do so, all information – including logon credentials – is sent as plain, unencrypted text over the internet. From DataMiner 10.1.7 onwards, client-server communication is encrypted by default. See also: [Setting up HTTPS on a DMA](xref:Setting_up_HTTPS_on_a_DMA).
