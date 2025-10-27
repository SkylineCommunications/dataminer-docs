---
uid: KI_Startup_issue_DcM_not_running
---

# DataMiner startup issue with one or more DcMs not running

## Affected versions

This issue is assumed to occur since the introduction of the DcMs, i.e. from DataMiner 10.3.7/10.4.0 onwards. It has been reproduced in DataMiner 10.5.4 and 10.5.7.

## Cause

Some [DataMiner Core Module (DcM)](xref:DataMinerExtensionModules#available-dcms) services do not respond quickly enough to the Windows Service Controller after a reboot (e.g. because of Windows updates). As a consequence, these services are still stopped while the DataMiner Agent is already starting, but DataMiner needs these services to be able to start up fully.

## Fix

No fix is available yet. <!--Task IDs: 270375 & 268191-->

## Workaround

See [DataMiner startup issues - DcM issue solution](xref:Troubleshooting_Startup_Issues#dcm-issue).

## Description

After a reboot, DataMiner fails to start, takes too long to start, or gets stuck at 99% during the startup process. In the Windows Task Manager, one or more [DataMiner Core Modules](xref:DataMinerExtensionModules#available-dcms) are shown as stopped.
