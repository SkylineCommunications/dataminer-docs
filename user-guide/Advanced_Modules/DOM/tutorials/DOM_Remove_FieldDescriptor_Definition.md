---
uid: DOM_Remove_FieldDescriptor_Definition
---

# Removing a field descriptor from a definition

This tutorial shows how you can remove a field descriptor from a section definition. It uses an example of an existing DOM model with a phone number field that is no longer needed and therefore needs to be removed.

Estimated duration: 10 minutes.

> [!NOTE]
> The content and screenshots for this tutorial have been created in DataMiner version 10.3.12.

## Prerequisites

- DataMiner version 10.3.12 or higher

- A DataMiner System with an [indexing database](xref:Indexing_Database)

- Basic knowledge of DataMiner Object Models (DOM)

## Overview

- [Step 1: DOM setup](#step-1-dom-setup)

- [Step 2: Soft-delete the field](#step-2-soft-delete-the-field)

- [Step 3: Remove the field from existing instances](#step-3-remove-the-field-from-existing-instances)

- [Step 4: Delete the field descriptor from the section definition](#step-4-delete-the-field-descriptor-from-the-section-definition)

- [Step 5 - Optional: Inspect the SectionDefinition with SLNetClientTest tool](#step-5---optional-inspect-the-sectiondefinition-with-slnetclienttest-tool)

## Step 1: DOM setup

This tutorial assumes that you use the setup from the tutorial [Creating a basic DOM setup](xref:DOM_Create_Basic_Setup), but you can also use a setup of your own.

## Step 2: Soft-delete the field

Before an existing field descriptor can be removed, you first need to mark the field as "soft-deleted". The soft-delete option on a `FieldDescriptor` object prevents the creation of more DOM instances using that field descriptor.

Use the code provided below to accomplish the following:

- The `FieldDescriptor` that should be deleted is retrieved from the `SectionDefinition`.

- The `IsSoftDeleted` property of the `FieldDescriptor` is set to *true*.

- The `SectionDefinition` is updated.

```C#
using System.Linq;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.Sections;

namespace Tutorial
{
    ///<summary>
    /// This script will set the "IsSoftDeleted" property of the "Phone number" FieldDescriptor of the SectionDefinition to true. 
    ///</summary>
    public class Script
    {
        // DOM object names are declared here, you can easily update this to your desired ones without having to update the actual script. 
        private readonly string _moduleName = "people_app";
        private readonly string _sectionDefinitionName = "PeopleSectionDefinition";
        private readonly string _fieldDescriptorName = "Phone number";

        public void Run(Engine engine)
        {
            var domHelper = new DomHelper(engine.SendSLNetMessages, _moduleName);

            var peopleSectionDefinition = domHelper.SectionDefinitions.Read(
                SectionDefinitionExposers.Name.Equal(_sectionDefinitionName)).FirstOrDefault() as CustomSectionDefinition;
            if (peopleSectionDefinition == null)
            {
                engine.GenerateInformation($"Did not find the '{_sectionDefinitionName}'");
                return;
            }

            var fieldDescriptors = peopleSectionDefinition.GetAllFieldDescriptors().ToList();
            var phoneNumberFieldDescriptor = fieldDescriptors?.FirstOrDefault(one => one.Name == _fieldDescriptorName);

            if (phoneNumberFieldDescriptor == null)
            {
                engine.GenerateInformation($"Did not find the '{_fieldDescriptorName}' FieldDescriptor");
                return;
            }

            // Update the fieldDescriptor
            phoneNumberFieldDescriptor.IsSoftDeleted = true;
            domHelper.SectionDefinitions.Update(peopleSectionDefinition);
        }
    }
}
```

After you have implemented this, the field descriptor is soft-deleted, and you should no longer see it in your low-code app when you create a new instance.

![Low-code app example](~/user-guide/images/DOM_Remove_FieldDescriptor_Definition_Step2.png)

## Step 3: Remove the field from existing instances

> [!NOTE]
> If the field descriptor is not used in any DOM instances, you can skip this step.

If the field value for the field descriptor is used by one or more DOM instances, that value needs to be removed from those instances before you can remove the descriptor.

Use the code provided below to accomplish the following:

- All instances using the `SectionDefinition` are retrieved.

- The field values for the `FieldDescriptor` are removed from the section in the instances.

- The instances are updated.

```C#
using System.Collections.Generic;
using System.Linq;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.Sections;
using Skyline.DataMiner.Net.Helper;

namespace Tutorial
{
    ///<summary>
    /// This script will get all instances using the SectionDefinition and delete the fields for the "Phone number" FieldDescriptor.
    ///</summary>
    public class Script
    {
        private readonly string _moduleName = "people_app";
        private readonly string _sectionDefinitionName = "PeopleSectionDefinition";

        public void Run(Engine engine)
        {
            var domHelper = new DomHelper(engine.SendSLNetMessages, _moduleName);

            var peopleSectionDefinition = domHelper.SectionDefinitions.Read(
                SectionDefinitionExposers.Name.Equal(_sectionDefinitionName)).FirstOrDefault() as CustomSectionDefinition;
            if (peopleSectionDefinition == null)
            {
                engine.GenerateInformation($"Did not find the '{_sectionDefinitionName}'");
                return;
            }

            var softDeletedFieldDescriptor = peopleSectionDefinition.GetAllFieldDescriptors().First(one => one.IsSoftDeleted);
            var pagingHelper = domHelper.DomInstances.PreparePaging(DomInstanceExposers.FieldValues
                .KeyExists(softDeletedFieldDescriptor.ID.Id.ToString()).Equal(true));
            var instancesToUpdate = new HashSet<DomInstance>();
            while (pagingHelper.HasNextPage())
            {
                pagingHelper.MoveToNextPage();
                var domInstances = pagingHelper.GetCurrentPage();
                foreach (var instance in domInstances)
                {
                    var sections = instance.Sections;
                    foreach (var section in sections)
                    {
                        var softDeletedFieldValues = section.FieldValues.Where(
                            one => one.FieldDescriptorID.Equals(softDeletedFieldDescriptor.ID)).ToList();
                        if (softDeletedFieldValues.Any())
                        {
                            softDeletedFieldValues.ForEach(one => section.RemoveFieldValueById(one.FieldDescriptorID));
                            instancesToUpdate.Add(instance);
                        }
                    }
                }
            }

            engine.GenerateInformation($"Updating {instancesToUpdate.Count} DOM instances");
            instancesToUpdate.ForEach(one => domHelper.DomInstances.Update(one));
        }
    }
}
```

After you have implemented this, the phone number for each person should no longer be visible in your low-code app.

![Step3](~/user-guide/images/DOM_Remove_FieldDescriptor_Definition_Step3.png)

## Step 4: Delete the field descriptor from the section definition

Once the field descriptor has been soft-deleted and you have made sure that it is not used in any DOM instances, you can delete the field descriptor from the section definition.

Use the code provided below to accomplish the following:

- The `FieldDescriptor` is deleted from the `SectionDefinition`.

- The `SectionDefinition` is updated.

```C#
using System.Linq;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.Sections;

namespace Tutorial
{
    ///<summary>
    /// This script will remove the FieldDescriptor and update the SectionDefinition. 
    ///</summary>
    public class Script
    {
        private readonly string _moduleName = "people_app";
        private readonly string _sectionDefinitionName = "PeopleSectionDefinition";

        public void Run(Engine engine)
        {
            var domHelper = new DomHelper(engine.SendSLNetMessages, _moduleName);

            var peopleSectionDefinition = domHelper.SectionDefinitions.Read(
                SectionDefinitionExposers.Name.Equal(_sectionDefinitionName)).FirstOrDefault() as CustomSectionDefinition;
            if (peopleSectionDefinition == null)
            {
                engine.GenerateInformation($"Did not find the '{_sectionDefinitionName}'");
                return;
            }

            var softDeletedFieldDescriptor = peopleSectionDefinition.GetAllFieldDescriptors().FirstOrDefault(one => one.IsSoftDeleted);

            if (softDeletedFieldDescriptor == null)
            {
                engine.GenerateInformation("Did not find the soft-deleted FieldDescriptor");
                return;
            }

            peopleSectionDefinition.RemoveFieldDescriptor(softDeletedFieldDescriptor.ID);
            domHelper.SectionDefinitions.Update(peopleSectionDefinition);
        }
    }
}
```

## Step 5 - Optional: Inspect the SectionDefinition with SLNetClientTest tool

If you want to be entirely sure the phone number is completely removed, you can inspect the `SectionDefinition` with the SLNetClientTest tool.

> [!WARNING]
> Always be extremely careful when using SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

1. [Open the SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).

1. Select *Advanced* > *Apps* > *DataMiner Object Model*.

   The different module settings will be shown.

1. Select the one you want to inspect (in this case "people_app") and click *Open*.

1. At the top, select the *SectionDefinitions* tab and open the definition you want to inspect.

   In this case, you will see that the phone number has been completely removed from the *SectionDefinition*:

   ![SLNetClientTest tool](~/user-guide/images/DOM_Remove_FieldDescriptor_Definition_Optional.png)
