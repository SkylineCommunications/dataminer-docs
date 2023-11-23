---
uid: DOM_Remove_FieldDescriptor_Definition
---

# Removing a field descriptor from a definition

In this tutorial, you will learn how to remove a *FieldDescriptor* from a *SectionDefinition*.

Estimated duration: 10 minutes.

> [!NOTE]
> This tutorial uses DataMiner version 10.3.12

# Overview

The soft-delete option on a field descriptor prevents the creation of more DOM instances using that field descriptor. Later, it can be completely removed.

If the field value for the field descriptor is used by a DOM instance, that value needs to be removed from those instances before removing the descriptor. If that field descriptor is not used, it can be immediately removed (see Step 4: Delete field descriptor from the section definition).

- [Step 1: DOM setup](#step-1-dom-setup)

- [Step 2: Soft delete one of the fields](#step-2-soft-delete-one-of-the-fields)

- [Step 3: Remove field from existing instances](#step-3-remove-field-from-existing-instances)

- [Step 4: Delete field descriptor from the section definition](#step-4-delete-field-descriptor-from-the-dom-definition)

# Step 1: DOM setup
In [creating a basic DOM setup](xref:DOM_Create_Basic_Setup) you can find a setup that will be used during this tutorial. You can also use your own and move on to [step 2](#step-2-soft-delete-one-of-the-fields), following all subsequent steps accordingly.

# Step 2: Soft delete one of the fields

The provided code below accomplishes the following:

- The *FieldDescriptor* we want to delete is retrieved from the *SectionDefinition*. 

- The *IsSoftDeleted* property of the field descriptor is set to *true*. 

- The *SectionDefinition* is updated.

```C#
using System;
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
        public void Run(Engine engine)
        {
            var moduleName = "people_app";
            var domHelper = new DomHelper(engine.SendSLNetMessages, moduleName);

            var peopleSectionDefinition = domHelper.SectionDefinitions.Read(
                SectionDefinitionExposers.Name.Equal("PeopleSectionDefinition")).FirstOrDefault() as CustomSectionDefinition;
            if (peopleSectionDefinition == null)
            {
                engine.GenerateInformation("Did not find the 'PeopleSectionDefinition'");
                return;
            }

            var fieldDescriptors = peopleSectionDefinition.GetAllFieldDescriptors().ToList();
            var phoneNumberFieldDescriptor = fieldDescriptors?.FirstOrDefault(one => one.Name == "Phone number");

            if (phoneNumberFieldDescriptor == null)
            {
                engine.GenerateInformation("Did not find the 'Phone number' fieldDescriptor");
                return;
            }

            // Update the fieldDescriptor
            phoneNumberFieldDescriptor.IsSoftDeleted = true;
            domHelper.SectionDefinitions.Update(peopleSectionDefinition);
        }
    }
}
```

After you have soft-deleted the field descriptor, you should no longer see it in your low-code app while creating a new instance.

![Step2](~/user-guide/images/DOM_Remove_FieldDescriptor_Definition_Step2.png)

# Step 3: Remove field from existing instances

The provided code below accomplishes the following:

- All instances using the *SectionDefinition* are retrieved.

- The *FieldValues* for that *FieldDescriptor* are removed from the section in the instances. 

- The instances are updated. 

```C#
using System;
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
        public void Run(Engine engine)
        {
            var moduleName = "people_app";
            var domHelper = new DomHelper(engine.SendSLNetMessages, moduleName);

            var peopleSectionDefinition = domHelper.SectionDefinitions.Read(
                SectionDefinitionExposers.Name.Equal("PeopleSectionDefinition")).FirstOrDefault() as CustomSectionDefinition;
            if (peopleSectionDefinition == null)
            {
                engine.GenerateInformation("Did not find the 'PeopleSectionDefinition'");
                return;
            }
            
            var softDeletedFieldDescriptor = peopleSectionDefinition.GetAllFieldDescriptors().First(one => one.IsSoftDeleted);

            var pagingHelper = domHelper.DomInstances.PreparePaging(
                DomInstanceExposers.SectionDefinitionIds.Contains(peopleSectionDefinition.GetID().Id));
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

            instancesToUpdate.ForEach(one => domHelper.DomInstances.Update(one));
        }
	}
}
```

After the values has been removed, the phone number for each person should no longer be visible in your low-code app.

![Step3](~/user-guide/images/DOM_Remove_FieldDescriptor_Definition_Step3.png)

# Step 4: Delete field descriptor from the section definition

The provided code below accomplishes the following: 

- The *FieldDescriptor* is deleted from the *SectionDefinition*.

- The *SectionDefinition* is updated.

```C#
using System;
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
        public void Run(Engine engine)
        {
            var moduleName = "people_app";
            var domHelper = new DomHelper(engine.SendSLNetMessages, moduleName);

            var peopleSectionDefinition = domHelper.SectionDefinitions.Read(
                SectionDefinitionExposers.Name.Equal("PeopleSectionDefinition")).FirstOrDefault() as CustomSectionDefinition;
            if (peopleSectionDefinition == null)
            {
                engine.GenerateInformation("Did not find the 'PeopleSectionDefinition'");
                return;
            }
            
            var softDeletedFieldDescriptor = peopleSectionDefinition.GetAllFieldDescriptors().First(one => one.IsSoftDeleted);
            
            peopleSectionDefinition.RemoveFieldDescriptor(softDeletedFieldDescriptor.ID);
            domHelper.SectionDefinitions.Update(peopleSectionDefinition);
        }
    }
}
```

Inspect the SectionDefinition with the [SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool). The phone number is now completely removed.

![Step4](~/user-guide/images/DOM_Remove_FieldDescriptor_Definition_Step4.png)