---
uid: NT_ADD_VIEWS
---

# NT_ADD_VIEWS (454)

Creates multiple views.

```csharp
string firstViewName = "HeadQuarter 1";
string parentViewId = "-1";
string viewId = "-1";

string firstViewPropertyName = "MyFirstProperty";
string firstViewPropertyType = "read-write";
string firstViewPropertyValue = "MyFirstViewPropertyValue";

string[] firstViewDetails = new string[] { firstViewName, parentViewId, viewId, firstViewPropertyName, firstViewPropertyType, firstViewPropertyValue };

string[] firstViewElementIds = new string[] { "346/661", "346/660" };

string secondViewName = "HeadQuarter 2";

string secondViewPropertyName = "MyFirstProperty";
string secondViewPropertyType = "read-write";
string secondViewPropertyValue = "MySecondViewPropValue";

string[] secondViewDetails = new string[] { secondViewName, parentViewId, viewId, secondViewPropertyName, secondViewPropertyType, secondViewPropertyValue };

string[] secondViewElementIds = new string[] { "346/761", "346/760" };

var allViewDetails = new object[]{firstViewDetails, secondViewDetails};
var allElementIds = new object[]{firstViewElementIds, secondViewElementIds};

uint[] viewIds = (uint[]) protocol.NotifyDataMiner(454 /*NT_ADD_VIEWS*/ , allViewDetails, allElementIds);
```

## Parameters

- allViewDetails (object[]): Jagged string array where each item of the array contains the viewDetails for a single view, see <xref:NT_ADD_VIEW>.
  - viewDetails (string[]):
    - name (string): Name of the new view.
    - parentViewID (string): ID of the view to which this new view has to be added. Specify -1 to add the view to the root view.
    - viewID (string): The ID of the view to be created. Any non-positive integer gets ignored, and a new ID is automatically provided.
    - propertyName (string): Name of a property to be added.
    - propertyType (string): Type of a property to be added. Must be `read-only`, `generic` or `read-write`.
    - propertyValue (string): The value of a property to be added.
    - The previous three items (propertyName, propertyType, propertyValue) can be repeated to add additional properties.
- allElementIds (object[]):Jagged string array where each item of the array contains the global element IDs of the elements that should be included in the new view, see <xref:NT_ADD_VIEW>.
  - elementIds (string[]): global element IDs of the elements that should be included in the new view.

## Return Value

- (uint[]): The IDs of the created views.

## Remarks

- Supported since DataMiner 10.2.3 (RN 32244).
- The size of the allElementIds array must be zero or equal to the size of the allViewDetails array.
- The call performs a best effort: it will skip any invalid data if possible and keep working on the remaining data. For example, if it tries to create 5 views, but one of the provided names already exists, it will skip that one and create the remaining 4. It will also skip duplicate view names and improperly formatted view property data.
