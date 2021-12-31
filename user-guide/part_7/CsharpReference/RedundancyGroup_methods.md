## RedundancyGroup methods

#### IsInMaintenance

Checks whether the specified element in the redundancy group is in maintenance mode.

```txt
bool IsInMaintenance(IActionableElement element)                         
bool IsInMaintenance(string elementName)                                 
bool IsInMaintenance(int dmaid, int eid)
```

Examples:

```txt
var redundancyGroup = engine.FindRedundancyGroup("MyRedundancyGroup");
var mainElement = engine.FindElement("MyMainElement");                
                                                                      
bool isInMaintenance = redundancyGroup.IsInMaintenance(mainElement);  
```

```txt
var redundancyGroup = engine.FindRedundancyGroup("MyRedundancyGroup");  
                                                                        
bool isInMaintenance = redundancyGroup.IsInMaintenance("MyMainElement");
```

```txt
var redundancyGroup = engine.FindRedundancyGroup("MyRedundancyGroup");
                                                                      
bool isInMaintenance = redundancyGroup.IsInMaintenance(200, 4000);    
```

#### SetMaintenanceMode

Changes a specified element in the redundancy group

- from normal mode to maintenance mode (inMaintenance = true), or

- from maintenance mode to normal mode (inMaintenance = false).

```txt
void SetMaintenanceMode(IActionableElement element, bool inMaintenance)                         
void SetMaintenanceMode(string elementName, bool inMaintenance)                                 
void SetMaintenanceMode(int dmaid, int eid, bool inMaintenance)
```

Examples:

```txt
var redundancyGroup = engine.FindRedundancyGroup("MyRedundancyGroup");
var mainElement = engine.FindElement("MyMainElement");                
                                                                      
redundancyGroup.SetMaintenanceMode(mainElement, true);                
```

```txt
var redundancyGroup = engine.FindRedundancyGroup("MyRedundancyGroup");
                                                                      
redundancyGroup.SetMaintenanceMode("MyMainElement", true);            
```

```txt
var redundancyGroup = engine.FindRedundancyGroup("MyRedundancyGroup");
                                                                      
redundancyGroup.SetMaintenanceMode(200, 4000, true);                  
```
