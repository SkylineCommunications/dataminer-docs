---
metadata_version: 1
uid: GettingStartedWithAutomationScriptDevelopment
description: "Describe the DataMiner Automation development topic Getting started with automation script development, including its purpose, behavior, implementation gu."
content_type: conceptual
applies_to:
  - DataMiner
---

# Getting started with automation script development

## Get to know the basics

- [DataMiner Automation](xref:automation)
- [Dojo course 'DataMiner Automation'](https://community.dataminer.services/courses/dataminer-automation/)
- [DataMiner Integration Studio](https://community.dataminer.services/exphub-dis/)

## Executing automation scripts

- [Linking a Visio shape to an automation script](xref:Linking_a_shape_to_an_Automation_script)
- [Running an automation script from a correlation rule](xref:Running_an_Automation_script_from_a_Correlation_rule)
- [Adding a scheduled task that executes an automation script at a specific time](xref:Manually_adding_a_scheduled_task)
- [Adding a custom command to the Alarm Console shortcut menu that executes an automation script when clicked](xref:Adding_a_custom_command_to_the_Alarm_Console_shortcut_menu)
- [Executing an automation script when a switchover occurs in a redundancy group](xref:Creating_a_redundancy_group)

## Basic script development

- [Script variables](xref:Script_variables)
- [Script actions in DataMiner Cube](xref:Automation_script_actions_in_DataMiner_Cube)
- [Script execution options](xref:Script_execution_options)
- [Using credentials in an automation script](xref:Using_credentials_in_an_automation_script)

For new C# automation scripts, prefer the project-based SDK-style workflow. Inline C# blocks remain useful for existing scripts and are documented in [Adding C# code to an automation script](xref:Adding_CSharp_code_to_an_Automation_script). If the script XML contains a `[Project:<project-name>]` value, keep the C# source in that referenced project rather than copying it into an inline block. See [Visual Studio solutions](xref:DisVisualStudioSolutionsIntroduction) for the SDK-style and legacy-style project distinction.

## References

- [DataMiner automation script XML schema](xref:SchemaAutomationScript)
- [C# code reference (Skyline.DataMiner.Automation namespace)](xref:Skyline.DataMiner.Automation)
- [DataMinerSystem library (Skyline.DataMiner.Core.DataMinerSystem.Automation namespace)](xref:Skyline.DataMiner.Core.DataMinerSystem.Automation)
- [Getting started with the IAS Toolkit](xref:Getting_Started_with_the_IAS_Toolkit)
