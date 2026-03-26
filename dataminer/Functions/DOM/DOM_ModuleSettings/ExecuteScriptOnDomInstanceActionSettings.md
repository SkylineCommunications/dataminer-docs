---
uid: ExecuteScriptOnDomInstanceActionSettings
---

# ExecuteScriptOnDomInstanceActionSettings

>[!NOTE]
> From 10.4.2/10.5.0 onwards<!-- RN 37963 -->, it is possible to override this setting in a `DomDefinition` with the [ModuleSettingsOverrides](xref:DomDefinition#modulesettingsoverrides) property.

This settings object contains the names of the scripts that should be executed after a [DomInstance](xref:DomInstance) is created, updated, or deleted. If no name is filled in, no script will be executed. From DataMiner version 10.3.10/10.4.0 onwards, it is also possible to define which type of script (entry point) should be executed. In earlier DataMiner versions, only the "ID only" type is supported. From DataMiner 10.5.3/10.6.0 onwards<!-- RN 41780 -->, conditions are supported that allow you to define whether the configured update script should be executed for a `DomInstance` update.

|Property |Type   |Description |
|---------|-------|------------|
|OnCreate |string |Name of the script that will be executed after each `DomInstance` is created in this module. |
|OnUpdate |string |Name of the script that will be executed after each `DomInstance` is updated in this module. |
|OnDelete |string |Name of the script that will be executed after each `DomInstance` is deleted in this module. |
|ScriptType |OnDomInstanceActionScriptType |Type of the script that should be executed. See [Script types](#script-types). |
|OnUpdateTriggerConditions |List&lt;IDomCrudScriptTriggerCondition&gt; |Conditions of which one has to be met before the update script is triggered. See [Conditions](#conditions). |

## Script types

There are currently two types of script, which each have their own unique entry point method:

1. [**ID only**](#id-only-type): Default. Uses the `OnDomInstanceCrud` entry point method. Gives you access to the CRUD type and the ID of the `DomInstance` in the script.
1. [**Full CRUD meta**](#full-crud-meta-type): Recommended. Uses the `OnDomInstanceCrudWithFullMeta` entry point method. Gives you access to the CRUD type and the full `DomInstance` object(s). Available from DataMiner version 10.3.10/10.4.0 onwards.

> [!NOTE]
> Prior to DataMiner versions 10.5.0/10.5.2<!-- RN 41536 -->, a "Script started" information event is generated when any of the configured scripts are launched. To reduce the load on the database, this no longer happens from those DataMiner versions onwards.

### ID Only type

When the "ID Only" type (`IdOnly` enum value) is selected, the automation script needs to contain an entry point method that has the `AutomationEntryPoint` attribute with argument `AutomationEntryPointType.Types.OnDomInstanceCrud`. When the CRUD action is executed, this method will be called with the following arguments:

|Argument |Type     |Description |
|---------|---------|------------|
|engine   |IEngine  |The object that can be used to interact with the DataMiner System. |
|id       |Guid     |The ID of the `DomInstance` that was created, updated, or deleted. |
|crudType |CrudType |The type of action that this script was triggered for (Create, Update, Delete). Note that the `CrudType` type used here resides in the `Skyline.DataMiner.Net.History` namespace. Make sure to include this in the using statements. |

```csharp
using System;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.History;

public class Script
{
    [AutomationEntryPoint(AutomationEntryPointType.Types.OnDomInstanceCrud)]
    public void OnDomInstanceCrud(Engine engine, Guid id, CrudType crudType)
    {
        engine.GenerateInformation($"Script triggered for {crudType} action on DomInstance with ID: {id}");
    }
}
```

### Full CRUD meta type

When the "Full CRUD meta" type (`FullCrudMeta` enum value) is selected, the automation script needs to contain an entry point method that has the `AutomationEntryPoint` attribute with argument `AutomationEntryPointType.Types.OnDomInstanceCrudWithFullMeta`. When the CRUD action is executed, this method will be called with the following arguments:

|Argument |Type                |Description |
|---------|--------------------|------------|
|engine   |IEngine             |The object that can be used to interact with the DataMiner System. |
|crudMeta |DomInstanceCrudMeta |The meta object containing all the information on the CRUD action. See below. |

This entry point has only one main argument, `DomInstanceCrudMeta`, which has the following properties:

|Property        |Type        |Description |
|----------------|------------|------------|
|CrudType        |CrudType    |The type of action that this script was triggered for (Create, Update, Delete). Note that the `CrudType` type used here resides in the `Skyline.DataMiner.Net.Apps.DataMinerObjectModel.General` namespace. Make sure to include this in the using statements when you want to compare its values.|
|CurrentVersion  |DomInstance |A full `DomInstance` object that represents the version at the point in time when the CRUD action was executed. |
|PreviousVersion |DomInstance |A full `DomInstance` object that represents the previous version when an update action is executed. Will contain "null" for the other actions. |

```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;

public class Script
{
    [AutomationEntryPoint(AutomationEntryPointType.Types.OnDomInstanceCrudWithFullMeta)]
    public void OnDomInstanceCrudWithFullMeta(IEngine engine, DomInstanceCrudMeta crudMeta)
    {
        engine.GenerateInformation($"Script triggered for {crudMeta.CrudType} action on DomInstance with name: {crudMeta.CurrentVersion.Name}");
    }
}
```

#### Calculating changes done to a DOM instance in a CRUD script

From DataMiner 10.4.3/10.5.0 onwards<!-- RN 38364 -->, it is possible to calculate the changes done to a `DomInstance` in a CRUD script using the `GetDifferences` method on the `DomInstanceCrudMeta` object.

The `GetDifferences` method returns an object `DomInstanceDifferences`. This contains the differences of the `DomInstance`:

- DomInstanceDifferences:
  - FieldValues: All changes.
    - Created: Changes where a new value was added.
    - Updated: Changes where a value was updated.
    - Deleted: Changes where a value was removed.

Examples:

```csharp
var differences = crudMeta.GetDifferences(); // Generate the differences

var allDifferences = differences.FieldValues; // All value differences (created, updated & deleted values)
var createdDifferences = differences.FieldValues.Created; // Only created values
var updatedDifferences = differences.FieldValues.Updated; // Only updated values
var deletedDifferences = differences.FieldValues.Deleted; // Only deleted values
```

These all return a `FieldValueDifferences` object.

On these `FieldValueDifferences`, you can apply different methods to further filter the results:

| Method                                       | Type                         | Description                                                                                          |
|----------------------------------------------|------------------------------|------------------------------------------------------------------------------------------------------|
| OfType(\<CrudType\>)                         | FieldValueDifferences        | Returns the differences with a certain `CrudType` (Create, Update or Delete).                        |
| OfFieldDescriptor(\<FieldDescriptorID\>)     | FieldValueDifferences        | Returns the differences on a certain `FieldDescriptor`.                                              |
| OfSectionDefinition(\<SectionDefinitionID\>) | FieldValueDifferences        | Returns the differences within a certain `SectionDefinition`.                                        |
| Get()                                        | List\<FieldValueDifference\> | Returns the differences as a list of `FieldValueDifference` objects, considering the filter methods. |

These methods can be chained to create specific conditions to get your desired differences. In most situations, the `Get()` method should be applied at the end, to get a list of `FieldValueDifference` objects and use the properties it contains.

Examples:

```csharp
// Getting all created values of a certain SectionDefinition:
var differences = crudMeta.GetDifferences().FieldValues.OfType(CrudType.Create).OfSectionDefinition(SectionDefinitionId).Get();

// Getting all updated values of a certain SectionDefinition:
var differences = crudMeta.GetDifferences().FieldValues.OfSectionDefinition(SectionDefinitionId).OfType(CrudType.Update).Get();

// Getting all updated values on a certain FieldDescriptor:
var differences = crudMeta.GetDifferences().FieldValues.Updated.OfFieldDescriptor(FieldDescriptorId).Get();

// Getting all deleted values on a certain FieldDescriptor:
var differences = crudMeta.GetDifferences().FieldValues.OfFieldDescriptor(FieldDescriptorId).OfType(CrudType.Delete).Get();
```

This `FieldValueDifferences` object contains a list of `FieldValueDifference` objects. These objects have some properties:

| Property            | Type                | Description                                                            |
|---------------------|---------------------|------------------------------------------------------------------------|
| Type                | CrudType            | The `CrudType` of the changed `FieldValue` (Create, Update or Delete). |
| ValueBefore         | IValueWrapper       | The value of the `FieldValue` before the change.                       |
| ValueAfter          | IValueWrapper       | The value of the `FieldValue` after the change.                        |
| FieldDescriptorId   | FieldDescriptorID   | The `FieldDescriptor` ID of the changed `FieldValue`.                  |
| SectionId           | SectionID           | The ID of the `Section` that this changed `FieldValue` is part of.     |
| SectionDefinitionId | SectionDefinitionID | The `SectionDefinitionID` of the changed `FieldValue`.                 |

This example script generates an information event stating the differences whenever a `DomInstance` is created, updated, or deleted:

```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel.General;

namespace Example
{
    public class Script
    {
        [AutomationEntryPoint(AutomationEntryPointType.Types.OnDomInstanceCrudWithFullMeta)]
        public void OnDomInstanceCrudWithFullMeta(IEngine engine, DomInstanceCrudMeta crudMeta)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"CRUD script triggered by the '{crudMeta.CrudType}' action on DomInstance with name '{crudMeta.CurrentVersion.Name}'. Changes:");
        
            var differences = crudMeta.GetDifferences().FieldValues.Get();
        
            foreach (var difference in differences)
            {
                var crudType = "";
                switch (difference.Type)
                {
                    case CrudType.Create:
                        crudType = "CREATED";
                        break;
                    case CrudType.Update:
                        crudType = "UPDATED";
                        break;
                    case CrudType.Delete:
                        crudType = "DELETED";
                        break;
                }
        
                sb.AppendLine($"{crudType}: ID: '{difference.FieldDescriptorId.Id}', Change: '{difference.ValueBefore}' -> '{difference.ValueAfter}'");
            }

            engine.GenerateInformation(sb.ToString());
        }
    }
}
```

## Conditions

From DataMiner 10.5.3/10.6.0 onwards<!-- RN 41780 -->, conditions can be used to prevent the update script from being triggered for each and every `DomInstance` update. This allows you to make a solution more efficient as no unnecessary script triggers are executed. These conditions can be configured by instantiating one of the supported condition classes and adding it to the `OnUpdateTriggerConditions` collection property on the `ExecuteScriptOnDomInstanceActionSettings`. The conditions are evaluated using a logical 'OR', meaning that only one condition needs to be true for the script to trigger.

> [!IMPORTANT]
> When you configure conditions, the update script will no longer be triggered when a status transition is done. A status-related condition to define a trigger based on a specific status is currently not available.

### FieldValueUpdatedTriggerCondition

This condition type allows you to check whether a `FieldValue` for a given `FieldDescriptor` has been added, updated, or removed. It also supports multiple sections, meaning the condition will be met if:

- A **new** `FieldValue` is added in a new or existing `Section`.
- An **existing** `FieldValue` is deleted from a deleted or existing `Section`.

To use this condition, define the ID of the `FieldDescriptor` by passing it to the condition's constructor.

Example:

```csharp
var licensePlate = new FieldDescriptorID(Guid.Parse("81915fe0-8f55-4ad1-8da5-3b703f9e7842"));
var insuranceId = new FieldDescriptorID(Guid.Parse("7cd4366c-983c-46d2-aa92-e0308a3102e5"));

moduleSettings.DomManagerSettings.ScriptSettings.OnUpdateTriggerConditions = new List<IDomCrudScriptTriggerCondition>
{
   new FieldValueUpdatedTriggerCondition(licensePlate),
   new FieldValueUpdatedTriggerCondition(insuranceId)
};
```
