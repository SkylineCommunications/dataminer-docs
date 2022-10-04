---
uid: EPM_6.1.6_I-DOCSIS
---

# EPM 6.1.6 I-DOCSIS

## New features

#### New 'Other DOCSIS' KPI [ID_34346]

New aggregation operations were added to the hub, market, network, CCAP, service group, and node segment levels to register the number of CMs with a DOCSIS version other than DOCSIS 2.0, DOCSIS 3.0, or DOCSIS 3.1. The resulting KPI is displayed in the *Other DOCSIS* column.

#### Option to show/hide PNM on Node Segment map [ID_34387]

Both on the *Configuration* page of the Skyline EPM Platform element and in the front-end EPM visual overview, a toggle button is now available that can be used to show or hide the PNM layers on the Node Segment map.

## Changes

### Enhancements

#### Maps with PNM layer moved to Node Segment layer [ID_34390]

The maps implementation with PNM layer has been moved from the Service Group layer to the Node Segment layer. Maps now retrieve data directly from the CCAP/collector elements instead of the front end.

#### Provisioning now by default enabled after back end restart [ID_34480]

When the back end was restarted, up to now, provisioning was disabled by default. Now it will be enabled by default. The Provisioning parameter is now also available on the Configuration page in Visual Overview.

### Fixes

#### Issues related to alarm in EPM Platform visual overview [ID_34449]

The following issues related to alarms could occur in the EPM Platform visual overview:

- On the Service Group level, the alarm tab in the EPM Platform visual overview did not show any alarms.
- Alarm statistics associated with the Service Group level could be incorrect.
- The alarm coloring of shapes could also be incorrect (e.g. minor alarms displayed with a green color instead of the correct light-blue color).

#### Arris E6000 CCAP Platform - Empty Node Segment table [ID_34461]

Because of an incorrect condition check, it could occur that the Node Segment table of the Arris CCAP connector did not get filled in. In addition, the export of the Node Segment EC file was not performed.

#### Exceptions thrown by CM Collector [ID_34472]

If the Generic DOCSIS CM Collector connector could not find the Passive Relation\\EP folder while parsing the SG file, an exception could be thrown.

#### Parameters based on system description not filled in in CCAP table [ID_34556]

In the CCAP table, it could occur that parameters based on the system description were not filled in.
