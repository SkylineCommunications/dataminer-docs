---
uid: Connector_help_Miranda_RCP-200
---

# Miranda RCP-200

This connector can be used as a remote controller for Miranda RCP-200 devices.

## About

The objective is to control DMA elements, using the RCP-200 keyboards. DMA acts as a gateway:

- Provide some parameter values from elements
- Change parameters of elements, based on requests sent by RCP-200

DMA is responsible for providing all the information to be displayed on the RCP-200 buttons:

- String ( HTML formatted )
- Background Color
- Text Color

Also, the layout is dynamic. This means that the parameters displayed on the keyboard could change , depending on which button the user clicks on. This is the case when parameters are on different pages.

CSV files can be used to provision the data (devices, pages, buttons) in the element.

### API

The RCP-200 devices can interact with the DMA using a REST API, with the DMA element acting as the server. All data is transferred in **JSON** format.

One single method is available to indicate which button on which page the user clicks on. The API replies with a response containing the complete design of the requested page.

Request URI: http://\<DMAIP\>:\<PORT\>/restapi/SetParameter?panelIp=\<Panel IP\>&page=\<Device Page\>&buttonID=\<Button ID\>

- Panel IP: IP address of the keyboard generating the command
- Device Page: Page reference. If emtpy the default page (home page) will be returned
- Button ID: button the user clicks on. Range depends of the configuration of the keyboard (default 1 -\> 24). If empty, this will be considered as a page refresh.

Response:

- Device page: name of the returned page. Note that, when receiving a request from the device or when sending a response to it, the page name could potentially contain the reference of the selected device. This device reference will be used to know from wich element the parameter value should be retrieved from.
- Description of the buttons (id, value, background color, text color)

## Installation and configuration

### Creation

***Virtual connection***
This connector uses a virtual connection and does not need any user information.

### Configuration

After creating an **element** of this **procotol**, some default settings are applied. To change these settings, see "Settings page".

## Usage

### General

Displays the **status** and **URI** of the API service.

### Simulation

Contains controls to easily simulate the generation of a keyboard page and interact with it. Same code as the one used to reply the the RCP-200 is used.

### Devices

Table containing the list of elements for which DMA needs to act as a gateway for RCP-200.

Some controls are present to select a connector from a dropdown list. And then, from a second dropdown list, to select one of the elements using that connector and add it to the table.

### Pages

Table defining the design of each page, meaning the position of each button group on the keyboard.

Columns:

- **Page Reference:** Name of the page
- **Button Group Reference:** Reference to the button group to display on this page
- **X Position** and **Y Position** columns contains the absolute position of the button group on the page.
- **Device Required**: indicates if the device reference should be added to the page name in the response.

### Buttons

Table defining groups of buttons to be displayed on the keyboard pages.

Columns:

- **Button Group Reference:** Name of the button group in which this button should be placed
- **X Position** and **Y Position** columns contains the relative position of the button in the group.
- **Type**: Title / Page Link / Element Reference / Parameter Value / Parameter Update
- **Element Reference**: \[optional\] A reference to a row in the **Devices table**. Only applicable when Type is 'Element Reference'. Links the page to a specific device.
- **Parameter Id**: \[optional\] only applicable when Type is 'Parameter Value' or 'Parameter Update'. Format: '\<parameter id\>' or '\<parameter id\>/\<key\>'
- **Parameter Value**: \[optional\] only applicable when Type is 'Parameter Update'
- **Page Link**: \[optional\] used to navigate to another page
- **Title**: \[optional\] text to show on the button
- **Background Color**: \[optional\] override the default background color. See 'Notes' section for the available options.
- **Text Color**: \[optional\] override the default text color. See 'Notes' section for the available options.
- **Format**: extra formatting, see 'Notes' section

### Import/Export

Provides the functionallity to import/export CSV files to provision devices, pages and buttons.

Import:

- First click on the **Refresh** button, to load the list with available elements on the DMA
- Choose the correct file in one of the dropdown parameters, and do the set.
- The CSV file is loaded in the element.

Export:

- Fill in a name for the export. The name will be the first part of the filename.
- Click on the **Export** button. Existing files will be overwritten.
- The exported files can be found in the documents folder of the protocol.

The status parameters indicate whether or not the import was successful.

### Configuration

Contains some controls to define the settings that are used by the API.

- **Number of Rows:** default 3
- **Number of Columns:** default 8
- **Default Page:** page to return when no page is specified in the request
- **Default Background Color:** button color when not overridden in the **Buttons Table**
- **Default Text Color:** button color when not overridden in the **Buttons Table**
- **Default Set Timout:** Default time to wait until a parameter set succeeded
- **REST API Port**: TCP port where the REST API will be running on

## Notes

### Special text formatting

The **Format** column on a button can be used to specify some optional conditions. Multiple pipe-separated conditions can be added.

- *PAGE:DeviceSelection2Page:\<b\>\*\</b\>*: In case the page that will be generated is 'DeviceSelection2Page', the text will be surrounded by '\<b\>' and '\</b\>'.

- MAPVALUE:1=OK;2=Loss : Allows to change the value of a parameter, to another value

### Special color formatting

In the color parameters it's possible to specify special options that could be used for conditional coloring.

- *ALARM*: returns the color that matches the alarm severity of the parameter linked to this button

- *VALUE:1=FF1111;2=FF2222*: use color 'FF1111' when the value of the parameter is 1, use color 'FF2222' when the value of the parameter is 2
