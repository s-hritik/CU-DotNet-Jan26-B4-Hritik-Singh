📋 Problem Statement: "The Secure Fleet Management System"

1. The Scenario
   "LogiTrack" is a logistics company transitioning to microservices. They have two primary services:
   Identity Service: Handles user login and issues a "Passport" (JWT).
   Tracking Service: Holds sensitive GPS data of trucks.
   Currently, the Tracking Service is open to the public. Your task is to implement JWT Authentication so that the Tracking Service only responds to requests carrying a valid, signed token from the Identity Service.

2. Requirements
   Phase 1: Token Generation (Identity Service)
   Create an endpoint POST /api/auth/login.
   If the user provides valid credentials (hardcode a test user for now), generate a JWT.
   The JWT must include Claims: sub (UserId), email, and role (e.g., "Manager" or "Driver").
   The token must be signed using a Symmetric Security Key stored in appsettings.json.
   Phase 2: Token Validation (Tracking Service)
   Configure the Program.cs of the Tracking Service to use JwtBearer authentication.
   The service must verify:
   Issuer & Audience: Matches the Identity Service settings.
   Signature: The key used to sign the token is valid.
   Expiration: Expired tokens must be rejected.
   Phase 3: Authorization (Access Control)
   Protect the GET /api/tracking/gps endpoint using the [Authorize] attribute.
   Role-Based Access: Only users with the role: "Manager" should be able to see the GPS history. "Drivers" should receive a 403 Forbidden error.

3. Technical Implementation Steps
   Step 1: Install NuGet Packages
   Both services need this package:
   Bash
   dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
   Step 2: Configuration (appsettings.json)
   Use the same secret key in both services:
   JSON
   "Jwt": {
   "Key": "A_Very_Long_And_Secure_Secret_Key_123456",
   "Issuer": "LogiTrack.Identity",
   "Audience": "LogiTrack.Tracking"
   }
   Step 3: Tracking Service Setup (Program.cs)
   C#
   builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options => {
   options.TokenValidationParameters = new TokenValidationParameters {
   ValidateIssuer = true,
   ValidateAudience = true,
   ValidateLifetime = true,
   ValidateIssuerSigningKey = true,
   ValidIssuer = builder.Configuration["Jwt:Issuer"],
   ValidAudience = builder.Configuration["Jwt:Audience"],
   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
   };
   });

// Don't forget the middleware order!
app.UseAuthentication();
app.UseAuthorization();

4. Assignment Submission Checklist
   Postman Collection:
   One request to Login to get the access_token.
   One request to Tracking Service without a token (Expect 401 Unauthorized).
   One request to Tracking Service with the token in the Authorization: Bearer <token> header (Expect 200 OK).
   Security Question: Why is it dangerous to store the Jwt:Key directly in the appsettings.json file in a real production environment? What should be used instead? (Hint: Azure Key Vault).

🛠️ Pro-Tip for Learners
To inspect your generated token, copy it and paste it into JWT.io. You should be able to see your "Claims" (Email and Role) in plain text. This helps you understand that JWTs are encoded, not encrypted—never put passwords inside a token!
