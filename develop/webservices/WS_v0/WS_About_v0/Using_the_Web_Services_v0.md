---
uid: Using_the_Web_Services_v0
---

# Using the Web Services (v0)

1. Load the WSDL file.

   See [Interfaces and WSDL files](xref:Interfaces_and_WSDL_filesv0).

1. Call the *Connect* method to request a connection ID.

   See [Connect](xref:Connect).

   > [!NOTE]
   > If the connection is not used for 5 minutes, the session will end. You will then need to connect again to request a new connection ID.

1. Call any of the other methods. Remember to pass along the connection ID you received in step 2.

   For a list of available methods, see [Methods (v0)](xref:WS_Methods_v0#methods-v0).

> [!WARNING]
>
> - From DataMiner 10.2.0/10.1.6 onwards, the Web Services API v0 is considered **obsolete**. By default, the v0 interface is disabled from these DataMiner versions onwards. However, you can enable the v0 interface again, provided that your DMS is not connected to dataminer.services. To do so, in the file *C:\\Skyline DataMiner\\Webpages\\API\\Web.config*, add the following extra tag under \<appSettings>: *\<add key="enableLegacyV0Interface" value="true"/>*
> - We strongly recommend that you use HTTPS when accessing the Web Service APIs over public Internet. If you do not do so, all information – including logon credentials – will be sent over the Internet as plain, unencrypted text.

> [!NOTE]
> In order to make a web API request from an external machine using HTTP POST instead of SOAP, uncomment the following section in the file *web.config* in the folder *C:\\Skyline DataMiner\\Webpages\\API*:<br><br> \<!-- uncomment to test webservices outside localhost:<br> \<protocols><br> \<add name="HttpGet"/><br> \<add name="HttpPost"/><br> \</protocols><br> //-->
