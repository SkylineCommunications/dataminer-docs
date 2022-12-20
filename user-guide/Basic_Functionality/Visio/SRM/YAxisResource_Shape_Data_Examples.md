---
uid: YAxisResource_Shape_Data_Examples
---

# YAxisResource session variable examples

> [!TIP]
> See also: [Passing elements, services, views, or exposers to the YAxisResources session variable](xref:Embedding_a_Resource_Manager_component#passing-elements-services-views-or-exposers-to-the-yaxisresources-session-variable)

### Passing exposers with a filter

In the following examples, a resource exposer is passed by means of a filter:

- Get all resources from resource "pool 1" (ID = 709d587d-80a3-456c-ac8d-3d862abee131):

  `Filter=(Resource.PoolGUIDs[List<Guid>]  contains 709d587d-80a3-456c-ac8d-3d862abee131)`

  Exposer code: `ResourceExposers.PoolGUIDs.Contains(resourcePool1.ID)`

- Get all resources that were modified in the last 15 minutes:

  `Filter=(Resource.LastModifiedAt[DateTime] > 11/26/2022 10:50:00)`

  Exposer code: `ResourceExposers.LastModifiedAt.GreaterThan(now.Subtract(TimeSpan.FromMinutes(15)))`

- Get all resources that have property Class type Gold:

  `Filter=(Resource.PropertiesDict.Class[String] =='Gold')`

  Exposer code: `ResourceExposers.Properties.DictStringField("Class").Equal("Gold")`

- Get all resources that contain description "my description" OR all function resources with function name "My Resource Function":

  `Filter=((Resource.Description[String]  contains 'my description') OR (Resource.FunctionName[String] =='My Resource Function'))`

  Exposer code: `ResourceExposers.Description.Contains("my description of my").OR(FunctionResourceExposers.FunctionName.Equal("My Resource Function"))`

- Get all function resources of certain DVE parent element that are not younger than a day:

  `Filter=((Resource.MainDVEDmaID[Int32] == 730) AND (Resource.MainDVEElementID[Int32] ==42) AND (Resource.CreatedAt[DateTime] <11/26/2022 10:50:00))`

  `FunctionResourceExposers.MainDVEDmaID.Equal(1).AND(FunctionResourceExposers.MainDVEElementID.Equal(1)).AND(ResourceExposers.CreatedAt.GreaterThanOrEqual(now.Subtract(TimeSpan.FromDays(1))).NOT())`

- Get all resources that have a specific capacity, which is less than 500,000:

  `Filter=(Resource.Capacities.f8aee157376b48789a71cb4c6b500d39[Double] <500000)`

  Exposer code: `ResourceExposers.Capacities.MaxCapacityValue(capacityParameter.ID).LessThan(500_000)`

- Get all resources that have a specific capability, which has discrete raw value "B 2":

  `Filter=(Resource.Capabilities.ef380239b06c445f860f1de5c03311be[List<String>]  contains B 2)`

  Exposer code: `ResourceExposers.Capabilities.DiscreteCapability(capabilityTextDiscreteParam.ID).Contains("B 2")`

- Get all resources that have a specific capability, which has range option 50:

  `Filter=((Resource.Capabilities.57af1dbf201b4ccb8b9c1687b577a45b_Min[Double] <=50) AND (Resource.Capabilities.57af1dbf201b4ccb8b9c1687b577a45b_Max[Double] >=50))`

  Exposer code: `ResourceExposers.Capabilities.HasRangePoint(capabilityNumberParam.ID, 50)`

- Get all resources that have a specific capability, which contains text value "CAPAB":

  `Filter=(Resource.Capabilities.b6d7cfadc3d34568afa353da82915f30[String]  contains 'CAPAB')`

  Exposer code: `ResourceExposers.Capabilities.StringCapability(capabilityTextParam.ID).Contains("CAPAB")`

### Passing exposers with a filter and converter

In the following examples, a resource exposer is passed by means of a filter and profile parameter conversion:

- Get all resources that have capability "myCapabilityNumberDiscreteParam", which has discrete raw value "1":

  `Filter=(Resource.Capabilities.[ProfileParameter:myCapabilityNumberDiscreteParam,ID][List<string>] contains '1')`

- Get all resources that have capability "myCapabilityNumberDiscreteParam", which has discrete raw value "1", AND have capability "myCapabilityTextDiscreteParam", which has discrete raw value "A 1":

  `Filter=(Resource.Capabilities.[ProfileParameter:myCapabilityNumberDiscreteParam,ID][List<string>] contains '1' AND Resource.Capabilities.[ProfileParameter:myCapabilityTextDiscreteParam,ID][List<string>] contains 'A 1')`

- Get all resources that have capability "myCapabilityNumberParam", which has range option 25, AND have capability "MyCapabilityTextParam", which has the text value "CAPA":

  `Filter=((Resource.Capabilities.[ProfileParameter:myCapabilityNumberParam,ID]_Min[Double] <= 25) AND (Resource.Capabilities.[ProfileParameter:myCapabilityNumberParam,ID]_Max[Double] >= 25) AND (Resource.Capabilities.[ProfileParameter:MyCapabilityTextParam,ID][string] == 'CAPA'))`
