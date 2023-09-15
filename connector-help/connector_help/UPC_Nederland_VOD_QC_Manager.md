---
uid: Connector_help_UPC_Nederland_VOD_QC_Manager
---

# UPC Nederland VOD QC Manager

The **UPCN VOD QC Manager** is a **virtual** connector. It's used to manage the dataflow between the **UPCN VOD Workflow Manager** and the **Digimetrics Aurora.**

## About

The connector will receive asset data from the **workflow manager**, these assets are sent to an **Aurora** server for a quality check (QC). Once the QC is done the results are sent back to the **workflow manager**.

Incoming assets are sorted on 4 values: Queue Priority, Date, Category Priority and Name. The asset with the highest priority will be scheduled first. Each assets also has a certain template linked to it, which defines which QC is used.

## Installation and configuration

### Creation

This connector uses a **virtual** connection and does not need any user information.

### Extra configurations

There are some extra **configurations** that need to be done before the connector can work correctly. These **configurations** need to be set on the **General-** and the **Template** page. The settings that need to be done, are explained in more detail on the **Usage \> General** and **Usage \> Template** section of this document.

## Usage

### General

On the **general** page the settings concerning the inter element communication are found.

The **Application DMAid/Eid** parameter needs to be set with the **dma id** and **element id** of the **UPCN VOD Workflow Manager.** Otherwhise no assets will be received.

In the **Server** table it's possible to add **Aurora** servers. Before communication with these elements is started, the column **ST DMAid/Eid** needs to be filled in. Other settable columns are: server **Name, QC Type** and **Report Path**.

### QCA

The **QCA** page contains the following parameters:

\-**Queue Time QC-A**: displays the current queue time, this parameter is used for the internal asset processing logic.

\-**Queue Time for Extra QC-A**: is a settable parameter which defines how big the **Queue Time QC-A** should be before changing a **QC-B** server into a **QC-A** server.

\-**Queue Time for Skipping**: is a settable parameter which defines how big the **Queue Time QC-A** should be before entirely skipping the asset.

\-**QCA Estimated Processing Time**: is a settable parameter which is needed to calculate the current **Queue Time QC-A**.

\-**Assets QC-A Table**: contains all the assets which are approved to be sent to the **Aurora QC-A** servers.

### QCB

This page will contain data concerning assets that are sent to a **QCB** server. (Phase 2/3 of project)

### Templates

Each asset contains 6 content flags: **ADI, Movie, Poster, Box_Cover, Preview** and **Promo**. For every possible combination of these components (2<sup>6</sup>=64), there can be a template defined in the **Aurora** server. This page links the 6 components to a certain **Template**. It's needed to always have a template defined for the components in an incoming asset, otherwhise this asset will be skipped.

To define a template, just go to the correct combination of the 6 components, and select in the **TT Name** column a valid **Template.**
