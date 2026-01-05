---
uid: About_DataMiner_connectors
description: DataMiner connectors (or 'protocols'/'drivers') are XML files containing the information needed for DataMiner to communicate with a data source.
---

# About DataMiner connectors

A DataMiner connector (also referred to as a "driver" or "protocol") is an XML file containing all the information a DataMiner Agent needs to be able to communicate with the device: instructions on how to poll the device and display all relevant data on the user interface (i.e. DataMiner Cube element cards), default port settings, alarm thresholds, parameter labels, etc. The language used to define a protocol is referred to as the DataMiner Protocol Markup Language (DPML).

A DataMiner protocol can be uploaded to a DataMiner Agent, so that elements can be created that will run the protocol.

![Conceptual overview of a DataMiner Agent](~/develop/images/DataMinerAgent.svg)

This guide provides an overview of the different components of a protocol and what happens when a protocol is executed by a DataMiner Agent:

- For more information about the key concepts you need to know to be able to develop protocols, see <xref:ConnectorFundamentals>.
- For an overview of the different UI components that can be used in a DataMiner protocol, see <xref:UIComponents>.
- For an overview of the different connection types that are supported in DataMiner, see <xref:Connections>.
- To find out more on how to implement alarming and trending support in a protocol, see <xref:Monitoring>.
- For more information on advanced protocol functionality, see <xref:AdvancedFunctionality>.
- To test your knowledge of DataMiner protocols or find the answers to particular questions, see <xref:QuestionsAndAnswers>.

> [!NOTE]
> As mentioned above, a protocol is an XML file. However, where possible, this guide makes abstraction of the way something is defined in DPML by providing a conceptual description. To learn more about this markup language, see DataMiner Protocol Markup Language.

## Using DataMiner connectors in a DataMiner System

When you have created or updated a DataMiner protocol, it first needs to be uploaded to a DataMiner Agent,
which will then automatically copy it to each of its peers in the DataMiner System it belongs to. You can then
start creating elements that will use that protocol.

- For more information on how to upload a protocol, refer to Adding a protocol or protocol version to your DataMiner System.
- For more information on how to create an element, refer to Adding an element.
