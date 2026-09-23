---
metadata_version: 1
uid: AdvancedDVEsExercise
description: "Describe the DataMiner connector development topic Exercise, including its purpose, behavior, implementation guidance, and relevant constraints."
---

# Exercise

The Network Electronics Flashlink device is a chassis that contains several modules. The chassis address can be configured from 0 to 7.

![Network Electronics Flashlink manager UI](~/develop/images/network_elektronics_flashlink.png)

The NWORK.mib can be used to find information about what is available via SNMP. Create DVE elements for the avhdxmux (106) and oe2hdsdi (150) modules. Export the parameters available in the moduleTable and voltageTable.

Important: do this only for the modules coming from the chassis number you specify in the bus address.

There is also a simulation available.
