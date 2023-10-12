**Exercise N1: Automate Signin API to obtain an Authentication Token. After getting the token automate account API**

*Objective: Your task is to write a program that automates the Account API which returns user information.*

*Instructions:*

*You need to automate the process of obtaining an authentication token from the Signi API, create a function or class for this task to make it modular and reusable.*

*The Signi API endpoint for token retrieval is: https://eeapi.qa.benivo.com/user/Signin*

You must make a POST request to this endpoint with the following parameters in the request body:

*Email: Will be provided during the interview*

*Password: Will be provided during the interview*

*PartnerURLName: This should be "AutomationTest"*

*TimeZoneNameIANA: Should be "Asia/Yerevan"*


*After getting response from Singin API you will get a response with the following properties: *
*Status*

*Token*

*HasError*

*AccessToken*

*The next step is to automate Account API using token property received from SignIn API and giving it as a header for Account API*

*The Account API endpoint is: https://api.qa.benivo.com/v3/api/account*

*You must make a GET request to this endpoint providing the token as a header*

*Requirements:*

*Use the C# programming language to automate the API*

*Use an HTTP client library to make the API request.*

*Create a function or class for this task to make it modular and reusable.*

*Deliverables:*

*The code you have written to automate the Signi API and obtain the token.*





**Exercise N2: Automate Signin flow with the help of Selenium WebDriver**

*Objective: Your task is to write a program that automates the login flow of the provided application (https://automationtest.qa.benivo.com), create a function or class for this task to make it modular and reusable.*

*Instructions:*

*You need to automate the process of logging in with the help of Selenium WebDriver, try to use POM model*

*You must open a browser, redirect to "https://automationtest.qa.benivo.com" and use the credentials to login*

*Email: Will be provided during the interview*
*Password: Will be provided during the interview*

*Deliverables:*

*The code you have written to automate the Login flow*


**Exercise N3: Automate cookie accpet logic using shadow rooting**

*Objective: Your task is to click Accept cookies button in the provided application*

*Deliverables:*

*The code you have written to automate the Signi API and obtain the token.*
