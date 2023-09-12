---
uid: Connector_help_Skyline_IP_Network_Manager
---

Skyline IP Network Manager

## About

Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus fermentum tortor ipsum, eu ultrices risus interdum non. Nullam feugiat mauris at mi convallis vehicula. Cras ac magna felis. Curabitur dictum enim a metus vehicula dictum. Interdum et malesuada fames ac ante ipsum primis in faucibus. In scelerisque ipsum id egestas varius. Donec interdum neque bibendum dui tempus, eget vehicula erat pretium. Integer malesuada ornare eros ac malesuada.

Vestibulum vehicula vehicula justo, eleifend rhoncus diam porttitor sit amet. Nunc feugiat, augue quis interdum laoreet, mauris ipsum consectetur nisi, eget consectetur sapien justo ut nulla. Quisque vitae mi eu urna dictum viverra. Curabitur dictum volutpat dui ullamcorper venenatis. Nulla aliquet lacus sapien, vitae sodales libero commodo nec. Morbi velit massa, sagittis nec ligula eu, vestibulum tincidunt dui. Duis ut est sit amet nisi porta pellentesque. Curabitur non sollicitudin leo. Aliquam condimentum mollis eleifend. Nulla venenatis, nisl non hendrerit tincidunt, turpis velit bibendum mauris, ut rhoncus magna nibh eget augue. Donec auctor nibh vitae metus adipiscing, quis tempor neque sodales. Aliquam erat volutpat. Ut pharetra rhoncus orci, id aliquet ante dictum vel. Vestibulum condimentum, massa eget blandit egestas, lectus libero tristique nibh, at pretium nunc massa eu felis. Vivamus at diam vel est rhoncus tincidunt a vel turpis. Suspendisse potenti.

## Installation and Configuration

Installation

#### System Requirements

In order to use the IP Network Manager, you will need at least DataMiner version 8.0.3.

#### Set-Up

Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus fermentum tortor ipsum, eu ultrices risus interdum non. Nullam feugiat mauris at mi convallis vehicula. Cras ac magna felis. Curabitur dictum enim a metus vehicula dictum. Interdum et malesuada fames ac ante ipsum primis in faucibus. In scelerisque ipsum id egestas varius. Donec interdum neque bibendum dui tempus, eget vehicula erat pretium. Integer malesuada ornare eros ac malesuada.

Configuration

Initally, the application will not hold any devices to manage. Therefor, it's necessary to perform a discovery before you can start using the IP Network Manager. The application has a **Discovery** **Wizard**, which is explained in in [Device Discovery](#Device%20Discovery).

![IPNetworkManager_Flow.png](~/connector-help/images/Skyline_IP_Network_Manager_IPNetworkManager_Flow.png)

## Usage

You should use DataMiner Cube to use the IP Network Manager Application. After launching Cube, click in the navigation on **start** and choose **Apps**. Click on **IP Network Manager** to open the application.

Map

After opening the application for the first time, the **map** page will be empty. In order to start working with the IP Network Manager, a discovery is needed to populate the application with devices. This is explained in [Device Discovery](#Device%20Discovery).

The map page shows the network devices that the application is managing. A icon is used to represent a device.

>
>
> |                                                                                                                                            |                 |
> |--------------------------------------------------------------------------------------------------------------------------------------------|-----------------|
> | **Icon**                                                                                                                                   | **Device Type** |
> | ![IPNetworkManager_IconServerLinked.png](~/connector-help/images/Skyline_IP_Network_Manager_IPNetworkManager_IconServerLinked.png) | Server          |
> | Router                                                                                                                                     |                 |
> | Switch                                                                                                                                     |                 |
> | Unknown                                                                                                                                    |                 |

Network

Go to this page to get a overview of the managed devices.

#### List

The subpage **List** shows the devices which are managed by the application. Specificially, the table contains the following columns:

- **IP** the IP address by which the device is managed
- **DNS/NetBIOS Name** a textual representation by which the device is identified.
- **Device Type** the type that the application has classified the devices in to. You manually override the device type.
- **sysDescr** the system description as found on the device
- **Network/Prefix** the network address and network mask (in prefix notation) of the IP address from the IP column
- **Discovery Status** the status of the last discovery.
- **LInked Element** the element name of the DataMiner element linked to this device.

Additionally, there are number of options available in the **context menu**. You can right-click on a row to select the following:

> <table>
> <colgroup>
> <col style="width: 50%" />
> <col style="width: 50%" />
> </colgroup>
> <tbody>
> <tr class="odd">
> <td><strong>Option</strong></td>
> <td><strong>Explanation</strong></td>
> </tr>
> <tr class="even">
> <td>Create Element</td>
> <td>This will allow you to create a DataMiner element from a discovered device. After selectin this option a pop-up will allow you to supply the following information for the element your creating:
> <ul>
> <li><strong>Element Name</strong> the name for the element</li>
> <li><strong>Polling IP</strong> the IP address</li>
> <li><strong>Protocol</strong> the DataMiner protocol that should be used. Note that the production version will be used automatically.</li>
> </ul></td>
> </tr>
> <tr class="odd">
> <td>Link Element</td>
> <td></td>
> </tr>
> <tr class="even">
> <td>Unlink Element (permanently)</td>
> <td></td>
> </tr>
> <tr class="odd">
> <td>Unlink Element (temporary)</td>
> <td></td>
> </tr>
> <tr class="even">
> <td>Delete Selected</td>
> <td></td>
> </tr>
> <tr class="odd">
> <td>Other...</td>
> <td></td>
> </tr>
> </tbody>
> </table>

These are the same options as with the subpage discovery//elements. How to approach this?

#### Subnet

The subpage **Subnet** shows the device in a tree structure, grouped by IP network.

#### Type

The subpage **Type** shows the device in a tree structure, grouped by device type.

Device Monitoring

Go to this page to verify and set-up the device monitoring. Note that this does not require the devices to be linked to elements.

#### List

The subpage **List** shows the devices which are managed by the application. The table contains the results of the monitoring tests which were currently running. More specifically, the following columns are available:

- **IP** the IP address by which the device is managed
- **DNS/NetBIOS Name** a textual representation by which the device is identified.
- **Device Type** the type that the application has classified the devices in to. You manually override the device type.
- Ping Status
- FTP Status
- SMTP Status
- DNS Status
- HTTP Status
- Database Status
- TCP Status
- RTSP Status
- RTMP Status
- TFTP Status

In order to enable a monitoring test for a specific device, a number of options are available in the context menu. You can right-click on a row to select the following:

> <table>
> <colgroup>
> <col style="width: 50%" />
> <col style="width: 50%" />
> </colgroup>
> <tbody>
> <tr class="odd">
> <td><strong>Option</strong></td>
> <td><blockquote>
> <strong>Explanation</strong>
> </blockquote></td>
> </tr>
> <tr class="even">
> <td>Enable/Disable Ping Test</td>
> <td><blockquote>
> Enables or disables the Ping test with the default settings.
> </blockquote></td>
> </tr>
> <tr class="odd">
> <td>Enable/Disable TCP Test</td>
> <td><blockquote>
> Enables or disables the TCP test with the default settings.
> </blockquote></td>
> </tr>
> <tr class="even">
> <td>Enable/Disable Database Test</td>
> <td><blockquote>
> Enables or disables the Database test with the default settings.
> </blockquote></td>
> </tr>
> <tr class="odd">
> <td>Enable/Disable DNS Test</td>
> <td><blockquote>
> Enables or disables the DNS test with the default settings.
> </blockquote></td>
> </tr>
> <tr class="even">
> <td>Enable/Disable FTP Test</td>
> <td><blockquote>
> Enables or disables the FTP test with the default settings.
> </blockquote></td>
> </tr>
> <tr class="odd">
> <td>Enable/Disable HTTP Test</td>
> <td><blockquote>
> Enables or disables the HTTP test with the default settings.
> </blockquote></td>
> </tr>
> <tr class="even">
> <td>Enable/Disable RTMP Test</td>
> <td><blockquote>
> Enables or disables the RTMP test with the default settings.
> </blockquote></td>
> </tr>
> <tr class="odd">
> <td>Enable/Disable RTSP Test</td>
> <td><blockquote>
> Enables or disables the RTSP test with the default settings.
> </blockquote></td>
> </tr>
> <tr class="even">
> <td>Enable/Disable SMTP Test</td>
> <td><blockquote>
> Enables or disables the SMTP test with the default settings.
> </blockquote></td>
> </tr>
> <tr class="odd">
> <td>Enable/Disable TFTP Test</td>
> <td><blockquote>
> Enables or disables the TFTP test with the default settings.
> </blockquote></td>
> </tr>
> <tr class="even">
> <td>Other...</td>
> <td></td>
> </tr>
> </tbody>
> </table>
>
>

#### Settings

The subpage **Settings** allows to change the settings of the monitoring tests currently running on the device.

[Device Discovery]()




# Topics



## About

## Installation and Configuration

> Installation

> > System RequirementsSet-Up
>
> Configuration

## Usage

> Map
> Network

> > #### List
>
> > #### Subnet
>
> > #### Type

> Monitor[Discover](#Device%20Discovery)


