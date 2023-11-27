---
uid: DOM_Remove_FieldDescriptor_Definition
---

# Removing a *FieldDescriptor* from a definition

In this tutorial, we have an existing DOM model with a phone number field that we no longer need and thus want to remove. This is done by removing a *FieldDescriptor* from a *SectionDefinition* which you will learn here.

Estimated duration: 10 minutes.

> [!NOTE]
> This tutorial uses DataMiner version 10.3.12. This is the minimum version where a *FieldDescriptor* can be removed using this procedure.

# Overview

There are a few steps that need to be done before an existing *FieldDescriptor* can be removed. We first need to mark the field as 'soft-deleted'.
The soft-delete option on a *FieldDescriptor* prevents the creation of more DOM instances using that FieldDescriptor. Later, it can be completely removed.

If the field value for the *FieldDescriptor* is used by a DOM instance, that value needs to be removed from those instances before removing the descriptor. If that *FieldDescriptor* is not used, it can be immediately removed (see Step 4: Delete *FieldDescriptor* from the section definition).

- [Step 1: DOM setup](#step-1-dom-setup)

- [Step 2: Soft delete one of the fields](#step-2-soft-delete-one-of-the-fields)

- [Step 3: Remove field from existing instances](#step-3-remove-field-from-existing-instances)

- [Step 4: Delete *FieldDescriptor* from the section definition](#step-4-delete-fielddescriptor-from-the-section-definition)

# Step 1: DOM setup
In [creating a basic DOM setup](xref:DOM_Create_Basic_Setup) you can find a setup that will be used during this tutorial. You can also use your own and move on to [step 2](#step-2-soft-delete-one-of-the-fields), following all subsequent steps accordingly.

# Step 2: Soft delete one of the fields

The provided code below accomplishes the following:

- The *FieldDescriptor* we want to delete is retrieved from the *SectionDefinition*. 

- The *IsSoftDeleted* property of the *FieldDescriptor* is set to *true*. 

- The *SectionDefinition* is updated.

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

After you have soft-deleted the *FieldDescriptor*, you should no longer see it in your low-code app while creating a new instance.

![Step2](~/user-guide/images/DOM_Remove_FieldDescriptor_Definition_Step2.png)

# Step 3: Remove field from existing instances

The provided code below accomplishes the following:

- All instances using the *SectionDefinition* are retrieved.

- The *FieldValues* for that *FieldDescriptor* are removed from the section in the instances. 

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

After the values has been removed, the phone number for each person should no longer be visible in your low-code app.

![Step3](~/user-guide/images/DOM_Remove_FieldDescriptor_Definition_Step3.png)

# Step 4: Delete *FieldDescriptor* from the section definition

The provided code below accomplishes the following: 

- The *FieldDescriptor* is deleted from the *SectionDefinition*.

- The *SectionDefinition* is updated.

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

Optionally, you can inspect the *SectionDefinition* with the [SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool) to check the phone number is now completely removed.

![Step4](~/user-guide/images/DOM_Remove_FieldDescriptor_Definition_Step4.png)