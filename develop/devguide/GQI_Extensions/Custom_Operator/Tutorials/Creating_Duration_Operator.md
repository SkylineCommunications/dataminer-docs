---
uid: Creating_Duration_Operator
---

# Building a GQI custom operator that calculates a duration

In this tutorial, you will learn how you can create a GQI custom operator that can be used to calculate a duration.

Expected duration: 15 minutes.

> [!TIP]
> See also:
>
> - [Configuring a custom operator for a query](xref:GQI_Custom_Operator)
> - [Kata #5: Transform data with GQI](https://community.dataminer.services/courses/kata-5/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

> [!NOTE]
> This tutorial uses DataMiner version 10.3.9.

## Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/downloads/) with [DataMiner Integration Studio](xref:Installing_and_configuring_DataMiner_Integration_Studio)

- A DataMiner Agent [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)

- If you are using a DataMiner version prior to DataMiner 10.3.0 [CU10]/10.4.1, make sure the [*GenericInterface* soft-launch option](xref:Overview_of_Soft_Launch_Options#genericinterface) is enabled.

  > [!TIP]
  > See [Activating soft-launch options](xref:Activating_Soft_Launch_Options).

- Basic knowledge of GQI extension development.

## Overview

- [Step 1: Get a quick start from the catalog](#step-1-get-a-quick-start-from-the-catalog)
- [Step 2: Open the custom operator in Visual Studio](#step-2-open-the-custom-operator-in-visual-studio)
- [Step 3: Provide the input arguments for the custom operator](#step-3-provide-the-input-arguments-for-the-custom-operator)
- [Step 4: Create a new column to show the duration](#step-4-create-a-new-column-to-show-the-duration)
- [Step 5: Add the duration to the added column](#step-5-add-the-duration-to-the-added-column)
- [Step 6: Use the data source](#step-6-use-the-data-source)

## Step 1: Get a quick start from the catalog

1. Go to [https://catalog.dataminer.services/details/package/5408](https://catalog.dataminer.services/details/package/5408)

1. Deploy the catalog item to your DataMiner Agent by clicking the *Deploy* button.

## Step 2: Open the custom operator in Visual Studio

1. Open Visual Studio and select *Extensions* > *DIS* > *DMA* > *Connect* to connect DIS to your DMA.

1. Select *Extensions* > *DIS* > *DMA* > *Import Automation Script*.

1. Select *Duration - GQIO* and click *Import*.

1. Go to the C# code of the imported Automation script by clicking the C# icon.

   ![C# icon](~/dataminer/images/GQI_code.png)

> [!NOTE]
> If certain types cannot be found in the file, verify if the *Skyline.DataMiner.Dev.Automation* NuGet package has the correct version. Go to *Tools* > *NuGet Package Manager* > *Manage NuGet Packages for Solution*. Select *Skyline.DataMiner.Dev.Automation*, and verify whether the version installed for the current project is at least *10.3.2*.

## Step 3: Provide the input arguments for the custom operator

This is the first step to implement the custom operator.

1. Add the *IGQIInputArguments* interface to the *DurationOperator* class.

   ```csharp
   public class DurationOperator : IGQIInputArguments
   ```

1. Implement the *GetInputArguments* method to provide GQI with the arguments that the user should fill in.

   ```csharp
   public GQIArgument[] GetInputArguments()
   {
      return new GQIArgument[] { _startColumnArg, _endColumnArg };
   }
   ```

1. Implement the *OnArgumentsProcessed* method to store the values that the user has filled in through the arguments.

   ```csharp
   public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
   {
      _startColumn =  args.GetArgumentValue(_startColumnArg);
      _endColumn = args.GetArgumentValue(_endColumnArg);
      return default;
   }
   ```

## Step 4: Create a new column to show the duration

1. Add the *IGQIColumnOperator* interface to the *DurationOperator* class.

   ```csharp
   public class DurationOperator : IGQIInputArguments, IGQIColumnOperator
   ```

1. Implement the *HandleColumns* method to let GQI know that a new column should be added.

   ```csharp
   public void HandleColumns(GQIEditableHeader header)
   {
      header.AddColumns(_durationColumn);
   }
   ```

## Step 5: Add the duration to the added column

1. Add the *IGQIRowOperator* interface to the *DurationOperator* class.

   ```csharp
   public class DurationOperator : IGQIInputArguments, IGQIColumnOperator, IGQIRowOperator
   ```

1. Implement the *HandleRow* method to calculate the duration and set that value in the cell matching the new duration column.

   ```csharp
   public void HandleRow(GQIEditableRow row)
   {
      var start = row.GetValue<DateTime>(_startColumn);
      var end = row.GetValue<DateTime>(_endColumn);
      var duration = end - start;
      row.SetValue(_durationColumn, duration);
   }
   ```

## Step 6: Use the data source

1. Open the *Dashboards* app and [create a new dashboard](xref:Creating_a_completely_new_dashboard).

1. In the *Data* pane on the right, go to *Queries* and click the "+" icon to create a query.

   ![+ icon to create query](~/dataminer/images/GQI_create_query.png)

1. Select a data source that has at least two columns containing datetime values.

   > [!NOTE]
   > If you do not have an applicable data source, you can [download one from the catalog](https://catalog.dataminer.services/details/package/5407).

1. Add a custom operator to the query and select *Duration*.

1. Fill in the input arguments matching with the necessary columns.

1. Drag the query to the dashboard.

1. [Select a table visualization](xref:Apply_Visualization) for the component.

The table should now also contain a *Duration* column containing the calculated duration.
