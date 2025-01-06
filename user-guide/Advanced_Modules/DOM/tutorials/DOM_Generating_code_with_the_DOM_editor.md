---
uid: DOM_Generating_code_with_the_DOM_editor
---

# Generating code with the DOM editor

In this tutorial, you will learn how to use the DOM editor to generate code from your DOM Module.
You can then use this code, to interact with your DOM modules, definitions and instances more easily.

Expected duration: 10 minutes.

> [!TIP]
> If you are new to DOM, take a look at the [Getting Started with DOM tutorial](xref:DOM_Generating_code_with_the_DOM_editor).

> [!NOTE]
> The content and screenshots for this tutorial have been created in DataMiner 10.4.12 and the DOM Editor version 10.4.4.3.

## Prerequisites

- DataMiner version 10.3.10 or higher
- A DataMiner System with an [indexing database](xref:Indexing_Database) or [Storage as a Service](xref:STaaS).
- Basic knowledge of DataMiner Object Models (DOM)
- [The DOM editor](https://catalog.dataminer.services/details/11674850-aeac-48c4-9f35-03c387ebcf18)

## Overview

This tutorial consists of the following steps:

- [Step 1: Install the example package from the catalog](#step-1-install-the-example-package-from-the-catalog)
- [Step 2: Generate the code](#step-2-generate-the-code)
- [Step 3: Use the code](#step-3-use-the-generated-code)
- [Step 4: Test the code](#step-4-test-the-code)

## Step 1: Install the example package from the catalog

1. Find the **Tutorial - Generating code with the DOM editor** package on the [catalog](https://catalog.dataminer.services) or use [this direct link](https://catalog.dataminer.services/details/6a8c3f13-db15-46a4-931d-96e7c187fa6a)

1. Deploy the catalog item to your dataminer system by clicking the *deploy* button.

   This will create a the **eventmanagement** DOM module, the **event** DOM definition and the **Event Management** low-code application.

1. Open the **Event Management** application by browsing to your dataminer ip, and select it from the landing page.

![Step1](~/user-guide/images/DOM_Generating_code_Step1.png)

## Step 2: Generate the code

1. Open the automation module in dataminer cube.

1. Find and execute the *DOM Editor* script.

1. Click the *Generate Code...* button at the bottom right-hand.

1. Select the *eventmanagement* module, by ticking the checkbox in front of it.

1. Click the *Generate* button.

1. Copy the generated code to your clipboard.

![Step2_1](~/user-guide/images/DOM_Generating_code_Step2_1.png)

![Step2_2](~/user-guide/images/DOM_Generating_code_Step2_2.png)

## Step 3: Use the generated code

### Create a new automation script solution

Create a new automation script solution using Visual Studio and DIS.

While you could develop the Automation script in Cube, creating an Automation script solution in Visual Studio will give you the advantage of having access to all the features of Visual Studio and [DIS](xref:Overall_concept_of_the_DataMiner_Integration_Studio).

To create an Automation script solution:

1. In Visual Studio, select *Create a new project*.

1. Search for *DataMiner Automation Script Solution (Skyline Communications)* in the template search box and click *Next*.

1. Use "Generate Kata DOM" as the name for your solution.

1. Choose a location to save the Automation script solution and click *Next*.

1. Specify *Generate Kata DOM Instances* as the name of your automation script.

1. Fill in your name as the author, and click *create*.

### Add the generated code to your solution

1. Right-click the *Generate Kata DOM Instances_1* project in the Solution explorer and choose *Add > New Item*

![Step3_1](~/user-guide/images/DOM_Generating_code_Step3_1.png)

1. Enter *DomIds* as the name.

1. Replace the content of the DomIds file with the code you copied from the DOM Editor.

![Step3_2](~/user-guide/images/DOM_Generating_code_Step3_2.png)

1. Double click the *Generate Kata Dom Instances_1.cs* file to edit the main script code.

1. Replace the content of the Generate Kata Dom Instances_1.cs file with the code below.

```csharp
namespace GenerateKataDOMInstances_1
{
    using System;

    using DomIds;

    using Skyline.DataMiner.Automation;
    using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
    using Skyline.DataMiner.Net.Sections;

    /// <summary>
    /// Represents a DataMiner Automation script.
    /// </summary>
    public class Script
    {
        public void Run(IEngine engine)
        {
            DateTime kataTime = new DateTime(2025, 01, 03, 10, 00, 00, DateTimeKind.Local);

            DomHelper domHelper = new DomHelper(engine.SendSLNetMessages, DomIds.Eventmanagement.ModuleId);

            for (int week = 0; week < 52; week++)
            {
                DomInstance domInstance = new DomInstance
                {
                    DomDefinitionId = DomIds.Eventmanagement.Definitions.Event,
                };

                domInstance.AddOrUpdateFieldValue(DomIds.Eventmanagement.Sections.EventInfo.Id, DomIds.Eventmanagement.Sections.EventInfo.EventName, $"Kata {week + 1}");
                domInstance.AddOrUpdateFieldValue(DomIds.Eventmanagement.Sections.EventInfo.Id, DomIds.Eventmanagement.Sections.EventInfo.Start, kataTime);
                domInstance.AddOrUpdateFieldValue(DomIds.Eventmanagement.Sections.EventInfo.Id, DomIds.Eventmanagement.Sections.EventInfo.End, kataTime.Add(TimeSpan.FromHours(1)));

                domHelper.DomInstances.Create(domInstance);

                kataTime = kataTime.Add(TimeSpan.FromDays(7));
            }
        }
    }
}
```

> [!IMPORTANT]
   > Visual studio will show some errors if your not using the latest version for some the nuget packages.
   > To resolve this, open the *NuGet package manager* from the tools menu: Tools > Nuget Package Manager > Manage NuGet Packages for Solution.
   > Here navigate to the *Updates tab* and select the *Skyline.DataMiner.Dev.Automation* package.
   > On the right-hand side choose *version 10.3.10* (or higher) and click the install button.
   > ![Step3_3](~/user-guide/images/DOM_Generating_code_Step3_3.png)
   > ![Step3_4](~/user-guide/images/DOM_Generating_code_Step3_4.png)

You can spot the different places in the code where the generated code is used through the *DomIds* prefix.
Using the generated code, we can write code quicker, while making it more readable at the same time.

Without the generated code, the code would contain a series of GUIDs.

> [!TIP]
> It's not required to have the "DomIds" namespace prefix present in the body of the code, it's only added in this tutorial to clearly indicate where where the generated code is used.

### Publish the script

When the automation script is complete, it needs to be published to the DataMiner System. You can do so using the built-in publish feature of DIS. Make sure that DIS can connect to the DataMiner System you want to upload your script to. You will need to [edit the DIS settings](xref:DIS_settings#dma) so the DMA is selectable.

1. In the *Solution Explorer*, double-click *Generate Kata DOM Instances.xml*.

1. At the top of the code window, click the arrow next to the *Publish* button, and select the DataMiner System you want to upload the script to.

## Step 4: Test the code

1. Open the *Event Management* application.

1. Verify there are no entries present.

1. In cube, execute the *Generate Kata DOM Instances* script.

1. An series of events is generated and visible in the app.

> [!IMPORTANT]
   > The events table is not updated automatically. To refresh the table, use the refresh button in the upper right-hand side, just above the table.

![Step4](~/user-guide/images/DOM_Generating_code_Step4.png)
