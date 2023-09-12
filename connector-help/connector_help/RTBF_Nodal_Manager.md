---
uid: Connector_help_RTBF_Nodal_Manager
---

# RTBF Nodal Manager

This connector interacts with several **Automation** **scripts** and a **WFM**. It allows you to schedule a series of settings, also called **activities**, that need to be performed at a specific date and time on a system. When an activity is scheduled, the connector checks the availability of resources at the time of the execution.

## About

This is a **virtual** manager connector configured via a custom-built WFM.

Via the WFM, **activities** can be configured as a series of settings, using the available resources in the system. These activities can be scheduled to be executed at a specific time or at recurring times. Depending on the user using the WFM, there can be limitations to the actions that can be performed. The WFM will interact with the connector to configure, save, validate, and schedule the activities. When the time to execute an activity has come, the needed resources will be configured. After the activity, they will be reset.

According to fixed flows, some resources can be double-booked, while others can only be used once at any time.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial range.   | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

The WFM and Automation scripts use pre-defined values or conditions. These need to be configured before any activities can be scheduled.

You can do so via the Config pages:

- **Config Login**

- **Config EBU**

- **Config Events/EVN/SNG**

- **Config Multiviewer**: On this data page, you can change the settings on the multiviewer connected to the nodal manager.

- At present, you can switch between the Barco device and the Imagine Communications Platinum IP3 viewer, using the **Viewer Mode** parameter. Note: this is a level-4 restricted parameter.
  - The **Multiviewer Element Name** parameter determines from where the manager will import its layouts and monitors. The import can be triggered with the **Get Layouts** button. The element ID of the specified element will be retrieved and used to get the data to the manager. This fills the **Layouts** table. Every layout of the element can be found in the Layout column. The monitors can be found in the monitors column, separated by semicolons (";").
  - The **Multiviewer VM Management Table** lists the resources used while on air.
  - The **Fast Uplink Barco Table** defines the "vignette" that can be used when performing a fast uplink action. A fast uplink action is a quick booking creation action that does not require much information. You can add or remove a vignette with the **Multiviewer Uplink Name** and **Delete** **Multiviewer Uplink Name** parameters, using the **Add** and **Delete** button, respectively.

- **Config Spectrum**

- **Maintenance**

## How to use

This connector is mainly used via the **WFM**. Below, you can find more information on the items that are used as input to the **WFM** or **Automation scripts**.

### Resources

Multiple pages of the connector contain information about the resources. All of these need to be configured, either by loading data from CSV resource files or by means of a discovery on the system.

For example, **SDI video resources** are configured by first selecting the **SDI** **Video** **Element** in the system. This will check the number of inputs and outputs. Once this is done, the **resource CSV** of the SDI video can be loaded to populate the **Input** and **Output** **tables** with the details. These will be the **source** and **destination** video items in the WFM. This is similar for audio resources, 34 Mbit-ASI resources and L-band resources.

- **L-Band Resources**: The **L-Band Matrix Element** can be selected on this page. **Source and Destination** tables contain the **inputs** and **outputs** of the L-band matrix. The **ASI Black Input** can also be selected.
- **IRD Resources**: The IRD and DEMOD Resource Table lists all the demodulators and IRDs available for selection to set up actions. When IRDs are selected, the IRD with the **least functionality** is selected first: DVB-S, DVB-S2, DVB-S2 - 16ASPK, NS3, NS4. IRD and DEMOD.
  The **IRD L-Band Ref** contains the reference to the input from the L-band matrix. This is used to select the correct **O.L. Frequency.** Only the IRDs hold the references, the demodulators do not.
- **Booked Resources**: This table lists all demods and IRDs that are in a booked and validated activity.
- **34Mbit-ASI** **Resources:** The **ASI Matrix Element** can be selected on this page. The **ASI in- and outputs** are defined here, and the page shows what they are connected to. The **ASI Black Input** can also be selected.

### EBU Synopsis

It is possible to let the WFM update the **EBU** **synopsis** when there is an activity change, e.g. when an activity is created. On the **Config EBU** page, you need to define where this synopsis command should be sent.

### Offload/Delete

As all of the scheduled items are saved in the connector, it is possible to delete old items or to offload them to a database. Using this last option, it is still possible to retrieve the data via the WFM. The offload and delete options can be found on the **Maintenance page**.

### Available Resources

The **Overview** page displays a summary of the currently available resources for:

- **Audio Processors**
- **Video Processors**
- **IRDs**
- **Temporary Members**
- **Conferences**

## Notes

This connector is part of a planning/scheduling tool, which also includes a **WFM** and multiple **Automation** **scripts**.
