---
uid: Release_overview
---

# DataMiner release overview

On this page, you can find an overview of the scheduled DataMiner updates.

## Core DataMiner updates 2025-2026

In the calendar below, you can find the release date for every release, as well as the scheduled period leading up to it, when the development teams are making code changes for it. For more information on the release cycles shown in this calendar, refer to [Core update release cycles](#core-update-release-cycles) below.

![Roadmap 2025-2026](~/release-notes/images/DM_RoadMap2025-2026-1.svg)

## Core update release cycles

A typical release cycle consists of:

- 4 weeks of **development and testing** (2 sprints of 2 weeks)
- 3 weeks of **soak testing**
- the **version release**, on the last Friday of those 3 weeks

During this cycle, there are **go/no-go decision point**s to see if a certain change has a negative impact on the release. If it does, and if we cannot safely fix it before the release date, the change gets reverted to make sure we can still release the other changes.

Here is an example of how you should interpret the overview: DataMiner 10.5.8 is scheduled for release on July 11th. Development of new functionality and fixes for this version is ongoing between May 23rd and June 20th. For some larger features that take more time, development may have started earlier already.

![Roadmap detail](~/release-notes/images/DataMiner-Release-Calendar-2025-2026-detail-1.png)

As we live in a VUCA world, the content of the releases cannot be determined beforehand.

When a version is released, you can find the full DataMiner packages for both the Main and the Feature Release on [DataMiner Dojo](https://community.dataminer.services/dataminer-server-upgrade-packages/).

## Client updates

Next to the full-blown DataMiner updates, you can opt for [regular Cube updates](xref:Managing_the_start_window#selecting-your-cube-update-track). This way you can use the latest Cube version even if you keep an older DataMiner version on the server for a while. These independent Cube updates can be used from DataMiner 10.2 onwards.

From DataMiner 10.3 onwards, the DataMiner web apps can also be updated independently. For more information, refer to [Upgrading the DataMiner web apps](xref:Upgrading_Downgrading_Webapps)

## DxMs

Some DataMiner functionality has been decoupled from the core software to allow for more granular releases of functionality without the need to fully restart the DataMiner server. These DxM (DataMiner Extension Module) packages are released more ad hoc, but the development cycles are similar to those of the core DataMiner releases. Some DxMs can be updated along with the core software upgrade, others need to be updated [via the dataminer.services Admin app](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions). For more information, refer to [DataMiner Extension Modules (DxMs)](xref:DataMinerExtensionModules).

## dataminer.services

Our cloud environment can be updated at any time. It is a great way of leveraging new DataMiner services. The same development-test-release cycle is applied, just like for DxMs.

## Update summary

Below you can find a quick overview of the different kinds of DataMiner updates, their frequency, their impact, and the way you can install them.

| Release type | Release frequency | Impact | Medium |
|--------------|-------------------|--------|--------|
| DataMiner Core | Every 4–6 weeks | DataMiner restart | .dmupgrade package |
| DataMiner Cube | Every 4–6 weeks | [Independent automatic updates](xref:Managing_the_start_window#selecting-your-cube-update-track) possible | Automatic download by Cube |
| DataMiner Web Apps| Every 4–6 weeks | [Independent manual updates](xref:Upgrading_Downgrading_Webapps) possible, without DataMiner restart | .dmupgrade package |
| DataMiner Extension Modules | When needed | DxM-dependent | Via dataminer.services or part of .dmupgrade package, depending on the DxM |
| dataminer.services | Ad hoc | No user impact | Automatic |
