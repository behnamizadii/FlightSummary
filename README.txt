Start of the project: Saturday 18/Aug
Finished On: Tuesday 21/Aug

Assumptions:
Port 55756 is open for the service to run.
The path C:\Users\Public exist and it is accessible for the Logs and Output files generation.

Running Project:
Project is written using Visual Studio 2017 (15.7.1) for compatibility please run it using 2017 version
Please assure both API and Client are running simultaneously
right click on the solution -> Properties -> From Startup project choose Multiple Projects -> choose both Set both API and Client projects
to start.

Running Test Cases:
Make sure the processor architecture of the test runner is set to X64:	
VS2017 -> Test menu -> Test Settings -> Default Processor Architecture -> X64

Nuget packages used:
Newtonsoft.Json V11.0.2 -- Handler Project
Microsoft.AspNet.WebApi.Client 5.2.6. -- Client Project
NUnit 3.1 -- Test Projects
NUnit3TestAdapter 3.10 -- Test Projects

