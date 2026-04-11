VNet-to-VNet VPN using Azure VPN Gateway

🔷 Assessment Objective
Connect two virtual networks using site-to-site style VPN inside Azure (VNet-to-VNet).

Concepts –
🔷 Core Idea
You are creating a secure, encrypted tunnel between two isolated networks inside Azure using Azure VPN Gateway.
👉 Think of it as:
Two private office networks connected over the internet using IPSec VPN

GatewaySubnet (Critical Component)
10.0.255.0/27
10.1.255.0/27
🔑 Concept
This is a dedicated subnet reserved for VPN gateway instances
❗ Why special?
Azure deploys managed gateway VMs internally
You cannot deploy your own VMs here
Must be named exactly: GatewaySubnet
👉 Think:
“This is where Azure places the VPN device”

Public IP (Behind the Scenes)
Each VPN Gateway has:
A Public IP
🔑 Concept
Even though VNets are private:
Gateways communicate over the public internet using encrypted tunnels

The VPN Tunnel (Connection)
VPN Gateway 1 <------VPN------> VPN Gateway 2
🔑 Concept
This is a site-to-site IPSec tunnel

🔄 Packet Flow
Example: VM1 → VM2
VM1 sends packet → 10.1.1.4
Azure routing detects:
Destination is remote VNet
Packet sent to: → VPN Gateway 1
Gateway:
Encrypts packet
Sends via internet
VPN Gateway 2:
Decrypts packet
Delivered to VM2
Why we have gateway subnet if we have vpn gateway?

VPN Gateway is a managed cluster of gateway VMs (controlled by Azure) that performs encryption, routing, and tunneling.

These VMs need IP addresses, They must be placed inside your Vnet GatewaySubnet.

🧱 Architecture Overview
VNet-1 (10.0.0.0/16) VNet-2 (10.1.0.0/16)  | | Subnet1 (VM1) Subnet1 (VM2)  | | GatewaySubnet GatewaySubnet  | | VPN Gateway 1 <------VPN------> VPN Gateway 2

🚀 Step-by-Step Lab (Azure Portal)

✅ Step 1: Create Resource Group
Name: rg-vnet-vpn-lab
Region: Choose same region (e.g., Central India)

✅ Step 2: Create VNet-1
Name: vnet1
Address space: 10.0.0.0/16
Subnets:
subnet1 → 10.0.1.0/24
GatewaySubnet → 10.0.255.0/27 (must be named exactly this)

✅ Step 3: Create VNet-2
Name: vnet2
Address space: 10.1.0.0/16
Subnets:
subnet1 → 10.1.1.0/24
GatewaySubnet → 10.1.255.0/27

✅ Step 4: Create VPN Gateway for VNet-1
Go to: 👉 Create Resource → Virtual Network Gateway
Name: vnet1-gateway
Gateway type: VPN
VPN type: Route-based
SKU: VpnGw1 (basic lab)
VNet: vnet1
Public IP: Create new (pip-vnet1-gw)
⏳ Takes ~20–30 minutes

✅ Step 5: Create VPN Gateway for VNet-2
Name: vnet2-gateway
Same config, attach to vnet2
Public IP: pip-vnet2-gw
⏳ Again ~20–30 minutes

✅ Step 6: Create Connection (VNet1 → VNet2)
Go to: 👉 vnet1-gateway → Connections → + Add
Name: vnet1-to-vnet2
Connection type: VNet-to-VNet
Second virtual network gateway: vnet2-gateway
Shared key (PSK): Azure123

✅ Step 7: Create Reverse Connection (VNet2 → VNet1)
Name: vnet2-to-vnet1
Same shared key: Azure123

✅ Step 8: Deploy Test VMs
VM1 in VNet1
Name: vm1
Subnet: subnet1
OS: Ubuntu / Windows
VM2 in VNet2
Name: vm2
Subnet: subnet1

✅ Step 9: Test Connectivity
From VM1:
ping 10.1.1.x # VM2 private IP
From VM2:
ping 10.0.1.x
✔ If ping works → VPN is successful

🔍
🔸 Why GatewaySubnet?
Dedicated subnet for VPN gateway
Cannot deploy anything else there

🔸 Why VPN Gateway?
Provides encrypted tunnel (IPSec/IKE)
Needed for cross-network secure communication
