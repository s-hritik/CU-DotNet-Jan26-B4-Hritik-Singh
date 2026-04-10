Azure Demo Lab: Virtual Network + NSG (Netwrok Security Group)

🎯 Lab Objective
By the end of this lab, learners will:
Understand Azure Virtual Network architecture
Configure NSG rules to filter traffic

A Virtual Network (VNet) and subnet in Azure only provide network isolation and IP addressing—they do not enforce traffic control by default. That’s where a Network Security Group (NSG) becomes essential.

🔐 Why NSG is Required in Azure VNet/Subnet
1️⃣ VNet/Subnet ≠ Security Boundary
A VNet is like a private LAN in the cloud
Subnets logically divide that network
👉 But by default:
Resources inside can freely communicate
There is no deny/allow filtering

🧱 Part 1: Create Virtual Network (Foundation)
Concept (Explain First)
Think of Virtual Network (VNet) as:
"Your private data center network inside Azure"
IP range
Subnets = departments (Web, App, DB)

🛠️ Practical Steps
Go to Azure Portal → Create Resource
Search → Virtual Network
Configure:
Name: vnet-demo-labRegion: Same for all resourcesAddress Space: 10.0.0.0/16
Add Subnets:

👉 Explain:
Subnets = segmentation (like floors in a building)
In networking, 10.0.0.0/16 is a way of defining a specific range of IP addresses

The Prefix / Mask (/16): This is the most important part. It tells you how many "bits" are locked for the network identity. Since an IP address has 32 bits total, a /16 means the first 16 bits (the first two numbers, 10.0) are frozen.

Because the first two octets (10.0) are locked, only the last two octets can change. This creates a range:
First IP: 10.0.0.0 (The Network Address)
Last IP: 10.0.255.255 (The Broadcast Address)
Total Addresses: 2^{16} = 65,536 addresses.

💻 Part 2: Create Virtual Machines
Create 2 VMs:
VM1 (Web Server)
Name: vm-webSubnet: web-subnetPort: Allow SSH (22)
VM2 (App Server)
Name: vm-appSubnet: app-subnetPort: Allow SSH (22)
👉 After creation:
Connect using SSH
Install nginx in vm-web:
sudo apt updatesudo apt install nginx -y

Verify NGINX is running on VM
SSH into your VM and run:
sudo systemctl status nginx

If not running:
sudo systemctl start nginx

Allow HTTP (Port 80) in NSG ⚠️ (Most important step)
Azure blocks incoming traffic by default.
In the portal:
Go to VM → Networking
Click Add inbound port rule
Configure:
Source: Any
Destination port: 80
Protocol: TCP
Action: Allow
Priority: 1000 (or lower number)

Check Firewall inside Ubuntu (optional but safe)
sudo ufw allow 'Nginx Full'sudo ufw enable

for second VM, if getting errors of quota limit, set Azure Spot Instance → OFF

🔥 Part 3: NSG (Network Security Group)
Concept
NSG = Firewall at subnet or NIC level
Controls:
Source
Destination
Port
Protocol
Allow/Deny

🛠️ Create NSG
Create Resource → Network Security Group
Name: nsg-web
Add Rule:

👉 Attach NSG to web-subnet

🧪 Test
Open browser → VM public IP
nginx should load ✅

❌ Now Block Traffic
Add rule:

👉 Refresh browser → ❌ Not working
👉 Explain:
Lower priority number = higher precedence

🔐 Part 4: Secure Network Traffic (Real Scenario)
Scenario:
Only vm-app should access vm-web, not public users.

Steps:
Remove public HTTP allow
Add rule:

👉 Now:
vm-app → vm-web ✅
Browser → vm-web ❌
👉 Demo:
curl http://<private-ip-of-vm-web>

🧩 Part 5: Application Security Groups (ASG)
Concept
ASG = Logical grouping of VMs
Instead of IP-based rules:
Use names like “web-servers”, “app-servers”

🛠️ Create ASGs
Create 2 ASGs:
asg-webasg-app

Assign VMs:
vm-web → asg-web
vm-app → asg-app

Update NSG Rule:
Instead of IPs:

👉 This is cleaner and scalable

🧪 Test Again
vm-app → vm-web ✅
External → vm-web ❌

⚖️ Part 6: NSG vs ASG (Explain Clearly)
