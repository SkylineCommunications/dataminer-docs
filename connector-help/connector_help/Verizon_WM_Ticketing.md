---
uid: Connector_help_Verizon_WM_Ticketing
---

# Verizon WM Ticketing

The Verizon WM Ticketing connector is used to handle the Verizon VSAT business logic towards the automation of the ticketing workflow. The connector interacts, directly or indirectly, with collector elements, Correlation rules, and Automation scripts.

## About

As this is a virtual connector, **no data traffic** will be shown **in the Stream Viewer**.

#### Enterprise Ticketing Management System (ETMS) Integration

1. The Correlation engine will listen for and capture information events coming from collector elements.

1. The Correlation engine executes an Automation script passing along the ticketing message.

1. The Automation engine selects the Verizon WM Ticketing (WMT) element that will continue with the ticketing workflow and sends the ticketing message via parameter set.

   - The WMT element selection is based on the DMA ID of the collector that triggered the info event in the first place. The idea is that workflows are initiated and completed on the same DMA whenever possible. If no WMT element is found, Automation will send the info message to any active WMT element within the DMS.

1. The WMT element performs a series of diagnostic activities, which are part of the overall ticketing workflow:

   1. PLM
   1. Sun Outage
   1. Weather Underground
   1. Network Connectivity
   1. Temperature
   1. KPIs

1. Once diagnostics are completed, the WMT element will send the final ticketing message with the result of the diagnostics to the ETMS element operating as back end on the current DMA.

### Version Info

| **Range**            | **Description**                                                                                                            | **DCF Integration** | **Cassandra Compliant** |
|----------------------|----------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | Initial version. Uses BinaryFormatter, which contains deserialization and security vulnerabilities and should not be used. | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Layout adapted and SLA and fault logic implemented.                                                                        | No                  | Yes                     |
| 1.0.2.x \[SLC Main\] | Minimum DataMiner required version increased from '10.0.3.0 - 8964' to '10.0.10.0 - 9454'                                  | No                  | Yes                     |

## Configuration

### Creation

This connector uses a **virtual** connection and does not require any input during element creation.

## Usage

### VerSat OnTicketing

This page provides an overview of the main sections of the connector. A configuration subpage for each interrogation process can be accessed via a page button. Depending on the interrogation process, different options are available. Any diagnostic (interrogation) can be disabled or enabled manually via a toggle button.

### Diagnostics

This page contains an overview of the diagnostic results.
