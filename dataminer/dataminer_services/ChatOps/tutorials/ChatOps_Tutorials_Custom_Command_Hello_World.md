---
uid: ChatOps_Tutorials_Custom_Command_Hello_World
reviewer: Alexander Verkest
---

# Hello World

This tutorial shows you how to create your first custom command for the DataMiner Teams bot. You will create a simple command that, upon execution, will return "Hello world!".

Estimated duration: 10 minutes.

> [!TIP]
> See also [Adding custom commands for the Teams bot to a DMS](xref:DataMiner_Teams_bot#adding-custom-commands-for-the-teams-bot-to-a-dms).

## Prerequisites

- [A DataMiner System connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)
- [The latest version of the DataMiner Cloud Pack](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions)
- [The DataMiner Teams bot](xref:DataMiner_Teams_bot)
- [Visual Studio with DataMiner Integration Studio](xref:Installing_and_configuring_the_software)

## Overview

- [Step 1: Create an Automation script solution](#step-1-create-an-automation-script-solution)
- [Step 2: Create the Automation script](#step-2-create-the-automation-script)
- [Step 3: Publish the Automation script](#step-3-publish-the-automation-script)
- [Step 4: Run the custom command](#step-4-run-the-custom-command)

## Step 1: Create an Automation script solution

1. In Visual Studio, select *Create a new project*.

1. In the template search box, search for *DataMiner Automation Script Solution (Skyline Communications)* and click *Next*.

   ![DataMiner Automation Script Solution in Visual Studio](~/dataminer/images/chatops_01_001.png)

1. Use *DataMinerCustomCommands* as the name for your solution, so you can reuse this solution for any future custom command scripts.

   ![Visual Studio configure your project](~/dataminer/images/chatops_01_002.png)

1. Choose a location to save the Automation script solution and click *Next*.

1. Specify *HelloWorld* as the name of your Automation Script, fill in your name as the author, and click *Create*.

   ![Visual Studio create Automation script](~/dataminer/images/chatops_01_003.png)

## Step 2: Create the Automation script

1. For the bot to find your script, you need to place it in the *bot* folder:

   1. Locate the *HelloWorld.xml* file in the Solution Explorer and open it.

      ![HelloWorld.xml file in Solution Explorer](~/dataminer/images/chatops_02_001.png)

   1. In the *Folder* tag, specify *bot* and save the file.

      ![HelloWorld.xml file in editor](~/dataminer/images/chatops_02_002.png)

1. Locate the *HelloWorld_1.cs* file in the *HelloWorld_1* C# project and open it.

   ![HelloWorld.cs file in Solution Explorer](~/dataminer/images/chatops_02_003.png)

1. Add the C# code. This code will output a simple message saying "Hello World!".

   ```csharp
   namespace HelloWorld_1
   {
       using System;
      using System.Collections.Generic;
      using System.Globalization;
      using System.Text;
      using Skyline.DataMiner.Automation;
   
      /// <summary>
      /// Represents a DataMiner Automation script.
      /// </summary>
      public class Script
      {
         /// <summary>
         /// The script entry point.
         /// </summary>
         /// <param name="engine">Link with SLAutomation process.</param>
         public void Run(IEngine engine)
         {
            engine.AddScriptOutput("Message", "Hello World!");
         }
      }
   }
   ```

## Step 3: Publish the Automation script

When the custom command script is complete, you will need to publish it to the DataMiner System. You can do so using the built-in publish feature of DIS. Make sure that DIS can connect to the DataMiner System you want to upload your script to. You will need to [edit the DIS settings](xref:DIS_settings#dma) so the DMA is selectable.

1. Locate the *HelloWorld.xml* file in the Solution Explorer and open it.

   ![HelloWorld.xml file in editor](~/dataminer/images/chatops_02_002.png)

1. At the top of the code window, click the arrow next to the *Publish* button and select the DataMiner System you want to upload the script to.

   ![Publish to DMA](~/dataminer/images/chatops_02_004.png)

## Step 4: Run the custom command

1. [Start a conversation with the Teams bot](xref:DataMiner_Teams_bot#starting-a-conversation-with-the-teams-bot).

1. Run the *Hello World* custom command.

   ![Run the Hello World custom command](~/dataminer/images/chatops_04_001.png)
