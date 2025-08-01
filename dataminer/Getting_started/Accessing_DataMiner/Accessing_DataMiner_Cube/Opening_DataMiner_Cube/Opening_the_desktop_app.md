---
uid: Using_the_desktop_app
---

# Using the desktop application

Open the DataMiner Cube desktop app via the shortcut on your desktop or in the start menu.

The DataMiner Cube start window is then displayed with tiles representing the different DataMiner Systems you can connect to.

Click a tile to connect to the corresponding DMS. In case the DMS you want to connect to is not listed yet, click the “+” button, specify the DMA name or IP and click *Connect*.

For more information on how to manage the start window of the Cube desktop app, see [Managing the start window of the DataMiner Cube desktop app](xref:Managing_the_start_window).

> [!NOTE]
>
> - If you want to open DataMiner Cube for multiple DataMiner Systems without closing the start window, keep the Ctrl key pressed while you click the tiles.
> - In most cases, you will be logged in automatically after you have clicked a tile. If you do not want this to happen, hold the `Shift` key during DataMiner Cube startup.
> - If you have multiple monitors and want DataMiner Cube to open on a specific monitor, you can open the app using a command with the *screen* argument. For example: *DataMinerCube.exe screen=\\\\.\\DISPLAY2*

## Opening DataMiner Cube from a session link

From DataMiner 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5 onwards<!--RN 42389-->, you can open DataMiner Cube directly using a session link.

If another user shares a session link with you, paste it into the address box of a web browser. This will automatically launch DataMiner Cube and connect to the shared session.

To copy your own session link, open the user menu in the [Cube header bar](xref:DataMiner_Cube_header_bar) and click the ![Copy](~/dataminer/images/Copy.png) icon to the right of the DataMiner System name. You can then share this link with other users so they can open the same Cube session.
