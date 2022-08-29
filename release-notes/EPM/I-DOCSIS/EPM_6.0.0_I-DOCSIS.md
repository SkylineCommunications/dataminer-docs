---
uid: EPM_6.0.0_I-DOCSIS
---

# EPM 6.0.0 I-DOCSIS

## New features

\-

## Changes

### Enhancements

#### DS/US channel file structure exported by Casa Systems connector \[ID_31060\]

The Casa Systems connector now exports a new file structure for the DS/US channels so that the Generic CM Collector and Skyline EPM connectors can ingest this to show contextual data for the DS/US ports, DS/US service groups, and the service groups in general. This way, they will be able to show actual channel data instead of using data from cable modem instances of the channels.

#### DS/US channel file structure exported by Cisco CBR-8 connector \[ID_31061\]

The Cisco CBR-8 connector now exports a new file structure for the DS/US channels so that the Generic CM Collector and Skyline EPM connectors can ingest this to show contextual data for the DS/US ports, DS/US service groups, and the service groups in general. This way, they will be able to show actual channel data instead of using data from cable modem instances of the channels.

#### DS/US channel file structure exported by Cisco CMTS connector \[ID_31104\]

The Cisco CMTS connector now exports a new file structure for the DS/US channels so that the Generic CM Collector and Skyline EPM connectors can ingest this to show contextual data for the DS/US ports, DS/US service groups, and the service groups in general. This way, they will be able to show actual channel data instead of using data from cable modem instances of the channels.

### Fixes

#### Issues in Arris E6000 connector \[ID_31063\]

Several issues have been fixed in the Arris E6000 connector:

- An error in QAction 101 could flood the logging, making it difficult to read other issues.
- Some tables could keep growing infinitely.
- When the device was still polling, duplicate entries could occur.

#### Generic DOCSIS CM Collector: Width and Frequency not correctly displayed for CM QAM US Channel \[ID_31105\]

When CM QAM US Channel information was updated, it could occur that the Frequency and Width were not set to the correct values from the QAM US Channel.

#### Generic DOCSIS CM Collector: Width and Frequency not correctly displayed for CM QAM US/DS Channel \[ID_31106\]

When CM QAM US/DS Channel information was updated, it could occur that the Frequency and Width were not set to the correct values from the QAM US/DS Channel.
