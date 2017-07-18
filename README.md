# POST http://app.idware.net:5050/api/ocr/ReadDocument
## Request Information

### Request Headers
|Name|Description|Type|Additional information|
|-----|-------|-----|-----------|
|Authorization||ApiKey XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX|Required|


### Request Content
|Name|Description|Type|Additional information|
|-----|-------|-----|-----------|
|||Multipart Form Data|Collection of image/jpeg|

## Response Information
|Name|Description|Type|Additional information|
|-----|-------|-----|-----------|
|RecognizeResponseItems||Collection of RecognizeResponse||

## RecognizeResponse
|Name|Description|Type|Additional information|
|-----|-------|-----|-----------|
|ImageId||int||
|FileName||string|
|Document||RecognizedDocument||
|Status||string||
|ErrorMsg||string|

## RecognizedDocument
|Name|Description|Type|Additional information|
|-----|-------|-----|-----------|
|IDType||RecognizedValue||
|Country||RecognizedValue||
|AbbrCountry||RecognizedValue||
|Abbr3Country||RecognizedValue||
|ID||RecognizedValue||
|DOB||RecognizedValue||
|Issued||RecognizedValue||
|Expires||RecognizedValue||
|FullName||RecognizedValue||
|PrivateName||RecognizedValue||
|FamilyName||RecognizedValue||
|City||RecognizedValue||
|State||RecognizedValue||
|Zip||RecognizedValue||
|Address||RecognizedValue||
|Class||RecognizedValue||
|Gender||RecognizedValue||
|Height||RecognizedValue||
|Eyes||RecognizedValue||
|Hair||RecognizedValue||
|Weight||RecognizedValue||
|Template||RecognizedValue||
|FirstName||RecognizedValue||
|MiddleName||RecognizedValue||
|Picture||RecognizedValue||
|Signature||RecognizedValue||

### RecognizedValue
|Name|Description|Type|Additional information|
|-----|-------|-----|-----------|
|Value||string||
|Confidence||int||

## Raw Response Example
```
[
  {
    "ImageId": 292,
    "FileName": "1.jpg",
    "Document": {
      "IDType": null,
      "Country": {
        "Value": "United States",
        "Confidence": 1
      },
      "AbbrCountry": null,
      "Abbr3Country": {
        "Value": "USA",
        "Confidence": 1
      },
      "ID": {
        "Value": "D616067108334",
        "Confidence": 1
      },
      "DOB": {
        "Value": "5/1/1977",
        "Confidence": 1
      },
      "Issued": {
        "Value": "4/1/2011",
        "Confidence": 1
      },
      "Expires": {
        "Value": "5/1/2015",
        "Confidence": 1
      },
      "FullName": {
        "Value": "ANNE CARR DRIVER",
        "Confidence": 1
      },
      "PrivateName": null,
      "FamilyName": null,
      "City": {
        "Value": "LANSING",
        "Confidence": 1
      },
      "State": {
        "Value": "MI",
        "Confidence": 1
      },
      "Zip": {
        "Value": "4891/*1(*)0",
        "Confidence": 1
      },
      "Address": {
        "Value": "123 NORTH STATE ST.",
        "Confidence": 1
      },
      "Class": {
        "Value": "0",
        "Confidence": 1
      },
      "Gender": {
        "Value": "F",
        "Confidence": 1
      },
      "Height": {
        "Value": "162 cm",
        "Confidence": 1
      },
      "Eyes": {
        "Value": "Brown",
        "Confidence": 1
      },
      "Hair": null,
      "Weight": null,
      "Template": null,
      "FirstName": null,
      "MiddleName": null,
      "Picture": null,
      "Signature": null
    },
    "Status": "Success",
    "ErrorMsg": null
  }
]
```
