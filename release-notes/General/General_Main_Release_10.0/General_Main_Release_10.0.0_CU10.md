---
uid: General_Main_Release_10.0.0_CU10
---

# General Main Release 10.0.0 CU10

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner Cube - Alarm templates: Hysteresis values can now be lower than the polling interval \[ID 28207\]

In the Alarm template editor, it is possible to configure hysteresis values for a monitored parameter. From now on, you will be able to enter hysteresis values that are lower than the polling interval of the parameter or the protocol. This will allow hysteresis to also work correctly for protocols in which SNMP traps are defined.

> [!NOTE]
>
> - In general, it remains recommended to specify hysteresis values that are greater than the polling interval of the parameter. Only for parameters updated via SNMP traps or smart-serial parameters should you consider specifying hysteresis intervals that are lower than the polling interval.
> - Up to now, when you entered a hysteresis value that was lower than the polling interval, an error message would be displayed. From now on, a warning message will be displayed instead.

#### DataMiner Cube - Data Display: Enhanced performance when loading the default page after opening a card \[ID 28255\]

Due to a number of enhancements, overall performance has increased when loading the default page after opening a card.

#### DataMiner Maps: Style attribute of TableSourceInfo tags will now by default be set 'markers' \[ID 28313\]

In a map configuration file, the style attribute of a TableSourceInfo tag can be set to either “markers” or “lines”.

From now on, if this attribute is not specified, it will by default be set to “markers”.

#### DataMiner Cube - Protocols & Templates: Signed enhanced service protocols \[ID 28338\]

In the Protocol & Templates app, it is now also possible to have signed enhanced service protocols.

#### DataMiner Cube - Services app & Visual Overview: Enhanced performance when refreshing service definition diagrams \[ID 28340\]

Due to a number of enhancements, overall performance has increased when refreshing service definition diagrams, both in the Services app and in Service Manager components embedded in visual overviews.

#### Log level of '!! No link found for ...' errors has been lowered from 0 to 5 \[ID 28353\]

Up to now, when SLElement tried to resolve a relation path in an element, it would throw a “!! No link found for ...” error with log level 0 and log type “Error”. As this error occurs very frequently in case of virtual functions, its log level has now been lowered from 0 to 5.

#### Enhanced performance when updating parameters \[ID 28515\]

Due to a number of enhancements, overall performance has increased when updating parameters.

#### Restricting the size of the C:\\Skyline DataMiner\\Logging\\WatchDog\\Notifications folder \[ID 28548\]

When a runtime error occurs, SLWatchdog stores a number of files in the C:\\Skyline DataMiner\\Logging\\WatchDog\\Notifications folder of the DataMiner Agent.

From now on, additional measures will be taken to prevent this folder from taking too much disk space. For example, files compressed into an errors.zip file will now be removed after the zip file has been created. Also, the oldest files will now be deleted each time the total size of the folder exceeds 1 GB.

#### Enhancements made to BPA test infrastructure and the StandaloneBpaExecutor tool \[ID 28556\]

A number of enhancements have been made to the BPA test infrastructure and the StandaloneBpaExecutor tool.

### Fixes

#### Problem with SLASPConnection when a timeout occurred while retrieving an alarm history \[ID 28163\]

When a timeout occurred while retrieving an alarm history, in some cases, an error could occur in the SLASPConnection process.

#### Secondary element ports would handle headers and trailers incorrectly \[ID 28271\]

When more than one connection were defined, in some cases, the secondary connections would not be able to handle headers and trailers correctly. This was due to the fact that the port cookie of the main port was incorrectly being used for all header and trailer information.

#### Problem when trying to activate data offload to a database \[ID 28276\]

When, in the *Database* section of *System Center*, you clicked the *Offload* tab, selected the *Activate this database* option, and then clicked *Save*, in some cases, this change would not be saved.

#### Problem when offloading data to SLDataGateway \[ID 28318\]

When offloading data to SLDataGateway, in some cases, a CPU leak could occur.

#### SLWatchDog was not able to detect problems occurring in SLSNMPAgent \[ID 28330\]

In some cases, the SLWatchdog process would not be able to detect problems occurring in the SLSNMPAgent process. From now on, SLSNMPAgent will register with SLWatchdog as soon as it is set to running.

#### DataMiner Maps: Problem when the autofit attribute of an OpenStreetMap layer was set to true \[ID 28336\]

When the autofit attribute of an OpenStreetMap layer was set to true, in some cases, automatic marker fitting could fail when the markers were loaded before the map view was fully visible.

#### DataMiner Cube: Clicking the alarm banner did not have any effect \[ID 28339\]

When, in DataMiner Cube, you logged out and then in again, clicking the alarm banner in the header would not have any effect.

The banner shows the number of new alarms, the color of the most severe among them, and service impact information. When you click the banner, the Alarm Console tab should open and the new alarm(s) should be selected.

#### DataMiner Cube: Problem when logging on to an SRM system \[ID 28342\]

When you logged on to a system running Service & Resource Management (SRM), in some cases, an error could occur in DataMiner Cube.

#### Offload database configuration: Problem with OldStyle=true option \[ID 28366\]

In the Db.xml file, you can add the OldStyle=true option to the offload database configuration to revert to the behavior of older DataMiner versions, so that average trend information is offloaded regardless of whether parameter values have changed.

However, in some cases, when this option was specified, unchanged values of type string or discreet would incorrectly not be written to the offload database.

#### DataMiner Cube: Problem with shared folder permissions \[ID 28373\]

The first time a user opens a newly installed DataMiner Cube, a folder structure is created in C:\\ProgramData\\Skyline. Up to now, when another user subsequently opened DataMiner Cube on the same machine, in some cases, that user would not be granted access to certain cache folders, which would cause delays when requests were made to the DataMiner Agent.

#### Child shapes automatically generated for elements in a service would be sorted incorrectly \[ID 28386\]

When child shapes automatically generated for elements in a service were sorted by name using a ChildrenSort data field, in some cases, the shapes would be sorted incorrectly.

From now on, child shapes sorted by name will be sorted by alias or, if no alias is found, by element name.

#### SNMP Managers: Polling IP address can now be added as a custom trap binding \[ID 28391\]

When configuring an SNMP manager, you can now add the polling IP address as a custom trap binding.

#### SLWatchDog would not log error messages when it failed to generate or clear alarm events \[ID 28435\]

When SLWatchDog was creating or clearing alarm events (e.g. alarm events reporting runtime errors), no error messages would be logged when a request to create or clear an alarm event failed. From now on, those errors will be logged in SLWatchDog2.txt.

#### DataMiner Cube - Resources app: Problem when adding, updating or deleting a resource \[ID 28438\]

In some cases, an error could occur when you added, updated or deleted a resource in the Resources app.

#### DataMµiner Cube - Service templates: Templated service incorrectly placed in the root view instead of the view containing the original view \[ID 28491\]

When you duplicated a service as a templated service, in some cases, the newly created templated service would incorrectly be placed in the root view instead of the view containing the original service.

#### DataMiner Cube - Query Executor: Problem when a Cassandra database returned a collection object \[ID 28499\]

When, in DataMiner Cube’s Query Executor, you launched a query that retrieved data from a Cassandra database, in some cases, an incorrect result would be displayed when the query returned a collection object.

#### Problem when updating DVE protocols \[ID 28561\]

When an existing DVE protocol was updated, in some cases, the update would fail.

#### DataMiner Cube - Profiles app: Production versions not listed in protocol list when adding a profile parameter \[ID 28687\]

When, in the Profiles app, you added a profile parameter, in some cases, the list of available protocols would incorrectly not list production versions.
