# 🛒 SupermercadoAPI

API REST desenvolvida em .NET 8 para gerenciamento de produtos, categorias e controle de estoque em um sistema de supermercado.

---

## 📌 Índice

- [Sobre o Projeto](#sobre-o-projeto)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Como Executar](#como-executar)
- [Documentação da API](#documentação-da-api)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Contribuição](#contribuição)
- [Licença](#licença)

---

## 📖 Sobre o Projeto

O **SupermercadoAPI** é uma aplicação backend que oferece endpoints para gerenciamento de dados de um supermercado, como produtos, categorias e usuários. O projeto segue princípios de arquitetura limpa, com separação de responsabilidades entre camadas e uso de boas práticas com DTOs, AutoMapper, e injeção de dependência.

---

## ⚙️ Tecnologias Utilizadas

- [.NET 8.0](https://dotnet.microsoft.com/en-us/download)
- C#
- Entity Framework Core
- AutoMapper
- Docker
- SQL Server (ou outro banco relacional)

---

## 🚀 Como Executar

### Requisitos

- [.NET SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/) (opcional)

### Executar via CLI

```bash
git clone https://github.com/juniorti91/SupermercadoAPI.git
cd SupermercadoAPI
dotnet restore
dotnet run
