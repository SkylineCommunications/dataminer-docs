---
uid: DOM_Invoice_app_example
---

# Invoice app example

In this example, an invoice app storage system is created using a DOM manager.

The following data will be stored for individual invoices:

- Customer (string)

- Total Price (double)

- Invoice Date (DateTime)

- Status (Enum with values *created*, *sent*, *payed*)

- Ordered Products

- Product ID (long)

- Amount (long)

- Product Price (double)

These requirements first need to be translated into different DOM objects:

- One invoice is one `DomInstance`.

- There will be two `SectionDefinitions`:

  - *GeneralInfoSectionDefinition*: Contains the *Customer*, *Total Price*, *Invoice Date*, and *Status* fields.

  - *ProductsSectionDefinition*: Contains the fields that represent one ordered product. This way there can be multiple `Sections` for this one, which will correspond with multiple ordered products.

- A `DomDefinition` will group the two `SectionDefinitions`.

The overview below shows the data that needs to be stored on the left and the DOM objects on the right. The invoice is represented by a `DomInstance` (linked to a `DomDefinition`), which contains `Sections` (linked to `SectionDefinitions`).

![Invoice app example overview](~/user-guide/images/DOM_Invoice_Example_Overview.jpg)

## Setting up a DOM manager

Start by creating the `ModuleSettings`. These will determine how the app will behave. They also tell DataMiner that it can accept messages for that module. In this case, no special actions are needed, only the default settings with module ID "invoice_app".

> [!NOTE]
> Only users with the [Module Settings](xref:DataMiner_user_permissions#modules--system-configuration--object-manager--module-settings) permission can create, update, or delete `ModuleSettings`.

```csharp
// Create the ModuleSettingsHelper
var moduleSettingsHelper = new ModuleSettingsHelper(engine.SendSLNetMessages);

// Create the default ModuleSettings & save it to DataMiner
var moduleSettings = new ModuleSettings("invoice_app");
moduleSettingsHelper.ModuleSettings.Create(moduleSettings);
```

You only need to create these `ModuleSettings` once. When implementing the creation in a script that is executed multiple times, you will need to check whether the settings already exist for your module ID.

```csharp
// Create a filter to check if there is already a ModuleSettings object with ID 'invoice_app'
var filter = ModuleSettingsExposers.ModuleId.Equal("invoice_app");

// Try to retrieve the ModuleSettings object with this filter
var moduleSettings = moduleSettingsHelper.ModuleSettings.Read(filter).FirstOrDefault();
if (moduleSettings == null)
{
    // No ModuleSettings object exists, create it...
}
```

## Creating the section definitions

Now that that the `ModuleSettings` have been created, you can start creating all the DOM objects using a `DomHelper`. You can create a `DomHelper` using an SLNet callback and the module ID.

```csharp
var domHelper = new DomHelper(engine.SendSLNetMessages, "invoice_app");
```

With the `DomHelper`, you can create the first `SectionDefinition`. This one will include four `FieldDescriptors`, one for each required field.

```csharp
// FieldDescriptor for the 'Customer' field (string)
var customerFieldDescriptor = new FieldDescriptor()
{
    FieldType = typeof(string),
    IsOptional = false,
    Name = "Customer",
    Tooltip = "Name of the customer"
};

// FieldDescriptor for the 'Total Price' field (double)
var totalPriceFieldDescriptor = new FieldDescriptor()
{
    FieldType = typeof(double),
    IsOptional = false,
    Name = "Total Price",
    Tooltip = "Total price of all ordered products in €"
};

// FieldDescriptor for the 'Invoice Date' field (DateTime)
var invoiceDateFieldDescriptor = new FieldDescriptor()
{
    FieldType = typeof(DateTime),
    IsOptional = false,
    Name = "Invoice Date",
    Tooltip = "Date when the invoice was sent"
};

// FieldDescriptor for the 'Status' field (Options: created, sent, payed)
var genericEnum = new GenericEnum<int>();
genericEnum.AddEntry("Created", 0);
genericEnum.AddEntry("Sent", 1);
genericEnum.AddEntry("Payed", 2);

var statusFieldDescriptor = new GenericEnumFieldDescriptor()
{
    FieldType = typeof(GenericEnum<int>),
    IsOptional = false,
    GenericEnumInstance = genericEnum,
    Name = "Status",
    Tooltip = "Status of the invoice"
};

// Combine all these FieldDescriptors in one SectionDefinition
var generalInfoSectionDefinition = new CustomSectionDefinition()
{
    Name = "GeneralInfoSectionDefinition"
};

generalInfoSectionDefinition.AddOrReplaceFieldDescriptor(customerFieldDescriptor);
generalInfoSectionDefinition.AddOrReplaceFieldDescriptor(totalPriceFieldDescriptor);
generalInfoSectionDefinition.AddOrReplaceFieldDescriptor(invoiceDateFieldDescriptor);
generalInfoSectionDefinition.AddOrReplaceFieldDescriptor(statusFieldDescriptor);

// Save this SectionDefinition to the DomManager
generalInfoSectionDefinition = domHelper.SectionDefinitions.Create(generalInfoSectionDefinition) as CustomSectionDefinition;
```

Since this is your first call with the `DomHelper`, it will trigger the initialization of the `DomManager` object. Once the DOM manager is initialized and running, the create request will be handled.

> [!NOTE]
> At this point, the DOM manager is only running and initialized on the connected DMA. The other DMAs in the DMS do not have it running. It will only be initialized on another DMA when a request is handled for this module ID by that DMA. All this is done transparently and on the fly. It does not matter where your messages are handled as everything is kept in sync by the Elasticsearch database.

Next, you need to create the second `SectionDefinition`, which will contain the `FieldDescriptors` for an ordered product.

```csharp
// FieldDescriptor for the 'Product ID' field (long)
var productIdFieldDescriptor = new FieldDescriptor()
{
    FieldType = typeof(long),
    IsOptional = false,
    Name = "Product ID",
    Tooltip = "ID of the ordered product"
};

// FieldDescriptor for the 'Amount' field (long)
var amountFieldDescriptor = new FieldDescriptor()
{
    FieldType = typeof(long),
    IsOptional = false,
    Name = "Amount",
    Tooltip = "Amount of products"
};

// FieldDescriptor for the 'Product Price' field (double)
var productPriceFieldDescriptor = new FieldDescriptor()
{
    FieldType = typeof(double),
    IsOptional = true,
    Name = "Product Price",
    Tooltip = "The price of the product in €"
};

// Combine all these FieldDescriptors in one SectionDefinition
var productsSectionDefinition = new CustomSectionDefinition()
{
    Name = "ProductsSectionDefinition"
};

productsSectionDefinition.AddOrReplaceFieldDescriptor(productIdFieldDescriptor);
productsSectionDefinition.AddOrReplaceFieldDescriptor(amountFieldDescriptor);
productsSectionDefinition.AddOrReplaceFieldDescriptor(productPriceFieldDescriptor);

// Save this SectionDefinition to the DomManager
productsSectionDefinition = domHelper.SectionDefinitions.Create(productsSectionDefinition) as CustomSectionDefinition;
```

## Adding the DOM definition

To complete the configuration, you need to create a `DomDefinition`. This will define which `SectionDefinitions` must be used by the `DomInstances`. It also creates a logical grouping of all invoices, since all `DomInstances` will have a link to this `DomDefinition`. From 10.3.3/10.3.0 onwards, the *AllowMultipleSections* bool also needs to be set on the link for the products `SectionDefinition`. This clearly defines that multiple products are allowed on an invoice.

```csharp
// We create a DomDefinition linked to the two SectionDefinitions
var invoicesDomDefinition = new DomDefinition()
{
    Name = "InvoicesDomDefinition",
    SectionDefinitionLinks = new List<SectionDefinitionLink>()
    {
        new SectionDefinitionLink(generalInfoSectionDefinition.GetID()),
        new SectionDefinitionLink(productsSectionDefinition.GetID()) { AllowMultipleSections = true }
    }
};

// Save it to the DomManager
invoicesDomDefinition = domHelper.DomDefinitions.Create(invoicesDomDefinition);
```

This concludes the configuration. From this point onwards, this system can be used to create, read, update, and delete invoices.

## Retrieving objects

In the configuration above, the existing references to the `GeneralInfoSectionDefinition` and `ProductsSectionDefinition` that were returned by the helper after creation were used. However, when you for example use multiple different scripts, you will have to retrieve objects you want to use with the helper.

You will always need a unique identifier to be able to retrieve an object. This can be the:

- *Name* (string) (not available on `DomInstances`), or
- *ID* (GUID)

The ID is generated at random by the server, but you can assign a pre-defined ID yourself instead when creating the object. For example:

```csharp
var domDefinition = new DomDefinition()
{
    ID = new DomDefinitionId(Guid.Parse("1eed444e-602c-48ab-9aea-62e69ccff435"))
};
```

These IDs or names can be hard-coded in the scripts, or better yet, a simple DLL can be created that contains these IDs. This DLL can then be used in all scripts. You can also store a link between a human-readable name and a `FieldDescriptorID` using the *FieldAliases* property of the `ModuleSettings` (see [DOM module settings](xref:DOM_ModuleSettings))

Retrieving an object using the name or ID can be done as follows:

```csharp
// Retrieve using the name
var nameFilter = DomDefinitionExposers.Name.Equal("InvoicesDomDefinition");
var retrievedDomDefinition = domHelper.DomDefinitions.Read(nameFilter).FirstOrDefault();

// Retrieve using the ID
var id = Guid.Parse("1eed444e-602c-48ab-9aea-62e69ccff435");
var idFilter = DomDefinitionExposers.Id.Equal(id);
retrievedDomDefinition = domHelper.DomDefinitions.Read(idFilter).FirstOrDefault();
```

> [!NOTE]
>
> - Use "Equal", not "Equals". This requires the using `Skyline.DataMiner.Net.Messages.SLDataGateway` using directive.
> - Every object type has an exposers class. The name of this class is always "object type name" + "Exposers" (e.g. "SectionDefinitionExposers"). This exposers class can be used to create filters as shown above. Further below, you will find an example of how `DomInstanceExposers` is used to retrieve `DomInstances`.

## Creating DOM instances

Once the configuration is done, you can create the `DomInstances`. You will need all the IDs of the `SectionDefinitions` and `FieldDescriptors` for this. These can either be made statically available by the script, or stored in a DLL.

```csharp
// Hard code the IDs of the SectionDefinitions that were created
// (could be stored in some global ID DLL)
var generalSectionDefinitionId = new SectionDefinitionID(Guid.Parse("11e9c938-7aa8-444a-8941-03d6968b198b"));
var productsSectionDefinitionId = new SectionDefinitionID(Guid.Parse("05f4991a-0ef1-48dd-96ee-e8917467ee06"));

// Hard code the IDs of the FieldDescriptors that were created
// (could be stored in some global ID DLL)
var customerFieldDescriptorId = new FieldDescriptorID(Guid.Parse("63ee0990-b2f1-4716-a7c8-06fa1c186a6d"));
var totalPriceFieldDescriptorId = new FieldDescriptorID(Guid.Parse("705db446-3ff1-4ef9-afe6-0285e81786fb"));
var invoiceDateFieldDescriptorId = new FieldDescriptorID(Guid.Parse("3367926e-edfe-4317-9d83-5def5ed6c10e"));
var statusFieldDescriptorId = new FieldDescriptorID(Guid.Parse("a14016f8-83d1-4963-9baf-569692b737aa"));
var productIdFieldDescriptorId = new FieldDescriptorID(Guid.Parse("6a67e181-1345-4e95-82a0-b3b9662ba038"));
var amountFieldDescriptorId = new FieldDescriptorID(Guid.Parse("c1551fb0-3ba3-4de4-85e7-dca36f70ed64"));
var productPriceFieldDescriptorId = new FieldDescriptorID(Guid.Parse("7aaccf6a-1a2c-432a-835e-7cf01fa2ddbb"));

// Hard code the ID of the DomDefinition
// (could be stored in some global ID DLL)
var domDefinitionId = new DomDefinitionId(Guid.Parse("1eed444e-602c-48ab-9aea-62e69ccff435"));
```

With the IDs available, you can now create the `DomInstance` object. You can start by creating a `Section` for the `GeneralSectionDefinition`.

```csharp
// Create a list of FieldValues for the general Section
var generalFieldValues = new List<FieldValue>()
{
    new FieldValue(customerFieldDescriptorId, new ValueWrapper<string>("John Doe")),
    new FieldValue(totalPriceFieldDescriptorId, new ValueWrapper<double>(3699.89)),
    new FieldValue(invoiceDateFieldDescriptorId, new ValueWrapper<DateTime>(DateTime.MinValue)),
    new FieldValue(statusFieldDescriptorId, new ValueWrapper<int>(0)), // 0 = Created
};

// Add them to a Section linked to the ID of the GeneralSectionDefinition
var generalSection = new Section()
{
    SectionDefinitionID = generalSectionDefinitionId
};

foreach (var fieldValue in generalFieldValues)
{
    generalSection.AddOrReplaceFieldValue(fieldValue);
}
```

The invoice includes two products. That means two `Sections` need to be created for the `ProductsSectionDefinition`.

For the first product:

```csharp
// Create a Section for the first ordered product
var firstProductFieldValues = new List<FieldValue>()
{
    new FieldValue(productIdFieldDescriptorId, new ValueWrapper<long>(58745698)),
    new FieldValue(amountFieldDescriptorId, new ValueWrapper<long>(1)),
    new FieldValue(productPriceFieldDescriptorId, new ValueWrapper<double>(2499.99)),
};

// Add them to a Section linked to the ID of the ProductsSectionDefinition
var firstProductSection = new Section()
{
    SectionDefinitionID = productsSectionDefinitionId
};

foreach (var fieldValue in firstProductFieldValues)
{
    firstProductSection.AddOrReplaceFieldValue(fieldValue);
}
```

For the second product:

```csharp
// Create a Section for the second ordered product
var secondProductFieldValues = new List<FieldValue>()
{
    new FieldValue(productIdFieldDescriptorId, new ValueWrapper<long>(548745687)),
    new FieldValue(amountFieldDescriptorId, new ValueWrapper<long>(2)),
    new FieldValue(productPriceFieldDescriptorId, new ValueWrapper<double>(599.95)),
};

// Add them to a Section linked to the ID of the GeneralSectionDefinition
var secondProductSection = new Section()
{
    SectionDefinitionID = productsSectionDefinitionId
};

foreach (var fieldValue in secondProductFieldValues)
{
    secondProductSection.AddOrReplaceFieldValue(fieldValue);
}
```

All three `Sections` can now be combined into a `DomInstance`. The `DomInstance` must be linked to the `DomDefinition` that was created earlier.

```csharp
var domInstance = new DomInstance()
{
    DomDefinitionId = domDefinitionId
};

// Add all Sections
domInstance.Sections.Add(generalSection);
domInstance.Sections.Add(firstProductSection);
domInstance.Sections.Add(secondProductSection);

// Save the DomInstance to the DomManager
domInstance = domHelper.DomInstances.Create(domInstance);
```

There is also an easier way to add `FieldValues` to a `DomInstance`, but this requires that the full `SectionDefinition` and `FieldDescriptor` objects are present. For more information, see [Altering values of a DomInstance](xref:DOM_Altering_values_of_a_DomInstance#simple-extension-methods).

```csharp
domInstance.AddOrUpdateFieldValue(generalSectionDefinition, customerFieldDescriptor, "John Doe");
domInstance.AddOrUpdateFieldValue(generalSectionDefinition, totalAmountFieldDescriptor, 3699.89);
```

## Reading/filtering DOM instances

Once the system is fully set up, you can filter on the data.

```csharp
// Retrieve all invoices that have not been payed for more than 14 days
var twoWeeksAgo = DateTime.Now.AddDays(-14);
var dateFilter = DomInstanceExposers.FieldValues.DomInstanceField(invoiceDateFieldDescriptorId).LessThanOrEqual(twoWeeksAgo);
var statusFilter = DomInstanceExposers.FieldValues.DomInstanceField(statusFieldDescriptorId).NotEqual(2);
var fullFilter = dateFilter.AND(statusFilter);

var unpaidInvoices = domHelper.DomInstances.Read(fullFilter);
```

You can also just retrieve all the invoices. Below, a filter is used on the `DomDefinition` ID, so that only the `DomInstances` linked to the `InvoicesDomDefinition` are retrieved. (This filter could also be appended to the previous example, though you will already only receive invoice `DomInstances` if no other `DomDefinition` is using the same `SectionDefinitions` and `FieldDescriptor` IDs.)

```csharp
var filter = DomInstanceExposers.DomDefinitionId.Equal(domDefinitionId.Id);
var allInvoices = domHelper.DomInstances.Read(filter);
```

> [!NOTE]
> For more information on how to add, update, and get values of a `DomInstance`, see [Altering values of a DomInstance](xref:DOM_Altering_values_of_a_DomInstance).
