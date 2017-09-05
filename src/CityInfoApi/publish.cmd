if exist %~dp0\publish del %~dp0\publish /Q

dotnet restore CityInfoApi.sln
pushd .\CityInfo.Api\

dotnet publish -o %~dp0\publish\ -c Release

popd  
