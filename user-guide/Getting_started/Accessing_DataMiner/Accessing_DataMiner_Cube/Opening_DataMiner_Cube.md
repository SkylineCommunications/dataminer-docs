---
uid: Opening_DataMiner_Cube
---

# Opening DataMiner Cube

## Opening the desktop application

### [From DataMiner 10.0.9 onwards](#tab/tabid-1)

Open the DataMiner Cube desktop app via the shortcut on your desktop or in the start menu.

The DataMiner Cube start window is then displayed with tiles representing the different DataMiner Systems you can connect to.

Click a tile to connect to the corresponding DMS. In case the DMS you want to connect to is not listed yet, click the “+” button, specify the DMA name or IP and click *Connect*.

For more information on how to manage the start window of the Cube desktop app, see [Managing the start window of the DataMiner Cube desktop app](#managing-the-start-window-of-the-dataminer-cube-desktop-app).

> [!NOTE]
>
> - If you want to open DataMiner Cube for multiple DataMiner Systems without closing the start window, keep the Ctrl key pressed while you click the tiles.
> - If you have multiple monitors and want DataMiner Cube to open on a specific monitor, you can open the app using a command with the *screen* argument. For example: *DataMinerCube.exe screen=\\\\.\\DISPLAY2*

### [Prior to DataMiner 10.0.9](#tab/tabid-2)

If you have installed the desktop DataMiner Cube application, execute the following command in the folder where you installed the application:

```txt
DataminerCube.exe
```

> [!NOTE]
> By default, the file is installed in the program files directory, in the folder *Skyline Communications\\DataMiner Cube*. However, it is possible to choose a different folder during installation.

***

## Managing the start window of the DataMiner Cube desktop app

Below you can find more information on the different options available to manage the start window of the DataMiner Cube desktop app, available from DataMiner 10.0.9 onwards.

### Selecting your Cube update track

From DataMiner 10.2.0 \[CU3]/10.2.6 onwards, Cube can automatically update to a more recent version than the DataMiner version installed on the server. This way you can use the latest Cube features as soon as they are released without having to wait for a server upgrade.

In the Cube start window, you can select which Cube update track should be used:

1. Click the cogwheel icon in the lower right corner of the start window.

1. Select *Settings*.

1. In the *Settings* dialog, select the update track you want to use:

   - **Release**: Use the latest released DataMiner Cube version, so you can enjoy all the latest and greatest features.
   - **Release (delayed 2 weeks)**: Wait to use the latest released DataMiner Cube version until 2 weeks after the release date.

   > [!NOTE]
   > For Skyline employees only, two additional tracks are available for development purposes:
   >
   > - **Preview**: Use a preview of the latest DataMiner Cube version, even if it has not been released yet.
   > - **Development**: Use the latest available development version.

1. Click *Save*.

> [!NOTE]
>
> - You can also right-click the tile representing a particular DMS/DMA in the start window and select *Connect using* to select a specific Cube version to connect to that DMS/DMA with.
> - Limitations to the possible Cube versions can be configured in the [system settings](xref:DMA_configuration_related_to_client_applications#managing-client-versions).

### Setting a DMS as the default DMS

To set a DMS as the default DMS to connect to:

1. Hover the mouse over the tile representing this DMS and click “...” in the top-right corner.

1. Select *Set as default* in the pop-up window and click *Save*.

### Changing which DMA in a DMS you connect to

To specify a different DMA in a DMS to connect to:

1. Hover the mouse over the tile representing this DMS and click “...” in the top-right corner.

1. Expand the *Agent* section, select the DMA and click *Save*.

### Connecting to a DMS using URL arguments

To connect to a DMS using specific URL arguments:

1. Hover the mouse over the tile representing this DMS and click “...” in the top-right corner.

1. Expand the *Advanced* section, specify the URL arguments and click *Save*.

For more information on the possible URL arguments, see [Options for opening DataMiner Cube](#options-for-opening-dataminer-cube).

### Configuring whether to connect with HTTPS only

From DataMiner 10.2.6/10.3.0 onwards, you can configure whether Cube should connect to a specific DMS using HTTPS only or whether it can fall back to HTTP if HTTPS is not available.

To do so:

1. Hover the mouse over the tile representing this DMS and click “...” in the top-right corner.

1. Expand the *Advanced* section.

1. In the *Transport* box, select *HTTP or HTTPS* or *HTTPS only*, depending on your preference.

1. Click *Save*.

### Removing a DMS from the start window

To remove the tile representing a DMS from the start window:

1. Hover the mouse over the tile representing this DMS and click “...” in the top-right corner.

1. Click the garbage can icon in the pop-up window.

### Sorting tiles in groups

From DataMiner 10.2.0/10.1.3 onwards, you can sort the different tiles in the start window in groups.

- If no groups have been created yet, all tiles will be considered to be part of the same group.

- To create a new group, drag a tile out of its current group.

- To name or rename a group, click above the group and enter the name.

- To move a tile to another position or to another group, drag it to its new position.

### Filtering the displayed tiles

To filter the tiles in the start window:

- Hover the mouse pointer over the looking glass and enter a search string in the search box.

- Alternatively, simply start typing a search string, without going to the search box.

    > [!NOTE]
    > When the filter does not yield any results, you can click the “+” button or press ENTER to immediately add the DMS you were looking for.

### Making DataMiner Cube start up with windows

To specify whether the DataMiner Cube should start up when Windows is started:

1. Click the cogwheel icon in the lower right corner of the start window.

1. Select or clear the option *Start with Windows*, depending on whether you want Cube to start with Windows or not.

### Viewing logging for the start window

To view logging for the DataMiner Cube start window:

1. Click the cogwheel icon in the lower right corner of the window.

1. Select *View logging*.

### Checking the software version for the start window

From DataMiner 10.2.6/10.3.0 onwards, you can check which software version the start window currently uses.

To do so:

1. Click the cogwheel icon in the lower right corner of the start window.

1. Select *About*.

## Opening the browser application

Open Internet Explorer and, depending on your setup, go to one of the following addresses:

```txt
http://[DMA]/dataminercube
https://[DMA]/dataminercube
```

> [!NOTE]
>
> - In the above-mentioned address, replace “\[DMA\]” by the IP address or the hostname of the DataMiner Agent you want to connect to.
> - If DataMiner Cube has been set as the default client, it is not necessary to add “*/dataminercube*” in the URL.
> - DataMiner Cube will automatically disconnect when the DMA to which you are connected goes offline.
> - It is good practice to encode URLs according to the W3C guidelines. For more information, see <http://www.w3schools.com/tags/ref_urlencode.asp>.

> [!CAUTION]
> If you use a DataMiner version prior to DataMiner 10.1.7, we strongly advise using HTTPS when you use DataMiner client applications over public internet. If you do not do so, all information – including logon credentials – is sent as plain, unencrypted text over the internet. From DataMiner 10.1.7 onwards, client-server communication is encrypted by default. See also: [Setting up HTTPS on a DMA](xref:Setting_up_HTTPS_on_a_DMA).

## Options for opening DataMiner Cube

You can pass a number of options when starting DataMiner Cube:

- [alarm=](#alarm)

- [app=](#app)

- [autoslide=](#autoslide)

- [buffer=](#buffer)

- [chain=](#chain)

- [debug=true](#debugtrue)

- [dte_filtername=filtervalue](#dte_filternamefiltervalue)

- [element=](#element)

- [host=](#host)

- [measpt=](#measpt)

- [options=](#options)

- [preset=](#preset)

- [preset=inline](#presetinline)

- [service=](#service)

- [view=](#view)

- [workspace=](#workspace)

> [!NOTE]
>
> - For the desktop application, prior to DataMiner 10.0.9, these options can only be passed along if you installed the application using an .msi file. From DataMiner 10.0.9 onwards, you can pass these options in the Cube start window by clicking ... in the top-right corner of the button representing the DMS you want to connect to, and specifying the URL arguments in the *Advanced* section.
> - From DataMiner 10.1.3 onwards, if the Cube desktop app is installed, you can use the cube:// protocol to connect to a specific host. For example:
>
>   - cube://mydma?element=MyElement
>   - cube://10.11.12.13?view=12

### alarm=

From DataMiner 9.0.5 onwards, you can use this option to immediately display a specific alarm card.

Specify the DMA ID and root alarm ID.

Example:

```txt
http://MyDMA1/DataMinerCube/DataMinerCube.xbap?alarm=48/6713
```

> [!NOTE]
> To quickly find the root alarm ID, right-click the alarm in the Alarm Console and select *Properties*. The root alarm ID will be displayed below the regular ID in the top-right corner of the properties window.

### app=

Name of the app to be opened in a card right after startup.

If you want to open several apps, separate them by means of pipe characters.

Examples:

```txt
http://MyDMA1/Dataminercube/dataminercube.xbap?app=about
http://MyDMA1/Dataminercube/dataminercube.xbap?app=Protocols%20%26%20Templates|Asset%20Manager
DataminerCube.exe app=about
DataminerCube.exe app="Reports & Dashboards"
DataminerCube.exe app=settings"|"logging
```

### autoslide=

Use this option if you want DataMiner Cube to automatically move to the next workspace every X seconds.

Examples:

```txt
http://MyDMA1/DataminerCube/dataminercube.xbap?autoslide=30
DataminerCube.exe autoslide=15
```

To disable the autoslide mode, reconnect without the autoslide option.

### buffer=

Use this option along with the “*element=*” option to immediately show the buffer of a Spectrum Analyzer element.

The buffer should be specified in one of the following three ways:

- Monitor trace variable:

    ```txt
    buffer=monitorID:traceVariable
    ```

- Monitor trace variable with monitor script using measurement point:

    ```txt
    buffer=monitorID:traceVariable:measurementpointID
    ```

- Monitor trace variable with monitor script using measurement point and input preset:

    ```txt
    buffer=monitorID:traceVariable:measurementpointID:presetName
    ```

Example:

```txt
http://MyDMA1/Dataminercube/dataminercube.xbap?element=34/105&buffer=3:trace1
```

### chain=

Use this option to open a CPE Manager element to a particular chain.

Example:

- To open the element with ID 169/2 and open the chain with name “Physical”:

    ```txt
    http://MyDMA1/DataMinerCube/DataMinerCube.xbap?ELEMENT=169%2F2&chain=physical
    ```

> [!NOTE]
>
> - It is advisable to also pass the element ID. If no element ID is specified, the first element of type “element manager” will be used.
> - The chain name is not case-sensitive.

### debug=true

This option allows you to view functionality that can be useful for debugging, but which is otherwise hidden in the UI.

For example, from DataMiner 9.6.0/9.5.3 onwards, the GUID of service definitions is only shown in the Services app if you use the *debug=true* argument.

### dte_filtername=filtervalue

Use this option to open a CPE Manager element with a particular filter.

- “filtername” is the name of the filter without spaces. The name is not case sensitive.

- “filtervalue” is the value of the filter.

Example:

- To open the element with ID 169/2, open the first chain with a “Node” filter, and load Node “DBL900”:

    ```txt
    http://MyDMA1/DataMinerCube/DataMinerCube.xbap?ELEMENT=169%2F2&dte_Node=DLB900
    ```

- To open the element with ID 169/2, open the first chain with a “Node” filter and an “MTA” filter, and if there is only one MTA that matches the filter then load the MTA that contains the string “ABCD987”:

    ```txt
    http://MyDMA1/DataMinerCube/DataMinerCube.xbap?ELEMENT=169%2F2&dte_Node=DLB900&dte_MTA=*ABCD987*
    ```

> [!NOTE]
>
> - It is advisable to also pass the element ID and chain. If no element ID is specified, the first element of type “element manager” will be used. If no chain is specified, the first chain containing the specified filter will be used.
> - When multiple filters are specified, only the lowest filter in the selected chain will be used. However, if no chain is specified, all filters are used to find the correct chain.
> - If only one row matches the filter, an object will be loaded.
> - If the filter value is a key prefix, add an asterisk (“\*”) to the filter value.
> - URLs containing filters must be encoded according to the W3C guidelines. For more information, see [http://www.w3schools.com/tags/ref_urlencode.asp](http://www.w3schools.com/tags/ref_urlencode.asp).

> [!TIP]
> See also: [DMS Experience and Performance Management](xref:EPM#dms-experience-and-performance-management)

### element=

Element to be opened in a card right after startup:

- ElementID,

- DmaID/ElementID, or

- Element name

If you want to open several elements, separate them by means of pipe characters.

Examples:

```txt
http://MyDMA1/DataminerCube/dataminercube.xbap?host=MyDMA2&element=MyElement
http://MyDMA1/DataminerCube/dataminercube.xbap?element=MyElement|MyOtherElement
DataminerCube.exe host=MyDMA2 element=154
DataminerCube.exe host=MyDMA2 element=MyElement"|"MyOtherElement
DataminerCube.exe host=MyDMA2 element="My element|My other element"
```

### host=

IP address or hostname of the DMA to which you want to connect.

Examples:

```txt
http://MyDMA1/DataminerCube/dataminercube.xbap?host=MyDMA2
DataminerCube.exe host=MyDMA2
```

### lat=

Used along with the “long” URL parameter when a link to a DataMiner map is specified, in order to override the initial center latitude and longitude defined in the map configuration.

For example:

```txt
http://localhost/maps/map.aspx?config=ExampleConfig&lat=42&long=12.30
```

Available from DataMiner 9.5.1 onwards.

> [!TIP]
> See also: [long=](#long)

### long=

Used along with the “lat” URL parameter when a link to a DataMiner map is specified, in order to override the initial center latitude and longitude defined in the map configuration.

For example:

```txt
http://localhost/maps/map.aspx?config=ExampleConfig&lat=42&long=12.30
```

Available from DataMiner 9.5.1 onwards.

> [!TIP]
> See also: [lat=](#lat)

### measpt=

Used when opening a Spectrum Analyzer element right after startup, in order to immediately open the *Measurement points* tab of the settings pane and select the indicated measurement point.

Always combine this option with *element=*.

To open several measurement points, separate them by means of pipe characters.

Examples:

```txt
http://MyDMA1/DataminerCube/dataminercube.xbap?element=34/105&measpt=1
```

> [!NOTE]
> This option can be combined with the *preset=* option.

### options=

Used along with *preset=*, in order to load a spectrum preset in the Spectrum Analyzer element(s) opened right after startup.*options=* is required in order to specify the preset options.

Spectrum preset options have to be specified as the sum of the following hexadecimal values:

| Value | Option                                             |
|-------|----------------------------------------------------|
| 0x1   | Load reference trace                               |
| 0x2   | Do not load settings like start and stop frequency |
| 0x4   | Load threshold                                     |
| 0x8   | Load display settings like colors                  |
| 0x10  | Load markers                                       |
| 0x20  | Load reference lines                               |
| 0x80  | Load frequency mask                                |
| 0x200 | Load measurement point cycle                       |

Example:

```txt
http://MyDMA1/DataminerCube/dataminercube.xbap?element=34/105&preset=abc&options=0x208
```

### preset=

Name of the spectrum preset to be loaded in the Spectrum Analyzer element(s) opened right after startup.

Unlike the inline preset option (see below), the regular preset option must always be combined with both *element=* and *options=*.

Examples:

```txt
http://MyDMA1/DataminerCube/dataminercube.xbap?element=34/105&preset=mypreset (public)&options=0x208
http://MyDMA1/DataminerCube/dataminercube.xbap?element=34/105|34/106|34/107&preset=mypreset (public)&options=0x00
```

> [!NOTE]
>
> - Take care when specifying more than one element in the URL. If you used a URL like the one in the second example above, all three elements would be opened in their own card, but as only the first one is a Spectrum Analyzer element, only that element would load the specified preset.
> - Only public presets can be used, and their *(public)* suffix must be included in the URL.

### preset=inline

The *preset=* option can also be used for inline presets, in which case it works differently from the regular *preset=* option, though it should also always be combined with *element=*.

Example:

```txt
http://MyDMA/dataminercube.xbap?element=element&measpt=-1&preset=inline:freqstart:450000;freqstop:500000000
```

Syntax:

```txt
inline:property1:value1;property2:value2;...
```

Property names:

- amountPoints

- detectMode

- firstMixerInput

- freqCenter (Hz)

- freqSpan (Hz)

- freqStart (Hz)

- freqStop (Hz)

- inputAtten

- preamp

- scaleType

- sweep (default: auto)

- rbw (default: auto)

- refLevel (default: 0 dBm)

- refScale (default: 10)

- vbw (default: auto)

> [!NOTE]
> When you specify an inline preset definition, you have to define at least the following properties:
>
> - freqStart and freqStop, or
> - freqCenter and freqSpan.

### service=

Service to be opened in a card right after startup:

- ServiceID,

- DmaID/ServiceID, or

- Service name

If you want to open several services, separate them by means of pipe characters.

Examples:

```txt
http://MyDMA1/DataminerCube/dataminercube.xbap?service=541
http://MyDMA1/DataminerCube/dataminercube.xbap?host=MyDMA2&service=MyService|MyOtherService
DataminerCube.exe host=MyDMA2 service=MyService-
DataminerCube.exe host=MyDMA2 service="My service"
DataminerCube.exe host=MyDMA2 service=MyService"|"MyOtherService
```

> [!NOTE]
> In order to open an SLA element, use the *element=* option.

### view=

View to be opened in a card right after startup:

- ViewID, or

- View name

If you want to open several views, separate them by means of pipe characters.

Examples:

```txt
http://MyDMA1/DataminerCube/dataminercube.xbap?host=MyDMA2&view=MyView
http://MyDMA1/DataminerCube/dataminercube.xbap?view=MyView|MyOtherView
DataminerCube.exe host=MyDMA2 view=MyView
DataminerCube.exe host=MyDMA2 view="My view"
DataminerCube.exe host=MyDMA2 view=MyView"|"MyOtherView
```

### workspace=

Name of the workspace to be opened right after startup.

Examples:

```txt
http://MyDMA1/DataminerCube/dataminercube.xbap?workspace=Classic
DataminerCube.exe workspace=Classic
```

> [!NOTE]
> If you want an empty workspace to be opened, use the argument *workspace=Clean*.

## Opening a card on a particular page

From DataMiner 9.6.3 onwards, if you use the *=element*, *=service* or *=view* option to open an element, service or view card at startup, you can have this card opened on a particular page.

To do so, add the following:

- A colon, followed by “*data*” or “*d*” for a data page or “*visual*” or “*v*” for a visual page.

  If the page is not grouped under the data or visual pages, only add a colon.

- A second colon, followed by the name of the page.

- A forward slash and the name of a subpage, in case you want to open a particular subpage.

For example:

- To open the subpage “ping” of the data page “performance” of the element with ID 48/70:

  ```txt
  http://MyDMA1/DataMinerCube/DataMinerCube.xbap?element=48/70:data:performance/ping
  ```

- To open the page “help” of the element with ID 48/70:

  ```txt
  http://MyDMA1/DataMinerCube/DataMinerCube.xbap?element=48/70::help
  ```

- To open the data page “Australia service” of the service with ID 48/105:

  ```txt
  http://MyDMA1/DataMinerCube/DataMinerCube.xbap?service=48/105:d:Australia Service
  ```

- To open the page “aggregation” of the view “SLC”:

  ```txt
  http://MyDMA1/DataMinerCube/DataMinerCube.xbap?view=SLC::aggregation
  ```

## Combining URL options for DataMiner Cube

You can combine different options using a separator character:

| Type of application | Option separator |
|---------------------|------------------|
| Browser application | &                |
| Desktop application | space            |

Examples for the browser application:

```txt
DataMinerCube.exe host=MyDMA view="My special view" element=MyElement
DataMinerCube.exe host=MyOtherDMA view=View2 element=365 app=help
```

Examples for the desktop application (to be specified via the “...” button in the Cube start window, in the *Arguments* box):

```txt
view="My special view" element=MyElement
view=View2 element=365 app=help
```

Examples for the desktop application (prior to DataMiner 10.0.9, using a command line):

```txt
DataMinerCube.exe host=MyDMA view="My special view" element=MyElement
DataMinerCube.exe host=MyOtherDMA view=View2 element=365 app=help
```
