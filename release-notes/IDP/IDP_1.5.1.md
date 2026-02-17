---
uid: IDP_1.5.1
---

# IDP 1.5.1

## New features

#### New API to communicate with IDP [ID 40324]

A new API is available that can be used in scripts or connectors to communicate with IDP. It is available as a NuGet called *Skyline.DataMiner.ConnectorAPI.IDP.Development*. The current initial version only supports starting a discovery request, but more capabilities may be added later.

To start a discovery request, access the discovery message builders, create a discovery device message with all the necessary settings, and send the message. For example:

```csharp
var discoveryMessageBuilders = IdpInterApp.DiscoveryMessageBuilders;
var messageBuilder = discoveryMessageBuilders.CreateDeviceDiscoveryMessageBuilder(Engine.SLNetRaw)
                                             .WithCiTypes("IDP Simulation - HTTP")
                                             .WithIpAddress("10.11.10.82")
                                             .WithElementCreation();
messageBuilder.SendMessage(source: "TestIdpInterappApi");
```

## Changes

### Enhancements

#### Rack Usage Per Location dashboard now shows location names [ID 39273]

The "Rack Usage Per Location" dashboard will now show the location names in the graph legend, making it easier to quickly identify which locations have the highest rack utilization.

#### IDP protocol visual overviews now delivered as protocol default [ID 39429]

The visual overviews used by the IDP protocols will now be delivered as protocol default Visio files instead of custom Visio files. This affects the Visio files for the following protocols:

- Skyline Infrastructure Discovery And Provisioning
- Skyline IDP Discovery
- Skyline Generic Provisioning
- Skyline Configuration Manager
- Generic Rack Layout Manager

When you upgrade to this IDP version, the existing custom Visio files will stay in the system, but IDP will now use the protocol default Visio files instead. If the custom Visio files have any custom changes, you can go back to using them by [making them the active Visio file](xref:Set_as_active_Visio_file). If you no longer need the custom Visio files, you can [delete them](xref:Managing_Visio_files_linked_to_protocols#removing-a-microsoft-visio-file-assigned-to-a-protocol).

### Fixes

#### Rack Layout Visual Overview not updated correctly when navigating to different racks [ID 39347]

When you navigated from one rack view to another, the details of a device selected in the previous rack could still be displayed. Consequently, it could occur that details were shown of a device that was not present in the currently opened rack.
