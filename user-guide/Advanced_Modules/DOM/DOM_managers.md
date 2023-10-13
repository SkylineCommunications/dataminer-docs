---
uid: DOM_managers
---

# DOM managers

A DOM manager manages create, read, update, and delete (CRUD) actions performed on DOM objects. Multiple DOM manager instances can be used at the same time in a DMS, for instance for invoicing, planned maintenance, etc.

A DOM manager sends out various [events](xref:DOM_events) when actions are done on the DOM objects and tracks the [history](xref:DOM_history) of all changes done to the field values of a DOM instance. It also allows you to configure the [status system](xref:DOM_status_system) for a DOM definition.

> [!NOTE]
>
> - Logging for each DOM manager is done in a separate log file with the name "SLDomManager_{moduleId}", e.g. "SLDomManager_my_module.txt".
> - A backup of all DOM manager data can be taken using the backup option *Create a backup of the database* > *Include all DomManager data in backup*. This is by default enabled in the backup preset *Full Backup*. See [Configuring the DataMiner backups](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube#configuring-the-dataminer-backups).

## Module ID

To create a DOM manager, you first need to create a [ModuleSettings](xref:DOM_ModuleSettings) object, which includes a **unique module ID** that is used to identify the DOM manager instance in the DMS. In the module settings, you can also configure the behavior of the DOM manager. You can for example define the permissions that will be needed for the various script actions, or you can enable information events.

## Creation and startup logic

A DOM manager gets initialized in SLNet as soon as the first call arrives for it. For this reason, the first call may take longer than others. When caching is enabled, the initialization time will also depend on the number of DOM configuration objects that are present in the DOM manager. By default, caching is enabled (see [CachingSettings](xref:DOM_StorageSettings#cachingsettings)).

The following logic flow applies:

1. DataMiner receives a message for an unknown manager (e.g. from a script or application).

1. The object type is checked to see if a custom manager can be created.

1. The `ModuleSettings` are retrieved so DataMiner knows the module ID of the request.

1. A manager using these settings is created.

1. The DOM manager instance is created and initialized. It will handle the message and send a response.

> [!NOTE]
>
> - If no `ModuleSettings` object is found for a module ID, a DataMiner exception will be thrown.
> - When multiple requests for the same manager are sent in a rapid succession, the system will wait until the first request has initialized the manager. Once that is done, all requests will be handled by that manager, and a response will be returned for each of them.
