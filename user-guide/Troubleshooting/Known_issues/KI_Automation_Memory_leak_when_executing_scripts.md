---
uid: KI_Automation_Memory_leak_when_executing_scripts
---

# SLAutomation would leak memory each time an Automation script was run

## Affected versions

DataMiner 10.5.6

## Cause

Since DataMiner 10.5.6<!--RN 42572-->, a new pointer to SLLog would be created for every Automation script that was run. This would cause SLAutomation to leak memory each time an Automation script was run.

## Fix

Install DataMiner 10.5.7<!--RN 43073-->.

## Workaround

Although this will not fix the problem, restarting the DataMiner Agent will cause memory usage to drop down again.

## Description

Since DataMiner 10.5.6<!--RN 42572-->, SLAutomation would leak memory each time an Automation script was run.
