$project = (Split-Path -Parent $MyInvocation.MyCommand.Path)
Import-Module "$project\..\bin\ipfs-powershell-provider.dll"
Describe "IpfsDrivesInit" {
		It "PinnedObjectsCheck" {
			$PinnedObjectstestdrive = new-psdrive -PsProvider PinnedObjects -Name PinnedObjects -Root ""
			$PinnedObjectstestdrive | Should Not Be $null
			$PinnedObjectstestdrive | Get-Member | Out-Host
		}
		It "MfsDataCheck" {
			$MfsTestDrive = new-psdrive -PsProvider MfsDrive -Name MfsDrive -Root ""
			$MfsTestDrive | Should Not Be $null
			$MfsTestDrive | Get-Member | Out-Host
		}
}
