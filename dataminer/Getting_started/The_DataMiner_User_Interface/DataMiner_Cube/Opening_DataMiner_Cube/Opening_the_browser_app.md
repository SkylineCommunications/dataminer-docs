---
uid: Using_the_browser_app
---

# Using the browser application

> [!IMPORTANT]
> The DataMiner Cube browser app reached *End of Life* as of DataMiner 10.3.x. While existing features will continue to function, some new features will only be supported in the DataMiner Cube desktop app. From DataMiner 10.4.0 [CU12]/10.5.3 onwards<!--RN 41873 + 41844-->, the option to install the browser application (via XBAP upgrade packages) has been removed. We recommend using the [DataMiner Cube desktop app](xref:Connecting_to_a_DMA_with_Cube) instead.

Up to DataMiner 10.5.2/10.4.0 [CU11]<!--RN 41844-->, it is possible to use DataMiner Cube as a browser app, but this is not recommended. In the past, Internet Explorer was used for this, but now you can use Microsoft Edge in IE compatibility mode (see [Configuring Microsoft Edge to run DataMiner Cube](xref:Configuring_Microsoft_edge_to_run_Cube)) or Chrome with the [IE Tab extension](https://chrome.google.com/webstore/detail/ie-tab/hehijbfgiekmjfkfjpbkbammjbdenadd).

When you have configured your browser to run DataMiner Cube, depending on your setup, go to one of the following addresses to open the browser app:

```txt
http://[DMA]/dataminercube
https://[DMA]/dataminercube
```

> [!NOTE]
>
> - In the above-mentioned address, replace “\[DMA\]” by the IP address or the hostname of the DataMiner Agent you want to connect to.
> - From DataMiner 10.4.0 [CU12]/10.5.3 onwards<!--RN 41844-->, the above-mentioned addresses will trigger the installation of the *DataMinerCube.exe* file (i.e. the Cube desktop application) instead of the browser app.
> - If DataMiner Cube has been set as the default client, it is not necessary to add “*/dataminercube*” in the URL.
> - Each time you connect to a DataMiner Agent, the software version will be checked. If you connect to a DMA with a higher DataMiner version than your current version of Cube, Cube will automatically be updated.
> - DataMiner Cube will automatically disconnect when the DMA to which you are connected goes offline.
> - It is possible to connect to Cube using specific [URL arguments](xref:Options_for_opening_DataMiner_Cube).
> - It is good practice to encode URLs according to the W3C guidelines. For more information, see <http://www.w3schools.com/tags/ref_urlencode.asp>.
> - While the desktop version of DataMiner Cube runs as a 64-bit process on 64-bit systems and as a 32-bit process on 32-bit systems, the DataMiner Cube browser application always runs as a 32-bit process.
