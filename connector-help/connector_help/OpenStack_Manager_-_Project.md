---
uid: Connector_help_OpenStack_Manager_-_Project
---

# OpenStack Manager - Project

**OpenStack** is an open-source cloud computing software platform. OpenStack allows totally efficient and abstract management of cloud resources using an open-source and interoperable approach.

## About

This connector uses HTTP to monitor and configure any OpenStack cloud. It currently supports the main OpenStack modules, such as Keystone, Glance, Nova, Cinder and Neutron. OpenStack OpenStack - Project is an exported element automatically created to cover an existent project.

### Product Info

| **Range** | **Device Firmware Version**                                           |
|------------------|-----------------------------------------------------------------------|
| 1.0.0.x          | Nova: v2.x, Neutron: v2.0, Cinder: v3.0, Keystone: v3.0, Glance: v2.0 |
| 1.0.1.x          | Nova: v2.x, Neutron: v2.0, Cinder: v3.0, Keystone: v3.0, Glance: v2.0 |

## Installation and configuration

### Creation

- This connector is used by DVEs that are automatically created by the parent element.

## Usage

### API Access

The API Access page contains the **public addresses** for every module in the respective project. It also allows the user to consult the project **Credentials**.

### Overview

The Overview page is split in two sections, the **Limit Summary** and the **Usage Summary**. The first presents the overall limits of the project, namely the **maximum** and **used** **Instances**, **VCPUS**, **Floating IPs**, **Memory**, **Security** **Groups**, **Volumes** and **Volumes** **Storage**. The second section presents the **Total** **Hours** and **Hours** **per** **Disk**, **Memory** and **VCPU**. It also includes the **Server Usage** Table containing the summary detailed for each instance.

### Instances

The Instance page includes a tree control containing all the **instances** (VMs) running on the respective project. By navigating down in the tree control, the user can find the same information presented in the Hypervisor page, namely, **Addresses** and **Volumes Attached**. By selecting an instance, the user can access to its main details and also to a large menu, where he/she can find all the possible immediate actions, such as, **start**, **stop**, **pause**, **resume**, etc.., and also, where he/she can **create snapshots**, **attach** or **detach** **volumes** or **network interfaces**, **edit** the instance, **resize** the instance, or even **update** the **metadata**.

Going down in the tree control, the user can find all **IP addresses** configured in that instance and also all **volumes** attached.

At the top of this page there is the **Launch Instance** button that allows the user to fully create a new instance.

### Images

The Images page show the **images** available for the respective project.

### Key Pairs

The Key Pairs page contains all **Keypairs** existent for the project. In this page the user can not only monitor those keypairs, but also **Create**, **Import** and **Delete** them.

### Volumes

The Volumes page contains a tree control where the user can immediately monitor all existent volumes for the respective project. By selecting one volume, the user can not only monitor it, but also managing it, by **editing** the **name**, **description, bootable option** and **size**. There are also a set of other possible actions available, such as, **Manage Attachment**, **Create Snapshots**, **Change Volume Type**, **Backup**, **Upload to Image**, **Create Transfer**, **Update Metadata** or **Delete** the volume. At the right top there are two buttons. The first allows the user to **Create a New Volume** for the respective project, while the second allows the user to **Accept a Transfer**.

By going down in the tree, the user can also access to the **Attachments** list, with the available **option** to **detach**, the **Metadata** list, with options to **edit** the value or **delete** it, and the **Transfers** list, with option to **delete** it.

Through the Volumes page the user can also access the **Volumes Limits**, **Messages** and **Versions** sub pages. In the first, the user can monitor the **storage limits** established for every project, as well as, the amount of **used storage**. In the second the user can view the messages and in the third the supported storage module's versions.

### BackUps

The Backups page contains a table presenting all backups existent for the respective project.

### Snapshots

The Snapshots page contains another tree control, where the user can observe all existent **snapshots** for the respective project and their respective **metadata**. By selecting one snapshot, the user can not only monitor but also **edit** the name and description, and also, **update the metadata**. The user can also delete the metadata or even the snapshot.

### Consistency Groups

The Consistency Groups page contains the respective table and a button to **Create** a new **Consistency Group**.

### Networks

The Networks page also contains a tree control presenting **all** available **networks** for the respective **project**. By selecting one network, the user can not only monitor it, but also change its **configuration** and execute specific action, such as, **delete**, create **Subnets** and create **Ports**. To create new Networks the user can push the **Create Network** Button located on top.

By navigating through the tree control, the user can do the same level of interaction to **Subnets** and **Ports**. By selecting a **Port**, the user can not only monitor and control it, but also visualize the respective **Fixed IPs**, **Allowed Address Pairs**, **Extra DHCP Options** and **Virtual Interface Detais**. On the other hand, by select a **Subnet** the user can monitor its **Allocation Pools** and also edit or delete the own subnet.

From this page the user can also access three other subpages, namely, the **Subnet Pools**, the **Quota** page and the **Service Providers** list. The Subnet Pools page presents a table with all existent subnet pools for the respective project. Here, the user can edit, delete and create pools. The Quota page presents a table containing all network quotas for the respective project, while the Service Providers page presents a short list of the existent service providers.

### Routers

The Routers page contains a tree control from which the user can **monitor** and **control** the project's **routers**. By selecting one router the user can observe the details and perform basic actions, such as, **edit** **name**, **description** and **admin state**, as well as, **add a new interface** or even **delete** it. To Create a new Router the user must push the **Create Button** positioned at the top right.

Going down in the tree, the user will find the respective **External Fixed IPs** and the associated **Interfaces**. In the first the user can fully manage the respective **Subnets**, while in the latest the user can do the same operation level over the respective **Ports**.

### Security Groups

The Security Groups page presents another tree control containing **all security groups** available for the respective project. By selecting one security group, the user can **edit** it, **delete** it and **manage** **Rules**. Rules, in turn, can only be **added** and **deleted**. At the top of this page exists a button to open the form required to **Add** a new **Security Group**.

### Floating IPs

The Floating IPs page contains only the floating IP table, where the user can **monitor**, **associate** and **disassociate** IPs from ports. It is also possible to **delete** the floating IP. To **Allocate IPs to Projects** the user should click on the top right button and fill in the respective form.

### IP Availability and Usage Stats

The IP Availability and Usage Stats page allows the user to consult the amount of available and used IPs for the respective project.
