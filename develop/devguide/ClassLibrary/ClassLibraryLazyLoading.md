---
uid: ClassLibraryLazyLoading
---

# Lazy loading

In order to minimize the number of inter-process calls, lazy loading is applied in the DMS library. For example, when retrieving an element, general information such as its name is readily available. However, the views an element belongs to is only obtained when requested.

```csharp
IDms dms = protocol.GetDms();
IDmsElement element = dms.GetElement(new DmsElementId(346, 530006)); // At this point, general information such as the Name of the element is already available.


IDmsElement views = element.Views; // The views are retrieved only when requested.
```

Once the information has been retrieved, it will not be requested again when an additional get operation is performed.

```csharp
IDms dms = protocol.GetDms();
IDmsElement element = dms.GetElement(new DmsElementId(346, 530006));
IDmsElement views = element.Views; // The views are retrieved as this is the first time the views are requested.
IDmsElement views = element.Views; // The views were already requested, so no new request is executed to retrieve the views as this information is already available.
```

Consequently, this means that when you want to obtain the latest state from the DataMiner System, a new request for the element should be obtained:

```csharp
IDms dms = protocol.GetDms();
IDmsElement element = dms.GetElement(new DmsElementId(346, 530006));
IDmsElement views = element.Views; // The views are retrieved as this is the first time the views are requested for this object.


IDmsElement sameElement = dms.GetElement(new DmsElementId(346, 530006));
IDmsElement views = sameElement.Views; // The views are retrieved as this is the first time the views are requested for this object.
```

When Update is called on an element, the data that was lazily loaded for that element is invalidated. This means that at this point the data will be requested again.

```csharp
IDms dms = protocol.GetDms();
IDmsElement element = dms.GetElement(new DmsElementId(346, 530006));
IDmsElement views = element.Views; // The views are retrieved as this is the first time the views are requested for this object.

element.Name = "Updated name";
element.Update(); // The changes are applied.

IDmsElement views = element.Views; // The views are retrieved again as there was an update in the meantime.
```
