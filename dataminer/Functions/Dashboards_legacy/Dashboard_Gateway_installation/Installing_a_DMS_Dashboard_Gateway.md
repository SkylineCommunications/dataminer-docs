---
uid: Installing_a_DMS_Dashboard_Gateway
---

# Installing a DMS Dashboard Gateway

> [!IMPORTANT]
> This information is applicable to the DMS Dashboards module, which is being retired as of DataMiner version 10.4.x. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement). We recommend using the [Dashboards app](xref:newR_D) instead.

It is possible to give users access to the legacy DataMiner Dashboards even if they do not have access to DataMiner, by means of a DMS Dashboard Gateway.

For a Dashboard Gateway to function correctly, an additional Windows component, Internet Information Services, must also be installed. On some Windows versions this is installed by default, but on others you will need to install it yourself.

## Installing a Dashboard Gateway on Windows Server 2012

To install a Dashboard Gateway on Windows Server 2012, you must first install IIS, then install the dashboards, configure IIS, and finally configure the web.config file.

### Installing IIS

1. Go to *Start \> Server Manager*.

1. On the *Dashboard* page, click *Add roles and features*.

1. In the *Add Roles and Features Wizard*, click *Next* to go to the *Server Roles* step.

1. On the *Server Roles* tab, select *Web Server (IIS)* and *Management Tools*.

1. Expand the *Application Development* node to select *ASP.NET 3.5*, *ASP.NET 4.5*, *.NET Extensibility 3.5*, and *.NET Extensibility 4.5*.

1. Click *Install* to start the installation process.

1. After the installation, which can take a few minutes, open the start menu and type "*iis manager*" to open the Internet Information Services (IIS) Manager.

1. In the navigation menu on the left, select *Application Pools*.

1. Right-click the *DefaultAppPool* and select the item *Advanced Settings*.

1. In the Process model section, set the item *Idle Time-out (minutes)* to 0 and click *OK* to confirm.

1. Right-click the *DefaultAppPool* again and select the item *Recycling*.

1. Disable the property *Regular time interval (in minutes)*.

### Installing the dashboards

1. Copy the directory `C:\Skyline DataMiner\Webpages\Dashboards` from the DataMiner Agent to a location on the DataMiner Gateway, such as `C:\Skyline DataMiner`.

1. Remove all the files and subfolders in the directory *...\\Dashboards\\db*.

### Configuring IIS

1. Go to *Start \> Control Panel \> Administrative Tools \> Internet Information Services (IIS) Manager*.

1. Click the root (name of the DataMiner Gateway) and select *Feature Delegation*.

1. For the items *Handler Mappings*, *Modules*, *Authentication - Anonymous* and *Authentication - Windows*, change the delegation from *Read Only* to *Read/Write*.

1. In the navigation menu on the left, select *COMPUTERNAME \> Web Sites \> Default Web Site*.

1. Right-click and select *Add Virtual Directory*.

1. Fill in the alias, "Example dashboards", and the correct path to the dashboard folder.

1. Right-click the new item and select *Convert to Application*.

1. Click *OK*.

1. Select *COMPUTERNAME \> Web Sites \> Default Web Site \> Dashboards* in the navigation menu on the left.

1. In the *HTTP Features* section of the *Feature View* tab, double-click the item *Mime Types*.

1. To the list of Mime Types, add the Mime Type *fcss* by right-clicking in the list and selecting *Add*.

1. Choose the file name extension *fcss* and the Mime Type *text/plain*, and click *OK* to confirm.

### Configuring the web.config file

1. In DataMiner, create a new user profile with access to all elements in the DMS. The user also has to have the permission *Modules* > *System configuration* > *Tools* > *Admin tools*. See [Adding a user](xref:Adding_a_user).

   > [!NOTE]
   > This user will be used by the Dashboard Gateway to access the DMA. The username and password of this user will be used in step 4 of this procedure.

1. On the Dashboard Gateway, open the file *web.config* with Notepad.

1. In the file, search for the term *appName = "Dashboard"*.

1. Change the attributes from the "add" tag from:

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

1. Click *Turn Windows features on or off*.

1. In the feature list, select *Internet Information Services*.

1. In the *World Wide Web* subdirectory *Application Development Features*, select the following features:

   - .Net Extensibility

   - ASP

   - ASP.NET

   - ISAPI Extensions

   - ISAPI Filter

1. Also under *World Wide Web*, select the checkbox of the directory *Security*.

1. Click *OK* to start the installation.

1. After the installation, which can take several minutes, go to *Start \> Control Panel \> Administrative Tools \> Internet Information Services (IIS) Manager*.

1. In the navigation menu on the left, select *Application Pools*.

1. Right-click the *DefaultAppPool* and select the item *Advanced Settings*.

1. Set the item *Idle Time-out (minutes)* in the Process model section to *0* and click *OK* to confirm.

1. Right-click the *DefaultAppPool* again and select the item *Recycling*.

1. Disable the property *Regular time interval (in minutes)*.

### Installing the dashboards

1. Copy the directory `C:\Skyline DataMiner\Webpages\Dashboards` from the DataMiner Agent to a location on the DataMiner Gateway, such as `C:\Skyline DataMiner`.

1. Remove all the files and subfolders in the directory *...\\Dashboards\\db*.
