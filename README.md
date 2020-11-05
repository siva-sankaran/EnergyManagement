# EnergyManagement

requirements:
* dotnet core

**To Build**:
$> dotnet build

**Usage**:
ElectricityController.exe [noOfFloors] [noOfMainCorridors] [noOfSubCorridors]

example:
ElectricityController.exe 2 1 2

The program will show the state of lights & ACs of floors and will wait for user input. On Valid inputs, state will be shown and wait for further user input. Enter "quit" to stop the program. 

_*redirect input from file to the program*_
inputs can be redirected from files as below in powershell

Get-Content .\sample_input.txt | .\ElectricityController\bin\Debug\netcoreapp3.1\ElectricityController.exe 2 1 2

in bash:
ElectricityController/bin/Debug/netcoreapp3.1/ElectricityController.exe 2 1 2 < sample_input.txt

Valid Inputs are (case insensitive):
* Movement in Floor <floor_number>, Sub corridor <sub_corridor_number>
* No Movement in Floor <floor_number>, Sub corridor <sub_corridor_number>
* quit



**To Run Unit Tests**:
$> dotnet test
