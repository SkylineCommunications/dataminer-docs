---
uid: About_DMS_Maps
---

# About DataMiner Maps

DataMiner Maps is a DataMiner add-on module that allows you to visualize real-time data from the DataMiner System on top of geographical maps provided by online map services. Up to DataMiner 9.5.7, the module allows integration with Google Maps only. From DataMiner 9.5.8 onwards, it is also possible to use MapQuest and OpenStreetMap.

> [!NOTE]
>
> - The DataMiner Maps module requires a special license.
> - DataMiner clients cannot visualize maps without internet access.
> - To use Google Maps, the Google Maps Platform license must be obtained. See also [Configuring the DataMiner Maps host servers](xref:Configuring_the_DataMiner_Maps_host_servers).

> [!CAUTION]
> If you use a DataMiner version prior to DataMiner 10.1.7, we strongly advise that you use HTTPS when you use DataMiner client applications over public internet. If you do not do so, all information – including logon credentials – is sent as plain, unencrypted text over the internet. From DataMiner 10.1.7 onwards, client-server communication is encrypted by default. See also: [Setting up HTTPS on a DMA](xref:Setting_up_HTTPS_on_a_DMA).

DataMiner Maps has a number of interesting features:

- **Custom map layers**

  On top of a map, you can visualize

  - data retrieved from a dynamic table stored in a particular DataMiner element,

  - data stored in properties of DataMiner views, elements and services,

  - fixed overlay images (not just common image formats like JPG, PNG or GIF, but also specialized KML files).

- **Custom markers and lines**

  In a layer, locations can be indicated by means of custom marker images that can even, in some cases, take on alarm severity colors.
  Apart from custom markers, layers can also display lines between two locations.

- **Custom pop-ups**

  The balloon that pops up when you click a particular marker can be customized. It can even contain data retrieved from dynamic tables or properties.

- **Custom JavaScript**

  Custom JavaScript code can be run when a map is opened.

  > [!TIP]
  > See also:
  >
  > - [Switching map configurations by means of JavaScript](xref:Switching_map_configurations_by_means_of_JavaScript)
  > - [Navigating to EPM information from a map using JavaScript](xref:PopupSkeleton_and_PopupDetails#navigating-to-epm-information-from-a-map-using-javascript)

- **Google Street View**

  If you notice the yellow Pegman icon, this means that Google Street View is enabled in your DataMiner Map.

  For more information on how to use Street View, see:

  - [http://maps.google.com/help/maps/streetview/learn/using-street-view.html](http://maps.google.com/help/maps/streetview/learn/using-street-view.html)
