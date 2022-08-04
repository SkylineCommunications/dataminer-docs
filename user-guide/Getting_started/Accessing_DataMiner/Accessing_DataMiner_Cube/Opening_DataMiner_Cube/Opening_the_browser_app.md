---
uid: Opening_the_browser_app
---

# Opening the browser application

While this is no longer recommended, it is possible to use DataMiner Cube as a browser app. In the past, Internet Explorer was used for this, but now you can use Microsoft Edge in IE compatibility mode (see [Configuring Microsoft Edge to run DataMiner Cube](xref:Configuring_Microsoft_edge_to_run_Cube)) or Chrome with the [IE Tab extension](https://chrome.google.com/webstore/detail/ie-tab/hehijbfgiekmjfkfjpbkbammjbdenadd).

When you have configured your browser to run DataMiner Cube, depending on your setup, go to one of the following addresses to open the browser app:

```txt
http://[DMA]/dataminercube
https://[DMA]/dataminercube
```

> [!NOTE]
>
> - In the above-mentioned address, replace “\[DMA\]” by the IP address or the hostname of the DataMiner Agent you want to connect to.
> - If DataMiner Cube has been set as the default client, it is not necessary to add “*/dataminercube*” in the URL.
> - DataMiner Cube will automatically disconnect when the DMA to which you are connected goes offline.
> - It is good practice to encode URLs according to the W3C guidelines. For more information, see <http://www.w3schools.com/tags/ref_urlencode.asp>.

> [!CAUTION]
> If you use a DataMiner version prior to DataMiner 10.1.7, we strongly advise using HTTPS when you use DataMiner client applications over public internet. If you do not do so, all information – including logon credentials – is sent as plain, unencrypted text over the internet. From DataMiner 10.1.7 onwards, client-server communication is encrypted by default. See also: [Setting up HTTPS on a DMA](xref:Setting_up_HTTPS_on_a_DMA).
