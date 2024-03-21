---
uid: Monitoring_app_header_bar
---

# Monitoring app header bar

> [!NOTE]
> If the app is used on a mobile device, to make optimal use of the available space on the screen, the app layout may be different from what is described in this section.

The Monitoring app header bar contains the following items, from left to right:

![Monitoring app header bar](~/user-guide/images/Monitoring_app_Header_Bar.png)<br>*Monitoring app header bar in DataMiner 10.4.4*

- Apps button (1): The button in the top-left corner provides quick access to other DataMiner web apps.

- *Monitoring* button (2): Click this button to return to the main page of the app at any time.

- Search box (3): The box in the middle of the header bar allows you to search the app. When you activate the box, a list of suggestions is displayed below it, based on the recent items list. This list of suggestions gets updated with search results as soon as you type in the box. Select a suggestion in the list to open the corresponding card.

- WebSocket connection status (4): Available from DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38676-->. This indicator shows the current status of your WebSocket connection. The available statuses include:

  - ![Successful connection](~/user-guide/images/MA_Successful.png) : A stable connection with instant updates.

  - ![Offline](~/user-guide/images/MA_No_Connection.png) : An offline connection.

  - ![No real-time connection](~/user-guide/images/MA_No_Real-Time_Connection.png) : No real-time connection could be established. Updates will happen more slowly than usual.

  - ![Establishing connection](~/user-guide/images/MA_Establishing.png) : Re-establishing a WebSocket connection. Updates will happen more slowly than usual.

- User button (5): A button with the initials or picture of the current user is displayed in the top-right corner. Click this button to open a menu that provides access to the following options:

  - *Settings*: Allows you to configure the default page that is displayed when you open an element or a view card.

    > [!NOTE]
    > Setting the Visual page as the default page can cause reduced performance.

  - *About*: Displays information about the app.

  - *Help*: Opens the DataMiner Help.

  - *Sign out*: Logs you out of the app and returns you to the logon screen.
