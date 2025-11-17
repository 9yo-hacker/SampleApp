# SampleApp

SampleApp — небольшой клон Twitter с простым API и фронтендом 
## Функционал

- Создание, редактирование, получение и удаление пользователей  
- Создание ролей и привязка их к пользователям  
- Возврат корректных HTTP-кодов (200, 201, 404)  
- Использование репозиторного паттерна и базовой валидации данных  

## Технологии

- ASP.NET Core Web API  
- Angular 20  
- C#  
- In-memory Singleton Repository  

## Запуск

### Backend (API)

1. Клонируйте репозиторий:  
```bash
   git clone https://github.com/9yo-hacker/SampleApp.git
```
Перейдите в папку проекта API и запустите:

```bash
cd SampleApp/SampleApp.API
```
```bash
dotnet run
```
API будет доступно по адресу: https://localhost:7293

Frontend (Angular)
Перейдите в папку Angular проекта:

```bash
cd SampleApp/SampleApp.Angular
```
Установите зависимости:

```bash
npm install
```
Запустите Angular приложение:
```bash
ng serve
```
Откройте в браузере: https://localhost:4300
Таблица с пользователями будет автоматически подгружаться с API.
