---
uid: docintel
---

# Document Intelligence

Starting from version 2.0.7, the [DataMiner Assistant](xref:Assistant_DxM) DxM will be able to analyze documents based on specific instructions.
The functionality is available over API in DataMiner automation. Both the document file and the instructions need to be provided by the user when sending a Document Intelligence request.

Example of such requests could be:

- Extracting satellite parameters from a PDF file
- Extracting contract information from a video content rights contract in Word
- Extracting order data from a bill of materials (BOM) Excel document

## How it works

DataMiner Assistant uses a combination of OCR (Optical Character Recognition) & LLMs (Large Lanaguage Models) in the background to perform the desired operations on the files. When a file is uploaded for analysis, the DxM will first process the document using OCR, which provides a plain text representation of the file content. As a second step, this information is packed together with the provided user instructions (prompt) and sent to an LLM for further interpretation. This two-step approach ensures maximum flexibility and reliability.

![DataMiner Document Intelligence](~/dataminer/images/documentintelligence_diagram.png)<br>*Using Document Intelligence API in DataMiner Automation Scripts*



> [!TIP]
> The quality of the generated response is tightly bound to the quality of the provided inputs (files and intstructions). The tool will perform better on more structured files that contain as little unrelevant information as possible. Next to that, the instructions fed to the model on how to interpret the file content should also be carefully selected. Check section [Input instructions](xref:docintel#user-instructions) for tips on how to structure the instructions optimally.

## Input files

In principle, every file format supported by Azure Document Intelligence Service can be analyzed via the Document Intelligence API.
At this point in time, the following formats are supported:

- Images (JPEG/JPG, PNG, BMP, HEIF)
- PDF
- TIFF
- Word (DOCX): embedded or linked images not supported
- Excel (XLSX): embedded or linked images not supported
- PowerPoint (PPTX): embedded or linked images not supported
- HTML: embedded or linked images not supported

## Input instructions

The input instructions will tell the tool Document Intelligence tool what is supposed to do. Generally speaking, any text containing instructions formulated in natural language will be accepted.
However, some basic guidelines can truly make a difference between an excellent and a mediocre Document Intelligence response:

- **Be specific**. Vague requests often result in poor responses. The more context and specificity you provide, the more targeted and useful the response will be. 
- **Focus on the essentials**. Extra information that is not directly relevant to your main question can sometimes pull the response in unintended directions. Avoiding tangential details is key.
- **Mention your desired format**. Specify if the response should conform to a specific structure. For example, if the response should be in json format, it is best to explain in advance which fields and values are allowed and/or required. 
- **Show, don't tell**. One good example is worth a thousand instructions. If possible, include a practical example of the response you would like to get.

An example of instructions that can be fed to the tool is shown below:

```txt
EXAMPLE OUTPUT:
{
	"satellites": [
		{
			"satellite_name": "SKY3B-3E",
			"uplink": {
				"frequency": "13062.5 MHz",
				"polarization": "Horizontal"
			},
			"downlink": {
				"frequency": "11262.5 MHz",
				"polarization": "Vertical"
			},
			"parameters": {
				"modulation_standard": "NS4",
				"symbol_rate": "35.294 MSym/s",
				"fec": "7/8"
            }
		}
	]
}

POSSIBLE VALUES:
"satellite_name": ["EUT1", "EUT2", "SKY3B-3E"],
"polarization": ["Horizontal", "Vertical"],
"modulation_standard": ["DVB-S", "DVB-S2", "NS3", "NS4"],
"roll_off":["5%", "10%"],
"fec": ["1/2", "2/3", "4/5"],

REQUIRED FORMATS:
Date values should be formatted as dd/mm/yyyy hh:mm:ss.
Frequency values should be formatted in MHz with 6 digits and 3 decimals places (e.g., 123.567 MHz). 
Symbol rate should be formatted in MSym/s with 3 decimals.

ADDITIONAL INFORMATION:
When things that are represented in a list such as satellites and they are not found in the document, just return an empty json array [] such as "satellites": []
For Satellites, you will see that the names are often an abbreviation of a Satellite provider (e.g. EUT) followed by numbers and letters (e.g. 7A), we're not interested in the letters so you can map "EUT 7A-7E" for example to "EUT 7"
```

## Integration in DataMiner Automation scripts

From DataMiner Main Release 10.6 (CU0) and Feature Release 10.6.1 onwards, it is be possible to seamlessly integrate Document Intelligence into [DataMiner Automation](xref:automation). Hereafter a code snippet showing how to use the built-in API call. The namespaces used in the snippet below require nuget Skyline.DataMiner.Dev.Automation (10.6.0 onwards) to included in your Automation Script project to resolve the namespaces.

```csharp
using Skyline.DataMiner.Net.Apps.DocumentIntelligence;
using Skyline.DataMiner.Net.Apps.DocumentIntelligence.Objects;

public void Run(IEngine engine)
{   
    // Read in file content
    var filepath = "C://myFolder//myFile.pdf";
    var fileBytes = File.ReadAllBytes(filepath);
    // Write instructions
    var instructions = "Extract the start and end time of my streaming event";
    // Create Document Intelligence helper
    var docIntelHelper = new DocumentIntelligenceHelper(engine.SendSLNetMessages);
    // Request Document Intelligence analysis
    var analysisResult = docIntelHelper.AnalyzeDocuments(instructions, new List<Document>() 
    { 
        new Document() 
        { 
            Name = "myFile.pdf", 
            Content = fileBytes 
        }
    });
}
```

> [!TIP]
> Eager to see Document Intelligence in action? The [Processing PDF documents using AI](https://catalog.dataminer.services/details/cb4988f9-f3e5-45b7-aade-144f21e9755a) package offers a ready-to-use Satellite Parameter Extractor app. This app showcases how to extract parameters from a pdf file as a fully automated step in the context of a satellite reservations pipeline. It offers real-life examples of input files, custom istructions and integration into DataMiner Automation. Go to the [Catalog app](https://catalog.dataminer.services/) to deploy the package and start diving into this feature!

## Data handling

The Document Intelligence features relies on external AI services, both for OCR as for LLM usage. More specifically, **Azure Document Intelligence Service** and **Azure OpenAI Service (Global Standard Deployment)** are used. Therefore, data is transmitted to Microsoft Azure endpoints for processing. Azure AI Services process data in accordance with Microsoft's data handling policies and all data is encrypted while in transit. 

> [!IMPORTANT]
> - When data is sent to the Document Intelligence Service, both input data and analysis results may be temporarily encrypted and stored in an Azure Storage for a maximum of 24h after the operation has completed. Data is guaranteed to never leave the services's region. For the time being, this will be Western Europe for any user.
> - The Global Standard Deployment of Azure OpenAI ensures the highest availability and lowest costs by processing data across Azure's global infrastructure: while temporarily stored data should never leave the designated region, prompts and responses **might be processed in any geographic area**. In this case, the service's region currently is Sweden for every user.
> - It is the user's responsibility to ensure that the uploaded content complies with their organization's data handling policies, security requirements, and applicable regulations (e.g., GDPR, CCPA).
> - It is highly recommended to review the [Azure Document Intelligence data privacy documentation](https://learn.microsoft.com/en-us/legal/cognitive-services/document-intelligence/data-privacy-security) and the [Azure OpenAI data privacy and security documentation](https://learn.microsoft.com/en-us/legal/cognitive-services/openai/data-privacy).


## Pricing

Document Intelligence consumes **DataMiner credits** proportionally to the amount of data analyzed. The DataMiner credits will be deducted monthly based on metered usage. More information about the pricing of DataMiner usage-based services can be found in the [DataMiner Pricing Overview](xref:Pricing_Usage_based_service#usage-terms)