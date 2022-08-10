---
uid: EPM_6.1.1_I-DOCSIS
---

# EPM 6.1.1 I-DOCSIS

## New features

\-

## Changes

### Enhancements

#### Performance improvements for CCAP connectors \[ID_32935\]

A number of changes have been implemented to the CCAP connectors to improve performance:

- To reduce the load on the server and client, the Data pages for the CCAP connectors can now only be opened by the Administrator user.
- The "volatile" option has been added to the following tables: *CM overview*, *CM US QAM*, *CM DS QAM*, *CM Registration*, *CM Upstream Channels*, *CM US Status DOCSIS 3* and *CM US Status*.
- When the *CM Upstream* page is disabled on the *Configuration/Other* settings page, polling for the *CM Upstream Channels* table is now disabled.

#### EPM manager improvements \[ID_32964\]

Several improvements have been implemented to the EPM managers:

- To improve performance, the volatile option has been added to the *CM Overview*, *CM QAM US*, *CM QAM DS* and *Subscribers Overview* table. This will prevent primary keys, display keys, and foreign keys from being saved in the database automatically.
- To improve performance, a new buffer system is now used for the reset and import/export logic, so that one CCAP-CM pair is handled at a time instead of all being handled at once.
- A daily reset is now triggered by the front-end element to ensure that the system remains up to date with the current state of the devices.

#### General improvements for EPM front-end element \[ID_32966\]

The following general improvements have been implemented in the Skyline EPM Platform connector:

- To improve consistency, the *DOCSIS Number Market*, *DOCSIS Number Hub*, *DOCSIS Number CCAP* and *DOCSIS Number CM* parameters on the *General* page of the EPM front-end element are now filled in based on the *DOCSIS Network Overview* table.
- To improve performance, passive logic during a reset is now processed after all CCAP-CM pairs have been processed.

#### General improvements for EPM back-end element \[ID_32967\]

The following general improvements have been implemented in the Skyline EPM Platform connector:

- To improve consistency, the *Number CCAP* and *Number CM* parameters on the *General* page of the EPM back-end element are now filled in based on the *CCAP Core Overview* table.
- To improve performance, passive logic during a reset is now processed after all CCAP-CM pairs have been processed.

### Fixes

#### Row with primary key -1 set in DOCSIS US Ports and DOCSIS DS Ports tables \[ID_32967\]

In some cases, a row with primary key -1 could be set in the *DOCSIS US Ports* and *DOCSIS DS Ports* tables.
