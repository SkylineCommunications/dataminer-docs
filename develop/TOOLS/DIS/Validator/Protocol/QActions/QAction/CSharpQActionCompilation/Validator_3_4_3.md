---  
uid: Validator_3_4_3  
---

# CSharpQActionCompilation

## NoCSharpCodeAnalysisPerformed

### Description

No C\# QAction code analysis was performed due to unsupported C\# version '{cSharpVersion}' in Visual Studio version '{visualStudioVersion}'.

### Properties

| Name         | Value     |
| ------------ | --------- |
| Category     | QAction   |
| Full Id      | 3.4.3     |
| Severity     | Warning   |
| Certainty    | Uncertain |
| Source       | Validator |
| Fix Impact   | Undefined |
| Has Code Fix | False     |

### Details

No C\# QAction code analysis could be performed due to following mismatch in supported C\# syntax versions:  
\- C\# syntax up to and including version 7.3 is supported by the protocol (see 'Compliancies\/MinimumRequiredVersion' tag).  
\- C\# 7.3 syntax is not supported by this Visual Studio (See Visual Studio version).
