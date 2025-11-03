---
uid: Monitoring_app_header_bar
---

# Monitoring app header bar

> [!NOTE]
> If the app is used on a mobile device, to make optimal use of the available space on the screen, the app layout may be different from what is described in this section.

The Monitoring app header bar contains the following items, from left to right:

![Monitoring app header bar](~/dataminer/images/Monitoring_app_Header_Bar.png)<br>*Monitoring app header bar in DataMiner 10.4.4*

- Apps button: The button in the top-left corner provides quick access to other DataMiner web apps.

- *Monitoring* button: Click this button to return to the main page of the app at any time.

- Search box: The box in the middle of the header bar allows you to search the app. When you activate the box, a list of suggestions is displayed below it, based on the recent items list. This list of suggestions gets updated with search results as soon as you type in the box. Select a suggestion in the list to open the corresponding card.

- WebSocket connection status: Available from DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4<!--RN 38676--> up to DataMiner 10.4.0 [CU10]/10.5.1. This indicator shows the current status of your WebSocket connection. The available statuses include:

  - ![Successful connection](~/dataminer/images/WebSocket_Success.png) : A stable connection with instant updates.

  - ![Offline](~/dataminer/images/WebSocket_No_Connection.png) : An offline connection.

  - ![No real-time connection](~/dataminer/images/WebSocket_No_Real-Time_Connection.png) : No real-time connection could be established. Updates will happen more slowly than usual.

  - ![Establishing connection](~/dataminer/images/WebSocket_Establishing_Connection.gif) : Re-establishing a WebSocket connection. Updates will happen more slowly than usual.

  From DataMiner 10.4.0 [CU11]/10.5.2 onwards<!--RN 41669-->, WebSocket connection issues are indicated via colored banners directly below the header bar instead. When the connection is successful, no banner is displayed. Other options include:

  - The connection is offline: A red banner with the message `You are offline` is displayed.

    > [!NOTE]
    > If your connection is offline, a red "x" icon is also displayed on the user button.

  - The connection has been interrupted: An orange banner with the message `Connection has been interrupted` is displayed.

  - The connection is being re-established: An orange banner with the message `Busy recovering connection...` is displayed.

  - The connection has been re-established: A green banner with the message `Connection recovered` is displayed.

- User button: A button with the initials or picture of the current user is displayed in the top-right corner. Click this button to open a menu that provides access to the following options:

  - *(Monitoring) settings*: Allows you to configure the default page that is displayed when you open an element or a view card.

    > [!NOTE]
    > Setting the Visual page as the default page can cause reduced performance.

  - *About*: Displays information about the app.

  - *Help*: Available up to DataMiner 10.4.0 [CU19]/10.5.0 [CU7]/10.5.10. Opens the DataMiner Help.

  - *User settings*: Available from DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43803-->. Allows you to configure user-specific settings such as changing your password.

    > [!NOTE]
    > User settings are only available if the following conditions are met:
    >
    > - In *System Center* > *Users*, the user's *User cannot change password* setting must be disabled.
    > - The user must have the [*Modules* > *System configuration* > *Security* > *Specific* > *Limited administrator* permission](xref:DataMiner_user_permissions#modules--system-configuration--security--specific--limited-administrator).
    > - The user must not be logged in with external or delegated authentication.

  - *Sign out*: Logs you out of the app and returns you to the logon screen.
