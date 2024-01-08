---
uid: Installing_a_DMS_Dashboard_Gateway
---

# Installing a DMS Dashboard Gateway

> [!IMPORTANT]
> This information is applicable to the DMS Dashboards module, which is being retired as of DataMiner version 10.4.x. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement). For more information on the Dashboards web app available from DataMiner 9.6.9 onwards, see [Dashboards app](xref:newR_D).

For a Dashboard Gateway to function correctly, an additional Windows component, Internet Information Services, must also be installed. On some Windows versions this is installed by default, but on others you will need to install it yourself.

## Installing a Dashboard Gateway on Windows Server 2012

To install a Dashboard Gateway on Windows Server 2012, you must first install IIS, then install the dashboards, configure IIS, and finally configure the web.config file.

### Installing IIS

1. Go to *Start \> Server Manager*.

2. On the *Dashboard* page, click *Add roles and features*.

3. In the *Add Roles and Features Wizard*, click *Next* to go to the *Server Roles* step.

4. On the *Server Roles* tab, select *Web Server (IIS)* and *Management Tools*.

5. Expand the *Application Development* node to select *ASP.NET 3.5*, *ASP.NET 4.5*, *.NET Extensibility 3.5* and *.NET Extensibility 4.5*.

6. Click *Install* to start the installation process.

7. After the installation, which can take a few minutes, open the start menu and type “*iis manager*” to open the Internet Information Services (IIS) Manager.

8. In the navigation menu on the left, select *Application Pools*.

9. Right-click the *DefaultAppPool* and select the item *Advanced Settings*.

10. In the Process model section, set the item *Idle Time-out (minutes)* to 0 and click *OK* to confirm.

11. Right-click the *DefaultAppPool* again and select the item *Recycling*.

12. Disable the property *Regular time interval (in minutes)*.

### Installing the dashboards

1. Copy the directory *C:\\Skyline DataMiner\\Webpages\\Dashboards* from the DataMiner Agent to a location on the DataMiner Gateway, such as *C:\\Skyline DataMiner*.

2. Remove all the files and subfolders in the directory *...\\Dashboards\\db*.

### Configuring IIS

1. Go to *Start \> Control Panel \> Administrative Tools \> Internet Information Services (IIS) Manager*.

2. Click the root (name of the DataMiner Gateway) and select *Feature Delegation*.

3. For the items *Handler Mappings*, *Modules*, *Authentication - Anonymous* and *Authentication - Windows*, change the delegation from *Read Only* to *Read/Write*.

4. In the navigation menu on the left, select *COMPUTERNAME \> Web Sites \> Default Web Site*.

5. Right-click and select *Add Virtual Directory*.

6. Fill in the alias, “Example dashboards”, and the correct path to the dashboard folder.

7. Right-click the new item and select *Convert to Application*.

8. Click *OK*.

9. Select *COMPUTERNAME \> Web Sites \> Default Web Site \> Dashboards* in the navigation menu on the left.

10. In the *HTTP Features* section of the *Feature View* tab, double-click the item *Mime Types*.

11. To the list of Mime Types, add the Mime Type *fcss* by right-clicking in the list and selecting *Add*.

12. Choose the file name extension *fcss* and the Mime Type *text/plain*, and click *OK* to confirm.

### Configuring the web.config file

1. In DataMiner, create a new user profile with access to all elements in the DMS. The user also has to have the permission *Modules* > *System configuration* > *Tools* > *Admin tools*. See [Adding a user](xref:Adding_a_user).

    > [!NOTE]
    > This user will be used by the Dashboard Gateway to access the DMA. The username and password of this user will be used in step 4 of this procedure.

2. On the Dashboard Gateway, open the file *web.config* with Notepad.

3. In the file, search for the term *appName = "Dashboard"*.

4. Change the attributes from the “add” tag from:

    ```xml
    <add id="local" connectionstring="localhost" description="Local DataMiner Cluster">
    ```

    to:

    ```xml
    <add id="local" connectionstring="[IP DMA]" user="[name dashboard user]"
    password="[password of Dashboard user]" description="Dashboard DMA">
    ```

## Installing a Dashboard Gateway on Vista Server

To install a Dashboard Gateway on Windows Vista Server, you must first install IIS, and then install the dashboards.

### Installing IIS

1. Go to *Start \> Control Panel \> Programs and features*.

2. Click *Turn Windows features on or off*.

3. In the feature list, select *Internet Information Services*.

4. In the *World Wide Web* subdirectory *Application Development Features*, select the following features:

    - .Net Extensibility

    - ASP

    - ASP.NET

    - ISAPI Extensions

    - ISAPI Filter

5. Also under *World Wide Web*, select the checkbox of the directory *Security*.

6. Click *OK* to start the installation.

7. After the installation, which can take several minutes, go to *Start \> Control Panel \> Administrative Tools \> Internet Information Services (IIS) Manager*.

8. In the navigation menu on the left, select *Application Pools*.

9. Right-click the *DefaultAppPool* and select the item *Advanced Settings*.

10. Set the item *Idle Time-out (minutes)* in the Process model section to *0* and click *OK* to confirm.

11. Right-click the *DefaultAppPool* again and select the item *Recycling*.

12. Disable the property *Regular time interval (in minutes)*.

### Installing the dashboards

1. Copy the directory *C:\\Skyline DataMiner\\Webpages\\Dashboards* from the DataMiner Agent to a location on the DataMiner Gateway, such as *C:\\Skyline DataMiner*.

2. Remove all the files and subfolders in the directory *...\\Dashboards\\db*.

## Installing a Dashboard Gateway on Windows Server 2003

To install a Dashboard Gateway on Windows Server 2003, you must first install IIS, then install the dashboards, configure IIS, and finally configure the web.config file.

> [!NOTE]
> Windows Server 2003 is not supported from DataMiner 9.0 onwards.

### Installing IIS

1. Go to *Start \> Control Panel \> Add or Remove Programs*.

2. On the right-hand side, click *Add/Remove Windows Components*.

3. Enable *IIS*:

    - For Windows 2000/XP: select the checkbox for *Internet Information Services (IIS)*.

    - For Windows 2003:

        1. Select the checkbox for *Application Server*.

        2. While *Application Server* is selected, click *Details*.

        3. Select the checkbox for *ASP.NET*.

        4. Select *Internet Information Services (IIS)* and click *Details*.

        5. Select *World Wide Web Service* and click *Details*.

        6. Select the checkbox for *Active Server Pages*.

        7. Click *OK* three times to go back to the Windows Components Wizard

4. In the wizard, click *Next* to start the installation.

    The installation can take several minutes. Depending on the Windows installation, the Windows Installation CD may be required.

5. Click *Finish* to close the wizard, and close the *Add or Remove Programs* window.

6. After the installation, go to *Start \> Control Panel \> Administrative Tools \> Internet Information Services (IIS) Manager*.

7. In the navigation menu on the left, right-click the *DefaultAppPool*, which is located in the node *Application Pools*, and select *Properties*.

8. On the *Recycling* tab, disable the property *Recycle worker processes (in minutes)*.

9. On the *Performance* page, disable the property *Shutdown worker processes after being idle for (time in minutes)*.

10. Apply the changes.

### Installing the dashboards

1. Copy the directory *C:\\Skyline DataMiner\\Webpages\\Dashboards* from the DataMiner Agent to a location on the DataMiner Gateway, such as *C:\\Skyline DataMiner*.

2. Remove all the files and subfolders in the directory *...\\Dashboards\\db*.

### Configuring IIS

1. Go to *Start \> Control Panel \> Administrative Tools \> Internet Information Services (IIS) Manager*.

2. In the navigation menu on the left, select *COMPUTERNAME \> Web Sites \> Default Web Site*.

3. Select *New, Virtual Directory*.

4. Follow the wizard and fill in the alias, “Example dashboards”, and the correct path to the dashboards folder.

5. Select the following permissions:

    - Read

    - Run scripts

    - Execute

6. Click *Finish*.

7. Right-click *Default Web Site* and select *Properties*.

8. On the *HTTP Headers* tab, click the item *Mime Types*.

9. Click the *New* button.

10. Add the extension *fcss* and select the Mime Type *text/plain*, then confirm by clicking *OK* three times.

11. In the navigation menu on the left, go to *COMPUTERNAME \> Web Sites \> Default Web Site \> Dashboards*.

12. Right-click *Dashboards* and select *Properties*.

13. Select the *Documents* tab page and add the content page *Default.aspx*.

### Configuring the web.config File

1. In DataMiner, create a new user profile with access to all elements in the DMS. See [Adding a user](xref:Adding_a_user).

    > [!NOTE]
    > This user will be used by the Dashboard Gateway to access the DMA. The username and password of this user will be used in step 4 of this procedure.

2. On the Dashboard Gateway, open the file *web.config* with Notepad.

3. In the file, search for the term *appName = "Dashboard"*.

4. Change the attributes from the “add” tag from:

    ```xml
    <add id="local" connectionstring="localhost" description="Local DataMiner Cluster">
    ```

    to:

    ```xml
    <add id="local" connectionstring="[IP DMA]" user="[name dashboard user]"
    password="[password of Dashboard user]" description="Dashboard DMA">
    ```
