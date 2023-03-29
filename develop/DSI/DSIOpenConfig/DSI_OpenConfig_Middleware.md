---
uid: DSI_OpenConfig_Middleware
---
# OpenConfig Middleware

## Purpose

The purpose of the OpenConfig middleware is to make it possible to **easily consume data exposed over the gNMI service in a DataMiner connector**. It assists you in **setting up the connection with the endpoint**, provides **easy to use wrappers around the gRPC service calls** and makes it possible to **map specific paths in the YANG model to DataMiner parameters** so the notifications the service is sending out get automatically parsed and the parameters populated with data.

## Prerequisites

In order to use the OpenConfig middleware, you will need to have the following setup:

* A **cloud-connected** DataMiner agent running version 10.3.3 or higher to facilitate the required message broker.
* The [CommunicationGateway DxM](xref:DataMinerExtensionModules#CommunicationGateway) installed on at least one of the DataMiner agents in the cluster.
* The NuGet *Skyline.DataMiner.Core.OpenConfig.Gnmi* included in your project. See [Consuming NuGet packages](xref:Consuming_NuGet) for more information.

> [!TIP]
> You can easily install the CommunicationGateway DxM through the [Admin Cloud Portal](https://admin.dataminer.services).

## Usage

### Setting up connection with the endpoint

#### Creating a GnmiClient

To set up a connection with the endpoint, you will need to create a [GnmiClient](xref:Skyline.DataMiner.Helper.OpenConfig.Api.GnmiClient) and pass along the `dataMinerId` and `elementId` of the element running the connector. This will be used to identify yourself with the CommunicationGateway DxM.

A friendly name can be passed along in the `elementName` which is used as context for logging purposes.

> [!TIP]
> There are scenarios in which you do not have an element (*e.g. a DataMiner automation script*). It is fine to pass along different context as well. It is meant to identify yourself and for logging purposes so it is sufficient if the consumer knows what it represents. It doesn't have to be unique, the middleware will make it unique for you by appending a `GUID`.

You also need to pass a [DataSourceConfiguration](xref:Skyline.DataMiner.Helper.OpenConfig.Models.DataSourceConfiguration) which specifies the details of the endpoint you want to connect with.

```csharp
var config = new DataSourceConfiguration();
config.IpAddress = "https://10.11.3.132";
config.Port = 10164;
```

> [!IMPORTANT]
> It is important to specify either `http://` or `https://`  in front of the address as that will decide whether to setup a secure channel or not.

On top of that there are some additional parameters for authentication. There is support for credentials and client certificates. In case of a self-signed certificate, it's important that the root certificate of the path is part of the *Trusted Root Certification Authorities* certificate store in Windows.

To use a client certificate, configure the path of where it can be found in [ClientCertificate](xref:Skyline.DataMiner.Helper.OpenConfig.Models.DataSourceConfiguration.ClientCertificate). Do note that the client certificate should be stored on the DataMiner agent that has the CommunicationGateway DxM installed.

```csharp
config.ClientCertificate = @"C:\Certificates\client-auth-cert.pfx";
```

> [!IMPORTANT]
> The client certificate should be in the PKCS#12 format and have the *.pfx* extension.

If instead you want to use credentials to authenticate you can pass them along as well.

```csharp
config.UserName = "admin";
config.Password = Convert.ToString(protocol.GetParameter(Parameter.datasourcepassword));
```

> [!CAUTION]
> Never hardcode a password in a QAction for security reasons. It is advised to create a parameter of type password in your DataMiner connector and retrieve the value through a `GetParameter` API call to pass it along.

To be able to log the information about what is being handled by the middleware, you will need to pass an [ILogger](xref:Skyline.DataMiner.Helper.OpenConfig.Utils.ILogger).

An example of an [ILogger](xref:Skyline.DataMiner.Helper.OpenConfig.Utils.ILogger) implementation for a DataMiner connector could be the following:

```csharp
namespace QAction_1.Loggers
{
    using Skyline.DataMiner.Helper.OpenConfig.Utils;
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

By calling [Connect](xref:Skyline.DataMiner.Helper.OpenConfig.Api.GnmiClient.Connect) you make connection with the endpoint.

```csharp
var client = new GnmiClient((uint)protocol.DataMinerID, (uint)protocol.ElementID, protocol.ElementName, config, logger);
client.Connect()
```

In case you want to get notified when the connection state changes, you can can register on the [ConnectionStateChanged](xref:Skyline.DataMiner.Helper.OpenConfig.Api.GnmiClient.ConnectionStateChanged) event.

```csharp
client.ConnectionStateChanged += OnConnectionStateChanged

private void OnConnectionStateChanged(object sender, EventArgs e)
{
    protocol.Log($"Connection state changed to {client.IsConnected}");
}
```

> [!NOTE]
> In case you are setting up a secure channel, it is important that the server certificate is issued to the hostname which is configured in the [DataSourceConfiguration](xref:Skyline.DataMiner.Helper.OpenConfig.Models.DataSourceConfiguration). The whole certificate chain needs to be trusted and not be expired. There is no option to disable this. When this is not the desired behavior, you will need to fall back to insecure HTTP.

### Disconnecting

To disconnect from the endpoint, you can call [Disconnect](xref:Skyline.DataMiner.Helper.OpenConfig.Api.GnmiClient.Disconnect). As GnmiClient implements [IDisposable](xref:System.IDisposable) you can call [Dispose](xref:Skyline.DataMiner.Helper.OpenConfig.Api.GnmiClient.Dispose) on the client as well which will call the [Disconnect](xref:Skyline.DataMiner.Helper.OpenConfig.Api.GnmiClient.Disconnect) for you.

Furthermore, to disconnect when the element has stopped, you can use the QAction's Dispose. 

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
> The Dispose() function on a QAction will only be called when the element is already considered stopped in DataMiner. The SLProtocol object should no longer be used at this point.

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

[Get](xref:Skyline.DataMiner.Helper.OpenConfig.Api.GnmiClient.Get) allows you to retrieve values from one or more YANG paths.

```csharp
var responses = client.Get("system/memory/state/physical");
```

You can either pass along the path as a string or as a `GnmiPath` object. Here's an example of how you can do this:

```csharp
var interfaceStatePath = new Gnmi.Path();
interfaceStatePath.Elem.Add(new Gnmi.PathElem { Name = "interfaces" });
interfaceStatePath.Elem.Add(new Gnmi.PathElem { Name = "interface" });
interfaceStatePath.Elem.Add(new Gnmi.PathElem { Name = "state" });
```

This would the equivalent of

```csharp
string interfaceStatePath = "interfaces/interface/state";
```

> [!IMPORTANT]
> The [gNMI specification](https://github.com/openconfig/reference/blob/master/rpc/gnmi/gnmi-specification.md#333-considerations-for-using-get) mentions that in case of retrieving larger datasets it's recommended to `Subscribe` on a path instead of doing a `Get` to avoid putting a significant resource burden on the target.

### Setting a value in the YANG path

You can find more info on the `Set` RPC in the [OpenConfig introduction](xref:DSI_OpenConfig_Introduction#set).

```csharp
client.Set("system/config/login-banner", "Hello DataMiner!");
```

It is a common practice that the read-write objects are stored under the */config* path, while the readable counterpart with the current value is stored under the */state* path.

### Subscribing to a YANG path

You can find more info on the `Subscribe` RPC in the [OpenConfig introduction](xref:DSI_OpenConfig_Introduction#subscribe).

[Subscribe](xref:Skyline.DataMiner.Helper.OpenConfig.Api.GnmiClient.Subscribe) allows you to create a subscription. It needs a unique name within the client to register itself in the CommunicationGateway DxM and one or more YANG paths that you are interested in. 

```csharp
string subscriptionName = "interfaces";
uint sampleIntervalMs = 10000;

client.Subscribe("interfaces", sampleIntervalMs, new[] { "interfaces/interface/state" }, HandleIncomingResponse);

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

In case you want to do an *ON_CHANGE* subscription, you can leave out the `sampleIntervalMs` from the [Subscribe](xref:Skyline.DataMiner.Helper.OpenConfig.Api.GnmiClient.Subscribe) call.

```csharp
string subscriptionName = "interfaces";

client.Subscribe("interfaces", new[] { "interfaces/interface/state" }, HandleIncomingResponse);
```

Now anytime a `leaf` changes, it will send out a notification with the new value.

> [!NOTE]
> There might be some limitations on the data source in terms of granularity. For example a switch could send out changes on the counters only once every 5 seconds while they would change multiple times in that time frame.

### Accessing a specific instance

If you need to access a specific instance in a `container`, you can use [ ] to specify the instance.
e.g: interfaces/interface[name:Ethernet1]/state

Using this path will result in only reading or writing the *Ethernet1* instance of the *interfaces/interface/state* `container`.

### Troubleshooting

The errors that occur in the middleware will be logged by the `ILogger` object that gets passed along at construction of the [GnmiClient](xref:Skyline.DataMiner.Helper.OpenConfig.Api.GnmiClient). In case of a DataMiner connector, that will be the logging of the element. There's an extensive list of [error codes](xref:CommunicationGateway_ErrorCodes) available to help you troubleshoot.

### DataMapper

The [DataMinerConnectorDataMapper](xref:Skyline.DataMiner.Helper.OpenConfig.DataMapper.DataMinerConnectorDataMapper) is an object that sits between your device and the DataMiner connector. It will automatically parse the incoming notifications and populate DataMiner parameters or tables with the data.

#### Map a YANG path to a parameter

```csharp
IDataMapper dataMapper = new DataMinerConnectorDataMapper(
    protocol,
    new List<IDataEntity>
    {
        new DataMinerConnectorParameter("system/memory/state/physical", Parameter.systemmemorystatephysical_400),
        new DataMinerConnectorParameter("system/memory/state/reserved", Parameter.systemmemorystatereserved_404)
    });
```

Having this configured as soon as a gNMI notification will come in with data for either the *system/memory/state/physical* or the *system/memory/state/reserved* YANG path, it will automatically do the set on the configured parameters. You need to pass it the `SLProtocol` object so it can execute those sets.

It works perfectly for DataMiner tables as well, but the configuration is slightly different.

```csharp
IDataMapper dataMapper = new DataMinerConnectorDataMapper(
    protocol,
    new List<IDataEntity>
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
> When configuring the path for a column, always specify the YANG module name as well. Notifications of type `JSON` do not contain them but notifications of type `JSON_IETF` do. The DataMapper is capable of handling both but for that reason the YANG module name needs to be known.

You need to create a [DataMinerConnectorDataGrid](xref:Skyline.DataMiner.Helper.OpenConfig.DataMapper.DataMinerConnectorDataGrid) and pass it the root YANG path of the `container` that will be stored. Then it is a matter of mapping the column parameters to the YANG paths of the `leaf` items.

> [!NOTE]
> After having created the [DataMinerConnectorDataMapper](xref:Skyline.DataMiner.Helper.OpenConfig.DataMapper.DataMinerConnectorDataMapper), do not forget to configure the [GnmiClient](xref:Skyline.DataMiner.Helper.OpenConfig.Api.GnmiClient) to use it by assigning it to the [DataMapper](xref:Skyline.DataMiner.Helper.OpenConfig.Api.GnmiClient.DataMapper) property.

#### Configuring a default value

In case a gNMI notification does not contain a value for a configured `leaf` it will remain `null` which results in the cell remaining *Not Initialized*. However, there is the possibility to configure a default value to be used instead of `null`.

This can be configured in the following way:

```csharp
string defaultValue = "Not Available";

IDataMapper dataMapper = new DataMinerConnectorDataMapper(
    protocol,
    new List<IDataEntity>
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

Sometimes the data in the notification needs to be converted before being set. A possible example might be a timestamp that comes in as *UNIX time* and needs to be converted to *OLE automation time*.

This can be achieved by setting the [OnRawValueChange](xref:Skyline.DataMiner.Helper.OpenConfig.DataMapper.DataMinerConnectorDataGridColumn.OnRawValueChange) property of a [DataMinerConnectorDataGridColumn](xref:Skyline.DataMiner.Helper.OpenConfig.DataMapper.DataMinerConnectorDataGridColumn).

```csharp
new DataMinerConnectorDataGrid("interfaces/interface/state", Parameter.Interfacesstate.tablePid, new List<IDataMinerConnectorDataGridColumn>
{
    new DataMinerConnectorDataGridColumn("openconfig-interfaces:last-change", Parameter.Interfacesstate.Pid.interfacesstatelastchange) { OnRawValueChange = ConvertEpochTimeUtcTicksToOleAutomationTime }
};

public static object ConvertEpochTimeUtcTicksToOleAutomationTime(SLProtocol protocol, DataValueOriginType origin, string pk, object value, DateTime timestamp)
{
    if (value is ulong ticks)
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

In case you are retrieving octets, it can be desirable to display those as rates. The [RateCalculator](xref:Skyline.DataMiner.Helper.OpenConfig.DataMapper.DataMinerConnectorDataGridColumn.RateCalculator) property on a [DataMinerConnectorDataGridColumn](xref:Skyline.DataMiner.Helper.OpenConfig.DataMapper.DataMinerConnectorDataGridColumn) makes that very easy to do.

```csharp
new DataMinerConnectorDataGrid("interfaces/interface/state", Parameter.Interfacesstate.tablePid, new List<IDataMinerConnectorDataGridColumn>
{
    new DataMinerConnectorDataGridColumn("openconfig-interfaces:counters/in-octets", Parameter.Interfacesstate.Pid.interfacesstateinoctets) { RateCalculator = CustomRates, RateColumnParameterId = Parameter.Interfacesstate.Pid.interfacesstateinbitrate },
    new DataMinerConnectorDataGridColumn(Parameter.Interfacesstate.Pid.interfacesstateinbitrate, notAvailable
};

public static object CustomRates(SLProtocol protocol, DataValueOriginType origin, string pk, object newValue, DateTime newTime, object oldValue, DateTime oldTime)
{
    if (newTime <= oldTime || !UInt64.TryParse(Convert.ToString(newValue), out ulong uiNewValue) || !UInt64.TryParse(Convert.ToString(oldValue), out ulong uiOldValue))
    {
        return -1;
    }

    TimeSpan ts = newTime - oldTime;
    double rate = 8.0 * Convert.ToDouble(uiNewValue - uiOldValue) / ts.TotalSeconds;
    return rate;
}
```

The `CustomRates` method will take care of the rate calculation and will set the calculated value in the parameter which is configured in the [RateColumnParameterId](xref:Skyline.DataMiner.Helper.OpenConfig.DataMapper.DataMinerConnectorDataGridColumn.RateColumnParameterId) property.

> [!TIP]
> In this scenario, you will typically want to map the `RateColumnParameterId` to a default value so it gets populated when there is insufficient information to calculate the rate.

#### Trigger an action when another column changes

There might be scenarios where you want to execute a specific action when a certain column changed. An example of this is to regenerate the display key when the interface description changes.

```csharp
new DataMinerConnectorDataGrid("interfaces/interface/state", Parameter.Interfacesstate.tablePid, new List<IDataMinerConnectorDataGridColumn>
{
    new DataMinerConnectorDataGridColumn(Parameter.Interfacesstate.Pid.interfacesstatedisplaykey) { OnTriggerValueChange = ValueConverter.CreateDisplayKey, TriggerColumnParameterIds = new List<int> { Parameter.Interfacesstate.Pid.interfacesstatedescription } }
};

public static object CreateDisplayKey(SLProtocol protocol, DataValueOriginType origin, string pk, Dictionary<int, object> values, DateTime timestamp)
{
    string description;
    if (values.TryGetValue(Parameter.Interfacesstate.Pid.interfacesstatedescription, out object descriptionVal))
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
