---
uid: DOM_managers
---

# DOM managers

A DOM manager (or `DomManager` in the code) manages create, read, update, and delete (CRUD) actions performed on DOM objects. Multiple DOM manager instances can be used at the same time in a DMS, for instance for invoicing, planned maintenance, etc.

A DOM manager sends out various [events](xref:DOM_events) when actions are done on the DOM objects and tracks the [history](xref:DOM_history) of all changes done to the field values of a DOM instance. It also allows you to configure the [status system](xref:DOM_status_system) for a DOM definition.

A DOM manager gets initialized in SLNet as soon as the first call arrives for it. For this reason, the first call may take longer than others.

To create a DOM manager, you first need to create a [ModuleSettings](xref:DOM_ModuleSettings) object, which includes a **unique module ID** that is used to identify the DOM manager instance in the DMS.

In the module settings, you can also configure the behavior of the DOM manager. You can for example define the permissions that will be needed for the various script actions, or you can enable information events:

```csharp
var moduleSettings = new ModuleSettings(moduleId:"my_module")
{
   DomManagerSettings = new DomManagerSettings()
   {
      // Secure DomInstance deletion with PlmDeleteDomInstances permission
      SecuritySettings = new DomManagerSecuritySettings()
      {
         DeleteDomInstancePermission = PermissionFlags.PlmDeleteDomInstances
      },

      // Enable information events
      InformationEventSettings = new DomManagerInformationEventSettings()
      {
         Enable = true
      }
   }
};
```

Once a `ModuleSettings` object with a specific [moduleID](xref:DOM_ModuleId) has been created, you can start to interact with the DOM manager.

When you send a message to create a DOM instance (e.g. from a script or application), DataMiner will check whether a DOM manager instance with the specified module ID already exists or not. If it does not exist yet, DataMiner will check if it is allowed to create a new DOM manager by trying to retrieve the module settings for that ID. If valid module settings are found, the DOM manager instance will be created and initialized. It will handle the message and send a response.

> [!NOTE]
>
> - If no `ModuleSettings` object is found for a module ID, a DataMiner exception will be thrown.
> - When multiple requests for the same manager are sent in a rapid succession, the system will wait until the first request has initialized the manager. Once that is done, all requests will be handled by that manager, and a response will be returned for each of them.
