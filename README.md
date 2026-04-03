# URL Shortener (ASP.NET Core)

Простой сервис сокращения ссылок на базе ASP.NET Core и PostgreSQL.

## Стек

* C#
* ASP.NET Core
* Entity Framework Core
* PostgreSQL
* Docker

---

## Запуск проекта

### 1. Клонировать репозиторий

```bash
git clone <repo_url>
cd <repo>
```

---

### 2. Поднять базу данных

```bash
docker compose up -d
```

PostgreSQL будет доступен на:

```
localhost:6432
```

---

### 3. Запустить приложение

```bash
http://localhost:5161/swagger
```

---

## API

### Создать короткую ссылку

```
POST /short_url
```

Body:
```json
{
  "long_url": "https://example.com"
}
```

---

### Редирект

```
GET /{slug}
```

---

## База данных

Используется PostgreSQL в Docker.

Конфигурация:
* DB: postgres
* User: postgres
* Password: postgres
* Port: 6432
