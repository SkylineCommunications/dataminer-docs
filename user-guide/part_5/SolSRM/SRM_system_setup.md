---
uid: SRM_system_setup
---

## SRM system setup

Once the SRM Framework has been installed, several actions are necessary to provision the system:

1. Make sure the necessary elements are created representing the devices in the system. See [Adding and deleting elements](xref:Adding_and_deleting_elements).

2. Create profile definitions consisting of parameters linked to specific virtual functions, and profile instances that determine the values assigned to these parameters in particular configurations. Also make sure to define capacities and capabilities, as the profile instances will not only be used to configure a function but also to select a function (resource) matching the capacity and capability requirements. See [The Profiles module](xref:The_Profiles_module).

    For example, for a Demodulator function, the profile definition could contain the following parameters:

    - *Frequency* (category: *Configuration*)

    - *Symbol Rate* (category: *Configuration*)

    - *Modulation* (category: *Capability*)

3. For each profile definition, create the “Profile-Load” Automation script that should be used to configure the corresponding virtual function during various booking events. To do so, you can start from the *SRM_ProfileLoadScriptTemplate* script, which is included in the installation package. This script will use a profile instance as input argument and will configure a function based on the content of this instance.

4. Add each “Profile-Load” script to the profile definition for the corresponding virtual function. See [Configuring profile definitions](xref:Configuring_profile_definitions).

5. Upload the necessary function.xml files in order to define specific virtual functions of devices. See [Functions XML files](xref:Functions_XML_files).

6. Provision the necessary resources, representing functions as resources that can be used in the system. This can be done manually (see [Configuring pools of resources](xref:Configuring_pools_of_resources)) or using the script *SRM_DiscoverResources* (included in the SRM package).

    During or after resources provisioning:

    - Add the *ResourceInputInterfaces* capability to the resources and set its value to the name of the available input interfaces of the corresponding function.

    - Add the *ResourceOutputInterfaces* capability to the resources and set its value to the name of the available output interface of the corresponding function.

    - Assign any additional capacities or capabilities required to select the resource.

    - Include resources in one or more pools. The name of each pool should start with the Virtual Platform identifier, followed by a period, e.g. *VPA.Decoder*.

    For more information see [The Resources module](xref:The_Resources_module) and [The Profiles module](xref:The_Profiles_module).

7. Combine the configured virtual functions in service definitions to describe the flow of the different functions in bookings. See [The Services module](xref:The_Services_module).

    This includes:

    - Adding a unique label for each node of the service definition.

    - Creating an LSO (Life cycle Service Orchestration) script based on the *SRM_LSOTemplate* script included in the package. The purpose of this script is to orchestrate the configuration of the resources during various events of the booking.

    - Adding an action for each expected service state (on the *Actions* tab page of the service definition) and linking it to the LSO script.

    - Adding a *Virtual Platform* property and setting its value to the Virtual Platform identifier.

    - Optionally, creating a DTR script to implement Data Transfer Rules and referring to it in the *Data Transfer Rules configuration* property of the service definition.

    - Optionally, adding a *Contributing Config* property if the booking will need to be converted into a contributing booking and generate a resource.

    - Optionally, adding extra properties to support additional features.
