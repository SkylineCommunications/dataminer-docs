---
uid: AutomationDevGuideIndex
description: "Find the development concepts, actions, and procedures you need to design, test, and troubleshoot DataMiner automation scripts."
---

# Automation script development guide

This guide contains everything you need for developing, testing, and troubleshooting DataMiner automation scripts.

## Getting started

To get started, refer to [Getting started with automation script development](xref:GettingStartedWithAutomationScriptDevelopment).

To make developing interactive automation scripts easier, use the [Interactive Automation Script Toolkit](xref:Interactive_Automation_Script_Toolkit).

For information on using C# in automation scripts in Cube, refer to [Using C# code in automation scripts](xref:Using_CSharp_code_in_Automation_scripts).

> [!NOTE]
> The project-based SDK-style workflow is preferred for the creation of new C# automation scripts. For existing scripts, [inline C# blocks](xref:Adding_CSharp_code_to_an_Automation_script) can continue to be used. If the script XML contains a `[Project:<project-name>]` value, keep the C# source in that referenced project rather than copying it into an inline block. See [Visual Studio solutions](xref:DisVisualStudioSolutionsIntroduction) for the SDK-style and legacy-style project distinction.

## Reference

For an overview of script actions and UI components, refer to [Automation script actions](xref:AutomationActions) and [UIBlockType overview](xref:UIBlockTypesOverview), respectively. For XML syntax and element definitions, refer to the [Automation XML schema](xref:SchemaAutomationScript).

## Best practices

To save costs and make sure you do not clutter the database with unnecessary data, keep the [information event best practices](xref:Automation_best_practices_information_events) in mind when creating scripts.

To help save precious time when debugging, [make sure your automation scripts are debug-ready](xref:How_to_make_your_automation_scripts_debug_ready).
