---
uid: MO_Development_Interacting_with_Code
---

# Interacting with MediaOps using code

All functionality of MediaOps is available through code. Custom scripts, data sources, etc. can make use of NuGet packages to retrieve and update objects within the MediaOps solution.

## Automation scripts

When creating a script that interacts with MediaOps you will need to directly reference at least the following NuGet packages:

- [Microsoft.Extensions.Logging.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Abstractions)
- [Skyline.DataMiner.ConnectorAPI.SkylineLockManager](https://www.nuget.org/packages/Skyline.DataMiner.ConnectorAPI.SkylineLockManager)
- [Skyline.DataMiner.Core.DataMinerSystem.Common](https://www.nuget.org/packages/Skyline.DataMiner.Core.DataMinerSystem.Common)
- [Skyline.DataMiner.Dev.Automation](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Automation)
- [Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Live]()
- [Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Plan]()
- [Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Plan.Automation]()
- [Skyline.DataMiner.SDM.Abstractions]()
- [Skyline.DataMiner.Utils.Categories.Automation]()

## Connectors

When creating a connectors that interacts with MediaOps you will need to directly reference at least the following NuGet packages:

<!-- TODO: Add the list here as well for connectors -->

## Data sources

When creating a data source that interacts with MediaOps you will need to directly reference at least the following NuGet packages:

<!-- TODO: Add the list here as well for data sources -->

## Code example

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