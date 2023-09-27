---
uid: Displaying_a_DataMiner_map_in_a_web_browser
---

# Displaying a DataMiner map in a web browser

1. Open a web browser.

1. Enter the map’s address in the address bar:

    ```txt
    http://[DMA]/maps/map.aspx?config=[configuration file]
    ```

1. Press ENTER.

> [!TIP]
> See also:
> [Switching map configurations by means of JavaScript](xref:Switching_map_configurations_by_means_of_JavaScript)

Example: If you want to display a DataMiner map using the settings specified in a configuration file named *mymap.xml*, enter the following address in the address bar of your web browser:

```txt
http://MyDma/maps/map.aspx?config=mymap
```

## Displaying a DataMiner Map in a Visio file

1. In a Microsoft Visio file, draw the shape in which you want the DataMiner map to be displayed.

1. Add a shape data item of type **Link** to the shape, and set its value to:

    ```txt
    #http://[DMA]/maps/map.aspx?config=[configuration file]
    ```

> [!NOTE]
> The # character in front of the address will make sure the DataMiner Map is displayed inside the shape you have drawn. If you do not type the # character in front of the address, the DataMiner Map will be displayed in a new web browser window when you click the shape.
>
