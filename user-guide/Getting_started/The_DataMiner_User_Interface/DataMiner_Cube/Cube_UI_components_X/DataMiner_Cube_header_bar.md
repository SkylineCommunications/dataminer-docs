---
uid: DataMiner_Cube_header_bar
---

# DataMiner Cube header bar

From DataMiner 10.0.0/10.0.2 onwards, you can find the following items in the header bar of DataMiner Cube:

- **Cube side indicators**: Four blue squares, each representing one of the four Cube sides. The largest square marks the Cube side that is currently displayed. These indicators may be hidden, depending on the user settings. (See “Quick menu icon” below.)

- **Cube search box**: See [Searching in DataMiner Cube](xref:Searching_in_DataMiner_Cube).

- **DMS time**: Indicates the server time of the DMS, which may be useful in case the server is not in the same time zone as the client. This time indicator may be hidden, depending on the user settings. (See “Quick menu icon” below.)

- **![Quick menu button](~/user-guide/images/CubeXquickmenu.png) Quick menu icon**: This icon opens a quick menu where you can toggle the following options related to the header:

  - *Show Cube sides*: Determines whether the 4 squares indicating the Cube sides are displayed.

  - *Show server time*: Determines whether the DMS time is displayed.

  - *Show cluster name*: Determines whether the name of the cluster is displayed. (Available from DataMiner 10.0.12 onwards.)

  - *Show search box*: Determines whether the search box is displayed. (Available from DataMiner 10.3.5/10.4.0 onwards).

- **User icon**: Click this icon to open a menu containing information on the user and the DMA, as well as the following options:

  - *Account details*: Opens your user card.

  - *X online contacts*: Displays the contacts that are currently online. Right-click a contact in the list to access a menu that allows you to exchange chat messages with them or to disconnect them (if you have the necessary permissions to do so).

    > [!TIP]
    > See also: [Chat collaboration](xref:chat#chat-collaboration)

  - *Settings*: Opens the *Settings* window.

    > [!TIP]
    > See also:
    >
    > - [User settings](xref:User_settings)
    > - [Computer settings](xref:Computer_settings)

  - *Change layout*: Allows you to select a different layout for the cards in the Cube workspace.

    > [!TIP]
    > See also: [Changing the card layout](xref:Working_with_cards_in_DataMiner_Cube#changing-the-card-layout)

  - *System Center*: Opens the System Center, where you can among others configure the DMS setup, backups, the database and DataMiner security, if you have the necessary permissions to do so. The System Center also provides access to all DataMiner log files.

    > [!TIP]
    > See also: [Logging](xref:logging)

  - *Agents*: Opens the *Agents* page in System Center, where you can view information on the DMS and configure the DMS, if you have the necessary permissions to do so.

  - *Help*: Opens the DataMiner online help.

  - *About*: Opens the *About* box. This box consists of several tabs, and three buttons:

    - The *general* tab mentions the upgrade version of your DMA. It also contains contact information and a link to the Skyline license terms and to third-party notices.

    - The *assemblies* tab mentions the assemblies used by your DMA.

    - The *connection* tab contains information about the connection of client to server.

    - The *versions* tab shows the server and client version, as well as the version of the various DataMiner files and the DMA upgrade history.

    - The *license* tab contains license information as well as activated license counter information. For demo licenses, the expiration date is shown at the top.

      > [!NOTE]
      > To view license information regarding third-party software, go to *http(s)://**\[DMA name or IP\]**/Licenses*.

    - The buttons at the bottom of the box allow you to export, email or copy the information for troubleshooting purposes.

  - *Check for updates*: Opens the Update Center, where you can check for and download updates for DataMiner protocols or for the DataMiner software itself.

    > [!TIP]
    > See also: [Updating protocols with the Update Center](xref:Adding_a_protocol_or_protocol_version_to_your_DataMiner_System#updating-protocols-with-the-update-center)

  - *Open Cube Mobile*/*Open web apps*: Opens the DataMiner landing page, with access to the various DataMiner web apps. This option is renamed from DataMiner 10.0.0 \[CU16\] /10.1.0 \[CU5\]/10.1.8 onwards to better reflect the actual usage of these apps.

  - *Sign out*: Ends your current DataMiner Cube session and returns you to the logon screen. If you are using a desktop app, you can click then the arrow button next to the DMA name or IP to go back to the start window and select a different DMS to connect to.
