# 🛵 MotoTrack - Backend (.NET)

## 📝 Descrição do Projeto

O **MotoTrack** é um sistema desenvolvido para ajudar no controle e monitoramento das motos utilizadas por uma empresa aluguel de motos. A solução foi pensada para resolver problemas comuns no gerenciamento físico dessas motos, como desorganização nos pátios, dificuldade para localizar veículos disponíveis ou em manutenção, e ausência de histórico rastreável de movimentações.

Esta API RESTful, desenvolvida em .NET 8, permite o cadastro, atualização e consulta de ordens de serviço relacionadas à manutenção de motos, utilizando boas práticas de arquitetura em camadas.

## 👥 Integrantes

- **Felipe Ulson Sora** – RM555462 – [@felipesora](https://github.com/felipesora)
- **Augusto Lope Lyra** – RM558209 – [@lopeslyra10](https://github.com/lopeslyra10)
- **Vinicius Ribeiro Nery Costa** – RM559165 – [@ViniciusRibeiroNery](https://github.com/ViniciusRibeiroNery)

## 🗂️ Estrutura do Projeto
O projeto está dividido nas seguintes camadas:

```bash
mototrack_backend_dotnet/
│
├── Application/
│   ├── DTOs/
│   │   ├── OrdemServicoCreateDTO.cs
│   │   └── OrdemServicoResponseDTO.cs
│   ├── Interfaces/
│   │   └── IOrdemServicoApplicationService.cs
│   └── Services/
│       └── OrdemServicoApplicationService.cs
│
├── Domain/
│   ├── Entities/
│   │   └── OrdemServicoEntity.cs
│   ├── Enums/
│   │   ├── Prioridade.cs
│   │   └── StatusOrdem.cs
│   └── Interfaces/
│       └── IOrdemServicoRepository.cs
│
├── Infrastructure/
│   ├── AppData/
│   │   └── ApplicationContext.cs
│   ├── Data/
│   │   └── OrdemServicoRepository.cs
│   └── Migrations/
│
└── Presentation/
    └── Controllers/
        └── OrdemServicoController.cs
```

## 📡 Endpoints da API

Abaixo estão os principais endpoints disponíveis para manipular as ordens de serviço:

### 🔍 Buscar todas as ordens
- **GET** `/api/OrdemServico`
- Retorna todas as ordens cadastradas.
- **Respostas**:
  - `200 OK`: Lista retornada com sucesso.
  - `204 No Content`: Nenhuma ordem encontrada.
  - `400 Bad Request`: Falha na consulta.

---

### 🔎 Buscar ordem por ID
- **GET** `/api/OrdemServico/{id}`
- Retorna a ordem com o ID informado.
- **Parâmetros**:
  - `id` (int): ID da ordem.
- **Respostas**:
  - `200 OK`: Ordem encontrada.
  - `404 Not Found`: Ordem não localizada.
  - `400 Bad Request`: Erro de validação ou servidor.

---

### 🚘 Buscar ordens por placa da moto
- **GET** `/api/OrdemServico/placa/{placa}`
- Lista ordens associadas a uma placa específica.
- **Parâmetros**:
  - `placa` (string): Placa da moto.
- **Respostas**:
  - `200 OK`: Ordens encontradas.
  - `204 No Content`: Nenhuma ordem com essa placa.
  - `400 Bad Request`: Falha na consulta.

---

### 📋 Buscar ordens por status
- **GET** `/api/OrdemServico/status/{status}`
- Filtra ordens com o status especificado.
- **Parâmetros**:
  - `status` (string): `ABERTA`, `EM_ANDAMENTO`, `FINALIZADA`
- **Respostas**:
  - `200 OK`: Ordens encontradas.
  - `204 No Content`: Nenhuma ordem com esse status.
  - `400 Bad Request`: Status inválido ou erro interno.

---

### ➕ Criar nova ordem
- **POST** `/api/OrdemServico`
- Cadastra uma nova ordem no sistema.
- **Body (JSON)**:
```jsonc
{
  "descricao": "Arrumar motor da moto",
  "prioridade": "MEDIA", // valores do enum
  "status": "EM_ANDAMENTO", // valores do enum
  "dataAbertura": "2025-05-13T21:59:20.953Z",
  "dataFinalizacao": "2025-06-07T09:00:00.000Z",
  "responsavel": "João Silva",
  "placaMoto": "ABC1234"
}
```
- **Respostas**:
  - `200 OK`: Ordem criada com sucesso.
  - `400 Bad Request`: Dados inválidos ou erro interno.

---

### ✏️ Atualizar ordem existente
- **PUT** `/api/OrdemServico/{id}`
- Atualiza os dados de uma ordem existente.
- **Parâmetros**:
  - `id (int)`: ID da ordem.
  - `Body (JSON)`: Mesmo formato da criação.
- **Respostas**:
  - `200 OK`: Ordem atualizada.
  - `404 Not Found`: Ordem não localizada.
  - `400 Bad Request`: Falha na atualização.

---

### ❌ Remover ordem
- **DELETE** `/api/OrdemServico/{id}`
- Exclui uma ordem pelo ID.
- **Parâmetros**:
  - `id (int)`: ID da ordem.
- **Respostas**:
  - `200 OK`: Ordem removida.
  - `404 Not Found`: Ordem não localizada.
  - `400 Bad Request`: Falha ao excluir.

## 🛠️ Tecnologias Utilizadas
.NET 8

ASP.NET Core Web API

Entity Framework Core

Oracle Database

Migrations via EF Core

Arquitetura em camadas (Application, Domain, Infrastructure, Presentation)

## ▶️ Como Rodar o Projeto

### Pré-requisitos

- .NET 8 SDK
- Banco de Dados Oracle (ou outro compatível configurado no `ApplicationContext`)
- Visual Studio / VS Code

### Passos

1. **Clone o repositório:**

```bash
git clone https://github.com/mototrack-challenge/mototrack-backend-dotnet.git
```

2. Configure a string de conexão:

No arquivo `appsettings.json`, atualize a string de conexão com os dados do seu banco Oracle:
```csharp
"ConnectionStrings": {
        "Oracle": "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=USUARIO;Password=SENHA;"
}
```

3. Rode as migrations (se necessário):
```bash
dotnet ef database update
```

4. Inicie o projeto