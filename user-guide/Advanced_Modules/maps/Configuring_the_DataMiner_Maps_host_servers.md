---
uid: Configuring_the_DataMiner_Maps_host_servers
---

# Configuring the DataMiner Maps host servers

On a DataMiner Agent, the host servers for DataMiner Maps have to be configured in the file *C:\\Skyline DataMiner\\Maps\\ServerConfig.xml* (which is synchronized throughout the DataMiner System).

If this file does not exist, it will be created automatically the first time DataMiner Maps is opened. It will contain the default configuration needed to load Google Maps without license key.

In this file, you can specify a DataMiner Maps configuration per (virtual) host.

## ServerConfig.xml syntax

*ServerConfig.xml* consists of a `<MapsServerConfig>` tag with a `<VirtualHosts>` subtag, which in turn contains one or more `<VirtualHost>` subtags. These are configured as follows.

### Attributes of the VirtualHost tag

- **hostname**: Used to specify the hostnames (or IP addresses) used in the URL to access DataMiner Maps. Wildcards are supported.

### Subtags of the VirtualHost tag

This subtag contains the `<GoogleMaps>` subtag. See [Attributes of the GoogleMaps tag](#attributes-of-the-googlemaps-tag).

From DataMiner 9.5.8 onwards, it can have the following additional subtags:

| Tag | Description |
|-----|-------------|
| AppVersion | Use this tag to indicate whether only the legacy features for the Maps app should be supported ("0") or whether all new features (from DataMiner 9.5.8 onwards) should be supported ("1"). |
| MapsProvider | Use this tag to indicate whether to use Google Maps ("gmaps") or OpenStreetMap via the MapQuest API ("osm"). |
| MapQuest | To use OpenStreetMap, specify an API key with the *key* attribute of this tag. |
| OWM | To use the OpenWeatherMap features in combination with OpenStreetMap, specify an additional API key with the *key* attribute of this tag. |
| TilesServer | Available from DataMiner 10.0.8 onwards. Can be used to make Open Street Maps available offline. However, this is only possible if *AppVersion* is set to "1" and *MapsProvider* is set to "OSM". For more information on how to configure this, see [Configuration of the TilesServer tag](#configuration-of-the-tilesserver-tag). |

> [!NOTE]
> If app version 1 is used, custom icons must be placed in the folder *C:\\Skyline DataMiner\\Webpages\\Maps\\v1\\images\\icons*.

### Attributes of the GoogleMaps tag

- **key**: Premium Google Maps JavaScript API key.

  > [!NOTE]
  > For development and testing purposes, you can open a map without a key, using a URL like `http://localhost/` or `http://servername/`. However, note that in that case you will only have access to limited functionality of the map.

- **client**: If you have a "Google Maps APIs Premium Plan" license, you can specify your client ID in this attribute instead of specifying an API key.

- **channel**: Business customers can optionally specify a channel for Channel Reports. To track usage across different applications using the same client ID, you may provide an optional channel parameter. By specifying different channel values for different aspects of your application, you can determine how your application is used.

- For more info about Google Maps licensing, see <http://www.google.com/enterprise/mapsearth/products/mapsapi.html>

### Configuration of the TilesServer tag

The *TilesServer* tag contains a *BaseLayers* tag which in turn contains a *BaseLayer* tag for each custom base layer. This *BaseLayer* tag has the following attributes.

| Attribute | Description |
|-----------|-------------|
| key | Key used to refer to a base layer acting as default map (in the *MapType* tag of a map configuration file). |
| name | The name of the base layer that will be displayed in the base map selection box. |
| url | The URL of the layer tiles exposed by the offline maps server. To get this URL, make sure the offline maps server is installed and configured as detailed in [Installation and configuration of an offline maps server](#installation-and-configuration-of-an-offline-maps-server). Then click on the *XYZ* links in the services lists of the map styles you want to use to see the tiles URLs. For example: `http://<maps server name or IP>:<host port>/styles/dark-matter/{z}/{x}/{y}.png` |

> [!TIP]
> See also: [Configuration to make Open Street Maps accessible offline](#configuration-to-make-open-street-maps-accessible-offline)

## Installation and configuration of an offline maps server

From DataMiner 10.0.8 onwards, Open Street Maps can be configured to be available offline. For this purpose, the *TilesServer* tag must be correctly configured in ServerConfig.xml, as detailed in [ServerConfig.xml syntax](#serverconfigxml-syntax). In addition, the offline server must be installed and configured. To do so:

1. Download Docker according to the instructions on the following page: <https://docs.docker.com/get-docker/>

1. Run the installation package, making sure to select *Linux containers* when appropriate.

1. Once Docker has been installed, open a command prompt and run the following command:

   ```txt
   docker run -idt -v <mbtiles folder>:/data -p <host port>:80 --name <container name> klokantech/openmaptiles-server
   ```

   This will:

   - Download a maps server image (klokantech/openmaptiles-server).

   - Create a container with the name `<container name>`.

   - Map a folder on your PC (`<mbtiles folder>`) to the */data* folder inside the container.

   - Map port 80 of the server inside the container to the port `<host port>` of your machine.

   In the `<mbtiles folder>`, you can add the map tile files that you can download for specific regions of the world from the following page: <https://openmaptiles.com/downloads/planet/>

1. To check if the creation of the container succeeded, run the following command:

   ```txt
   docker ps -a --filter "ancestor=klokantech/openmaptiles-server"
   ```

   This should return a row with the container information.

1. Start the container with the command `docker start <container name>`.

1. Download the satellite tiles from the page <https://openmaptiles.com/downloads/dataset/satellite-lowres/#0.23/0/-26> and save them in the mapped */data* folder.

1. Go to `http://localhost:<host port>/` and follow the instructions:

   1. In the *Region* step, select the region you want to use. By way of a test, you can select the Zurich region, as all the standard layers are free to use. This will download the associated vector mbtiles file in the mapped */data* folder.

   1. In the *Style* step, select the styles you want to use.

   1. In the *Settings* step, select the type of rendered data to be served. Make sure to have the raster option enabled at least.

   1. When you reach the *Publish* step, a config.json file containing your preferences is added to the mapped */data* folder.

1. Test the different styles to make sure everything is working correctly.

## Examples

### Production agent

```xml
<MapsServerConfig>
   <VirtualHosts>
      <VirtualHost hostname="*">
         <GoogleMaps client="YOUR_CLIENT_ID"/>
      </VirtualHost>
   </VirtualHosts>
</MapsServerConfig>
```

### Two production agents with different channel reporting

```xml
<MapsServerConfig>
   <VirtualHosts>
      <VirtualHost hostname="agent1.domain.com">
         <GoogleMaps client="YOUR_CLIENT_ID" channel="CHANNEL_AGENT1"/>
      </VirtualHost>
      <VirtualHost hostname="agent2.domain.com">
         <GoogleMaps client="YOUR_CLIENT_ID" channel="CHANNEL_AGENT2"/>
      </VirtualHost>
   </VirtualHosts>
</MapsServerConfig>
```

### Staging and production agents

```xml
<MapsServerConfig>
   <VirtualHosts>
      <VirtualHost hostname="staging.domain.com">
         <GoogleMaps key="MY_KEY"/>
      </VirtualHost>
      <VirtualHost hostname="*.domain.com">
         <GoogleMaps client="YOUR_CLIENT_ID"/>
      </VirtualHost>
   </VirtualHosts>
</MapsServerConfig>
```

### Configuration using OpenStreetMap

```xml
<MapsServerConfig>
   <VirtualHosts>
      <VirtualHost hostname="*">
         <AppVersion>1</AppVersion>
         <MapsProvider>osm</MapsProvider>
         <GoogleMaps key=""/>
         <MapQuest key="My_API_key"/>
         <OWM key=""/>
      </VirtualHost>
   </VirtualHosts>
</MapsServerConfig>
```

### Configuration to make Open Street Maps accessible offline

```xml
<MapsServerConfig>
   <VirtualHosts>
      <VirtualHost hostname="*">
         <AppVersion>1</AppVersion>
         <MapsProvider>OSM</MapsProvider>
         <TilesServer>
            <BaseLayers>
               <BaseLayer key="..." name="..." url="..."/>
               <BaseLayer key="..." name="..." url="..."/>
               <BaseLayer key="..." name="..." url="..."/>
            </BaseLayers>
         </TilesServer>
         <GoogleMaps key="..."/>
         <MapQuest key="..."/>
         <OWM key="..."/>
      </VirtualHost>
   </VirtualHosts>
</MapsServerConfig>
```
