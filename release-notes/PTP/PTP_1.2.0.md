---
uid: PTP_1.2.0
---

# PTP 1.2.0

## New features

#### Catalog Deployment

The PTP Solution can now be deployed [directly from the Catalog](https://catalog.dataminer.services/details/9c5eb0a1-43bc-42d2-bca2-de4982ee57d7).

#### New Low-Code APP UI

A brand new Low-Code App was added to allow to monitor all PTP Domains from any browser.

#### New GQI Ad-Hoc Data Sources

To support the new Low-Code app, multiple GQI Ad-Hoc Data Sources have been added. These will supply the necessary PTP data to the app in real-time.

> [!NOTE]
> These GQI Ad-Hoc Data Sources need the [GQI DXM](https://docs.dataminer.services/dataminer/Functions/Dashboards_and_Low_Code_Apps/GQI/GQI_DxM.html) to function properly.

## Changes

### Enhancements

#### Renamed automation scripts

The automation scripts used to configure the PTP Solution have been renamed to match the standards.

#### Standard PTP mediation connector updated to version 1.0.0.26

The version of the mediation connector *Standard DataMiner PTP Device* included in the PTP package has been incremented from 1.0.0.22 to 1.0.0.26.

For detailed information about the changes in this version, refer to the [change log for this connector in the Catalog](https://catalog.dataminer.services/details/59d8a85e-5ee6-4203-a7c4-2b06ad665d96).

> [!NOTE]
> New versions of the mediation connector can be deployed independently of the PTP app.

#### Minimum DataMiner version increased to 10.6.2

The PTP app now requires at least DataMiner version 10.6.2.0-16783.