---
uid: deploying_srm
---

# Deploying the SRM framework

1. Ensure that a DataMiner version is installed that is compatible with the SRM version you want to deploy. Check the SRM release notes to see which minimum DataMiner version is required. Contact Skyline Communications to check if any additional components need to be installed in your system.

   > [!NOTE]
   > The SRM framework requires an [Elasticsearch database](xref:Elasticsearch_database).

1. Download the SRM package from [DataMiner Dojo](https://community.dataminer.services/downloads/).

1. Double-click the SRM package, and install the package in the same manner as a DataMiner upgrade.

   > [!NOTE]
   > DataMiner will restart during the installation of the package.

   > [!TIP]
   > See also: [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent)

1. Create a view structure in the Surveyor to organize your elements and services.

   As shown in the example below, you can use several subviews to categorize different types of services:

   ```txt
   1 – Resources
   2 – Elements
   3 – Services
       Gold
       Silver
       Bronze
   ```

   > [!TIP]
   > See also:
   >
   > - [Creating a view](xref:Managing_views#creating-a-view)
   > - [Naming of elements, services, views, etc.](xref:NamingConventions#naming-of-elements-services-views-etc)

1. If you are using a version of the SRM framework prior to SRM 1.2.19, create an element with the name *SRM Log Manager*, using the protocol *Generic Bookings Log*.

   > [!TIP]
   > See also: [Adding elements](xref:Adding_elements)

1. If you are using a version of the SRM framework prior to SRM 1.2.19, on the *Configuration* page of the *SRM Log Manager* element, set the *Path* parameter to a shared folder accessible from both the client machine and the DataMiner servers.

1. Create an element with the name *SRM Booking Manager*, using the protocol *Skyline Booking Manager* (Production version).

1. In the visual overview of the *Skyline Booking Manager* element, go to *Config* > *General* and configure the following settings:

   - Set *Application Setup* > *Default Virtual Platform* to the correct [Virtual Platform](xref:srm_instantiations#virtual-platform) identifier, e.g. *SRM*, *Default*, *Satellite Downlink*, etc.

   - Set *Services* > *App. Services View* to the name of the view you created to contain services (e.g. "3 - Services").

   - Set *History and Logs* > *Booking Logging Location* to a shared folder accessible from both the client machine and the DataMiner servers, so that users will be able to view the log files. See [Configuring SRM logging](xref:SRM_logging_config).
