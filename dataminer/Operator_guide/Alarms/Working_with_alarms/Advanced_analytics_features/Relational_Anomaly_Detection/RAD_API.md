---
uid: RAD_API
---

# Working with the RAD API

The RAD API is a set of messages that allows you to configure [Relational Anomaly Detection](xref:Relational_anomaly_detection) through an [Automation script](xref:automation). Compared to using the [RAD Manager](xref:RAD_manager), the RAD API offers more flexibility, making it particularly useful for use cases that deviate from the default options provided by the RAD Manager.

All messages in the RAD API reside in the `Skyline.DataMiner.Analytics.Rad` namespace. The following messages are available:

| Message | Response message | Description |
|------|-----|-------------|
| [AddRADParameterGroupMessage](xref:Skyline.DataMiner.Analytics.Rad.AddRADParameterGroupMessage) | [AddRADParameterGroupResponseMessage](xref:Skyline.DataMiner.Analytics.Rad.AddRADParameterGroupResponseMessage) | Adds a new relational anomaly group to the RAD configuration or overwrites an existing one. See [Options for RAD parameter groups](xref:Relational_anomaly_detection#options-for-rad-parameter-groups) for details on the available options. |
| [AddRADSubgroupMessage](xref:Skyline.DataMiner.Analytics.Rad.AddRADSubgroupMessage) | [AddRADSubgroupMessage](xref:Skyline.DataMiner.Analytics.Rad.AddRADSubgroupMessage) | Adds a relational anomaly subgroup to a [shared model group](xref:Relational_anomaly_detection#shared-model-groups). Available since DataMiner 10.5.9. |
| [GetRADDataMessage](xref:Skyline.DataMiner.Analytics.Rad.GetRADDataMessage) |[GetRADDataResponseMessage](xref:Skyline.DataMiner.Analytics.Rad.GetRADDataResponseMessage) | Retrieves historical anomaly scores for a specified relational anomaly group within a given time range. |
| [GetRADParameterGroupInfoMessage](xref:Skyline.DataMiner.Analytics.Rad.GetRADParameterGroupInfoMessage) |[GetRADParameterGroupInfoResponseMessage](xref:Skyline.DataMiner.Analytics.Rad.GetRADParameterGroupInfoResponseMessage) | Fetches the configuration of a specific relational anomaly group. |
| [GetRADParameterGroupsMessage](xref:Skyline.DataMiner.Analytics.Rad.GetRADParameterGroupsMessage) |[GetRADParameterGroupsResponseMessage](xref:Skyline.DataMiner.Analytics.Rad.GetRADParameterGroupsResponseMessage) | Returns a list of all configured relational anomaly groups. |
| [RemoveRADParameterGroupMessage](xref:Skyline.DataMiner.Analytics.Rad.RemoveRADParameterGroupMessage) |[RemoveRADParameterGroupResponseMessage](xref:Skyline.DataMiner.Analytics.Rad.RemoveRADParameterGroupResponseMessage) | Removes a relational anomaly group from the RAD configuration. |
| [RemoveRADSubgroupMessage](xref:Skyline.DataMiner.Analytics.Rad.RemoveRADSubgroupMessage) |[RemoveRADSubgroupMessage](xref:Skyline.DataMiner.Analytics.Rad.RemoveRADSubgroupMessage) | Removes a subgroup from a [shared model group](xref:Relational_anomaly_detection#shared-model-groups). Available since DataMiner 10.5.9. |
| [RenameRADParameterGroupMessage](xref:Skyline.DataMiner.Analytics.Rad.RenameRADParameterGroupMessage) |[RenameRADParameterGroupResponseMessage](xref:Skyline.DataMiner.Analytics.Rad.RenameRADParameterGroupResponseMessage) | Renames a relational group. Available since DataMiner 10.5.9. |
| [RetrainRADModelMessage](xref:Skyline.DataMiner.Analytics.Rad.RetrainRADModelMessage) |[RetrainRADModelResponseMessage](xref:Skyline.DataMiner.Analytics.Rad.RetrainRADModelResponseMessage) | Retrains the internal model of a specified relational anomaly group using the provided time ranges. See [Specifying the training range](xref:RAD_manager#specifying-the-training-range) for more information. |

Each request message sent to DataMiner will return a response message of the corresponding type. For example, an `AddRADParameterGroupMessage` will receive an `AddRADParameterGroupResponseMessage` in response, confirming that the request was processed successfully.

## Example

Below you can find an example of an Automation script that uses the RAD API to add a RAD parameter group with four parameter instances for each element of which the name begins with `Commtia LON`.

The core logic resides in the `RunSafe()` method. It loops through all elements matching the filter `Commtia LON*`. For each element, it builds a list of parameters to include in the RAD group, specifically, the output power of three power amplifiers (represented as cells in the same table column), and the total output power of the DAB transmitter. It then constructs a `RADGroupInfo` object, which contains the group's name, the list of parameters, and additional options. Finally, it creates and sends an `AddRADParameterGroupMessage` to DataMiner.

```csharp
namespace AddRADParameterGroupWithAPI
{
    using System;
    using System.Collections.Generic;
    using Skyline.DataMiner.Analytics.DataTypes;
    using Skyline.DataMiner.Analytics.Rad;
    using Skyline.DataMiner.Automation;

    /// <summary>
    /// Represents a DataMiner Automation script.
    /// </summary>
    public class Script
    {
        /// <summary>
        /// The script entry point.
        /// </summary>
        /// <param name="engine">Link with SLAutomation process.</param>
        public void Run(IEngine engine)
        {
            try
            {
                RunSafe(engine);
            }
            catch (ScriptAbortException)
            {
                // Catch normal abort exceptions (engine.ExitFail or engine.ExitSuccess)
                throw; // Comment if it should be treated as a normal exit of the script.
            }
            catch (ScriptForceAbortException)
            {
                // Catch forced abort exceptions, caused via external maintenance messages.
                throw;
            }
            catch (ScriptTimeoutException)
            {
                // Catch timeout exceptions for when a script has been running for too long.
                throw;
            }
            catch (InteractiveUserDetachedException)
            {
                // Catch a user detaching from the interactive script by closing the window.
                // Only applicable for interactive scripts, can be removed for non-interactive scripts.
                throw;
            }
            catch (Exception e)
            {
                engine.ExitFail("Run|Something went wrong: " + e);
            }
        }

        private void RunSafe(IEngine engine)
        {
            // Loop through all elements whose names start with "Commtia LON"
            foreach (var element in engine.FindElementsByName("Commtia LON*"))
            {
                // Create a list of parameter instances to include in the group
                var parameters = new List<ParameterKey>
                {
                    new ParameterKey(element.DmaId, element.ElementId, element.FindParameterID("Output Power"), "PA1"),
                    new ParameterKey(element.DmaId, element.ElementId, element.FindParameterID("Output Power"), "PA2"),
                    new ParameterKey(element.DmaId, element.ElementId, element.FindParameterID("Output Power"), "PA3"),
                    new ParameterKey(element.DmaId, element.ElementId, element.FindParameterID("Tx Amplifier Output Power")),
                };

                // Define the RAD group with its name, parameters, and configuration options
                var groupInfo = new RADGroupInfo($"PA fault ({element.ElementName})", parameters, false);

                // Create the message to add the group to the RAD configuration
                var addMessage = new AddRADParameterGroupMessage(groupInfo);

                // Send the message to DataMiner and receive a response
                var response = engine.SendSLNetSingleResponseMessage(addMessage);
            }
        }
    }
}
```
