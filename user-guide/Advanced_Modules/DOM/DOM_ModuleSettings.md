---
uid: DOM_ModuleSettings
---

# DOM module settings

The `ModuleSettings` object contains information on how a DOM manager should behave. It contains sub-settings objects that are passed on to the various proxies, i.e. the parts of the manager that determine the behavior of each create, read, update, or delete (CRUD) action.

To create the `ModuleSettings` object, use the `ModuleSettingsHelper`. For example:

```csharp
// Create the helper
var helper = new ModuleSettingsHelper(engine.SendSLNetMessages);

// Create the (empty) settings object
var settings = new ModuleSettings("random_module_name");

// Save the settings
helper.ModuleSettings.Create(settings);
```

> [!NOTE]
> When you update the module settings of a manager that is already running, this will only take effect when the manager is (re-)initialized. This happens when:
>
> - You send a `ManagerStoreReinitializeCustomManagerRequest` in a script. This will reinitialize the manager on all Agents in the cluster. If a manager is not present on one of the Agents, it will be ignored.
> - DataMiner is restarted.
> - You send a *ManagerStoreReinitializeCustomManagerRequest* using the DOM page in the [SLNetClientTest tool](xref:SLNetClientTest_tool). To do so, first [connect to the DMA in the tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool), and then go to *Advanced* > *Apps* > *DataMiner Object Model* and click the *Reinitialize* button.

Note the following:

- The module settings are saved in a separate Elasticsearch index (dms-cmodulesettings-xxx).

- Issues/events are logged in the *SLModuleSettingsManager.txt* log file.

- Only users with the *Module Settings Configuration* permission can create, delete, or update module settings.

- To include the module settings in a [custom backup](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube#configuring-the-dataminer-backups) in Cube, select *Create a backup of the database* > *Include module specific configuration data*.

- There are no license checks when module settings are added.

## Errors

When something goes wrong while the `ModuleSettings` are saved, the `TraceData` will contain one or more `ModuleSettingsManagerErrorData` errors. They can have the following `ErrorReasons`:

| Reason | Description |
| InvalidModuleId | The module ID does not meet the requirements. The error will contain the exact validation error. |
| InvalidPermissions | The user does not have permission to do this action. |

## Available settings

The current settings structure (with regards to `DomManager`) is as follows:

- ModuleSettings

  - Module ID (string)

  - DomManagerSettings

    - ModuleSections (List)

    - FieldAliases (List)

    - ExecuteScriptOnDomInstanceActionSettings

    - DomManagerSecuritySettings

    - DomManagerInformationEventSettings

    - DomInstanceNameDefinition

    - ModuleBehaviorDefinition

    - TtlSettings

## Module ID property

This is the ID (string) used to distinguish between multiple running DOM managers. Since this name is used in the index name of Elasticsearch, a few requirements are in place:

- The ID must not be empty or null.

- The ID must not be longer than 40 characters.

- The ID must be lowercase.

- The ID must not have one of the following characters:

  - "\" (Backslash)
  - "/" (Slash)
  - "*" (Asterisk)
  - "?" (Question Mark)
  - """ (Quotation Mark)
  - "<" (Lesser Than)
  - ">" (Greater Than)
  - "|" (Vertical Bar or Pipe)
  - " " (Space)
  - "," (Comma)
  - "#" (Hashtag)
  - ":" (Colon)
  - "-" (Hyphen)
