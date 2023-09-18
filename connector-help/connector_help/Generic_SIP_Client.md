---
uid: Connector_help_Generic_SIP_Client
---

# Generic SIP Client

The Generic SIP (Session Initiation Protocol) Client is a softphone application that allows you to manage communications by enabling voice calls over IP networks (VoIP).

## About

The Generic SIP Client connector is capable of establishing RTC (Real-Time Communication) sessions through the parameter negotiation and media setup performed with the SDP (Session Description Protocol) that is carried as payload in SIP messages. This connector can also perform **calls** and **transfers** using the implemented signaling.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

The General page contains the main functionalities of the connector, such as **Register** **Call**, **Hang Up** and **Transfer**. Note that the User-Agent registration is done automatically.

This page also displays the inherent **Registration and Call Status** as well as the **Last Call Duration** for the last dialed phone number.

### Account

The Account subpage displays all the details concerning the **SIP Extension Account** used for registration purposes, namely **Account Name** (SIP Username), **Extension** (Account Phone Number), **Domain** (PBX IP address), **Display Name** (Alias for SIP Username), **Authorization Name** (Authentication Username) and **Password** (SIP Password).

### Transfer

The Transfer subpage displays the **Extension** to which the call will be transferred. It also contains the **Transfer Call** button.
