---
uid: DOM_Generating_code_with_the_DOM_editor
---

# Generating code with the DOM Editor

In this tutorial, you will learn how to use the DOM Editor to generate code from your DOM module. You can then use this code to interact with your DOM modules, definitions, and instances more easily.

Expected duration: 10 minutes.

> [!TIP]
> See also: [Kata #57: Generating code with the DOM Editor](https://community.dataminer.services/courses/kata-57/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

> [!NOTE]
> The content and screenshots for this tutorial have been created in DataMiner 10.4.12 with DOM Editor version 10.4.4.3.

## Prerequisites

- DataMiner version 10.3.10 or higher.
- A DataMiner System with an [indexing database](xref:Indexing_Database) or [Storage as a Service](xref:STaaS).
- [DOM Editor](https://catalog.dataminer.services/details/11674850-aeac-48c4-9f35-03c387ebcf18) (version 10.4.4.3 or higher) is installed.
- Visual Studio and [DIS](xref:Overall_concept_of_the_DataMiner_Integration_Studio).
- Basic knowledge of DataMiner Object Models (DOM).

  > [!TIP]
  > If you are new to DOM, take a look at the [Getting Started with DOM tutorial](xref:DOM_Generating_code_with_the_DOM_editor).

## Overview

This tutorial consists of the following steps:

- [Step 1: Install the example package from the Catalog](#step-1-install-the-example-package-from-the-catalog)
- [Step 2: Generate the code](#step-2-generate-the-code)
- [Step 3: Use the code](#step-3-use-the-generated-code)
- [Step 4: Test the code](#step-4-test-the-code)

## Step 1: Install the example package from the Catalog

1. Go to the [Tutorial - Generating code with the DOM Editor](https://catalog.dataminer.services/details/6a8c3f13-db15-46a4-931d-96e7c187fa6a) package in the Catalog.

1. Deploy the package to your DataMiner System by clicking the *Deploy* button.

   This will add the **eventmanagement** DOM module, the **event** DOM definition, and the **Event Management** low-code application.

1. Go to `http(s)://[DMA name]/root`, and select the **Event Management** application.

   ![Event Management application on DMA root page](~/dataminer/images/DOM_Generating_code_Step1.png)

## Step 2: Generate the code

1. Open the Automation module in DataMiner Cube.

1. If necessary, use the filter box at the top to find the *DOM Editor* script.

1. Select the script and click the *Execute* button on the right, then click *Execute now*.

   ![DOM Editor script execution](~/dataminer/images/DOM_Generating_code_Step2_1.png)

1. Click the *Generate Code* button in the lower-right corner.

1. Select the checkbox in front of the *eventmanagement* module.

1. Click the *Generate* button.

1. Copy the generated code to the clipboard.

   ![Generated code](~/dataminer/images/DOM_Generating_code_Step2_2.png)

## Step 3: Use the generated code

### Create a new automation script solution

Create a new automation script solution using Visual Studio and DIS.

While you could develop the automation script in Cube, creating an automation script solution in Visual Studio will give you the advantage of having access to all the features of Visual Studio and [DIS](xref:Overall_concept_of_the_DataMiner_Integration_Studio).

To create an automation script solution:

1. In Visual Studio, select *File > New > Project*.

1. Search for *DataMiner Automation Script Project (Skyline Communications)* in the template search box and click *Next*.

   > [!NOTE]
   > If you follow [Kata #57](https://community.dataminer.services/courses/kata-57/), the project template *DataMiner Automation Script Solution (Skyline Communications)* will be mentioned instead, but this project template is no longer available and has been replaced with the above-mentioned template.

1. Use `Generate Kata DOM` as the name for your solution.

1. Choose a location to save the automation script solution and click *Next*.

1. Specify *Generate Kata DOM Instances* as the name of your automation script.

1. Fill in your name as the author, and click *create*.

### Add the generated code to your solution

1. Right-click the *Generate Kata DOM Instances_1* project in the Solution explorer and select *Add > New Item*.

   ![Add a new item to the project](~/dataminer/images/DOM_Generating_code_Step3_1.png)

   > [!TIP]
   > If you have trouble accessing the project in the Solution Explorer, refer to [Visual Studio troubleshooting](xref:VisualStudioTroubleshooting).

1. Enter *DomIds* as the name.

1. Replace the content of the *DomIds.cs* file with the code you copied from the DOM Editor.

1. Open the *Generate Kata Dom Instances_1.cs* file to edit the main script code.

1. Replace the content of the *Generate Kata Dom Instances_1.cs* file with the code below.

```csharp
namespace GenerateKataDOMInstances_1
{
    using System;

    using DomIds;

    using Skyline.DataMiner.Automation;
    using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
    using Skyline.DataMiner.Net.Sections;

    /// <summary>
    /// Represents a DataMiner automation script.
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
> Visual studio will show some errors if you are not using the latest version for some of the NuGet packages. To resolve this:
>
> 1. Open the *NuGet package manager* from the tools menu: *Tools* > *Nuget Package Manager* > *Manage NuGet Packages for Solution*.
>
> 1. Go to the *Updates* tab and select the *Skyline.DataMiner.Dev.Automation* package.
>
> 1. On the right-hand side, select *version 10.3.10* (or higher) and click the *Install* button.
>
>    ![Install version 10.3.10 or higher](~/dataminer/images/DOM_Generating_code_Step3_4.png)

You can spot the different places in the code where the generated code is used through the *DomIds* prefix. Using the generated code, you can write code more quickly, while making it more readable at the same time. Without the generated code, the code would contain a series of GUIDs.

> [!NOTE]
> The *DomIds* namespace prefix does not have to be present in the body of the code. It is only added in this tutorial to clearly indicate where the generated code is used.

### Publish the script

When the automation script is complete, it needs to be published to the DataMiner System. You can do so using the built-in publish feature of DIS. Make sure that DIS can connect to the DataMiner System you want to upload your script to. You will need to [edit the DIS settings](xref:DIS_settings#dma) so the DMA is selectable.

1. In the *Solution Explorer*, double-click *Generate Kata DOM Instances.xml*.

1. At the top of the code window, click the arrow next to the *Publish* button, and select the DataMiner System you want to upload the script to.

## Step 4: Test the code

1. Go to the *Event Management* application.

1. Verify whether no entries are present.

1. In Cube, execute the *Generate Kata DOM Instances* script.

   A series of events will be generated and shown in the app.

> [!IMPORTANT]
> The events table is not updated automatically. To refresh the table, use the refresh button in the upper right corner.

![Step 4](~/dataminer/images/DOM_Generating_code_Step4.png)
