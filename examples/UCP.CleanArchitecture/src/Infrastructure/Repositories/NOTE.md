# Repository Implementation Note

These repositories use static ConcurrentDictionary for in-memory storage as a simple demonstration.

**For Production Use:**
- Replace with proper database implementation (Entity Framework Core, Dapper, etc.)
- Use scoped or transient lifetime for repositories
- Implement proper data persistence
- Add transaction support

**Current Limitations:**
- Data is shared across all application instances
- Data is lost on application restart
- Not suitable for multi-instance deployments
- Not thread-safe across multiple processes

This is intentional for the example to keep dependencies minimal and focus on architecture patterns.
