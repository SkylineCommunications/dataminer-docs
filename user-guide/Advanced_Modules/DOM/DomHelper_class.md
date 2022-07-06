---
uid: DomHelper_class
---

# DomHelper class

The DomHelper class can be used in a script, protocol, or app to execute create, read, update, and delete actions on DOM objects.

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
