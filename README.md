# 🧠 AutoSuite

> Automação inteligente de processos documentais.

---

## ⚙️ Sobre o Projeto

**AutoSuite** é uma plataforma modular construída com microserviços para automatizar tarefas operacionais.

### 🔍 Funcionalidades
- Cadastro e gerenciamento de clientes
- Varredura de diretórios em rede
- Coleta automática de documentos fiscais
- Envio automático por e-mail
- Arquitetura escalável e desacoplada (Kafka)

---

## 🧩 Arquitetura de Microserviços

| Serviço            | Responsabilidade                             | Status           |
|--------------------|----------------------------------------------|------------------|
| `ClientService`    | Cadastro de clientes, paths, dados fiscais   |Implementado      |
| `DocSweepService`  | Escaneamento de diretórios via Kafka         |Em desenvolvimento|
| `EmailService`     | Envio automático de arquivos por e-mail      |Em desenvolvimento|

### 🛰 Comunicação entre serviços
- Utiliza **Apache Kafka**
- Cada serviço consome e publica eventos
- Separação clara de responsabilidades (SRP)

---

### 🔗 Responsabilidade
- Cadastro de clientes
- Consulta por ID ou CNPJ
- Exposição dos paths dos diretórios via Kafka

### 🔨 Tecnologias
- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Kafka (Producer)

## 🐳 Como Rodar com Docker Compose

### 📦 Pré-requisitos

- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [Docker Compose](https://docs.docker.com/compose/install/)

---

### 🚀 Passo a passo

#### 1. Atualize o appSettings: 

```
"ConnectionStrings": {
"DefaultConnection": "Server=db;Database=DocSweepDB;User Id=sa;Password=Your_password123;"
} 
```

#### 1. Clone o repositório:

```
git clone https://github.com/seu-usuario/seu-repo.git
cd seu-repo
```

#### 2. Suba os containers::

```
docker-compose up -d --build
```

