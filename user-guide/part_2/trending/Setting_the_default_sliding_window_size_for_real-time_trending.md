---
uid: Setting_the_default_sliding_window_size_for_real-time_trending
---

# Setting the default sliding window size for real-time trending

It is possible to configure the default size of the sliding window for real-time trending for a particular DMA. All elements on that DMA will then inherit this default value, unless it is overridden on element level.

> [!NOTE]
> The user permission *Configure trend templates* is required to modify this setting.

To configure the default size:

- From DataMiner 9.6.6 onwards:

    1. Go to System Center \> *System settings* > *time to live*

    2. Under *Trending*, in the *Real-time* box, specify the new window size.

        > [!NOTE]
        > At present, trending information is not saved in the indexing database. As such, if your DMS uses an indexing database, only the settings in the *Local* column of the *time to live* page will be taken into account for trending.

    3. Click the *Apply* button.

    > [!NOTE]
    > For more information on the TTL configuration, including how to specify an override for a specific protocol or protocol version, see [Specifying TTL overrides](xref:Specifying_TTL_overrides).

- In DataMiner versions prior to DataMiner 9.6.6:

    1. In the Cube navigation pane, click the apps button and select *System Center*.

    2. In System Center, select *System settings* > *trending*.

    3. Under *Trend time span*, use the up and down buttons to enter a different number of hours.

    4. In the lower right corner, click *Apply size*.

    > [!NOTE]
    > - In some older DataMiner versions, this setting may not be available in Cube. In that case, this can be configured in the file *DBMaintenanceDMS.xml*. For more information, see [DBMaintenance.xml and DBMaintenanceDMS.xml](xref:DBMaintenance_xml_and_DBMaintenanceDMS_xml#dbmaintenancexml-and-dbmaintenancedmsxml).
