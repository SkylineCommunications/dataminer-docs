---
uid: Connector_help_Red_Hat_Enterprise_Openshift
---

# Red Hat Enterprise OpenShift

Red Had Enterprise OpenShift Manager allows a full monitoring and SRM support of OpenShift instances.

## About

Red Hat Enterprise OpenShift allows the full management of enterprise Kubernetes deployments. This connector monitors the entire north-south infrastructure. from containers to PODs and Nodes. It also includes real-time statistics of the main elements.

### Version Info

| **Range** | **Description**               | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version - Version 3.6 | No                  | True                    |
| 1.1.0.1          | Initial Version - Version 3.7 | No                  | True                    |

## Installation and configuration

### Creation

This connector uses a virtual connection and does not require any input during element creation.

Note however, that the connector uses HTTPS connectivity that must be configured in the General page.

## Usage

### General

The General page contains the main connection data. In this page the user must insert the OpenShift URL/IP Address, the username and the password. Openshift uses OAuth authentication method, based on Bearer tokens. By default, the token is retrieved from the implemented Login mechanism, but the user can insert his/her own token. Each Bearer token is valid for 24 hours and renewed accordingly. In this page the user can also verify the authorization state, which refers to the login success. There is also a refresh data button, that allows to poll all data manually at once.

By default, the Login is done at startup and renewed at every 12 hours.

From the General page the user can access to the main information in plain table mode. To do so, there are sub pages listing Nodes, PODs, Containers and their respective statistics.

### Namespaces

The namespaces list, original from Kubernetes, are listed in this page in a table format. This table contains the namespace name, labels, status, age, creation timestamp, resource version and self link.

### Nodes

This page presents the list of nodes organized by namespace in a tree control fashion. From each node, the user can navigate to the respective Conditions, Stats and PODs.

### PODs

This page presents the list of PODs organized by namespace in a tree control fashion. For every POD it is possible to see the Containers, Conditions and Volumes among others.

### Services

Also in a tree control fashion, this page displays all services organized per namespace.

### Replica Controllers

Replica Controllers are also listed and organized per namespace in a tree control structure.

> [!NOTE]
> The pages listed below are exported to SRM DVEs and not visible in the main element

### Node Info

This page shows all information available regarding one specific node.

### POD Info

The POD Info page also shows all the information available regarding one specific POD.

### POD Container Info

In turn, the POD Container Info page display all data about the selected Container.

### Node Stats Info

Node Stats Info is a complementary page that appears in the same element of Node Info page and it is used to show all realtime statistics regarding the chosen node.

### POD Stats Info

POD Stats Info presents all realtime statistics for the referred node. As above, it appears in the same DVE of POD Info page.

### POD Container Stats Info

Finally, the POD Container Stats Info displays the realtime statistics regarding the selected container. This page is enclosed to POD Container Info.
