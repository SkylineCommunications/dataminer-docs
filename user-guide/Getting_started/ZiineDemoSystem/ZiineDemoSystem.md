---
uid: ZiineDemoSystem
---

# Ziine Demo System

The Ziine Demo System allows you to explore many different DataMiner features in a functioning DataMiner System. This includes the standard DataMiner monitoring and Visual Overview features, and also several DataMiner Solutions and standard apps.

## Connecting to Ziine

To connect to the Ziine Demo System:

1. If you do not have the DataMiner Cube desktop application installed yet:

   1. Go to [dataminer.services](https://dataminer.services).
   1. Log on using your DataMiner Cloud Platform account.
   1. In the top-right corner, select *Install DataMiner Cube > Desktop installation*.

   > [!TIP]
   > See also: [Installing the DataMiner Cube desktop application](xref:Installing_the_DataMiner_Cube_desktop_application)

1. Open the DataMiner Cube desktop application.

1. Connect to the DataMiner System "the [Ziine Demo System](xref:ZiineDemoSystem)" as described under [Opening the desktop application](xref:Opening_the_desktop_app).

   > [!NOTE]
   > The Ziine hostname is `https://ziine.skyline.be/`.

## Having problems connecting?

1. Check the connection settings.

   All public Agents at Skyline have a unique port for their .Net remoting connection instead of default port _8004_. Therefore it is important that the _Connection Type_ is set to _Auto_. [Logging on to DataMiner Cube](xref:Logging_on_to_DataMiner_Cube) describes you can change this.

1. Trigger the authentication popup window.

   In some cases the authentication popup window fails to load. This can be manually triggered:
   
   1. Make sure you see the start screen asking for a username and password
   2. Fill in your username
   3. Keep the password blank
   4. Click on the connect button

