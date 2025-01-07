---
uid: SRM_properties_Booking_Manager
---

# SRM properties for use with the Booking Manager app

The overview below lists the different properties you can use for service definitions and other SRM objects when you use the Booking Manager standard app.

For each property, the scope indicates where the property should be specified. For example, if the scope is "Service definition node", you should specify the property on a node of a service definition.

The overview also indicates the type of value that is expected for each property, e.g. string or integer, and whether the property is mandatory or not.

- [Allowed Resource Type](#allowed-resource-type)

- [ApplyProfileScript](#applyprofilescript)

- [Auto Select Resource](#auto-select-resource)

- [BlockInfo](#blockinfo)

- [ConfigurationOrder](#configurationorder)

- [Contributing Configuration](#contributing-configuration)

- [Created Booking Action](#created-booking-action)

- [Data Transfer Rules Configuration](#data-transfer-rules-configuration)

- [Enhanced Protocol](#enhanced-protocol)

- [ExposedParentInterfaceId](#exposedparentinterfaceid)

- [FilterProfileInstance](#filterprofileinstance)

- [HideFromWizard](#hidefromwizard)

- [HideIfResourceAvailable](#hideifresourceavailable)

- [IsContributing](#iscontributing)

- [IsProfileInstanceOptional](#isprofileinstanceoptional)

- [NoConnectivityCheck](#noconnectivitycheck)

- [Options](#options)

- [Priority](#priority)

- [ReadOnlyResourceSelectionControl](#readonlyresourceselectioncontrol)

- [Resource Assignment](#resource-assignment)

- [Resource Pool](#resource-pool)

- [Resource Sorting Capacity](#resource-sorting-capacity)

- [Reuse Contributing Resource](#reuse-contributing-resource)

- [Service Profile Data Transfer Configuration](#service-profile-data-transfer-configuration)

- [Virtual Platform](#virtual-platform)

### Allowed Resource Type

**Scope**: Service definition node

**Type**: String

**Mandatory**: No

This property can be used to assign a “pool” resource to the node of a service definition. This way, when a booking is created, only the configured pool resources will be available. When the booking starts or another relevant event occurs, the pool resource can be exchanged for a regular resource.

To configure this, set the value of the property to *PoolResource*. In addition, make sure the *Pool Resource* option is enabled in the Booking Manager (on the *Config* > *Wizard* tab), and the pool resources are configured with the capability *Resource Type* and value *PoolResource*.

Other supported values for this property are:

- *Regular*: Only resources that are not configured as pool resources will be available.

- *All*: All resources are available, regardless of whether they are pool resources or not. If the property is not defined, this value is assumed by default.

### ApplyProfileScript

**Scope**: Service definition node

**Type**: String

**Mandatory**: No

This property is used to define the script that should be executed when the Profile-Load Script is applied on a contributing DVE. The script can have custom code to go through the details of the contributing booking and do actions on included resources.

Either just use the script name as the property value, or specify the script in the following JSON format: *{"ScriptName":"My_Script_Name", "ExtraParameters":{"Param1":"Value1","Param2":"Value2, (...), "ParamN":"ValueN"}}*. "ExtraParameters" represents the input parameters of the script.

> [!NOTE]
> Ideally, the Profile-Load Script should always be defined on the profile definition. The *ApplyProfileScript* property should only be used if that is not possible for some reason.

**Example value**:

```json
{"ScriptName":"SRM_ProfileLoadScript_Transport"}
```

### Auto Select Resource

**Scope**: Service definition node

**Type**: String

**Mandatory**: No

This property allows you to indicate whether a resource should be assigned to a node automatically or not.

Set this property to *True*, *False*, or *Always*.

> [!TIP]
> See also: [Customizing automatic resource selection](xref:Service_Orchestration_resources_advanced#customizing-automatic-resource-selection)

### BlockInfo

**Scope**: Service definition

**Type**: String

**Mandatory**: No

This property allows you to override the custom booking block information (configured on the *Config* > *Timeline* tab of the Booking Manager) for a specific service definition.

Set the value to a JSON code block as illustrated below. In this code, the order of each item must always be specified, as this will determine the order in which the items are displayed (1 = the highest).

**Example value**:

```json
[
 { "BlockInfo": "FixedString", "Order":3},
 { "BlockInfo": "Name: [BOOKINGNAME]", "Order": 1},
 { "BlockInfo": "Friendly Reference: [PROPERTY:FriendlyReference]", "Order": 2}
]
```

### ConfigurationOrder

**Scope**: Service definition node

**Type**: Integer

**Mandatory**: No

This property determines the order in which resources should be assigned to nodes in the Booking Wizard.

Set the value to an integer indicating the position of the resource for this node in the order, e.g. 2.

> [!TIP]
> See also: [Defining the resource selection sequence](xref:Service_Orchestration_resources_advanced#defining-the-resource-selection-sequence)

### Contributing Configuration

**Scope**: Service definition

**Type**: String

**Mandatory**: No

This property is used to define how to generate a contributing booking for a specific service definition. (See [Configuring contributing bookings](xref:Service_Orchestration_contrib_bookings#configuring-contributing-bookings).)

The JSON value of this property can contain the following fields:

- *CandidateResources*: Optional. The resources that should be used per node. You can specify a list of resources for each node. In case no resources are specified or none of the specified resources are available, the system will select the first available resource from the global list of resources.

- *Concurrency*: Integer defining the maximum concurrency for the contributing resource (i.e. the number of overlapping bookings allowed to make use of the resource).

- *ConvertToContributing*:  Determines whether the *Convert to Contributing* checkbox is selected by default (*true*) or not (*false*).<!-- RN 28069 -->

- *LifeCycle*: The type of lock life cycle, which can be *Locked* or *Unlocked*. *Locked* means the timing of the contributing booking is tied to that of the main booking; *Unlocked* means it is independent from the main booking. See [Locked or unlocked](xref:Service_Orchestration_contrib_bookings#locked-or-unlocked).

- *LiteContributingResource*: Optional. Determines whether a lite contributing resource is used. If the property is not specified, regular contributing resources will be created. See [Enabling lite contributing bookings](xref:Service_Orchestration_contrib_bookings#enabling-lite-contributing-bookings).<!-- RN 31182 -->

- *OrchestrationTrigger*: *Local* or *Main*. If set to *Main*, the service state will not be updated and LSO will not be triggered. See [Main or local](xref:Service_Orchestration_contrib_bookings#main-or-local).

- *ParentSystemFunction*: The GUID of the system function that defines the signature of the contributing resource.

- *PostRoll*: Optional. The post-roll interval in minutes. Only used for Dijkstra use case.

- *PreRoll*: Optional. The pre-roll interval in minutes. Only used for Dijkstra use case.

- *ReservationAppendixName*: Optional. String that will be appended to the booking name.

- *ReservationType*: Optional. Only used for Dijkstra use case. Represents the type of booking, i.e.:

  - *Standalone*

  - *Permanent*: The contributing booking remains permanently available.

  - *FollowMain*: The contributing booking follows the main booking.

- *ResourcePool*: The name of the resource pool in which the contributing resource should be included.

- *Script*: Optional. Defines a custom Automation script that can be triggered after creating the contributing booking. It is typically used to assign capabilities/capacities to the associated contributing resource. Configured in the format "*Script:Script Name\|\|Parameter Name 1=Parameter 1;Parameter Name 2=Parameter 2;...*". The *\[RESERVATIONID\]* and *\[RESOURCEID\]* placeholders can be used, representing the resulting contributing booking ID and resource ID, respectively.<!-- RN 28243 & 28961 -->

- *VisioFileName*: The Visio drawing that should be used for the contributing booking. While in other cases the Visio file configured in the service definition is used when a contributing booking is generated, when it is generated based on a *Path* parameter, the Visio file must be explicitly mentioned with this option.

**Example value**:

```json
{
    "CandidateResources":null,
    "Concurrency":310,
    "ConvertToContributing":true,
    "LifeCycle":"Locked",
    "OrchestrationTrigger":"Local",
    "ParentSystemFunction":"b91f59c8-58f2-4422-9a28-f0a6bf815ab0",
    "PostRoll":0,
    "PreRoll":0,
    "ReservationAppendixName":"V46GQJ",
    "ReservationType":"Standalone",
    "ResourcePool":"SDMN.SAT.Resource Pool",
    "Script":"Script:SRM_DummyScript||DummyParameterName=DummyValue",
    "VisioFileName":null
}
```

### Created Booking Action

**Scope**: Service definition node

**Type**: String

**Mandatory**: No

This property defines the Automation script that should be executed when a booking is confirmed.

The value of this property should be configured in JSON format. It can contain script parameters, but script dummies are not supported. You can also use the *\[RESERVATIONID\]* placeholder to represent the GUID of the booking.

**Example value**:

```json
{"Script":"Script:UpdateJob||BookingId=[RESERVATIONID]"}
```

> [!TIP]
> See also: [Configuring a custom Created Booking Action](xref:Service_Orchestration_life_cycle_states#configuring-a-custom-created-booking-action)

### Data Transfer Rules Configuration

**Scope**: Service definition

**Type**: String

**Mandatory**: No

This property is used to transfer data between nodes of a booking. When a profile instance or resource is selected, a custom DTR script can be executed to set a value on another node.

As the value of this property, in JSON, specify the script that implements the transfer logic and the parameters, resources or profile instances of which a change will trigger the script.

> [!TIP]
> See also: [Service Orchestration Data Transfer Rules configuration](xref:Service_Orchestration_DTR)

**Example values**:

```json
{
    "Script":"SRM_ApplyDataTransferRules",
    "Triggers":[{
            "InterfaceId":null,
            "NodeLabel":"Demodulating",
            "ParameterName":"RF Modulation",
            "TriggerType":"Parameter"
        }
    ]
}
```

The property value above will cause the script "SRM_ApplyDataTransferRules" to be triggered every time the parameter "RF Modulation" on the node with label "Demodulating" changes.

```json
{
    "Script":"SRM_ApplyDataTransferRules",
    "Triggers":[{
            "NodeLabel":"Demodulating",
            "TriggerType":"Resource"
        }
    ]
}
```

The property value above will cause the script "SRM_ApplyDataTransferRules" to be triggered whenever the resource on the node with label "Demodulating" changes.

```json
{
 "Script": "SRM_DataTransferRulesTemplate",
 "Triggers": [
 {
 "NodeLabel": "Demodulator 1",
 "TriggerType": "ProfileInstance"
 },
 {
 "InterfaceId": 11,
 "NodeLabel": "Demodulator 1",
 "TriggerType": "ProfileInstance"
 }
 ]
}
```

The property value above will cause the script "SRM_DataTransferRulesTemplate" to be triggered whenever the profile instance on the node with label "Demodulator 1" changes.

### Enhanced Protocol

**Scope**: Service definition

**Type**: String

**Mandatory**: No

This property is used to assign a custom enhanced protocol to a service.

As the value of this property, in JSON, specify the name and version of the protocol.

**Example value**:

```json
{"ProtocolName" : "MyProtocol", "ProtocolVersion": "1.0.0.1"}
```

### ExposedParentInterfaceId

**Scope**: Service definition node interface

**Type**: Integer

**Mandatory**: No

This property is used when a booking is converted to a contributing booking, to map a node interface of a contributing service definition to an interface of the associated system function.

While this mapping is not mandatory, if it is not configured, some parameters or interfaces may not be available in the generated function protocol. Note also that if two interfaces are configured with the same *ExposedParentID* property value, the conversion will not be possible.

Set this property to an integer value corresponding with the parent system function interface ID, e.g. 1.

### FilterProfileInstance

**Scope**: Resource

**Type**: String

**Mandatory**: No

Set this property to *Yes* to filter the available profile instances for a node in the Booking Wizard based on the capabilities of the selected resource.

> [!TIP]
> See also: [Filtering profile instances based on resource selection](xref:Service_Orchestration_profile_instances#filtering-profile-instances-based-on-resource-selection)

### HideFromWizard

**Scope**: Service definition

**Type**: String

**Mandatory**: No

Set the value of this property to *TRUE* to hide a service definition from the Booking Wizard.

> [!TIP]
> See also: [Hiding a service definition in the Booking Manager app](xref:Service_Orchestration_service_definition_advanced#hiding-a-service-definition-in-the-booking-manager-app)

### HideIfResourceAvailable

**Scope**: Service definition node

**Type**: String

**Mandatory**: No

This property allows you to hide a service definition node in the Booking Wizard if a valid resource is available that can be assigned to the node. Though the node will not be displayed, the resource will be selected and included in the booking automatically.

Set this property to *Yes* to hide the node if a resource is available.

> [!TIP]
> See also: [Hiding resource selection if a resource is available](xref:Service_Orchestration_resources_advanced#hiding-resource-selection-if-a-resource-is-available).

### IsContributing

**Scope**: Service definition node

**Type**: String

**Mandatory**: Yes, when contributing bookings are used

This property identifies a contributing node in a service definition, so that the Booking Manager knows that a contributing booking may need to be created for this node.

Set the property to *TRUE* to indicate that a node is a contributing node.

> [!TIP]
> See also: [Configuring contributing bookings](xref:Service_Orchestration_contrib_bookings#configuring-contributing-bookings)

### IsProfileInstanceOptional

**Scope**: Service definition node or service definition node interface

**Type**: String

**Mandatory**: No

This property allows you to indicate that profile instance selection is optional for a specific node. This means that a booking can be confirmed even if no profile instance is selected for the node.

Set this property to *TRUE* to mark profile instance selection as optional.

> [!TIP]
> See also: [Setting a profile instance as optional](xref:Service_Orchestration_profile_instances#setting-a-profile-instance-as-optional)

### NoConnectivityCheck

**Scope**: Service definition node interface

**Type**: String

**Mandatory**: No

This property allows you to configure an interface that is not connected. This is also used in the context of contributing bookings to indicate interfaces that are not connected.

If this property is not configured or set to *FALSE*, a disconnected interface is not handled. If the property is set to *TRUE*, the disconnected interface is loaded and displayed in the Booking Wizard.

> [!TIP]
> See also: [Allowing profile instance configuration for disconnected interfaces](xref:Service_Orchestration_profile_instances#allowing-profile-instance-configuration-for-disconnected-interfaces)

### Options

**Scope**: Service definition node

**Type**: String

**Mandatory**: No

This property can be set to a list of several options, separated by pipe (“\|”) characters. At present the following options are supported:

- *Optional*: Marks a node as optional, so that it is possible to create a booking even if no resource is selected for this node.

- *Hide*: Hides the node from the Booking Wizard.

> [!TIP]
> See also:
>
> - [Hiding resource selection for a specific node](xref:Service_Orchestration_resources_advanced#hiding-resource-selection-for-a-specific-node)
> - [Making resource selection optional for a node](xref:Service_Orchestration_resources_advanced#making-resource-selection-optional-for-a-node)

### Priority

**Scope**: Resource

**Type**: Integer

**Mandatory**: No

This property allows you to define a priority for the resource, which is used to sort resources that are displayed for resource selection in the Booking Wizard.

Set this property to an integer representing the priority of the resource, e.g. 5.

> [!TIP]
> See also: [Resource sorting configuration](xref:Service_Orchestration_resources_advanced#resource-sorting-configuration)

### ReadOnlyResourceSelectionControl

**Scope**: Service definition node

**Type**: String

**Mandatory**: No

This property allows you to set the resource selection control for a specific node to read-only.

To do so, set the property to *TRUE*.

> [!TIP]
> See also: [Disabling resource selection in the UI](xref:Service_Orchestration_resources_advanced#disabling-resource-selection-in-the-ui)

### Resource Assignment

**Scope**: Service definition node

**Type**: String

**Mandatory**: No

This property allows you to define pre-filtering conditions based on resource capabilities.

Specify the conditions in JSON format as illustrated below. Only "AND" combinations are supported.

**Example value**:

```json
{
 "Condition":"<A>",
 "Value":[{
 "Label":"A",
 "Type":"Operation",
 "Value":{
 "FirstOperand":
 {
 "Link":"[var:ENC-Vendor]"
 },
 "Operator":"=",
 "SecondOperand":
 {
 "Link":"RESOURCE",
 "Capability":"ENC-Vendor"
 }
 }
 }
 ]
}
```

> [!TIP]
> See also: [Setting up additional pre-filtering](xref:Service_Orchestration_resources_advanced#setting-up-additional-pre-filtering).

### Resource Pool

**Scope**: Service definition node

**Type**: String

**Mandatory**: No

This property allows you to indicate the resource pool from which candidate resources should be selected for this node. By default, the Booking Manager will search for a resource pool with a name starting with the virtual platform name, followed by a period.

For example, if you set this property to *Satellites*, and the virtual platform is set to *SDMN*, the app will look for a resource pool with the name *SDMN.Satellites*.

### Resource Sorting Capacity

**Scope**: Service definition node

**Type**: String

**Mandatory**: No

This property is used to sort resources for a specific node in the Booking Wizard based on available capacity.

To configure this, on the *Config* > *Wizard* tab of the Booking Manager, set *Resources Ordering Rule* to *Capacity*. Then set the *Resource Sorting Capacity* property to the name of the capacity that should be used for sorting, e.g. *Bandwidth*.

> [!NOTE]
> If *Resources Ordering Rule* is set to *Capacity* but this property is not defined, the first available capacity will be used for sorting.

> [!TIP]
> See also: [Resource sorting configuration](xref:Service_Orchestration_resources_advanced#resource-sorting-configuration).

### Reuse Contributing Resource

**Scope**: Service definition node

**Type**: String

**Mandatory**: No

This property allows you to indicate whether the Service Profile Wizard should create a new contributing booking for this node or use an existing contributing booking if available.

Set this property to *TRUE* to indicate that existing contributing bookings should be reused for the node.

> [!TIP]
> See also: [Enabling reuse of contributing bookings](xref:Service_Orchestration_service_definition_advanced#enabling-reuse-of-contributing-bookings)

### Service Profile Data Transfer Configuration

**Scope**: Service profile definition or service profile instance

**Type**: String

**Mandatory**: No

This property allows you to define the script that should be launched during booking creation in order to transfer data between nodes or between main and contributing booking or vice versa. This is only applicable for bookings created using the Service Profile Wizard.

Set this property to a JSON object with a *Script* key, as illustrated below.

If the property is defined both on instance and on definition level, the instance level takes precedence. If several service profiles have a configuration defined, the scripts will be executed top-down.

> [!TIP]
> See also: [Configuring service profile Data Transfer Rules](xref:Service_Orchestration_DTR#configuring-service-profile-data-transfer-rules)

**Example value**:

```json
{"Script":"SRM_ServiceProfileDataTransferExample"}
```

### Virtual Platform

**Scope**: Service definition

**Type**: String

**Mandatory**: Yes

This property should be set to the name of the virtual platform. This is used to filter the list of candidate service definitions and candidate resources in the Booking Wizard.

**Example value**: SDMN
