---
uid: Options_for_opening_DataMiner_Cube
---

# Arguments for DataMiner Cube

You can pass a number of arguments when starting DataMiner Cube, as detailed below.

- In the desktop app, from DataMiner 10.0.9 onwards, you can do so as detailed under [Connecting to a DMS using URL arguments](xref:Managing_the_start_window#connecting-to-a-dms-using-arguments)).

- In the legacy browser app, you can pass these arguments by adding them to the URL.

- To combine different options, use a space as separator in the desktop app, or "&" in the browser app.

> [!NOTE]
>
> - Prior to DataMiner 10.0.9, these arguments can only be passed along in the desktop app if you installed the application using an .msi file.
> - From DataMiner 10.1.3 onwards, if the Cube desktop app is installed, you can also use the cube:// protocol to connect to a specific host. For example:
>
>   - cube://mydma?element=MyElement
>   - cube://10.11.12.13?view=12

## Examples

Examples for the desktop application:

```txt
view="My special view" element=MyElement
view=View2 element=365 app=help
```

Examples for the browser application:

```txt
DataMinerCube.exe host=MyDMA view="My special view" element=MyElement
DataMinerCube.exe host=MyOtherDMA view=View2 element=365 app=help
```

Examples for the desktop application (prior to DataMiner 10.0.9, using a command line):

```txt
DataMinerCube.exe host=MyDMA view="My special view" element=MyElement
DataMinerCube.exe host=MyOtherDMA view=View2 element=365 app=help
```

## Overview of the arguments

### Opening a card on a particular page

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

### alarm=

Use this option to immediately display a specific alarm card.

Specify the DMA ID and root alarm ID.

Example:

```txt
http://MyDMA1/DataMinerCube/DataMinerCube.xbap?alarm=48/6713
```

> [!NOTE]
> To quickly find the root alarm ID, right-click the alarm in the Alarm Console and select *Properties*. The root alarm ID will be displayed below the regular ID in the top-right corner of the properties window.

### app=

Use this option to immediately open a specific module in a card.

If you want to open several modules, separate the module names by means of pipe characters.

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
> - We recommend that you also pass the element ID and chain. If no element ID is specified, the first element of type “element manager” will be used. If no chain is specified, the first chain containing the specified filter will be used.
> - When multiple filters are specified, only the lowest filter in the selected chain will be used. However, if no chain is specified, all filters are used to find the correct chain.
> - If only one row matches the filter, an object will be loaded.
> - If the filter value is a key prefix, add an asterisk (“\*”) to the filter value.
> - URLs containing filters must be encoded according to the W3C guidelines. For more information, see [http://www.w3schools.com/tags/ref_urlencode.asp](http://www.w3schools.com/tags/ref_urlencode.asp).

> [!TIP]
> See also: [Experience and Performance Management](xref:EPM)

### element=

Use this option to specify an element to be opened in a card right after startup. You can specify the element by:

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

Use this option to specify the IP address or hostname of the DMA to which you want to connect.

Examples:

```txt
http://MyDMA1/DataminerCube/dataminercube.xbap?host=MyDMA2
DataminerCube.exe host=MyDMA2
```

### lat=

Use this option along with the “long” URL parameter when a link to a DataMiner map is specified, in order to override the initial center latitude and longitude defined in the map configuration.

For example:

```txt
http://localhost/maps/map.aspx?config=ExampleConfig&lat=42&long=12.30
```

Available from DataMiner 9.5.1 onwards.

> [!TIP]
> See also: [long=](#long)

### long=

Use this option along with the “lat” URL parameter when a link to a DataMiner map is specified, in order to override the initial center latitude and longitude defined in the map configuration.

For example:

```txt
http://localhost/maps/map.aspx?config=ExampleConfig&lat=42&long=12.30
```

Available from DataMiner 9.5.1 onwards.

> [!TIP]
> See also: [lat=](#lat)

### measpt=

Use this option when opening a Spectrum Analyzer element right after startup, in order to immediately open the *Measurement points* tab of the settings pane and select the indicated measurement point.

Always combine this option with *element=*.

To open several measurement points, separate them by means of pipe characters.

Examples:

```txt
http://MyDMA1/DataminerCube/dataminercube.xbap?element=34/105&measpt=1
```

> [!NOTE]
> This option can be combined with the *preset=* option.

### options=

Use this option along with *preset=*, in order to load a spectrum preset in the Spectrum Analyzer element(s) opened right after startup.*options=* is required in order to specify the preset options.

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

Use this option to specify the name of the spectrum preset to be loaded in the Spectrum Analyzer element(s) opened right after startup.

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

Use this option to specify the service to be opened in a card right after startup. You can specify the service by:

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

Use this option to specify the view to be opened in a card right after startup. You can specify the view by:

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

Use this option to specify the name of the workspace to be opened right after startup.

Examples:

```txt
http://MyDMA1/DataminerCube/dataminercube.xbap?workspace=Classic
DataminerCube.exe workspace=Classic
```

> [!NOTE]
> If you want an empty workspace to be opened, use the argument *workspace=Clean*.
