---
uid: KI_SNMP_SET_returns_a_NO_ACCESS_error
---

# SNMP SET returns a 'NO ACCESS' error

## Description of the issue

When an SNMP SET is performed, a "NO ACCESS" error is returned in the element's Stream Viewer.

## Cause

The SET COMMUNITY string is not correctly set.

## Resolution

Set the SET COMMUNITY string to the correct value.

In DataMiner, in most cases, SNMP elements have to have their SET COMMUNITY string set to "private".
