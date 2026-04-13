---
uid: Changing_the_default_browser_engine_used_in_DataMiner_Cube
---

# Changing the default browser engine used in DataMiner Cube

To change the default browser engine used in DataMiner Cube:

1. In the *System Center* module, go to *System settings* > *plugins*.

1. Select a specific default engine, or select the option to let Cube determine the default engine.

   - **Edge** (default): From DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43429-->, Edge (WebView2) is the default web browser engine. This browser engine has the advantage that web content is rendered directly to the graphics card and proprietary codecs such as H.264 and AAC are supported. In addition, the browser engine automatically receives updates via Windows Update, regardless of the DataMiner or Cube version.

     > [!NOTE]
     > The WebView2 Runtime is not included in DataMiner upgrade packages. While it is pre-installed on most recent Windows versions, you may need to install it manually on older Windows versions or on certain Windows Server editions. We highly recommend performing a system-wide installation as Administrator. See [DataMiner Client Requirements - WebView2](xref:DataMiner_Client_Requirements#microsoft-webview2).

   - **Chromium**: In versions up to DataMiner 10.4.0 [CU17]/10.5.0 [CU5]/10.5.8<!--RN 43429-->, Chromium is the default browser engine if installed. However, in more recent versions, Chromium can no longer be set as the default engine.

     DataMiner apps displayed within an embedded web browser in DataMiner Cube (e.g., Dashboards) will always use the Chromium browser engine, regardless of which default browser engine is configured.

1. Optionally, if you want a different browser to be used for a specific protocol:

   1. Below *Exclusions*, click *Add protocol exclusion*.

   1. Click *\<protocol>* and select the name of the protocol.

   1. Next to *Engine*, select the engine that should be used for this protocol.

1. Click the *Apply* button in the lower-right corner to save your changes.
