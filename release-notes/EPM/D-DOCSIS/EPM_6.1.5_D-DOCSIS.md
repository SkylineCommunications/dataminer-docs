---
uid: EPM_6.1.5_D-DOCSIS
---

# EPM 6.1.5 D-DOCSIS - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## New features

#### Buttons to refresh and sort view tables [ID_34019]

In the EPM visual overview, it is now possible to refresh the EPM view buttons using a refresh button. Next to this button, the date and time when the data were last refreshed in the client are displayed.

In addition, a custom sorting button is now available.

## Changes

### Enhancements

#### Cox Smart Phy: Improved handling of multiple BC/NC service groups [ID_33999]

When RPD devices have multiple nodes and therefore multiple BC/NC service groups, the *Cox Smart Phy* connector will now take this into account. It will now export all service groups, so that they can be shown correctly in the EPM solution.

#### Cox Ceeview Platform: Improved export handling [ID_34000]

To avoid constantly overwriting the export file, the *Cox Ceeview Platform* collector will now only export the data once all buffered RPD requests have been handled.

#### CISCO CIN Manager Platform now uses dynamic trailers [ID_34003]

Up to now, the *CISCO CIN Manager Platform* connector did not use trailers for SSH CLI calls, so timeouts had to be set manually to send the next call. Now every time the connector logs in, it gets a dynamic trailer to know when a response has ended and the next request can be sent.

#### Skyline CCAP Platform EPM: Visual and Topology page improvements [ID_34004]

A number of improvements have been implemented to the Skyline CCAP Platform EPM pages:

- The Visual pages with a side panel, i.e. *CM Overview*, *RPD Association*, and *Node Utilization*, now show all available fields and buttons regardless of the resolution or aspect ratio used.

- On the *CM Overview* page, you can now search for *Unknown* for the manufacturer.

- If a *Topology* page shows a link from an RPA to connected RPDs, you can now click this to open the interface page of the selected RPA and see which interfaces are in alarm.

#### EPM interface integration [ID_34005]

*DCF Interface* tables have been removed from the collectors. Instead, they are now using *CIN Interface* and *DPIC Interface* tables, as those also exist at the EPM level. This allows EPM to know the destination and source of all interfaces in the system, so that it can show the user how all interfaces are connected to one another.

#### Topology visual pages can now display up to 20 RPDs [ID_34313]

The topology visual pages have been adjusted so that they can now display up to 20 RPDs.

#### Cox CBR-8 Platform D-DOCSIS/CISCO CBR-8 CCAP Platform Collector: Core IP retrieval improvement [ID_34314]

An improvement has been implemented to the way Core IPv6 values are retrieved for the Cable Modem Overview table. This way, the table can better represent what the values are supposed to be, and there are fewer rows showing exception values.

#### Standalone Elastic Backup tool improvement to secure credentials [ID_34438]

As the commands of the Standalone Elastic Backup tool could expose the password, the tool has been modified to use an encrypted password instead of plain text. A separate tool, *PasswordEncryptionTool.exe*, has also been created to encrypt a plain text password.

#### Exposed tables removed [ID_34693]

To improve performance and stability, several exposed tables that were linked to the CCAP and RPD EPM objects have been removed.

#### ID logic for cable modems separated from other entities [ID_34694]

To improve stability, when processing the full system because of a change to the devices' connectivity structure, EPM will now process the cable modems separately. For this purpose, the ID file that is used for this has been split up into multiple files: one with the unique IDs for all entities except the cable modems, and individual files for the cable modem IDs in accordance with the number of CCAPs in the system.

### Fixes

#### Cox CBR-8 Platform D-DOCSIS: Kafka ingestion and EPM file creation taking too long [ID_34002]

In some cases, the Kafka ingestion and EPM file creation processes could take too long, causing RTEs because they locked other processes in the connector. The processing time has now been improved, and data is handled much more efficiently.

#### RPD OFDM Profile above 100% [ID_34437]

In some cases, the logic used to calculate the percentages for OFDM Profiles could result in values over 100%. To resolve this, the logic will now determine the OFDM CMs and calculate the OFDM Profile % Distribution shown in the RPD Overview.
