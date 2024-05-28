---
uid: Ad_hoc_Tutorials_GQIDMS
---

# Building a GQI data source that retrieves data from a DMS

In this tutorial, you will learn how you can create a GQI data source that retrieves the active client connections from your DMS.

Expected duration: 15 minutes.

> [!NOTE]
> This tutorial uses DataMiner version 10.3.4/10.4.0 onwards.

## Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/downloads/) with [DataMiner Integration Studio](xref:Installing_and_configuring_DataMiner_Integration_Studio)

## Overview

- [Step 1: Create the ad hoc data source](#step-1-create-the-ad-hoc-data-source)
- [Step 2: Fetch the client connections from the DMS](#step-2-fetch-the-client-connections-from-the-dms)
- [Step 3: Parse the responses into a GQIPage](#step-3-parse-the-responses-into-a-gqipage)

## Step 1: Create the ad hoc data source

1. Create a new class that implements the [IGQIDatasource](xref:GQI_IGQIDataSource) interface.

> [!NOTE]
> If certain types cannot be found in the file, verify if the *Skyline.DataMiner.Dev.Automation* NuGet package has the correct version. Go to *Tools* > *NuGet Package Manager* > *Manage NuGet Packages for Solution*. Select *Skyline.DataMiner.Dev.Automation*, and verify whether the version installed for the current project is at least *10.3.4*.

1. Implement the GetColumns function to define the columns that the data source will contain. Our data source will include two columns: `Client` (of type `String`) and `Connection Time` (of type `DateTime`).

1. Implement the `GetNextPage` function to provide the actual data. For now, leave it empty since we still need to retrieve the data from the DMS.

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

## Step 2: Fetch the client connections from the DMS

To retrieve the current client connections, communication with the DMS is required. You can use the [GQIDMS](xref:GQI_GQIDMS) object, available in the [OnInitInputArgs](xref:GQI_OnInitInputArgs) argument of the `OnInit` function, by implementing the [IGQIOnInit](xref:GQI_IGQIOnInit) interface.

1. Add the [IGQIOnInit](xref:GQI_IGQIOnInit) interface to the class.

1. Implement the `OnInit` function, which receives [OnInitInputArgs](xref:GQI_OnInitInputArgs) as input arguments. Store the DMS property from the arguments in the class for later use.

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

1. We can use the `GQIDMS` object to send messages to the DMS, to retrieve the client connections we will need the `GetInfoMessage`. The response to that message are multiple `LoginInfoResponseMessage` objects.

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

## Step 3: Parse the responses into a GQIPage

1. Parse the responses into a [GQIPage](xref:GQI_GQIPage).

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