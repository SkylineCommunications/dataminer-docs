## SpectrumPreset methods

- [GetCenterFrequency](#getcenterfrequency)

- [GetFrequencySpan](#getfrequencyspan)

- [GetRBW](#getrbw)

- [GetReferenceLevel](#getreferencelevel)

- [GetReferenceScale](#getreferencescale)

- [GetStartFrequency](#getstartfrequency)

- [GetStopFrequency](#getstopfrequency)

- [GetSweepTime](#getsweeptime)

- [GetVBW](#getvbw)

- [Save](#save)

- [SetCenterFrequency](#setcenterfrequency)

- [SetFrequencySpan](#setfrequencyspan)

- [SetRBW](#setrbw)

- [SetReferenceLevel](#setreferencelevel)

- [SetReferenceScale](#setreferencescale)

- [SetStartFrequency](#setstartfrequency)

- [SetStopFrequency](#setstopfrequency)

- [SetSweepTime](#setsweeptime)

- [SetVBW](#setvbw)

#### GetCenterFrequency

Retrieves the center frequency.

```txt
double GetCenterFrequency()
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
double centerFrequency = preset.GetCenterFrequency();               
```

#### GetFrequencySpan

Retrieves the frequency span.

```txt
double GetFrequencySpan()
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
double frequencySpan = preset.GetFrequencySpan();                   
```

#### GetRBW

Retrieves the resolution bandwidth (RBW) value.

```txt
double GetRBW()
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
double rbw = preset.GetRBW();                                       
```

#### GetReferenceLevel

Retrieves the reference level.

```txt
double GetReferenceLevel()
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
double referenceLevel = preset.GetReferenceLevel();                 
```

#### GetReferenceScale

Retrieves the reference scale.

```txt
double GetReferenceScale()
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
double referenceScale = preset.GetReferenceScale();                 
```

#### GetStartFrequency

Retrieves the start frequency.

```txt
double GetStartFrequency()
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
double startFrequency = preset.GetStartFrequency();                 
```

#### GetStopFrequency

Retrieves the stop frequency.

```txt
double GetStopFrequency()
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
double stopFrequency = preset.GetStopFrequency();                   
```

#### GetSweepTime

Retrieves the sweep time.

```txt
double GetSweepTime()
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
double sweepTime = preset.GetSweepTime();                           
```

#### GetVBW

Retrieves the video bandwidth (VBW).

```txt
double GetVBW()
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
double vbw = preset.GetVBW();                                       
```

#### Save

Saves the preset.

```txt
void Save()
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
preset.SetCenterFrequency(100000000);                               
preset.Save();                                                      
```

#### SetCenterFrequency

Sets the center frequency.

```txt
void SetCenterFrequency(double value)
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
preset.SetCenterFrequency(100000000);                               
preset.Save();                                                      
```

#### SetFrequencySpan

Sets the frequency span.

```txt
void SetFrequencySpan(double value)
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
preset.SetFrequencySpan(10000000);                                  
preset.Save();                                                      
```

#### SetRBW

Sets the resolution bandwidth (RBW).

```txt
void SetRBW(double value)
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
preset.SetRBW(1000000);                                             
preset.Save();                                                      
```

#### SetReferenceLevel

Sets the reference level.

```txt
void SetReferenceLevel(double value)
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
preset.SetReferenceLevel(100);                                      
preset.Save();                                                      
```

#### SetReferenceScale

Sets the reference scale.

```txt
void SetReferenceScale(double value)
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
preset.SetReferenceScale(100);                                      
preset.Save();                                                      
```

#### SetStartFrequency

Sets the start frequency.

```txt
void SetStartFrequency(double value)
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
preset.SetStartFrequency(100000000);                                
preset.Save();                                                      
```

#### SetStopFrequency

Sets the stop frequency.

```txt
void SetStopFrequency(double value)
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
preset.SetStopFrequency(10000000000);                               
preset.Save();                                                      
```

#### SetSweepTime

Sets the sweep time.

```txt
void SetSweepTime(double value)
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
preset.SetSweepTime(10);                                            
preset.Save();                                                      
```

#### SetVBW

Sets the video bandwidth (VBW).

```txt
void SetVBW(double value)
```

Example:

```txt
Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");    
                                                                    
preset.SetVBW(1000000);                                             
preset.Save();                                                      
```
