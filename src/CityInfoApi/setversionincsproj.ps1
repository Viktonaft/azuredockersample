[CmdletBinding()]
Param(
	[Parameter(Mandatory=$true, Position=1)]
	$version,
    [Parameter(Mandatory=$false, Position=2)]
	$filePath = ".\CityInfo.Api\CityInfo.Api.csproj"
)



[xml]$xml = Get-Content $filePath
$propertyGroup = $xml.Project.PropertyGroup;

if($propertyGroup)
{
	$propertyGroup["AssemblyVersion"]."#text" = "$version"
	$propertyGroup["FileVersion"]."#text" = "$version"
	
}
$xml.Save($filePath)