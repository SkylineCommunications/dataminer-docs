---
uid: Cost_Billing_Installation
---
# Installation

This section describes what is needed to install the Cost & Billing solution.

## Prerequisites

Before installing the solution, make sure the following requirements are met:

| Prerequisite | Details |
| --- | --- |
| **DataMiner** | DataMiner **10.6.4** or higher is required. |
| **GQI DxM** | The GQI DxM must be installed and running on the DataMiner System. |
| **Standard Data Model Registration** | The [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) Package must be installed with a minimum version of **2.1.1**. |

## Installing the Cost & Billing Solution

The core solution consists of a single [Cost & Billing ](https://catalog.dataminer.services/details/33bca425-6591-482d-a2d5-d118ecf77d54) package that must be deployed.

The **Cost & Billing Solution** package contains:
- The Low-Code App.
- The DOM model and automation scripts.
- The Cost & Billing Dev Pack, which includes the Standard Data Model and provides typed read/write access to the Cost & Billing DOM instances.

Once the package is installed, the core concepts within the Cost & Billing application are fully functional, including **Value Units**, **Contracts**, and **Rate Cards**.

## Installing the MediaOps sample integration 

If the sample integration with **MediaOps Plan** is required, the following  components must also be deployed:

| Prerequisite | Details |
| --- | --- |
| **MediaOps Plan** | The  [MediaOps Plan](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75) package must be installed with a minimum version of **1.6.0**. |
| **Cost & Billing MediaOps Plan Adapter and Calculation** | The [Cost & Billing MediaOps Plan Adapter and Calculation]() package must be installed as it provides the integration between MediaOps Plan and Cost & Billing. The package includes: <br><br> - **MediaOps Adapter**: Synchronizes MediaOps data into Cost & Billing by mapping resources and pools to Items, jobs to Billable Events, and workflows to Groups. <br><br> - **MediaOps Calculation Script**: Performs the time-based cost and billing calculations required for the MediaOps integration. |

> **Note:** These components are only needed for the MediaOps Plan integration. For an integration with any other external system, a dedicated adapter and Calculation Script must be created  — see the [Architecture](architecture.md) section for details. Both the MediaOps Plan Adapter and the MediaOps Plan Calculation Script can be used as a base when integrating with a new external system.
