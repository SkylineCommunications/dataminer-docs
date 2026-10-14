---
uid: KI_DELT_export_unfiltered_after_STaaS_cost_estimation
description: "Learn what to do when a DELT element export returns unfiltered data after a STaaS cost estimation and how to work around this issue."
---

# DELT export of elements returns unfiltered data after a STaaS cost estimation

## Affected versions

From DataMiner 10.4.0 [CU17], 10.5.0 [CU5], and 10.5.8 onwards, on systems using a Cassandra Cluster database where the [STaaS cost estimation](xref:STaaS_cost_estimation) has been executed.

Single-node Cassandra setups may also be affected, but this has not been confirmed yet.

## Cause

When a [STaaS cost estimation](xref:STaaS_cost_estimation) is started, the Cloud Storage migration service is initialized on every node of the cluster. In this state, the DELT export does not apply the element filter when reading element data, alarms, and trend data from the database, and it reads the complete tables instead. Stopping the test run does not restore the normal state; it remains active until the DataMiner Agent is restarted.

## Fix

No fix is available yet.

## Workaround

Restart the DataMiner Agents hosting the elements you want to export. After the restart, DELT exports are filtered correctly again.

Note that the issue will reappear if a STaaS cost estimation or migration is started again on the system.

## Description

[Exporting an element](xref:Exporting_elements_services_etc_to_a_dmimport_file), with trend and/or alarm data included, to a .dmimport file takes much longer than usual (over 10 minutes on large clusters) and produces a very large package (several GB).

The resulting package contains element data, alarms, and trend data of other elements and DataMiner Agents, including Agents that no longer exist. The package is also incomplete for the exported element itself, so it cannot be used for an import. For example, trend averages are missing.
