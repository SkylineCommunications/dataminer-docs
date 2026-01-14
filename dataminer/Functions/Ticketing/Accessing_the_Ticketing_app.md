---
uid: Accessing_the_Ticketing_app
---

# Accessing the Ticketing app

> [!IMPORTANT]
> The Ticketing app is obsolete. It is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.<!-- RN 44371+44373 -->

To access the Ticketing app:

- In DataMiner Cube, go to *Apps* > *Ticketing*, or

- Go directly to the link `https://[MyDataMiner]/Ticketing` or `http://[MyDataMiner]/Ticketing`, depending on your setup.

> [!NOTE]
>
> - The standalone Ticketing app can be accessed using Google Chrome, Microsoft Edge, Mozilla Firefox or Safari.
> - When you embed the Ticketing app in another page, e.g. in Visual Overview, you can add *embed=true* to its URL in order to hide the sidebar and header bar of the app. You can also add a filter in the Ticketing URL to only show tickets affecting a specific element, service, view or redundancy groups. To do so, add a filter in the following format: *affecting=\[type\]/\[DataMiner ID\]/\[object ID\]*, where \[type\] can be *element*, *service*, *view* or *redundancy group*. For example: *affecting=element/299/31*

## Accessing the Ticketing app via dataminer.services

If you have been granted remote access to a DataMiner System via dataminer.services, you can connect as follows:

1. Go to the public URL of the remote DataMiner System. See [Remote access](xref:About_Remote_Access).

1. Log on to dataminer.services. See [Logging on](xref:Logging_on_to_dataminer_services#logging-on).

1. Log on to the remote DataMiner System using your DataMiner login credentials.

   > [!NOTE]
   > If your DataMiner account is linked to your dataminer.services account, you will be logged in automatically with that linked DataMiner account.

1. Click the *Ticketing* icon.
