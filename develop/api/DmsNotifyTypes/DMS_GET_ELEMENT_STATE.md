---
uid: DMS_GET_ELEMENT_STATE
---

# DMS_GET_ELEMENT_STATE (91)

> [!WARNING]
> The use of DMS Notify types has been deprecated. Use types from the [Class Library](xref:ClassLibraryIntroduction) instead.

Gets the element state.

```csharp
int type = 91;
int subType = 0;

int dmaID = 346;
int elementID = 601;

object result = new object();

DMS dms = new DMS();
dms.Notify(type/*DMS_GET_ELEMENT_STATE*/ , subType, dmaID, elementID, out result);

string elementState = (string)result;
```

## Parameters

- type (int): Specifies the notify type. To perform a DMS_GET_ELEMENT_STATE call, set this to 91.
- subType (int): Specifies the sub type. Not applicable for DMS_GET_ELEMENT_STATE calls. Set this to 0.
- dmaID (int): DataMiner Agent ID
- elementID (int): Element ID
- result (object): Element state as string. Possible values are:

  - active
  - stop
  - inactive
  - unknown
