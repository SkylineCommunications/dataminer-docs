---
uid: DOM_status_system_example
---

# DOM status system example

This page contains an example of how the status system can be set up and used.

The example sets up a rudimentary tracking system with the following statuses:

- **New**: The issue is new.

- **Investigation**: The issue that is being investigated by a technician.

- **Fixing**: The issue is being fixed by a technician.

- **Fixed**: The issue is fixed.

Each status has its own requirements as to which fields must be present and which fields can be changed.

> [!NOTE]
> Information on how to set up the *ModuleSettings* and *DomHelper* are not included here. For an example of this, see [Invoice app example](xref:DOM_Invoice_app_example).

## Creating section definitions

First, one `SectionDefinition` is created containing four fields:

- **Reporter Name**: The name of the person reporting the issue.
- **Issue Text**: A description of the issue.
- **Technician Name**: The name of the technician who fixed the issue.
- **Fixed Date**: The date of when the issue was fixed.

```csharp
// Construct the FieldDescriptors
var reporterNameFieldDescriptor = ConstructFieldDescriptor("Reporter Name", typeof(string));
var issueTextFieldDescriptor = ConstructFieldDescriptor("Issue Text", typeof(string));
var technicianNameFieldDescriptor = ConstructFieldDescriptor("Technician Name", typeof(string));
var fixedDateFieldDescriptor = ConstructFieldDescriptor("Fixed Date", typeof(DateTime));

// Create a SectionDefinition that contains the FieldDescriptors
var sectionDefinition = new CustomSectionDefinition(){ Name = "IssueDataSectionDefinition" };
sectionDefinition.AddOrReplaceFieldDescriptor(reporterNameFieldDescriptor);
sectionDefinition.AddOrReplaceFieldDescriptor(issueTextFieldDescriptor);
sectionDefinition.AddOrReplaceFieldDescriptor(technicianNameFieldDescriptor);
sectionDefinition.AddOrReplaceFieldDescriptor(fixedDateFieldDescriptor);
sectionDefinition = _domHelper.SectionDefinitions.Create(sectionDefinition) as CustomSectionDefinition;
```

```csharp
private FieldDescriptor ConstructFieldDescriptor(string name, Type type)
{
    return new FieldDescriptor()
    {
        ID = new FieldDescriptorID(Guid.NewGuid()),
        FieldType = type,
        Name = name
    };
}
```

## Creating the DOM behavior definition

Next, the `DomBehaviorDefinition` that links to the `SectionDefinitions` should be created.

### Defining statuses and transitions

First, define the statuses and the transitions.

```csharp
// Define the statuses (id, display name)
var statuses = new List<DomStatus>()
{
    new DomStatus("new_status", "New"),
    new DomStatus("investigation_status", "Investigation"),
    new DomStatus("fixing_status", "Fixing"),
    new DomStatus("fixed_status", "Fixed")
};

// Define the transitions (id, from, to)
var transitions = new List<DomStatusTransition>()
{
    new DomStatusTransition("new_to_investigation", "new_status", "investigation_status"),
    new DomStatusTransition("investigation_to_fixing", "investigation_status", "fixing_status"),
    new DomStatusTransition("fixing_to_fixed", "fixing_status", "fixed_status")
};
```

### New status link

Next, a `DomStatusSectionDefinitionLink` can be defined for each status.

To create a new issue, the reporter name and issue description can be filled in.

```csharp
var newLinkId = new DomStatusSectionDefinitionLinkId("new_status", sectionDefinition.GetID());
var newLink = new DomStatusSectionDefinitionLink(newLinkId)
{
    FieldDescriptorLinks = new List<DomStatusFieldDescriptorLink>()
    {
        new DomStatusFieldDescriptorLink(reporterNameFieldDescriptor.ID), // Optional
        new DomStatusFieldDescriptorLink(issueTextFieldDescriptor.ID)     // Optional
    }
};
```

### Investigation status link

When transitioning to the status *Investigation*, the reporter name and issue text must both have a valid value. The reporter name can also no longer be changed, while the issue text can be amended with comments. When an issue has this status, the name of the technician who will investigate or fix the issue can be added.

```csharp
var investigationLinkId = new DomStatusSectionDefinitionLinkId("investigation_status", sectionDefinition.GetID());
var investigationLink = new DomStatusSectionDefinitionLink(investigationLinkId)
{
    FieldDescriptorLinks = new List<DomStatusFieldDescriptorLink>()
    {
        new DomStatusFieldDescriptorLink(reporterNameFieldDescriptor.ID)
            { RequiredForStatus = true, ReadOnly = true }, // Required & Read-Only
        new DomStatusFieldDescriptorLink(issueTextFieldDescriptor.ID)
            { RequiredForStatus = true, ReadOnly = true }, // Required
        new DomStatusFieldDescriptorLink(technicianNameFieldDescriptor.ID), // Optional
    }
};
```

### Fixing status link

When transitioning to the status *Fixing*, the name of the technician who will fix the issue must be present and valid. However, it can still be changed. The date when the issue was fixed has now also become optional, so it can be filled in before the transition to the *Fixed* status.

```csharp
var fixingLinkId = new DomStatusSectionDefinitionLinkId("fixing_status", sectionDefinition.GetID());
var fixingLink = new DomStatusSectionDefinitionLink(fixingLinkId)
{
    FieldDescriptorLinks = new List<DomStatusFieldDescriptorLink>()
    {
        new DomStatusFieldDescriptorLink(reporterNameFieldDescriptor.ID)
            { RequiredForStatus = true, ReadOnly = true }, // Required & Read-Only
        new DomStatusFieldDescriptorLink(issueTextFieldDescriptor.ID)
            { RequiredForStatus = true, ReadOnly = true }, // Required
        new DomStatusFieldDescriptorLink(technicianNameFieldDescriptor.ID), // Required
        new DomStatusFieldDescriptorLink(fixedDateFieldDescriptor.ID)       // Optional
    }
};
```

### Fixed status link

Before an issue can transition to the *Fixed* status, a valid value for the technician's name and the date are required. When an issue has this status, all values are read-only.

```csharp
var fixedLinkId = new DomStatusSectionDefinitionLinkId("fixed_status", sectionDefinition.GetID());
var fixedLink = new DomStatusSectionDefinitionLink(fixedLinkId)
{
    FieldDescriptorLinks = new List<DomStatusFieldDescriptorLink>()
    {
        new DomStatusFieldDescriptorLink(reporterNameFieldDescriptor.ID)
            { RequiredForStatus = true, ReadOnly = true}, // Required & Read-Only
        new DomStatusFieldDescriptorLink(issueTextFieldDescriptor.ID)
            { RequiredForStatus = true, ReadOnly = true}, // Required & Read-Only
        new DomStatusFieldDescriptorLink(technicianNameFieldDescriptor.ID)
            { RequiredForStatus = true, ReadOnly = true}, // Required & Read-Only
        new DomStatusFieldDescriptorLink(fixedDateFieldDescriptor.ID)
            { RequiredForStatus = true, ReadOnly = true}  // Required & Read-Only
    }
};
```

### Construct and save the DOM behavior definition

Now all statuses, the transition, and the links to a `DomBehaviorDefinition` can be added.

```csharp
// Construct the DomBehaviorDefinition
var domBehaviorDefinition = new DomBehaviorDefinition()
{
    ID = new DomBehaviorDefinitionId(Guid.NewGuid()),
    Name = "Issue Tracking Behavior",
    InitialStatusId = "new_status",
    Statuses = statuses,
    StatusTransitions = transitions,
    StatusSectionDefinitionLinks = new List<DomStatusSectionDefinitionLink>()
    {
        newLink,
        investigationLink,
        fixingLink,
        fixedLink
    }
};

// Save the DomBehaviorDefinition
domBehaviorDefinition = _domHelper.DomBehaviorDefinitions.Create(domBehaviorDefinition);
```

## Creating the DOM definition

The last part of the setup is the creation of the `DomDefinition` that forms a link between the configuration and the `DomInstances`.

```csharp
// Create a DomDefinition that is linked to the DomBehaviorDefinition
var domDefinition = new DomDefinition()
{
    ID = new DomDefinitionId(Guid.NewGuid()),
    Name = "Issue Tracking",
    DomBehaviorDefinitionId = domBehaviorDefinition.ID
};

domDefinition = _domHelper.DomDefinitions.Create(domDefinition);
```

## Creating and transitioning a DOM instance

A `DomInstance` (representing an issue) can now be created and transitioned through the different statuses.

```csharp
// John was grabbing a coffee in the kitchen when he noticed that one of the lights is not working
var domInstance = new DomInstance()
{
    ID = new DomInstanceId(Guid.NewGuid()),
    DomDefinitionId = domDefinition.ID,
    StatusId = "new_status" // Can be left empty if it matches the initial status
};
domInstance.AddOrUpdateFieldValue(sectionDefinition, reporterNameFieldDescriptor, "John");
var description = "One of the lights in the kitchen on the 2nd floor does not work";
domInstance.AddOrUpdateFieldValue(sectionDefinition, issueTextFieldDescriptor, description);
domInstance = _domHelper.DomInstances.Create(domInstance);

// Technician Bob sees the new issue and decides to investigate it
domInstance = _domHelper.DomInstances.DoStatusTransition(domInstance.ID, "new_to_investigation");
domInstance.AddOrUpdateFieldValue(sectionDefinition, technicianNameFieldDescriptor, "Bob");
domInstance = _domHelper.DomInstances.Update(domInstance);

// Bob confirms the issue but also sees that this is one of those special new LED lights he has no experience with.
// He updates the issue description and assigns it to his colleague, Roger.
description += "\r\n";
description += "Note from Bob: It is one of the LED lights. I assigned it to Roger";
domInstance.AddOrUpdateFieldValue(sectionDefinition, issueTextFieldDescriptor, description);
domInstance.AddOrUpdateFieldValue(sectionDefinition, technicianNameFieldDescriptor, "Roger");

// Roger saw that this issue was assigned to him. He transitioned it to 'Fixing' and went to the kitchen with a new light.
domInstance = _domHelper.DomInstances.DoStatusTransition(domInstance.ID, "investigation_to_fixing");

// Once fixed, Roger added the current date and transitioned the DomInstance to 'Fixed'
domInstance.AddOrUpdateFieldValue(sectionDefinition, fixedDateFieldDescriptor, DateTime.Now);
domInstance = _domHelper.DomInstances.Update(domInstance);
_domHelper.DomInstances.DoStatusTransition(domInstance.ID, "fixing_to_fixed");
```
