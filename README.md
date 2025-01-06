# Sistema de Gerenciamento de Tarefas - Backend

Backend para o Sistema de Gerenciamento de Tarefas. 
Ele apresenta uma **API RESTful** para manipular as tarefas, permitindo operações básicas Create, Read, Update e Delete (CRUD).

## 🚀 Funcionalidades
- **GET**: Retorna a lista de tarefas ou uma tarefa específica.
- **POST**: Cria uma nova tarefa.
- **PUT**: Atualiza uma tarefa existente.
- **DELETE**: Deleta uma tarefa.

---

## 🛠️ Tecnologias Utilizadas
- **ASP.NET Core** (Versão 8.0.10)
- **Entity Framework Core (Versão 9.0.0)**
- **Entity Framework In Memory - Entity Framework Core** (Banco de dados)
- **Swagger** (Documentação da API)

---

## ⚙️ Requisitos
- **.NET SDK** (>= 8.0)
- **dotnet-ef** (Eventuais Migrations do DB)

---

## 📦 Instalação

1. Clone o repositório do Backend:
   ```bash
   git clone https://github.com/guilhermeS53/crud-sistema-de-tarefas-dl.git
   ```

2. Instale as dependências (se necessário):
   ```bash
   dotnet restore
   ```

---

## ▶️ Execução do Backend

1. Inicie a aplicação:
   ```bash
   dotnet run
   ```

3. Acesse a documentação Swagger no navegador:
   ```
   http://localhost:PORT/swagger
   ```

## 📂 Estrutura de Pastas

```
src/
├── Data/                 # Configuração do DbContext
├── Models/               # Modelos da aplicação
├── Program.cs            # Arquivo principal da aplicação
```

---

## 🔧 Testando a API

Podem ser usadas ferramentas como **Postman** ou **Swagger** para testar os endpoints. Exemplos de requisições:

### Criar uma Tarefa
**POST** `/tarefas`
```json
{
  "titulo": "Tarefa Teste",
  "descricao": "Descrição Teste",
  "status": "Pendente"
}
```
ou
```json
{
  "titulo": "Tarefa Teste",
  "descricao": "Descrição Teste",
  "status": 0
}
```

### Listar Tarefas
**GET** `/tarefas`

### Atualizar uma Tarefa
**PUT** `/tarefas/{id}`
```json
{
  "titulo": "Tarefa Teste Atualizada",
  "descricao": "Nova Descrição Teste",
  "status": "Concluido"
}
```
ou
```json
{
  "titulo": "Tarefa Teste Atualizada",
  "descricao": "Nova Descrição Teste",
  "status": 2
}
```
