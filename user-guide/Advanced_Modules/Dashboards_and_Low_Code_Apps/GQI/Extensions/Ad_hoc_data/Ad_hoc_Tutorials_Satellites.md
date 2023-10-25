---
uid: Ad_hoc_Tutorials_Satellites
---

# Create your first GQI data source: Satellites

In this tutorial, you will learn how you can create your first GQI data source which can be used to add ad hoc data to your dashboard or low-code app.

Expected duration: 15 minutes.

## Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/downloads/)
- Cloud connected agent

## Step 1: Get a quick start from the catalog

1. Go to [https://catalog.dataminer.services/catalog/5406](https://catalog.dataminer.services/catalog/5406)
1. Deploy the catalog item to your DataMiner Agent.

## Step 2: Open the data source in Visual Studio

Open Visual Studio and connect DIS to your DMA, go to *Extensions* -> *DIS* -> *DMA* -> *Connect*.

> [!NOTE]
> If you do not have DIS yet, you should download and install it. For detailed information, refer to [Installing and configuring DataMiner Integration Studio](xref:Installing_and_configuring_DataMiner_Integration_Studio).
1. Import the data source, by going to *Extensions* -> *DIS* -> *DMA* -> *Import Automation Script...*
1. Select *Satellites - GQIDS* and click Import.
1. Go to the C# code of the imported automation script.

## Step 3: Complete the data source

1. Add the *IGQIDataSource* interface to the SatellitesDataSource class.
1. Implement the *GetColumns* method to provide GQI with all the columns the data source has.
```csharp
    public GQIColumn[] GetColumns()
    {
        return new GQIColumn[] {
            new GQIStringColumn("Name"),
            new GQIDoubleColumn("Latitude"),
            new GQIDoubleColumn("Longitude")
        };
    }
```
1. Implement the *GetNextPage* method to provide GQI with the actual data. Each row is one satellite.
```csharp
    public GQIPage GetNextPage(GetNextPageInputArgs args)
    {
        var satellites = _satellitesHelper.GetSatellites().Take(100);
        var rows = new List<GQIRow>();
        foreach (var satellite in satellites) {
            var cells = new GQICell[] {
                new GQICell(){ Value = satellite.Name },
                new GQICell(){ Value = satellite.Latitude},
                new GQICell() { Value = satellite.Longitude}
            };
            var row = new GQIRow(cells);
            rows.Add(row);
        }

        return new GQIPage(rows.ToArray());
    }
```
1. By implementing both methods provided by the *IGQIDataSource* interface, we have successfully finished the data source. Let's publish these changes by going to the xml file and click *Publish* in the top left corner.

## Step 4: Use the data source 

1. Open the *Dashboards* app, create a new dashboard and go to *queries* in the right panel.
1. Create a new query, select *Get ad hoc data* and select *Satellites* as *Data source* option.
1. Drag this query to your dashboard and pick a table visualization. You should see all the satellites popping up!