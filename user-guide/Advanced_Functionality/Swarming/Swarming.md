---
uid: Swarming
---

# Swarming

With the upcoming DataMiner Swarming functionality, you will be able to [switch objects](xref:SwitchingObjects), such as elements or services, from one DataMiner Agent to another Agent in that cluster.

The primary goal of Swarming is to eliminate downtime resulting from maintenance activities and provide a more polished user experience.

## User stories we envision
### Initial version
- As a DataMiner System Admin, I can apply maintenance (ex. Windows updates) on my live cluster, Agent by Agent.(*) (**)
- As a DataMiner System Admin, I can easily extend my system with an extra node and easily move functionalities from my existing agents to the new agents, so I can rebalance my cluster.(*) (**)
- As a DataMiner System, I will recover from failing nodes by moving activities hosted on that node to the remaining nodes.(*) (**)

### Later
- As a DataMiner System Admin, I can do rolling DataMiner Software updates on my live clusters, with limited downtime of specific functionality.(*) (**)

(*) with limited downtime and as long as there is spare capacity  
(**) initial versions will have limitations. Some DataMiner functionality might be excluded

## Softlaunch release
- Limited to basic elements (no DVE parent or child elements, no functions, no spectrum elements, no element managers or EPM elements, no derived elements or elements in a Redundancy group, no built-in elements like DataMiner Element, aggregation element, service element)
- Expected in Q3 2024

## Initial Release
- Will have limitations on what is swarmable and what not. We will be adding more information while we are making progress. Check back for updates frequently!
- Expected in Q4 2024

> [!NOTE]
> Swarming is not available in DataMiner Systems with a [storage per DMA setup](xref:Configuring_storage_per_DMA) (Cassandra or MySQL).
