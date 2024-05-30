---
uid: ConnectionsHttpHttps
---

# HTTPS

The default port for HTTPS communication is 443.

When port 443 is set in the element wizard, HTTPS will be used by default. For all other ports, HTTP will be used by default (RN 9995).

To poll an HTTPS server on a different port than 443, you have to specify the "https://" prefix in the address field of the server in the element wizard. If this is not specified, this can result in an ERROR_WINHTTP_HEADER_SIZE_OVERFLOW, because DataMiner could assume it is polling through HTTP and not on a secure channel.

When the IP address is changed during runtime of the element by the value of a dynamic IP parameter, then the "https://" prefix also needs to be specified in such parameter value. The prefix that has been specified at the port configuration of the element will not be taken into account.
