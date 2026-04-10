Azure Hands-On Lab: Core Tools + Key Vault + ARM

🎯 Lab Objective
By the end, learners will:
Use Azure Portal & Cloud Shell
Execute Azure CLI & PowerShell
Store/retrieve secrets in Key Vault
Deploy infra using ARM Template

1. Install Azure CLI
   On Windows
   Download and install from:
   Azure CLI
   Or via PowerShell:
   winget install -e --id Microsoft.AzureCLI

Login to Azure
Interactive login (most common)
az login

az account show

Understand CLI Structure (Important)
Azure CLI example:

az group create \--name rg-demo \--location centralindia

az group list --output table

az resource list --output table

Cleanup (Very Important for Cost Control)
az group delete --name rg-demo --yes --no-wait

--yes is a confirmation bypass flag
--no-wait → command returns immediately
Deletion continues in background

🔰 Pre-requisites
Azure account (Free tier works)
Basic command-line familiarity

🧩 Lab 1: Azure Portal & Resource Group
🎯 Goal
Understand Resource Group as lifecycle container

▶️ Steps
Open Azure Portal
Search → Resource Groups
Click Create
Fill:
RG Name: rg-smartbank-lab
Region: Central India
Click Create

🧪 Exercise
Create another RG:
rg-smartbank-test

✅ Expected Output
2 Resource Groups visible:
rg-smartbank-lab
rg-smartbank-test

✔️ Validation
Both RGs appear in Portal dashboard

🧩 Lab 2: Azure Cloud Shell + CLI
🎯 Goal
Run Azure commands without local setup

▶️ Steps
Click Cloud Shell
Choose Bash
Run:
az group create \ --name rg-smartbank-cli \ --location centralindia

🧪 Exercise
Create one more RG:
rg-cli-demo2

✅ Expected Output
{ "name": "rg-smartbank-cli", "location": "centralindia", "provisioningState": "Succeeded"}

✔️ Validation
az group list --output table
👉 Should list all RGs

🧩 Lab 3: Azure PowerShell
🎯 Goal
Execute same task using PowerShell

Azure CLI vs Azure PowerShell

Azure CLI
Designed for cross-platform usage (Linux, macOS, Windows)
Follows Unix-style command patterns
Works well in Bash scripting

Azure PowerShell
Built on PowerShell object-oriented model
Uses .NET objects instead of plain text
Ideal for Windows admins

Syntax Difference (Side-by-Side)
Create Resource Group
Azure CLI
az group create --name rg-demo --location centralindia
Azure PowerShell
New-AzResourceGroup -Name rg-demo -Location CentralIndia

Install-Module Az

👉 CLI = parameter-based👉 PowerShell = verb-noun pattern

Local PowerShell
Connect-AzAccount

Azure Cloud Shell vs Local CMD / PowerShell

1. What they are
   🔹 Azure Cloud Shell
   Runs inside Azure (browser-based)
   Preconfigured with:
   Azure CLI
   Azure PowerShell
   No installation required

🔹 Local CMD / PowerShell
Runs on your own machine
Requires manual setup:
Azure CLI install
Az PowerShell module install

▶️ Steps
Switch Cloud Shell → PowerShell
New-AzResourceGroup ` -Name "rg-smartbank-ps"` -Location "Central India"

🧪 Exercise
Create:
rg-ps-demo2

✅ Expected Output
Resource group created successfully

✔️ Validation
Get-AzResourceGroup

💡 Trainer Insight
Highlight:
CLI = string-based
PowerShell = object-based

Infrastructure as Code (IaC)

ARM Template vs Azure PowerShell

1. Core Philosophy
   🔹 ARM Template
   Declarative model
   You define desired state
   Azure figures out how to reach it

🔹 Azure PowerShell
Imperative model
You define step-by-step instructions
You control execution flow

Simple Analogy
ARM Template → “I want a VM with these specs”
PowerShell → “Create RG → create VNet → create NIC → create VM”

🧩 Lab 5: ARM Template Deployment
🎯 Goal
Infrastructure as Code (IaC)

▶️ Steps
Step 1: Create Template File
Create storage-template.json:
{ "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#", "contentVersion": "1.0.0.0", "resources": [ { "type": "Microsoft.Storage/storageAccounts", "apiVersion": "2022-09-01", "name": "smartbankstorage12345", "location": "centralindia", "sku": { "name": "Standard_LRS" }, "kind": "StorageV2", "properties": {} } ]}

Step 2: Deploy Template
az deployment group create \ --resource-group rg-smartbank-lab \ --template-file storage-template.json

🧪 Exercise
Modify template:
Change storage name
Deploy again

✅ Expected Output
{ "provisioningState": "Succeeded"}

✔️ Validation
Storage Account visible in Portal

🧠 Final Challenge (Mini Project)
🎯 Task
Learners must:
Create RG using CLI
Create Key Vault
Store:
DB connection string
Deploy Storage using ARM

How it is detecting / connecting my azure account?

How az deployment group create knows your Azure account
The Azure CLI (az) does not connect automatically to Azure. It relies on a previously authenticated session that’s stored locally.

1. Authentication happens via az login
   At some point earlier, you (or your environment) executed:
   az login
   This does the following:
   Opens browser → you sign into your Azure account
   Azure CLI receives an OAuth 2.0 access token
   Token + account metadata are stored locally on your machine
   Location (Windows):
   C:\Users\<your-user>\.azure\
   Key files:
   accessTokens.json
   azureProfile.json

or check using command –
az account list --output table

Your Azure Tenant ID (also called Directory ID) identifies your Azure Active Directory (now Microsoft Entra ID tenant).

Using Azure Portal (UI method)
In Azure Portal:
Search → Microsoft Entra ID
Go to Overview
Copy:
Tenant ID (Directory ID)
