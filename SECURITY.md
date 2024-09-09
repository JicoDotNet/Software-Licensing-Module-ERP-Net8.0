# Security Policy

## Handling Secrets

- Sensitive data (e.g., API keys, database connection strings) must never be committed to the repository.
- Use `secrets.json` to store secrets in local, staging, and production environments.
- Add sensitive files (e.g., `.env`, `config.yml`, `secrets.json`) to `.gitignore` to prevent them from being tracked.
- Enable secret scanning and monitoring tools (e.g., GitHub Secret Scanning, GitGuardian).
