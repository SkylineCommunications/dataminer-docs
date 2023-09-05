---  
uid: Validator_6_7_1  
---

# CheckActionTypes

## IncompatibleTypeVsOnTag

### Description

Incompatible 'Action\/Type' value '{actionType}' with 'Action\/On' value '{actionOn}'. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.7.1       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Only the following combination of 'Action\/On' and 'Action\/Type' are supported.  
\- command  
    \- crc  
    \- length  
    \- make  
    \- replace  
    \- replace data  
    \- stuffing  
\- group  
    \- add to execute  
    \- execute  
    \- execute next  
    \- execute one  
    \- execute one top  
    \- execute one now  
    \- force execute  
    \- set  
    \- set with wait  
\- pair  
    \- set next  
    \- timeout  
\- parameter  
    \- aggregate  
    \- append  
    \- append data  
    \- change lenght  
    \- clear  
    \- clear on display  
    \- copy  
    \- copy reverse  
    \- go  
    \- increment  
    \- multiply  
    \- normalize  
    \- pow  
    \- read  
    \- replace data  
    \- reverse  
    \- run actions  
    \- save  
    \- set  
    \- set and get with wait  
    \- set info  
    \- set with wait  
\- protocol  
    \- close  
    \- lock\/unlock  
    \- merge  
    \- open  
    \- priority lock\/unlock  
    \- read file  
    \- sleep  
    \- stop current group  
    \- swap column  
    \- wmi  
\- response  
    \- clear  
    \- clear length info  
    \- crc  
    \- length  
    \- read  
    \- read stuffing  
    \- replace  
    \- replace data  
    \- stuffing  
\- timer  
    \- restart timer  
    \- start  
    \- stop  
    \- reschedule
