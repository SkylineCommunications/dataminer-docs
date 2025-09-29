---
uid: KI_SLElement_issues_caused_by_parameter_name_overrides
---

# SLElement issues caused by parameter name overrides

## Affected versions

TBD

## Cause

When a parameter name is overridden at element level, this causes the parameter pointers to be recreated. However, these are not updated in the service cache, which can lead to a problem in SLElement.

## Workaround

If a parameter name override is needed, instead of configuring it in the information template at runtime, do so directly in the [Description.xml](xref:Elements1#descriptionxml) file while the DMA is stopped (if [Swarming](xref:Swarming) is not enabled in the system).

## Fix

No fix is available yet. <!--Task ID: 187896-->

## Issue description

Applying a parameter name override at element level may lead to problems in SLElement, such as a memory leak or an unexpected DMA restart.

> [!TIP]
> See also: [Various resolved SLElement issues](xref:KI_SLElement_various_resolved_issues)