---
uid: ClassLibraryUpdatingElements
keywords: class library 
---

# Updating elements

Once an element is retrieved, it can be updated.
To update an element, set the desired properties to the new value and call the [Update](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IUpdateable.Update) method on the element.

The following example performs a rename of an element and also sets a property.

```csharp
IDms dms = protocol.GetDms();

IDmsElement element = dms.GetElement(new DmsElementId(346, 529981));

element.Name = "Renamed Element";

if (element.Properties["CustomProperty"].IsWritable)
{
    IWritableProperty myProperty = element.Properties["CustomProperty"].AsWritable();
    myProperty.Value = "A";
}
else
{
   // "My Property" is a read-only property.
}

element.Update(); // Apply the changes.
```

The updates are only sent to DataMiner when the Update method is executed. This makes it possible to set multiple properties at once reducing the number of messages that needs to be sent to DataMiner to apply all changes.

## Updating element connections

In case you need to update the connection settings of a specific connection of an element, e.g. an SNMP connection, cast the connection to the corresponding interface:

```csharp
IDms dms = protocol.GetDms();
var element = dms.GetElement(elementName);

var connection = element.Connections[0] as ISnmpV2Connection;

if (connection != null)
{
    connection.GetCommunityString = "public";
    connection.SetCommunityString = "private";
}

element.Update();
```

The following example illustrates how to update an HTTP connection of an existing element:

```csharp
IDms myDms = protocol.GetDms();

var element = myDms.GetElement("myHttpElement");

int portNumber = 8888;

ElementConnectionCollection connections = element.Connections;

// We assume that in this example we know the first connection is the HTTP connection.
if (connections.Length > 0)
{
    var httpConnection = connections[0] as IHttpConnection;
    
    if (httpConnection != null)
    {
        var currentPortNumber = httpConnection.TcpConfiguration.RemotePort;
    
        if (currentPortNumber != portNumber)
        {
            httpConnection.TcpConfiguration.RemotePort = portNumber;
        
            // Apply changes.
            element.Update();
        }
    }
}
```

For an overview of the different interfaces, refer to [Creating an element with connections](xref:ClassLibraryElementCreation#creating-an-element-with-connections).
