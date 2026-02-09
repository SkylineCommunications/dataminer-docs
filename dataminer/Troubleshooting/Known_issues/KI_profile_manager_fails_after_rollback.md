---
uid: KI_profile_manager_fails_after_rollback
---

# Profile Manager fails to initialize after rollback to an earlier DataMiner version

## Affected versions

DataMiner versions that support new Profile Manager features

## Cause

Profile Manager uses XML serialization during initialization. Newer DataMiner versions introduce additional Profile Manager features (for example, new fields or parameter types). When a system is rolled back to an earlier version, that version may not be able to interpret all serialized data created by the newer version. As a result, Profile Manager cannot be initialized correctly.

## Fix

No fix is available yet.

## Workaround

Remove or reconfigure the affected profile definition, profile instance, or parameter so that it no longer depends on functionality that is not supported by the rolled-back DataMiner version.

The notice details in the Alarm Console indicate which part of the data could not be parsed. Additional details can be found in the *SLErrors.txt* log file, where a `SLDataGateway.API.Types.Exceptions.Queries.QueryException` identifies the specific definition, instance, or parameter that could not be serialized.

## Description

When rolling back from a DataMiner version that supports newer Profile Manager features to an older version, Profile Manager may fail to initialize.

For example, since DataMiner 10.5.9, profile capacity parameters can be of type *Range*. If such a parameter exists and the system is rolled back to an earlier DataMiner version, Profile Manager will no longer start.

A `SerializationException` is shown as a notice in the Alarm Console.
