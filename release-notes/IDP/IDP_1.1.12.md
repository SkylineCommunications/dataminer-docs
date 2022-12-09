---
uid: IDP_1.1.12
---

# IDP 1.1.12

## New features

#### Process Automation: Discover Data Sources activity \[ID_24019\]\[ID_27581\]

To allow users to discover elements with IDP using Process Automation, IDP now supports the *SLC IDP Discover Data Sources* activity. To support this, a number of changes have been implemented in the *Skyline IDP Discovery* driver and a new “Profile Load” script *IDP_Discovery_Actions_Start* is available.

The script accepts the parameters *Info*, *ProfileInstance* and *ProcessInfo*. When it receives a request message, the script will check the scan range specified in the profile instance and then send a request to the *DataMiner IDP Discovery* element to start new discovery. When new devices are found, the *DataMiner IDP Discovery* element will send one or more response messages to the script, depending on the number of discovered devices and on the IDP Discovery configuration. For each discovered device, the response includes the CI type and the device IP address. The script will process the response and generate a volatile profile instance for each discovered device.

On the *Settings* data page of the *DataMiner IDP Discovery* element, the *Max Devices per Token* setting allows you to customize how many devices can be included in a response.

#### Process Automation: Provision Element activity \[ID_26019\]

To allow users to provision elements with IDP using Process Automation, IDP now supports the *SLC IDP Provision Element* activity. A number of changes have also been implemented in the *Skyline Generic Provisioning* driver and a new “Profile Load” script *IDP_Provisioning_CreateElement* is available.

The script accepts the parameters *Info*, *ProfileInstance* and *ProcessInfo*. It can receive several types of messages and behaves as follows for each type:

- Request: The script will receive this message from the token handler script and will read all node and process profile instances to generate the request message to send to the *DataMiner IDP Provisioning* element. This element will in turn use the request message to perform the element creation.

- Partial response: The script will receive this message from the *DataMiner IDP Provisioning* element when it has completed part of its task and already sends back results for each created element. For elements that could not be created, it returns the DMA and element ID "-1/-1". For each result, the script will create a profile instance with indication of the new element ID and pass the profile instance to the token handler script in order to create new tokens.

- Response: The behavior in this case is similar to that for a partial response, except that the token handler script is also notified that all operations related to the original request have been concluded.

The *SLC_ProvisionElement_Result* gateway key contains the status of the provisioning operation: *Success* if the element was successfully provisioned, and *Fail* if it was not provisioned.

#### Token metadata can replace CI type field values in Provision Element activity \[ID_26799\]

When provisioning is done via Process Automation, the token can contain metadata that can replace the CI type fields. For this to work, the name of the metadata must consist of the *IDP\_* prefix followed by the relevant JSON object from the CI type. For example, to overwrite the element description from the CI type, use the metadata name *IDP\_$.Provisioning.Configuration.Description* and place the new element description in the metadata value. If the metadata value contains special characters, e.g. double quotation marks, place a backslash in front of these to make sure they are not misinterpreted (e.g. \[*\\"Test\\", \\"Test 123\\"\]*).

Other examples:

- Providing a custom keyword (only “IPAddress” is currently supported):

  - Metadata name: *IDP_IPAddress*
  - Metadata value: “10.10.10.10”

- Providing a keyword to override an integer:

  - Metadata name: *IDP\_$.Provisioning.Configuration.TimeoutTime*
  - Metadata value: “2500”

- Providing a keyword to override a string:

  - Metadata name: *IDP\_$.Provisioning.Configuration.Description*
  - Metadata value: "This is a test of keywords."

- Providing a keyword to override the value of a property:

  - Metadata name: *IDP\_$.Provisioning.Configuration.Properties\[?(@.Name == 'MyProperty2')\].Value*
  - Metadata value: "MyNewPropertyValue"

- Providing a keyword to override the first item in a string array (not adding, only updating):

  - Metadata name: *IDP\_$.Provisioning.ViewName\[0\]*
  - Metadata value: "newViewName"

- Providing a keyword to override a string array:

  - Metadata name: *IDP\_$.Provisioning.ViewName*
  - Metadata value: "\[\\"Test\\", \\"Test 123\\"\]"

- Providing a keyword to override the GetCommunity string of the first connection:

  - Metadata name: *IDP\_$.Provisioning.Configuration.Ports\[0\].DMAElementSnmpPortInfo\[0\].GetCommunity*
  - Metadata value: "customGetCommunity"

#### Process Automation: Reapply CI Type activity \[ID_26950\]

To allow users to reapply a CI type to an element using Process Automation, IDP now supports the *SLC IDP Reapply CI Type* activity. The “Profile Load” script *IDP_Provisioning_ReapplyCIType* will receive a request from Process Automation, process it and send a request to the provisioning element to reapply the CI type. When the CI type has been reapplied to the selected elements, a token will be generated with the received response.

The following fields will be reapplied:

- Element name
- Element description
- Initial alarm template
- Initial trend template
- Initial port info
- Password setup
- Default element state

In addition, the element for which the CI type is reapplied will be removed from views that are not present in the CI type, and the update property script will run.

The *SLC_ReapplyCIType_Result* gateway contains the status of the reapply operation: *Success* if the CI type was successfully reapplied for all elements, and *Fail* if it was not reapplied.

#### Process Automation: Reassign CI Type activity \[ID_26951\]

To allow users to reassign a CI type for an element using Process Automation, IDP now supports the *SLC IDP Reassign CI Type* activity. The script *IDP_Provisioning_ReassignCIType* will receive a request from Process Automation, process it and send a request to the provisioning element to reassign the CI type. When the CI type has been reassigned to the selected elements, a token will be generated with the received response.

The following fields will be reassigned:

- Element name
- Element description
- Initial alarm template
- Initial trend template
- Initial port info
- Password setup
- Default element state

In addition, the element for which the CI type is reassigned will be removed from views that are not present in the new CI type, and the update property script will run.

The *SLC_ReassignCIType_Result* gateway key contains the current status of the reassign operation: *Success* if the CI type was successfully reassigned for all elements, *Fail* if it was not reassigned, and *PartialSuccess* if it was only reassigned for some of the elements.

#### Process Automation: Delete Element activity \[ID_27525\]

To allow users to delete a managed element using Process Automation, IDP now supports the *SLC IDP Delete Element* activity.

The *SLC_DeleteElement_Result* gateway key contains the current status of the activity: *Success* if all elements were deleted, *Fail* if none of the elements were deleted, and *PartialSuccess* if only some of the elements were deleted.

#### Process Automation configuration in setup wizard \[ID_27664\]

The IDP setup wizard now allows you to configure and set up the Skyline Booking Manager for use with IDP in the context of Process Automation, so that SRM objects can be created for IDP activities.

#### Process Automation Activity wizard \[ID_26308\]\[ID_27967\]\[ID_28623\]\[ID_28776\]\[ID_28896\]

When you want to create or schedule new processes, you can now click *New* on the *Processes* > *Schedules* tab of the IDP app. This will launch the Process Automation wizard. This is a custom script that allows users to configure a process in a streamlined way. However, note that this is only available if DataMiner Process Automation has been installed in your DataMiner System.

The wizard consists of three steps:

- In the first step, you need to specify:

  - The process name.
  - The activation window type: Single event or a permanent service.
  - The activation window: The start time, as well as the stop time or duration in case of a single event.

- In the second step, you need to specify if the process should be executed once or repeated, and you need to specify the activities in the process and their profile instances and resources:

  - Select an existing process to schedule it again or create a custom process.
  - In the *Start* drop-down box, select whether the process should be executed once (“Instant”) or repeated at regular intervals (“Timer”). If you select *Timer*, you will need to specify a profile and interval for the timer. Note that this drop-down box is only available if a repeat gateway is available in the DMS. If no repeat gateway is available, the process will always be executed once.
  - If you are creating a custom process, click the *Add* *Activity button* to add an activity to the process. You can use the *Delete Activity* button to remove the last activity you have added.
  - For each activity you add, select which activity should be executed. The available choices depend on the preceding activity in the process.
  - For each activity, select a profile and resource if necessary.
  - When you have selected a profile for an activity, and there are no mandatory profile parameters without a value, a *Show Details* label is displayed next to the arrow button below the profile. Click the arrow button to view and change the profile parameter values according to your preference. If there are mandatory profile parameters without a value, a *Show All* label is displayed instead, and you will need to make sure a value is assigned to these before you can continue to the next step of the wizard.
  - In the drop-down list with resources you can select for an activity, both pool resources and regular resources are displayed. Regular resources that belong to a pool resource are displayed beneath that pool resource. If there is one resource pool and all regular resources for the activity belong to it, the resource pool is automatically selected. If there are no resource pools, and only one regular resource, that resource is automatically selected.

- In the final step, you need to select the starting profile instance, as well as the token profile instance and resource:

  - Select the profile instance that should be used for the first activity of the process. For example, if the first activity is a discovery activity, you must select the profile that will determine the scan range for this activity.
  - The token selection is displayed below the start profile selection. If there is one profile instance, that profile is automatically selected. If there are multiple profiles instances, the profile instance with the name *Token Default Instance* is automatically selected. Selecting or customizing a token profile in this step allows you to fine-tune the way the token will be handled by Process Automation. You can for instance indicate the priority for the token and the duration it should be allowed to stay in the queue.
  - If it is possible to select a profile instance and resource automatically, the token section is collapsed.
  - When the necessary configuration is done, click *Create* to create the process. The scheduled process will be added to the timeline on the *Processes* > *Schedules* tab and executed at the specified time.

When you select a custom option in the wizard and you start from a blank profile instance, all options will be blank too. If you start from a previously configured state (profile, activity, etc.) and select a custom option, all previously configured options will remain, and it will be possible to then customize those options. Regardless of whether you are using an existing option or a custom option, the wizard will validate mandatory parameters. Using an existing option provides preconfigured values, while custom options require manual configuration.

The Process Automation wizard can work both with profile instances configured in the Profiles and with volatile profile instances, which will not be visible to the user when the process runs.

#### Process Automation: Update Software Image activity \[ID_28064\]

To allow users to schedule software updates using Process Automation, IDP now supports the *SLC IDP Update Software Image* activity. No parameters need to be specified for the node profile definition of this activity, but an input interface is required that specifies the elements for which a software update should occur (possible values: Element ID, Element Name, Element Property, IP Address, IP Address List, IP Address Range, and View).

When the activity starts, it runs the "Software update script" configured in the CI type for each element in the input interface. If the activity is successful, a success response with *SLC_UpdateSoftwareImage_Result* gateway key is sent with the value *Success*. If the activity fails, the same gateway key is sent with the value *Fail*.

#### Process Automation: Activities loaded based on virtual platform \[ID_28204\]

In the Process Automation wizard, the list of allowed activities can be dynamically loaded based on the virtual platform configured in the Booking Manager. For this purpose, the list of activities must be provided in a JSON file with the same name as the virtual platform. This file must be located in the *DMA_COMMON_DOCUMENTS\\SRM* subfolder of the DataMiner Documents folder. Such a file will be included with IDP out of the box.

You can find an example of this JSON configuration below.

```json
{
    "Activities": {
        "Ids": [
         "dc57a80d-cff7-48a8-bbc3-d76874e99143",
         "a2101670-07c2-4980-84bd-bdc0050beabd",
         "0712be17-57c6-41f0-bcdf-a9e8e354e881",
         "03a6481a-9439-4ddd-b227-46b43b6a9350",
         "4ba40aed-0369-4981-bdea-b87cb0e8cb2f",
         "26fbee5c-48db-494d-af89-51495320e60f",
         "8eb36541-d98e-41d4-b6ae-0fd6ef7bc36e",
      ]
    }
}
```

#### Process Automation: Auto Rack Assign Position activity \[ID_28308\]

To allow users to schedule an automatic rack assignment using Process Automation, IDP now supports the *SLC IDP Auto Rack Assign Position* activity. This activity requires an input interface that specifies the elements for which the automatic rack assignment should occur (possible values: Element ID, Element Name, Element Property, IP Address, IP Address List, IP Address Range, and View).

When the activity starts, it runs the "Rack assignment script" configured in the CI type for each element in the input interface. If the activity is successful, a success response with *SLC_AutoAssignRackPosition* gateway key is sent with the value *Success*. If the activity fails, the same gateway key is sent with the value *Fail*.

#### Configuration Management: Configuration update on multiple elements with any configuration backup from the DataMiner Configuration Archive \[ID_28419\]

The IDP app now has a new *Configuration* > *Update* tab, where you can select a configuration backup file and apply it to multiple selected elements. The backup file is then copied from the DataMiner Configuration Archive to the working directory on the DMAs hosting the selected elements. IDP will then execute the "Configuration Update Script" configured in the CI type on the hosting DMAs and inform them of the local path to the file. The script will access the file and execute the necessary actions to update the configuration of the elements.

For this purpose, for each DMA in the DMS, a working directory must be available, and the IDP API account must have access to the shared location. This can be configured on the *Admin* > *Configuration* > *Network Shares* page.

The following other changes have also been implemented:

- On the *Processes* > *Automation* page, *Restore Default* has been renamed to *Configuration Update*.
- On the *Admin* > *CI Types* > *Configuration* page, *Completeness Default* has been renamed to *Completeness Update*, *Default script* has been renamed to *Update script*, and *Default Directory* has been renamed to *Default Update File*.

#### IDP setup wizard now allows configuration with predefined values and unattended running \[ID_28645\]

The IDP setup wizard can now be configured with predefined values or even executed without any user interaction. This is possible using the new *SetupWizardInputData* object in the namespace *Skyline.DataMiner.DataMinerSolutions.IDP.SetupWizard.Silent*.

The following things can be configured with this object:

- The script title and the title of each step (if it is shown)
- Whether a step should be executed automatically or shown in the UI.
- The IDP view configuration:

  - Whether views should be moved under the top view.
  - The top view name.
  - The applications view name.
  - The devices view name.
  - The infrastructure view name.

- The username and/or password to be used.
- Extra configuration options:

  - Whether a configuration group should be expanded or collapsed in the *Extra Configuration* step.
  - Whether the Activity Scheduler should be used.
  - The Provisioning API binding address and binding address port.
  - Whether HTTP or HTTPS need to be used for the Provisioning API, and in case the latter is used, the HTTPS certificate.
  - The archive path and user for the Configuration Manager

If invalid or incompatible data are configured for a screen that is set to be executed without user interaction, the setup wizard will fail. If the wizard is run with user interaction and an error is detected in a configuration group of the *Extra Configuration* step, that group will automatically be expanded.

#### Admin \> Configuration \> Network Shares page renamed and adapted \[ID_28865\]

The *Admin* > *Configuration* > *Network Share* page of the IDP app has been renamed to *Network Shares* and now contains a list of the working directories on the network shares.

This list allows users to specify a working directory to transfer the configuration file to for each hosting DMA. Working directories temporarily contain configuration backups during a configuration update. A working directory must be available for each DMA in the DMS. The IDP API account needs to have access to the shared location.

In addition, the *Archive Settings* title at the top of the page has been changed to *DataMiner Configuration Archive*.

#### Refresh Agents button on Admin \> Provisioning page \[ID_28871\]

On the *Admin* > *Provisioning* page of the IDP app, a *Refresh Agents* option is available, which allows you to manually refresh the list of DMAs for which you can configure IP ranges and from which you can select a DMA to be the Fallback Agent.

#### Selection of provisioning DMA \[ID_28997\]

It is now possible to select on which DMA an element will be provisioned. After you run a discovery, on the *Inventory* > *Discovered* tab, you can now select the DMA name.

IDP will also automatically suggest a DMA name. To do so, it will check for a configured DMA in the CI type. In case a DMA should be determined based on device address, IDP will check the configured IP ranges (on the *Admin* > *Provisioning* tab) to find a matching DMA. If no match is found, the Fallback Agent will be suggested.

## Changes

### Fixes

#### Exception when long file paths were used in IDP configuration \[ID_28674\]

When a file path length was longer than 260 characters, or longer than 240 characters in case of a directory path, it could occur that the IDP configuration throw an exception.

#### Overlapping text in CI type management UI \[ID_28728\]

When you deleted or duplicated a CI type, it could occur that some text overlapped in the UI.

#### Problem accessing temporary configuration backup files \[ID_28803\]

Previously, when a configuration backup was executed, IDP temporarily stored the files in the *Windows\\TEMP* folder and then moved them to a share location. However, in some cases this could cause issues when users were unable to connect to the *Windows\\TEMP* folder, so files will now be immediately transferred to the share location instead.

#### Incompatibility with DataMiner 10.1.1 or higher \[ID_28826\]

If the IDP app was used with DataMiner version 10.1.1 or higher, run-time errors could occur. IDP has now been optimized to be fully compatible with the changes introduced in DataMiner 10.1.1.
