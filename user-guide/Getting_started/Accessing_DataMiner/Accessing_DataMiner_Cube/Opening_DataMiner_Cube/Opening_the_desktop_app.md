---
uid: Opening_the_desktop_app
---

# Opening the desktop application

## [From DataMiner 10.0.9 onwards](#tab/tabid-1)

Open the DataMiner Cube desktop app via the shortcut on your desktop or in the start menu.

The DataMiner Cube start window is then displayed with tiles representing the different DataMiner Systems you can connect to.

Click a tile to connect to the corresponding DMS. In case the DMS you want to connect to is not listed yet, click the “+” button, specify the DMA name or IP and click *Connect*.

For more information on how to manage the start window of the Cube desktop app, see [Managing the start window of the DataMiner Cube desktop app](xref:Managing_the_start_window).

> [!NOTE]
>
> - If you want to open DataMiner Cube for multiple DataMiner Systems without closing the start window, keep the Ctrl key pressed while you click the tiles.
> - If you have multiple monitors and want DataMiner Cube to open on a specific monitor, you can open the app using a command with the *screen* argument. For example: *DataMinerCube.exe screen=\\\\.\\DISPLAY2*

## [Prior to DataMiner 10.0.9](#tab/tabid-2)

If you have installed the desktop DataMiner Cube application, execute the following command in the folder where you installed the application:

```txt
DataminerCube.exe
```

> [!NOTE]
> By default, the file is installed in the program files directory, in the folder *Skyline Communications\\DataMiner Cube*. However, it is possible to choose a different folder during installation.

***
