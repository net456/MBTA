# MBTA

MBTA soltion consists of 3 projects:

1. MbtaApi - contains MBTA specific JSON models and .Net HttpClient to read API data.
2. MbtaTest - contains nunit tests specific to MBTA api to test basic functionality.
3. MbtaApiConsole - sample console app to demo api access.

Requirements:
1. Visual Studion 2019.
2. NewtonSoft.JSON nuget package.

Initial implementation:
1. Some api calls do not return relationship data, need to further research to find optimal solution.

https://api-v3.mbta.com/routes?include=stop
https://api-v3.mbta.com/routes/?include=stop&id=CR-Worcester
Does not include stops data.
