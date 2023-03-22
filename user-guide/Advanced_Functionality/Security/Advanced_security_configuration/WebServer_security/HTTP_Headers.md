---
uid: HTTP_Headers
---

# HTTP headers

HTTP response headers allow you to instruct how the browser should behave when handling data. The HTTP headers below provide extra protection layers to mitigate vulnerabilities (e.g. cross-site scripting, clickjacking, information disclosure, etc.).

## Server Header

The *Server* header describes the software used by the web server handling the request. This may allow attackers to gain insight into the version or type of the web server.

To remove the *Server* header in IIS, create an outbound rewrite rule that removes the value for the *Server* header.

To create the outbound rewrite rule:

1. Open *IIS Manager*.

1. In the *Connections* pane on the left, select *Default Web Site*.

1. In the middle pane, double-click *URL Rewrite*.

1. In the *Actions* pane on the right, click *Add Rule(s)*.

1. Under *Outbound rules*, select *Blank rule*, and click *OK*.

1. In the *Match* pane, set *Matching scope* to *Server Variable*.

1. Set the *Variable name* to *RESPONSE_SERVER*

1. Set the *Regular Expressions* pattern to `.*`.

1. Leave the *Action type* set to *Rewrite* and leave the *Value* field empty.

1. In the *Actions* pane, click *Apply*.

1. Restart IIS

Alternatively, you can add the following XML in the *\<system.webServer>* element of *C:\Skyline DataMiner\Webpages\web.config* and then restart IIS:

```xml
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

The *X-Powered-By* header describes technologies in the web server. Threat actors could gain valuable knowledge because of this.

To remove the *X-Powered-By* response header:

1. Open *IIS Manager*.

1. In the *Connections* pane, select the web server by clicking the server name.

1. In the middle pane, double-click *HTTP Reponse Headers*.

1. Select *X-Powered-By*, and click *Remove* in the *Actions* pane.

1. Click *Yes* when asked to confirm the removal.

## HSTS - Strict Transport Security

To bypass TLS encryption on websites served over HTTPS, attackers can use *SSL stripping*. To mitigate this type of attack, set the *Strict-Transport-Security* (HSTS) response header. This will instruct the browser to always load DataMiner over HTTPS.

To enable *Strict Transport Security*:

### [Windows Server 2019 or newer](#tab/hsts-1)

1. Open *IIS Manager*.

1. In the *Connections* pane on the left, expand the top node and *Sites* node until you see *Default Web Site*.

1. Right click *Default Web Site* and select *Manage Website* > *Advanced settings*.

1. Under *Behavior*, expand *HSTS*.

1. Set *Enabled* to *True*.

1. Set *IncludeSubDomains* to *True*.

1. Set *Max-Age* to *31536000* seconds (i.e. 1 year).

1. Optionally, set *Preload* to *True*.

1. Optionally, set *Redirect Http to Https* to *True*

1. Click *OK*.

### [Older Windows Server versions](#tab/hsts-2)

1. Open *IIS Manager*.

1. In the *Connections* pane on the left, select *Default Web Site*.

1. In the middle pane, double-click *HTTP Reponse Headers*.

1. In the *Actions* pane, click *Add...*.

1. Set *Name* to *Strict-Transport-Security*.

1. Set *Value* to *max-age=31536000; includeSubDomains* (i.e. 1 year).

1. Click *OK*.

***

> [!TIP]
> For information about HSTS, see [HSTS Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/HTTP_Strict_Transport_Security_Cheat_Sheet.html).
