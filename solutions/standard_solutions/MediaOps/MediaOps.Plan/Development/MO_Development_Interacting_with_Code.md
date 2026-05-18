---
uid: MO_Development_Interacting_with_Code
---

# Interacting with MediaOps using code

All functionality of MediaOps is available through code. Custom scripts, data sources, etc. can make use of NuGet packages to retrieve and update objects within the MediaOps solution.

## Automation scripts

When creating a script that interacts with the MediaOps **Resource Studio**, **Scheduling**, or **Workflow Designer** apps, you will need to reference [Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Plan.Automation](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Plan.Automation).

When creating a script that interacts with the MediaOps **People and Organizations** app, you will need to reference [Skyline.DataMiner.Dev.Utils.Solutions.PeopleAndOrganizations.Automation](https://github.com/SkylineCommunications/Skyline.DataMiner.Dev.Utils.Solutions.PeopleAndOrganizations/tree/main/DevPack.Automation).

## Connectors

When creating a connector that interacts with the MediaOps **Resource Studio**, **Scheduling**, or **Workflow Designer** apps, you will need to reference [Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Plan.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Plan.Protocol).

When creating a connector that interacts with the MediaOps **People and Organizations** app, you will need to reference [Skyline.DataMiner.Dev.Utils.Solutions.PeopleAndOrganizations.Protocol](https://github.com/SkylineCommunications/Skyline.DataMiner.Dev.Utils.Solutions.PeopleAndOrganizations/tree/main/DevPack.Protocol).

## Data sources

When creating a [data source](xref:GQI_Ad_hoc_data_sources) that interacts with the MediaOps **Resource Studio**, **Scheduling**, or **Workflow Designer** apps, you will need to reference [Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Plan.GQI](https://www.nuget.org/packages/Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Plan.GQI).

When creating a [data source](xref:GQI_Ad_hoc_data_sources) that interacts with the MediaOps **People and Organizations** app, you will need to reference [Skyline.DataMiner.Dev.Utils.Solutions.PeopleAndOrganizations.GQI](https://github.com/SkylineCommunications/Skyline.DataMiner.Dev.Utils.Solutions.PeopleAndOrganizations/tree/main/DevPack.GQI).

## Code examples

### Managing resources from an automation script

More details and code examples like the one below can be found in the [documentation of the code repository](https://github.com/SkylineCommunications/Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Plan/tree/main/Documentation).

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

### Managing people from an automation script

More details and code examples like the one below can be found in the [documentation of the code repository](https://github.com/SkylineCommunications/Skyline.DataMiner.Dev.Utils.Solutions.PeopleAndOrganizations/tree/main/Documentation).

```cs
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Solutions.PeopleAndOrganizations.API;
using Skyline.DataMiner.Solutions.MediaOps.Plan.Automation;

public class Script
{
   public void Run(IEngine engine)
   {
      var api = engine.GetPeopleAndOrganizationsApi();
   
      // Create an organization
      var organization = api.Organizations.Create(new Organization
      {
         Name = "Skyline Communications",
      });
   
      // Define a new experience
      var experience = api.Experience.Create(new Experience
      {
         Name = "Senior System Developer",
      });
   
      // Create a person
      var person = api.People.Create(new Person
      {
         Name = "John Doe",
         Email = "john.doe@example.com",
         Phone = "+1 555 0100",
         StreetAddress = "123 Main St",
         City = "Ghent",
         Country = Country.Belgium,
         ZipCode = "9000",
         OrganizationId = organization.Id,
         ExperienceId = experience.Id,
      });
   
      // Update person
      person.Email = "john.updated@skyline.be";
      person = api.People.Update(person);
   
      // Delete person
      api.People.Delete(person.Id);
   }
}
```
