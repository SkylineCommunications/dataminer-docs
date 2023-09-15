---
uid: Connector_help_Dexin_NDS3975
---

# Dexin NDS3975

SNMP connector for Satellite Receiver Dexin NDS3975. Allows the user to monitor and set up parameters.

## About

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Configuration

### Creation

#### SNMPconnection

This connector uses an SNMP connection and does not require any input during element creation.

## Usage

### General

System MIB (system info and snmp config + GpResetCI + alarm parameters + Rate info)

Subpages:

- Decoder (General Param: from ES Mode .... to Program Select ; Gpdescram,from gpaudiospdif to gp destination mac + Ac3 Pass subtree)
- Receiver (the rest of the parameters of the General parameters tree)

### Modules

- Card program info table
- Program info control

### Input Page

- Input program table
- Input AV pid
- BissData info

### Output Page

- Output Program table
- Output AV PId table
- SPTS settings

### Dvb Page

- Dvb

### PID Page

- Table Pid transmit

### Import/Export

- Address, Name, Operate, Completed

### WebSite Page

Link with the device
