---
uid: Get_alarms
---

# Get alarms

Available from DataMiner 10.2.0/10.1.9 onwards. The *Get alarms* data source retrieves the alarms in the DataMiner System. Several columns, such as *Element Name*, *Parameter Description*, *Value* and *Time*, are included by default. Others can be added with a [*Select* operation](xref:GQI_Select).

> [!NOTE]
> If your DataMiner System uses [self-hosted storage with Cassandra but without an indexing database](xref:Separate_Cassandra_setup_without_Elasticsearch), we recommend always adding filtering on *Time*, as this filters directly on the database. Otherwise, the SLDataGateway process will fetch all alarms and then apply the filtering, which might take a lot of resources.
