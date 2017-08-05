$project = (Split-Path -Parent $MyInvocation.MyCommand.Path)
Import-Module "$project\..\bin\ipfs-powershell-provider.dll"
Describe "IpfsDriveInit" {
		$ipfstestdrive = new-psdrive -PsProvider IpfsDrive -Name IpfsDrive -Root ""
		It "BaseInitaliztion" {
			$ipfstestdrive | Should Not Be $null
			$ipfstestdrive | Get-Member | Out-Host
		}
		It "PinnedObjectsCheck" {
			$ipfstestdrive.PinnedObjects | Should Not Be $null
			$ipfstestdrive.PinnedObjects | Get-Member | Out-Host
		}
		It "MfsDataCheck" {
			$ipfstestdrive.MfsData | Should Not Be $null
			$ipfstestdrive.MfsData | Get-Member | Out-Host
		}
}
