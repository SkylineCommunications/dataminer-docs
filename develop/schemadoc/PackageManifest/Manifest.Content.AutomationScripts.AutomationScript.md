---
uid: Manifest.Content.AutomationScripts.AutomationScript
---

# AutomationScript element

Specifies an Automation script to be included in the package.

## Parent

[AutomationScripts](xref:Manifest.Content.AutomationScripts)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[RepoPath](xref:Manifest.Content.AutomationScripts.AutomationScript.RepoPath)||Specifies the repository path of the Automation script solution.|
|&nbsp;&nbsp;[Selection](xref:Manifest.Content.AutomationScripts.AutomationScript.Selection)|[0, 1]|In case the Automation script solution consist of multiple Automation scripts, the Selection element allows to specify which Automation scripts should be included in the package. By default, all Automation scripts will be included.|
|&nbsp;&nbsp;[Version](xref:Manifest.Content.AutomationScripts.AutomationScript.Version)||Specifies the version of the Automation script solutions.|
