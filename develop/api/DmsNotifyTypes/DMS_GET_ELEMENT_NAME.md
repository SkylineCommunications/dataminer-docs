---
uid: DMS_GET_ELEMENT_NAME
---

# DMS_GET_ELEMENT_NAME (67)

> [!WARNING]
> The use of DMS Notify types has been deprecated. Use types from the [Class Library](xref:ClassLibraryIntroduction) instead.

Gets the name of the element given the element ID.

```csharp
int type = 67;
int subType = 0;
uint dmaID = 346;
uint elementID = 601;

DMS dms = new DMS();
object result = new object();

dms.Notify(type/*DMS_GET_ELEMENT_NAME*/, subType, dmaID, elementID, out result);

string elementName = (string) result;
```

## Parameters

- type (int): Specifies the notify type. To perform a DMS_GET_ELEMENT_NAME call, set this to 67.
- subType (int): Specifies the sub type. Not applicable for DMS_GET_ELEMENT_NAME calls. Set this to 0.
- dmaID (uint): DataMiner Agent ID
- elementID (uint): Element ID
- result (object): Holds the returned element name (empty string if there is no element with the specified element ID on the specified DataMiner Agent).
