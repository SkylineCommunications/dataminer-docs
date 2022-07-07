---
uid: DomHelper_class
---

# DomHelper class

## CRUD actions

The *DomHelper* class can be used in a script, protocol, or app to execute create, read, update, and delete (CRUD) actions on DOM objects.

To do so, first call the constructor of the helper, provide a callback to SLNet, and specify a module ID for which module settings have been defined. For example:

```csharp
// Create the DomHelper
var domHelper = new DomHelper(engine.SendSLNetMessages, moduleId:"my_module");
```

You can then call the *Create*, *Read*, *Update* or *Delete* methods on the CRUD helper components of the helper.

For example, to create an empty DOM template:

```csharp
// Create the DomHelper
var domHelper = new DomHelper(engine.SendSLNetMessages, moduleId:"my_module");

// Create a basic empty DOM template
var domTemplate = new DomTemplate()
{
    Name = "Empty Template",
    TemplateData = new DomInstance()
};

// Save the DOM template to the DOM manager
domHelper.DomTemplates.Create(domTemplate);
```

Updating and deleting an object can be done in a similar way. For example:

```csharp
// Update a DOM template
domHelper.DomTemplates.Update(domTemplate);

// Delete a DOM template
domHelper.DomTemplates.Delete(domTemplate);
```

To read an object, create a filter with an exposer class and then pass this to the read method of the helper. For example:

```csharp
// Create a filter to retrieve the empty template we just saved
var filter = DomTemplateExposers.Name.Equal("Empty Template");

// Request the object from the server
var emptyTemplate = domHelper.DomTemplates.Read(filter).FirstOrDefault();
```

By default, an exception will be thrown if a call fails. However, you can disable this and check if something went wrong yourself by requesting the *TraceData* object of the last call. This object contains all errors and warnings. For example:

```csharp
// Disable the exceptions
helper.DomInstances.ThrowExceptionsOnErrorData = false;

// Do a call
helper.DomInstances.Create(domInstance);

// Get the TraceData and check if the last call succeeded
var traceData = helper.DomInstances.GetTraceDataLastCall();
if (!traceData.HasSucceeded())
{
    // Something went wrong, retrieve all DomInstance errors
    var errors = traceData.GetErrorDataOfType<DomInstanceError>();
    foreach (var error in errors)
    {
        // Do something with the error, e.g. log it
        engine.GenerateInformation($"Error reason: {error.ErrorReason}");
    }

    // You can also just log the complete TraceData object,
    // this will clearly show the errors, reasons and extra info
    engine.GenerateInformation(traceData.ToString());
}
```

<!-- Add Xref to error data types and error reasons? -->

## Retrieving history information

You can also retrieve [HistoryChange](wref:DOM_history#historychange) objects using the *DomHelper* class. You can filter them using HistoryChangeExposers.

> [!NOTE]
> It is only possible to read *HistoryChange* items. Creating, updating or deleting is reserved for the internal API.

Example:

```csharp
// Get all history for a specific DomInstance
var filter = HistoryChangeExposers.SubjectID.Equal(domInstance.ID.ToFileFriendlyString());
var allHistory = domHelper.DomInstanceHistory.Read(filter);

// Cast the changes
var singleHistory = allHistory.First();
var sectionChanges = singleHistory.Changes.OfType<DomSectionChange>();
var statusChanges = singleHistory.Changes.OfType<DomInstanceStatusChange>();
```

## Sending a transition request

Transitioning to another status for a DOM instance must be done by sending a transition request. This request requires the ID of the DOM instance and the ID of the transition.

For example:

```csharp
domHelper.DomInstances.DoStatusTransition(domInstance.ID, "initial_to_acceptance");
```

When something goes wrong while transitioning, a *DomStatusTransitionError* will be returned in the *TraceData* of the request. This error can contain the following reasons:

| Reason | Description |
| StatusTransitionNotFound | The given transition ID does not match any of the IDs defined on the associated DOM behavior definition. This error can also occur when there is no valid DOM behavior definition linked in the first place. *StatusTransitionId* contains the ID of the transition that could not be found. |
| StatusTransitionIncompatibleWithCurrentStatus | The current status of the DOM instance does not match the "from" status defined by the transition. *StatusTransitionId* contains the ID of the transition that could not be completed. |
| DomInstanceContainsUnknownFieldsForNextStatus | There is at least one field value defined in the DOM instance for which no link could be found in the DOM behavior definition for the next status. *AssociatedFields* contains the *SectionDefinitionID* and *FieldDescriptorID* combinations of the unknown fields. |
| DomInstanceHasInvalidFieldsForNextStatus | The DOM instance contains fields that are required but are not valid according to at least one validator. If there are multiple values for the same *SectionDefinition* and *FieldDescriptor*, only one entry will be included. *AssociatedFields* contains the *SectionDefinitionID* and *FieldDescriptorID* combinations of the invalid fields |
| DomInstanceHasMissingRequiredFieldsForNextStatus | The DOM instance does not contain all fields that are required for the next status. *AssociatedFields* contains the *SectionDefinitionID* and *FieldDescriptorID* combinations of the missing fields |
| CrudFailedExceptionOccurred | When the DOM instance was saved, a *CrudFailedException* occurred. *InnerTraceData* contains the *TraceData* contained in the exception. |
