Assignment: Provisioning and Accessing an Azure Windows VM

Objective
To create a Windows Server Virtual Machine in Azure, configure networking for remote access, and successfully log in using the Remote Desktop Protocol (RDP).
Prerequisites
An active Azure Subscription.
Remote Desktop Connection client (built-in on Windows, available as "Microsoft Remote Desktop" on macOS/Linux).

Part 1: The Implementation Task
Step 1: Create the Virtual Machine
Sign in to the Azure Portal.
Search for Virtual Machines and select Create > Azure virtual machine.
Project Details:
Resource Group: Create a new one named RG-VM-Assignment.
Instance Details:
VM Name: WinServer-Lab-01
Region: (Select the region closest to you).
Image: Windows Server 2022 Datacenter: Azure Edition.
Size: Standard_B2s (2 vCPUs, 4 GiB memory) is sufficient for this lab.
Administrator Account:
Set a Username and a Complex Password (Store these securely).
Inbound Port Rules:
Select Allow selected ports.
Select RDP (3389).
Step 2: Networking & Review
Keep default settings for Disks and Networking (Azure will automatically create a VNet and a Public IP).
Select Review + create. Once validation passes, click Create.
Wait for the deployment to complete (usually 2–5 minutes).
Step 3: Connect via RDP
Once the deployment is finished, click Go to resource.
On the Overview blade, click Connect > RDP.
Download the RDP File.
Open the file, click Connect, and enter the credentials you created in Step 1.
Accept the certificate warning to enter the Windows Desktop environment.

Part 2: Documentation Requirement
You are required to submit a technical "Implementation Guide" (Word or PDF). Your document must include the following sections:
Environment Overview: A table listing the VM Name, Operating System, Region, and Public IP address.
Connection Proof: A screenshot of the Windows Server Desktop once you have logged in, with the "Server Manager" dashboard visible.
Resource Cleanup: A brief note confirming you have Deleted the Resource Group to avoid unnecessary billing.
