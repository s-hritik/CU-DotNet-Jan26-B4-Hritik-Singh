🔷 Azure Application Gateway – Portal Lab (Step-by-Step)
🎯 Lab Objective
Create an Application Gateway (Layer 7 Load Balancer)
Deploy 2 backend VMs
Configure:
Backend Pool
HTTP Settings
Listener
Routing Rule
Test load balancing via browser

🧱 Architecture (Explain before demo)
User (Browser)  ↓ Application Gateway (Public IP)  ↓ Backend Pool (VM1 + VM2 with IIS/NGINX)

🚀 STEP 1: Create Resource Group
Go to Azure Portal
Search → Resource Groups
Click + Create
Enter:
Name: rg-appgw-lab
Region: Central India
Click Review + Create

🌐 STEP 2: Create Virtual Network
Go to Virtual Networks → Create
Configure:
Name: vnet-appgw
Address Space: 10.0.0.0/16
Subnets:
appgw-subnet → 10.0.0.0/24 ⚠️ (Mandatory for App Gateway)
backend-subnet → 10.0.1.0/24
Create
👉 Emphasize: Application Gateway must be in a dedicated subnet

🖥️ STEP 3: Create Backend VMs (2 VMs)
Create VM1 + VM2:
Go to Virtual Machines → Create
Configure:
Name: vm1 / vm2
Image: Ubuntu / Windows
Size: Standard B1s (for demo)
VNet: vnet-appgw
Subnet: backend-subnet
Allow:
HTTP (Port 80)
SSH/RDP (optional)

⚙️ Install Web Server (VERY IMPORTANT)
For Ubuntu:
sudo apt update sudo apt install nginx -y echo "Hello from VM1" | sudo tee /var/www/html/index.html
(Repeat for VM2 with "Hello from VM2")

🌍 STEP 4: Create Application Gateway
Search → Application Gateway
Click + Create

🔹 Basics Tab
Name: appgw-demo
Region: Same as VNet
Tier: Standard v2
Autoscaling: Enabled (min 1)

🔹 Frontend IP
Type: Public
Create new Public IP Name: appgw-pip

🔹 Backend Pool
Click Add backend pool
Name: backend-pool
Add backend targets:
Select VM1 + VM2 (private IPs)

🔹 Configuration Tab (Important Section)

1. Add HTTP Setting
   Name: http-setting
   Port: 80
   Protocol: HTTP
   Cookie-based affinity: Disabled

2. Add Listener
   Name: listener
   Frontend IP: Public
   Port: 80
   Protocol: HTTP

3. Add Routing Rule
   Name: rule1
   Listener: listener
   Backend Pool: backend-pool
   HTTP Setting: http-setting

👉 Click Review + Create → Create
⏳ Takes ~5–10 minutes

🌐 STEP 5: Test Application Gateway
Go to Application Gateway
Copy Public IP
Open browser:
http://<public-ip>

🎉 Expected Output
Refresh multiple times → you should see:
Hello from VM1 Hello from VM2 Hello from VM1...
👉 Explain:This is Layer 7 Load Balancing (Round Robin)
