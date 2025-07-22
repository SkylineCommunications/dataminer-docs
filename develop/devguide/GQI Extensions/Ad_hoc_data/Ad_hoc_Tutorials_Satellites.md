---
uid: Ad_hoc_Tutorials_Satellites
---

# Building a GQI data source that fetches satellites

In this tutorial, you will learn how you can create a GQI data source that can be used to add ad hoc data to a dashboard or low-code app.

Expected duration: 15 minutes.

> [!TIP]
> See also: [Kata #4: Build your first GQI](https://community.dataminer.services/courses/kata-4/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

> [!NOTE]
> This tutorial uses DataMiner version 10.3.0.

## Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/downloads/) with [DataMiner Integration Studio](xref:Installing_and_configuring_DataMiner_Integration_Studio)
- A DataMiner Agent [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)

## Overview

- [Step 1: Get a quick start from the catalog](#step-1-get-a-quick-start-from-the-catalog)
- [Step 2: Open the data source in Visual Studio](#step-2-open-the-data-source-in-visual-studio)
- [Step 3: Complete the data source](#step-3-complete-the-data-source)
- [Step 4: Use the data source](#step-4-use-the-data-source)

## Step 1: Get a quick start from the catalog

1. Go to [https://catalog.dataminer.services/details/package/5406](https://catalog.dataminer.services/details/package/5406)

1. Deploy the catalog item to your DataMiner Agent by clicking the *Deploy* button.

## Step 2: Open the data source in Visual Studio

1. Open Visual Studio and select *Extensions* > *DIS* > *DMA* > *Connect* to connect DIS to your DMA.

1. Select *Extensions* > *DIS* > *DMA* > *Import Automation Script*.

1. Select *Satellites - GQIDS* and click *Import*.

1. Go to the C# code of the imported Automation script by clicking the C# icon.

   ![C# icon](~/dataminer/images/GQI_code.png)

> [!NOTE]
> If certain types cannot be found in the file, verify if the *Skyline.DataMiner.Dev.Automation* NuGet package has the correct version. Go to *Tools* > *NuGet Package Manager* > *Manage NuGet Packages for Solution*. Select *Skyline.DataMiner.Dev.Automation*, and verify whether the version installed for the current project is at least *10.2.4*.

## Step 3: Complete the data source

1. Add the *IGQIDataSource* interface to the *SatellitesDataSource* class. Do this by removing the comments (`//`) in front of *IGQIDataSource*.

1. Implement the *GetColumns* method to provide GQI with all the columns of the data source.

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

   By implementing both methods provided by the *IGQIDataSource* interface, you have now successfully finished the data source.

1. To publish your changes, go to the XML file and click *Publish* in the top left corner.

   ![Publish option](~/dataminer/images/GQI_publish.png)

## Step 4: Use the data source

1. Open the *Dashboards* app and [create a new dashboard](xref:Creating_a_completely_new_dashboard).

1. In the *Data* pane on the right, go to *Queries* and click the "+" icon to create a query.

   ![+ icon to create query](~/dataminer/images/GQI_create_query.png)

1. Select *Get ad hoc data* and select *Satellites* as *Data source* option.

1. Drag the query to the dashboard.

1. [Select a table visualization](xref:Apply_Visualization) for the component.

   The satellites should now be displayed in the table.
