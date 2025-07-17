---
uid: Ad_hoc_Tutorials_GQIDMS
---

# Building a GQI data source that retrieves data from a DMS

In this tutorial, you will learn how you can create a GQI data source that retrieves the active client connections from your DMS.

Expected duration: 15 minutes.

> [!NOTE]
> This tutorial uses DataMiner version 10.3.4.

> [!TIP]
> See also: [Kata #35: Interact with your DMS using an ad hoc data source](https://community.dataminer.services/courses/kata-35/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/downloads/) with [DataMiner Integration Studio](xref:Installing_and_configuring_DataMiner_Integration_Studio)

## Overview

- [Step 1: Create the ad hoc data source](#step-1-create-the-ad-hoc-data-source)
- [Step 2: Fetch the client connections from the DMS](#step-2-fetch-the-client-connections-from-the-dms)
- [Step 3: Transform DMS responses into a GQIPage](#step-3-transform-dms-responses-into-a-gqipage)
- [Step 4: Configure the script to compile as library](#step-4-configure-the-script-to-compile-as-library)

## Step 1: Create the ad hoc data source

1. Create a new class that implements the [IGQIDatasource](xref:GQI_IGQIDataSource) interface.

   > [!NOTE]
   > If certain types cannot be found in the file, verify if the *Skyline.DataMiner.Dev.Automation* NuGet package has the correct version. Go to *Tools* > *NuGet Package Manager* > *Manage NuGet Packages for Solution*. Select *Skyline.DataMiner.Dev.Automation*, and verify whether the version installed for the current project is at least *10.3.4*.

1. Implement the `GetColumns` method to define the columns of the data source.

   The data source will include two columns: a *Client* column of type `String` and a *Connection Time* column of type `DateTime`.

1. Implement the `GetNextPage` method to provide the actual data.

   For now, leave it empty, as you still need to retrieve the data from the DMS.

```csharp
[GQIMetaData(Name = "Client connections")]
public class ClientConnections : IGQIDataSource
{
    public GQIColumn[] GetColumns()
    {
        return new GQIColumn[]
        {
            new GQIStringColumn("Client"),
            new GQIDateTimeColumn("Connection Time"),
        };
    }

    public GQIPage GetNextPage(GetNextPageInputArgs args)
    {
        // TODO: Fetch the data
        return default;
    }
}
```

> [!NOTE]
> Above the class, a *GQIMetaData* attribute was added to configure the name of the data source as displayed in the Dashboards app or Low-Code Apps.

## Step 2: Fetch the client connections from the DMS

To retrieve the current client connections, the data source will have to communicate with the DMS. You can use the [GQIDMS](xref:GQI_GQIDMS) object for this. It is available in the [OnInitInputArgs](xref:GQI_OnInitInputArgs) argument of the `OnInit` method, by implementing the [IGQIOnInit](xref:GQI_IGQIOnInit) interface.

1. Add the [IGQIOnInit](xref:GQI_IGQIOnInit) interface to the class.

1. Implement the `OnInit` method, which receives [OnInitInputArgs](xref:GQI_OnInitInputArgs) as parameters.

1. Store the DMS property from the arguments in the class for later use.

   ```csharp
   [GQIMetaData(Name = "Client connections")]
   public class ClientConnections : IGQIDataSource
   {
       private GQIDMS _dms;

       public OnInitOutputArgs OnInit(OnInitInputArgs args)
       {
           _dms = args.DMS;
           return default;
       }
   }
   ```

1. Use the `GQIDMS` object to send messages to the DMS.

   Retrieve the client connections by sending a `GetInfoMessage`. The response will be a collection of `LoginInfoResponseMessage` objects.

   ```csharp
       public GQIPage GetNextPage(GetNextPageInputArgs args)
       {
           var request = new GetInfoMessage(InfoType.ClientList);
           var responses = _dms.SendMessages(request).OfType<LoginInfoResponseMessage>();
           return default;
       }
   ```

> [!IMPORTANT]
> DMS messages are subject to change without notice. If you can implement an alternative using the [built-in data sources](xref:Query_data_sources), we highly recommend that you do so instead.

## Step 3: Transform DMS responses into a GQIPage

Transform the responses into a [GQIPage](xref:GQI_GQIPage). Each `LoginInfoResponseMessage` represents an active client connection and will be converted into a row.

```csharp
    public GQIPage GetNextPage(GetNextPageInputArgs args)
    {
        var request = new GetInfoMessage(InfoType.ClientList);
        var responses = _dms.SendMessages(request).OfType<LoginInfoResponseMessage>();

        var rows = new List<GQIRow>();
        foreach (var response in responses)
        {
            rows.Add(new GQIRow(
                new GQICell[]
                {
                    new GQICell()
                    {
                        Value = response.FriendlyName,
                    },
                    new GQICell()
                    {
                        Value = DateTime.SpecifyKind(response.ConnectTime, DateTimeKind.Utc),
                    },
                }));
        }

        return new GQIPage(rows.ToArray());
    }
```

> [!NOTE]
> Ensure `DateTime` values are in UTC. Although the `ConnectTime` value is in UTC, it is not explicitly marked as such. Therefore, this is specified in the example.

## Step 4: Configure the script to compile as library

In order for GQI to work, the script must be configured to compile as a library.

To do so:

- If you use DIS, add the following to the *Script.Exe* tag in the script XML:

  ```xml
     <Param type="preCompile">true</Param>
     <Param type="libraryName">Kata Clients Connections</Param>
  ```

- If you do not use DIS, in the Automation module in Cube, select the *Compile as library* option. See [Compiling a C# code block as a library](xref:Compiling_a_CSharp_code_block_as_a_library).
