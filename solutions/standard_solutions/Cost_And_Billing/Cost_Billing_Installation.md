---
uid: Cost_Billing_Installation
description: "Learn how to install Cost & Billing, including prerequisites, core solution deployment, and the optional MediaOps Plan sample integration."
---

# Installing Cost & Billing

## Prerequisites

Before installing the solution, make sure the following requirements are met:

- **DataMiner 10.6.0** or higher is installed.
- The [GQI DxM](xref:GQI_DxM) is installed and running.
- [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) version **2.1.1** or higher is installed.

## Installing the Cost & Billing Solution

To install the solution, after the prerequisites are met, deploy the [Cost & Billing](https://catalog.dataminer.services/details/33bca425-6591-482d-a2d5-d118ecf77d54) package from the Catalog.

This will deploy the following components:

- The Cost & Billing low-code app.
- The DOM model and automation scripts.
- The Cost & Billing Dev Pack, which includes the Standard Data Model and provides typed read/write access to the Cost & Billing DOM instances.

> [!TIP]
> After the package is installed, you can start [configuring value units](xref:Cost_Billing_Configuring_Value_Units), [contracts](xref:Cost_Billing_Configuring_Contracts), and [rate cards](xref:Cost_Billing_Configuring_Rate_Cards).

## Installing the MediaOps sample integration

If the sample integration with **MediaOps Plan** is required, **DataMiner 10.6.4** or higher must be installed installed.

The following components are required:

- The [MediaOps Plan](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75) package, version **1.6.0** or higher.

- The [Cost & Billing MediaOps Plan Adapter and Calculation](https://catalog.dataminer.services/details/4c6e38cd-495c-417d-bd6b-f54c4f77e407), which provides the integration between MediaOps Plan and Cost & Billing. This package includes:

  - **MediaOps Adapter**: Synchronizes MediaOps data into Cost & Billing by mapping resources and pools to items, jobs to billable events, and workflows to groups.
  - **MediaOps Calculation Script**: Performs the time-based cost and billing calculations required for the MediaOps integration.

> [!NOTE]
> These components are only needed for the MediaOps Plan integration. For an integration with any other external system, a dedicated adapter and calculation script must be created. For details, refer to [Integration with other solutions](xref:Cost_Billing_Integration).
