---
uid: KI_SNMP_polling_issues_with_wildcards_in_param_OIDs
---

# SNMP polling issues in case protocol contains wildcards in parameter OIDs

## Affected versions

10.2.9 and 10.2.0.0 - 12153 CU6.

## Cause

In some specific cases, wildcards in the parameter OIDs in a protocol cause polling to return no data. This only occurs in case the wildcards refer to a parameter that is not displayed.

## Fix

- For 10.2.9: install 10.2.9 CU1.

- For 10.2.0.0 - 12153 CU6: install 10.2.0.0 - 12184 CU6.

## Issue description

After upgrading to 10.2.9 or 10.2.0 CU6, there are SNMP elements that do not receive data from polling.
