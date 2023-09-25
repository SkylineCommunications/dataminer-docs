---
uid: DOM_Remove_Enum_Entry
---

# How to remove an enum entry from a GenericEnumFieldDescriptor

This tutorial shows you how to soft-delete and permanently delete an enum entry from a GenericEnumFieldDescriptor.

## Overview

- [Step 1: Setup DOM](#step-1-setup-dom)
- [Step 2: Soft-delete the enum entry](#step-2-soft-delete-the-enum-entry)
- [Step 3: Remove the value from existing instances](#step-3-remove-the-value-from-existing-instances)
- [Step 4: Remove the enum entry from the DOM definition](#step-4-remove-the-enum-entry-from-the-dom-definition)

The soft-delete option on an enum entry hides that entry to users. That way users are unable to create more DOM instances using that entry. Later on the entry can be completely removed.
If the entry is used by a DOM instance, that value needs to be removed from those instances before removing the entry from the definition. If that enum entry is not used, it can immediately be removed (see [Step 4: Remove the enum entry from the DOM definition](#step-4-remove-the-enum-entry-from-the-dom-definition)).

## Step 1: Setup DOM

This setup is purely for the tutorial, you can use your own setup and apply the other steps to your setup (see [Step 2: Soft-delete the enum entry](#step-2-soft-delete-the-enum-entry)).

The given code does the following:
1. Creates a DOM module
1. Creates a DOM definition containing a GenericEnumFieldDescriptor
1. Creates a DOM instance using that enum entry of that DOM definition

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.Apps.Modules;
using Skyline.DataMiner.Net.Apps.Sections.SectionDefinitions;
using Skyline.DataMiner.Net.GenericEnums;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.Sections;


namespace Tutorial
{
    ///<summary>
    /// This script will create a basic people app with one DomInstance.
    /// Each domInstance for this sectionDefinition will contain:
    ///     - first name of the person
    ///     - last name of the person
    ///     - phone number of the person
    ///     - job title of the person
    ///</summary>
    public class Script
    {
        private const string ModuleName = "people_app";
        private DomHelper _domHelper;
        private Engine _engine;

        public void Run(Engine engine)
        {
            _engine = engine;
            _domHelper = new DomHelper(_engine.SendSLNetMessages, ModuleName);
            
            // Create the ModuleSettingsHelper
            var moduleSettingsHelper = new ModuleSettingsHelper(_engine.SendSLNetMessages);

            // Create the default moduleSettings and save it
            var moduleSettings = new ModuleSettings(ModuleName);
            moduleSettingsHelper.ModuleSettings.Create(moduleSettings);

            // Start creating the DOM objects now that you have the domHelper
            var firstNameFieldDescriptor = new FieldDescriptor()
            {
                FieldType = typeof(string),
                IsOptional = false,
                Name = "First name",
                Tooltip = "First name of the person"
            };

            var lastNameFieldDescriptor = new FieldDescriptor()
            {
                FieldType = typeof(string),
                IsOptional = false,
                Name = "Last name",
                Tooltip = "Last name of the person"
            };

            var phoneNumberFieldDescriptor = new FieldDescriptor()
            {
                FieldType = typeof(string),
                IsOptional = false,
                Name = "Phone number",
                Tooltip = "Phone number of the person"
            };

            var genericEnum = new GenericEnum<int>();
            genericEnum.AddEntry("Director", 0);
            genericEnum.AddEntry("Project manager", 1);
            genericEnum.AddEntry("Engineer", 2);
            genericEnum.AddEntry("Secretary", 3);

            var jobTitleFieldDescriptor = new GenericEnumFieldDescriptor()
            {
                FieldType = typeof(GenericEnum<int>),
                IsOptional = true,
                GenericEnumInstance = genericEnum,
                Name = "JobTitle",
                Tooltip = "Job title of the person"
            };

            // Put all the fieldDescriptors in a sectionDefinition
            var sectionDefinition = new CustomSectionDefinition()
            {
                Name = "PeopleSectionDefinition"
            };

            sectionDefinition.AddOrReplaceFieldDescriptor(firstNameFieldDescriptor);
            sectionDefinition.AddOrReplaceFieldDescriptor(lastNameFieldDescriptor);
            sectionDefinition.AddOrReplaceFieldDescriptor(phoneNumberFieldDescriptor);
            sectionDefinition.AddOrReplaceFieldDescriptor(jobTitleFieldDescriptor);

            sectionDefinition = _domHelper.SectionDefinitions.Create(sectionDefinition) as CustomSectionDefinition;

            // Create the domDefinition
            var personDomDefinition = new DomDefinition()
            {
                Name = "PersonDomDefinition",
                SectionDefinitionLinks = new List<SectionDefinitionLink>()
                {
                    new SectionDefinitionLink(sectionDefinition?.GetID())
                }
            };

            personDomDefinition = _domHelper.DomDefinitions.Create(personDomDefinition);

            var sectionDefinitionId = sectionDefinition?.ID;
            var firstNameFieldDescriptorId = firstNameFieldDescriptor.ID;
            var lastNameFieldDescriptorId = lastNameFieldDescriptor.ID;
            var phoneNumberFieldDescriptorId = phoneNumberFieldDescriptor.ID;
            var jobTitleFieldDescriptorId = jobTitleFieldDescriptor.ID;
            var domDefinitionId = personDomDefinition.ID;

            // Create a list of FieldValues for the general Section
            var fieldValues = new List<FieldValue>()
            {
                new FieldValue(firstNameFieldDescriptorId, new ValueWrapper<string>("John")),
                new FieldValue(lastNameFieldDescriptorId, new ValueWrapper<string>("Doe")),
                new FieldValue(phoneNumberFieldDescriptorId, new ValueWrapper<string>("0423482635")),
                new FieldValue(jobTitleFieldDescriptorId, new ValueWrapper<int>(0)),
            };

            // Add them to a Section linked to the ID of the GeneralSectionDefinition
            var generalSection = new Section()
            {
                SectionDefinitionID = sectionDefinitionId
            };

            foreach (var fieldValue in fieldValues)
            {
                generalSection.AddOrReplaceFieldValue(fieldValue);
            }

            // Create of the actual DomInstance
            var domInstance = new DomInstance()
            {
                DomDefinitionId = domDefinitionId,
                Sections = { generalSection }
            };
            domInstance = _domHelper.DomInstances.Create(domInstance);
        }
    }
}
```

To visualize the setup, create a low code app. On that low code app:
1. Drag the DOM definition: *"Object Manager Definitions" > "people_app" > "PersonDomDefinition"*
1. Choose the "Form" visualization
1. Create a query that shows all instances: *"Queries" > "Get object manager instances" > "people_app" > "PersonDomDefinition"*
1. Drag the query and choose "Table" visualization

   ![Step1](~/user-guide/images/DOM_Remove_Enum_Entry_Step1_1.png)

   ![Step1_2](~/user-guide/images/DOM_Remove_Enum_Entry_Step1_2.png)

## Step 2: Soft-delete the enum entry

The given code does the following:
1. Gets the enum entry from the DOM definition
1. Sets the property "IsSoftDeleted" of the enum entry to true
1. Updates the DOM definition

```C#
using System;
using System.Linq;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Sections;


namespace Tutorial
{
    ///<summary>
    /// This script will set the "IsSoftDeleted" property of the enum entry "Director" of the DOM definition.
    ///</summary>
    public class Script
    {
        private const string ModuleName = "people_app";
        private DomHelper _domHelper;
        private Engine _engine;

        public void Run(Engine engine)
        {
            _engine = engine;
            _domHelper = new DomHelper(_engine.SendSLNetMessages, ModuleName);

            // Searching by name, can also use the IDs, it will do less calls and needs less null checks
            var sectionDefinitionName = "PeopleSectionDefinition";
            var fieldDescriptorName = "JobTitle";
            var enumName = "Director";

            var sectionDefinitions = _domHelper.SectionDefinitions.ReadAll();
            var sectionDefinition = sectionDefinitions.First(x => x.GetName() == sectionDefinitionName);
            var fieldDescriptor = sectionDefinition.GetAllFieldDescriptors().First(x => x.Name == fieldDescriptorName) as GenericEnumFieldDescriptor;
            if (fieldDescriptor == null) { return; }
            var enumDelete = fieldDescriptor.GenericEnumInstance.Entries.First(x => x.DisplayName == enumName);
            enumDelete.IsSoftDeleted = true;
            _domHelper.SectionDefinitions.Update(sectionDefinition);
        }
    }
}
```

This example uses the names of the section definition and fielddescriptor. Another option is to use the IDs, that way less calls and null checks are needed, but those IDs still need to be looked up. Note: these IDs will not work, you need the IDs of your setup.

```C#
using System;
using System.Linq;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.Sections;


namespace Tutorial
{
    ///<summary>
    /// This script will set the "IsSoftDeleted" property of the enum entry "Director" of the DOM definition.
    ///</summary>
    public class Script
    {
        private const string ModuleName = "people_app";
        private DomHelper _domHelper;
        private Engine _engine;

        public void Run(Engine engine)
        {
            _engine = engine;
            _domHelper = new DomHelper(_engine.SendSLNetMessages, ModuleName);

            // Searching by ID, can also use the names, it will do more calls, but don't need to lookup IDs
            var enumName = "Director";

            var sectionDefinitionId = new SectionDefinitionID(Guid.Parse("66e11713-28a2-4e6e-84cf-16a539721404"));
            var fieldDescriptorId = new FieldDescriptorID(Guid.Parse("1c149c48-3e56-4798-a92b-368d7ae827b4"));

            var filter = SectionDefinitionExposers.ID.Equal(sectionDefinitionId);

            var sectionDefinition = _domHelper.SectionDefinitions.Read(filter).First();
            var fieldDescriptor = sectionDefinition.GetFieldDescriptorById(fieldDescriptorId) as GenericEnumFieldDescriptor;

            var enumDelete = fieldDescriptor.GenericEnumInstance.Entries.First(x => x.DisplayName == enumName);
            enumDelete.IsSoftDeleted = true;
            _domHelper.SectionDefinitions.Update(sectionDefinition);
        }
    }
}

```

After soft-deletion, you should not see that enum entry in the dropdown of the form on your low code app.

   ![Step2](~/user-guide/images/DOM_Remove_Enum_Entry_Step2.png)

## Step 3: Remove the value from existing instances

The given code does the following:
1. Gets all instances that use the enum entry
1. Removes the enum value
1. Updates the instances

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.Apps.Modules;
using Skyline.DataMiner.Net.Apps.Sections.SectionDefinitions;
using Skyline.DataMiner.Net.GenericEnums;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.Sections;


namespace Tutorial
{
    ///<summary>
    /// This script will remove the enum value "0" (int value of "Director") from all existing instances.
    ///</summary>
    public class Script
    {
        private const string ModuleName = "people_app";
        private DomHelper _domHelper;
        private Engine _engine;

        public void Run(Engine engine)
        {
            _engine = engine;
            _domHelper = new DomHelper(_engine.SendSLNetMessages, ModuleName);

            var sectionDefinitionName = "PeopleSectionDefinition";
            var fieldDescriptorName = "JobTitle";
            var enumValue = 0; // int value of the enum entry "Director" we want to delete

            var sectionDefinitions = _domHelper.SectionDefinitions.ReadAll();
            var sectionDefinition = sectionDefinitions.First(x => x.GetName() == sectionDefinitionName);
            var fieldDescriptor = sectionDefinition.GetAllFieldDescriptors().First(x => x.Name == fieldDescriptorName) as GenericEnumFieldDescriptor;
            if(fieldDescriptor == null){return;}

            var filter = DomInstanceExposers.FieldValues.DomInstanceField(fieldDescriptor.ID).Contains(enumValue);
            var instancesToDelete = _domHelper.DomInstances.Read(filter);

            foreach (var instance in instancesToDelete)
            {
                var section = instance.Sections.First(x => x.SectionDefinitionID.Equals(sectionDefinition.GetID()));
                section.RemoveFieldValueById(fieldDescriptor.ID);
                _domHelper.DomInstances.Update(instance);
            }
        }
    }
}
```

After the removal, you should see that the enum value is removed from the instance.

   ![Step3](~/user-guide/images/DOM_Remove_Enum_Entry_Step3.png)

## Step 4: Remove the enum entry from the DOM definition

The given code does the following:
1. Gets the enum from the DOM definition
1. Removes the enum entry by copying the original enum, but leaving out the one to remove
1. Updates the DOM definition

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.Apps.Modules;
using Skyline.DataMiner.Net.Apps.Sections.SectionDefinitions;
using Skyline.DataMiner.Net.GenericEnums;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.Sections;


namespace Tutorial
{
    ///<summary>
    /// This script will remove the enum entry "Director" from the DOM definition.
    ///</summary>
    public class Script
    {
        private const string ModuleName = "people_app";
        private DomHelper _domHelper;
        private Engine _engine;

        public void Run(Engine engine)
        {
            _engine = engine;
            _domHelper = new DomHelper(_engine.SendSLNetMessages, ModuleName);

            var sectionDefinitionName = "PeopleSectionDefinition";
            var fieldDescriptorName = "JobTitle";
            var enumName = "Director";

            var sectionDefinitions = _domHelper.SectionDefinitions.ReadAll();
            var sectionDefinition = sectionDefinitions.First(x => x.GetName() == sectionDefinitionName);
            var fieldDescriptor = sectionDefinition.GetAllFieldDescriptors().First(x => x.Name == fieldDescriptorName) as GenericEnumFieldDescriptor;
            if (fieldDescriptor == null) { return; }
            var newEnum = new GenericEnum<int>();
            foreach (var entry in fieldDescriptor.GenericEnumInstance.Entries.Where(x => x.DisplayName != enumName))
            {
                newEnum.AddEntry(entry.DisplayName, (int)entry.Value);
            }
            fieldDescriptor.GenericEnumInstance = newEnum;
            _domHelper.SectionDefinitions.Update(sectionDefinition);
        }
    }
}
```

If you look into the DOM definition the enum entry is now completely removed.

   ![Step4](~/user-guide/images/DOM_Remove_Enum_Entry_Step4.png)