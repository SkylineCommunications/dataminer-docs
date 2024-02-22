---
uid: Dashboard_Gateway_troubleshooting
---

# Dashboard Gateway troubleshooting

> [!IMPORTANT]
> This information is applicable to the DMS Dashboards module, which is being retired as of DataMiner version 10.4.x. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement). For more information on the Dashboards web app available from DataMiner 9.6.9 onwards, see [Dashboards app](xref:newR_D).

The following issues may occur when you try to access the Dashboard Gateway:

- **Message: Connection Lost. Failed to set up a connection with the DataMiner Agent: DataMiner is not running.**

    The DataMiner Agent is not running for the moment. Start up the DataMiner Agent. Once the DataMiner Agent is active, the connection will automatically be restored.

- **Message: Connection Lost. Failed to set up a connection with the DataMiner Agent: Could not auto-detect URI for \<DataMiner IP> Unable to connect to the remote server.**

    The Dashboard Gateway can no longer connect to the DataMiner Agent. Check if it is possible to make a connection from the Dashboard Gateway to the DataMiner Agent.

- **Message: Connection Lost. Web Server Unavailable: The server method “IsAlive” failed.**

    There is no longer a connection between the client PC and the DataMiner Gateway. Check if the DataMiner Gateway is still available from the client PC.

- **Login failed with the message: Failed to setup a connection with the DataMiner Agent. Unable to authenticate.**

    This message indicates that there is a problem with the setup of a connection between the Dashboard Gateway and the DataMiner Agent. Check if the username and the password used in the web.config file are the same as the username and password in DataMiner System.

- **Login failed with the message: Your login attempt was not successful. Please try again.**

    The username and password that you used to login are not correct. Check if the user is available in the DataMiner System and if the password is correct.

- **Login failed with the message: Failed to setup a connection with the DataMiner Agent. User \<Dashboard User Name> has no rights on the DataMiner System.**

    The Dashboard Gateway uses a specific user to communicate with the DataMiner Agent. This user needs to have the necessary rights for all the elements used in the dashboards they need to access. To solve this issue, change the user’s rights so they have access to the elements. See [Configuring a user group](xref:Configuring_a_user_group).

- **DataMiner Maps cannot be accessed via the Dashboard Gateway.**

    By default, data accessed via a Dashboard Gateway is not publicly accessible. Therefore, to be able to display DataMiner Map information via a Dashboard Gateway, add the following exception to the web.config of that Dashboard Gateway:

    ```xml
    <!-- allow anonymous access to MapsGetSecureFile (required by Google Maps) -->
    <location path="p/API">
      <system.web>
        <authorization>
          <allow users="?" />
        </authorization>
      </system.web>
    </location>
    ```

    > [!NOTE]
    > Private KML files can only be loaded via a Dashboard Gateway from DataMiner 9.0 onwards.

- **The Dashboard Gateway is no longer working after a DataMiner upgrade or update.**

    In case the Dashboard Gateway no longer responds immediately after DataMiner has been upgraded or updated, do the following:

    1. Make a backup of the *Dashboards* folder on the Gateway server.

    2. In the *Dashboards* folder on the Gateway server, delete the following files and folders:

        - App_Themes

        - bin

        - Common

        - Layouts

        - Master

        - Parts

        - Scripts

        - AlarmDetails.aspx

        - ChangePassword.aspx

        - ColorPicker.aspx

        - ConfigureDashboard.asmx

        - ConfigureSecurity.aspx

        - DashboardInfo.asmx

        - Data.asmx

        - Default.aspx

        - Error.aspx

        - ImageGallery.aspx

        - Login.aspx

        - LoginChallenge.aspx

        - packages.config

        - PopupAdvancedSelection.aspx

        - PopupGroupLayoutEditor.aspx

        - PopupLayoutSelection.aspx

        - PopupThemeSelection.aspx

        - PrecompiledApp.config

        - robots.txt

        - SimpleData.asmx

        - ViewFolder.aspx

    3. Go to the folder *C:\\Skyline DataMiner\\Webpages\\Dashboards* of the DataMiner Agent, and copy the same files and folders as you have just deleted on the Gateway server.

    4. Paste the files and folders in the *Dashboards* folder on the Gateway server.

    5. Restart IIS.
