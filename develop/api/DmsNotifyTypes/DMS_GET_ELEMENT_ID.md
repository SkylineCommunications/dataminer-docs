---
uid: DMS_GET_ELEMENT_ID
---

# DMS_GET_ELEMENT_ID (72)

> [!WARNING]
> The use of DMS Notify types has been deprecated. Use types from the [Class Library](xref:ClassLibraryIntroduction) instead.

Gets the ID of the element given the element name.

```csharp
int type = 72;
int subType = 0;
string elementName = "Cisco DCM";
object result = new object();

DMS dms = new DMS();
dms.Notify(type, subType, elementName, null, out result);

string globalElementID = (string) result;

if(!string.IsNullOrEmpty(globalElementID))
{
    string[] globalElementIDParts = globalElementID.Split('/');
    int dmaID = Convert.ToInt32(globalElementIDParts[0]);
    int elementID = Convert.ToInt32(globalElementIDParts[1]);
    
    ////...
}
```

## Parameters

- type (int): Specifies the notify type. To perform a DMS_GET_ELEMENT_ID call, set this to 72.
- subType (int): Specifies the sub type. Not applicable for DMS_GET_ELEMENT_ID calls. Set this to 0.
- elementName (string): Element name
- result (object): Holds the returned global element ID (DMA ID/Element ID).

## Remarks

- In case the provided element name does not exist, an empty string is returned.
