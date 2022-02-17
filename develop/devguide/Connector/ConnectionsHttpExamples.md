---
uid: ConnectionsHttpExamples
---

# Examples

The following example defines a session defining a GET request including the HTTP header "Accept" (which is set to "text/xml"). Basic authentication is used and the username and password are defined in parameters 40 and 42, respectively.

The response defines the IDs of the parameters where the status code and response body will be saved.

```xml
<Session id="1" name="Get ASI Inputs" loginMethod="credentials" userName="40" password="42">
   <Connection id="1">
      <Request verb="GET" url="/txp_get_tree?path=/data/elements/asiinput_coll/">
         <Headers>
            <Header key="Accept">text/xml</Header>
         </Headers>
      </Request>
      <Response statusCode="601">
         <Content pid="801"/>
      </Response>
   </Connection>
</Session>
```

The following example is a session defining a POST request with a number of request headers. The request uses the Data tag to send the content of parameter 101 as the request message body.

```xml
<Session id="101" name="getAllEquipment">
   <Connection id="1" name="getAllEquipment">
      <Request verb="POST" url="/EquipmentInventoryRetrieval">
         <Headers>
            <Header key="Content-Type">text/xml;charset=UTF-8</Header>
            <Header key="SOAPAction">getAllEquipment</Header>
            <Header key="Accept-Encoding">gzip,deflate</Header>
         </Headers>
         <Data pid="101"></Data>
      </Request>
      <Response statusCode="201">
         <Content pid="301"></Content>
      </Response>
   </Connection>
</Session>
```

The following example illustrates using the Parameters tag:

```xml
<Session id="101" name="postExample">
   <Connection id="1" name="postExampleConnection">
      <Request verb="POST" url="API/v0/Soap.asmx/Connect">
         <Parameters>
            <Parameter key="Connection" pid="3"></Parameter>
            <Parameter key="Login" pid="40"></Parameter>
            <Parameter key="Password" pid="42"></Parameter>
         </Parameters>
         <Headers>
            <Header key="Content-Type">application/x-www-form-urlencoded</Header>
         </Headers>
      </Request>
      <Response statusCode="201">
         <Content pid="301"></Content>
      </Response>
   </Connection>
</Session>
```
