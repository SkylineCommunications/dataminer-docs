---
uid: KI_RTEs_Alarm_Template_Issue
---

# RTEs caused by problem when updating alarm templates

## Affected versions

DataMiner 10.2.0 [CU15], [CU16], and [CU17]

## Cause

An issue was introduced in the DataMiner 10.2.0 Main release versions concerning the assignment of alarm templates.

## Fix

Install DataMiner 10.2.0 [CU18]. <!--RN 37027-->

## Description

When updating an element's alarm template, run-time errors occur. These specifically occur in the SLElement process and/or the alarm template scheduling thread, but other processes may also be affected as a result.
