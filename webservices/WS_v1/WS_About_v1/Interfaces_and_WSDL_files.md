---
uid: Interfaces_and_WSDL_files
---

# Interfaces and WSDL files

The DataMiner Web Services (v1) are accessible via the following interfaces.

| Protocol | Version | Address          |
|----------|---------|------------------|
| SOAP     | v1      | `http://DmaNameOrIpAddress/API/v1/soap.asmx` |
| JSON     | v1      | `http://DmaNameOrIpAddress/API/v1/json.asmx` |

> [!NOTE]
> For security reasons, by default, it is not possible to test web API requests from an external machine using HTTP POST instead of SOAP. To enable this, uncomment the following section in the file *web.config* in the folder *C:\\Skyline DataMiner\\Webpages\\API*:<br><br> \<!-- uncomment to test webservices outside localhost:<br> \<protocols><br> \<add name="HttpGet"/><br> \<add name="HttpPost"/><br> \</protocols><br> //-->

The WSDL files can be found on the following addresses.

| Protocol | Version | Address                |
|----------|---------|------------------------|
| SOAP     | v1      | `http://DmaNameOrIpAddress/API/v1/soap.asmx?WSDL` |
| JSON     | v1      | `http://DmaNameOrIpAddress/API/v1/json.asmx?WSDL` |
