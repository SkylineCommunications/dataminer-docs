---
uid: Connector_help_OpenStack_Manager
---

# OpenStack Manager

**OpenStack** is an open-source cloud computing software platform. OpenStack allows totally efficient and abstract management of cloud resources using an open-source and interoperable approach.

## About

This connector uses HTTP to monitor and configure any OpenStack cloud. It currently supports the main OpenStack modules, such as Keystone, Glance, Nova, Cinder and Neutron. Currently, only Nova has read-write capabilities, allowing the creation and management of virtual machines in an IaaS fashion.

### Version Info

| **Range** | **Description**              | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version              | No                  | Yes                     |
| 1.0.1.x          | Multi-tenant support version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                           |
|------------------|-----------------------------------------------------------------------|
| 1.0.0.x          | Nova: v2.x, Neutron: v2.0, Cinder: v3.0, Keystone: v3.0, Glance: v2.0 |
| 1.0.1.x          | Nova: v2.x, Neutron: v2.0, Cinder: v3.0, Keystone: v3.0, Glance: v2.0 |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address, by default *ByPassProxy*.

## Usage

### General

This page allows you to configure the **HTTP connection** settings, such as **username** and **password**.

You can also monitor the current connection status and the history of the issues that have occurred. The issue history can be accessed via the **HTTP Log** page button. This displays a subpage listing all the errors that have occurred, sorted by date and time. The errors are grouped by function, so that it is only possible to view the last event for each function. The subpage also contains a button that can be used to clear the table. Note that this table is persistent.

### Overview

This page displays two tables summarizing the **overall usage** for all valid projects:

- The **Usage Report** table summarizes the active state for each project from its start. It is possible to monitor the **VCPUs**, **Disk** and **RAM** history, as well as the **VCPU**, **Disk** and **Memory Hours**. The latter are obtained by multiplying the total amount of GB or MB by the number of hours consumed.
- The second table displays the overall usage since the OpenStack deployment for every server, terminated or not. It allows you to monitor the **VCPUs**, **Hours**, **Disk**, **Memory**, **Uptime**, **Flavor** and **Start** and **End dates**.

### Hypervisors

This page contains a tree control that allows you to navigate from the **hypervisor** to the created **instances**. On the first level, you can monitor several parameters related to the selected hypervisor, including the additional usage information, such as the amount of used and available disk space, VCPU and memory, the number of VMs running, the IP address, the entire physical CPU architecture and feature, the uptime, and also the load in the last minute, 5 minutes and 15 minutes. Note that in some cases the load can be higher than 100%. This means that the hypervisor was overloaded.

From the **Hypervisor** page, you can also access a detailed **Statistics** page, where disks, memory and processing are shown in detail. There is also a **Compute Services** subpage that allows you to view and manage the existing compute services. For security reasons, there is no delete option on this subpage. On the **Flavors** subpage you can also view the existing Flavor configurations, as well as create new flavors.

There is also an **Error Table** page where any server faults are listed.

Finally, you can also verify the supported **Nova Versions** and consult the **Guest Agents** information on this page, if available.

### Host Aggregates

This page contains the **Host Aggregates** table, where you can **monitor and edit** existing host aggregations, as well as **manage hosts** and the respective **metadata**. You can also **create new** host aggregations with the button at the top of this page.

### Images

This page displays the available **images** per project. The same image is multiplied by the number of projects where that image is available.

### API Access

This page contains all the **public addresses** for every module in every authenticated project.

### Instances

This page contains a tree control with all the **instances** (VMs) running on every project.

By navigating down in the tree control, you can find the same information as on the Hypervisor page, namely **Addresses** and **Volumes Attached**. By selecting an instance, you can access its main information, as well as a large menu with all possible immediate actions, such as **start**, **stop**, **pause**, **resume**, etc. This menu also allows you to **create snapshots**, **attach** or **detach** **volumes** or **network interfaces**, **edit** the instance, **resize** the instance, and even **update** the **metadata**.

Further down in the tree control, you can find all **IP addresses** configured in that instance and also all **volumes** attached.

### Key Pairs

This page contains all existing **Key Pairs** for all projects. It allows you to monitor, **create**, **import** and **delete** key pairs.

### Volumes

This page contains a tree control where you can monitor all existing volumes for all authenticated projects.

Selecting a volume allows you to both monitor and manage it, e.g. by **editing** the **name**, **description, bootable option** and **size**. Additional available actions are **Manage Attachment**, **Create Snapshots**, **Change Volume Type**, **Backup**, **Upload to Image**, **Create Transfer**, **Update Metadata** and **Delete**.

Further down in the tree control, you can also access the **Attachments** list, with the **detach** option, the **Metadata** list, with the options to **edit** the value or **delete** it, and the **Transfers** list, with the option to **delete** it.

The page also provides access to the following subpages:

- **Volumes Limits:** Allows you to monitor the **storage limits** established for every project, as well as the amount of **used storage**.
- **Messages:** Displays the messages.
- **Versions**: Displays the supported storage module versions.

### Snapshots

This page contains another tree control that allows you to view all existing **snapshots** for every project and their respective **metadata**. Selecting a snapshot allows you to monitor it and also to **edit** the name and description, and **update the metadata**. You can also delete the metadata or even the snapshot.

### Volume Types

This page contains a tree control that allows you to monitor and control **Volume Types**. For each volume type, you can also **create Extra Specs** and **Encryptions**, as well as **delete** the type. A button at the top of the page can be used to **create new volume types**.

### Networks

This page contains a tree control with all available **networks** for all authenticated projects. Selecting a network allows you to monitor it, to change its **configuration** and to execute specific actions, such as **deleting**, creating **Subnets** and creating **Ports**.

Further down in the tree control, you can select a **Port** to monitor and control it, and also to visualize the relevant **Fixed IPs**, **Allowed Address Pairs**, **Extra DHCP Options** and **Virtual Interface Details**. You can also select a **Subnet** to monitor its **Allocation Pools** and to edit or delete it.

The page also provides access to the following subpages:

- **Subnet Pools**: Displays a table with all existing subnet pools for all authenticated projects. You can **edit and delete** the pools here, but not create them. **Creating** pools is only possible at project level and must be done using the **OpenStack openstack - Project** element.
- **Quota**: Displays a table with all network quotas for all authenticated projects.
- **Service Providers**: Displays a list of the existing service providers.

### Routers

This page contains a tree control where you can monitor and control all existing **routers**. Selecting a router allows you to view detailed information and perform basic actions, such as **editing the** **name**, **description** and **admin state**, **adding a new interface** or **deleting** **an interface**.

Further down in the tree view, you can find the relevant **External Fixed IPs** and the associated **Interfaces**. The former allow you to fully manage the relevant **Subnets**, while the latter allow you to do the same for the relevant **Ports**.

### Security Groups

This page contains a tree control with all **security groups** for all authenticated projects. Selecting a security group allows you to **edit** it, **delete** it and **manage** **Rules**. These rules can only be **added** and **deleted**.

### Floating IPs

This page contains the **Floating IPs** table, where you can **monitor**, **associate** and **disassociate** IPs from ports. It is also possible to **delete** the floating IP.

### IP Availability and Usage Stats

This page allows you to consult the amount of available and used IPs for every authenticated project.

### Projects

This page is the main page to **boot and control this connector**. This table allows **full management of projects** within OpenStack, as well as **DVE management** within the DataMiner domain. You can manually configure the **credentials** of each project, as well as request the **authentication**. You can also **disable** or enable the project **polling**, or **delete** the project. The project can be deleted without deleting the DVE, and the DVE can be deleted without deleting the project. However, an option at the bottom of the page also allows you to toggle whether or not to automatically **delete the DVE on project deletion**.

The page also contains a button that can be used to **create** **new projects.** When creating a new project, you must give it a name and select the **users**, **groups** and **quotas**.

### Users

Lists all existing users.

### Groups

Lists all existing groups

### Roles

Lists all existing roles.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
