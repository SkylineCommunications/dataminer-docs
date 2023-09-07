---
uid: DSI_OpenConfig_Middleware
---
# OpenConfig Middleware

## Purpose

The purpose of the OpenConfig middleware is to make it possible to **easily consume data exposed over the gNMI service in a DataMiner connector**. It assists you in **setting up the connection with the endpoint**, provides **easy to use wrappers around the gRPC service calls**, and makes it possible to **map specific paths in the YANG model to DataMiner parameters** so the notifications the service sends out get automatically parsed and the parameters are populated with data.

## Prerequisites

In order to use the OpenConfig middleware, you will need to have the following setup:

- A DataMiner Agent that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud) and runs DataMiner 10.3.3 or higher.

- The [CommunicationGateway DxM](xref:DataMinerExtensionModules#communicationgateway) is installed on at least one of the DataMiner Agents in the cluster.

> [!NOTE]
> You can install the CommunicationGateway DxM with the Admin app. See [Deploying a DxM on a node](xref:Managing_cloud-connected_nodes#deploying-a-dxm-on-a-node). The DxM will be installed as a Windows service and will start automatically after installation.

## Usage

### Including the middleware package

Include the NuGet package *Skyline.DataMiner.DataSources.OpenConfig.Gnmi* in your project, as explained under [Consuming NuGet packages](xref:Consuming_NuGet).

When you are developing a connector, there is an optional package when you want to use the [DataMapper](#datamapper): *Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Protocol*

> [!NOTE]
> At present, these NuGet packages are not yet publicly available. They are currently only available for use during in-house connector development at Skyline Communications.

### Setting up the connection with the endpoint

#### Creating a GnmiClient

##### Identification

To set up a connection with the endpoint, you will need to create a [GnmiClient](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Api.GnmiClient) and pass along the `agentId` and `elementId` of the element running the connector. This will be used to identify you with the CommunicationGateway DxM.

A friendly name can be passed along in the `elementName`, which is used as context for logging purposes.

> [!NOTE]
> There are scenarios where you do not have an element (e.g. a DataMiner Automation script). It is fine to pass along a different context as well. This is meant to identify you and for logging purposes, so it is sufficient if the consumer knows what it represents. It does not have to be unique. The middleware will make it unique for you by appending a `GUID`.

##### Endpoint details

You also need to pass a [DataSourceConfiguration](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Models.DataSourceConfiguration) that specifies the details of the endpoint you want to connect with.

```csharp
var config = new DataSourceConfiguration();
config.IpAddress = "https://10.11.3.132";
config.Port = 10164;
```

> [!IMPORTANT]
> It is important to specify either `http://` or `https://`  in front of the address, as that will determine whether a secure channel is set up or not.

##### Authentication

On top of that, there are some additional **parameters for authentication**. There is support for credentials and client certificates. In case of a self-signed certificate, it is important that the root certificate of the path is part of the *Trusted Root Certification Authorities* certificate store in Windows.

To use a **client certificate**, configure the path where it can be found in [ClientCertificate](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Models.DataSourceConfiguration.ClientCertificate).

```csharp
config.ClientCertificate = @"C:\Certificates\client-auth-cert.pfx";
```

> [!IMPORTANT]
>
> - The client certificate must be in the PKCS#12 format and must have the *.pfx* extension.
> - The client certificate must be stored on the DataMiner Agent that has the CommunicationGateway DxM installed.

If instead you want to use **credentials** to authenticate, you can pass them along as well.

```csharp
config.UserName = "admin";
config.Password = Convert.ToString(protocol.GetParameter(Parameter.datasourcepassword));
```

> [!CAUTION]
> Never hard-code a password in a QAction, for security reasons. We recommend creating a parameter of type password in the DataMiner connector and retrieving the value through a `GetParameter` API call to pass it along.

##### Logging

To be able to **log** the information about what is being handled by the middleware, you will need to pass an [ILogger](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Utils.ILogger).

An example of an [ILogger](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Utils.ILogger) implementation for a DataMiner connector could be the following:

```csharp
namespace QAction_1.Loggers
{
    using Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Utils;
    using Skyline.DataMiner.Scripting;

    internal class DataMinerConnectorLogger : ILogger
    {
        private readonly SLProtocol _protocol;

        public DataMinerConnectorLogger(SLProtocol protocol)
        {
            _protocol = protocol;
        }

        public void LogFatal(string message)
        {
            _protocol.Log(message, LogType.Error, LogLevel.NoLogging);
        }

        public void LogError(string message)
        {
            _protocol.Log(message, LogType.Error, LogLevel.NoLogging);
        }

        public void LogWarning(string message)
        {
            _protocol.Log(message, LogType.Error, LogLevel.NoLogging);
        }

        public void LogInfo(string message)
        {
            _protocol.Log(message, LogType.Information, LogLevel.NoLogging);
        }

        public void LogDebug(string message)
        {
            _protocol.Log(message, LogType.DebugInfo, LogLevel.Level2);
        }

        public void LogTrace(string message)
        {
            _protocol.Log(message, LogType.DebugInfo, LogLevel.Level4);
        }
    }
}

```

#### Connecting with the gNMI service

By calling [Connect](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Api.GnmiClient.Connect), you make a connection with the endpoint.

```csharp
var client = new GnmiClient((uint)protocol.DataMinerID, (uint)protocol.ElementID, protocol.ElementName, config, logger);
client.Connect()
```

In case you want to get notified when the connection state changes, you can register on the [ConnectionStateChanged](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Api.GnmiClient.ConnectionStateChanged) event.

```csharp
client.ConnectionStateChanged += OnConnectionStateChanged

private void OnConnectionStateChanged(object sender, EventArgs e)
{
    protocol.Log($"Connection state changed to {client.IsConnected}");
}
```

> [!NOTE]
> In case you are setting up a secure channel, it is important that the server certificate is issued to the hostname configured in the [DataSourceConfiguration](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Models.DataSourceConfiguration). The whole certificate chain needs to be trusted and must not be expired. There is no option to disable this. When this is not the desired behavior, you will need to fall back to insecure HTTP.

### Disconnecting

To disconnect from the endpoint, you can call [Disconnect](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Api.GnmiClient.Disconnect). As GnmiClient implements [IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable), you can call [Dispose](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Api.GnmiClient.Dispose) on the client as well, which will call the [Disconnect](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Api.GnmiClient.Disconnect) for you.

To disconnect when the element has stopped, you can use the QAction's Dispose.

```csharp
public class QAction : IDisposable
{
   private bool disposed;
   private GnmiClient gnmiClient;

   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }

   protected virtual void Dispose(bool disposing)
   {
      if (disposing && !disposed)
      {
         disposed = true;
         gnmiClient?.Dispose();
         gnmiClient = null;
      }
   }
}
```

> [!NOTE]
> Making a QAction implement IDisposable is only supported in DataMiner version 10.2.9 and up.

> [!IMPORTANT]
> The Dispose() method on a QAction will only be called when the element is already considered stopped in DataMiner. The SLProtocol object should no longer be used at this point.

### Retrieving the capabilities

You can find more info on the `Capabilities` RPC in the [OpenConfig introduction](xref:DSI_OpenConfig_Introduction#capabilities).

```csharp
var capabilities = client.Capabilities();

protocol.Log($"The gNMI version is: {capabilities.GNMIVersion}");
foreach(var model in capabilities.SupportedModels)
{
    protocol.Log($"Model name is {model.Name}");
    protocol.Log($"Model organization is {model.Organization}");
    protocol.Log($"Model version is {model.Version}");
}
```

It is very useful to have this information available to know which models you can retrieve.

### Getting a value in the YANG path

You can find more info on the `Get` RPC in the [OpenConfig introduction](xref:DSI_OpenConfig_Introduction#get).

[Get](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Api.GnmiClient.Get%2A) allows you to retrieve values from one or more YANG paths.

```csharp
var responses = client.Get("system/memory/state/physical");
```

You can pass along the path either as a string or as a `GnmiPath` object. For example:

```csharp
var interfaceStatePath = new Gnmi.Path();
interfaceStatePath.Elem.Add(new Gnmi.PathElem { Name = "interfaces" });
interfaceStatePath.Elem.Add(new Gnmi.PathElem { Name = "interface" });
interfaceStatePath.Elem.Add(new Gnmi.PathElem { Name = "state" });
```

This would the equivalent of this:

```csharp
string interfaceStatePath = "interfaces/interface/state";
```

> [!IMPORTANT]
> The [gNMI specification](https://github.com/openconfig/reference/blob/master/rpc/gnmi/gnmi-specification.md#333-considerations-for-using-get) mentions that when retrieving larger datasets it is recommended to `Subscribe` to a path instead of doing a `Get`, to avoid putting a significant resource burden on the target.

### Setting a value in the YANG path

You can find more info on the `Set` RPC in the [OpenConfig introduction](xref:DSI_OpenConfig_Introduction#set).

```csharp
client.Set("system/config/login-banner", "Hello DataMiner!");
```

In OpenConfig, the read-write objects are commonly stored under the */config* path, while the readable counterpart with the current value is stored under the */state* path.

### Subscribing to a YANG path

You can find more info on the `Subscribe` RPC in the [OpenConfig introduction](xref:DSI_OpenConfig_Introduction#subscribe).

[Subscribe](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Api.GnmiClient.Subscribe%2A) allows you to create a subscription. It needs a unique name within the client to register itself in the CommunicationGateway DxM and one or more YANG paths that you are interested in.

```csharp
string subscriptionName = "interfaces";
uint sampleIntervalMs = 10000;

client.Subscribe(subscriptionName, sampleIntervalMs, new[] { "interfaces/interface/state" }, HandleIncomingResponse);

public void HandleIncomingResponse(IEnumerable<GnmiResponseValue> response)
{
    try
    {
        foreach (var value in response)
        {
            ProcessUpdate(value);
        }
    }
    catch (Exception ex)
    {
        Log($"Exception occurred: {ex}");
    }
}
```

This will create a *SAMPLE* subscription where a notification will be sent out by the data source every 10 seconds.

In case you want to do an *ON_CHANGE* subscription, you can leave out the `sampleIntervalMs` from the [Subscribe](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Api.GnmiClient.Subscribe%2A) call.

```csharp
string subscriptionName = "interfaces";

client.Subscribe(subscriptionName, new[] { "interfaces/interface/state" }, HandleIncomingResponse);
```

Now anytime a `leaf` changes, it will send out a notification with the new value.

> [!NOTE]
> There might be some limitations on the data source in terms of granularity. For example, a switch could send out changes on the counters only once every 5 seconds while they would change multiple times in that time frame.

### Accessing a specific instance

If you need to access a specific instance in a `container`, you can use [ ] to specify the instance. For example: `interfaces/interface[name='Ethernet1']/state`

Using this path will result in only reading or writing the *Ethernet1* instance of the *interfaces/interface/state* `container`.

### Troubleshooting

The errors that occur in the middleware will be logged by the `ILogger` object that gets passed along at construction of the [GnmiClient](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Api.GnmiClient).

In case of a DataMiner connector, that will be the logging of the element. There is an extensive list of [error codes](xref:CommunicationGateway_ErrorCodes) available to help you troubleshoot.

The logging of the CommunicationGateway DxM can be found under `C:\ProgramData\Skyline Communications\DataMiner CommunicationGateway\Logs`.

### DataMapper

The [DataMinerConnectorDataMapper](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Protocol.DataMapper.DataMinerConnectorDataMapper) is an object that sits between your device and the DataMiner connector. It will automatically parse the incoming notifications and populate DataMiner parameters or tables with the data.

#### Map a YANG path to a parameter

```csharp
IDataMapper dataMapper = new DataMinerConnectorDataMapper(
    protocol,
    new List<IDataMinerConnectorDataEntity>
    {
        new DataMinerConnectorParameter("system/memory/state/physical", Parameter.systemmemorystatephysical_400),
        new DataMinerConnectorParameter("system/memory/state/reserved", Parameter.systemmemorystatereserved_404)
    });
```

With the example above, the DataMapper will automatically parse the gNMI notifications that come in and check if these contain data for either the *system/memory/state/physical* or the *system/memory/state/reserved* YANG path. It will then automatically do the set on the configured parameters with the value that the gNMI notification contains. You need to pass the `SLProtocol` object to it so it can execute those sets.

It works perfectly for DataMiner tables as well, but the configuration is slightly different.

```csharp
IDataMapper dataMapper = new DataMinerConnectorDataMapper(
    protocol,
    new List<IDataMinerConnectorDataEntity>
    {
        new DataMinerConnectorDataGrid("interfaces/interface/state", Parameter.Interfacesstate.tablePid, new List<IDataMinerConnectorDataGridColumn>
        {
            new DataMinerConnectorDataGridColumn("openconfig-interfaces:type", Parameter.Interfacesstate.Pid.interfacesstatetype),
            new DataMinerConnectorDataGridColumn("openconfig-interfaces:mtu", Parameter.Interfacesstate.Pid.interfacesstatemtu),
            new DataMinerConnectorDataGridColumn("openconfig-interfaces:loopback-mode", Parameter.Interfacesstate.Pid.interfacesstateloopbackmode)
        }
    });
```

> [!IMPORTANT]
> When configuring the path for a column, always specify the YANG module name as well. Notifications of type `JSON` do not contain it but notifications of type `JSON_IETF` do. The DataMapper is capable of handling both, but for that reason the YANG module name needs to be known.

You need to create a [DataMinerConnectorDataGrid](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Protocol.DataMapper.DataMinerConnectorDataGrid) and pass it the root YANG path of the `container` that will be stored. Then it is a matter of mapping the column parameters to the YANG paths of the `leaf` items.

> [!NOTE]
> After you have created the [DataMinerConnectorDataMapper](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Protocol.DataMapper.DataMinerConnectorDataMapper), do not forget to configure the [GnmiClient](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Api.GnmiClient) to use it with the [SetDataMapper](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Api.GnmiClient.SetDataMapper%2A) method.

#### Configuring a default value

In case a gNMI notification does not contain a value for a configured `leaf`, it will remain `null`, which results in the cell remaining *Not Initialized*. However, there is the possibility to configure a default value to be used instead of `null`.

This can be configured in the following way:

```csharp
string defaultValue = "Not Available";

IDataMapper dataMapper = new DataMinerConnectorDataMapper(
    protocol,
    new List<IDataMinerConnectorDataEntity>
    {
        new DataMinerConnectorDataGrid("interfaces/interface/state", Parameter.Interfacesstate.tablePid, new List<IDataMinerConnectorDataGridColumn>
        {
            new DataMinerConnectorDataGridColumn("openconfig-interfaces:type", Parameter.Interfacesstate.Pid.interfacesstatetype, defaultValue),
            new DataMinerConnectorDataGridColumn("openconfig-interfaces:mtu", Parameter.Interfacesstate.Pid.interfacesstatemtu, defaultValue),
            new DataMinerConnectorDataGridColumn("openconfig-interfaces:loopback-mode", Parameter.Interfacesstate.Pid.interfacesstateloopbackmode, defaultValue)
        }
    });
```

#### Converting the value before doing the set

Sometimes the data in the notification needs to be converted before it is set. A possible example might be a timestamp that comes in as *UNIX time* and needs to be converted to *OLE automation time*.

You can achieve this by setting the [OnRawValueChange](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Protocol.DataMapper.DataMinerConnectorDataGridColumn.OnRawValueChange) property of a [DataMinerConnectorDataGridColumn](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Protocol.DataMapper.DataMinerConnectorDataGridColumn).

```csharp
new DataMinerConnectorDataGrid("interfaces/interface/state", Parameter.Interfacesstate.tablePid, new List<IDataMinerConnectorDataGridColumn>
{
    new DataMinerConnectorDataGridColumn("openconfig-interfaces:last-change", Parameter.Interfacesstate.Pid.interfacesstatelastchange) { OnRawValueChange = ConvertEpochTimeUtcTicksToOleAutomationTime }
};

public static object ConvertEpochTimeUtcTicksToOleAutomationTime(DataMinerConnectorRawValueArgs rawValue)
{
    if (rawValue != null && rawValue.Value is ulong ticks)
    {
        double secondsSinceEpoch;

        if (ticks > 946684800000000000)
        {
            secondsSinceEpoch = ticks / 1000000000d;
        }
        else
        {
            secondsSinceEpoch = ticks / 100d;
        }
    
        double convertedDate = Epoch.AddSeconds(secondsSinceEpoch).ToOADate();
        return convertedDate;
    }
    return "Not Available";
}
```

#### Displaying octets as rates

In case you are retrieving octets, it can be desirable to display those as rates. The [RateCalculator](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Protocol.DataMapper.DataMinerConnectorDataGridColumn.RateCalculator) property on a [DataMinerConnectorDataGridColumn](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Protocol.DataMapper.DataMinerConnectorDataGridColumn) can be used for this.

```csharp
new DataMinerConnectorDataGrid("interfaces/interface/state", Parameter.Interfacesstate.tablePid, new List<IDataMinerConnectorDataGridColumn>
{
    new DataMinerConnectorDataGridColumn("openconfig-interfaces:counters/in-octets", Parameter.Interfacesstate.Pid.interfacesstateinoctets) { RateCalculator = CustomRates, RateColumnParameterId = Parameter.Interfacesstate.Pid.interfacesstateinbitrate },
    new DataMinerConnectorDataGridColumn(Parameter.Interfacesstate.Pid.interfacesstateinbitrate, notAvailable
};

public static object CustomRates(DataMinerConnectorRateArgs rateValues)
{
    if (rateValues == null)
    {
        return NotAvailable;
    }

    if (rateValues.CurrentTimestampUtc <= rateValues.PreviousTimestampUtc || !UInt64.TryParse(Convert.ToString(rateValues.CurrentValue), out ulong uiNewValue) || !UInt64.TryParse(Convert.ToString(rateValues.PreviousValue), out ulong uiOldValue) || uiOldValue > uiNewValue)
    {
        return -1;
    }

    TimeSpan ts = rateValues.CurrentTimestampUtc - rateValues.PreviousTimestampUtc;
    double rate = 8.0 * Convert.ToDouble(uiNewValue - uiOldValue) / ts.TotalSeconds;
    return rate;
}
```

The `CustomRates` method will take care of the rate calculation and will set the calculated value in the parameter that is configured in the [RateColumnParameterId](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Protocol.DataMapper.DataMinerConnectorDataGridColumn.RateColumnParameterId) property.

> [!TIP]
> In this scenario, you will typically want to map the `RateColumnParameterId` to a default value so it gets populated when there is insufficient information to calculate the rate.

#### Trigger an action when another column changes

There might be scenarios where you want to execute a specific action when a certain column changed. An example of this is to regenerate the display key when the interface description changes.

```csharp
new DataMinerConnectorDataGrid("interfaces/interface/state", Parameter.Interfacesstate.tablePid, new List<IDataMinerConnectorDataGridColumn>
{
    new DataMinerConnectorDataGridColumn(Parameter.Interfacesstate.Pid.interfacesstatedisplaykey) { OnTriggerValueChange = ValueConverter.CreateDisplayKey, TriggerColumnParameterIds = new List<int> { Parameter.Interfacesstate.Pid.interfacesstatedescription } }
};

public static object CreateDisplayKey(DataMinerConnectorTriggerValueArgs triggerValues)
{
    string description;
    if (triggerValues.Values.TryGetValue(Parameter.Interfacesstate.Pid.interfacesstatedescription, out object descriptionVal))
    {
        description = Convert.ToString(descriptionVal);
    }
    else
    {
        description = String.Empty;
    }

    if (String.IsNullOrEmpty(description) || description == "-1")
    {
        return pk;
    }

    return $"{pk}/{description}";
}

```
