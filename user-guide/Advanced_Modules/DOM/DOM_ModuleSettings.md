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
var settings = new ModuleSettings("my_module");

// Save the settings
helper.ModuleSettings.Create(settings);
```

> [!NOTE]
> When you update the module settings of a manager that is already running, this will only take effect when the manager is (re-)initialized. This happens when:
>
> - You send a `ManagerStoreReinitializeCustomManagerRequest` in a script. This will reinitialize the manager on all Agents in the cluster. If a manager is not present on one of the Agents, it will be ignored. Initialize the `ManagerStoreReinitializeCustomManagerRequest` message with the name of the module that needs to be reinitialized and *DomManager* as the manager name.
> - DataMiner is restarted. If a DataMiner Agent is restarted, the manager running on that DMA is restarted using the new settings. You will therefore need to restart all DMAs that have a running instance of the manager.
> - You send a *ManagerStoreReinitializeCustomManagerRequest* using the DOM page in the [SLNetClientTest tool](xref:SLNetClientTest_tool). To do so, first [connect to the DMA in the tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool), and then go to *Advanced* > *Apps* > *DataMiner Object Model* and click the *Reinitialize* button.

## Errors

When something goes wrong while the `ModuleSettings` are saved, the `TraceData` will contain one or more `ModuleSettingsManagerErrorData` errors. They can have the following `ErrorReasons`:

| Reason | Description |
|--|--|
| InvalidModuleId | The module ID does not meet the requirements. The *InvalidModuleId* property contains the module ID that is invalid. The *ModuleIdValidationResult* contains the exact reason why the ID was deemed invalid. |
| InvalidPermissions | The user does not have permission to do this action. |

## Available settings

The current settings structure (with regards to `DomManager`) is as follows:

- ModuleSettings

  - [Module ID](xref:DOM_ModuleId) (string)

  - DomManagerSettings

    - [ModuleSections](xref:DOM_ModuleSections) (List)

    - [FieldAliases](xref:DOM_FieldAliases) (List)

    - [ExecuteScriptOnDomInstanceActionSettings](xref:ExecuteScriptOnDomInstanceActionSettings)

    - [DomManagerInformationEventSettings](xref:DomManagerInformationEventSettings)

    - [DomInstanceNameDefinition](xref:DomInstanceNameDefinition)

    - [ModuleBehaviorDefinition](xref:DOM_ModuleBehaviorDefinition)

    - [TtlSettings](xref:DOM_TtlSettings)

    - [DomInstanceHistorySettings](xref:DOM_DomInstanceHistorySettings)

    - [StorageSettings](xref:DOM_StorageSettings)

## Notes

- The module settings are saved in a separate Elasticsearch index (dms-cmodulesettings-xxx).

- Issues/events are logged in the *SLModuleSettingsManager.txt* log file.

- Only users with the [Module Settings](xref:DataMiner_user_permissions#modules--system-configuration--object-manager--module-settings) permission can create, delete, or update module settings.

- To include the module settings in a [custom backup](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube#configuring-the-dataminer-backups) in Cube, select *Create a backup of the database* > *Include module specific configuration data*.

- There are no license checks when module settings are added.

- From DataMiner 10.3.2/10.4.0 onwards, the `ModuleSettings` object also has [the *ITrackBase* properties](xref:DOM_objects#itrackbase-properties).

- From DataMiner 10.3.5/10.4.0 onwards, you can remove a DOM manager from your system using [the SLNetClientTest tool](xref:SLNetClientTest_removing_DOM_Manager).
