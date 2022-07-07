---
uid: DOM_managers
---

# DOM managers

A DOM manager manages create, read, update, and delete actions performed on DOM objects. Multiple DOM manager instances can be used at the same time in a DMS, for instance for invoicing, planned maintenance, etc.

A DOM manager sends out various [events](xref:DOM_events) when actions are done on the DOM objects and tracks the [history](xref:DOM_history) of all changes done to the field values of a DOM instance. It also allows you to configure the [status system](xref:DOM_status_system) for a DOM definition.

To create a DOM manager, you first need to create a *ModuleSettings* object. You can do so by using the moduleSettingsHelper in a script. For example:

```csharp
// Create the ModuleSettingsHelper
var moduleSettingsHelper = new ModuleSettingsHelper(engine.SendSLNetMessages);

// Create the default module settings and save them to DataMiner
var moduleSettings = new ModuleSettings(moduleId:"my_module");
moduleSettingsHelper.ModuleSettings.Create(moduleSettings);
```

The *moduleId* defined in the example above is what is used to identify the DOM manager instance in the DMS. This must be **unique**.

> [!NOTE]
> Only the Administrator account can create *ModuleSettings* objects.

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

Once a *ModuleSettings* object with a specific *moduleID* has been created, you can start to interact with the DOM manager.

When you send a message to create a DOM instance (e.g. from a script or application), DataMiner will check whether a DOM manager instance with the specified module ID already exists or not. If it does not exist yet, DataMiner will check if it is allowed to create a new DOM manager by trying to retrieve the module settings for that ID. If valid module settings are found, the DOM manager instance will be created and initialized. It will handle the message and send a response.

> [!NOTE]
>
> - If no  *ModuleSettings* object is found for a module ID, a DataMiner exception will be thrown.
> - When multiple requests for the same manager are sent in a rapid succession, the system will wait until the first request has initialized the manager. Once that is done, all requests will be handled by that manager, and a response will be returned for each of them.
