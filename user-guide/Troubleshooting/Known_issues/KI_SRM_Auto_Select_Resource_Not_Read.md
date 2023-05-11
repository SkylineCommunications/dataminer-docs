---
uid: KI_SRM_Auto_Select_Resource_Not_Read
---

# SRM - Auto Select Resource not read for silent booking

## Affected versions

SRM 1.2.30 CU2.

## Cause

When a booking was created silently, the *Auto Select Resource* node property was not read.

## Fix

No fix is available yet.

## Workaround

In the Automation script, pass the function with `ShouldAutoSelectResource=false`.

## Description

When a booking was created silently, resources were automatically selected even if the *Auto Select Resource* node property was set to *False*.
