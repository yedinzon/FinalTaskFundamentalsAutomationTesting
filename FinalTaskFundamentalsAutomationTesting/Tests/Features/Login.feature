Feature: Login Functionality
    As a user of the application 
    I want to be informed when required fields are missing
    So that I can provide the correct login information

@UC1
Scenario Outline: UC1 - Login with empty credentials should show username error
    Given I am on the login page in "<browser>" browser
    When I attempt to login with empty credentials
    Then I should see an error message containing "Username is required"

    Examples:
    | browser |
    | Chrome  |
    | Edge    |

@UC2
Scenario Outline: UC2 - Login with username only should show password error
    Given I am on the login page in "<browser>" browser
    When I attempt to login with username "<username>" and empty password
    Then I should see an error message containing "Password is required"

    Examples:
    | browser | username   |
    | Chrome  | user-test  |
    | Edge    | user-test  |

@UC3
Scenario Outline: UC3 - Login with valid credentials should navigate to dashboard
    Given I am on the login page in "<browser>" browser
    When I login with username "<username>" and password "<password>"
    Then I should be redirected to the dashboard with title "Swag Labs"

    Examples:
    | browser | username       | password      |
    | Chrome  | standard_user  | secret_sauce  |
    | Edge    | standard_user  | secret_sauce  |