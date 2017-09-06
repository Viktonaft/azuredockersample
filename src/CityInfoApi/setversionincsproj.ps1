[CmdletBinding()]
Param(
	[Parameter(Mandatory=$true, Position=1)]
	$version,
	[Parameter(Mandatory=$false, Position=3)]
	$assemblyVersion,
	[Parameter(Mandatory=$false)]
	$fileVersion,
    [Parameter(Mandatory=$false, Position=2)]
	$filePath = ".\CityInfo.Api\CityInfo.Api.csproj"
)



[xml]$xml = Get-Content $filePath
$propertyGroup = $xml.Project.PropertyGroup;

if($propertyGroup)
{
	Write-Host "Replacing version info..."
	if($version)
	{
		Write-Host "Version: $version"
		$propertyGroup["Version"]."#text" = "$version"
	}

	if($assemblyVersion)
	{
		Write-Host "AssemblyVersion: $assemblyVersion"
		$propertyGroup["AssemblyVersion"]."#text" = "$assemblyVersion"
	}

	if($fileVersion)
	{
		Write-Host "FileVersion: $fileVersion"
		$propertyGroup["FileVersion"]."#text" = "$fileVersion"
	}
	
	Write-Host "Update completed..."
	$xml.Save($filePath)
}
