---
uid: Connector_help_Arris_DreamGallery
---

# Arris DreamGallery

The Arris DreamGallery connector is used to monitor different aspects of the DreamGallery System.

## About

The Arris DreamGallery allows the user to monitor the DreamGallery System. The monitored data will be displayed on multiple pages regarding the subject of what is monitored.

This connector uses a serial connection to set up the SSH Connection, will use http and MySQL.

## Installation and configuration

### Creation

This connector uses a **Serial** connection and needs following user information:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*
- **IP port**: the port of the connected device, default value: *22*
- **Bus address**: the bus address of the connected device

There will need to be two elements created from the **Arris DreamGallery Varnish** protocol, one for the Backup server and one for the Portal Generator server.

The *DataMiner*/*Element* Id of each of these two will need to be filled in on the configurations pop-up page of the Varnish page.

## Usage

### TomCat DreamGallery page

On the TomCat DreamGallery page the the status of the TomCat, DreamGallery and the DreamGallery Database can be viewed for the Main, Backup and the Portal Generator. The status will be *Running* or *Not Running*.

The **Connected Clients** group box displays the number of connected clients for the Comet Registry and the Comet server.

On the bottom of the page there is a page button available that will open up a pop-up page where the IP+port (e.g. *172.16.1:29:8080*) can be filled in for each of the servers on the **TomCat DreamGallery** page.

### Varnish page

On Varnish page the Varnish stats are available for the Main, Backup and the Portal Generator.

There is a page button available that will open up a pop-up page where the configurations can be filled in:

- **User Name** : The user name to set up the SSH connection with the main server.
- **Password** : The password to set up the SSH connection with the main server.
- **Portal Server (Backup)** : The *DMAID*/*ElementID* of the element that was created with the **Arris DreamGallery Varnish** protocol for the Backup server.
- **Portal Generator (Varnish)** : The *DMAID*/*ElementID* of the element that was created with the **Arris DreamGallery Varnish** protocol for the Portal Generator server.

### Server Status

On the Server Status page the Server Status Table can be viewed. On this table there are global status variables viewable with the value they have in the **Main** and the **Backup** server. The user can add extra **Server Status Variables** by writing the name of the global status variable in the **Add Status Variable** parameter. A **Server Status Variable** can also be *removed* by clicking on the **Delete** button.

The Configuration page button will open up a pop-up page where the settings for the database connection can be filled in.

### Settings Page

On this page the settings to set up the SSH connection are available. The **User Name** and **Password** parameter need to be filled in, in order for the SSH connection to be set up.

Once this connection is set up, the varnish stats can be retrieved.
