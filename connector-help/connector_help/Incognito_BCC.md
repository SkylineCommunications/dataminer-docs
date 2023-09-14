---
uid: Connector_help_Incognito_BCC
---

# Incognito BCC

Incognito Broadband Command Center is a device-provisioning solution with a service provider-grade DHCP management component that supports the latest standards and technologies: IPv6, DOCSIS, Packet Cable, and SIP.

Broadband Command Center is a combination of the following key components:

- **DHCP Service**: Automatically manages dynamic IPv4 and IPv6 address allocation, DDNS record and DOCSIS terminal configuration based on user-defined policies.
- **Multimedia Provisioning Service**: Provisions accurate Packet Cable and SIP multimedia configurations to subscriber devices by acting as both storage and integration point for subscriber, device and associated configuration data.
- **Configuration File Management Proxy**: Delivers scalable and secure transfer of device configuration files over TFTP, HTTP, HTTP(s), and FTP.
- **DNS**: Supports high-security domain name resolution, DDNS, zone transfers, and simplified DNS administration.
- **Configuration File Management Service**: Removes the need to track and store large numbers of static files by dynamically generating configuration files.

## About

This connector was designed to work with the **Incognito BCC** device. With it, you can check the parameters of the different services of the BCC and keep track of the performance of the equipment. The different parameters of the device are displayed on multiple pages grouped by function.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|--|--|
| 1.0.0.1 | **[CFM]** 6.4.5.1<br>**[CFM Proxy]** 6.4.4.3<br>**[DHCP]** 6.4.5.7<br>**[MPS]** 6.4.6.5 |

## Installation and configuration

### Creation

This connector uses an SNMPv3 connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *192.168.10.11*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

Once created, the element can be used immediately. Several pages are available.

### CFM

This page displays the **CFM Service Server Name**, **CFM** **Service Name**, **CFM** **Version**, **CFM** **License Users**, **CFM** **Subscription Expiration**, **CFM** **License Type**, **CFM** **Operating System** and **CFM** **Service Start** **Time**, as well as the numbers for the DOCSIS and SIP.

### CFM Proxy

This page displays the **CFM Proxy Service Server Name**, **CFM Proxy Service name**, **CFM Proxy Version**, **CFM Proxy License Users**, **CFM Proxy Subscription Expiration**, **CFM Proxy License Type**, **CFM Proxy Operating System** and **CFM Proxy Service Start Time**.

There are also page buttons that display the statistics of the **TFTP**, **HTTP**, **HTTPS**, and **FTP** file transfer methods.

### DHCP

This page provides information about the **IPC Service Server Name**, **IPC Service Name**, **IPC Version**, **IPC License Users**, **IPC Subscription Expiration**, **IPC License Type**, **IPC Operating System** and **IPC Service Start Time**.

It is possible to check the IPv4 DHCP statistics:

- **DHCPPacket Discards**
- **DHCPSupercedes**
- **DHCPResponse**

The failover statistics of the following objects are also displayed:

- TimeUp
- Resynch Time
- TimeDown
- Time
- Status
- Traffic
- Error
- Sent
- Received

### DHCPv4

On this page, you can find general information related to the DHCP service, e.g. DHCPv4 server system description, DHCPv4 counters (error packets, sent packets, DHCPv4 and BOOTP), optional statistics regarding DHCPv4, and the **Server Configuration.**

### DHCPv6

On this page, you can check the IPv6 statistics:

- **DHCPv6Packet Discards**
- **DHCPv6Supercedes**
- **DHCPv6Response**
- **IPC DHCPv6 Counters**

### MPS

This page contains DPC server information such as **DPC** **Service Server Name, DPC** **Service name, DPC** **Version, DPC** **License Users, DPC** **Subscription Expiration, DPC** **License Type, DPC** **Operating System** and the **DPC** **Service Start Time**.

The page also displays the statistics of the subscriber devices:

- AP Handler
- Cable Modem (CM)
- MTA
- Voice Cache
- MAC FQDN

### Notifications

This page shows the notifications of the different services. Those are received independently in each table. One table is displayed per service.

Note: The values in parentheses correspond to the different types of server that can be shown in the alarm traps.

**MPS Notifications Table:**

**Alarms:**

- MPS Server Stop **(DNS, LDAP, DHCP, CFMProxy, TFTP, MPS, KDC, DHCP Relay)**
- MPS Service Paused
- MPS Exceeded License
- MPS Enrollment Ignored
- MPS Inform Status Failed
- MPS TFTP File Upload Fail
- MSP DHCP User not Found
- MPS MTA FQDN Req Failed
- MPS AP Request Failed
- MPS Disk Storage Low
- MPS TFTP Server Leaving
- MPS Other Server Not Responding **(DNS, LDAP, DHCP, CFMProxy, TFTP, MPS, KDC, DHCP Relay)**
- MPS Failover Resynch Operation Completed
- MPS Server Leaving Cluster Integration **(DNS, LDAP, DHCP, CFMProxy, TFTP, MPS, KDC, DHCP Relay)**
- MPS LDAP Communications Down
- MPS LDAP Timed Out
- MPS DHCP Connection Failed
- MPS Device Has No Lease

**Information:**

- MPS Service Backup Done
- MPS Failover Terminated
- MPS Packet Cable Dev Event Inform

**CFM & CFM Proxy Notifications Table:**

**Alarms:**

- CFM Server Stop **(DNS, LDAP, DHCP, CFM, CFMProxy, TFTP, MPS, KDC, DHCP Relay)**
- CFM Service Paused
- CFM Disk Storage Low
- CFM TFTP File Generation Failed
- CFM Server Leave Cluster Integration **(DNS, LDAP, DHCP, CFM, CFMProxy, TFTP, MPS, KDC, DHCP Relay)**
- CFM Config Profile Not Requested
- CFM Proxy Server Stop **(DNS, LDAP, DHCP, CFM, CFMProxy, TFTP, MPS, KDC, DHCP Relay)**
- CFM Proxy Service Paused
- CFM Proxy Disk Storage Low
- CFM Proxy Other Server Not Responding **(DNS, LDAP, DHCP, CFM, CFMProxy, TFTP, MPS, KDC, DHCP Relay)**
- CFM Proxy Server Leave Cluster Integration **(DNS, LDAP, DHCP, CFM, CFMProxy, TFTP, MPS, KDC, DHCP Relay)**
- CFM Proxy Service Overloaded
- CFM Proxy DoS Attack Detected

Information:

- CFM Service Backup Done
- CFM Proxy Service Backup Done

**DHCP Notifications Table:**

**Alarms:**

- DHCP Server Stop **(DNS, LDAP, DHCP, CFM, CFMProxy, TFTP, MPS, KDC, DHCP Relay)**
- DHCP Service Paused
- DHCP Exceeded License
- DHCP Free Address High
- DHCP Critical Address Level
- DHCP Other Server Not Responding **(DNS, LDAP, DHCP, CFM, CFMProxy, TFTP, MPS, KDC, DHCP Relay)**
- DHCP Failover Conflict
- DHCP Service Overloaded
- DHCP DNS Failure **(DNS, LDAP, DHCP, CFM, CFMProxy, TFTP, MPS, KDC, Unknown, DHCPRelay)**
- DHCP Unknown Device
- DHCP Disk Storage Low
- DHCP Free Address Low
- DHCP Failover Resynch Operation Started
- DHCP NetView Critical HWM Exceeded
- DHCP NetView Warning HWM Exceeded
- DHCP Possible Duplicate Device
- DHCP No More Addresses Available
- DHCP TFTP Server Leaving
- DHCP Server Leave Cluster integration **(DNS, LDAP, DHCP, CFM, CFMProxy, TFTP, MPS, KDC, Unknown, DHCPRelay)**
- DHCP LDAP Communications Down
- DHCP LDAP Timed Out
- DHCP Radius Accounting HWM Exceeded
- DHCP Set Communications Down
- DHCP DoS Exceeded Limit
- DHCP SQL Lease Audit HWM Exceeded
- DHCP DHCPv6 Reconfigure Message Failed
- DHCP Failover Error
- DHCP DHCPv6 DUID DoS Exceeded Limit
- DHCP DHCPv6 DUID IA DoS Exceeded Limit
- DHCP Gi Reservable Subnet Allocated
- DHCP Roamed Device
- DHCP Cls HWM Exceeded
- DHCP Failover Conflict Inet Address

**Information:**

- DHCP Rogue Server
- DHCP Service Backup Done
- DHCP GiReservable Subnet Released
- DHCP GiReservable Subnet Allocated
- DHCP Roamed Device

**SNMP Notifications Table:**

- SNMP Cold Start
- SMNP Warm Start
- SNMP Authentication Failure
- SNMP Notification Shutdown
- SNMP Notification Restart
- SNMP Notification Start
