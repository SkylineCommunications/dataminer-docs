---
uid: DOM_DomInstanceHistorySettings
---

# DomInstanceHistorySettings

The `DomInstanceHistorySettings` has been introduced in DataMiner version 10.3.9/10.4.0 and contains the settings related to the DOM instance history. It currently has the option to alter the history saving behavior.

## StorageBehavior

The `StorageBehavior` property of type `DomInstanceHistoryStorageBehavior` allows you to define how the DOM instance history objects should be saved. For more info on the DOM history, see [the history page](xref:DOM_history). The following options are available:

- **EnabledAsync**: The DOM instance history objects wil be stored or deleted asynchronously, and will not block the DOM instance create, update or delete calls until the database operation for the history object is completed. This improves the performance of the DOM instance calls. This is the default option.
- **EnabledSync**: The DOM instance history objects wil be stored or deleted synchronously, and will block the DOM instance create, update or delete calls until the database operation for the history object is completed. With this option, you are able to read the most recent history record from an update, right after the call for that update returns. This option should be avoided as this impacts the DOM instance call performance.
- **Disabled**: The DOM instance history will not be stored or deleted. Any existing history for this manager will not be deleted when the associated DOM instance is deleted. This option is recommended when no history is needed as it reduces the load on the DB and the storage required.
