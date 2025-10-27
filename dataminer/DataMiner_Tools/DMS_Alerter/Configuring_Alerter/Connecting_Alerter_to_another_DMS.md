---
uid: Connecting_Alerter_to_another_DMS
---

# Connecting Alerter to another DataMiner System

Do the following if you want Alerter to connect to another DataMiner System.

1. Go to *Settings \> DMS Connections*.

1. In the *Account* section, click *Edit Account*.

1. In the *Add Connection* dialog box, make the necessary changes to the following settings.

    - **Name of DMS**: The name of the DataMiner System. You can enter an arbitrary name.

    - **Host**: The name or the IP address of the DataMiner Agent to which you want to connect.

1. If you want to change the default connection settings, click *Advanced*, make the necessary changes to the settings, and click *OK*.

1. In the *Add Connection* dialog box, click *OK*.

1. In the *Options* dialog box, click *OK*.

> [!NOTE]
>
> - In the DMS Connections tab, the option *Show message when SLAlerter loses connection* determines whether users will be notified when the connection to the DMS is lost. By default, this option is enabled.
> - If the connection to the DMS is lost, this is logged in the Event Viewer with an "SLAlerter lost connection" message. In the Alerter application itself, the user will be redirected to the login screen, in the same manner as when the connection is lost in DataMiner Cube.
