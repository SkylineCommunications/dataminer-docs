---
uid: ClassLibraryElementCreation
---

# Element creation

## Introduction

This section provides more information on how to create elements using the class library.

To create an element, use the [CreateElement](xref:Skyline.DataMiner.Library.Common.IDma.CreateElement(Skyline.DataMiner.Library.Common.ElementConfiguration)) method of the [IDma](xref:Skyline.DataMiner.Library.Common.IDma) interface.
This method takes an [ElementConfiguration](xref:Skyline.DataMiner.Library.Common.ElementConfiguration) object as parameter, where you can configure the  element settings for the element.

The ElementConfiguration constructors require the element name and the protocol to be specified.
Other configuration settings can be specified via the properties of the ElementConfiguration object:

- [AdvancedSettings](xref:Skyline.DataMiner.Library.Common.ElementConfiguration.AdvancedSettings): Allows configuring advanced element settings such as the timeout, whether the element is hidden, etc.
- [AlarmTemplate](xref:Skyline.DataMiner.Library.Common.ElementConfiguration.AlarmTemplate): Allows specifying an alarm template to be used.
- [Connections](xref:Skyline.DataMiner.Library.Common.ElementConfiguration.Connections): Allows specifying the connections, if any. See <xref:ClassLibraryElementCreation#creating-an-element-with-connections>.
- [Description](xref:Skyline.DataMiner.Library.Common.ElementConfiguration.Description): Allows providing a description for the element.
- [DveSettings](xref:Skyline.DataMiner.Library.Common.ElementConfiguration.DveSettings): Allows configuring DVE-related settings such as whether DVE creation is enabled or disabled.
- [Properties](xref:Skyline.DataMiner.Library.Common.ElementConfiguration.Properties): Allows configuring element properties. See <xref:ClassLibraryElementCreation#creating-an-element-with-properties>.
- [State](xref:Skyline.DataMiner.Library.Common.ElementConfiguration.State): Allows configuring the state. Must be either Active, Paused or Stopped.
- [TrendTemplate](xref:Skyline.DataMiner.Library.Common.ElementConfiguration.TrendTemplate): Allows specifying an alarm template to be used.
- [Type](xref:Skyline.DataMiner.Library.Common.ElementConfiguration.Type): Allows specifying the type.
- [Views](xref:Skyline.DataMiner.Library.Common.ElementConfiguration.Views): Allows specifying the views the created element should be part of. See <xref:ClassLibraryElementCreation#creating-an-element-in-specific-views>.

## Creating an element with properties

The following example illustrates how to create an element with some element properties:

```csharp
IDms dms = protocol.GetDms();
var agent = dms.GetAgent(1000);

IDmsProtocol elementProtocol = dms.GetProtocol("<ProtocolName>", "1.0.0.1");
string elementName = "<ElementName>";

ElementConfiguration configuration = new ElementConfiguration(dms, elementName, elementProtocol);
configuration.Properties["Manufacturer"].Value = "<manufacturerValue>";
configuration.Properties["Model"].Value = "<modelValue>";

DmsElementId id = agent.CreateElement(configuration);
```

## Creating an element in specific views

The following example illustrates how to create an element that should be included in the specified views:

```csharp
IDms dms = protocol.GetDms();
var agent = dms.GetAgent(1000);

IDmsProtocol elementProtocol = dms.GetProtocol("<ProtocolName>", "1.0.0.1");
string elementName = "<ElementName>";

ElementConfiguration configuration = new ElementConfiguration(dms, elementName, elementProtocol);

configuration.Views.Add(dms.GetView(7));
configuration.Views.Add(dms.GetView(9));

DmsElementId id = agent.CreateElement(configuration);
```

## Creating an element with connections

In version 1.2.0.5 of the class library, support has been added for HTTP connections of elements (virtual and SNMP connections were already supported in previous versions). The following diagram gives an overview of the provided interfaces:

![alt text](../../images/classlibrary1205_1.png "Connections class diagram")

### Creating an SNMPv1 element

```csharp
IDms dms = protocol.GetDms();
IDma agent = dms.GetAgent(1000); // Obtain Agent where the element should be created.
IDmsProtocol protocol = dms.GetProtocol("<ProtocolName>", "1.0.0.1"); // Specify the protocol the element will run.

IUdp port = new Udp("127.0.0.1", 161); // Configure the SNMP connection.

ISnmpV1Connection mySnmpV1Connection = new SnmpV1Connection(port);

ElementConfiguration configuration = new ElementConfiguration(dms, "<ElementName>", protocol, new List<IElementConnection> { mySnmpV1Connection });

DmsElementId id = agent.CreateElement(configuration);
```

### Creating an SNMPv2c element

```csharp
IDms dms = protocol.GetDms();
IDma agent = dms.GetAgent(1000); // Obtain Agent where the element should be created.
IDmsProtocol protocol = dms.GetProtocol("<ProtocolName>", "1.0.0.1"); // Specify the protocol
IUdp port = new Udp("127.0.0.1", 161);

ISnmpV2Connection mySnmpV2Connection = new SnmpV2Connection(port);

ElementConfiguration configuration = new ElementConfiguration(dms, "<ElementName>", protocol, new List<IElementConnection> { mySnmpV2Connection });

DmsElementId id = agent.CreateElement(configuration);
```

### Creating an SNMPv3 element

```csharp
IDms dms = protocol.GetDms();
IDma agent = dms.GetAgent(1000); // Obtain Agent where the element should be created.
IDmsProtocol protocol = dms.GetProtocol("<ProtocolName>", "1.0.0.1");
IUdp port = new Udp("127.0.0.1", 161);

SnmpV3SecurityConfig secConfig = new SnmpV3SecurityConfig("myUserName", "myAuthKey", SnmpV3AuthenticationAlgorithm.Md5, "myEncryptionKey", SnmpV3EncryptionAlgorithm.Aes128);
ISnmpV3Connection mySnmpV3Connection = new SnmpV3Connection(port, secConfig);

ElementConfiguration configuration = new ElementConfiguration(dms, randomizedElementName, protocol, new List<IElementConnection> { mySnmpV3Connection });

DmsElementId id = agent.CreateElement(configuration);
```

### Creating an HTTP element

The following example illustrates how to create an element with an HTTP connection:

```csharp
private static void CreateElement(SLProtocol protocol)
{
    IDms dms = protocol.GetDms();
    IDma agent = dms.GetAgent(protocol.DataMinerID);
    
    IDmsProtocol elementProtocol = dms.GetProtocol("<ProtocolName>", "1.0.0.1");
    
    ITcp port = new Tcp("127.0.0.1", 8888);
    IHttpConnection myHttpConnection = new HttpConnection(port);
    
    var configuration = new ElementConfiguration(
        dms,
        "<ElementName>",
        elementProtocol,
        new List<IElementConnection> { myHttpConnection });
    
    DmsElementId createdElementId = agent.CreateElement(configuration);
}
```
