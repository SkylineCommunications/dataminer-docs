---
uid: srm_service_orchestration
---

# Service Orchestration

Service Orchestration involves the complete scheduled orchestration of a service, including management of resources and advanced service orchestration rules. It is perfect for teams facing a high number of service additions, updates, and removals. Each change of a service requires a service orchestration cycle. In case there are lots of services of the same nature, it makes perfect sense to spend the effort configuring DataMiner SRM with all service details in order to achieve **fully automatic service lifecycle orchestration**.

## Service configuration using service definitions

For each type of service that needs to be on air, dedicated development is required to define the type of resources that will be part of the booking, to define how these will be interconnected, and to fully customize the configuration steps based on the target service state. All of this is done by means of [service definitions](xref:srm_definitions#service-definition).

For example, an OTT service requires an IP streaming resource on premises that can output a Zixi flow on a defined IP address, as well as a transcoder in the public cloud with 16 CPU cores and 32 GB of memory, which will receive the stream of the previously chosen IP address. The packager in the cloud also needs to be configured to take the transcoder output and map it on a URL, and so on. All of this can be configured in the service definition.

Service definitions also ensure that operators do not need to enter redundant information. For example, the output IP address of the Zixi edge resource mentioned above is the same IP address as for the transcoder input. This logic is added to the service definition with scripts that transfer data from one resource in the service definition to another resource, in any kind of direction. As these scripts describe the rules used to transfer data, they are known as [Data Transfer Rules (DTR)](xref:srm_scripting#data-transfer-rules-dtr) scripts.

## Flexible lifecycle management

Service Orchestration also increases the choices and possibilities for service lifecycle management. While Resource Orchestration schedules only understand the "START" and "STOP" events of a schedule, Service Orchestration facilitates additional LSO states. For example, "PAUSE" may tell DataMiner to disable the streaming URL of the packager, "SWITCH_TO_REDUNDANT" may cause a redundant input stream selection, etc.

Two more stages that are included in the service lifecycle of DataMiner SRM are the "PRE-ROLL" and "POST-ROLL" stages. Operators often like to get a service orchestrated and checked before it goes on air. This is the pre-roll stage. Similarly, operators may want to keep the service deployed after the schedule end, for example to cope with unexpended schedule extensions. This can be done with the post-roll stage.

The additional logic for these lifecycle stages is defined in scripts that are configured for each service definition, called [Lifecycle Service Orchestration (LSO)](xref:srm_scripting#lifecycle-service-orchestration-lso-script) scripts. These allow DevOps teams to script precisely what DataMiner will do for each LSO transition.

## Automated resource configuration

To orchestrate services, more is needed than just the configuration of the resources used for the service. The selected resources also need to be properly connected to one another. DataMiner SRM comes with a Service Flow Engineering module that can calculate the lowest-cost paths between resources (based on a Dijkstra algorithm). This functionality can be used while booking a service, or JIT before the service starts (as part of the LSO). Optionally, DataMiner can even control the underlying network routers and switches (IP, SDI, ASI, L-Band, etc.). In that case, the network routers and switches are included in the service definition, and therefore fully orchestrated by DataMiner.

The actual automation of the resources used for a service is executed by [Profile-Load Scripts (PLS)](xref:srm_scripting#profile-load-script-pls). These are the exact same scripts as the ones DevOps teams can use to kick-start the automation of their operations using Resource Automation. This means that Service Orchestration is a seamless step up from Resource Automation, Resource Scheduling, and Resource Orchestration.

## Service Orchestration in a nutshell

Service Orchestration relies on different scripts to know the behavior of a particular type of service. In addition to the existing PLS scripts, which the teams will often have at hand already, Service Orchestration makes use of DTR and LSO scripts per service definition.

This means that Service Orchestration is the SRM flavor requiring the biggest implementation efforts. This is typically used to support very **repetitive and deterministic use cases**. Everything is prepared in advance to make the life of the user as easy as possible. However, this requires that each and every action that the user can potentially trigger on each type of service is defined and implemented (e.g. switching to a backup device, inserting a video processing unit, etc.).

Typical uses of Service Orchestration include contribution and distribution networks (e.g. IP over fiber and satellite), media aggregation and distribution headends, etc. When service quantities are high and repeated configuration actions are needed, it makes perfect sense to spend the incremental development effort.

While the DataMiner SRM stack is deployed on any DataMiner node by default at no additional cost, using Service Orchestration requires [SRM licenses](xref:Pricing_Perpetual_Use_Licensing#special-purpose-licenses).

> [!TIP]
> See also: [Enabling powerful orchestration of service workflows](https://www.youtube.com/watch?v=XBDk48hY300) ![Video](~/dataminer/images/video_Duo.png)
