---
uid: Connector_help_Skyline_IP_Network_Discovery
---

# Skyline IP Network Discovery

This connector can be used to discover devices in one or more network IP ranges.

## About

With this connector, you can scan IP network ranges for devices. In the request, you specify the IP ranges together with a list of devices to detect. After a while, the connector will return a response with the IPs that answered to the various detection methods.

The connector includes:

- Multi-threaded detection
- Mapping of connector names against the method to identify the type uniquely
- Any communication method on IP that will be required to identify a device

Currently the following devices can be discovered:

- Generic Ping
- Generic SNMP
- Generic SSH
- Generic WMI
- AppearTV General Platform
- Harris Selenio Controller
- Leitch Matrix SNMP
- Envivio Spark
- Envivio 4Caster C4
- Envivio Halo
- Envivio 4Balancer
- HP Virtual Connect Flex-10
- Cisco Manager
- Cisco Nexus
- Huawei Manager
- ZTE ZXR10 8900
- Sencore MRD-3187x
- DEV1951
- Harmonic NSG 9000
- NetInsight Nimbra
- NetInsight Nimbra 230
- RGB Networks VMG2
- RGB Networks TransAct Packager
- Wellav Media Platform
- Wellav UMH 160
- Envivio Spark M-SMP3-100
- Envivio Spark M-DMP6-900
- Network Electronics Router MRP
- DEV 1996
- TAG Video Systems MCM-9000
- TAG Video Systems MBC-7000
- Ericsson RX8200
- Ericsson RX9500

### Version Info

| **Range** | **Description**  | **DCF Integration** | **Cassandra Compliant** |
|-----------|------------------|---------------------|-------------------------|
| 1.0.0.x   | Initial version  | No                  | Yes                     |
| 1.0.1.x   | Connector review | No                  | Yes                     |

## Configuration

### Connections

This connector uses a virtual connection. No special configuration is needed during element creation.

### Initialization

Before the discovery will work, some settings need to be configured in the element on the **Configuration** page.

First, you must add the correct credentials to the credentials list. Select a name and link it to a discovery type in the next step. For SNMP, only the password is used, so the username can be left blank.

In the discovery settings table, add a new row for each network and type that must be scanned. You can also add a global network that covers everything. The credential reference is the name of the credentials that were added in the previous step.

Prior to range 1.0.1.x, for the connector to function properly, SLLockManager.dll, SLIPNetworkDiscovery.dll, System.Web.Extensions.dll, and SLIPNetworkManager.dll must be located in the ProtocolScripts folder. These external DLLs are no longer required in range 1.0.1.x.

## Usage

In most cases, the elements created with this connector will be hidden. All requests must be started with remote sets on the element.

### Using SLIPNetworkDiscovery.dll

To make things easier, a DLL (SLIPNetworkDiscovery.dll) is available that handles the creation of requests and parses the response from the discovery process. To use the DLL, place it in the ProtocolScripts folder, and add a reference to it with the "dllImport" attribute on a QAction.

\<QAction id="1" name="Discovery" encoding="csharp" triggers="1" dllImport="SLIPNetworkDiscovery.dll"\>

Add the following "using" statement in the QAction:

using SLIPNetworkDiscovery;

Now you can create a new DiscoveryRequest object.

### Creating a discovery request

The code below can be used to start a discovery request. A list of **IP ranges** must be specified. They are processed in top-down manner. When you include a range, IP addresses will be added to the internal list; when you exclude a range, the IP addresses are removed from the internal list. The resulting set of IP addresses will be used to discover the devices. The **DMA and element ID** of the source element must also be specified. These will be used together with the *ResponsePid* to send back the result of the discovery. **DiscoveryTypes** must contain all the methods that must be used for the discovery.

DiscoveryRequest request = new DiscoveryRequest();
request.Source = new Source() { DmaId = protocol.DataMinerID, ElementId = protocol.ElementID };
request.ResponsePid = 50;
request.RequestId = requestKey;
request.DiscoveryTypes = new string\[\] { "PING", "SNMP", "WMI" };

List\<IPRange\> ipranges = new List\<IPRange\>();

foreach (var seed in GetSeeds(protocol).OrderBy(s =\> s.Order))
{
switch (seed.Type)
{
case 1: // network
ipranges.Add(new IPRange() { Type = IPRangeType.network, Network = seed.Network, Mask = seed.Mask });
break;
case 2: // single ip
ipranges.Add(new IPRange() { Type = IPRangeType.singleip , IP = seed.Network });
break;
case 3: // ip range
string\[\] range = seed.IPRange.Split('-');
ipranges.Add(new IPRange() { Type = IPRangeType.range, StartIP = range.First(), EndIP = range.Last() });
break;
}
}

request.IPRanges = ipranges.ToArray();

To send the request to the discovery element, use the code below. The DMA and element ID of the discovery element must be filled in.

SLIPNetworkDiscovery.SendRequest(protocol, 1, 2, request);

### Loading credentials and default global discovery settings

On the **Configuration** page, you can specify a CSV file to load a list of credentials and add default global discovery settings. The CSV file needs to contain 3 columns: Name, Username, and Password. If username is not applicable, use the value -1.
For example, SNMP Community strings: *snmp_slc;-1;envivio*

The default path is "C:\Skyline DataMiner\Documents\DMA_COMMON_DOCUMENTS\Skyline IP Network Discovery.csv".

### Canceling a Discovery Request

CancelRequest request = new CancelRequest();
request.Source = new Source() { DmaId = protocol.DataMinerID, ElementId = protocol.ElementID };

The source element and request ID must be specified.

SLIPNetworkDiscovery.SendRequest(protocol, 1, 2, request);

### Discovery Response

When the discovery element has completed the discovery process, it will send the result back by setting a parameter. That parameter ID is specified in the *ResponsePid* property of the request.

To capture the response, add a QAction that triggers on that parameter.

You can use the following function to parse the data into an object:

string data = Convert.ToString(protocol.GetParameter(10));
var response = SLIPNetworkDiscovery.SLIPNetworkDiscovery.ParseResponse(data);
