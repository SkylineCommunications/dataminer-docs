---
uid: ExecuteScriptOnDomInstanceActionSettings
---

# ExecuteScriptOnDomInstanceActionSettings

This settings object contains the names of the scripts that should be executed after a [DomInstance](xref:DomInstance) is created, updated, or deleted. If no name is filled in, no script will be executed. Since DataMiner version 10.3.10/10.4.0, it is also possible to define which type of script (entry point) should be executed. Prior to this version, only the 'ID only' type was supported.

|Property |Type   |Description |
|---------|-------|------------|
|OnCreate |string |Name of the script that will be executed after each `DomInstance` is created in this module. |
|OnUpdate |string |Name of the script that will be executed after each `DomInstance` is updated in this module. |
|OnDelete |string |Name of the script that will be executed after each `DomInstance` is deleted in this module. |
|ScriptType |OnDomInstanceActionScriptType |Type of the script that should be executed. See below for more info. |

There are currently two types of scripts which each have their own unique entry point method:

1. [**ID only**](#id-only-type) - (Default) Uses the `OnDomInstanceCrud` entry point method. Gives you access to the CRUD type and the ID of the `DomInstance` in the script.
1. [**Full CRUD meta**](#full-crud-meta-type) - (Recommended) Uses the `OnDomInstanceCrudWithFullMeta` entry point method. Gives you access to the CRUD type and the full `DomInstance` object(s). Available since DataMiner version 10.3.10/10.4.0.

## ID Only type

When the 'ID Only' type (`IdOnly` enum value) is selected, the Automation script needs to contain an entry point method that has the `AutomationEntryPoint` attribute with argument `AutomationEntryPointType.Types.OnDomInstanceCrud`. When the CRUD action is executed, this method will be called with the following arguments:

|Argument |Type     |Description |
|---------|---------|------------|
|engine   |IEngine  |The object which can be used to interact with the DataMiner system. |
|id       |Guid     |The ID of the `DomInstance` which was created, updated or deleted. |
|crudType |CrudType |The type of action where this script was triggered for (Create, Update, Delete). Note that the `CrudType` type used here resides in the `Skyline.DataMiner.Net.History` namespace. Make sure to include this in the using statements. |

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

## Full CRUD meta type

When the 'Full CRUD meta' type (`FullCrudMeta` enum value) is selected, the Automation script needs to contain an entry point method that has the `AutomationEntryPoint` attribute with argument `AutomationEntryPointType.Types.OnDomInstanceCrudWithFullMeta`. When the CRUD action is executed, this method will be called with the following arguments:

|Argument |Type                |Description |
|---------|--------------------|------------|
|engine   |IEngine             |The object which can be used to interact with the DataMiner system. |
|crudMeta |DomInstanceCrudMeta |This meta object contains all the information on the CRUD action. See below. |

This entry point has only one main argument, the `DomInstanceCrudMeta`, which contains:

|Property        |Type        |Description |
|----------------|------------|------------|
|CrudType        |CrudType    |The type of action where this script was triggered for (Create, Update, Delete). Note that the `CrudType` type used here resides in the `Skyline.DataMiner.Net.Apps.DataMinerObjectModel.General` namespace. Make sure to include this in the using statements when you want to compare its values.|
|CurrentVersion  |DomInstance |A full `DomInstance` object that represents the version at the point in time where the CRUD action was executed. |
|PreviousVersion |DomInstance |A full `DomInstance` object that represents the previous version when an update action is executed. Will contain 'null' for the other actions. |

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
