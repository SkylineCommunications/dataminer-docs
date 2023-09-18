---
uid: Connector_help_Sky_UK_MCR_Desk
---

# Sky UK MCR Desk

The **Sky UK MCR Desk** connector is a **virtual** connector that is used in Sky to run a script.

The data for a particular monitor that is linked to a certain desk is saved in the element data.

A Visio drawing will contain a button that will launch an **automation script**.

## About

The script can be either a generic one, or the one that is linked to the MON FOLLOW function.

It is used in case the MON FOLLOW function is enabled in the Visio that is on the **Atos BNCS** element.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Configuration

### Connections

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

On the General Page, you need to configure the Linked Output Monitor and the SDI Matrix Element. You can also configure a separate Audio Matrix Element, and Audio Monitoring Outputs.

## Usage

### General

This connector shows 6 parameters: The **Monitor Follows IO**, the **Buffer-Trigger Automation Script**, the **Local SD Matrix Element**, the **SDI Monitoring Outputs**, the **Local Audio Matrix Element** and the **Audio Monitoring Outputs**.

The name of the Matrix is shown on the **SDI Matrix Element** parameter.

This connector also shows 2 other parameters: The **Monitor Follows IO** and a **Linked Output Monitor**.

Also the **Buffer - Trigger Automation Script** parameter shows the command that was sent from Visual Overview. The syntax of the command that triggers the launching of the script adheres to a certain standard.The line should start with \[Automation\].

Furthermore there are 2 separators: \[NextAtt\] and \[AttData\].

If the line that is sent from Visual Overview to the Sky UK Desk connector contains the word "MONFOLLOW" (case insensitive), the Monitor Follows IO parameter is checked.

The **Automation script** will then run if that parameter is set to Enabled, and set a Crosspoint on the Matrix, or perform another - yet to be defined - function.The part followed by \[NextAtt\] contains the command that needs to run, or the parameter that needs to be set, the part followed by \[AttData\] then contains the data to be set for that parameter, is an attribute for that command.The command set still needs to be completed.
