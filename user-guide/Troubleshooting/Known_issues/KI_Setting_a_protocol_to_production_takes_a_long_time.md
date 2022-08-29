---
uid: KI_Setting_a_protocol_to_production_takes_a_long_time
---

# Setting a protocol to production takes a long time

## Affected versions

All DataMiner versions

## Cause

Thread locking

## Fix

To be confirmed

## Issue description

When you activate a new production protocol, all affected elements are stopped and activated again. For some elements, this can take a very long time. This occurs when some elements are still stopping while others are already starting up again on the same DMA.

## Workaround

Stop the elements using the protocol before you set a new version to production and then start them again after the change.
