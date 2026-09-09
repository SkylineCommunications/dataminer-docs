---
uid: PTP_2.0.0
---

# PTP 2.0.0

> [!NOTE]
> This version requires **DataMiner 10.6.2** or higher, **DataMiner Web 10.6.3 CU0** or higher, the [DataMiner GQI DxM](xref:GQI_DxM), and a Storage as a Service (STaaS) or Cassandra storage database with indexing.

## New features

#### Custom web application: PTP Monitor

A brand-new custom DataMiner web application (*PTP Monitor*) is now available, accessible directly from any web browser at `/public/ptp/`.

The application provides dedicated pages:

- **Summary page**: Real-time domain summary KPIs, active alarms table with filtering, active grandmaster details with BMCA parameters, and PTP probe trend graphs.
- **Nodes page**: Comprehensive inventory of all PTP devices in the domain, with role filters, alarm state indicators (element state and PTP state), slide-out node details, and multi-selection comparison.
- **Compare panel**: Side-by-side comparison of two or more nodes across Clock, Default DS, Current DS, Parent DS, Grandmaster, Time Properties, and Port datasets, featuring automated difference highlighting in amber and performance sparklines.
- **Topology page**: Interactive node graph displaying DCF connections or reported parent connections, distinct clock role icons, state color coding, Show/Hide Followers toggle, and customizable drag-and-drop layout editing saved per domain.
- **Admin page**: Built-in administration wizards for adding, renaming, and deleting domains, configuring device roles, designating preferred grandmasters, and onboarding new domains.

#### In-connector mediation in Skyline PTP 2.0.0.X

Mediation has been integrated directly into the *Skyline PTP* connector (version 2.0.0.X), replacing the separate *Standard DataMiner PTP Device* mediation protocol. This streamlines deployment and eliminates managing a separate mediation layer.

#### Real-time data delivery via GQI ad hoc data sources

Real-time telemetry and state updates are delivered to the PTP Monitor web application using high-performance Generic Query Interface (GQI) ad hoc data sources.

## Changes

### Enhancements

#### Transition to modern follower terminology

In alignment with IEEE 1588-2019 and the PTP Monitor UI, the solution now standardizes on the term **follower** (follower clocks, follower devices, follower role) instead of "slave".

#### Single source of truth for supported connectors

The list of supported vendor connectors has been consolidated into the [Skyline PTP Technical](https://docs.dataminer.services/connector/doc/Skyline_PTP_Technical.html) connector documentation, which serves as the definitive reference for compatible devices.

#### Retirement of legacy Automation scripts and Visio pages

The legacy Microsoft Visio visual overview pages and the setup Automation scripts (such as *PTP_SetupWizard*) used in earlier versions have been retired. All configuration and monitoring workflows are now handled directly within the custom web application.
