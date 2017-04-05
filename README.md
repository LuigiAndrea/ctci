| Linux/OSX | Windows |
| --- | --- |
| [![Build Status](https://travis-ci.org/LuigiAndrea/ctci.png?branch=master)](https://travis-ci.org/LuigiAndrea/ctci) | [![Build status](https://ci.appveyor.com/api/projects/status/0dfaivsu6degg079/branch/master?svg=true)](https://ci.appveyor.com/project/LuigiAndrea/ctci) |

CTCI
====

My solution to Cracking the Coding Interview 6th Edtion using C# 6, .NET Core Platform and Xunit

Continuous work in progress

### Prerequisites

You need to install on your machine the current version of .NET Core 1.1 (1.0.0-preview2-1-003177)

Verify your version running `dotnet --version` in a terminal/console window.

### Build and Run

To __build and run all the tests__, navigate to test and run the following commands:
```
dotnet restore

dotnet test
```
The files are organized in a way that it is also possible to run the tests per class or namespace