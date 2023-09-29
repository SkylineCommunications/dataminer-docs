---
uid: DOM_Remove_Enum_Entry
---

# How to remove an enum entry from a GenericEnumFieldDescriptor

This tutorial shows you how to soft-delete and permanently delete an enum entry from a GenericEnumFieldDescriptor.

> [!Note]
> - To use DOM, your Dataminer system needs to use an [indexing database](xref:Indexing_Database).
> - To soft-delete enum entries, your Dataminer system needs to be using DataMiner 10.3.10 or higher.

The soft-delete option on an enum entry hides that entry to users. That way users are unable to create more DOM instances using that entry. Later on it can be completely removed.
If the entry is used by a DOM instance, that value needs to be removed from those instances before removing it from the descriptor. If that enum entry is not used, it can immediately be removed (see [Step 4: Remove the enum entry from the DOM definition](#step-4-remove-the-enum-entry-from-the-dom-definition)).

## Overview

- [Step 1: Setup DOM](#step-1-setup-dom)
- [Step 2: Soft-delete the enum entry](#step-2-soft-delete-the-enum-entry)
- [Step 3: Remove the value from existing instances](#step-3-remove-the-value-from-existing-instances)
- [Step 4: Remove the enum entry from the DOM definition](#step-4-remove-the-enum-entry-from-the-dom-definition)

## Step 1: Setup DOM

This setup is purely for the tutorial, you can use your own setup and apply the other steps to your setup (see [Step 2: Soft-delete the enum entry](#step-2-soft-delete-the-enum-entry)).

The given code does the following:
1. Creates a DOM module.
1. Creates a DOM definition that links to a SectionDefinition containing a GenericEnumFieldDescriptor.
1. Creates a DOM instance with a value for the enum descriptor.

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

            // Create of the actual DomInstance
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

To visualize the setup, create a low-code app. On that low-code app:
1. Drag the DOM definition onto the canvas: *"Object Manager Definitions" > "people_app" > "PersonDomDefinition"*.
1. Choose the "Form" visualization.
1. Create a GQI query that shows all instances: *"Queries" > "Get object manager instances" > "people_app" > "PersonDomDefinition"*.
1. Drag the GQI query onto the canvas and choose "Table" visualization.

   ![Step1](~/user-guide/images/DOM_Remove_Enum_Entry_Step1_1.png)

   ![Step1_2](~/user-guide/images/DOM_Remove_Enum_Entry_Step1_2.png)

## Step 2: Soft-delete the enum entry

The given code does the following:
1. Gets the enum entry from the SectionDefinition.
1. Sets the property "IsSoftDeleted" of the enum entry to true.
1. Updates the SectionDefinition.

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
    /// This script will set the "IsSoftDeleted" property of the enum entry "Director" of the SectionDefinition.
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

After soft-deletion, you should not see that enum entry in the dropdown of the form on your low-code app anymore.

   ![Step2](~/user-guide/images/DOM_Remove_Enum_Entry_Step2.png)

## Step 3: Remove the value from existing instances

The given code does the following:
1. Gets all instances that use the enum entry.
1. Removes the enum value.
1. Updates the instances.

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

After the removal, you should see that the enum value is removed from the instance.

   ![Step3](~/user-guide/images/DOM_Remove_Enum_Entry_Step3.png)

## Step 4: Remove the enum entry from the DOM definition

The given code does the following:
1. Gets the enum from the DOM definition.
1. Removes the enum entry by copying the original enum, but leaving out the one to remove.
1. Updates the DOM definition.

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

If you look into the DOM definition (this can be done using the [SLNet Client Test Tool](xref:Opening_the_SLNetClientTest_tool)), the enum entry is now completely removed.

   ![Step4](~/user-guide/images/DOM_Remove_Enum_Entry_Step4.png)