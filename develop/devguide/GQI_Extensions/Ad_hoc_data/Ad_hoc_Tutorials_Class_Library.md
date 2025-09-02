---
uid: Ad_hoc_Tutorials_Class_Library
---

# Building a GQI data source that retrieves data from a DMS using the Class Library

In this tutorial, you will learn how you can create a GQI data source that retrieves the version info of the agents your DMS.

Expected duration: 15 minutes.

> [!NOTE]
> This tutorial uses DataMiner version 10.5.4.

## Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/downloads/) with [DataMiner Integration Studio](xref:Installing_and_configuring_DataMiner_Integration_Studio)
- [GQI DxM](xref:GQI_DxM) installed and enabled.

## Overview

- [Step 1: Create the ad hoc data source](#step-1-create-the-ad-hoc-data-source)
- [Step 2: Fetch the agents in the DMS](#step-2-fetch-the-agents-in-the-dms)
- [Step 3: Transform DMS responses into a GQIPage](#step-3-transform-dms-response-into-a-gqipage)
- [Step 4: Configure the script to compile as library](#step-4-configure-the-script-to-compile-as-library)

## Step 1: Create the ad hoc data source

1. Create a new class that implements the [IGQIDatasource](xref:GQI_IGQIDataSource) interface.

   > [!NOTE]
   > If certain types cannot be found in the file, verify if the *Skyline.DataMiner.Dev.Automation* NuGet package has the correct version. Go to *Tools* > *NuGet Package Manager* > *Manage NuGet Packages for Solution*. Select *Skyline.DataMiner.Dev.Automation*, and verify whether the version installed for the current project is at least *10.5.4.2*.

1. Go to *Tools* > *NuGet Package Manager* > *Manage NuGet Packages for Solution*. 

   Select *Browse* and search for `Skyline.DataMiner.Core.DataMinerSystem.Common`, and install the latest version of the class library.

1. Implement the `GetColumns` method to define the columns of the data source.

   The data source will include two columns: a *Agent ID* column of type `Int` and a *Version* column of type `String`.

1. Implement the `GetNextPage` method to provide the actual data.

   For now, leave it empty, as you still need to retrieve the data from the DMS.

```csharp
[GQIMetaData(Name = "Agent Versions")]
public class AgentVersions : IGQIDataSource
{
    public GQIColumn[] GetColumns()
    {
        return new GQIColumn[]
        {
            new GQIIntColumn("Agent ID"),
            new GQIStringColumn("Version"),
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

## Step 2: Fetch the agents in the DMS

To retrieve the agent information, the data source will have to communicate with the DMS. You can use the [IDms](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDms) object for this. It is available by using the [OnInitInputArgs](xref:GQI_OnInitInputArgs) argument of the `OnInit` method, by implementing the [IGQIOnInit](xref:GQI_IGQIOnInit) interface.

1. Add the [IGQIOnInit](xref:GQI_IGQIOnInit) interface to the class.

1. Implement the `OnInit` method, which receives [OnInitInputArgs](xref:GQI_OnInitInputArgs) as parameters.

1. Store the [IDms](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDms) object as a field of the class for later use.

   ```csharp
   [GQIMetaData(Name = "Agent Versions")]
   public class AgentVersions : IGQIDataSource
   {
       private IDms _dms;

       public OnInitOutputArgs OnInit(OnInitInputArgs args)
       {
           _dms = args.DMS.GetConnection().GetDms();
           return default;
       }
   }
   ```

1. Use the [IDms](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDms) object to retrieve information from the DMS.

   Retrieve the agents by calling the [GetAgents](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDms.GetAgents) method. The response will be a collection of [IDma](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDma) objects.

   ```csharp
       public GQIPage GetNextPage(GetNextPageInputArgs args)
       {
           var agents = _dms.GetAgents();
           return default;
       }
   ```

## Step 3: Transform DMS response into a GQIPage

Transform the response into a [GQIPage](xref:GQI_GQIPage). Each [IDma](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDma) represents an agent in the cluser and will be converted into a row.

```csharp
    public GQIPage GetNextPage(GetNextPageInputArgs args)
    {
        var agents = _dms.GetAgents();
        var rows = new List<GQIRow>();
        foreach (var agent in agents)
        {
            rows.Add(new GQIRow(agent.Id.ToString(), new GQICell[]
            {
                new GQICell { Value = agent.Id },
                new GQICell { Value = agent.VersionInfo },
            }));
        }

        return new GQIPage(rows.ToArray());
    }
```

## Step 4: Configure the script to compile as library

In order for GQI to work, the script must be configured to compile as a library.

To do so:

- If you use DIS, add the following to the *Script.Exe* tag in the script XML:

  ```xml
     <Param type="preCompile">true</Param>
     <Param type="libraryName">Agent_Versions</Param>
  ```

    > [!NOTE]
    > Avoid placing '.' in the library name. As this makes the script un-editable in cube.

- If you do not use DIS, in the Automation module in Cube, select the *Compile as library* option. See [Compiling a C# code block as a library](xref:Compiling_a_CSharp_code_block_as_a_library).
