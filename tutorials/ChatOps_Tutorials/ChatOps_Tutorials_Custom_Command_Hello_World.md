---
uid: ChatOps_Tutorials_Custom_Command_Hello_World
---

# Hello World

This tutorial shows you how to create your first custom command for the Teams bot. You will create a simple command that, upon execution, will return "Hello world!".

> [!IMPORTANT]
> Before you start this tutorial, take a look at the [prerequisites](xref:ChatOps_Tutorials_Custom_Command#prerequisites).

> [!TIP]
> See also [Adding custom commands for the Teams bot to a DMS](xref:DataMiner_Teams_bot#adding-custom-commands-for-the-teams-bot-to-a-dms).

## Overview

- [Step 1: Create an Automation Script solution](#create-an-automation-script-solution)
- [Step 2: Create the Automation Script](#create-the-automation-script)
- [Step 3: Publish the Automation Script](#publish-the-automation-script)
- [Step 4: Run the Custom Command](#run-the-custom-command)

## Create an Automation Script solution

1. In Visual Studio, select *Create a new project*.

1. Search for *DataMiner Automation Script Solution (Skyline Communications)* in the template search box and click *Next*.

   ![DataMiner Automation Script Solution in Visual Studio](../images/chatops_01_001.png)

1. Use *DataMinerCustomCommands* as the name for your solution, so you can reuse this solution for any future custom command scripts.

   ![Visual Studio configure your project](../images/chatops_01_002.png)

1. Choose a location to save the Automation script solution and click *Next*.

1. Specify *HelloWorld* as the name of your Automation Script, fill in your name as the author, and click *Create*.

   ![Visual Studio create Automation script](../images/chatops_01_003.png)

## Create the Automation script

1. For the bot to find your script, you need to place it in the *bot* folder. Locate the *HelloWorld.xml* file in the Solution Explorer and open it.

   ![HelloWorld.xml file in Solution Explorer](../images/chatops_02_001.png)

1. In the *Folder* tag, specify *bot* and save the file.

   ![HelloWorld.xml file in editor](../images/chatops_02_002.png)

1. Locate the *HelloWorld_1.cs* file in the *HelloWorld_1* C# project and open it.

   ![HelloWorld.cs file in Solution Explorer](../images/chatops_02_003.png)

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

## Publish the Automation Script

When the Custom Command script is complete, it needs to be published to the DataMiner System. You can do so using the built-in publish feature of DIS. Make sure that DIS can connect to the DataMiner System you want to upload your script to. You will need to [edit the DIS settings](xref:DIS_settings#dma) so the DMA is selectable.

1. Locate the *HelloWorld.xml* file in the Solution Explorer and open it.

   ![HelloWorld.xml file in editor](../images/chatops_02_002.png)

1. At the top of the code window, click the arrow next to the *Publish* button and select the DataMiner System you want to upload the script to.

   ![Publish to DMA](../images/chatops_02_004.png)

## Run The Custom Command

1. [Start a conversation with the Teams bot](xref:DataMiner_Teams_bot#starting-a-conversation-with-the-teams-bot).

1. Run the *Hello World* Custom Command.

   ![Run the Hello World Custom Command](../images/chatops_04_001.png)
