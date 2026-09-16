---
uid: KI_SLAutomation_ScriptRunner_missing_assemblies
description: "Learn why scripts running in separate SLAutomation.ScriptRunner processes may be unable to load referenced assemblies."
---

# Libraries unavailable to scripts running in separate SLAutomation.ScriptRunner processes

## Affected versions

Feature Release versions from DataMiner 10.6.9 onwards.

## Cause

To reduce the risk of loading incorrect DLL files, an SLAutomation.ScriptRunner process does not consider assemblies in the `C:\Skyline DataMiner\Files` folder by default. Instead, assemblies considered necessary for script execution are copied to the `C:\Skyline DataMiner\Files\SLAutomation.ScriptRunner` folder.

However, dependencies that are not anticipated may be omitted from this folder. For example, this can occur with *Skyline.DataMiner.Storage.Types.dll*.

## Fix

No fix is available yet.<!-- RN 46443 -->

## Description

When an Automation script is configured to run in a separate SLAutomation.ScriptRunner process based on its `SolutionId`, a referenced library is unavailable if it is only included in the `C:\Skyline DataMiner\Files` folder. As a result, the script cannot use the dependency correctly.
