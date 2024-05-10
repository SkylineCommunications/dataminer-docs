---
uid: KI_Hostnames_not_supported_with_SNMP_traps
---

# SNMP traps not working if hostname instead of an IP is used in the polling IP address of an element's SNMP connection(s)

## Affected versions

Any versions of DataMiner

## Cause

If a hostname instead of an IP is used in the polling IP address of an element's SNMP connection(s), the traps received from the hostname will not be captured. This is because DNS resolution does not occur when traps are received, causing the element's trap receivers to not know which IP to listen to.

## Workaround

Use IP instead of hostname in polling IP address of an element's SNMP connection(s)

## Fix

None at the moment
