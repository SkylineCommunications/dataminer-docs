---
uid: DIS_2.42
---

# DIS 2.42

## New features

### IDE

#### DIS now supports SDK-style projects [ID_36409]

DIS now supports SDK-style projects in addition to the legacy-style projects.

At startup, DIS will install new protocol solution and Automation script solution templates that will be used when creating a new protocol or Automation script solution in Visual Studio 2022.

When a legacy-style solution is added, an SDK-style project will also automatically be created (and vice versa).

### Validator

#### Validator check 'UnsupportedIDisposable' has become a feature check [ID_36455]

Up to now, DIS Validator check *UnsupportedIDisposable* (ID 3.14.1) checked whether QAction classes implemented the `IDisposable` interface. If they did, a Validator issue would be generated, saying that this is not supported by DataMiner.

As DataMiner has been supporting calling the `Dispose` method of QActions as from version 10.2.9 (see [release note 33965](xref:General_Feature_Release_10.2.9#qactions-are-now-idisposable-and-the-slprotocol-object-remains-available-outside-of-the-run-scope-id_33965)), the *UnsupportedIDisposable* check has now been converted into a feature check.

### XML Schema

#### Protocol Schema: 'ColumnOptions' element has been removed [ID_36526]

​The following element has been removed from the protocol schema:

- Protocol.Params.Param.ArrayOptions.ColumnOptions

#### Protocol Schema: 'ExportRule' elements can now have a 'whereAttribute' attribute [ID_36667]

The protocol schema now supports the `whereAttribute` attribute on `ExportRule` elements.

This will allow you to validate the value of an attribute when applying an export rule.

See also: [Release note 36622]()

## Changes

### Enhancements

#### User-defined APIs - Small tweaks and fixes [ID_35996]

Made some small tweaks and fixes to User-defined APIs:

- The logline that is executed when an API is triggered will now contain a description of the actual error reason if there was an error. It will also contain the ApiToken ID (if the ApiToken wasn't fetched yet when the request is finished, this can happen because there are validation steps before the ApiToken is fetched, then this will not be added to the logline)

  - [78d5c5c0ef] Handling API trigger from NATS for route 'some/route' SUCCEEDED after 1,004.00 ms. API script provided response code: 200. (Token ID: df6df996-7d05-40fe-b484-53adf48648d9)

- DataMinerMessageBroker.API.dll has been updated to the latest version in the DxM
- The SessionConfigPath & CredentialsConfigPath options in the appsettings of the DxM have been made optional and removed from the default file, also in the SLNet side these hardcoded paths are removed as they are not necessary. (Documentation PR: https://github.com/SkylineCommunications/dataminer-docs/pull/1236)
- Added property Route on ApiDefinitionError that will be filled in when error reason RouteInUse and InvalidRoute are returned
- Changed the docs to reflect the naming changes in the client test tool docs PR: https://github.com/SkylineCommunications/dataminer-docs/pull/1233 Internal docs PR: https://github.com/SkylineCommunications/internal-docs/pull/411
- Previously the maximum concurrent connections defined on the Kestrel webhost was set to 100. The value can now be configured using app settings. By default the MaxConcurrentConnections limit will still be set to 100. Using the appsettings.custom.json (using the key: Kestrel/Limits/MaxConcurrentConnections) this value can be adjusted.
- Previously MaxConcurrentUpgradedConnections was also limited to 100. That limitation has been removed since it's not relevant.
- Other settings Kestrel options - although limited - can now also be tweaked using app settings (Reference).
- Prefixes of the loglines changed from 'CustomAction: ' to 'CustomActionINF: ' and 'CustomActionWRN: '
- Warning loglines from custom actions are now logged as a warning in the DataMiner upgrade
- The errors in JSON format returned by the endpoint will now almost always include the DMA ID in the faulting node field.
- The validation logic when the DxM is installed will now be able to better handle situations where a custom port is configured. It will check if the port has been overridden in the appsettings & will generate a warning if it notices that the rewrite rule does not include this overridden port. This logic will now also not disable the rewrite rule anymore if it already existed, even when this port is in use.
- The SLUserDefinableApiManager.txt log file will now always contain the amount of max. parallel triggers that can be handled.

#### DIS Comparer - Add tooltip to State column [ID_36598]

​A tooltip has been added to the State column for the Validator and Comparer. This tooltip explains and shows the possible values for that column.

### Fixes

#### Validator - SNMP OID options: allow multipleGet [ID_36477]

Since DataMiner 10.1.10 (RN 30780) 'multipleGet' can be used which was not taken into account in the Validator.

Now it won't throw the 'Unknown or malformed option' error anymore.
