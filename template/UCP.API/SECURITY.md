# UCP Security Requirements

## Required HTTP Headers

According to the UCP specification, all merchant API endpoints must implement proper security headers:

### 1. Request-Signature (Required)
**Purpose:** Ensures the authenticity and integrity of HTTP messages.

**Implementation:**
```csharp
// TODO: Implement request signature validation
// - Verify the signature matches the request body
// - Use your merchant signing key
// - Follow UCP signature specification
```

**Example Header:**
```
Request-Signature: keyid="merchant-key-1",algorithm="ecdsa-p256-sha256",signature="base64..."
```

### 2. Idempotency-Key (Required for POST/PUT)
**Purpose:** Prevents duplicate operations during retries.

**Format:** UUID v4

**Implementation:**
```csharp
// TODO: Implement idempotency handling
// 1. Store idempotency key with request/response in database
// 2. On duplicate key, return cached response
// 3. Expire keys after 24 hours
```

**Example Header:**
```
Idempotency-Key: 550e8400-e29b-41d4-a716-446655440000
```

### 3. Request-Id (Optional but Recommended)
**Purpose:** Request tracing and debugging.

**Format:** UUID v4

**Example Header:**
```
Request-Id: 6ba7b810-9dad-11d1-80b4-00c04fd430c8
```

### 4. Authorization (Optional)
**Purpose:** OAuth 2.0 token for authentication.

**Schemes:**
- Client credentials (platform self-authenticating)
- Authorization code (platform on behalf of end user)

**Example Header:**
```
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

### 5. X-API-Key (Optional)
**Purpose:** Simple API key authentication.

**Example Header:**
```
X-API-Key: your-api-key-here
```

### 6. UCP-Agent (Optional)
**Purpose:** Client identification and version negotiation.

**Example Header:**
```
UCP-Agent: profile="https://platform.example/ucp-profile",version="2026-01-11"
```

## Transport Security

### HTTPS/TLS
- All UCP endpoints MUST use HTTPS with TLS 1.2 or higher
- Valid SSL certificates required
- No self-signed certificates in production

### CORS Configuration
If serving browser-based applications, configure CORS properly:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("UCP", policy =>
    {
        policy.WithOrigins("https://trusted-platform.com")
              .AllowedHeaders("*")
              .AllowedMethods("GET", "POST", "PUT", "DELETE");
    });
});
```

## Implementation Guide

### Step 1: Enable Middleware
In `Program.cs`, uncomment the UCP header validation middleware:

```csharp
// Enable after implementing validation logic
app.UseUcpHeaderValidation();
```

### Step 2: Implement Signature Validation
In `Middleware/UcpHeaderValidationMiddleware.cs`:

```csharp
private bool ValidateSignature(HttpContext context, string signature)
{
    // TODO: Your implementation
    // 1. Extract signature components (keyid, algorithm, signature)
    // 2. Reconstruct signed content from request
    // 3. Verify using your public key
    // 4. Return true if valid, false otherwise
    return false;
}
```

### Step 3: Implement Idempotency
Create an idempotency service:

```csharp
public interface IIdempotencyService
{
    Task<(bool Exists, object? Response)> CheckAsync(string key);
    Task StoreAsync(string key, object response);
}
```

### Step 4: Add Authentication
Configure your auth scheme in `Program.cs`:

```csharp
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        // Configure JWT validation
    });
```

## Testing

### Development Mode
In development, header validation is disabled by default. Enable it manually for testing:

```bash
curl -X POST http://localhost:5000/checkout-sessions \
  -H "Request-Signature: test" \
  -H "Idempotency-Key: 550e8400-e29b-41d4-a716-446655440000" \
  -H "Content-Type: application/json" \
  -d '{ "line_items": [...] }'
```

### Production Mode
In production, all security headers must be properly validated.

## References

- [UCP Specification - Transport Security](https://ucp.dev/specification/checkout-rest/#transport-security)
- [HTTP Message Signatures RFC](https://datatracker.ietf.org/doc/html/rfc9421)
- [Idempotency Keys Best Practices](https://brandur.org/idempotency-keys)
