#### [MoodleAssistant](index.md 'index')
### [MoodleAssistant.Logic.Utils](MoodleAssistant.Logic.Utils.md 'MoodleAssistant.Logic.Utils')

## Error Enum

Represents an error that occurred in the replication process.

```csharp
public enum Error
```
### Fields

<a name='MoodleAssistant.Logic.Utils.Error.CsvBadFormed'></a>

`CsvBadFormed` 12

The uploaded CSV file is not well-formed.

<a name='MoodleAssistant.Logic.Utils.Error.CsvInvalidHeader'></a>

`CsvInvalidHeader` 11

The uploaded CSV file has not a valid header.

<a name='MoodleAssistant.Logic.Utils.Error.EmptyFile'></a>

`EmptyFile` 5

The uploaded file is empty.

<a name='MoodleAssistant.Logic.Utils.Error.FileMismatch'></a>

`FileMismatch` 14

The uploaded files names or quantity do not match the values inside the CSV file.

<a name='MoodleAssistant.Logic.Utils.Error.FileTooBig'></a>

`FileTooBig` 6

The uploaded file is too big.

<a name='MoodleAssistant.Logic.Utils.Error.NoErrors'></a>

`NoErrors` 0

No errors occurred.

<a name='MoodleAssistant.Logic.Utils.Error.NoFiles'></a>

`NoFiles` 1

No files were uploaded.

<a name='MoodleAssistant.Logic.Utils.Error.NonCsvFile'></a>

`NonCsvFile` 10

The uploaded file is not a valid CSV file.

<a name='MoodleAssistant.Logic.Utils.Error.NonXmlFile'></a>

`NonXmlFile` 4

The uploaded file is not a valid XML file.

<a name='MoodleAssistant.Logic.Utils.Error.NoValidFile'></a>

`NoValidFile` 13

The uploaded file is not a valid image/MS-Office file.

<a name='MoodleAssistant.Logic.Utils.Error.NullFile'></a>

`NullFile` 2

Uploaded files are null.

<a name='MoodleAssistant.Logic.Utils.Error.Unexpected'></a>

`Unexpected` 3

An unexpected error occurred.

<a name='MoodleAssistant.Logic.Utils.Error.XmlBadFormed'></a>

`XmlBadFormed` 7

The uploaded XML file is not well-formatted.

<a name='MoodleAssistant.Logic.Utils.Error.ZeroAnswers'></a>

`ZeroAnswers` 9

The uploaded XML file has no answers.

<a name='MoodleAssistant.Logic.Utils.Error.ZeroOrMoreQuestions'></a>

`ZeroOrMoreQuestions` 8

The uploaded XML file has zero or more than one question.