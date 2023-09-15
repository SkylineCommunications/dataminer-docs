---
uid: Connector_help_Generic_Manager_Channel_Distribution
---

# Generic Manager Channel Distribution

This connector comes with a WFM app that should be used as the main user interface.

## About

The connector implements the logic used by the Channel Substitution WFM. It allows the user to perform sets on other elements, and provides a central location to do so.

There are currently two main parts in this connector:

- One to manage Matrix connectors from multiple vendors. This part is not used, and as such also not documented.
- One to manage services managed by Cisco DCM devices.

### Purpose of the connector

The connector detects all redundancy groups based on Cisco DCM elements. These redundancy groups can be added to the element and will then be used by the WFM. In the WFM, it is possible to view a list of services managed by the active DCM element in the redundancy group. However, not all services will be available. Some settings and hard-coded filters limit what services can be displayed.

For each service you will be able to see the backup services and alternate sources. The connector allows you to activate a backup service (or the main service) and will search for the same service on all DCMs in the redundancy group and execute the same set, so that all elements of the redundancy group will end up having the same configuration.

Note: At this time, only redundancy groups with 2 DCMs are supported: one active and one main.

## Installation & Configuration

Create a new element with a unique name. Technically, only one element in the entire DMS is sufficient.

Optionally, on the element's **General** page, set the email addresses and the pagers (separated by a semicolon).

When using the connector with DCM redundancy groups, also add the desired redundancy groups on the **DCM** page by setting the name in the parameter **Add Redundancy Group**.

Note that the available drop-down lists will only be populated after you click the **Refresh** button in the bottom right corner. Also make sure to set the **Group Filter** in the **DCM Redundancy Groups** table. Group filters can be used to define which ports and boards on the DCM can be used to retrieve and show services.

Note: You can optionally override the group filter by specifying a filter in the **DCM Elements** table.

### Installing the WFM

The WFM comes as a separate DLL (SLChannelSubstitutionWfm.dll) and should be provided together with the connector. It must be installed in the same folder as where the protocol is stored (which typically will be the Production version folder), e.g. *C:\Skyline DataMiner\Protocols\Generic Manager Channel Distribution\1.0.0.7\\*

There should be an upgrade package available that will automatically install the DLL on all DMAs. If this is not the case, it may be necessary to do this manually.

### Using the WFM

The WFM can be started from a Visio file by creating a shape with label "Execute" and the following value:

"*Dll\|SLWFMControls\SLChannelSubstitutionWfm/SLChannelSubstitutionWfm.Starter/LaunchWFM/protocol/\[DMA\]/\[EID\]*"

In the above value, \[DMA\] should be replaced with the DataMiner ID from the DMA where the element running this protocol is installed. \[EID\] should be replaced by the element ID from that same element.

The WFM can also be available from the **View** menu as configured in the MenuItems.xml file.

Note: When you open the WFM, a warning message should appear. If it does, check the **I understand and agree** checkbox and click **Next**. (This message cannot be disabled.)

## Usage

### General

This page contains the original logic that is used to manage matrix connectors.

The most important parameters are:

- **Full Email To**: Can be used to send detailed information about sets performed on another element by this element.
- **Short Email To**: Can be used to send a summary of the full email.
- **Pager**: Can be used to send a message to a pager, to inform about a set done by the element.

### DCM

Supported since version 1.0.0.7.

To add or remove redundancy groups in the system, use the **Add Redundancy Group** and **Remove Redundancy Group** parameters. A drop-down list containing all valid options will be available after you click the **Refresh** button at the bottom of the page. The **Remove All** button will remove all entries from the table.

There is a table, **DCM Redundancy Groups**, listing all selected redundancy groups.
For each redundancy group, it shows the name, the description, the group filter and the type of redundancy used. (However, currently only one type of redundancy is supported, i.e. "one on one". With this type of redundancy, the connector assumes that each service on the main has exactly one equivalent service on the backup.) The default value for the group filter used to be *Not implemented,* excluding all ports until otherwise defined, but this has changed to *\*.\** in version 1.0.0.12, including all ports on the targeted devices.

There is also a second table, **DCM Elements**, listing all DCM elements found in the imported redundancy groups.
For each element, the name and the element active status are shown, as well as their role in the redundancy group (primary or backup) and the ID of the redundancy group they belong to. The most important column in this table is the **DCM Filter**, which by default is set to *Inherited.* In most cases, this is fine, but it is possible to have another filter depending on the element in the redundancy group.

Note:

- The columns in the **DCM Elements** table are not updated in real time. To get the current active status, click the **Refresh** button.
- More information about how to write or interpret a filter can be found in the section "Notes".

The **Check Consistency** button provides an important functionality: it will check and if necessary update all the relations between items in the "DCM Elements" table and the "DCM Redundancy Groups" table. When the redundancy groups are edited, these tables could become outdated. This is because for performance reasons the connector does not automatically sync/poll the configuration of the redundancy groups. It is very important that you use this button whenever necessary:

- Whenever you have edited a redundancy group used by this connector, you must click the **Check Consistency** button.
- After you delete a redundancy group, you must also click the **Check Consistency** button. Otherwise, the WFM will no longer function properly!
- If you cannot find an element that you are sure belongs to a registered group, this is the button you should use to fix the issue.

This button will remove items that are no longer in a redundancy group, add new items that have been added to the redundancy group since the last check or since the group was registered, and also update the names of the redundancy groups and elements.

### External Interfaces

This page contains the interface used by the WFM. It can also be used to test if everything works fine.

- To get a list of virtual DCM elements, set something (no matter what) in the field **Refresh DCM List**.

  This will update the data in the **Export Interface: Virtual DCM List**.

- To get the output services from one virtual element, copy the name to the parameter **Get Output Services For**.

  This will update the parameter **Export Interface: Output Service List**.

- To get the backup services for one output service, copy the key of the output service found in the table **Output Service List** to the parameter **Get Backup Services For**.

- To clear all data, click the **Clear WFM Int.** button.

- To activate an alternate source, set the parameter **Activate Alternating Source** with a command containing these parameters, separated by a new line or semicolon:

  - KEY:\[KEY\]

    Key of the backup service as found in the **Backup Service List.**

    Contains dataminer ID, element ID, and full key of an existing backup service. Example: *12\551:1.0.5.3#1.0.1*

  - SERVICENAME:\[NAME\]

    Used in the emails.

  - USERNAME:\[NAME\]

    Used in the emails.

  - DEVICENAME:\[NAME\]

    Used in the emails.

  - MAINSERVICENAME:\[NAME\]

    Used in the emails.

- To activate a backup service, set the **Activate Backup Service** parameter with a command containing some of these parameters, separated by a new line or a semicolon:

  - KEY:\[KEY\]

    Key of the backup service as found in the **Backup Service List**.

    Contains dataminer ID, element ID and full key of an existing backup service. Example: *12\551:1.0.5.3#1.0.1*

  - DERIVED-KEY:\[KEY\]

    Key of the backup service formatted in the same way as in the **Backup Service List**, but using the element ID of the derived/virtual element representing the active element in the redundancy group.

    Note: Cannot be combined with the KEY argument.

    Note: It is possible that the active element changes, and the KEY will point to a wrong value.

  - MASKFOR:\[TIME\]

    \[OPTIONAL\] Valid TimeSpan, example: *00:01:30*

  - SERVICENAME:\[NAME\]

    Used in the emails.

  - ACTION:deactivate

    \[OPTIONAL\] Add only if the main service should be activated instead.

  - USERNAME:\[NAME\]

    Used in the emails.

  - MERGEDSERVICENAME:\[NAME\]

    Used in the emails.

  - MAINSERVICENAME:\[NAME\]

    Used in the emails.

Note: Each set should also result in an update of the **WFM Status** parameter. If something went wrong, the error will be visible there.

### Alarm Suppression

Contains a table displaying all current alarm suppression requests.
This table is filled when a WFM command is received to activate a backup service containing a "MASKFOR" argument. In that case, a line is added containing the backup service identifier and the UTC time when the masking should stop.

To actually make this work, an automation script is required that is triggered by the alarm(s) to mask and then checks whether the alarm actually should be masked or not (based on this table). The automation script is not included with this connector and should be added manually. (For more information, contact Skyline, CVH.)

## Notes

### Group Redundancy Policies

#### One on One

In this configuration, the connector expects that each output service on any of the two elements in the redundancy group will also exist on the other DCM. It also assumes that this identical output service will be found on the same board and port as the original output service.

When a backup service is activated on one element, the connector will search for the same transport stream (based on the IP address) on the backup DCM and for the same output service on that transport stream. If there is only one service on the transport stream, then this service is assumed to be the same as the original service. If there are multiple services on the transport stream, the service with the same name will be selected, or, if this service doesn't exist, an exception will be thrown.

When the services are found, the set will be executed on both DCM elements. Otherwise, an exception is thrown.

#### N + x

In the (currently not yet used) N + x configuration, the system does not assume anything. For each output service there could be 0 or more backup services which will have to be set. To find these services, the system will query another (yet to be developed) connector to get the backup information.

### How filters work

A filter will by default block anything that is not explicitly allowed. A filter can have multiple parts that are separated by a semicolon and result in an OR combination. Filters represent the port keys that are to be included. Port keys are formatted as "\[BOARD\].\[PORT\]" where both boards are one-based and ports are zero-based.

Note: Boards are one-based, because '0' represents the main board (or DCM chassis). By contrast, ports don't have a 'main', so the first port has ID '0'.

#### Special characters

- The dot character '.'

  A dot is used to separate the board and port parts of a key combination. Using multiple dots in one part is not allowed.

  Example: "1.5" means: allow services on board 1 port 5 (which is actually port 6 since it is zero based.)

- The comma character ','

  A comma can be used to select multiple items within the board or port part.

  Example: "1.1,2" selects port 1 and 2 on board 1.

- The semicolon character ';'

  The semicolon can be used to define multiple key combinations separated in an OR manner. This means that if you want to include port 1 and 2 on board one, you could use this filter: "1.1;1.2"

- The colon character ':'

  The colon character can be used to specify a group of numbers.

  Example: "1.1:2" selects port 1 and 2 on board 1 (and is thus completely equivalent to "1.1;1.2" )

- The asterisk character '\*'

  An asterisk can be used to select all numbers, or all numbers from/to X on.

  - Example: "1.\*" selects all ports on board 1.
  - Example: "1.5:\*" selects all ports with ID 5 or more.
  - Example: "1.\*:5" selects port 0, 1, 2, 3, 4 and 5 on board 1.
  - Example: "\*.\*" select all ports on all boards.

- The bracket characters '\[' and '\]'

  Brackets can be used to group several items. They can also help to make filters more readable. Though they have no further functionality, they are also not filtered away during normalization.

  - Example: "1.\[2:5\]" selects port 2, 3, 4 and 5 on board 1
  - Example: "\[1\].\[2\]" selects port 2 on board 1
  - Example: "\[\*\].\[1,2,3,4\],\[10:\*\]" selects port 1, 2, 3, 4, 10 and all ports with ID above 10 on all boards.

#### Normalization

When a filter is edited, the system will normalize the filter so that all illegal characters are removed. This feature can be used to check if a filter is actually updated. It does not necessarily indicate that the filter is completely unambiguous.

- Accepted characters are limited to: 1, 2, 3, 4, 5, 6, 7, 8, 9, ',', ':', ';', '\[', '\]', '.'. All other characters are considered to be illegal.

  Example: "Include board 1. Include port 2" would become "1.2" which is a valid filter and will indeed include port 2 on board 1.

- Special cases such as a dot "." or an empty string "" become respectively "All ports blocked." and "Inherited" if used in the "DCM Elements" table. When used in the redundancy group table, a dot "." becomes "Not Defined."

- Notice that normalized filters result in a real filter when illegal characters are removed. For example:

  - removing illegal characters from "All ports blocked." becomes "." after normalization.
  - "Inherited" becomes an empty string "" and therefore inherits the group filter if used on element level.

#### Ambiguous Filters

Ambiguous filters are filters like "*1.2.3*". This filter, for example, could be interpreted as "include port 2 on board 1", or as "include port 3 on board 2" or maybe even as "include port 2 and 3 on board 1" or any other mix.

These kinds of filters may not be used, since there is no guarantee that they will be parsed in the same way in different versions of the protocol. If the example filter mentioned above would include port 5 on board 6, it would still not be an error, since the filter is badly formatted. There are no safeguards to prevent this kind of situation, so take care when constructing filters.

Other ambiguous filter examples are:

- "*\[1\]:5.1*" : there should be a number before the colon instead of a square bracket.
- "*1,2,:\*.\**" : there should be a number before the colon instead of a comma.
- "*\[1\]\[2\].\[\*\]*" : there should be a comma between a closed and a opened square bracket "\]\[".

Note: A single dot is not an ambiguous filter: ".". This filter means: include not a single port on not a single board. Alternatives are "\*." or ".\*". Do not use an empty string if all ports should be blocked. This would work on group level, but on element level it means that the group filter will be used instead (Inherited).
