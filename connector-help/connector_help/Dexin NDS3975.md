---
uid: Connector_help_Dexin_NDS3975
---

# Dexin NDS3975

Driver SNMP for Satellite Receiver Dexin NDS3975, Allows the user tomonitoring and set up parameters.

## About

The SNMP device, allows the user to monitoring and set up parameters. Also contains different pages that do easier the undestanding of Parameters Displayed

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### SNMPconnection

This driver uses a SNMP connection and does not require any input during element creation.

All Pages and Subpages were done and grouped to do it easier to undertand for the user.

## Usage

General

System Mib (system info and snmp config + GpResetCI + alarm parameters + Rate info)

SubPage - Decoder (General Param: from ES Mode .... to Program Select ; Gpdescram,from gpaudiospdif to gp destination mac + Ac3 Pass subtree) - Receiver ( the rest of param of Generalparam tree)

## Modules

\- Card program info table- Program info control

## Input Page

\- Input program table- Input AV pid- BissData info

## Output Page

\- Output Program table- Output AV PId table- SPTS settings

## Dvb Page

-Dvb

## PID Page

-Table Pid transmit

## Import/Export

-Address, Name, Operate, Completed

## WebSite Page

Link with the device
