---
uid: Using_the_Web_Services_v1
description: The DataMiner Web Services methods can be used in SOAP, JSON, or URL-encoded requests. First authenticate to get a connection string.
---

# Using the Web Services

The Web Services methods can be used in SOAP, JSON, or URL-encoded requests.

> [!WARNING]
> We strongly recommend using HTTPS when accessing the Web Service APIs over public internet. If you do not do so, all information, including logon credentials, will be sent over the internet as plain, unencrypted text.

> [!IMPORTANT]
> Because of the additional security layer used in [DaaS systems](xref:Creating_a_DMS_in_the_cloud), at present, it is not possible to connect to a DaaS system using the Web Services.

> [!NOTE]
> An earlier version of the Web Services API (v0) still exists in DataMiner versions prior to 10.5.0 [CU16]/10.6.0 [CU4]/10.6.7<!--RN 45387-->. This legacy interface is obsolete and disabled by default. While we strongly recommend using the current v1 API instead, you can enable the legacy v0 interface in older systems by opening the file `C:\Skyline DataMiner\Webpages\API\Web.config` and adding the following extra tag under `<appSettings>`: `<add key="enableLegacyV0Interface" value="true"/>`.

## Authentication

Most methods require a connection string, which is a token identifier received upon authentication. To authenticate, either use the [ConnectApp](xref:ConnectApp) method, or, if two-step authentication is required, use [ConnectAppAndInfo](xref:ConnectAppAndInfo) and [ConnectAppAndInfoStep2](xref:ConnectAppAndInfoStep2).

When you authenticate, make sure to pass along the name and version of the client application as provided by Skyline Communications as part of the DataMiner software license.

> [!NOTE]
>
> - If the connection is not used for 5 minutes, the session will end. You will then need to connect again to request a new connection ID.
> - The client application should invoke the Connect method once, retaining the same connection ID for all subsequent web method calls. Should the connection ID become invalid, the Web APIs will raise an error ("No connection available"), which the client application can identify so it can subsequently reconnect, allowing the API call to be retried. This approach eliminates the necessity of initiating a Connect operation prior to each call to the Web APIs.

## Interfaces and WSDL files

The DataMiner Web Services are accessible via the following interfaces.

| Protocol | Address          |
|----------|------------------|
| SOAP     | `http://DmaNameOrIpAddress/API/v1/soap.asmx` |
| JSON     | `http://DmaNameOrIpAddress/API/v1/json.asmx` |

> [!NOTE]
> For security reasons, by default, it is not possible to test web API requests from an external machine using HTTP POST instead of SOAP. To enable this, uncomment the following section in the file *web.config* in the folder `C:\Skyline DataMiner\Webpages\API`:<br><br> \<!-- uncomment to test webservices outside localhost:<br> \<protocols><br> \<add name="HttpGet"/><br> \<add name="HttpPost"/><br> \</protocols><br> //-->

The WSDL files can be found on the following addresses.

| Protocol | Address                |
|----------|------------------------|
| SOAP     | `http://DmaNameOrIpAddress/API/v1/soap.asmx?WSDL` |
| JSON     | `http://DmaNameOrIpAddress/API/v1/json.asmx?WSDL` |

## SOAP

When SOAP requests are used, the URL should have the structure `http(s)://{DMA IP}/api/v1/soap.asmx`, regardless of which method is chosen.

Make sure all the input fields for a method are enclosed within the method's name tags.

For examples, see [SOAP examples](xref:WS_v1_examples#soap-examples).

## JSON

For JSON requests, the URL should include the method, in the format `http(s)://{DMA IP}/API/v1/Json.asmx/{Method}`.

The fields for each method will be serialized in a JSON without root element.

For examples, see [JSON examples](xref:WS_v1_examples#json-examples).

## URL-encoded

DataMiner's API supports the use of encoded URLs as the content of the body in an HTTP POST request, as illustrated below:

```txt
POST https://dma.local/API/v1/Json.asmx/GetElement
Content-Type: application/x-www-form-urlencoded
Content-Length: length

connection=string&dmaID=string&elementID=string
```
