Create a demo to use Event Grid as per lab demo shared –

Azure Event Grid is an event routing service. It sits between event producers (like Blob Storage) and consumers (Function, Logic App, Webhook).
Instead of tight coupling:

Blob → Function → Logic App
You move to event-driven decoupling:
Blob → Event Grid → (Function / Logic App / others)
