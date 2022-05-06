---
uid: HTTP_Headers
---

# HTTP Headers

HTTP Response Headers allow you to instruct how the browser should behave when handling data. The HTTP Headers below provide extra protection layers to mitigate vulnerabilities (e.g. Cross-Site Scripting, Clickjacking, Information Disclosure, ...).

## Server Header

The *Server* header describes the software used by the webserver handling the request. This may allow attackers to gain insights about version or type of webserver.

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

1. Alternatively, add the following XML in the *<system.webServer>* of *C:\Skyline DataMiner\Webpages\web.config*:
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

1. Restart IIS

## X-Powered-By

The *X-Powered-By* header describes technologies in the webserver. Threat actors could gain valuable knowledge because of this.

To remove the *X-Powered-By* response header:

1. Open *IIS Manager*.

1. In the *Connections* pane, select the *Webserver* by clicking the server name.

1. Open the *HTTP Reponse Headers*.

1. Select *X-Powered-By*, and click *Remove* in the *Actions* pane.

1. Click *Yes* when asked to confirm the removal.

## HSTS - Strict Transport Security

To bypass TLS encryption on websites served over HTTPS, attackers can use *SSL stripping*. To mitigate this type of attack, set the *Strict-Transport-Security* (HSTS) response header. This will instruct the browser to always load DataMiner over HTTPS.

To enable *Strict Transport Security*:

1. Open *IIS Manager*.

1. Navigate to the *Default Web Site*.

1. In the *Actions* pane, click *HSTS*.

1. In the pop-up, select *Enable*.

1. Set the *Max-Age* to *31536000* seconds, meaning 1 year.

1. Select *IncludeSubDomains*.

1. Optionally, select *Preload*.

1. Click *OK* to exit.

> [!TIP]
> For information about HSTS, see [HSTS Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/HTTP_Strict_Transport_Security_Cheat_Sheet.html).