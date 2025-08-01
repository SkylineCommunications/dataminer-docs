---
uid: DOM_Remove_Enum_Entry
---

# Removing an enum entry from a GenericEnumFieldDescriptor

In this tutorial, you will learn to soft-delete and permanently delete an enum entry from a GenericEnumFieldDescriptor.

Estimated duration: 10 minutes.

> [!NOTE]
> The content and screenshots for this tutorial have been created in DataMiner 10.3.10.

## Prerequisites

- DataMiner version 10.3.10 or higher

- A DataMiner System with an [indexing database](xref:Indexing_Database)

- Basic knowledge of DataMiner Object Models (DOM)

## Overview

The soft-delete option on an enum entry hides that entry from users, preventing the creation of more DOM instances using that entry. Later, it can be completely removed.

If the entry is used by a DOM instance, that value needs to be removed from those instances before removing it from the descriptor. If that enum entry is not used, it can be immediately removed (see [Step 4: Remove the enum entry from the DOM definition](#step-4-remove-the-enum-entry-from-the-dom-definition)).

- [Step 1: DOM setup](#step-1-dom-setup)

- [Step 2: Soft-delete the enum entry](#step-2-soft-delete-the-enum-entry)

- [Step 3: Remove the value from existing instances](#step-3-remove-the-value-from-existing-instances)

- [Step 4: Remove the enum entry from the DOM definition](#step-4-remove-the-enum-entry-from-the-dom-definition)

## Step 1: DOM setup

This tutorial assumes that you use the setup from the tutorial [Creating a basic DOM setup](xref:DOM_Create_Basic_Setup), but you can also use a setup of your own.

## Step 2: Soft-delete the enum entry

The provided code below accomplishes the following:

- The enum entry (in this example: "Director") is retrieved from the `SectionDefinition`.

- The `IsSoftDeleted` property of the enum entry is set to *true*.

- The `SectionDefinition` is updated.

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

![Step2](~/dataminer/images/DOM_Remove_Enum_Entry_Step2.png)

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

![Step3](~/dataminer/images/DOM_Remove_Enum_Entry_Step3.png)

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

![Step4](~/dataminer/images/DOM_Remove_Enum_Entry_Step4.png)
