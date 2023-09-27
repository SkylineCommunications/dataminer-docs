---
uid: DOM_Altering_values_of_a_DomInstance
---
# Altering values of a DomInstance - examples

This page contains simple examples of how you can add or update values of a `DomInstance` linked to `SectionDefinitions` and their `FieldDescriptors`.

There are two main ways to alter values:

- Use the [extension methods](xref:DOM_Altering_values_of_a_DomInstance#simple-extension-methods).

- Manually create your own `Sections` and `FieldValues`.

  ```csharp
  using System;
  using System.Linq;
  using System.Collections.Generic;
  using Skyline.DataMiner.Automation;
  using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
  using Skyline.DataMiner.Net.Apps.Sections.Sections;
  using Skyline.DataMiner.Net.Sections;

  namespace DOM_Example
  {
      public class Script
      {
          public void Run(Engine engine)
          {
              // Create the DomHelper
              var domHelper = new DomHelper(engine.SendSLNetMessages, "my_module");

              // Code examples here
          }
      }
  }
  ```

> [!NOTE]
> This code example behaves as if wrapped in an Automation script that contains the required using statements and a `DomHelper`.

## Simple extension methods

The simplest method to alter values of a `DomInstance` is by using the extension methods provided by the `SectionUtils` and `SectionListUtils` classes. There is a method to:

- [Add or update a value](#add-or-update-a-dominstance-value) to/of a `DomInstance`.

- [Get a value](#get-a-value-from-a-dominstance) from a `DomInstance`.

> [!NOTE]
> These two methods both have a variant for a single value and a list value.

There are two versions available:

- A version where you can pass the full `SectionDefinition` and `FieldDescriptor` objects (available from DataMiner 10.3.2/10.4.0 onwards).

  > [!NOTE]
  > This will automatically [stitch](xref:DomHelper_class#stitching) these full objects into the `DomInstance`. This might not always be necessary.

- A version where you only need to pass the object IDs.

  This has the advantage that you do not need to retrieve the full objects from the server, which could improve your script's performance.

There is currently no extension method to remove `FieldValues` or `Sections` from a `DomInstance`. For more information on how to do this manually, see [Manually altering 'Sections' and 'FieldValues'](#manually-altering-sections-and-fieldvalues).

#### List of extension methods

##### Add or update a 'DomInstance' value

- *void* **AddOrUpdateFieldValue&lt;T&gt;** (SectionDefinition, FieldDescriptor, T)

- *void* **AddOrUpdateFieldValue&lt;T&gt;** (SectionDefinitionID, FieldDescriptorID, T)

- *void* **AddOrUpdateListFieldValue&lt;T&gt;** (SectionDefinition, FieldDescriptor, T)

- *void* **AddOrUpdateListFieldValue&lt;T&gt;** (SectionDefinitionID, FieldDescriptorID, T)

> [!IMPORTANT]
> When you call these methods, you will add or update a field value to the local copy of the `DomInstance` that was retrieved during the read operation using the `DomHelper`. No additional calls are done to set these new values in the database. After setting new values to the local object, you need to call the "Add" or "Update" methods on the `DomHelper` to save your changes to the database.

##### Get a value from a 'DomInstance'

- *ValueWrapper&lt;T&gt;* **GetFieldValue&lt;T&gt;** (SectionDefinition, FieldDescriptor)

- *ValueWrapper&lt;T&gt;* **GetFieldValue&lt;T&gt;** (SectionDefinitionID, FieldDescriptorID)

- *ListValueWrapper&lt;T&gt;* **GetListFieldValue&lt;T&gt;** (SectionDefinition, FieldDescriptor)

- *ListValueWrapper&lt;T&gt;* **GetListFieldValue&lt;T&gt;** (SectionDefinitionID, FieldDescriptorID)

> [!IMPORTANT]
> When you call these methods, you will retrieve the field values from the local copy of the `DomInstance` that was retrieved during the read operation using the `DomHelper`. No additional calls are done to retrieve the current values in the database. If you require the latest version, you will first need to read the instance again using the `DomHelper`.

#### Examples

##### Examples: Add or update a 'DomInstance' value

**Single value variant**:

```csharp
// Define the ID of the DomDefinition, the SectionDefinition and the ID for one of its FieldDescriptors.
var domDefinitionId = new DomDefinitionId(Guid.Parse("f724ff26-877e-4511-80c1-b97d17d80f79"));
var sectionDefinitionId = new SectionDefinitionID(Guid.Parse("f45033cc-ff33-4d33-88bf-49b85e91d59c"));
var fieldDescriptorId = new FieldDescriptorID(Guid.Parse("c97b2989-7043-4b73-a279-ab4464b0f3d6"));

// Instantiate a new DomInstance & assign 'Hello' as a value for the c97b... FieldDescriptor.
var domInstance = new DomInstance() { DomDefinitionId = domDefinitionId };
domInstance.AddOrUpdateFieldValue<string>(sectionDefinitionId, fieldDescriptorId, "Hello");

// Save it to the DB.
var createdDomInstance = domHelper.DomInstances.Create(domInstance);

// Alter the value again, you can use the same method. It will just replace the previous value.
createdDomInstance.AddOrUpdateFieldValue<string>(sectionDefinitionId, fieldDescriptorId, "Who is this?");

// Save the update to the DB.
var updatedDomInstance = domHelper.DomInstances.Update(createdDomInstance);
```

**List value variant**:

```csharp
// Define the ID of a FieldDescriptor that accepts list values.
var listFieldDescriptorId = new FieldDescriptorID(Guid.Parse("8adfb099-ac06-449a-96d0-9e652669444d"));

var doubleList = new List<double>() { 26.23, 195.23, 987.42  };
updatedDomInstance.AddOrUpdateListFieldValue<double>(sectionDefinitionId, listFieldDescriptorId, doubleList);

// Save the update to the DB.
domHelper.DomInstances.Update(updatedDomInstance);
```

##### Example: Get a value from a 'DomInstance'

```csharp
// Retrieve the value from the DomInstance.
var value = domInstance.GetFieldValue<string>(sectionDefinitionId, fieldDescriptorId);
string actualString = value.Value;

// Retrieve the list value from the DomInstance.
var listValue = domInstance.GetListFieldValue<double>(sectionDefinitionId, listFieldDescriptorId);
List<double> actualList = listValue.Values;
```

## Manually altering 'Sections' and 'FieldValues'

It is also possible to manually add `Sections` and `FieldValues` to the `DomInstance`. This could be required when you, for example, want to add multiple `Sections` for the same `SectionDefinition`.

#### Examples

##### Example: adding a new 'Section' and 'FieldValue'

```csharp
// Define the ID of the DomDefinition, the SectionDefinition and the ID for one of its FieldDescriptors.
var domDefinitionId = new DomDefinitionId(Guid.Parse("f724ff26-877e-4511-80c1-b97d17d80f79"));
var sectionDefinitionId = new SectionDefinitionID(Guid.Parse("f45033cc-ff33-4d33-88bf-49b85e91d59c"));
var fieldDescriptorId = new FieldDescriptorID(Guid.Parse("c97b2989-7043-4b73-a279-ab4464b0f3d6"));

// Create a DomInstance & assign the DomDefinitionId.
var domInstance = new DomInstance() { DomDefinitionId = domDefinitionId };

// Create a Section for the SectionDefinition.
var section = new Section(sectionDefinitionId);

// Create a FieldValue for the FieldDescriptor.
var fieldValue = new FieldValue(fieldDescriptorId)
{
    Value = new ValueWrapper<string>("Hello")
};

// Add the FieldValue to the Section.
section.AddOrReplaceFieldValue(fieldValue);

// Add the Section to the DomInstance.
domInstance.Sections.Add(section);

// Save it to the DB.
var createdDomInstance = domHelper.DomInstances.Create(domInstance);
```

##### Example: adding or updating a 'FieldValue' on an existing section

```csharp
// Find the Section on the DomInstance.
var existingSection = createdDomInstance.Sections.FirstOrDefault(x => x.SectionDefinitionID.Equals(sectionDefinitionId));
if (existingSection == null)
{
    engine.ExitFail($"No Section found on the DomInstance that is linked to the SectionDefinition with ID '{sectionDefinitionId}'");
    return;
}

// Create a new FieldValue with another value.
var newFieldValue = new FieldValue(fieldDescriptorId)
{
    Value = new ValueWrapper<string>("Who is this?")
};

// Replace it on the Section.
existingSection.AddOrReplaceFieldValue(newFieldValue);

// Save the update to the DB.
// Since we replace the FieldValue on the Section instance retrieved from the DomInstance,
// we do not need to add the Section again. We have replaced it on the reference that is already on the DomInstance.
domHelper.DomInstances.Update(createdDomInstance);
```

##### Example: removing a 'FieldValue'

```csharp
// Find the Section on the DomInstance.
var existingSection = createdDomInstance.Sections.FirstOrDefault(x => x.SectionDefinitionID.Equals(sectionDefinitionId));
if (existingSection == null)
{
    engine.ExitFail($"No Section found on the DomInstance that is linked to the SectionDefinition with ID '{sectionDefinitionId}'");
    return;
}

// Remove the FieldValue from the Section.
existingSection.RemoveFieldValueById(fieldDescriptorId);

// Save the update to the DB.
// Since we removed the FieldValue on the Section instance retrieved from the DomInstance,
// we do not need to add the Section again. We have removed it from the reference that is already on the DomInstance.
domHelper.DomInstances.Update(createdDomInstance);
```

##### Example: removing a 'Section'

```csharp
// Find the Section on the DomInstance.
var existingSection = createdDomInstance.Sections.FirstOrDefault(x => x.SectionDefinitionID.Equals(sectionDefinitionId));
if (existingSection == null)
{
    engine.ExitFail($"No Section found on the DomInstance that is linked to the SectionDefinition with ID '{sectionDefinitionId}'");
    return;
}

// Remove the Section from the DomInstance.
createdDomInstance.Sections.Remove(existingSection);

// Save the update to the DB.
var updatedInstance = domHelper.DomInstances.Update(createdDomInstance);
```

##### Example: retrieving a single value

```csharp
// Find the Section on the DomInstance.
var existingSection = createdDomInstance.Sections.FirstOrDefault(x => x.SectionDefinitionID.Equals(sectionDefinitionId));
if (existingSection == null)
{
    engine.ExitFail($"No Section found on the DomInstance that is linked to the SectionDefinition with ID '{sectionDefinitionId}'");
    return;
}

// Find the FieldValue on the Section.
var existingFieldValue = existingSection.GetFieldValueById(fieldDescriptorId);
var valueWrapper = existingFieldValue.Value as ValueWrapper<string>; // Cast to the ValueWrapper of the expected type.
string actualValue = valueWrapper.Value;
```

##### Example: retrieving a list value

Just like normal single values, you can add, update, and get list values. Just keep in mind that the `ValueWrapper` should be replaced with `ListValueWrapper`.

```csharp
// Creating a FieldValue with a list.
var newFieldValue = new FieldValue(fieldDescriptorId)
{
    Value = new ListValueWrapper<string>(new List<string> { "Hello", "Is it me", "You are looking for" } )
};

// Retrieving a list value.
var fieldValue = section.GetFieldValueById(fieldDescriptorId);
var valueWrapper = fieldValue.Value as ListValueWrapper<string>;
List<string> actualValue = valueWrapper.Values;
```

## Notes

- Make sure that the value is of the same type as was defined in the associated `FieldDescriptor`. We recommend that you use an IDE that allows you to easily see the type by hovering over it. Deceiving situations might occur, e.g. an "int" is assigned but the `FieldDescriptor` expects type "long" (Use "236L" instead of "236" in this case).

- You can alter the `DomInstance` object as much as required. Only when passing the `DomInstance` to the `Create` or `Update` method of the helper, will a call be made to the server and will the object be created or updated in the DB.
