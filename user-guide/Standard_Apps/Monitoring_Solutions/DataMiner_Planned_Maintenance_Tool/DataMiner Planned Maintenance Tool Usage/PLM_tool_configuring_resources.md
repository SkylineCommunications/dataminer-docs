---
uid: PLM_tool_configuring_resources
---

# Configuring resources

The Planned Maintenance Tool contains two configuration tables that are necessary to validate if the entered resource is a valid entity during the creation operation. The configuration tables for resource validation in the PLM solution must be set up before starting to create PLM activities.

- **Resource Types Table**: Delimits the supported resources.

    - Click “Add Type” to configure a new PLM resource type.

    - The name entered can be anything, but should be descriptive for intuituve use in the subscriber table.

- **Resource Subscribers Table**: Allows the PLM Solution to reference both table and standalone parameters for the specified protocol.

    - Click “Add Resource Subscriber” to configure a new PLM resource subscriber.

    - Choose the type of resource to be used. The list of available types is defined in the Resource Types table on the same page.

    - Enter a Valid Protocol name. This needs to match the Protocol’s name exactly as seen from Cube. This field is case sensitive.

    - Enter a valid Protocol version that is in use. This needs to match the Protocol’s version exactly as seen from Cube.

    - Enter the parameter ID (PID) for the parameter that correlates to the resource being created.

<!-- ![Planned Maintenance App Resource Configuration](~/user-guide/images/DataMiner_Planned_Maintenance_Resource_Configuration.png) -->
