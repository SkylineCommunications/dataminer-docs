---
uid: PA_Integrating_Gateways
---

# Integrating gateways

For non-linear processes, which contain more than one branch, gateways can be used. The behavior of a gateway is defined by so-called routing rules.

A gateway is a function with 5 inputs and 5 outputs. Routing rules indicate the condition to generate one or multiple tokens at one or several outputs of the gateway.

![Generic Gateway](~/user-guide/images/Generic_Gateway.png)

Function inputs are numbered from 1 to 5 and function outputs from 11 to 15. Those numbers are used during the configuration of the gateway.

## Extending a process definition with a gateway

To integrate a gateway in a process:

1. In the *Process Automation* app, extend the process definition with a *Generic Gateway* function.

1. Drag the *Generic Gateway* function from the functions sidebar to the workspace and connect it to the relevant tasks/functions.

   > [!NOTE]
   > Make sure the entry point of your process is still a start event and the end point is an end event.

1. Build a JSON string representing the routing rules. See [routing rules](#routing-rules).

1. In the [*Profiles* module](xref:The_Profiles_module), create a profile instance that applies the *PA GW* profile definition and store the serialized routing rules in the *PA GW RoutingRules* parameter.

1. In the *Process Automation* app, launch the *process definition configuration* wizard and select the previously created profile instance when you configure the gateway node.

## Routing rules

The *PA GW RoutingRules* parameter of a profile instance can contain a set of ordered rules, with the option to skip the remaining rules as soon as a rule matches.

A rule contains one or multiple conditions comparing the field value of the process DOM instance or user DOM instance to fixed values.

### General Build

```json
{
    "Evaluation": "First Matching",
    "Rules": [{
                "SequenceId": 1,
                "Description": "Generate a token on each outgoing interface",
                "OutgoingInterfaceIds": [],
                "DoTagTokens": true,
                "Conditions": [{
                    "IncomingGatewayKeyName": "*",
                    "Value": "*",
                    "Operation": "any",
                    "IncomingInterfaceId": -1
                },
                "DomField": {
                    "FieldDescriptorId": "9a15783b-ccc0-4d8f-9574-0870c55f4a73",
                    "SectionDefinitionId": "5d6c39ed-f616-4ad2-b311-28e39d52505a"
                 }
            ]
        }
    ]
}
```

### Routing Rule Json Object

#### RoutingRule Object

| Name | Type | Value | Information |
| --- | --- | --- | --- |
| Evaluation | string (discrete) | First Matching <br>or All Matching | First Matching: The evaluation will stop when the first rule has a match. <br>All Matching: All rules will be evaluated. Only triggered if all of the conditions match. |
| Rules | [Rule](#rule-object)[] | [Rule](#rule-object) | |

#### Rule Object

| Name | Type | Value | Information |
| --- | --- | --- | --- |
| SequenceId | int |  | Needs to be unique. |
| Description | string |  | Description for developers. |
| OutgoingInterfaceIds | int[] | 11, 12, 13, 14, 15 | The list of all the output interface IDs that this rule has to generate a token for. These represent the outgoing interfaces that need to be triggered when this rule matches. |
| DoTagTokens | bool | true or false | Used on a split gateway to tag all tokens generated from the same incoming token with the same unique identifier. On the associated merge gateway, only tokens with the same tag will be considered together for evaluating routing rules. |
| Conditions | [RoutingCondition](#routingcondition-object)[] | [RoutingCondition](#routingcondition-object) | |

#### RoutingCondition Object

| Name | Type | Value | Information |
| --- | --- | --- | --- |
| IncomingGatewayKeyName | nullable string | "\*", null, or another value | For null or "*": Any incoming gateway key name.<br>If you use a DomField, this is entirely ignored, so this will most likely be null.|
| Value | string | | The value that will be used to validate a DOM Field against. |
| Operation | string (discrete) | any or equal | When operation is **any**, the incoming gateway key name and value are ignored.<br>When operation is **equal**, it will match when the incoming value matches the *Value* field. <br> When a DomField is given, it will check the DOM Field instead of the incoming gateway key name. |
| IncomingInterfaceId | int | -1, 1, 2, 3, 4, 5 | It can be one of the specified values. -1 represents all interfaces. |
| DomField | [IncomingDomField](#incomingdomfield-object) | | |

#### IncomingDomField Object

| Name | Type | Value | Information |
| --- | --- | --- | --- |
| FieldDescriptorId | string | | The GUID of the field descriptor defined in the Section Definition of the DOM definition. |
| SectionDefinitionId | string | | The GUID of the Section definition where the field descriptor belongs to. |
| UserDomInstance | string | | The label of the Activity from the Process Definition where the user task gets generated. When this is defined, it will process a user DOM instance instead of the Process DOM instance. |

Below you can find examples of the possible routing rules.

### Parallel split

```json
{
   "Evaluation": "First Matching",
   "Rules": [{
               "SequenceId": 1,
               "Description": "Generate a token on each outgoing interface",
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

### Exclusive split

#### Example 1: Process DOM instance

```json
{
   "Evaluation": "First Matching",
   "Rules": [{
               "SequenceId": 1,
               "Description": "Generate a token on first output (ID11) in case the Field Value in the Process DOM Instance is equal to OK",
               "Conditions": [{
                       "DomField": {
                                   "FieldDescriptorId": "9a15783b-ccc0-4d8f-9574-0870c55f4a73",
                                   "SectionDefinitionId": "5d6c39ed-f616-4ad2-b311-28e39d52505a"
                       },
                         "IncomingGatewayKeyName": null,
                         "Value": "OK",
                         "Operation": "equal",
                         "IncomingInterfaceId": 1
               }
           ],
               "OutgoingInterfaceIds": [11],
               "DoTagTokens": false
           }, {
               "SequenceId": 2,
               "Description": "Generate a token on second output(ID 12) in case the Field Value in the Process DOM Instance is equal to NOK ",
               "Conditions": [{
                   "DomField": {
                               "FieldDescriptorId": "9a15783b-ccc0-4d8f-9574-0870c55f4a73",
                               "SectionDefinitionId": "5d6c39ed-f616-4ad2-b311-28e39d52505a"
                   },
                   "IncomingGatewayKeyName": null,
                   "Value": "NOK",
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

#### Example 2: User DOM instance

```json
{
   "Evaluation": "First Matching",
   "Rules": [{
               "SequenceId": 1,
               "Description": "Generate a token on first output (ID11) in case the Field Value in the Process DOM Instance is equal to OK",
               "Conditions": [{
                       "DomField": {
                                   "UserDomInstance": "Main"
                                   "FieldDescriptorId": "9a15783b-ccc0-4d8f-9574-0870c55f4a73",
                                   "SectionDefinitionId": "5d6c39ed-f616-4ad2-b311-28e39d52505a"
                       },
                         "IncomingGatewayKeyName": null,
                         "Value": "OK",
                         "Operation": "equal",
                         "IncomingInterfaceId": 1
               }
           ],
               "OutgoingInterfaceIds": [11],
               "DoTagTokens": false
           }, {
               "SequenceId": 2,
               "Description": "Generate a token on second output(ID 12) in case the Field Value in the Process DOM Instance is equal to NOK ",
               "Conditions": [{
                   "IncomingGatewayKeyName": null,
                   "Value": "NOK",
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

### Inclusive split

```json
{
   "Evaluation": "All Matching",
   "Rules": [{
           "SequenceId": 1,
           "Description": "Generate a token on first output (ID11) in case the Field Value X in the Process DOM Instance is equal to OK",
           "Conditions": [{
                   "DomField": {
                                    "FieldDescriptorId": "9a15783b-ccc0-4d8f-9574-0870c55f4a73",
                                    "SectionDefinitionId": "5d6c39ed-f616-4ad2-b311-28e39d52505a"
                       },
                   "IncomingGatewayKeyName": null,
                   "Value": "OK",
                   "Operation": "equal",
                   "IncomingInterfaceId": 1
               }
           ],
           "OutgoingInterfaceIds": [11],
           "DoTagTokens": false
       }, {
           "SequenceId": 2,
           "Description": "Generate a token on second output(ID 12) in case the Field Value Y in the Process DOM Instance is equal to No",
           "Conditions": [{
                   "DomField": {
                                    "FieldDescriptorId": "ff15785b-5550-4d52-5146-045255f54993",
                                    "SectionDefinitionId": "aa6c33dd-f616-4ad2-b311-20e42d5320ff"
                       },
                   "IncomingGatewayKeyName": null,
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

### Parallel merge

#### Example 1

```json
{
   "Evaluation": "All Matching",
   "Rules": [{
               "SequenceId": 1,
               "Description": "Generate a token as soon as we have received a token on each of the 2 incoming interfaces",
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

#### Example 2

```json
{
   "Evaluation": "All Matching",
   "Rules": [{
                   "SequenceId": 1,
                   "Description": "Generate a token as soon as we have received an incoming token on input 1 and 2",
                   "Conditions": [{
                                       "DomField": {
                                                       "FieldDescriptorId": "ff15785b-5550-4d52-5146-045255f54993",
                                                       "SectionDefinitionId": "aa6c33dd-f616-4ad2-b311-20e42d5320ff"
                                       },
                                           "IncomingGatewayKeyName": null,
                                           "Value": "OK",
                                           "Operation": "equal",
                                           "IncomingInterfaceId": 1
                                 }, {
                                       "DomField": {
                                                       "FieldDescriptorId": "9a15783b-ccc0-4d8f-9574-0870c55f4a73",
                                                       "SectionDefinitionId": "5d6c39ed-f616-4ad2-b311-28e39d52505a "
                                        },
                                           "IncomingGatewayKeyName": null,
                                           "Value": "OK",
                                           "Operation": "equal",
                                           "IncomingInterfaceId": 2
                                    }
                   ],
                   "OutgoingInterfaceIds": [11],
                   "DoTagTokens": false
       }
   ]
}
```
