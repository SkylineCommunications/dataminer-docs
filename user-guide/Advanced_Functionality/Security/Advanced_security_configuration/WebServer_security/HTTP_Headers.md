---
uid: HTTP_Headers
---

# HTTP Headers

HTTP Response Headers allow you to instruct how the browser should behave when handling data. The HTTP Headers below can provide an extra protection layers to mitigate vulnerabilities (e.g. Cross-Site Scripting, Clickjacking, Information Disclosure, ...)

## Server Header

The *Server* header describes the software used by the (Web) Server handling the request. This may allow attackers to gain insights about version or type of Web Server.

To remove the *Server* header in IIS, create an Outbound Rewrite rule that removes the value for the *Server* header.

To create the Outbound Rewrite rule:

1. Open *IIS Manager*

1. Open the *Default Web Site*

1. Open the *URL Rewrite*

1. In the *Actions* pane, click *Add Rule(s)*

1. Under *Outbound rules*, click *Blank rule*

1. In the *Match* pane, set *Matching scope* to *Server Variable*

1. Set the *Variable name* to *RESPONSE_SERVER*

1. Set the *Regular Expressions* pattern to *.**

1. Leave the *Action* on *Rewrite* and leave the *Value* field empty

1. In the *Actions* pane, click *Apply*

1. Alternatively, add the following XML in the *<system.webServer>* of *C:\Skyline DataMiner\Webpages\web.config* and restart IIS:
```
<rewrite>
  <outboundRules rewriteBeforeCache="true">
    <rule name="Remove Server header">
      <match serverVariable="RESPONSE_SERVER" pattern=".*" />
      <action type="Rewrite" value="" />
    </rule>
  </outboundRules>
</rewrite>
```

## X-Powered-By

