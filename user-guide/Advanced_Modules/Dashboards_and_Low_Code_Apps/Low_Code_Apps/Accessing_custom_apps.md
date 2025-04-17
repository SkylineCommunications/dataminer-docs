---
uid: Accessing_custom_apps
---

# Accessing the Low-Code Apps module

The DataMiner Low-Code Apps are available on the DataMiner landing page. To access this page, browse to the IP or hostname of a DMA or to `https://[Your DMA]/root`, depending on your configuration.

You can then access any of the available low-code apps by clicking the relevant app icon, or [create a new low-code app](xref:Creating_custom_apps).

From DataMiner 10.2.9/10.3.0 onwards, you can also access each of the published low-code apps from the apps pane in DataMiner Cube.<!-- RN 33944 -->

> [!NOTE]
>
> - Depending on your configuration, the Monitoring app may be displayed instead when you browse directly to a DMA IP or hostname. See [Configuring whether the landing page is displayed](xref:Configuring_the_landing_page#configuring-whether-the-landing-page-is-displayed).
> - To view the Low-Code Apps module, you need the user permission [Modules > User-definable apps > View apps](xref:DataMiner_user_permissions#modules--user-definable-apps--view-apps).
> - Draft apps are not shown by default. To view them, click the cogwheel button and activate *Show draft applications*.

> [!TIP]
> In many browsers, it is possible to install a low-code app as a standalone app on your computer, using the install button on the right side of the browser address bar. You can then for instance pin the app to your taskbar or add a desktop shortcut to quickly open it. Note that currently only one low-code app can be installed this way at a time.

## Accessing the Low-Code Apps via dataminer.services

If you have been granted remote access to a DataMiner System via dataminer.services, you can connect as follows:

1. Go to the public URL of the remote DataMiner System. See [Remote access](xref:About_Remote_Access).

1. Log on to dataminer.services. See [Logging on](xref:Logging_on_to_dataminer_services#logging-on).

1. Log on to the remote DataMiner System using your DataMiner login credentials.

   > [!NOTE]
   > If your DataMiner account is linked to your dataminer.services account, you will be logged in automatically with that linked DataMiner account.

1. Either click the icon of the app you want to access, or click *Create a new app* to begin [creating your first app](xref:Creating_custom_apps).
