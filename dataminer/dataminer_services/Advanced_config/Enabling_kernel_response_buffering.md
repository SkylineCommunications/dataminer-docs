---
uid: Enabling_kernel_response_buffering
reviewer: Alexander Verkest
---

# Enabling kernel response buffering for DataMiner APIGateway

From DataMiner 10.3.0 [CU14]/10.4.0 [CU2]/10.4.5 onwards<!-- RN 38710 -->, it is possible to enable kernel response buffering for the [DataMiner APIGateway](xref:DataMinerExtensionModules#apigateway) DxM. This can be useful to improve throughput and responsiveness over high-latency connections.

To enable this setting:

1. On each server where you want to enable this feature, go to the folder `C:\Program Files\Skyline Communications\DataMiner APIGateway`.

1. In this folder, create or adjust the override *appsettings.custom.json* with the following contents:

```json
{
   "HostingOptions": {
      "EnableKernelResponseBuffering": true
   }
}
```

1. Restart *DataMiner APIGateway* on each server for the changes to take effect.

> [!NOTE]
> From DataMiner 10.5.10/10.6.0 onwards<!-- RN 43346 -->, this setting is enabled by default. If necessary, you can disable it by following the procedure above and specifying *false* instead of *true*.
