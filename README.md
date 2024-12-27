# MoodleAssistant #

**MoodleAssistant** is a web application that generates multiple question variants for Moodle from a single template question, enabling users to create diverse quizzes with minimal effort.

## Usage ##

To generate your questions, you need two files:
* a template question, written with the Moodle XML format (you can write the question from scratch, or write it in Moodle an then export it)
* a CSV file.

The template question must contain **parameters**. There are different type of parameters:

Type | Format
------------- | -------------
Basic parameter (string) | <code>[*[[parameter]]*]</code>
File parameter (MS Word, Excel...) | <code>[*[[FILE-parameter]]*]</code>
Image parameter | <code>[*[[IMAGE-parameter]]*]</code>

You can find more informations at the [Tutorial page](https://moodleassistant.azurewebsites.net/Tutorial) of the website.

## Deploy ##
