---  
uid: Validator_8_3_1  
---

# CheckKeyAttribute

## UnknownHeaderKey

### Description

Unknown Header key '{headerKey}' for HTTP request. Session ID '{sessionId}'. Connection ID '{connectionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | HTTP        |
| Full Id      | 8.3.1       |
| Severity     | Major       |
| Certainty    | Uncertain   |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The community has come to a consensus regarding a list of header keys to be used in HTTP communication.  
The list can be found on following webpage:  
    https:\/\/www.iana.org\/assignments\/message\-headers\/message\-headers.xhtml   
This 'Unknown Header Key' message can be returned by the validator in following 2 scenarios:  
\- The data source requires the usage of such unknown header key because the Vendor simply did not adhere to the consensus \-\> Feel free to suppress the result.  
\- The consensus has been updated and DIS is not up to date \-\> Please report it to the DIS team via the DIS Feedback feature.
