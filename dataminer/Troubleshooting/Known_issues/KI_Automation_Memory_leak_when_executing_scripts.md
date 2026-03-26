---
uid: KI_Automation_Memory_leak_when_executing_scripts
---

# SLAutomation memory leak when automation script runs

## Affected versions

DataMiner 10.5.6

## Cause

In DataMiner 10.5.6<!--RN 42572-->, a new pointer to SLLog is created for every automation script that runs. This causes SLAutomation to leak memory each time an automation script runs.

## Fix

Install DataMiner 10.5.7<!--RN 43073-->.

## Workaround

Restart the DataMiner Agent to cause the memory usage to decrease again. However, note that this is a temporary workaround that will not fix the issue.

## Description

In DataMiner Systems using DataMiner 10.5.6, SLAutomation keeps using more memory after each automation script run.<!--RN 42572-->
