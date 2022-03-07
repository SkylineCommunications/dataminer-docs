---
uid: NT_ADD_VIEW
---

# NT_ADD_VIEW (2)

Creates a new view.

```csharp
string name = "HeadQuarter";
string parentViewID = " 10060";
string[] viewDetails = new string[] { name, parentViewID };
string[] elementIDs = new string[] { "346/661", "346/660" };

uint viewID = (uint) protocol.NotifyDataMiner(2 /*NT_ADD_VIEW*/, viewDetails, elementIDs);
```

## Parameters

- viewDetails (string[]):
  - name (string): Name of the new view.
  - parentViewID (string): ID of the view to which this new view has to be added. Specify -1 to add the view to the root view.
  - viewID (string): The ID of the view to be created. Any non-positive integer gets ignored and a new ID is automatically provided. Supported since DataMiner 10.2.3 (RN 32244).
  - propertyName (string): Name of a property to be added. Supported since DataMiner 10.2.3 (RN 32244).
  - propertyType (string): Type of a property to be added, must be `read-only`, `generic` or `read-write`. Supported since DataMiner 10.2.3 (RN 32244).
  - propertyValue (string): The value of a property to be added. Supported since DataMiner 10.2.3 (RN 32244).
  - The previous three items (propertyName, propertyType, propertyValue) can be repeated to add additional properties. Supported since DataMiner 10.2.3 (RN 32244).
- elementIDs (string[]): global element IDs of the elements that should be included in the new view.

## Return Value

- (uint): The ID of the view.

## Examples

```csharp
string name = "HeadQuarter";
string parentViewID = "-1";

string viewId = "-1";
string firstPropertyName = "MyFirstProperty";
string firstPropertyType = "read-write";
string firstPropertyValue = "MyFirstPropValue";

string secondPropertyName = "MySecondProperty";
string secondPropertyType = "read-write";
string secondPropertyValue = "MySecondPropValue";

string[] viewDetails = new string[] { name, parentViewID, viewId, firstPropertyName, firstPropertyType, firstPropertyValue, secondPropertyName, secondPropertyType, secondPropertyValue };
string[] elementIDs = new string[] { "346/661", "346/660" };

uint viewID = (uint) protocol.NotifyDataMiner(2 /*NT_ADD_VIEW*/ , viewDetails, elementIDs);
```
