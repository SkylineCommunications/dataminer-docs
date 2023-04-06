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
