---
uid: Changing_the_default_browser_engine_used_in_DataMiner_Cube
---

# Changing the default browser engine used in DataMiner Cube

To change the default browser engine used in DataMiner Cube:

1. In the *System Center* module, go to *System settings* > *plugins*.

1. Select a specific default engine, or select the option to let Cube determine the default engine.

   - If Chromium is installed, this will be the default browser engine. In addition, DataMiner apps displayed within an embedded web browser in DataMiner Cube (e.g. Ticketing, Dashboards, etc.) will always use the Chromium browser engine, regardless of which default browser engine is configured.

   - From DataMiner 10.1.11/10.2.0 onwards, you can select to use *Edge* (WebView2). This browser engine has the advantage that web content is rendered directly to the graphics card and proprietary codecs such as H.264 and AAC are supported. In addition, the browser engine automatically receives updates via Windows Update, regardless of the DataMiner or Cube version.

     > [!NOTE]
     > The WebView2 Runtime is not included in DataMiner upgrade packages. It is automatically installed with Office 365 apps and/or Windows 11. You can also get the Evergreen Bootstrapper or Standalone installer from Microsoft: [Microsoft Edge WebView2](https://developer.microsoft.com/en-us/microsoft-edge/webview2/?form=MA13LH#download-section).

1. Optionally, if you want a different browser to be used for a specific protocol:

   1. Below *Exclusions*, click *Add protocol exclusion*.

   1. Click *\<protocol>* and select the name of the protocol.

   1. Next to *Engine*, select the engine that should be used for this protocol.

1. Click the *Apply* button in the lower right corner to save your changes.
