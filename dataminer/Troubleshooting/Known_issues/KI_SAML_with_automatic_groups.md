---
uid: KI_SAML_with_automatic_groups
---

# Higher CPU usage and connection issues when using SAML with automatic groups

## Affected versions

- From DataMiner 10.4.0 [CU4]/10.4.7 onwards.<!-- RN 39234 -->

## Cause

When users connect using SAML with automatic groups, all security keys are recalculated whenever there are group changes, causing higher CPU usage for SLNet and SLDataMiner as well as connection issues.

## Fix

Install DataMiner 10.4.0 [CU15], 10.5.0 [CU3], or 10.5.5.<!-- RN 42668 -->

## Issue description

When SAML is used with automatic groups, after upgrading to DataMiner 10.4.0 [CU4]/10.4.7 or higher, SLNet and SLDataMiner show a significantly higher CPU usage for SLNet and SLDataMiner, and users are frequently disconnected.
