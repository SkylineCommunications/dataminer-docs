---
uid: Connector_help_Newtec_SatLink_Manager
---

# Newtec SatLink Manager

The **Newtec SatLink Manager** connector is used to communicate with the **Northbound Interface API** of the **SLR/SLM** (SatLink Reservator/SatLink Manager).

## About

The Newtec SatLink Manager connector uses **SOAP** calls to retrieve data from the SLR.

There are different version ranges of this connector based on implemented features and supported SLM API:

- 3.0.0.*: supports SLR API 1.1
- 4.0.0.*: supports SLR API 1.1 and creates DVEs for each VN
- 4.1.0.*: supports SLM API 2.0 and creates DVEs for each VN

Currently, the following calls are implemented:

- **Session interface**:

  - BookSession (contribution, distribution, dual hop, single hop and bidirectional)
  - CheckSession
  - StartSession
  - StopSession
  - CancelSession
  - FindSession and FindSessions
  - UpdateSession (3.0.0.5 and higher)
  - RequestModulatorAvailability (3.0.0.\* - 4.0.0.\*)
  - RequestTransmitAvailability (replaces RequestModulatorAvailability 4.1.0.\* and higher)
  - RequestDemodulatorAvailability (3.0.0.\* - 4.0.0.\*)
  - RequestReceiveAvailability (replaces RequestModulatorAvailability 4.1.0.\* and higher)

- **Reservation interface**:

  - FindReservations

- **Provisioning interface**:

  - GetAllTerminals
  - GetAllModulators (4.1.0.\* and higher)
  - GetAllDemodulators (4.1.0.\* and higher)
  - GetAllVirtualNetworks
  - GetAllSessionProfiles

## Installation and configuration

### Creation

This connector uses an HTTP connection and requires the following input during element creation:
**HTTP CONNECTION:**

- **IP address/host:** The polling IP of the device, eg. *10.11.12.13*
- **IP port:** The IP port of the destination, by default *80*

## Usage

Booking sessions is done in combination with an interactive automation script. The script will pass which command needs to be executed and what the values are that need to be used in the command. More information about the usage in combination with an interactive automation script can be found in the "Notes" section.

### Sessions

The **sessions** page displays all sessions that are currently available in the **SLR**. The sessions are displayed in the **Sessions** table.

A session consists of 1 or 2 **links**, with each link having a **source** and 1 or multiple **destinations**. The **links**, **sources** and **destinations** are also displayed on this page in their respective tables.

### Reservations

The **reservations** page displays all reservations that are currently available in the SLR. This can be reservations linked to a specific session or stand alone reservations. The reservations are displayed in the **Reservations** table.

A reservation consists of a **transmitter** and a **receiver**. These are also displayed in their respective table on this page.

### Terminals

The **terminals** page displays all the terminals that are provisioned in the SLR. Each terminal can have multiple **modulators** and **demodulators**. All this data is displayed on the Terminals page in the **Terminals**, **Modulators** and **Demodulators** tables.

### Profiles

The **profiles** page displays the **Session Profiles** table. This table contains all the session profiles that are provisioned on the SLR and can be used when booking a session.

### Webpage

This page can be used to access the **web interface** of the SLR. Note that the client machine has to be able to access the device, otherwise it won't be possible to open the web interface.

## Notes

If a command needs to be triggered from an interactive automation script or another external source, then a string containing all information about the command needs to be set on PID 101 of the SLM connector. Each command expects a certain format to make sure that the connector has all necessary information to create the request that needs to be sent to the SLR.

An overview of the commands that can be triggered from an external source and the format that needs to be used can be found below:

- **Book session:**

  - Format: *booksession\|virtualnetwork=xxx;start=yyyy-MM-dd HH:mm:ss;stop=yyyy-MM-dd HH:mm:ss;sessionprofile=xxx;link=src1:dst1,dst2\|src2:dst3,dst4*

  - If there are 2 links, then they need to be separated by a '\|' character

  - There are extra parameters that can optionally be passed: serviceid, servicename, and servicedescription

- **Start session:**

  - Format: *startsession\|id=xxx;multicastaddress=xxx*

- **Stop session:**

  - Format: *stopsession\|id=xxx*

- **Cancel session:**

  - Format: *cancelsession\|id=xxx*

- **Check session:**

  - Format: *checksession\|virtualnetwork=xxx;start=yyyy-MM-dd HH:mm:ss;stop=yyyy-MM-dd HH:mm:ss;sessionprofile=xxx;link=src1:dst1,dst2\|src2:dst3,dst4*

  - Similar remarks as for booksession

- **Find session:**

  - Format: *findsession\|id=xxx*

- **Find sessions:**

  - Format: *findsessions\|*

- **Find reservations:**

  - Format: *findreservations\|* or *findreservations\|start=yyyy-MM-dd HH:mm:ss;stop=yyyy-MM-dd HH:mm:ss*

- **Request Modulator/Transmit Availability:**

  - Format: requestmodulatoravailability\|sessionprofile=xxx;start=yyyy-MM-dd HH:mm:ss;stop=yyyy-MM-dd HH:mm:ss;virtualnetwork:xxx

  - Format: requesttransmitavailability\|sessionprofile=xxx;start=yyyy-MM-dd HH:mm:ss;stop=yyyy-MM-dd HH:mm:ss;virtualnetwork:xxx

- **Request Demodulator/Receive Availability:**

  - Format: requestdemodulatoravailability\|sessionprofile=xxx;start=yyyy-MM-dd HH:mm:ss;stop=yyyy-MM-dd HH:mm:ss;virtualnetwork:xxx

  - Format: requestreceiveavailability\|sessionprofile=xxx;start=yyyy-MM-dd HH:mm:ss;stop=yyyy-MM-dd HH:mm:ss;virtualnetwork:xxx
