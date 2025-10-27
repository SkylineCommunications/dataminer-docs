---
uid: Setting_the_default_sliding_window_size_for_real-time_trending
---

# Setting the default sliding window size for real-time trending

It is possible to configure the default size of the sliding window for real-time trending for a particular DMA. All elements on that DMA will then inherit this default value, unless it is overridden on element level.

> [!NOTE]
> The user permission *Configure trend templates* is required to modify this setting.

To configure the default size:

1. Go to System Center \> *System settings* > *time to live*

   > [!NOTE]
   > If your DMS uses [Storage as a Service](xref:STaaS), TTL settings are automatically configured and may not be available for manual adjustment on the *System settings* > *time to live* tab in System Center, depending on your DataMiner version<!--RN 39173 + 42333-->.

1. Under *Trending*, in the *Real-time* box, specify the new window size.

   > [!NOTE]
   > At present, trending information is not saved in the indexing database. As such, if your DMS uses an indexing database, only the settings in the *Local* column of the *time to live* page will be taken into account for trending.

1. Click the *Apply* button.

> [!NOTE]
> For more information on the TTL configuration, including how to specify an override for a specific protocol or protocol version, see [Specifying TTL overrides](xref:Specifying_TTL_overrides).
