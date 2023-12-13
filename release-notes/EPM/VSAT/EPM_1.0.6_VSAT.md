---
uid: EPM_1.0.6_VSAT
---

# EPM 1.0.6 VSAT

## New features

#### Carrier performance and information event dashboards additions [ID_37584]

The existing carrier performance dashboard has been updated to include new parameters in the Stats Summary table and Carrier Summary table, including *Target C/No*, *Modulation Name*, *Fecrate*, and *Symbol Rate*.

In addition, two new dashboards are now included in the solution:

- Information Events - Textbox Feed
- Information Events - Parameter feed

Both of these dashboards can be used to query historical information events for a user-defined selection of circuits and for a selected time period.

## Changes

### Fixes

#### Verizon iDirect Evolution Platform Collector: RTEs when database table cleanup logic was running [ID_37555]

When database table cleanup logic was running, the Verizon iDirect Evolution Platform Collector connector could cause RTEs or half-open RTEs.

#### Missing information events in dashboards [ID_37581]

Up to now, the *InformationEventsGQI* script could result in missing information events within the selected time range in a dashboard. This has been adjusted so that the dashboards are now completely accurate based on the time range selected by the user.

#### Generic KAFKA Consumer: Exceptions related to files marked for deletion [ID_37583]

When a KAFKA topic file was deleted, it could occur that it was erroneously marked for deletion twice, resulting in exceptions in the KAFKA Consumer element.

#### Verizon iDirect Evolution Platform Collector: Duplicate active alarms [ID_37690]

After an iDirect upgrade, it could occur that the Verizon iDirect Evolution Platform Collector had duplicate active alarms. The cleanup logic of retained rows has now been adjusted to resolve this issue.
