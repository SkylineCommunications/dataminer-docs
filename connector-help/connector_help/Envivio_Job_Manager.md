---
uid: Connector_help_Envivio_Job_Manager
---

# Envivio Job Manager

The **Envivio Job Manager** will schedule and configure resources needed to execute a desired broadcast. The connector will check the availability of resources and schedule them. At the time of execution the configuration of the resources will be done automatically.

The details of the job can be configured in the user interface.

## About

A job can be requested via a **SOAP** call or via the user interface on the **Element** **Card**.

The format of the **SOAP** call is user fixed.

Via the user interface of the **Element** **Card** the details can easily be specified and once this is done the request to create the job can be send to the connector.

The connector will check the request information and return an error when something is missing. If not the availability of the resources will be checked and booked for the requested execute time.

On execution the needed configuration will be done on the resources and they will be reset when the job has finished.

Indications of the progress of the jobs are available in an **Overview Table**.

Available resources are automatically detected by the manager.

## Installation and configuration

Creation

This connector uses a **HTTP** connection and needs following user information:

**SERIAL CONNECTION**:

- **IP address/host**: the polling IP or URL of the destination eg *10.11.12.13*
- **IP port**: the port of the destination eg *80*
- **Bus address**: this field can be used to bypass the proxy. To do so fill in the value *bypassproxy*.

These communication settings will be used to send notification on the state of a Job.

Resources

Resources are automatically detected and do not need any configurations. This can be forced by using the **Check Resources** button on the **Resource Overview** page.

On execute of a job some settings need to be set on the resources. To determine these settings ranges need to be defined. This is done in the Configuration page.

- **Multicast Low IP Range**
- **Multicast High IP Range**
- **Multicast Low Port Range**
- **Multicast High Port Range**
- **Multicast Port Step**

To determine if a resource can be booked or not there is need of a limit of services that can be used on a type of resource:

- **Max Number of Services on Muse**
- **Max Number of Services on Halo**

Notifications

It is possible to have notifications send back. This is a soap call and will send different states of a job. Eg: **Running**. This can be configured via the **Notifications.** page button.

Logging

It is possible to save extra logging on all the states of the jobs in a csv file. Configuring the location, enable or disable this function is done via the **Logging.** page button.

Job Manager

Execution or finishing a job is done via an **automation script**. The name of this script needs to be configured.
On execute a configuration file for the resources is generated containing all the settings. This needs to be save on a specific location.
It is also possible to define how long a completed job should stay in the **Job Overview**. This is set in amount of days.
All these settings are done via the **Job Manager.** page button.

## Usage

Job Overview Page
This page shows a list of all the Job requests in the **Job Overview Table**. And keep track of their current state. E.g.: Scheduled, Running, Completed, Failed.
A Job can be linked to a group and these groups are displayed in the **Group Table.** Whenever a group is disabled or enabled, the jobs linked to this group will be disabled or enabled as well.

Resource Overview Page
This page shows a list of all the resources and a percentage of the already booked pool: **Resource Pool Usage.**
Depending on the configuration of the resource elements itself, see **Notes** for more details, the resource list can be updated manually via the **Check Resources** button.

# Notes

Supported resources are **Envivio Halo** using the *Envivio Halo* and **Envivio Muse** using the *Envivio 4Caster C4* protocol**.**

The **Envivio Muse** can be configured in redundancy. In this case the virtual redundant Element will be used as resource. This way the current active, main or backup, will be used on job execution.

The **Envivio Halo** can be configured with a duplicate element. This is an element that needs the same configuration on job execution as its linked element. The link will be provided via an **element** **Property**: **TeamID**. When this property contains the same value the resource will be detected as one but will copy the configuration settings in all of the linked elements as well.
