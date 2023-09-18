---
uid: Connector_help_Imagine_Communications_Landmark_PXF
---

# Imagine Communications Landmark PXF

The Imagine Communications Landmark PXF connector can be used to efficiently ingest playlists and check subtitle availability.

## About

This connector can be used to parse the information present in the PXF files (XML data in PXF wrapper). This information consists of the events that are to be played out. Each playout event has a corresponding subtitle file (CHK file). The connector will also check if the corresponding subtitle file is available in the file system and then subsequently check for the defined languages present within the subtitle file.

There are promo events in the PXF files that the connector will ignore in the program tables. It can take in up to four days of PXF files and will provide a summary of missing languages and files for the corresponding events on the "General" page.

The connector provides a **Live DPI (Digital Program Insertion) Triggers** page, which contains the **SCTE35 Promo Live Table**. This table lists all the promos of the current day (Day 1).

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Virtual Main Connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

This page summarizes the **missing languages** and **missing files** for four days of playlists (i.e. the **D1**, **D2**, **D3** and **D4** playlist). It also contains a count of the number of events with missing languages per day for all four days.

### D1 Playlist

This page contains information on the D1 Playlist, i.e. the playlist of the current day.

On the left side of this page, you can check which program is currently running. In this same column, the **D1 Playlist Refresh** and **D1 Subtitle Refresh** buttons allow you to refresh the D1 program table's playlist and subtitles, respectively. The **D1 Preload Playlist** page button displays the **D1 Preload Program Table**, with the **D1 Preload Refresh** button. This allows you to preload the playlist of the current day in advance to avoid any gap time in monitoring.

On the right side, the **D1 Filename** parameter displays the PXF file name that is currently being parsed/read. Below this, the **D1 Refresh Status** displays the progress of the playlist or the subtitle refresh of the current day.

### D2 Playlist

This page contains information on the day 2 (D2) playlist.

The **D2 Filename** parameter displays the PXF file name that is being parsed/read to display information in the **D2 Program Table**. Below this, the **D2 Refresh Status** displays the progress of the playlist or the subtitle refresh of the current day.

The **D2 Playlist Refresh** and **D2 Subtitle Refresh** buttons allow you to refresh the D2 program table's playlist and subtitles, respectively.

### D3 Playlist

This page contains information on the day 3 (D3) playlist.

The **D3 Filename** parameter displays the PXF file name that is being parsed/read to display information in the **D3 Program Table**. Below this, the **D3 Refresh Status** displays the progress of the playlist or the subtitle refresh of the current day.

The **D3 Playlist Refresh** and **D3 Subtitle Refresh** buttons allow you to refresh the D3 program table's playlist and subtitles, respectively.

### D4 Playlist

This page contains information on the day 4 (D4) playlist.

The **D4 Filename** parameter displays the PXF file name that is being parsed/read to display information in the **D4 Program Table**. Below this, the **D4 Refresh Status** displays the progress of the playlist or the subtitle refresh of the current day.

The **D4 Playlist Refresh** and **D4 Subtitle Refresh** buttons allow you to refresh the D4 program table's playlist and subtitles, respectively.

### Live DPI Triggers

This page contains the **SCTE35 Promo Live Table**. This table lists all the promos of the current day (Day 1).

### Settings

On this page, you can set the **Time Zone (+/-hh:mm:ss).** You can also set **playlist file path details** and **subtitle file path details** to access and parse the files from the FTP server.

The **Language Settings** page button displays parameters that allows you to enable different languages to monitor. However, the changes will only be applied after you click the **Apply Language Settings** button.

### Exceptions

This page consists of three exception tables, namely the **Event Name Exception Table**, **Filename Exception Table (FN)** and **Event Time Exception Table**. There is also a page button that displays the **Default Exceptions Table**.

You can add exceptions to these tables by clicking the **Add Row** button located above each table. Once an exception has been added, you can then implement it by clicking the **Implement** button. By setting these exceptions, you can monitor or ignore events in the **program tables** based on an event name, a filename or a specific time slot. However, using the **Default Exceptions Table**, you can ignore a particular language entirely for all four playlists at once.
