---
uid: KI_SLDataMiner_crashes_because_of_subgroup_query_failure
---

# SLDataMiner crashes because of subgroup query failure

## Affected versions

From DataMiner 10.3.0 [CU11]/10.4.0/10.4.2 onwards

## Cause

When SLDataMiner attempts to fetch users of a group, either by adding the group or through regular synchronization, and the group contains a subgroup, a code issue may prevent the successful querying of this subgroup, resulting in the crashing of SLDataMiner.

## Workaround

1. Open the *DataMiner.xml* file, located in the folder `C:\Skyline DataMiner\`.

1. Remove the attribute *referralConfigured="false"* from the LDAP tag.

## Fix

Install DataMiner 10.3.0 [CU13], 10.4.0 [CU1], or 10.4.4<!--RN 39058-->.

## Description

- SLDataMiner crashes when executing the scheduled task *Skyline DataMiner LDAP Resync* or when adding a group with a subgroup to a DataMiner System where the DataMiner.LDAP attribute "referralConfigured" is set to false.

  > [!TIP]
  > See also: [DataMiner.LDAP attributes](xref:DataMiner.LDAP)

- The *ActiveDirectory.txt* logfile contains a query with an empty "name" field, similar to the following example:

  ```txt
  2024/03/06 15:47:19.097|ActiveDirectory|20024|9072|CActiveDirectoryInfo::ADQuery|DBG|0|Query:    (&(&(objectClass=group)(groupType:1.2.840.113556.1.4.803:=2147483648))(name=)) CR LF
  ```
