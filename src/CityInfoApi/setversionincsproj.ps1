[CmdletBinding()]
Param(
	[Parameter(Mandatory=$true, Position=1)]
	$version,
	[Parameter(Mandatory=$false, Position=3)]
	$assemblyVersion = $version,
	[Parameter(Mandatory=$false)]
	$fileVersion = $assemblyVersion,
    [Parameter(Mandatory=$false, Position=2)]
	$filePath = ".\CityInfo.Api\CityInfo.Api.csproj"
)



[xml]$xml = Get-Content $filePath
$propertyGroup = $xml.Project.PropertyGroup;

if($propertyGroup)
{
	Write-Host "Replacing version info..."
	Write-Host "Version: $version"
	Write-Host "AssemblyVersion: $assemblyVersion"
	Write-Host "FileVersion: $fileVersion"
	
	
	$propertyGroup["Version"]."#text" = "$version"
	$propertyGroup["AssemblyVersion"]."#text" = "$assemblyVersion"
	$propertyGroup["FileVersion"]."#text" = "$fileVersion"
	
	$xml.Save($filePath)
}
