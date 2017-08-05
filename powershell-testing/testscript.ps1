Import-Module ..\bin\ipfs-powershell-provider.dll
$ipfstestdrive = new-psdrive -PsProvider IpfsDrive -Name users -Root ""
$ipfstestdrive | Get-Member
$ipfstestdrive.PinnedObjects