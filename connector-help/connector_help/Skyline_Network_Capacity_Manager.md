---
uid: Connector_help_Skyline_Network_Capacity_Manager
---

# Skyline Network Capacity Manager

The **Skyline Network Capacity Manager** is used to simulate the creation of NetInsignt Nimbra services. The goal of this is to make sure in advance that the NetInsight Nimbra network has enough resources (available interfaces, available bandwidth.) to manage the potentially desired new services.

## About

Via **VISUAL** page **'design booking'**, services can be booked. After that, the impact of the booked services will be forwarded to the **NetInsight Nimbra element**. Thanks to that, it's easy to measure the impact of potential new services on a Nimbra setup and to test and determine which is the best path to use for a service.

Via the **NetInsight Nimbra elements**, it's also possible to add virtual modules (ITS/ETS/DTM interfaces modules). Via the **Skyline Network Capacity Manager**, virtual DTM links between virtual DTM interfaces can then be created. This way, it's easy to check if buying a certain type of module would be sufficient to be able to create a certain amount of desired services.

In order to be able to do all of that, an xml file describing the possible NetInsight Nimbra node types and the possible modules needs to be created.

## Installation and configuration

### Creation

The **Skyline Network Capacity Manager** is a **virtual** connector so no communication settings are needed while creating the element. Once the element is created, the **VM - Import Folder** and the **VM - File to Import** parameters needs to be configure to mention where the xml file describing the different NetInsight Nimbra types and modules can be found. Those parameters can be found under the **Configuration.** page button located on the **General** page.

On the **NetInsight Nimbra elements** that need to be taken into account by the **Skyline Network Capacity Manager**, the **Virtual Modules Feature** parameter needs to be enabled. This parameter can be found under the **Configuration.** page button located on the **Virtual Modules** page.

## Usage

General
This page contains the list of NetInsight Nimbra nodes that have been detected. It also contains the **Configuration.** page button under which the location of the xml Nimbra descriptor file can be configured.

DTM Links
This page contains a list of the **physical** and **virtual** **DTM Links** that exist between the different **Nimbra nodes**. By right-clicking on the table, **virtual DTM Links** can be managed.

Booked Services
This page contains a list of booked services together with their channels. By right-clicking on the **Booked Services Table**, **virtual services** can be deleted. In order to add **virtual services**, the **VISUAL** page '**design booking**' needs to be used.
