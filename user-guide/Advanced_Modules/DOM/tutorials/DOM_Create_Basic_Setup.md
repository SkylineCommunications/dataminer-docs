---
uid: DOM_Create_Basic_Setup
---

# Creating a basic DOM setup

In this tutorial, you will learn how to create a basic DOM setup.

Each DOM instance will represent a person and contain the following information:

- First name

- Last name

- Phone number

- Job title

Estimated duration: 5 minutes.

> [!NOTE]
> The content and screenshots for this tutorial have been created in DataMiner version 10.3.10.

## Prerequisites

- DataMiner version 10.3.10 or higher

- A DataMiner System with an [indexing database](xref:Indexing_Database)

- Basic knowledge of DataMiner Object Models (DOM)

## Overview

- [Step 1: Configure the DOM module](#step-1-configure-the-dom-module)

- [Step 2: Create a low-code app to visualize your setup](#step-2-create-a-low-code-app-to-visualize-your-setup)

## Step 1: Configure the DOM module

Use the code below to accomplish the following:

- A DOM module is created.

- A DOM definition is created linked to a `SectionDefinition` containing a `GenericEnumFieldDescriptor`.

- A DOM instance is created with a value for each `FieldDescriptor`.

```C#
using System.Collections.Generic;
using System.Linq;
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
            genericEnum.AddEntry("Project Manager", 1);
            genericEnum.AddEntry("Engineer", 2);
            genericEnum.AddEntry("Secretary", 3);

            var jobTitleFieldDescriptor = new GenericEnumFieldDescriptor()
            {
                FieldType = typeof(GenericEnum<int>),
                GenericEnumInstance = genericEnum,
                Name = "Job title",
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

            // All of the configuration items have now been created. We can start creating our DOM instance.
            var domInstance = new DomInstance()
            {
                DomDefinitionId = personDomDefinition.ID,
            };

            domInstance.AddOrUpdateFieldValue(sectionDefinition.ID, firstNameFieldDescriptor.ID, "John");
            domInstance.AddOrUpdateFieldValue(sectionDefinition.ID, lastNameFieldDescriptor.ID, "Doe");
            domInstance.AddOrUpdateFieldValue(sectionDefinition.ID, phoneNumberFieldDescriptor.ID, "0423482635");
            domInstance.AddOrUpdateFieldValue(sectionDefinition.ID, jobTitleFieldDescriptor.ID, 0);

            domInstance = domHelper.DomInstances.Create(domInstance);
        }
    }
}
```

## Step 2: Create a low-code app to visualize your setup

Create a low-code app to visualize your DOM setup:

1. Create a low-code app as detailed under [Creating low-code applications](xref:Creating_custom_apps).

1. Drag the DOM definition onto the canvas: *"Object Manager Definitions" > "people_app" > "PersonDomDefinition"*.

1. Apply the [form visualization](xref:DashboardForm).

1. Create a GQI query that shows all instances: *"Queries" > "Get object manager instances" > "people_app" > "PersonDomDefinition"*.

1. Drag the GQI query onto the canvas and apply the [table visualization](xref:DashboardTable).

The result should look like this:

![Step1](~/user-guide/images/DOM_Create_Basic_Setup_Step1_1.png)

![Step1_2](~/user-guide/images/DOM_Create_Basic_Setup_Step1_2.png)
