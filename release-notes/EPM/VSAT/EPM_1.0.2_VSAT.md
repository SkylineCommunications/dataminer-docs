---
uid: EPM_1.0.2_VSAT
---

# EPM 1.0.2 VSAT - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## New features

*No new features have been added to this release yet.*

## Changes

### Enhancements

#### WM ticketing integrated with EPM PLM [ID_36468]

WM ticketing connectors now point to the EPM PLM Solution.

#### Skyline Universal Weather: pagination added [ID_36469]

In the Skyline Universal Weather connector, pagination has been added for the tables with ID 100, 300, 1000, and 1100.

#### iDirect Evolution Platform Collector: MODCOD reference for hub return carriers updated [ID_36471]

The MODCOD reference for hub return carriers has been updated.

#### Newtec Dialog Platform VSAT: TSDB Rx technology integration + UI adjustments [ID_36473]

TSDB Rx technology data has been integrated into the EPM Solution with formula updates for the Circuit Overview Table of the Newtec Dialog Platform VSAT connector. In addition, the connector user interface has been adjusted in several places: tables have been moved and the order of the pages has changed.

### Fixes

#### WM Ticketing exceptions related to load balancing [ID_36470]

In some cases, the logging could contain exceptions related to the WM Ticketing load balancing logic. For example:

```txt
2023/04/13 15:31:11.742|SLManagedScripting.exe|ManagedInterop|ERR|0|3|QA1|ProcessIncomingEvent|Error processing incoming event. System.IndexOutOfRangeException: Index was outside the bounds of the array. at QAction.LoadBalancing(SLProtocolExt protocol, List`1 receivedRowsData, List`1 listToSend, List`1 listOfEtms) at QAction.LoadBalancingLogic(SLProtocolExt protocol, List`1 receivedRowsData, List`1 listToSend) at QAction.TicketProcess(SLProtocolExt protocol, List`1 diagnosticTableEntries, ConcurrentBag`1 processedRows, List`1 receivedRowsData) at QAction.ProcessIncomingEvent(SLProtocolExt protocol, List`1 diagnosticTableEntries)
```

To prevent these exceptions, if the previous ticket has "N/A" as the ticket handler, a new ticket handler will now be assigned.

#### Not possible to push SES S.A. Skala connector to pipeline [ID_36472]

Up to now, it was not possible to push the SES S.A. Skala connector to the pipeline and get a signed copy. Now, the latest version of the connector is available in the pipeline.

#### VerSat On ETMS Automation script caused error when inter-app messages were sent [ID_36483]

When inter-app messages were sent from the VerSat On ETMS Automation script to ETMS connectors, this could cause an error. To prevent this, the InterApp library has now been updated in the script.
