---
uid: KI_SLNet_handle_leak_caused_by_SAML_authentication_and_SLHelper_startup
---

# SLNet handle leak caused by SAML authentication and SLHelper startup

## Affected versions

- Main Release versions from DataMiner 10.5.0 [CU12]/10.6.0 onwards.

- Feature Release versions from DataMiner 10.6.3 onwards. <!--RN 44314-->

## Cause

Logger instances used in SAML authentication and SLHelper-related flows are not correctly disposed. As a result, handles are not released after use.

## Fix

No fix is available yet. <!-- Task ID: 292260-->

## Workaround

If the handle leak is caused by BPAs running on the system, adjust the BPA schedule to run them less frequently as a temporary workaround. See [Running BPA tests](xref:Running_BPA_tests).

## Description

The SLNet process gradually leaks handles when:

- A user authenticates using SAML.

- An SLHelper process is started.

  Notable flows in which an SLHelper process is started include:

  - [BPA executions](xref:Running_BPA_tests).

  - [GQI query executions](xref:Creating_GQI_query) when the [GQI DxM](xref:GQI_DxM) is not enabled.
