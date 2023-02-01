---
uid: DataMiner_Configuration_External_Cluster
---
# Manual DataMiner Configuration

The connection of a DataMiner agent to an Elasticsearch cluster is made by
manually adding a *DataBase* tag to the DB.xml file. To do so, follow the instructions
below:

1. Stop the DataMiner agent using any of the methods explained in [Starting or Stopping DataMiner agents](xref:Starting_or_stopping_DataMiner_Agents_in_your_DataMiner_System).
2. Open the DB.xml file at *c:\Skyline DataMiner* folder (it is advised to create a copy first).
3. After the last closing DataBase tag add the following content:
```xml
 	<DataBase active="true" search="true" type="Elasticsearch">
		<DBServer>Node IP1,Node IP1,..,Node IPx</DBServer>
		<UID>elastic</UID>
		<PWD>{220CCF11-0785-4712-BBAB-E7DD72CFB0D6}</PWD>
	</DataBase>
```
4. Save the file, and then start the DataMiner agent.
5. Once running, confirm that no errors related to the database configuration are reported.

Before executing the procedure above, make sure the DataMiner agent has an available connection to each node of the
Elasticsearch cluster. To do so, you can use the URL http://elasticnodeip:9200/ from a Web Browser in the agent.
A positive response should present Elasticsearch's general server information.


