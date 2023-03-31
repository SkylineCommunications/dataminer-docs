---
uid: ExecuteScriptOnDomInstanceActionSettings
---

# ExecuteScriptOnDomInstanceActionSettings

This settings object contains the names of the scripts that should be executed after a [DomInstance](xref:DomInstance) is created, updated, or deleted. If no name is filled in, no script will be executed.

|Property |Type   |Description |
|---------|-------|------------|
|OnCreate |string |Name of the script that will be executed after each `DomInstance` is created in this module. |
|OnUpdate |string |Name of the script that will be executed after each `DomInstance` is updated in this module. |
|OnDelete |string |Name of the script that will be executed after each `DomInstance` is deleted in this module. |

The scripts used must have a `OnDomInstanceCrud` entry point method defined. This makes it possible to know for what action and `DomInstance` the script was triggered.

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
