---
uid: Connector_help_CEFD_PCB4300
---

# CEFD PCB-4300

The Comtech CE Data (CEFD) PCB-4300 1:2 Phase Combiner, together with three Solid State Power Amplifiers (SSPAs) and associated waveguide and cabling, form a complete 1:2 phase combined system.

In a 1:2 phase combined system, two of the three SSPAs are normally online and their outputs are summed in the waveguide combiner, effectively doubling the system output power. The third SSPA remains offline and, in the event of a failure of either of the two online units, its "standby" output is automatically switched in place of the failed unit - thereby maintaining full system output power.

## About

The CEFD PCB-4300 demands a **serial** approach in order to communicate with it. This protocol allows the user to maintain some settings of the **PCB** and the **SSPAs**. It also gives an overview of the statusses and possible alarms

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |



### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |



### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |



## Configuration

### Connections

#### Serial Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: Depending on the customer
  - **IP port**: Depending on the customer
  - **Bus address**: Not required

### Initialization

No need to configure anything else.

### Redundancy

There is no redundancy defined.

## How to use

This connector is very simple to use. There are only two settings that might make sense to configure. Are they:

### - Stored Alarms

On this page, the user can configure the maximum number of rows that should be retained in the table. This parameter is used to limit the maximum number of rows for the SSPAs Stored Alarms Tables too. When the number of rows in the table is higher than the mximum limit, the oldest rows will get deleted.

#### - Real Time Clock (SSPA 1/2/3)

On this page, the user can see and configure the **date** and **time** of the SSPA.
