# SampleApp

SampleApp — это небольшой сервис для управления пользователями с Web API на ASP.NET Core и хранением данных в PostgreSQL.  

## Функционал

- Создание, редактирование, получение и удаление пользователей  
- Хранение пароля в виде хэша и соли (HMACSHA256)  
- Валидация данных пользователя (Login обязательное поле)  
- Репозиторный паттерн с внедрением зависимостей (Dependency Injection)  
- Генерация тестовых пользователей через SeedController и библиотеку Bogus  
- Поддержка Swagger для тестирования API  

## Технологии

- ASP.NET Core Web API (.NET 9)  
- C#  
- Entity Framework Core + PostgreSQL  
- Swagger  
- Bogus (генерация тестовых данных)  

## Настройка проекта

1. **Клонируйте репозиторий:**

```bash
git clone git push origin master
```
```bash
cd SampleApp/SampleApp.API
```
2. Настройте строку подключения в appsettings.json:
```json
"ConnectionStrings": {
  "PostgreSQL": "Host=localhost;Port=5432;Database=SampleAppCourse;Username=postgres;Password=<ваш_пароль>"
}
```

3. Установите зависимости EF Core и Npgsql (если еще не установлены):

```bash
dotnet add package Microsoft.EntityFrameworkCore -v 9.0.0
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL -v 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools -v 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design -v 9.0.0
dotnet add package Bogus
```

4. Создайте и примените миграции:
```bash
dotnet ef migrations add Initial -s SampleApp.API -p SampleApp.API
dotnet ef database update -s SampleApp.API -p SampleApp.API
```

5. Запустите приложение:

```bash
dotnet watch run --launch-profile "https"
```

API будет доступно по адресу: https://localhost:7293

Работа с API

-Создание пользователя: POST /api/users
Входные данные: JSON в формате UserDto:
```json
{
  "login": "alice123",
  "password": "123456"
}
```

- Получение всех пользователей: GET /api/users

- Редактирование пользователя: PUT /api/users/{id}

- Удаление пользователя: DELETE /api/users/{id}

- Генерация тестовых пользователей: GET /api/seed/generate

Примечания

- Пароли пользователей хранятся в виде хэша + соли (HMACSHA256).

- Swagger доступен по адресу: https://localhost:7293/swagger для тестирования API.

- SeedController генерирует 100 тестовых пользователей с случайными логинами и паролями.
