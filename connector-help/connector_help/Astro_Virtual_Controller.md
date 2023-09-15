---
uid: Connector_help_Astro_Virtual_Controller
---

# Astro Virtual Controller

With this connector, it is possible to manage the following Astro connectors: **Astro U116 Edge PAL**, **Astro U125 Edge FM**, **Astro U158 Edge QAM** and **Astro U168 Edge DVB-T**.

## About

This is a virtual connector that can be used to manage the Astro Edge modules.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration

The connector will determine which modules must be controlled based on the **element** **names**.

For a module to be recognized as to be controlled by this connector, its name must start with the controller name.

## Usage

### General Page

This page allows you to specify the **Physical Location**, **Assigned Name** and **Contact Person**.

These parameters are merely intended by way of information and will not affect the managed modules.

### Modules Page

This page displays the **Modules Table**, which contains information on each of the detected modules.

In this table, you can set the redundancy type of a module (*Main* or *Backup*). You can also manually trigger a switchover by pressing the **Switch** button.

Finally, the page also contains a page button, **Redundancy Settings**, that allows you to configure the redundancy procedure.

### IP To RF Summary Page

This page displays the **IP To RF Summary Table**, which contains information on every RF output interface of the managed modules.

In the table, you can set the network segment for each RF output.

Via the **Network Segment** page button, you can also add or delete network segments.

To add a network segment, right-click the table, select **Add** and specify the network segment name.

To delete one or more network segments, select the desired row(s), right-click and select the option **Delete Selected Row(s)**.

### RF To IP Summary Page

This page displays the **RF To IP Summary Table**, which contains information on every IP output interface of the managed modules.

### Firmware Update Page

On this page, the **Firmware Update Schedule Table** lists all the scheduled firmware updates.

To schedule a new firmware update, right-click the table and click **Launch new schedule wizard**. This will open a pop-up window where updates can be scheduled.

Note that the Automation scripts "Astro Firmware Update Wizard" and "Astro Firmware Update Execute" must be present in the DMS to be able to launch the wizard.

### Module Configuration Page

This page allows you to configure settings for each of the managed modules.

Note: Setting a parameter on this page will set the parameter with the same name on the controller.
