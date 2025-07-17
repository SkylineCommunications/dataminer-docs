---
uid: DataMiner_interfaces
---

# DataMiner interfaces

Your DataMiner System can interface with a multitude of client applications, ranging from the standard DataMiner web clients to third-party tools.

There are four main categories of DataMiner interfaces:

- **Private interfaces**: Used for the standard DataMiner client applications, including DataMiner Cube and the DataMiner web apps.

  > [!TIP]
  > See also: [IP communication within a DMS](xref:Configuring_the_IP_network_ports#graphical-representation-of-ip-communication-within-a-dms)

- **Standard public interfaces**: By default, every DataMiner System has a number of standard public interfaces that allow:

  - Forwarding of SNMP notifications to third-party SNMP managers (HP OpenView, IBM NetCool, etc.).

  - Performing SNMP Get and SNMP Set requests on individual controls and readings of devices.

  - Exchange of information via TCP-IP sockets.

  - Offload of database records via SQL or NoSQL (Cassandra).

  - Web Services APIs (SOAP XML, XML-RPC).

- **Optional public interfaces**: Optionally, a DataMiner System can be configured to connect to third-party applications via

  - Web Services APIs (SOAP XML, XML-RPC, JSON)

  - EGMC2

- **Custom interfaces**: On top of all available private and public interfaces, highly specialized, custom interfaces can be developed to allow your DataMiner System to integrate seamlessly into your existing infrastructure.

  > [!TIP]
  > For more information, contact [Skyline Sales](mailto:sales%40skyline.be).

<!--To be replaced:
 ![Overview DataMiner interfaces](~/dataminer/images/3rd_party_System_Interfacing_REV003.jpg) -->
