---
uid: DMS_GET_ELEMENTS_USING_PROTOCOL
---

# DMS_GET_ELEMENTS_USING_PROTOCOL (102)

> [!WARNING]
> The use of DMS Notify types is deprecated. Use types from [Class library](xref:ClassLibraryIntroduction) instead.

Gets elements using the specified protocol.

```csharp
object result;

string protocolName = "Microsoft Platform";
string protocolVersion = "Production";

int type = 102;
int subType = 0;

string[] protocolDetails = new string[]{protocolName, protocolVersion};
bool activeOnly = true;

DMS dms = new DMS();
dms.Notify(type/* DMS_GET_ELEMENTS_USING_PROTOCOL */, subType, protocolDetails, activeOnly, out result);

if (result != null)
{
    string[] globalElementIDs = (string[])result;
    
    foreach (string globalElementID in globalElementIDs)
    {
        ////....
    }
}
```

## Parameters

- type (int): Specifies the notify type. To perform a DMS_GET_ELEMENTS_USING_PROTOCOL call, set this to 102.
- subType (int): Specifies the sub type. Not applicable for DMS_GET_ELEMENTS_USING_PROTOCOL calls. Set this to 0.
- protocolDetails (string[] or string):

  In case protocolDetails is of type string[]:
  - protocolDetails[0]: Name of the protocol.
  - protocolDetails[1]: Version of the protocol.
  
  In case protocolDetails is of type string[]:
  - activeOnly (boolean): Set to true in case you only want to retrieve active elements. Otherwise set to false (or provide null for this argument).
  - result (object): Overview of all elements that use this protocol version as a string array containing the global element IDs (DMA ID/Element ID).
