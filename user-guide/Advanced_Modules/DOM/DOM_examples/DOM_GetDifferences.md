---
uid: DOM_GetDifferences
---

# Checking differences when updating a DomInstance

From 10.4.3/10.5.0 onwards<!-- RN 38364 -->, it is possible to see the changes done to a DomInstance in a CRUD script using the `GetDifferences` method on the [CrudMeta](xref:ExecuteScriptOnDomInstanceActionSettings#full-crud-meta-type) object of that instance.

## GetDifferences structure & methods

The GetDifferences method returns an object DomInstanceDifferences. This contains the differences of the DomInstance:

- DomInstanceDifferences:
    - FieldValues : all changes (returned as FieldValueDifferences)
        - Created : changes of the created type (returned as FieldValueDifferences)
        - Updated : changes of the updated type (returned as FieldValueDifferences)
        - Deleted : changes of the deleted type (returned as FieldValueDifferences)

On these FieldValueDifferences you can apply different methods:

|Method        |Type        |Description |
|----------------|------------|------------|
|Get() | List\<FieldValueDifference\> | Returns the differences as a list of FieldValueDifference|
|GetEnumerator() | IEnumerator\<FieldValueDifference\> | Returns an enumerator that iterates through the collection of differences|
|OfType(\<CrudType\>) | FieldValueDifferences | Returns the differences with a certain CrudType (Create, Update & Delete)|
|OfFieldDescriptor(\<FieldDescriptorID\>) | FieldValueDifferences | Returns the differences on a certain FieldDescriptor|
|OfSectionDefinition(\<SectionDefinitionID\>) | FieldValueDifferences | Returns the differences within a certain SectionDefinition|

These methods can be chained to create specific conditions to get your desired differences.

Example: getting all updated `FieldValues` of a certain `SectionDefinition`:

```csharp
var differences = crudMeta.GetDifferences().OfSectionDefinition(SectionDefinitionId).OfType(CrudType.Update);
```

This `FieldValueDifferences` object contains a list of `FieldValueDifference` objects:

|Property        |Type        |Description |
|----------------|------------|------------|
|Type | CrudType | The CrudType of the changed FieldDescriptor (Create, Update & Delete) |
|ValueBefore | IValueWrapper | The value of the FieldDescriptor before the change|
|ValueAfter | IValueWrapper | The value of the FieldDescriptor after the change|
|FieldDescriptorId | FieldDescriptorID | The ID the changed FieldDescriptor|
|SectionId | SectionID |The SectionId of the changed FieldDescriptor|
|SectionDefinitionId | SectionDefinitionID | The SectionDefinitionId of the changed FieldDescriptor|

## Example
This example script generates an information event stating the differences whenever a DomInstances is updated.

```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel.General;

namespace Example
{
    public class Script
    {
        [AutomationEntryPoint(AutomationEntryPointType.Types.OnDomInstanceCrudWithFullMeta)]
        public void OnDomInstanceCrudWithFullMeta(IEngine engine, DomInstanceCrudMeta crudMeta)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"CRUD script triggered by the '{crudMeta.CrudType}' action on DomInstance with name '{crudMeta.CurrentVersion.Name}'. Changes:");
        
            var differences = crudMeta.GetDifferences().FieldValues;
        
            foreach (var difference in differences)
            {
                var crudType = "";
                switch (difference.Type)
                {
                    case CrudType.Create:
                        crudType = "CREATED";
                        break;
                    case CrudType.Update:
                        crudType = "UPDATED";
                        break;
                    case CrudType.Delete:
                        crudType = "DELETED";
                        break;
                }
        
                sb.AppendLine($"{crudType}: ID: '{difference.FieldDescriptorId.Id}', Change: '{difference.ValueBefore}' -> '{difference.ValueAfter}'");
            }

            engine.GenerateInformation(sb.ToString());
        }
    }
}
```