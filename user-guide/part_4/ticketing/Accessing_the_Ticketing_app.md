# Accessing the Ticketing app

To access the Ticketing app:

- In DataMiner Cube, go to *Apps* > *Ticketing*, or

- Go directly to the link https://\[MyDataMiner\]/Ticketing or http://\[MyDataMiner\]/Ticketing, depending on your setup.

> [!NOTE]
> - The standalone Ticketing app can be accessed using Google Chrome, Microsoft Edge, Mozilla Firefox or Safari.
> - When you embed the Ticketing app in another page, e.g. in Visual Overview, from DataMiner 10.0.13 onwards, you can add *embed=true* to its URL in order to hide the side bar and header bar of the app. You can also add a filter in the Ticketing URL to only show tickets affecting a specific element, service, view or redundancy groups. To do so, add a filter in the following format: *affecting=\[type\]/\[DataMiner ID\]/\[object ID\]*, where \[type\] can be *element*, *service*, *view* or *redundancy group*. For example: *affecting=element/299/31*

> [!CAUTION]
> If you use a DataMiner version prior to DataMiner 10.1.7, we strongly advise to use HTTPS when you use DataMiner client applications over public internet. If you do not do so, all information – including logon credentials – is sent as plain, unencrypted text over the internet. From DataMiner 10.1.7 onwards, client-server communication is encrypted by default. See also: [Setting up HTTPS on a DMA](../../part_3/DataminerAgents/General_DMA_configuration.md#setting-up-https-on-a-dma).
