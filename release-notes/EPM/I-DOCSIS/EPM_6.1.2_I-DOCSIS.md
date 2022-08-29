---
uid: EPM_6.1.2_I-DOCSIS
---

# EPM 6.1.2 I-DOCSIS

## New features

\-

## Changes

### Enhancements

#### CCAP platforms: Polling optimization \[ID_33249\]

Several improvements have been implemented to the polling of CCAP platforms:

- Fast and slow SNMP polling have been adjusted so that polling does not start if it is already in progress.
- To allow for cooling time after a polling cycle, an auto-adjust fast SNMP interval functionality has been implemented. You can control this cooling time with the new *SNMP Fast Polling Cooling Time* parameter on the *Debug* page.
- If the fast SNMP polling is auto-adjusted, the threshold execution interval is now also auto-adjusted with the cooling time value.

#### CCAP platforms: No more "-1" values in CM configuration files \[ID_33263\]

The CCAP platform connectors have been adjusted so that "-1" IDs will no longer be exported to the configuration files.

#### Support for CCAPs and CM collectors hosted on different DMAs \[ID_33264\]

DataMiner EPM now supports combining CCAPs and CM collectors hosted on different DataMiner Agents.

#### General improvements \[ID_33266\]

The following general improvements have been implemented:

- Settings for subscribers, taps, amplifiers and node tables will now all be done in the back end. In the front end, they will be displayed via view tables. The tables were also made volatile.
- To prevent possible issues, the importing logic in the back end now uses an impersonated user only during the reading of the files.
- The timing of the aggregation actions for the front and back end has been adjusted from 20 seconds to 5 minutes

#### Improved passive logic in DOCSIS back end \[ID_33421\]

The following changes have been implemented in the Skyline EPM Platform DOCSIS connector to improve the passive logic in the DOCSIS back end:

- The logic of the connector has been adjusted to prevent invalid data from being set in the Subscribers table.
- An exception has been added to the passive tables (Subscribers, Taps, Nodes and Amplifiers) to show "Not available" if parameters within those tables have not been initialized.
- The *avoidZeroInResult* option has been added on the aggregate action for the Nodes and Amplifiers tables, so the connector does not aggregate empty rows and create a -1 primary key in those tables.

### Fixes

#### Reset caused CCAPs to be removed \[ID_33265\]

In some cases, it could occur that CCAPS were removed from the system during a reset.

#### Cable Modem table not cleaned up after restart back end \[ID_33308\]

When a back-end element restarted, it could occur that old rows in the Cable Modem table were not cleaned up.

#### Missing values in Cable Modem table \[ID_33309\]

In some cases, the following exception could be thrown by the collector element:

```txt
System.InvalidCastException: Unable to cast object of type 'System.String' to type 'System.Object[]'.
```

This could cause values to be missing for one or more cable modems in the Cable Modem table.
