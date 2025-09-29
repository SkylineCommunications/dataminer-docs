---
uid: ZiineDemoSystem
description: Use the Ziine Demo System to explore DataMiner features in a functioning DataMiner System. To connect, you need a dataminer.services account.
---

# Ziine Demo System

The Ziine Demo System allows you to explore many different DataMiner features in a functioning DataMiner System. This includes the standard DataMiner monitoring and Visual Overview features, and also several DataMiner Solutions and standard apps.

## Requesting access to Ziine

To access the Ziine Demo System:

1. Go to the [live Demo System page](https://skyline.be/learn/demo/) on the Skyline website.

1. Complete the form to request access to Ziine.

Once you have submitted the form, you will see a confirmation page and receive an email with more information on how to get started.

## Accessing Ziine

After you have requested access, you will be able to log in to Ziine. To get started, follow these steps:

1. Go to [ziine.skyline.be](https://ziine.skyline.be/)

1. Log in using one of the following ways:

   - Use your corporate account linked to Microsoft, Google, Amazon, or Linkedin.
   - Create a dedicated account via the *Sign up* option at the bottom of the authentication window.

1. Start exploring the different available apps, or install DataMiner Cube to experience the desktop version.

### Installing DataMiner Cube

On the homepage of Ziine you can find different apps, dashboards and monitoring options to explore.

To install DataMiner Cube:

1. On the [ziine.skyline.be](https://ziine.skyline.be/) homepage, click the ... icon on the *Cube* button, and select *Download installer*.

   ![Download Cube installer](~/dataminer/images/DownloadCubeForZiine.png)

   > [!TIP]
   > See also: [Installing the DataMiner Cube desktop application](xref:Installing_the_DataMiner_Cube_desktop_application)

1. After installation, open the DataMiner Cube desktop application.

1. Connect to the DataMiner System "the [Ziine Demo System](xref:ZiineDemoSystem)" as described under [Opening the desktop application](xref:Using_the_desktop_app).

> [!NOTE]
> The Ziine hostname is `https://ziine.skyline.be/`.

### Having problems connecting?

If you are having problems connecting using the DataMiner Cube:

1. Check the connection settings and make sure *Connection Type* is set to *Auto*. See [Overriding the default connection type](xref:Overriding_Cube_connection_type).

   *Connection Type* must be set to *Auto* because all public Agents at Skyline have a unique port for their .NET Remoting connection instead of the default port *8004*.

1. Make sure the authentication pop-up window is triggered. If it is not shown automatically as soon as you try to connect, you can trigger it manually from the login screen:

   1. Fill in your username, but **do not fill in a password**.

   1. Click the blue arrow icon to log on.

      ![Logging on to Ziine](~/dataminer/images/ziine_login.png)
