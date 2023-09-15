---
uid: Connector_help_Microsoft_Hyper-V
---

# Microsoft Hyper-V

This connector is an administrative tool to manage a local Hyper-V host and a limited number of remote hosts.

Hyper-V is a hypervisor-based virtualization technology for certain x64 versions of Windows. The hypervisor is core to virtualization. It is the processor-specific virtualization platform that allows multiple isolated operating systems to share a single hardware platform. Hyper-V supports isolation in terms of a partition. A partition is a logical unit of isolation, supported by the hypervisor, in which operating systems are executed. The Microsoft hypervisor must have at least one parent or root partition running Windows.
The virtualization management stack runs in the parent partition and has direct access to hardware devices. The root partition then creates the child partitions that host the guest operating systems. A root partition creates child partitions using the hypercall application programming interface (API).

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## How to use

The element consists of the following data pages:

- **Summary**: Displays summary information related to the Virtual Machine (VM) present in the system.
- **Settings**: Contains security settings such as **Username** and **Password**, as well as network settings, i.e. **Domain** and **IP Address**.
