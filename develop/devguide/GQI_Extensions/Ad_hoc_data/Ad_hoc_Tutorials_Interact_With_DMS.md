---
uid: Ad_hoc_Tutorials_Interact_With_DMS
---

# Building a GQI data source that retrieves data from a DMS

In this tutorial, you will learn how you can create a GQI data source that retrieves the version info of the Agents in your DMS.

Expected duration: 15 minutes.

## Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/downloads/) with [DataMiner Integration Studio](xref:Installing_and_configuring_DataMiner_Integration_Studio)
- DataMiner 10.3.4 or higher

## Overview

- [Step 1: Create the ad hoc data source](#step-1-create-the-ad-hoc-data-source)
- [Step 2: Fetch the Agents in the DMS](#step-2-fetch-the-agents-in-the-dms)
- [Step 3: Transform the DMS responses into a GQIPage](#step-3-transform-the-dms-response-into-a-gqipage)
- [Step 4: Configure the script to compile as a library](#step-4-configure-the-script-to-compile-as-a-library)

## Step 1: Create the ad hoc data source

1. Create a new class that implements the [IGQIDatasource](xref:GQI_IGQIDataSource) interface.

   > [!NOTE]
   > If certain types cannot be found in the file, verify if the *Skyline.DataMiner.Dev.Automation* NuGet package has the correct version. Go to *Tools* > *NuGet Package Manager* > *Manage NuGet Packages for Solution*. Select *Skyline.DataMiner.Dev.Automation*, and verify whether the version installed for the current project is at least *10.3.4*.

1. Implement the `GetColumns` method to define the columns of the data source.

   The data source will include two columns: an *Agent ID* column of type `Int` and a *Version* column of type `String`.

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

## Step 2: Fetch the Agents in the DMS

To retrieve the Agent information, the data source will have to communicate with the DMS. The information can be retrieved using the [OnInitInputArgs](xref:GQI_OnInitInputArgs) argument of the `OnInit` method, by implementing the [IGQIOnInit](xref:GQI_IGQIOnInit) interface. Depending on the DataMiner version used, a different approach will be needed.

### [With DataMiner 10.5.0 [CU1]/10.5.4 or higher with GQI DxM](#tab/step-2-class-library)

1. Go to *Tools* > *NuGet Package Manager* > *Manage NuGet Packages for Solution*.

1. Select *Browse* and search for `Skyline.DataMiner.Core.DataMinerSystem.Common`, and install the latest version of the class library.

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

   Retrieve the Agents by calling the [GetAgents](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDms.GetAgents) method. The response will be a collection of [IDma](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDma) objects.

   ```csharp
   public GQIPage GetNextPage(GetNextPageInputArgs args)
   {
       var agents = _dms.GetAgents();
       return default;
   }
   ```

### [With older DataMiner versions](#tab/step-2-gqidms)

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
        // Retrieve the agents in the system.
        var agentsInfoRequest = new GetInfoMessage(InfoType.DataMinerInfo);
        var agentsInfo = _dms.SendMessages(agentsInfoRequest).OfType<GetDataMinerInfoResponseMessage>();

        // Retrieve the build information for each agent.
        var agentsBuildInfoRequests = agentsInfo.Select(agentInfo => new GetAgentBuildInfo(agentInfo.ID));
        var agentsBuildInfo = _dms.SendMessages(agentsBuildInfoRequests.ToArray()).OfType<BuildInfoResponse>();
        return default;
   }
   ```

> [!IMPORTANT]
> DMS messages are subject to change without notice. If you can implement an alternative using the [built-in data sources](xref:Query_data_sources), we highly recommend that you do so instead.

***

## Step 3: Transform the DMS response into a GQIPage

Transform the response into a [GQIPage](xref:GQI_GQIPage). Each Agent in the cluster will be converted into a row. Again, a different approach will be needed depending on the DataMiner version used.

### [With DataMiner 10.5.0 [CU1]/10.5.4 or higher with GQI DxM](#tab/step-3-class-library)

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

### [With older DataMiner versions](#tab/step-3-gqidms)

```csharp
public GQIPage GetNextPage(GetNextPageInputArgs args)
{
    // Retrieve the agents in the system.
    var agentsInfoRequest = new GetInfoMessage(InfoType.DataMinerInfo);
    var agentsInfo = _dms.SendMessages(agentsInfoRequest).OfType<GetDataMinerInfoResponseMessage>();

    // Retrieve the build information for each agent.
    var agentsBuildInfoRequests = agentsInfo.Select(agentInfo => new GetAgentBuildInfo(agentInfo.ID));
    var agentsBuildInfo = _dms.SendMessages(agentsBuildInfoRequests.ToArray()).OfType<BuildInfoResponse>();

    var rows = new List<GQIRow>();
    foreach(var buildInfo in agentsBuildInfo)
    {
        rows.Add(new GQIRow(buildInfo.Agents[0].DataMinerID.ToString(), new GQICell[]
        {
            new GQICell { Value = buildInfo.Agents[0].DataMinerID },
            new GQICell { Value = buildInfo.Agents[0].RawVersion },
        }));
    }

    return new GQIPage(rows.ToArray());
}
```

***

## Step 4: Configure the script to compile as a library

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
