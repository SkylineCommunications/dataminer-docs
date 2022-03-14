---
uid: Using_the_Web_Services_v1
---

# Using the Web Services (v1)

1. Load the WSDL file.

    See [Interfaces and WSDL files](xref:Interfaces_and_WSDL_files).

1. Call the *ConnectApp* method to request a connection ID (see [ConnectApp](xref:ConnectApp) ).

   > [!NOTE]
   > -  Remember to pass along the name and version of the client application as provided by Skyline Communications as part of the DataMiner software license.
   > -  If two-step authentication is required, use *ConnectAppAndInfo* (see [ConnectAppAndInfo](xref:ConnectAppAndInfo)) and *ConnectAppAndInfoStep2* (see [ConnectAppAndInfoStep2](xref:ConnectAppAndInfoStep2)) instead of *ConnectApp*.
   > -  If the connection is not used for 5 minutes, the session will end. You will then need to connect again to request a new connection ID.

1. Call any of the other methods. Remember to pass along the connection ID you received in step 2.

   For a list of available methods, see [Methods (v1)](xref:WS_Methods_v1_overview#methods-v1).

1. Call the *LogOut* method to log out. See [LogOut](xref:LogOut).

> [!WARNING]
> We strongly recommend that you use HTTPS when accessing the Web Service APIs over public Internet. If you do not do so, all information – including logon credentials – will be sent over the Internet as plain, unencrypted text.
