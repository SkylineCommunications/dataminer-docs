---
uid: DOM_Create_Basic_Setup
---

# Creating a basic DOM setup

In this small tutorial, a basic DOM setup is created. 
Each DOM instance will represent a person and contains the following information:

- First name

- Last name

- Phone number

- Job title

The provided code below accomplishes this by:

- Creating a DOM module.

- Creating a DOM definition links to a *SectionDefinition* containing a *GenericEnumFieldDescriptor*.

- Creating a DOM instance with a value for each *FieldDescriptor*.

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