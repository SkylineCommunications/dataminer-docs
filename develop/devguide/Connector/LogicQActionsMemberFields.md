---
uid: LogicQActionsMemberFields
---

# QAction member fields

A static entry point method can use static members of the QAction class. Static fields in C# are class-level members shared by all instances of the class.

> [!NOTE]
> Static fields are only shared between elements with the same protocol version that are running in the same SLScripting process.

> [!IMPORTANT]
> From DataMiner 10.6.3/10.7.0 onwards<!-- RN 44420 -->, multiple SLScripting processes are active by default. This causes unexpected behavior when static fields are used to share data as not all elements running the same protocol will be located in the same SLScripting process. Furthermore, restarting the element can cause it to move to another SLScripting process. Because of this, **static fields should not be used to exchange data between elements running the same protocol**. If protocols have been developed with the assumption that all elements are running in the same SLScripting process, you can [configure DataMiner to only use one SLScripting process](xref:Configuration_of_DataMiner_processes#setting-the-number-of-simultaneously-running-slscripting-processes). However, we strongly recommend adapting such problematic protocols according to the approach described under [Sharing and persisting data](#sharing-and-persisting-data), as this will allow DataMiner to use multiple SLScripting processes and increases overall resilience.

An instance entry point method can use both static and instance fields.

QAction member fields can for example be used to persist data across QAction executions. For more information, refer to the example protocol [Skyline Example QActions Caching and Sharing](https://github.com/SkylineCommunications/SLC-C-Example_QActions-CachingAndSharingData) on GitHub.

## Sharing and persisting data

Depending on the level at which data needs to be shared, different approaches are required.

All scenarios below assume that the data does **not** need to persist when the element restarts. If persistence across restarts is required, use saved parameters and access them from the relevant QActions.

- **Between elements running different protocols**: Use a **static QAction** and share data via [**InterApp calls**](xref:InterAppCalls_Introduction).

- **Between elements running the same protocol**: Use a **static QAction** and share data via [**InterApp calls**](xref:InterAppCalls_Introduction).

  > [!IMPORTANT]
  > Do **not** share data between elements running the same protocol version using static fields. This approach does not work when DataMiner uses multiple SLScripting processes, which is the default starting from DataMiner 10.6.3/10.7.0<!--RN 44420-->.

- **Within a single element across multiple executions of the same QAction**: Use an **instanced QAction** and share data through a **non-static field**.

- **Within a single element across multiple executions of two or more different QActions**: Use a **precompiled QAction** with a **singleton or static class** containing a **static dictionary field**. Store and retrieve data per element using this dictionary. The key of the dictionary should be a combination of the **Root DataMiner ID** and the **Element ID**. This combination will guarantee uniqueness of the dictionary key even when the DMS contains multiple Agents. The **Root DataMiner ID** is used instead of the host DataMiner ID to make sure the key stays unique even after an element is swarmed to a different Agent.

  > [!IMPORTANT]
  > Implement cleanup logic when the element is stopped to remove all entries related to that element from the dictionary, as the lifetime of the static field is independent of the element lifecycle.

## Implementing the IDisposable interface

In case the QAction class has members that should be disposed of, you can implement the [IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable) interface on the QAction class.

From DataMiner 10.2.9 onwards (RN 33965), DataMiner will call the [Dispose](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable.dispose) method of the [IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable) interface when a QAction instance is released (i.e., when the element is stopped, removed, or restarted) if this interface is implemented on the QAction class.

> [!NOTE]
>
> - DataMiner will only create an instance of a class containing an entry point method if this method is not a static method (see [Instance entry methods](xref:LogicQActionsEntryPointMethods#instance-entry-methods)). Therefore, if you want to make use of the IDisposable functionality, make sure you use a non-static entry point method so that an instance gets created.
> - This also applies to any other class the entry point may be in (see [Multiple entry methods](xref:LogicQActionsEntryPointMethods#multiple-entry-methods)).
> - This coincides with the IsActive property of the SLProtocol interface being set to false, which prevents further function calls to the object from being executed.
> - The Dispose method is called by a separate thread than the one stopping the element. Its purpose is to release lingering resources and connections when the element is stopped.
