---
uid: DOM_Remove_Enum_Entry
---

# Removing an enum entry from a GenericEnumFieldDescriptor

In this tutorial, you will learn to soft-delete and permanently delete an enum entry from a GenericEnumFieldDescriptor.

Estimated duration:

> [!NOTE]
> This tutorial uses DataMiner version 10.3.x.

## Prerequisites

- DataMiner version 10.3.10 or higher

- A DataMiner System with an [indexing database](xref:Indexing_Database)

## Overview

The soft-delete option on an enum entry hides that entry from users, preventing the creation of more DOM instances using that entry. Later, it can be completely removed.

If the entry is used by a DOM instance, that value needs to be removed from those instances before removing it from the descriptor. If that enum entry is not used, it can be immediately removed (see [Step 4: Remove the enum entry from the DOM definition](#step-4-remove-the-enum-entry-from-the-dom-definition)).

- [Step 1: DOM setup](#step-1-dom-setup)

- [Step 2: Soft-delete the enum entry](#step-2-soft-delete-the-enum-entry)

- [Step 3: Remove the value from existing instances](#step-3-remove-the-value-from-existing-instances)

- [Step 4: Remove the enum entry from the DOM definition](#step-4-remove-the-enum-entry-from-the-dom-definition)

## Step 1: DOM setup

The provided setup is intended for this tutorial. You can also use your own setup and move on to [step 2](#step-2-soft-delete-the-enum-entry), following all subsequent steps accordingly.

The provided code below accomplishes the following:

- A DOM module is created.

- A DOM definition is created that links to a *SectionDefinition* containing a *GenericEnumFieldDescriptor*.

- A DOM instance is created with a value for the enum descriptor.

```C#
using System;
using System.Collections.Generic;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.Apps.Modules;
using Skyline.DataMiner.Net.Apps.Sections.SectionDefinitions;
using Skyline.DataMiner.Net.GenericEnums;
using Skyline.DataMiner.Net.Sections;

namespace Tutorial
{
    ///<summary>
    /// This script will create a basic people app with one DomInstance.
    /// Each DomInstance for this SectionDefinition will contain:
    ///     - First name of the person
    ///     - Last name of the person
    ///     - Phone number of the person
    ///     - Job title of the person
    ///</summary>
    public class Script
    {
        public void Run(Engine engine)
        {
            var moduleName = "people_app";
            var domHelper = new DomHelper(engine.SendSLNetMessages, moduleName);

            // Create the ModuleSettingsHelper
            var moduleSettingsHelper = new ModuleSettingsHelper(engine.SendSLNetMessages);

            // Create the default ModuleSettings and save it
            var moduleSettings = new ModuleSettings(moduleName);
            moduleSettingsHelper.ModuleSettings.Create(moduleSettings);

            // Start creating the DOM objects now that you have the DomHelper
            var firstNameFieldDescriptor = new FieldDescriptor()
            {
                FieldType = typeof(string),
                Name = "First name",
            };

            var lastNameFieldDescriptor = new FieldDescriptor()
            {
                FieldType = typeof(string),
                Name = "Last name",
            };

            var phoneNumberFieldDescriptor = new FieldDescriptor()
            {
                FieldType = typeof(string),
                Name = "Phone number",
            };

            var genericEnum = new GenericEnum<int>();
            genericEnum.AddEntry("Director", 0);
            genericEnum.AddEntry("Project manager", 1);
            genericEnum.AddEntry("Engineer", 2);
            genericEnum.AddEntry("Secretary", 3);

            var jobTitleFieldDescriptor = new GenericEnumFieldDescriptor()
            {
                FieldType = typeof(GenericEnum<int>),
                GenericEnumInstance = genericEnum,
                Name = "JobTitle",
            };

            // Put all the FieldDescriptors in a SectionDefinition
            var sectionDefinition = new CustomSectionDefinition()
            {
                Name = "PeopleSectionDefinition"
            };

            sectionDefinition.AddOrReplaceFieldDescriptor(firstNameFieldDescriptor);
            sectionDefinition.AddOrReplaceFieldDescriptor(lastNameFieldDescriptor);
            sectionDefinition.AddOrReplaceFieldDescriptor(phoneNumberFieldDescriptor);
            sectionDefinition.AddOrReplaceFieldDescriptor(jobTitleFieldDescriptor);

            sectionDefinition = domHelper.SectionDefinitions.Create(sectionDefinition) as CustomSectionDefinition;

            // Create the DomDefinition
            var personDomDefinition = new DomDefinition()
            {
                Name = "PersonDomDefinition",
                SectionDefinitionLinks = new List<SectionDefinitionLink>()
                {
                    new SectionDefinitionLink(sectionDefinition.GetID())
                }
            };

            personDomDefinition = domHelper.DomDefinitions.Create(personDomDefinition);


            // Create a list of FieldValues for the general Section
            var fieldValues = new List<FieldValue>()
            {
                new FieldValue(firstNameFieldDescriptor.ID, new ValueWrapper<string>("John")),
                new FieldValue(lastNameFieldDescriptor.ID, new ValueWrapper<string>("Doe")),
                new FieldValue(phoneNumberFieldDescriptor.ID, new ValueWrapper<string>("0423482635")),
                new FieldValue(jobTitleFieldDescriptor.ID, new ValueWrapper<int>(0)),
            };

            // Add them to a Section linked to the ID of the GeneralSectionDefinition
            var generalSection = new Section()
            {
                SectionDefinitionID = sectionDefinition.ID
            };

            foreach (var fieldValue in fieldValues)
            {
                generalSection.AddOrReplaceFieldValue(fieldValue);
            }

            // Create the actual DomInstance
            var domInstance = new DomInstance()
            {
                DomDefinitionId = personDomDefinition.ID,
                Sections = { generalSection }
            };
            domInstance = domHelper.DomInstances.Create(domInstance);
        }
    }
}
```

To visualize the setup, create a low-code app.

> [!TIP]
> See [Creating low-code applications](xref:Creating_custom_apps).

In that low-code app:

1. Drag the DOM definition onto the canvas: *"Object Manager Definitions" > "people_app" > "PersonDomDefinition"*.

1. Apply the [form visualization](xref:DashboardForm).

1. Create a GQI query that shows all instances: *"Queries" > "Get object manager instances" > "people_app" > "PersonDomDefinition"*.

1. Drag the GQI query onto the canvas and apply the [table visualization](xref:DashboardTable).

![Step1](~/user-guide/images/DOM_Remove_Enum_Entry_Step1_1.png)

![Step1_2](~/user-guide/images/DOM_Remove_Enum_Entry_Step1_2.png)

## Step 2: Soft-delete the enum entry

The provided code below accomplishes the following:

- The enum entry (in this example: "Director") is retrieved from the *SectionDefinition*.

- The *IsSoftDeleted* property of the enum entry is set to *true*.

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
    /// This script will set the "IsSoftDeleted" property of the enum entry "Director" of the SectionDefinition to "true".
    ///</summary>
    public class Script
    {
        public void Run(Engine engine)
        {
            var moduleName = "people_app";
            var sectionDefinitionName = "PeopleSectionDefinition";
            var fieldDescriptorName = "JobTitle";
            var enumName = "Director";

            var domHelper = new DomHelper(engine.SendSLNetMessages, moduleName);

            var filter = SectionDefinitionExposers.Name.Equal(sectionDefinitionName);

            var sectionDefinition = domHelper.SectionDefinitions.Read(filter).FirstOrDefault();
            var fieldDescriptor = sectionDefinition.GetAllFieldDescriptors()
                .FirstOrDefault(x => x.Name == fieldDescriptorName) as GenericEnumFieldDescriptor;

            if (fieldDescriptor == null)
            {
                engine.GenerateInformation("FieldDescriptor could not be found.");
                return;
            }

            var enumDelete = fieldDescriptor.GenericEnumInstance.Entries.FirstOrDefault(x => x.DisplayName == enumName);

            enumDelete.IsSoftDeleted = true;

            domHelper.SectionDefinitions.Update(sectionDefinition);
        }
    }
}
```

After you have soft-deleted the enum entry, you should no longer see it listed in the *JobTitle* dropdown list in your low-code app.

![Step2](~/user-guide/images/DOM_Remove_Enum_Entry_Step2.png)

## Step 3: Remove the value from existing instances

The provided code below accomplishes the following:

1. All instances that use the enum entry are retrieved.

1. The enum value is removed.

1. The instances are updated.

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
    /// This script will remove the enum value "0" (int value of "Director") from all existing instances.
    ///</summary>
    public class Script
    {
        public void Run(Engine engine)
        {
            var moduleName = "people_app";
            var sectionDefinitionName = "PeopleSectionDefinition";
            var fieldDescriptorName = "JobTitle";
            var enumValue = 0; // int value of the enum entry "Director" we want to delete

            var domHelper = new DomHelper(engine.SendSLNetMessages, moduleName);

            var sectionFilter = SectionDefinitionExposers.Name.Equal(sectionDefinitionName);

            var sectionDefinition = domHelper.SectionDefinitions.Read(sectionFilter).FirstOrDefault();
            var fieldDescriptor = sectionDefinition.GetAllFieldDescriptors().FirstOrDefault(x => x.Name == fieldDescriptorName) as GenericEnumFieldDescriptor;

            if (fieldDescriptor == null)
            {
                engine.GenerateInformation("FieldDescriptor could not be found.");
                return;
            }

            var instanceFilter = DomInstanceExposers.FieldValues.DomInstanceField(fieldDescriptor.ID).Contains(enumValue);
            var pagingHelper = domHelper.DomInstances.PreparePaging(instanceFilter);

            while (pagingHelper.HasNextPage())
            {
                pagingHelper.MoveToNextPage();
                var instancesToDelete = pagingHelper.GetCurrentPage();

                foreach (var instance in instancesToDelete)
                {
                    RemoveFieldValueFromInstance(domHelper, instance, sectionDefinition.GetID(), fieldDescriptor.ID);
                }
            }
        }

        private void RemoveFieldValueFromInstance(DomHelper domHelper, DomInstance domInstance, SectionDefinitionID sectionDefinitionId, FieldDescriptorID fieldDescriptorId)
        {
            var section = domInstance.Sections.FirstOrDefault(x => x.SectionDefinitionID.Equals(sectionDefinitionId));
            if (section.RemoveFieldValueById(fieldDescriptorId))
            {
                domHelper.DomInstances.Update(domInstance);
            }
        }
    }
}
```

After the enum value has been removed, it should no longer be visible in your low-code app.

![Step3](~/user-guide/images/DOM_Remove_Enum_Entry_Step3.png)

## Step 4: Remove the enum entry from the DOM definition

The provided code below accomplishes the following:

1. The enum is retrieved from the DOM definition.

1. The enum entry is removed by copying the original enum, but leaving out the one to remove.

1. The DOM definition is updated.

```C#
using System;
using System.Linq;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.GenericEnums;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.Sections;

namespace Tutorial
{
    ///<summary>
    /// This script will remove the enum entry "Director" from the DomDefinition.
    ///</summary>
    public class Script
    {
        public void Run(Engine engine)
        {
            var moduleName = "people_app";
            var sectionDefinitionName = "PeopleSectionDefinition";
            var fieldDescriptorName = "JobTitle";
            var enumName = "Director";

            var domHelper = new DomHelper(engine.SendSLNetMessages, moduleName);

            var filter = SectionDefinitionExposers.Name.Equal(sectionDefinitionName);

            var sectionDefinition = domHelper.SectionDefinitions.Read(filter).FirstOrDefault();
            var fieldDescriptor = sectionDefinition.GetAllFieldDescriptors().FirstOrDefault(x => x.Name == fieldDescriptorName) as GenericEnumFieldDescriptor;

            if (fieldDescriptor == null)
            {
                engine.GenerateInformation("FieldDescriptor could not be found.");
                return;
            }

            var newEnum = new GenericEnum<int>();
            foreach (var entry in fieldDescriptor.GenericEnumInstance.Entries.Where(x => x.DisplayName != enumName))
            {
                newEnum.AddEntry(entry.DisplayName, (int)entry.Value);
            }
            fieldDescriptor.GenericEnumInstance = newEnum;

            domHelper.SectionDefinitions.Update(sectionDefinition);
        }
    }
}
```

Inspect the DOM definition with the [SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool). The enum entry is now completely removed.

![Step4](~/user-guide/images/DOM_Remove_Enum_Entry_Step4.png)