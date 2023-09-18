---
uid: Connector_help_Cisco_Service_Redundancy_Manager
---

# Cisco Service Redundancy Manager

The **Cisco Service Redundancy Manager** will collect all IP services on all active **Cisco DCM elements** in a redundancy group. The services with the **same multicast IP** **and port** are grouped in the same **service group**.

## About

A service is marked as IP service if it meets the following requirements:

- The service is linked to a transport stream.
- Service Multicast IP is not "0.0.0.0".

Using the service group and the status of each service, an Automation script can be used to change the VLAN of a service to the active VLAN (or vice versa).

Service Status:

- **Online_OK**: Service is not faulty and is in active VLAN.
- **Online_FLT**: Service is faulty and is in active VLAN.
- **Ready**: Service is not faulty and is not in active VLAN.
- **Faulty**: Service is faulty and is not in active VLAN.
- **Disabled**: Service Redundancy Status (SRS) of this service is *Disabled*, or the SRS of another service within the same service group is *Forced*, and the service is not in an active VLAN.
- **Online_Disabled**: Service Redundancy Status (SRS) of this service is *Disabled*, or the SRS of another service within the same service group is *Forced*, and the service is in an active VLAN.
- **Stopped**: Hosting TS OTS State is "Streaming paused" or service OSP Streaming is "No".

A service is faulty when the service has a non-descrambled alarm, or is billboard (= last backup service).

A service is in active VLAN if the configured active VLANs contains the VLAN of this service.

## Configuration and installation

### Installation

This is a **virtual** protocol. This means that all the configuration is done in the element's Data Display, instead of during element creation.

### Configuration

The entire configuration can be done on the Configuration page.

**Active VLANs:** This is a comma- or semicolon-separated list.

**Redundancy Group:** Redundancy group with the Cisco DCM elements. After you select a redundancy group, the elements in this redundancy group are shown in the **Redundancy Group Elements** table.

Click the **Refresh** button to refresh the redundancy groups and the elements of the selected redundancy group.

## Usage

### Services page

On this page, the **Service Table** and **Service Element table** are displayed.

### Configuration page

This page displays all the configuration parameters of the element. Refer to the "Configuration" section above for more information.
