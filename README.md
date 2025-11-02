# FinalTaskFundamentalsAutomationTesting

# Overview
This repository contains automated tests for the Final Task Fundamentals project. 
This solution provides a robust, maintainable, and scalable test automation framework that meets all the specified requirements. 
The tests can be executed in parallel across different browsers and provide detailed logging for debugging and reporting.

# Components
- Programming Language: C#
- Testing Framework: MSTest 
- Automation Tool: Selenium WebDriver	
- Browsers Supported: Chrome, Edge
- Loggging Framework: NLog
- Assertion Library: FluentAssertions for readable assertions
- BDD Framework: Reqnroll for behavior-Driven Development style tests
- Data Provider: Parameterized tests with multiple browsers and users from json file
- Design Patterns:
    - Page Object Model (LoginPage, InventoryPage with BasePage)
    - Factory pattern for WebDriver initialization     
    - Singleton pattern for Logger configuration
    - Strategy pattern for Logger implementation

## Setup
1. Install required NuGet packages
2. Run tests via Test Explorer or command line

# Test Case Description
The tests are designed to verify the functionality, stability, and reliability of the login page https://www.saucedemo.com/
through a variety of test cases, implemented using the BDD (Behavior-Driven Development) approach:

UC1: Login Validation

    As a user of the application
    I want to be informed when required fields are missing
    so that I can provide the correct login information

Scenario: Login with empty credentials
        - Given the user is on the login page
        - When he enters credentials and then clears both fields and clicks the Login button
        - Then an error message "Username is required" should be displayed
    
UC2: Login Validation

    As a user of the application
    I want to be informed when required fields are missing
    so that I can provide the correct login information

Scenario: Login with credentials by passing Username
        - Given the user is on the login page
        - When he enters a username, enters a password, then clears the password and clicks the Login button
        - Then an error message "Password is required" should be displayed
       
UC3: Login Success

    As a user of the application
    I want to log in with valid credentials
    so that I can access the dashboard and perform actions

Scenario: Login with accepted credentials
        - Given the user is on the login page
        - When he enters a valid username and the password and clicks the Login button
        - Then the dashboard should be displayed with the title "Swag Labs"  