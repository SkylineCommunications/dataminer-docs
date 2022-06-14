---
uid: Changing_the_default_browser_engine_used_in_DataMiner_Cube
---

# Changing the default browser engine used in DataMiner Cube

From DataMiner 9.6.3 onwards, you can change the default browser engine used in DataMiner Cube.

To do so:

1. In the *System Center* module, go to *System settings* > *plugins*.

1. Select a specific default engine, or select the option to let Cube determine the default engine.

   - Prior to DataMiner 10.0.10, the default browser engine is Internet Explorer. From DataMiner 10.0.10 onwards, if Chromium is installed, the default browser engine changes to Chromium. In addition, DataMiner apps displayed within an embedded web browser in DataMiner Cube (e.g. Ticketing, Dashboards, etc.) will always use the Chromium browser engine, regardless of which default browser engine is configured.

   - From DataMiner 10.1.11/10.2.0 onwards, you can select to use *Edge* (WebView2). This browser engine has the advantage that web content is rendered directly to the graphics card and proprietary codecs such as H.264 and AAC are supported. In addition, the browser engine automatically receives updates via Windows Update, regardless of the DataMiner or Cube version.

     > [!NOTE]
     > The WebView2 Runtime is automatically installed with Office 365 Apps and/or Windows 11. It is not included in DataMiner upgrade packages.

1. Optionally, if you want a different browser to be used for a specific protocol or (prior to DataMiner 10.0.10) app:

   1. Below *Exclusions*, click *Add exclusion* and select either *Protocol* or the name of the app.

   1. For a protocol, click *\<protocol>* and select the name of the protocol.

   1. Next to *Engine*, select the engine that should be used for this protocol or app.

    > [!NOTE]
    > From DataMiner 10.0.10 onwards, it is no longer possible to specify a different browser for apps.

1. Click the *Apply* button in the lower right corner to save your changes.
