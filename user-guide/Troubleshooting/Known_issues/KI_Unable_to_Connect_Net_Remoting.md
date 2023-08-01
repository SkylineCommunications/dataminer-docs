---
uid: KI_Unable_to_Connect_Net_Remoting
---

# Unable to connect to DMS when using .NET Remoting

## Affected versions

- DataMiner Cube 10.3.7 and 10.3.8

- Any versions from DataMiner 10.2.0 onwards using automatic client updates

## Cause

Because of a race condition in DataMiner Cube you may be unable to connect to your DMS when using .NET Remoting.

## Fix

No fix is available yet.

## Workaround

- Restart DataMiner Cube.

- DataMiner 10.3.x: Enable *GRPCConnection* as the default in the *ConnectionSettings.txt* file. See [ConnectionSettings.txt options](xref:ConnectionSettings_txt#connectionsettingstxt-options).

- DataMiner 10.2.x: In *System Center > System settings > Manage client versions*, select *Force the matching release version* to temporarily switch over to a matching DataMiner Cube version. See [Managing client versions](xref:DMA_configuration_related_to_client_applications#managing-client-versions).

  > [!CAUTION]
  > Using this workaround will result in the loss of the latest 10.3.x features. We recommend switching back to allowing automatic updates as soon as a permanent fix is available.

## Issue description

- The DataMiner Cube login screen displays the following error message: `Start the DataMiner software manually or contact your system administrator.`

- In [Cube logging](xref:Cube_logging) the following line is displayed alongside a `Login failed` entry: `Cannot accept SOAP messages (text/xml)`
