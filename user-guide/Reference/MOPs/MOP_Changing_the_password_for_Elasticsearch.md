---
uid: MOP_Changing_the_password_for_Elasticsearch
---

# Changing the password for Elasticsearch

The procedure below details how you can change the password for an Elasticsearch database used by a specific DataMiner Agent.

## Requirements

- Access to the server with administrator rights. This requires a connection dedicated completely or partially to this procedure, via VPN or local network.
- A sufficiently large maintenance window, especially for large DataMiner clusters, as the steps detailed below need to be done for each DMA, even in Failover systems.

## Procedure

### Check the requirements and connection

#### Prerequisites

- Remote access to the system
- User credentials with administrator rights
- Elasticsearch database is enabled in DataMiner
- DataMiner version 10.0.11, 10.1.0 or higher is installed
- Basic Elasticsearch knowledge
- Basic DataMiner knowledge

#### Steps

1. Connect to the system via the designated VPN or host PC.
1. Test if you can access DataMiner Cube.
1. Check if the system is using the correct DataMiner version.
1. Start Kibana from `C:\Program Files\Elasticsearch\Kibana\bin\kibana.bat`.
1. Wait until the last line in the command prompt reads `Status changed from red to green – Ready`.

### Create a new username and password in Kibana

#### Prerequisites

- All previous requirements are met
- Kibana is started and ready

#### Steps

1. Open a browser and go to `http://127.0.0.1:5601`.
1. Log in with the current username and password.
1. In the menu on the left, go to *Management*.
1. Go to *Users* and create a new user. Make sure "superuser" is selected as the role of the new user.

### Update the Elasticsearch password using the SLNetClientTest tool

#### Prerequisites

- All previous requirements are met
- The new username and password have been created

#### Steps

1. Right-click the *DataMiner Taskbar Utility* icon and select *Launch > Tools > Client Test*.
1. In the *Connection* menu, select *Connect*.
1. In the *Connect* window, select the DMA, specify credentials with administrator rights, and click *Connect*.
1. Go to the *Build Message* tab of the main window.
1. In the *Message Type* drop-down list, select "UpdateDatabaseSettingsMessage".
1. Change the following attributes:

    - *ChangedFields*: PWD
    - *DatabaseConfigType*: SearchDatabase
    - *PWD*: [the password of your choice]

1. Click *Send message*.

### Update the username in DB.xml

#### Prerequisites

- All previous requirements are met
- The password has been updated

#### Steps

1. Stop the DMA.
1. Go to `C:\Skyline DataMiner\` and open the *DB.xml* file.
1. Look for the `<Database>` tag with `type="Elasticsearch"`, and change the contents of the `<UID>` tag below it to the new username.
1. Save the file.
1. Restart the DMA.
1. When the DMA is online again, confirm that there are no errors in the Alarm Console or in the *SLDBConnection* log file.

## Time estimate

| Item | Activity | Duration |
|------|----------|----------|
| 1    | Checking the requirements            | 5 min. |
| 2    | Creating a new username and password | 10 min. |
| 3    | Updating the password                | 10 min. |
| 4    | Updating the username                | 10 min. |

> [!NOTE]
> These activities need to be carried out for each DMA separately, so this may take some time for large DataMiner clusters.
