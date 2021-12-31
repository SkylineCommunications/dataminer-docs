## Logging on to DataMiner Cube

When you open DataMiner Cube, in most cases you will be logged on automatically with your current Windows account. However, if, for example, you explicitly logged out of your previous DataMiner Cube session, or your system uses external authentication, the DataMiner Cube logon screen will be displayed.

### Logging on to DataMiner Cube

#### Logging on using DataMiner 10.0.0/10.0.2 or higher

1. Check if the IP or name that is displayed below the DataMiner logo is that of the DMA you want to connect to. If not, click the IP or name and specify a different IP or name in the box.

2. Specify your credentials if necessary:

    - To log in with the current Windows user account, no credentials need to be specified.

    - To log in with a different user account, click the gray user icon at the bottom of the page and then specify the username and password.

3. Optionally select *Remember me* in order to log in automatically next time.

4. Click the blue arrow icon below the user information to log on.

> [!NOTE]
> -  When you log out of a DMS using the Cube desktop app, you are returned to the logon screen, but no drop-down box will be available to modify the DMA you connect to. This is intended to ensure that you do not connect to a DMA with a different software version. However, if for some reason, for example for testing or debugging purposes, you do wish to connect to a different DMS using the current DataMiner version, keep Ctrl + Alt+ Shift pressed and you will be able to select a different DMS. Note that this feature should never be used in normal circumstances, as it can cause unexpected behavior. 
> -  From DataMiner 10.1.3 onwards, after you have logged out using the Cube desktop app, you can click the arrow button to go back to the start window and select a different DMA to connect to.

#### Using a DataMiner version prior to DataMiner 10.0.0/10.0.2

##### Logging on using one of the listed user accounts

1. If you are using the DataMiner Cube desktop application, check the name of the DataMiner Agent in the *Connect to* box. If necessary, specify a different DMA.

    > [!NOTE]
    > -  If you are using the DataMiner Cube browser application and want to connect to a different Agent, click *Connect to another Agent* and specify the DMA in the *Connect to* box.
    > -  From DataMiner 9.0 onwards, the logon window will adopt the theme of the Agent selected in the *Connect to* box.

2. Click one of the listed users and enter the password if necessary.

    > [!NOTE]
    > If you log on with your current Windows user account, you will not need to specify a password.

3. If you do not want to have to enter the password again the next time you log on, select *Save my user name and password*.

4. Click *Log on*.

##### Logging on with a user account that is not in the list

1. If you are using the DataMiner Cube desktop application, check the name of the DataMiner Agent in the *Connect to* box. If necessary, specify a different DMA.

    > [!NOTE]
    > -  If you are using the DataMiner Cube browser application and want to connect to a different Agent, click *Connect to another Agent* and specify the DMA in the *Connect to* box.
    > -  From DataMiner 9.0 onwards, the logon window will adopt the theme of the Agent selected in the *Connect to* box.

2. Click *Other User*.

3. Enter the username or email address and the password.

4. If you do not want to have to enter the password again the next time you log on, select *Save my user name and password*.

5. Click *Log on*.

> [!NOTE]
> If, on the client computer, no cached user settings can be found for the user account you logged on with, DataMiner Cube will load the default user settings stored on the DataMiner Agent.

### Overriding the default connection type

By default, the type of connection that will be established between DataMiner Cube and the DMA will be the type of connection that is specified in the file *connectionsettings.txt* (located in the following directory on the DMA: *C:\\Skyline DataMiner\\Webpages*). However, on the logon screen, you can override that default connection type for the connection you are about to establish.

To do so, before you log on, do the following:

- Using DataMiner 10.0.0/10.0.2 or higher:

    1. Click the cogwheel button in the lower right corner and select *Options* in the menu.

    2. In the *Edit Settings* window, set the *Connection Type* to either *Remoting* or *Web services* and modify the different settings if necessary (destination port, polling interval, ...).

        > [!NOTE]
        > As WSE is deprecated, the Web Services option is no longer available from DataMiner 10.0.0 \[CU6\]/10.0.11 onwards.

    3. Click *OK*.

- Using a DataMiner version prior to DataMiner 10.0.0/10.0.2:

    1. At the bottom of the logon screen, click *Options*.

    2. In the *Edit Settings* window, set the *Connection Type* to either *Remoting* or *Web services* and modify the different settings if necessary (destination port, polling interval, ...).

    3. Click *OK*.

> [!NOTE]
> -  It is also possible to change the connection settings once you are logged on. To do so, go to *Settings \> computer \> Connection*. See [Manual configuration of client communication settings](../../part_3/DataminerAgents/DMA_configuration_related_to_client_applications.md#manual-configuration-of-client-communication-settings).
> -  Connecting via web services is not possible if WSE is not installed on the DMA. 

### Logging off from DataMiner Cube

Using DataMiner 10.0.0/10.0.2 or higher:

- In the header bar, click the user icon and select *Sign out*.

Using a DataMiner version prior to DataMiner 10.0.0:

1. In the header bar, click the name of the user who is currently logged on.

2. At the top of the *Contacts* window, click *Log Off*.
