---
uid: Accessing_dashboards
---

# Accessing dashboards

To access DataMiner dashboards:

- In DataMiner Cube, go to *Apps* > *Reports & Dashboards*, or

- Go directly to the link `https://[MyDataMiner]/Dashboards` or `http://[MyDataMiner]/Dashboards`, depending on your setup.

    > [!CAUTION]
    > If you use a DataMiner version prior to DataMiner 10.1.7, we strongly advise that you use HTTPS when you use DataMiner client applications over public internet. If you do not do so, all information – including logon credentials – is sent as plain, unencrypted text over the internet. From DataMiner 10.1.7 onwards, client-server communication is encrypted by default. See also: [Setting up HTTPS on a DMA](xref:Setting_up_HTTPS_on_a_DMA).

More information on accessing the Dashboards app is included in the following topics:

- [Logging on to the Dashboards App](xref:Logging_on_to_the_Dashboards_App)

- [Dashboard URL options](xref:Dashboard_URL_options)

> [!NOTE]
>
> - Some dashboard components, such as the *Trend parameter* component, can be used outside the *Dashboards* app in custom portals. The code and web services for the components can be found on the DMA in the folder *C:\\Skyline DataMiner\\Webpages\\Dashboards\\Parts*.
> - While data is being loaded in a dashboard, an activity indicator is displayed in the top-right corner of the page. You can click the indicator to see the number of calls in progress.
