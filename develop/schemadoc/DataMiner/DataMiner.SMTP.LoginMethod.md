---
uid: DataMiner.SMTP.LoginMethod
---

# LoginMethod element

Specifies the method that will be used to authenticate the DataMiner Agent when it logs on to the SMTP server.

## Content Type

| Item | Facet Value | Description |
| --- | --- | --- |
| ***string restriction*** |  |  |
| &#160;&#160;Enumeration | NoLoginMethod | The user will not be authenticated by the server. |
| &#160;&#160;Enumeration | LoginPlainMethod | Username and password will be sent to the server unencrypted. |
| &#160;&#160;Enumeration | CramMD5Method | The user will be authenticated using CRAM MD5 (Challenge-Response Authentication Mechanism, see RFC 2195). |
| &#160;&#160;Enumeration | AuthLoginMethod | Username and password will be sent to the server using simple base64 encoding. |
| &#160;&#160;Enumeration | NTLM | The user will be authenticated using the MS NTLM (NT LAN Manager) protocol. |
| &#160;&#160;Enumeration | Auto | The authentication protocol to be used will be auto-negotiated. |

## Parents

[SMTP](xref:DataMiner.SMTP)
