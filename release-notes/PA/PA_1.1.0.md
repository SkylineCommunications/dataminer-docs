---
uid: PA_1.1.0
---

# PA 1.1.0

## New features

#### Support for 'Preemptive' flag and token priority \[ID_27813\]

The token object has been extended with a "Preemptive" flag, which is defined in the *PA_Preemptive* parameter. The *Skyline Queue Manager* driver has been adjusted to process tokens first based on this flag and then based on the token priority.

#### Support for gateways \[ID_28143\]

When an output token is generated, an activity will now associate one or more gateway keys with it, defining the result of the activity. These gateway keys will then be used by gateways that will decide where the token should be routed. Each gateway has a routing table defining this behavior. The routing table is stored in the profile instance of the activity function, in the *PA_GW_RoutingRules* parameter. This parameter is meant to be filled in based on JSON code containing the routing rules and evaluation type.

The evaluation type can be:

- *First Matching*: The first matching rule should be identified and one single token should be generated.
- *All Matching*: A token should be generated for each matching rule.

A routing rule defines:

- A sequence ID (integer)
- A "DoTagTokens" boolean (see below)
- A list of "OutgoingInterfaceIds", which refer to local interface IDs
- A list of conditions:

  - An "IncomingGatewayKeyName" (optional in case of "Any" operation)
  - A Value (optional in case of "Any" operation)
  - An Operation: Only "Equal" and "Any" are currently supported. "Any" means that the gateway key and value are ignored, and only the incoming interface ID is matched)
  - A list of IDs of incoming interfaces. Alternatively, -1 can be specified to indicate all incoming interfaces.

Token objects will have the following additional fields to support this:

- *Initial Token Guid*: Used to identify all tokens related to an initial token.
- *Custom Identifier*: Used to identify tokens related to one another.

The token object will also have a list of parent token GUIDs, as multiple incoming tokens can result in one single outgoing token.

When a token arrives in the gateway queue and the conditions of a routing rule are met, a new token will be generated. In case *DoTagTokens* is set to true, a new *Custom Identifier* ID will be generated and attached to the token. The new token will contain all the information (process profile instances, gateway keys and activity metadata) from the incoming tokens matching the rules.

Below you can find a number of examples of routing rules:

- AND-Split rule:

    ```json
    {
        "Evaluation": "First Matching",
        "Rules": [{
                "SequenceId": 1,
                "Description": "Generate on each outgoing interface",
                "Conditions": [{
                        "IncomingGatewayKeyName": "*",
                        "Value": "*",
                        "Operation": "any",
                        "IncomingInterfaceId": -1
                    }
                ],
                "OutgoingInterfaceIds": [],
                "DoTagTokens": true
            }
        ]
    }
    ```

- AND-Merge or OR-Merge rule:

    ```json
    {
        "Evaluation": "First Matching",
        "Rules": [{
                "SequenceId": 1,
                "Description": "Generate a token as soon as we have received an incoming token on each of the 2 incoming connected interfaces",
                "Conditions": [{
                        "IncomingGatewayKeyName": "*",
                        "Value": "*",
                        "Operation": "any",
                        "IncomingInterfaceId": 1
                    }, {
                        "IncomingGatewayKeyName": "*",
                        "Value": "*",
                        "Operation": "any",
                        "IncomingInterfaceId": 2
                    }
                ],
                "OutgoingInterfaceIds": [11],
                "DoTagTokens": false
            }
        ]
    }
    ```

- XOR-Split rule:

    ```json
    {
     "Evaluation": "First Matching",
        "Rules": [{
                "SequenceId": 1,
                "Description": "Generate a token on first output (ID11) in case GK Ping_Result equal to OK",
                "Conditions": [{
                        "IncomingGatewayKeyName": "Ping_Result",
                        "Value": "OK",
                        "Operation": "equal",
                        "IncomingInterfaceId": 1
                    }
                ],
                "OutgoingInterfaceIds": [11],
                "DoTagTokens": false
            }, {
                "SequenceId": 2,
                "Description": "Generate a token on second output(ID 12 ) in case GK TESTKEY equal to OK",
                "Conditions": [{
                        "IncomingGatewayKeyName": "TESTKEY",
                        "Value": "OK",
                        "Operation": "equal",
                        "IncomingInterfaceId": 1
                    }
                ],
                "OutgoingInterfaceIds": [12],
                "DoTagTokens": false
            }
        ]
    }
    ```

- XOR-Merge rule:

    ```json
    {
        "Evaluation": "First Matching",
        "Rules": [{
                "SequenceId": 1,
                "Description": "Generate a token on first output (ID11) when receiving a token on any input",
                "Conditions": [{
                        "IncomingGatewayKeyName": "*",
                        "Value": "*",
                        "Operation": "any",
                        "IncomingInterfaceId": -1
                    }
                ],
                "OutgoingInterfaceIds": [11],
                "DoTagTokens": false
            }
        ]
    }
    ```

- OR-Split rule:

    ```json
    {
        "Evaluation": "All Matching",
        "Rules": [{
                "SequenceId": 1,
                "Description": "Generate a token on first output (ID11) in case GK Ping_Result equal to OK",
                "Conditions": [{
                        "IncomingGatewayKeyName": "Ping_Result",
                        "Value": "OK",
                        "Operation": "equal",
                        "IncomingInterfaceId": 1
                    }
                ],
                "OutgoingInterfaceIds": [11],
                "DoTagTokens": false
            }, {
                "SequenceId": 2,
                "Description": "Generate a token on second output(ID 12) in case not all ping have succeeded",
                "Conditions": [{
                        "IncomingGatewayKeyName": "Ping_AllSucceed",
                        "Value": "No",
                        "Operation": "equal",
                        "IncomingInterfaceId": 1
                    }
                ],
                "OutgoingInterfaceIds": [12],
                "DoTagTokens": false
            }
        ]
    }
    ```

#### New ExecuteTokenHandler methods \[ID_28216\]

Two new methods are available that can be used for the callback to the *TokenHandler* script in Profile-Load scripts. These are available in the *ProcessAutomationManager* class in the *Skyline.DataMiner.DataMinerSolutions.ProcessAutomation namespace*.

```csharp
public static void ExecuteTokenHandler(Engine engine, ScriptInfo scriptInfo, MessageType messageType);
```

Executes the token handler script defined in the *ScriptInfo* parameter with the same process profile instances, gateway keys and activity metadata.

Parameters:

- *Engine*: Link with the SLScripting process.
- *ScriptInfo*: The data needed to perform the callback operation.
- *MessageType*: The type of message exchanged between the queue element, token handler and profile load scripts.

```csharp
public static void ExecuteTokenHandler(Engine engine, ScriptInfo scriptInfo, MessageType messageType, ProcessProfileInstances processProfileInstances, Dictionary<string, string> activityMetadata, Dictionary<string, string> gatewayKeys);
```

Executes the token handler script defined in the *ScriptInfo* parameter with new process profile instances, gateway keys and activity metadata.

Parameters:

- *Engine*: Link with the SLScripting process.
- *ScriptInfo*: The data needed to perform the callback operation.
- *MessageType*: The type of message exchanged between the queue element, token handler and profile load scripts.
- *ProcessProfileInstances*: The list of process profile instances passed to the token handler.
- *ActivityMetadata*: The activity metadata passed to the token handler.
- *GatewayKeys*: The gateway keys passed to the token handler.

#### Queue elements now only created depending on ProcessAutomation property of resource pool \[ID_28225\]

The *SRM_Setup* script will now only create queue elements for a resource pool if that resource pool contains a property named *ProcessAutomation* with the value *True*.

#### New Skyline Process Automation Gateways driver \[ID_28323\]

A new *Skyline Process Automation Gateways* driver is now available. It can be used to create an element that supports Process Automation gateways, storing both functional data and status information related to Repeat Rules, which are used to generate multiple tokens based on one incoming token.

## Changes

### Enhancements

#### Improved handling of tokens \[ID_26939\]

The *Skyline Queue Manager* protocol will now handle tokens differently, so that it is possible to read a token in the token handler script when a booking is finished early.

#### PA_TokenHandler script supports empty values for specific objects \[ID_28138\]

The *PA_TokenHandler* script now supports empty values for the gateway key, activity metadata and process profile instances.

#### PA_TokenHandler script now supports finish message \[ID_28217\]

The *PA_TokenHandler* script now supports a finish message. When it receives such a message, it will ask the user for the resource to complete a token.

#### PA_TokenHandler script now supports bulk operations \[ID_28319\]

In order to reduce the number of calls required for gateways, the *PA_TokenHandler* script now supports bulk operations. The Process Automation framework has been extended with several methods to support these operations.

#### SRM_Setup script now creates pool resources with maximum allowed concurrency \[ID_28326\]

The *SRM_Setup* script will now create pool resources with a maximum allowed concurrency of 2147483647.

### Fixes

#### Skyline Queue Manager swapped resources while this was not necessary \[ID_28072\]

In some cases, it could occur that the *Skyline Queue Manager* swapped resources while this was not necessary.
