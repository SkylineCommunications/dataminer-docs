---
metadata_version: 1
uid: Protocol.HTTP.Session-proxyServer
description: "Reference the DataMiner connector protocol schema entry for proxyServer attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# proxyServer attribute

Use this attribute to specify the proxy server through which the connection has to be set up.

## Content Type

string

## Parent

[Session](xref:Protocol.HTTP.Session)

## Remarks

This can be either a hard-coded string or a parameter ID referring to a parameter (with Interprete/Type set to "string") that holds the value (the latter option is preferred).

> [!NOTE]
> If you do not specify a proxy server, then an attempt will be made to fetch the default proxy configuration using the Web Proxy Auto-Discovery Protocol (WPAD).
