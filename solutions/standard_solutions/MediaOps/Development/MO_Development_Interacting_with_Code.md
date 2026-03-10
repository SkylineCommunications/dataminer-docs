---
uid: MO_Development_Interacting_with_Code
---

# Interacting with MediaOps using code

All functionality of MediaOps is available through code. Custom scripts, data sources, etc. can make use of NuGet packages to retrieve and update objects within the MediaOps solution.

## Automation scripts

When creating a script that interacts with MediaOps, you will need to reference [Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Plan.Automation](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Plan.Automation).

## Connectors

When creating a connector that interacts with MediaOps, you will need to reference [Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Plan.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Plan.Protocol).

## Data sources

When creating a [data source](xref:GQI_Ad_hoc_data_sources) that interacts with MediaOps, you will need to reference [Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Plan.GQI](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Plan.GQI).

## Automation script code example

More details and code examples as the one below can be found in the [documentation of the code repository](https://github.com/SkylineCommunications/Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Plan/tree/main/Documentation).

```cs
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Solutions.MediaOps.Plan.API;
using Skyline.DataMiner.Solutions.MediaOps.Plan.Automation;

public class Script
{
   public void Run(IEngine engine)
   {
      var planApi = engine.GetMediaOpsPlanApi();

      // Create Capability
      var decodingCapability = new Capability()
      {
         Name = "Decoding",
      }
      .SetDiscretes(new[] { "AVC/H.264", "HEVC/H.265" });
      planApi.Capabilities.Create(decodingCapability);

      // Create Resource Pool and move to complete state
      var decodersResourcePool = new ResourcePool
      {
         Name = "Decoders",
      };
      planApi.ResourcePools.Create(decodersResourcePool);
      planApi.ResourcePools.Complete(decodersResourcePool.Id);

      // Create unmanaged Resources using decoding capability, assign to resource pool and move to complete state
      var decodingCapabilitySetting = new CapabilitySetting(decodingCapability.Id)
         .SetDiscretes(new[] { "AVC/H.264", "HEVC/H.265" });

      var decoder1 = new UnmanagedResource
      {
         Name = "Makito X4-001",
         Concurrency = 1,
      }
      .AddCapability(decodingCapabilitySetting)
      .AssignToPool(decodersResourcePool.Id);

      var decoder2 = new UnmanagedResource
      {
         Name = "Makito X4-002",
         Concurrency = 1,
      }
      .AddCapability(decodingCapabilitySetting)
      .AssignToPool(decodersResourcePool.Id);

      planApi.Resources.Create(new[] { decoder1, decoder2 });
      planApi.Resources.Complete(new[] { decoder1.Id, decoder2.Id });
   }
}
```
