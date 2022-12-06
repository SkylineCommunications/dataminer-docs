---
uid: General_Main_Release_10.4.0_new_features
---

# General Main Release 10.4.0 – Other new features - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

### Core functionality

#### All DOM objects now have 'LastModified', 'LastModifiedBy', 'CreatedAt' and 'CreatedBy' properties [ID_34980]

<!-- MR 10.4.0 - FR 10.3.2 -->

All DOM objects (DomInstance, DomTemplate, DomDefinition, DomBehaviorDefinition, SectionDefinition and ModuleSettings) will now contain the following additional properties:

- *LastModified*: Date/time (UTC) at which the object was last modified.
- *LastModifiedBy*: Full username of the user who last modified the object.
- *CreatedAt*: Date/time (UTC) at which the object was created.
- *CreatedBy*: Full username of the user who created the object.

> [!NOTE]
>
> - *CreatedAt* and *CreatedBy* are automatically populated when the object is created. Any value assigned to these two fields by a user will always be discarded.
> - *LastModified* and *LastModifiedBy* are automatically updated when the object is updated on the server. Any value assigned to these two fields by a user will always be discarded. When an object is created, these fields will contain the same values as *CreatedAt* and *CreatedBy*.
> - These four fields are not directly accessible on the object. You first need to cast them to either *ITrackBase* or their individual interfaces (*ITrackLastModified*, *ITrackLastModifiedBy*, *ITrackCreatedAt* and *ITrackCreatedBy*).
>
>   `string createdBy = ((ITrackBase) domInstance).CreatedBy;`
>
> - These four fields can all be used in a filter.
> - In the Elasticsearch database, existing data will not contain values for these new fields (except the *LastModified* field for all but *ModuleSettings*).
> - All four fields are also available in the GQI data source *Object Manager Instances*. The *Last Modified* and *Created At* columns should show the time in the time zone of the browser.

### Service & Resource Management

#### Service & Resource Management: Exposers for resource capacities and capabilities [ID_34841]

<!-- MR 10.4.0 - FR 10.3.1 -->

Exposers have been added for resource capacities and capabilities. These can for example be used as follows:

```csharp
var helper = new ResourceManagerHelper(engine.SendSLNetSingleResponseMessage);

// Get all resources with a certain discrete option
var encodingQualityParameterId = Guid.Parse("..."); // GUID of the profile parameter
FilterElement<Resource> filter = ResourceExposers.Capabilities.DiscreteCapability(encodingQualityParameterId).Contains("UHD");
var resources = helper.GetResources(filter);

// Get all resources with a certain rangepoint capability
var frequencyParameterId = Guid.Parse("...");
filter = ResourceExposers.Capabilities.HasRangePoint(frequencyParameterId, 50);
resources = helper.GetResources(filter);

// Get all resources with a certain string capability (case-insensitive)
var locationParameterId = Guid.Parse("...");
filter = ResourceExposers.Capabilities.StringCapability(locationParameterId).Equal("Berlin");
filter = ResourceExposers.Capabilities.StringCapability(locationParameterId).Contains("New");
resources = helper.GetResources(filter);

// Get all resources with a bitrate capacity, with a max value of 100.1 or more
var bitrateParameterId = Guid.Parse("...");
filter = ResourceExposers.Capacities.MaxCapacityValue(bitrateParameterId).GreaterThanOrEqual(100.1);
resources = helper.GetResources(filter);
```

These are the string representations of the examples above:

| Filter in code | String representation |
|--|--|
| `ResourceExposers.Capabilities.DiscreteCapability(encodingQualityParameterId).Contains("UHD");` | `Resource.Capabilities.e551766950f9442da1232d2e0e0f5872[List<String>] contains UHD` |
| `ResourceExposers.Capabilities.HasRangePoint(frequencyParameterId, 50);` | `(Resource.Capabilities.f0c94ee8ab2444d1866fa2ce5b7a3290_Min[Double] <=50) AND (Resource.Capabilities.f0c94ee8ab2444d1866fa2ce5b7a3290_Max[Double] >=50)` |
| `ResourceExposers.Capabilities.StringCapability(locationParameterId).Equal("Berlin");` | `Resource.Capabilities.be64ec9a33e843e0a06111690cff0140[String] =='Berlin'` |
| `ResourceExposers.Capacities.MaxCapacityValue(bitRateParameterId).GreaterThanOrEqual(100.10);` | `Resource.Capacities.8ce08caa5c1f45f4a2f6566cca7754b0[Double] >=100.1` |

Please note the following:

- The capacities and capabilities are exposed as dictionaries, where the key is the ID of the profile parameter (without dashes).
- A range capability exposes two values: the minimum and maximum of the range. These are exposed as two keys in the dictionary: "[id]_Min" and "[id]_Max".
- Building the filter in code and calling the *ToString()* method on the *FilterElement* should return a usable string representation of the filter.
- When you filter on discrete values, use the discrete value itself instead of the display value, as the latter is not stored in the resource.
- The filter is case sensitive with regard to profile parameter keys.
- The exposers will filter based on the total capacity configured on the resources. The available capacity at a specific point in time will not be taken into account. The same applies for time-dependent capabilities: the current time-dependent value is not resolved, and the resources will be treated as not having an empty string value for the capability.
- The exposers will not work reliably if you have the same capacity or capability multiple times on the same resource.
- The capacity value is exposed as a double (though it is stored as a decimal on the resource), for compatibility with the ElasticSearch database.
- The following extension methods have been added to easily compose the filters: *HasRangePoint*, *DiscreteCapability*, *StringCapability* and *MaxCapacityValue*.

> [!TIP]
> See also: [Visual Overview: Session variable YAxisResources now supports filters to pass exposers](xref:Cube_Main_Release_10.4.0_other_features_changes#visual-overview-session-variable-yaxisresources-now-supports-filters-id_34857)

### Tools

#### SLNetClientTest tool - 'Connect' window: Enhanced 'Connection Type' and 'Authentication' sections [ID_34712]

<!-- MR 10.4.0 - FR 10.3.1 -->

In the *SLNetClientTest* tool, to connect to a DataMiner Agent, you select *Connection* > *Connect*, and specify the necessary information in the *Connect* window. That window has now been updated.

In the *Connection Type* section, you now have to indicate how the connection has to be established:

| Select...              | in order to... |
|------------------------|----------------|
| Autodetect             | connect to the local machine or a remote machine using the method that will be detected automatically. |
| gRPC                   | connect to the local machine or a remote machine via the APIGateway service using the GRPCWeb protocol.<br>When you choose this option, you can specify a custom port (default: `443`) and a custom endpoint (default: `/APIGateway`). |
| .NET Remoting (legacy) | connect to the local machine or a remote machine using .NET Remoting.<br>When you choose this option, you can specify a custom port (default: `8004`) |
| IPC (only local)       | connect to the local machine using IPC. |

In the *Authentication* section (formerly known as *User Info* section), you now have the following authentication options:

- Single sign-on

    > [!NOTE]
    > External authentication not yet supported.

- Explicit credentials (with *Force Authenticate Local User* option)

- Ticket

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
