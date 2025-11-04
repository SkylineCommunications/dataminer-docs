---
uid: srm_using_resourcemanagerhelper
keywords: ResourceManagerHelper
---

# Interacting with Resource Manager

The *ResourceManagerHelper* class can be used in code to interact with *Resource* and *ReservationInstance* (i.e. booking) objects. To instantiate a *ResourceManagerHelper*, a callback to SLNet needs to be provided:

```csharp
// In an automation script
var helper = new ResourceManagerHelper(engine.SendSLNetSingleResponseMessage);

// In an ad hoc data source
var helper = new ResourceManagerHelper(gqiDms.SendMessages);

// In a connector QAction
var helper = new ResourceManagerHelper(protocol.SLNet.SendSingleResponseMessage);
```

> [!NOTE]
> Be careful when updating bookings in connectors. Depending on the scale of the SRM system, adding or updating bookings can take a while.

## Reading resources and bookings

The *ResourceManagerHelper* provides methods to retrieve *Resource* and *ReservationInstance* (i.e. booking) objects in a filtered, sorted, and paged way.

Filters are constructed by concatenating together *Exposers* that specify the field you want to filter on.

> [!NOTE]
>
> - You will need to include the *Skyline.DataMiner.Net.Messages* namespace to use the *ResourceManagerHelper* and *ResourceExposers* classes.
> - The *ReservationInstanceExposers*, *ServiceReservationInstanceExposers*, and *FunctionResourceExposers* classes can be found in the *Skyline.DataMiner.Net.ResourceManager.Objects* namespace.
> - The namespace *Skyline.DataMiner.Net.Messages.SLDataGateway* contains the comparison methods (*Contains*, *Equal*, *LessThan* etc.).

Some examples:

```csharp
// Filter that matches all ReservationInstances that have a name that contains 'satellite' and that use a specific service definition.
var reservationInstanceFilter = ReservationInstanceExposers.Name.Contains("satellite").AND(ServiceReservationInstanceExposers.ServiceDefinitionID.Equal(Guid.Parse("...")));

// Filter that matches all ReservationInstances overlapping with the time range between now and 3 hours from now.
var start = DateTime.UtcNow;
var end = start.AddHours(3);
var timeRangeFilter = ReservationInstanceExposers.Start.LessThan(end).AND(ReservationInstanceExposers.End.GreaterThan(start));

// Filter that matches all resources that have a name that contains 'Encoder' and are linked to a specific function.
var resourceFilter = ResourceExposers.Name.Contains("Encoder").AND(FunctionResourceExposers.FunctionGUID.Equal(Guid.Parse("...")));

// Filter that matches all resources that support a capacity range between 100 and 200 units for a specific capacity parameter.
var resourceFilter = ResourceExposers.Capacities.SupportsRange(rangeCapacityId, 200, 200)
```

> [!IMPORTANT]
> On a DataMiner Agent that uses OpenSearch or Elasticsearch, there is a default limit of 1024 clauses in a query. This means that you can only concatenate a maximum of 1024 filters using an "OR" filter. If this limit is not sufficient, you can adjust it using the "indices.query.bool.max_clause_count" option in [OpenSearch](https://opensearch.org/docs/latest/install-and-configure/configuring-opensearch/index-settings/) or [Elasticsearch](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/search-settings.html).
>
> For STaaS, there is no such hard limit, but we do recommend keeping the queries short.

> [!NOTE]
> When you want to read multiple *ReservationInstance* or *Resource* objects using their IDs, it is more efficient to build one large OR filter and read them in a single call instead of retrieving them one by one. The *Tools.RetrieveBigOrFilter()* helper method is available for this:
>
> ```Tools.RetrieveBigOrFilter(ids, id => ReservationInstanceExposers.ID.Equal(id), filter => helper.GetReservationInstances(filter))```

The filter can be passed to the relevant helper method to retrieve the objects in a [paged](#reading-with-paging) or [non-paged](#reading-without-paging) way, and it can be [combined with a sort operator](#reading-with-paging-and-sorting) to perform sorting on a database level.

### Reading without paging

> [!NOTE]
> Reading in a non-paged way will return trace data if the user does not have the necessary permissions or if an unforeseen error occurs (for example when the database is not reachable). For more information on handling trace data, see [Handling errors](#handling-errors).

```csharp
var resourceFilter = ResourceExposers.ID.Equal(Guid.Parse("39CA130D-082D-49F3-AB49-89A23ACA9270"));
var resources = helper.GetResources(resourceFilter);

// Get a resource pool by name. Exposers are not supported for resource pools.
var pool = new ResourcePool
{
    Name = "Encoders"
};
var foundPool = helper.GetResourcePools(pool).FirstOrDefault();
if (foundPool == null)
{
    // No pool found; handle appropriately.
}

// Get all resources in that pool.
var resourcesInPoolFilter = ResourceExposers.PoolGUIDs.Contains(foundPool.GUID);
resources = helper.GetResources(resourcesInPoolFilter);

var reservationInstanceFilter = ReservationInstanceExposers.ID.Equal(Guid.Parse("47BB3B98-6F94-49EE-B034-283A22AB634A"));
var reservationInstances = helper.GetReservationInstances(reservationInstanceFilter);
```

### Reading with paging

> [!NOTE]
>
> - Reading in a paged way will throw a *CrudFailedException* if the user does not have the necessary permissions or if an unforeseen error occurs (for example when the database is not reachable). The *CrudFailedException* contains a *TraceData* property with more information about the error. For more information on handling trace data, see [Handling errors](#handling-errors).
> - Retrieving resources using paging is supported from DataMiner version 10.4.9/10.5.0 onwards.<!-- RN 39743 -->

```csharp
var resourceFilter = ResourceExposers.Name.Contains("encoder", caseSensitive: false);
var resourcePager = helper.PrepareResourcePaging(resourceFilter.ToQuery(), preferredPagingSize: 200);

while (resourcePager.MoveToNextPage())
{
    var resources = resourcePager.GetCurrentPage();
    // Do something with the resources on this page.
}

var reservationInstanceFilter = ReservationInstanceExposers.Name.Contains("Satellite", caseSensitive: false);
var reservationInstancePager = helper.PrepareReservationInstancePaging(reservationInstanceFilter.ToQuery(), preferredPagingSize: 200);

while (reservationInstancePager.MoveToNextPage())
{
    var reservationInstances = reservationInstancePager.GetCurrentPage();
    // Do something with the ReservationInstances on this page.
}
```

### Reading with paging and sorting

```csharp
// Retrieve all resources with custom property 'Location' equal to 'London' and sort them by name.
var resourceFilter = ResourceExposers.Properties.DictStringField("Location").Equal("London");
var resourcePager = helper.PrepareResourcePaging(resourceFilter.OrderBy(ResourceExposers.Name), preferredPagingSize: 200);

while (resourcePager.MoveToNextPage())
{
    var resources = resourcePager.GetCurrentPage();
    // Do something with the resources on this page.
}

var reservationInstanceFilter = ReservationInstanceExposers.Name.Contains("Satellite");
var reservationInstancePager = helper.PrepareReservationInstancePaging(reservationInstanceFilter.OrderBy(ReservationInstanceExposers.Name), preferredPagingSize: 200);

while (reservationInstancePager.MoveToNextPage())
{
    var reservationInstances = reservationInstancePager.GetCurrentPage();
    // Do something with the ReservationInstances on this page.
}
```

## Getting available resources

The *ResourceManagerHelper* provides a *GetEligibleResources* method to retrieve the resources with certain capacities or capabilities that are available at a certain time. The *EligibleResourceContext* passed to this method contains a number of properties that can be used to fine-tune the filtering.

The most basic filter specifies the time range in which the resources need to be available:

```csharp
// The timings in the context should be in UTC.
// The namespace 'Skyline.DataMiner.Net.Time' needs to be included to use 'TimeRangeUtc' 
var now = DateTime.UtcNow;
var context = new EligibleResourceContext()
{
    TimeRange = new TimeRangeUtc(now.AddHours(1), now.AddHours(4)),   
};
```

A filter can be passed to only return resources that match certain criteria.

In this example, a filter is passed to only return resources that are part of a specific pool.

```csharp
var poolGuid = Guid.Parse("...");
context.ResourceFilter = ResourceExposers.PoolGUIDs.Contains(poolGuid);
```

A list of capacities can be passed to only return resources that have the specified capacities available in the requested time range.

Multiple capacities can be added to the list. Only resources that have all capacities in the list available will be returned.

```csharp
// The namespace 'Skyline.DataMiner.Net.SRM.Capacities' needs to be included to use 'MultiResourceCapacityUsage'
var bitrateProfileId = Guid.Parse("...");
var requestedCapacity = new MultiResourceCapacityUsage(bitrateProfileId, quantity: 100);
context.RequiredCapacities.Add(requestedCapacity); 
```

> [!NOTE] 
> Since DataMiner 10.5.9/10.6.0 <!-- RN 43335 -->, it is possible to request resources that have a capacity range defined by a start range and the quantity.

```csharp
var rangeCapacityParameter = Guid.Parse("...");
var requestedCapacityId = new MultiResourceCapacityUsage(rangeCapacityParameterId, start: 100, quantity: 50);
context.RequiredCapacities.Add(requestedCapacityId); 
```

A list of capabilities can be passed to only return resources that have the specified capabilities.

Multiple capabilities can be added to the list. Only resources that have all capabilities in the list available will be returned.

```csharp
// The namespace 'Skyline.DataMiner.Net.SRM.Capabilities' needs to be included to use 'ResourceCapabilityUsage'
var inputInterfaceProfileId = Guid.Parse("...");
var requestedCapability = new ResourceCapabilityUsage()
{
    CapabilityProfileID = inputInterfaceProfileId,
    RequiredDiscreet = "IP"
};
context.RequiredCapabilities.Add(requestedCapability); 
```

There is also the possibility to match resources that have one or more capabilities from a list of capabilities. In the example below, all resources that have either the *HD* or the *UHD* capability (or both) are requested.

```csharp
var encodingQualityProfileId = Guid.Parse("...");
var requestedCapabilityHD = new ResourceCapabilityUsage()
{
    CapabilityProfileID = encodingQualityProfileId,
    RequiredDiscreet = "HD"
};
var requestedCapabilityUHD = new ResourceCapabilityUsage()
{
    CapabilityProfileID = encodingQualityProfileId,
    RequiredDiscreet = "UHD"
};
context.RequiredCapabilitiesOrFiltered.Add(requestedCapabilityHD); 
context.RequiredCapabilitiesOrFiltered.Add(requestedCapabilityUHD); 
```

The *ReservationIdToIgnore* and *NodeIdToIgnore* properties can be used to exclude an already booked resource. This means that the resource assigned to that node might be included in the result set, since it will be treated as if it is not currently assigned to that booking. If the *TimeRange* property was not set on the context, the timing of the ignored booking will also be used to calculate the available resources. This can be useful in scenarios where the available resources for a node you want to swap need to be calculated.

> [!NOTE]
>
> - These two properties always need to be used together, or not at all.
> - Passing the ID of a booking that does not exist will result in a *ReservationInstanceNotFound* error in the trace data.
> - Passing the ID of a node that does not exist in the booking will result in a *ServiceNodeResourceUsageNotFound* error in the trace data.

```csharp
context.ReservationIdToIgnore = new ReservationInstanceID(Guid.Parse("..."));
context.NodeIdToIgnore = 2; // The NodeId is a property on the 'ServiceResourceUsageDefinition' and indicates which node of the ServiceDefinition this resource was assigned to.
```

You can skip filling in the *LinkerTableEntries* property of the resources. The default behavior of the call is to fill in these *LinkerTableEntries*. For performance reasons, we recommend setting this flag to *false* if the script logic does not require the *LinkerTableEntries*.

```csharp
context.FillLinkerTableEntries = false;
```

By default, the result will only contain information about the usage of the requested capacities and capabilities. It is possible to request the calculation of all capacities and capabilities of the resources.

We do not recommend setting these flags to *true* unless the script logic requires it, as this has an impact on the performance.

```csharp
context.CalculateAllCapacities = true;
context.CalculateAllCapabilities = true;
```

The result of the call will contain all the resources that match the criteria of the context, as well as details about the usage of those resources in the requested time range.

```csharp
var result = helper.GetEligibleResources(context);

var resources = result.EligibleResources;
var usageDetailsByResourceId = result.UsageDetails.ToDictionary(u => u.ResourceId);

var logString = new StringBuilder();
foreach (var resource in resources)
{
    if (!usageDetailsByResourceId.TryGetValue(resource.ID, out var usageDetails))
    {
        // This should not ever happen
        continue;
    }

    logString.AppendLine($"Usage details for resource '{resource.Name}' ({resource.ID}):");
    logString.AppendLine($"\tConcurrency left: {usageDetails.ConcurrencyLeft}");
    
    foreach (var capacityUsage in usageDetails.CapacityUsageDetails)
    {
        logString.AppendLine($"\tCapacity left for capacity with ID '{capacityUsage.CapacityParameterId}': {capacityUsage.CapacityLeft}");
    }
    
    foreach (var capabilityUsage in usageDetails.CapabilityUsageDetails)
    {
        // 'HasExistingBookings' will be 'null' if the capability is not time-dynamic.
        //  Capabilities that are not time-dynamic capabilities are available regardless of the fact if there are bookings or not. 
        logString.Append($"\tCapability '{capabilityUsage.CapabilityParameterId}': Is time-dynamic: {capabilityUsage.HasExistingBookings.HasValue}");

        foreach (var oneBookedCapability in capabilityUsage.BookedCapabilities)
        {
            // We log the 'RequiredString' in this case, the filled in property will depend on the type of capability (string, discreet or rangepoint)
            logString.AppendLine($"\t\tBooked {oneBookedCapability.BookedTimeRange} with value '{oneBookedCapability.Value.RequiredString}'");
        }
    }
}

// Example value for 'logString.ToString()':
// Usage details for resource 'Encoder A' (c89d58c6-7173-4f08-b067-f27aa486e2ef):
//      Concurrency left: 9
//      Capacity left for capacity with ID '0ec82fec-2c43-46af-ab73-fb4d478e95ea': 50,0
//      Capability 'e97b58ce-90b8-459c-8894-d39b8ccd8a4e': Is time-dynamic: true. 
//          Booked From 2024-09-17T14:25:33.879 UTC to 2024-09-17T17:25:33.879 UTC spans 3h with value 'Example value'
logString.Clear();
```

It is possible to pass multiple *EligibleResourceContext* instances in one call, which will result in better performance than when these calls are done separately. The helper will return a list of results, which can be matched by *ContextId*.

```csharp
var contextOne = new EligibleResourceContext();
...
var contextTwo = new EligibleResourceContext();
...

var results = helper.GetEligibleResources(new List<EligibleResourceContext>() { contextOne, contextTwo });
var resultsByContextId = results.ToDictionary(r => r.ForContextId);

var resultForContextOne = resultsByContextId.TryGetValue(contextOne.ContextId, out var resultOne) ? resultOne : null;
if (resultForContextOne == null)
{
    // Check the trace data of the call. Something might have gone wrong.
}

var resultForContextTwo = resultsByContextId.TryGetValue(contextTwo.ContextId, out var resultTwo) ? resultTwo : null;
if (resultForContextTwo == null)
{
    // Check the trace data of the call. Something might have gone wrong.
}
```

## Handling errors

If a call fails, the helper will not throw an exception. Trace data will be available on the helper instead. The trace data can be retrieved with the *GetTraceDataLastCall* method:

```csharp
helper.AddOrUpdateResources(resource);
var traceData = helper.GetTraceDataLastCall();
if (!traceData.HasSucceeded())
{
    var resourceManagerErrors = traceData.GetErrorDataOfType<ResourceManagerErrorData>();
    foreach (var error in resourceManagerErrors)
    {
        // Handle the error
    }
}
```

When bookings are updated via the framework, a *ResourceManagerTraceDataException* will be thrown if trace data is returned when the *ReservationInstance* (i.e. booking) is updated. This exception has a property to access the full trace data, as well as a method to format some known errors. When you use the framework, we highly recommend using the framework methods to update *ReservationInstances*.

```csharp
try 
{
    bookingManager.CreateNewBooking(...);
}
catch (ResourceManagerTraceDataException traceDataException)
{
    var traceData = traceDataException.TraceData;
    var errors = traceDataException.BuildErrors();
    var errorString = string.Join(Environment.NewLine, errors);
}
```

The *ResourceManagerErrorData* has a *Reason* field, which gives more information about the reason for the failure. Below, you can find a table listing the different reasons that can be returned, together with the other properties that will be available in the error.

### Errors when adding or updating resources

| Error reason   | Description  | Available properties |
|---|---|---|
| NotLicensed | The necessary licenses are missing. To create a resource, the *ResourceManager* license is required. To create a function resource, the *ServiceManager* license is required as well. | None. |
| InitializeFunctionResourceFailed | Occurs when a function resource could not be initialized. | *SubjectId* contains the ID of the resource that failed to initialize. <br>*InitializeFunctionResourceResult* contains a more detailed reason. See [Possible values](#possible-values-for-the-initializefunctionresourceresult-property). |
| ResourceDeleteFailed | Deleting the resources failed. | *UsingIds* contains the IDs of the resources that could not be deleted. |
| ResourceInvalidPropertyName | The resource has two or more properties with the same name, which is not valid. | *SubjectId* contains the ID of the resource. |
| ResourcePoolNotExists | The resource refers to a resource pool that does not exist. | *SubjectId* contains the ID of the pool that does not exist. |
| ResourceDeleteInUseOrMaintenanceMode | The resource cannot be deleted because it is in use or in maintenance mode. | *SubjectId* contains the ID of the resource. <br>*FutureOrOngoingReservationIds* contains the IDs of the future or ongoing *ReservationInstances* that use the given resource. <br>*HasPastBookings* indicates if the resource that failed to be deleted has bookings in the past. |
| InvalidCharactersInPropertyNames | The custom properties of the resource contains some characters that are invalid (see [Restrictions on property names](#restrictions-on-property-names)). | *SubjectId* contains the ID of the resource. <br>*PropertyNames* contains the invalid property names. |
| ResourceCapabilityInvalid | The resource has a capability assigned without a value. | *SubjectId* contains the ID of the resource. <br>*ResourceCapability* contains the invalid capability. |
| ResourceCapacityInvalid | The resource has a capacity assigned without a value. | *SubjectId* contains the ID of the resource. <br>*ResourceCapacity* contains the invalid capability. |
| ResourceUpdateCausedReservations&shy;ToGoToQuarantine | The resource cannot be updated because some *ReservationInstances* would be moved to quarantine. | *SubjectId* contains the ID of the resource. <br>*ConflictInformation* contains the *ReservationInstances* with their usage that would be moved to quarantine. |
|ModuleNotInitialized| The Resource Manager is not initialized yet; the request cannot be handled. | None|
|UnknownError| An unexpected error happened. | *Message* could contain more information. |
|NotAllowed| The user does not have the necessary permissions to create, read, update, or delete the resource. | *SubjectId* contains the ID of the resource. <br>*Message* will contain more details. |
|MainElementNotReachable| When deleting a resource, the record in the *[Generic DVE Table]* of the parent element could not be deleted. This is not possible if the element is not reachable (e.g. the element is stopped).|*SubjectId* contains the ID of the resource that cannot be deleted.<br>*ElementID* contains the ID of the main element of the resource.|

#### Possible values for the InitializeFunctionResourceResult property

The following table contains possible values for the *InitializeFunctionResourceResult* field when the error *InitializeFunctionResourceFailed* is returned.

| Reason   | Description  |
|---|---|
| Error | A general error, without more information. |
| MaxAmountOfInstancesReached | The function definition of the resource has reached its maximum instances. |
| DVEDataNotAvailable | Fetching the necessary DVE data from the parent element for initializing the resource failed. |
| FunctionDefinitionNotFound | The function definition this resource is linked to could not be found. |
| InvalidParentElementState | The parent element linked to this resource is not in a valid state (hidden, active, masked, or paused). |
| ElementHasDifferentParentThan&shy;FunctionResource | The parent element configured on the resource and the DVE parent configured on the element are different. |
| InvalidDveState | The parent element configured on the resource is not in a valid state (hidden, active, masked, or paused). |
| DuplicateFunctionName | The function name of the resource is already in use by a different resource on the same parent element. |

### Errors when adding or updating bookings

| Error reason   | Description  | Available properties |
|---|---|---|
| NotLicensed | The necessary licenses are missing. To add or update a *ReservationInstance* (i.e. booking), the *ResourceManager* and *ServiceManager* licenses are required. | None. |
| ResourceDoesNotExist | The *ReservationInstance* uses a resource that does not exist in the system. | *SubjectId* contains the ID of the *ReservationInstance*. <br>*ResourceId* contains the ID of the missing resource. |
| ConcurrentLicense | Adding or updating the *ReservationInstance* is not possible because this would exceed the maximum number of concurrent bookings defined in the license. | *UsingIdsWithNames* contains the IDs of the *ReservationInstances* that could not be added. <br>*Message* contains more information. |
| ReservationInstanceInvalidFunctionResources | The *ReservationInstance* cannot be set to mode *Confirmed* because one or more resources are used where the linked function is not active or does not exist. | *SubjectId* contains the ID of the *ReservationInstance*. <br>*UsingIds* contains the IDs of the function definitions or system function definitions that are not active or do not exist. |
| ResourceNotAvailable | A resource assigned to the *ReservationInstance* is not available. Its mode is set to either *Maintenance*, *Undefined*, or *Unavailable*. | *SubjectId* contains the ID of the *ReservationInstance*. <br>*ResourceId* contains the ID of the unavailable resource. |
| ReservationInstanceNotValid | One or more fields of the *ReservationInstance* are not valid. <br>The *ReservationInstance* has the status *Undefined*, or there are custom properties with invalid characters (see [Restrictions on property names](#restrictions-on-property-names)). |*SubjectId* contains the ID of the *ReservationInstance*.|
|HostingAgentNotRunning|The hosting Agent of the *ReservationInstance* is not running, which is needed to add, edit, or delete a booking hosted on that Agent. | *SubjectId* contains the ID of the *ReservationInstance*. |
|ServiceWithSameNameAlreadyPlanned|The *ServiceReservationInstance* cannot be saved because a *ServiceReservationInstance* with the same name that overlaps is already planned. |*SubjectId* contains the ID of the *ServiceReservationInstance* with the conflict. <br>*UsingIdsWithNames* contains the ID and name of the *ServiceReservationInstances* overlapping and using the same name.|
|ServiceWithSameServiceIdAlreadyPlanned|The *ServiceReservationInstance* cannot be saved because a *ServiceReservationInstance* with the same service ID that overlaps is already planned. |*SubjectId* contains the ID of the *ServiceReservationInstance* with the conflict. *UsingIdsWithNames* contains the ID and name of the *ServiceReservationInstances* overlapping and using the same service ID.|
|ResourceCapabilityInvalid| The *ReservationInstance* tries to book a capability that does not exist on the resource. | *SubjectId* contains the ID of the *ReservationInstance*. <br>*ResourceId* contains the ID of the resource being used. <br>*ResourceCapabilityUsage* contains the invalid capability usage.|
|ReservationUpdateCausedReservations&shy;ToGoToQuarantine| The *ReservationInstance* cannot be created or updated because some bookings would go into quarantine. | *MustBeMovedToQuarantine* contains the bookings and their usage that must be moved. |
|ModuleNotInitialized| The ResourceManager is not initialized yet, the request cannot be handled. | None. |
|UnknownError| An unexpected error happened. | *Message* could contain more information. |
|NotAllowed| The user does not have the necessary permissions to create, read, update or delete the *ReservationInstance*. | *SubjectId* contains the ID of the *ReservationInstance*. <br>*Message* will contain more details about the missing permission. |
|ServiceDefinitionTypeDoesNotMatch|The *ServiceDefinitionType* of the *ReservationInstance* does not match with the type defined on the service definition. | *ReservationInstanceType* contains the type on the *ReservationInstance*. |

#### Restrictions on property names

Because custom properties of resources and bookings (i.e. *ReservationInstances*) are indexed in the database, some restrictions apply to the names of these properties. The following validation is done:

- Property names must not start with an underscore (`_`).
- Property names must not contain a period (`.`), hashtag (`#`), asterisk (`*`), comma (`,`), double quotation mark (`"`), or single quotation mark (`'`).
- Property names must not be empty or contain only whitespace characters.
- Property values must not be null.
