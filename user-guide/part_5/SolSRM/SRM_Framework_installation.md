## SRM Framework installation

To install the SRM Framework:

1. Ensure that a DataMiner version is installed that is compatible with the SRM Framework. Contact Skyline Communications to check if any additional components need to be installed in your system.

    > [!NOTE]
    > The SRM Framework requires an Elasticsearch database (see [DataMiner Indexing Engine](../../part_3/databases/DataMiner_Indexing_Engine.md)).

2. Double-click the SRM package, and install the package in the same manner as a DataMiner upgrade.

    > [!TIP]
    > See also:
    > [Upgrading a DataMiner Agent](../../part_3/DataminerAgents/Upgrading_a_DataMiner_Agent.md)

3. Create a view structure in the Surveyor to organize your elements and services.

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
    > -  [Creating a view](../../part_2/views/Managing_views.md#creating-a-view)
    > -  [Naming of elements, services, views, etc.](../../part_7/NamingConventions/NamingConventions.md#naming-of-elements-services-views-etc)

4. Create an element with the name *SRM Log Manager*, using the protocol *Generic Bookings Log*.

    > [!TIP]
    > See also:
    > [Adding and deleting elements](../../part_2/elements/Adding_and_deleting_elements.md)

5. On the *Configuration* page of the *SRM Log Manager* element, set the *Path* parameter to a shared folder accessible from both the client machine and the DataMiner servers.

6. Create an element with the name *SRM Booking Manager*, using the protocol *Skyline Booking Manager* (Production version).

7. In the visual overview of the *Skyline Booking Manager* element, go to *Admin* > *Config* > *Application Setup* and configure the following settings:

    - Set *Default Virtual Platform* to the correct Virtual Platform identifier, e.g. *SRM*, *Default*, *Satellite Downlink*, etc.

        > [!NOTE]
        > A Virtual Platform is used to group all SRM components (resources, bookings, etc.) belonging to the same domain. 

    - Set *Services* > *App. Services View* to the name of the view you created to contain services.

    - Set *History and Logs* > *Booking Logger Element* to *SRM Log Manager*.
