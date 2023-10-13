---
uid: ZiineDemoSystem
---

# Ziine Demo System

The Ziine Demo System allows you to explore many different DataMiner features in a functioning DataMiner System. This includes the standard DataMiner monitoring and Visual Overview features, and also several DataMiner Solutions and standard apps.

> [!TIP]
> See also: [Easy access to the DataMiner Live Demo System](https://community.dataminer.services/video/easy-access-to-the-dataminer-live-demo-system/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Connecting to Ziine

To connect to the Ziine Demo System:

1. If you do not have the DataMiner Cube desktop application installed yet:

   1. Go to [dataminer.services](https://dataminer.services).
   1. Log on using your dataminer.services account.
   1. In the top-right corner, select *Install DataMiner Cube > Desktop installation*.

   > [!TIP]
   > See also: [Installing the DataMiner Cube desktop application](xref:Installing_the_DataMiner_Cube_desktop_application)

1. Open the DataMiner Cube desktop application.

1. Connect to the DataMiner System "the [Ziine Demo System](xref:ZiineDemoSystem)" as described under [Opening the desktop application](xref:Opening_the_desktop_app).

   > [!NOTE]
   > The Ziine hostname is `https://ziine.skyline.be/`.

## Having problems connecting?

1. Check the connection settings and make sure *Connection Type* is set to *Auto*. See [Overriding the default connection type](xref:Logging_on_to_DataMiner_Cube#overriding-the-default-connection-type).

   *Connection Type* must be set to *Auto* because all public Agents at Skyline have a unique port for their .NET Remoting connection instead of the default port *8004*.

1. Make sure the authentication pop-up window is triggered. If it is not shown automatically as soon as you try to connect, you can trigger it manually from the login screen:

   1. Fill in your username, but **do not fill in a password**.

   1. Click the blue arrow icon to log on.

      ![Logging on to Ziine](~/user-guide/images/ziine_login.png)
