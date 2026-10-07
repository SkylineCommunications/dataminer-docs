---
uid: KI_DELT_export_unfiltered_after_STaaS_cost_estimation
---

# DELT export of elements returns unfiltered data after a STaaS cost estimation

## Affected versions

DataMiner 10.4.0 [CU17] and later, including all 10.5.x and 10.6.x versions, on systems using a Cassandra Cluster database where the [STaaS cost estimation](xref:STaaS_cost_estimation) has been executed. Single-node Cassandra setups are likely also affected, but this has not been confirmed.

## Cause

When the STaaS cost estimation (*CloudStorageMigration* script, *Start Test Run*) is started, the Cloud Storage migration service is initialized on every Agent of the cluster. In this state, the DELT export does not apply the element filter when reading element data, alarms, and trend data from the database, and reads the complete tables instead. Stopping the test run does not restore the normal state; it remains active until the Agent is restarted.

## Fix

No fix is available yet.

## Workaround

Restart the Agent(s) hosting the elements you want to export. After the restart, DELT exports are filtered correctly again.

Note that the issue will reappear if a STaaS cost estimation or migration is started again on the system.

## Description

[Exporting an element](xref:Exporting_elements_services_etc_to_a_dmimport_file) to a .dmimport file (Surveyor right-click menu > *Actions* > *Export*, with trend and/or alarm data included) takes much longer than usual (over 10 minutes on large clusters) and produces a very large package (several GB). The package contains element data, alarms, and trend data of other elements and Agents, including Agents that no longer exist. The package is also incomplete for the exported element itself (for example, trend averages are missing), so it should not be used for an import.
