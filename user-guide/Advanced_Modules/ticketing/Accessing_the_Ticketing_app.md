---
uid: Accessing_the_Ticketing_app
---

# Accessing the Ticketing app

To access the Ticketing app:

- In DataMiner Cube, go to *Apps* > *Ticketing*, or

- Go directly to the link `https://[MyDataMiner]/Ticketing` or `http://[MyDataMiner]/Ticketing`, depending on your setup.

> [!NOTE]
>
> - The standalone Ticketing app can be accessed using Google Chrome, Microsoft Edge, Mozilla Firefox or Safari.
> - When you embed the Ticketing app in another page, e.g. in Visual Overview, from DataMiner 10.0.13 onwards, you can add *embed=true* to its URL in order to hide the sidebar and header bar of the app. You can also add a filter in the Ticketing URL to only show tickets affecting a specific element, service, view or redundancy groups. To do so, add a filter in the following format: *affecting=\[type\]/\[DataMiner ID\]/\[object ID\]*, where \[type\] can be *element*, *service*, *view* or *redundancy group*. For example: *affecting=element/299/31*

> [!CAUTION]
> If you use a DataMiner version prior to DataMiner 10.1.7, we strongly advise that you use HTTPS when you use DataMiner client applications over public internet. If you do not do so, all information – including logon credentials – is sent as plain, unencrypted text over the internet. From DataMiner 10.1.7 onwards, client-server communication is encrypted by default. See also: [Setting up HTTPS on a DMA](xref:Setting_up_HTTPS_on_a_DMA).

## Accessing the Ticketing app via dataminer.services

If you have been granted remote access to a DataMiner System via dataminer.services, you can connect as follows:

1. Go to the public URL of the remote DataMiner System. See [Remote access](xref:Cloud_Remote_Access).

1. Log on to dataminer.services. See [Logging on](xref:Logging_on_to_the_DataMiner_Cloud_Platform#logging-on).

1. Log on to the remote DataMiner System using your DataMiner login credentials.

   > [!NOTE]
   > If your DataMiner account is linked to your dataminer.services account, you will be logged in automatically with that linked DataMiner account.

1. Click the *Ticketing* icon.
