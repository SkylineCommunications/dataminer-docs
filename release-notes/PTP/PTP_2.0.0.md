---
uid: PTP_2.0.0
description: "Learn about PTP 2.0.0, featuring the PTP Monitor web app, integrated connector mediation, and various enhancements."
---

# PTP 2.0.0

## Prerequisites

- DataMiner 10.6.2 or higher.
- DataMiner Web 10.6.3 or higher.
- The [DataMiner GQI DxM](xref:GQI_DxM) must be enabled.
- The DataMiner System must use a storage setup with indexing, preferably [Storage as a Service (STaaS)](xref:STaaS) or [dedicated clustered storage](xref:Dedicated_clustered_storage).

## New features

#### Custom web application: PTP Monitor

A new custom DataMiner web app, *PTP Monitor*, is now available. You can access it directly from any web browser at `https://[Your DMA name]/public/ptp/`.

The application provides the following dedicated pages:

- **Summary page**: Real-time domain summary KPIs, active alarms table with filtering, active grandmaster details with BMCA parameters, and PTP probe trend graphs.
- **Nodes page**: Comprehensive inventory of all PTP devices in the domain, with role filters, alarm state indicators (element state and PTP state), slide-out node details, and multi-selection comparison.
- **Compare panel**: Side-by-side comparison of two or more nodes across Clock, Default DS, Current DS, Parent DS, Grandmaster, Time Properties, and Port datasets, featuring automated difference highlighting in amber and performance sparklines.
- **Topology page**: Interactive node graph displaying DCF connections or reported parent connections, distinct clock role icons, state color coding, a toggle button to show or hide followers, and customizable drag-and-drop layout editing saved per domain.
- **Admin page**: Built-in administration wizards for adding, renaming, and deleting domains, configuring device roles, designating preferred grandmasters, and onboarding new domains.

Real-time telemetry and state updates are delivered to the *PTP Monitor* web app using high-performance Generic Query Interface (GQI) ad hoc data sources.

#### In-connector mediation in Skyline PTP 2.0.0.x

Mediation has been integrated directly into the *Skyline PTP* connector (version 2.0.0.x), replacing the separate *Standard DataMiner PTP Device* mediation protocol. This streamlines deployment and eliminates managing a separate mediation layer.

## Changes

### Enhancements

#### Transition to modern follower terminology

In alignment with IEEE 1588-2019 and the PTP Monitor UI, the solution now standardizes on the term **follower** (follower clocks, follower devices, follower role) instead of "slave".

#### Single source of truth for supported connectors

The list of supported vendor connectors has been consolidated into the [Skyline PTP Technical](https://docs.dataminer.services/connector/doc/Skyline_PTP_Technical.html) connector documentation, which serves as the definitive reference for compatible devices.

#### Retirement of legacy automation scripts and Visio pages

The legacy Microsoft Visio visual overview pages and the setup automation scripts (such as *PTP_SetupWizard*) used in earlier versions have been retired. All configuration and monitoring workflows are now handled directly within the custom web app.
